Imports System.Data
Imports System.Drawing

''' <summary>
''' Floating pop-up modal dialog for creating and editing sports disciplines.
''' Handles sport metadata, tryout availability, and coach/evaluator assignments.
''' </summary>
Public Class frmSportDialog

    Public Class CoachItem
        Public Property UserID As Integer
        Public Property FullName As String

        Public Sub New(id As Integer, name As String)
            Me.UserID = id
            Me.FullName = name
        End Sub

        Public Overrides Function ToString() As String
            Return FullName
        End Function
    End Class

    Private targetSportId As Integer = 0
    Private isEditMode As Boolean = False

    Public Sub New(Optional sportId As Integer = 0)
        InitializeComponent()
        Me.targetSportId = sportId
        Me.isEditMode = (sportId > 0)
        SetupDialog()
    End Sub

    Private Sub SetupDialog()
        ' Paint card border
        AddHandler cardContent.Paint, AddressOf DrawCardBorder

        ' Wire action events
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        AddHandler btnCancel.Click, Sub(s, e) Me.Close()
        AddHandler btnSelectAllCoaches.Click, AddressOf BtnSelectAllCoaches_Click
        AddHandler btnClearAllCoaches.Click, AddressOf BtnClearAllCoaches_Click

        ' Load active certified coaches
        LoadCoachesList()

        If isEditMode Then
            ' ── EDIT MODE ──
            Me.Text = "Edit Sport"
            lblTitle.Text = "✎  Edit Sport Discipline"
            lblSub.Text = "Update sport details, active tryout availability, and assigned coaches."
            btnSave.Text = "💾  Save Changes"

            LoadExistingSportData()
        Else
            ' ── CREATE MODE ──
            Me.Text = "Create New Sport"
            lblTitle.Text = "🏆  Create New Sport Discipline"
            lblSub.Text = "Configure sport details, active tryout availability, and assign certified coaches."
            btnSave.Text = "✚  Create Sport"

            chkIsActive.Checked = True
            txtSportName.Text = ""
            txtDescription.Text = ""
        End If
    End Sub

    Private Sub DrawCardBorder(sender As Object, e As PaintEventArgs)
        Dim pnl = TryCast(sender, Panel)
        If pnl Is Nothing Then Return
        Using pen As New Pen(Color.FromArgb(226, 232, 240), 1)
            e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
    End Sub

    Private Sub LoadCoachesList()
        Try
            clbCoaches.Items.Clear()
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT UserID, FullName FROM Users WHERE Role='Coach' AND IsActive=1 ORDER BY FullName")
            For Each row As DataRow In dt.Rows
                clbCoaches.Items.Add(New CoachItem(Convert.ToInt32(row("UserID")), row("FullName").ToString()))
            Next
        Catch ex As Exception
            lblFeedback.Text = "Failed to load coach roster: " & ex.Message
        End Try
    End Sub

    Private Sub LoadExistingSportData()
        lblFeedback.Text = ""
        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT SportName, Description, IsActive FROM Sports WHERE SportID=@id",
                New SQLiteParameter("@id", targetSportId))

            If dt.Rows.Count > 0 Then
                Dim row = dt.Rows(0)
                txtSportName.Text = row("SportName").ToString()
                txtDescription.Text = If(IsDBNull(row("Description")), "", row("Description").ToString())
                chkIsActive.Checked = (Convert.ToInt32(row("IsActive")) = 1)

                ' Load assigned coaches
                Dim dtCoaches As DataTable = DatabaseHelper.GetDataTable(
                    "SELECT UserID FROM SportCoaches WHERE SportID=@id",
                    New SQLiteParameter("@id", targetSportId))

                Dim assignedIds As New HashSet(Of Integer)
                For Each r As DataRow In dtCoaches.Rows
                    assignedIds.Add(Convert.ToInt32(r("UserID")))
                Next

                For i As Integer = 0 To clbCoaches.Items.Count - 1
                    Dim item As CoachItem = CType(clbCoaches.Items(i), CoachItem)
                    clbCoaches.SetItemChecked(i, assignedIds.Contains(item.UserID))
                Next
            Else
                UIHelper.ShowError("Sport discipline not found.")
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        Catch ex As Exception
            UIHelper.ShowError("Failed to load sport details: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnSelectAllCoaches_Click(sender As Object, e As EventArgs)
        For i As Integer = 0 To clbCoaches.Items.Count - 1
            clbCoaches.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub BtnClearAllCoaches_Click(sender As Object, e As EventArgs)
        For i As Integer = 0 To clbCoaches.Items.Count - 1
            clbCoaches.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        lblFeedback.Text = ""

        Dim sportName As String = txtSportName.Text.Trim()
        Dim description As String = txtDescription.Text.Trim()
        Dim isActive As Integer = If(chkIsActive.Checked, 1, 0)

        ' Validation
        If String.IsNullOrWhiteSpace(sportName) Then
            lblFeedback.Text = "Sport name is required."
            txtSportName.Focus()
            Return
        End If

        ' Verify unique sport name
        Try
            Dim countSql As String
            Dim countParam As SQLiteParameter
            If isEditMode Then
                countSql = "SELECT COUNT(*) FROM Sports WHERE SportName=@n AND SportID<>@id"
                countParam = New SQLiteParameter("@id", targetSportId)
            Else
                countSql = "SELECT COUNT(*) FROM Sports WHERE SportName=@n"
                countParam = Nothing
            End If

            Dim existing As Object
            If countParam IsNot Nothing Then
                existing = DatabaseHelper.ExecuteScalar(countSql, New SQLiteParameter("@n", sportName), countParam)
            Else
                existing = DatabaseHelper.ExecuteScalar(countSql, New SQLiteParameter("@n", sportName))
            End If

            If existing IsNot Nothing AndAlso Convert.ToInt32(existing) > 0 Then
                lblFeedback.Text = "A sport discipline with this name already exists."
                txtSportName.Focus()
                Return
            End If

            ' Insert or Update sport record
            Dim savedSportId As Integer = targetSportId

            If Not isEditMode Then
                ' ── INSERT NEW SPORT ──
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO Sports (SportName, Description, IsActive) VALUES (@n,@d,@a)",
                    New SQLiteParameter("@n", sportName),
                    New SQLiteParameter("@d", description),
                    New SQLiteParameter("@a", isActive))

                Dim idObj As Object = DatabaseHelper.ExecuteScalar(
                    "SELECT MAX(SportID) FROM Sports WHERE SportName=@n",
                    New SQLiteParameter("@n", sportName))
                If idObj IsNot Nothing AndAlso Not IsDBNull(idObj) Then
                    savedSportId = Convert.ToInt32(idObj)
                End If
            Else
                ' ── UPDATE EXISTING SPORT ──
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Sports SET SportName=@n, Description=@d, IsActive=@a WHERE SportID=@id",
                    New SQLiteParameter("@n", sportName),
                    New SQLiteParameter("@d", description),
                    New SQLiteParameter("@a", isActive),
                    New SQLiteParameter("@id", targetSportId))
            End If

            ' ── UPDATE COACH ASSIGNMENTS ──
            If savedSportId > 0 Then
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM SportCoaches WHERE SportID=@id",
                    New SQLiteParameter("@id", savedSportId))

                For i As Integer = 0 To clbCoaches.Items.Count - 1
                    If clbCoaches.GetItemChecked(i) Then
                        Dim item As CoachItem = CType(clbCoaches.Items(i), CoachItem)
                        DatabaseHelper.ExecuteNonQuery(
                            "INSERT INTO SportCoaches (SportID, UserID) VALUES (@s,@u)",
                            New SQLiteParameter("@s", savedSportId),
                            New SQLiteParameter("@u", item.UserID))
                    End If
                Next
            End If

            UIHelper.ShowInfo(
                String.Format("Sport discipline '{0}' {1} successfully.", sportName, If(isEditMode, "updated", "registered")),
                "Sport Saved")

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            lblFeedback.Text = "Database error: " & ex.Message
        End Try
    End Sub

End Class
