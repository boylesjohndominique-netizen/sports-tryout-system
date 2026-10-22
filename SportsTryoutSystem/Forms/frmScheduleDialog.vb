Imports System.Data
Imports System.Drawing

''' <summary>
''' Floating pop-up modal dialog for creating and editing tryout schedule sessions.
''' Configures sport discipline, date, time, venue, status, and notes.
''' </summary>
Public Class frmScheduleDialog

    Private targetScheduleId As Integer = 0
    Private isEditMode As Boolean = False

    Public Sub New(Optional scheduleId As Integer = 0)
        InitializeComponent()
        Me.targetScheduleId = scheduleId
        Me.isEditMode = (scheduleId > 0)
        SetupDialog()
    End Sub

    Private Sub SetupDialog()
        ' Paint card border
        AddHandler cardContent.Paint, AddressOf DrawCardBorder

        ' Wire actions
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        AddHandler btnCancel.Click, Sub(s, e) Me.Close()

        ' Load sports
        LoadSports()

        If isEditMode Then
            ' ── EDIT MODE ──
            Me.Text = "Edit Tryout Schedule"
            lblTitle.Text = "✎  Edit Tryout Schedule"
            lblSub.Text = "Update session date, time, venue location, status, or remarks."
            btnSave.Text = "💾  Save Changes"

            LoadExistingScheduleData()
        Else
            ' ── CREATE MODE ──
            Me.Text = "Create Tryout Schedule"
            lblTitle.Text = "📅  Create Tryout Schedule"
            lblSub.Text = "Configure tryout session date, time, venue location, status, and sport discipline."
            btnSave.Text = "✚  Create Schedule"

            dtpDate.Value = Date.Today
            dtpTime.Value = Date.Now
            If cmbStatus.Items.Count > 0 Then cmbStatus.SelectedIndex = 0
            txtVenue.Text = ""
            txtNotes.Text = ""
        End If
    End Sub

    Private Sub DrawCardBorder(sender As Object, e As PaintEventArgs)
        Dim pnl = TryCast(sender, Panel)
        If pnl Is Nothing Then Return
        Using pen As New Pen(Color.FromArgb(226, 232, 240), 1)
            e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
    End Sub

    Private Sub LoadSports()
        Try
            cmbSport.Items.Clear()
            Dim dt As DataTable = DatabaseHelper.GetDataTable("SELECT SportID, SportName FROM Sports WHERE IsActive=1 ORDER BY SportName ASC")
            For Each row As DataRow In dt.Rows
                cmbSport.Items.Add(New SportItem(Convert.ToInt32(row("SportID")), row("SportName").ToString()))
            Next
            If cmbSport.Items.Count > 0 Then cmbSport.SelectedIndex = 0
        Catch ex As Exception
            lblFeedback.Text = "Error loading sports: " & ex.Message
        End Try
    End Sub

    Private Sub LoadExistingScheduleData()
        lblFeedback.Text = ""
        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT sc.SportID, sp.SportName, sc.TryoutDate, sc.TryoutTime, sc.Venue, sc.Status, sc.Notes " &
                "FROM Schedules sc LEFT JOIN Sports sp ON sp.SportID = sc.SportID WHERE sc.ScheduleID=@id",
                New SQLiteParameter("@id", targetScheduleId))

            If dt.Rows.Count > 0 Then
                Dim row = dt.Rows(0)
                Dim sportId As Integer = Convert.ToInt32(row("SportID"))
                Dim sportName As String = If(IsDBNull(row("SportName")), "", row("SportName").ToString())

                ' Match sport in combobox
                Dim matched As Boolean = False
                For Each item As Object In cmbSport.Items
                    If TypeOf item Is SportItem AndAlso CType(item, SportItem).SportID = sportId Then
                        cmbSport.SelectedItem = item
                        matched = True
                        Exit For
                    End If
                Next

                ' If sport is inactive or not currently in list, add it so it can still be displayed
                If Not matched AndAlso Not String.IsNullOrEmpty(sportName) Then
                    Dim inactiveSport As New SportItem(sportId, sportName & " (Inactive)")
                    cmbSport.Items.Add(inactiveSport)
                    cmbSport.SelectedItem = inactiveSport
                End If

                ' Parse Date
                Dim parsedDate As Date
                If Date.TryParse(row("TryoutDate").ToString(), parsedDate) Then
                    dtpDate.Value = parsedDate
                End If

                ' Parse Time
                Dim timeStr As String = If(IsDBNull(row("TryoutTime")), "", row("TryoutTime").ToString())
                Dim parsedTime As Date
                If Date.TryParse(Date.Today.ToShortDateString() & " " & timeStr, parsedTime) Then
                    dtpTime.Value = parsedTime
                End If

                ' Venue & Notes
                txtVenue.Text = If(IsDBNull(row("Venue")), "", row("Venue").ToString())
                txtNotes.Text = If(IsDBNull(row("Notes")), "", row("Notes").ToString())

                ' Status
                Dim statusStr As String = If(IsDBNull(row("Status")), "Upcoming", row("Status").ToString())
                Dim statusIndex As Integer = cmbStatus.FindStringExact(statusStr)
                If statusIndex >= 0 Then
                    cmbStatus.SelectedIndex = statusIndex
                Else
                    cmbStatus.Text = statusStr
                End If
            End If

        Catch ex As Exception
            lblFeedback.Text = "Failed to load schedule data: " & ex.Message
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        lblFeedback.Text = ""

        ' Validation
        If cmbSport.SelectedItem Is Nothing OrElse Not TypeOf cmbSport.SelectedItem Is SportItem Then
            lblFeedback.Text = "Please select a valid sport discipline."
            cmbSport.Focus()
            Return
        End If

        Dim selectedSport = CType(cmbSport.SelectedItem, SportItem)
        Dim venue As String = txtVenue.Text.Trim()

        If String.IsNullOrWhiteSpace(venue) Then
            lblFeedback.Text = "Please specify the venue / location for this tryout session."
            txtVenue.Focus()
            Return
        End If

        Dim dateStr As String = dtpDate.Value.ToString("yyyy-MM-dd")
        Dim timeStr As String = dtpTime.Value.ToString("HH:mm")
        Dim statusStr As String = If(cmbStatus.SelectedItem IsNot Nothing, cmbStatus.Text, "Upcoming")
        Dim notesStr As String = txtNotes.Text.Trim()

        Try
            If isEditMode Then
                ' UPDATE existing schedule
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Schedules SET SportID=@s, TryoutDate=@d, TryoutTime=@t, Venue=@v, Status=@st, Notes=@n WHERE ScheduleID=@id",
                    New SQLiteParameter("@s", selectedSport.SportID),
                    New SQLiteParameter("@d", dateStr),
                    New SQLiteParameter("@t", timeStr),
                    New SQLiteParameter("@v", venue),
                    New SQLiteParameter("@st", statusStr),
                    New SQLiteParameter("@n", notesStr),
                    New SQLiteParameter("@id", targetScheduleId))

                UIHelper.ShowInfo("Tryout schedule session updated successfully.", "Schedule Updated")
            Else
                ' INSERT new schedule
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO Schedules (SportID, TryoutDate, TryoutTime, Venue, Status, Notes) VALUES (@s, @d, @t, @v, @st, @n)",
                    New SQLiteParameter("@s", selectedSport.SportID),
                    New SQLiteParameter("@d", dateStr),
                    New SQLiteParameter("@t", timeStr),
                    New SQLiteParameter("@v", venue),
                    New SQLiteParameter("@st", statusStr),
                    New SQLiteParameter("@n", notesStr))

                UIHelper.ShowInfo("Tryout schedule session created successfully.", "Schedule Created")
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            lblFeedback.Text = "Database error: " & ex.Message
        End Try
    End Sub

End Class
