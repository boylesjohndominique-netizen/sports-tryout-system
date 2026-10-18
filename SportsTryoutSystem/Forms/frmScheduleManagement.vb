Imports System.Data
Imports System.Drawing

Public Class frmScheduleManagement

    Private selectedScheduleId As Integer = 0
    Private headerPanel As Panel

    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True

        headerPanel = UIHelper.MakePanelHeader("Tryout Schedule Management", Me.Width)
        Me.Controls.Add(headerPanel)
        headerPanel.SendToBack()

        AddHandler Me.Resize, AddressOf OnFormResized
        AddHandler Me.Shown, AddressOf OnFormShown
        AddHandler dgv.CellFormatting, AddressOf Dgv_CellFormatting
    End Sub

    Private Sub OnFormShown(sender As Object, e As EventArgs)
        LayoutPanels()
        Try
            LoadSportsIntoCombo(cmbSport, False)
            LoadSportsIntoCombo(cmbFilterSport, True)
            If cmbFilterStatus.Items.Count > 0 Then cmbFilterStatus.SelectedIndex = 0
            If cmbStatus.Items.Count > 0 Then cmbStatus.SelectedIndex = 0
            LoadSchedules()
        Catch ex As Exception
            UIHelper.ShowError("Failed to load schedules: " & ex.Message)
        End Try
    End Sub

    Private Sub OnFormResized(sender As Object, e As EventArgs)
        LayoutPanels()
    End Sub

    ' ========================================================
    '  DYNAMIC RESPONSIVE LAYOUT ENGINE
    ' ========================================================

    Private Sub LayoutPanels()
        If Me.ClientSize.Width < 700 OrElse Me.ClientSize.Height < 450 Then Return

        Me.SuspendLayout()

        If headerPanel IsNot Nothing Then
            headerPanel.Width = Me.ClientSize.Width
        End If

        Dim topY As Integer = 72
        Dim marginX As Integer = 24
        Dim bottomMargin As Integer = 20
        Dim totalW As Integer = Me.ClientSize.Width - (marginX * 2)

        ' 1. Top Card: Schedule Configuration (pnlScheduleCard)
        Dim card1H As Integer = 270
        pnlScheduleCard.Location = New Point(marginX, topY)
        pnlScheduleCard.Size = New Size(totalW, card1H)

        LayoutScheduleCard(totalW)

        ' 2. Bottom Card: Timetable Grid & Filters (pnlGridCard)
        Dim gridY As Integer = topY + card1H + 16
        Dim gridH As Integer = Me.ClientSize.Height - gridY - bottomMargin
        pnlGridCard.Location = New Point(marginX, gridY)
        pnlGridCard.Size = New Size(totalW, Math.Max(200, gridH))

        LayoutGridCard(totalW, pnlGridCard.Height)

        Me.ResumeLayout(True)
    End Sub

    Private Sub LayoutScheduleCard(cardW As Integer)
        pnlScheduleCard.SuspendLayout()

        cardAccent.Width = cardW

        lblSectionTitle.Location = New Point(20, 14)
        lblSectionSub.Location = New Point(22, 38)
        lblModeBadge.Location = New Point(Math.Max(300, cardW - 200), 14)

        ' 4 columns for Row 1
        Dim colGap As Integer = 20
        Dim colW As Integer = CInt((cardW - 40 - (colGap * 3)) / 4)
        If colW < 120 Then colW = 120

        Dim col1X As Integer = 20
        Dim col2X As Integer = 20 + colW + colGap
        Dim col3X As Integer = 20 + (colW + colGap) * 2
        Dim col4X As Integer = 20 + (colW + colGap) * 3

        ' Row 1: Sport, Date, Time, Status
        lblSport.Location = New Point(col1X, 64)
        cmbSport.Location = New Point(col1X, 86)
        cmbSport.Size = New Size(colW, 26)

        lblDate.Location = New Point(col2X, 64)
        dtpDate.Location = New Point(col2X, 86)
        dtpDate.Size = New Size(colW, 26)

        lblTime.Location = New Point(col3X, 64)
        dtpTime.Location = New Point(col3X, 86)
        dtpTime.Size = New Size(colW, 26)

        lblStatus.Location = New Point(col4X, 64)
        cmbStatus.Location = New Point(col4X, 86)
        cmbStatus.Size = New Size(colW, 26)

        ' Row 2: Venue and Notes (2 wide columns)
        Dim halfW As Integer = CInt((cardW - 40 - colGap) / 2)
        If halfW < 200 Then halfW = 200

        lblVenue.Location = New Point(col1X, 126)
        txtVenue.Location = New Point(col1X, 148)
        txtVenue.Size = New Size(halfW, 26)

        Dim colNotesX As Integer = col1X + halfW + colGap
        lblNotes.Location = New Point(colNotesX, 126)
        txtNotes.Location = New Point(colNotesX, 148)
        txtNotes.Size = New Size(Math.Max(200, cardW - 20 - colNotesX), 26)

        ' Divider
        divCard.Location = New Point(20, 194)
        divCard.Size = New Size(cardW - 40, 1)

        ' Row 3: Action Buttons & Action Hint
        btnAdd.Location = New Point(20, 208)
        btnAdd.Size = New Size(175, 42)

        btnUpdate.Location = New Point(205, 208)
        btnUpdate.Size = New Size(165, 42)

        btnDelete.Location = New Point(380, 208)
        btnDelete.Size = New Size(155, 42)

        btnClear.Location = New Point(545, 208)
        btnClear.Size = New Size(135, 42)

        lblActionHint.Location = New Point(695, 218)
        lblActionHint.Size = New Size(Math.Max(160, cardW - 715), 24)

        pnlScheduleCard.ResumeLayout(True)
    End Sub

    Private Sub LayoutGridCard(cardW As Integer, cardH As Integer)
        pnlGridCard.SuspendLayout()

        gridAccent.Width = cardW

        lblGridTitle.Location = New Point(20, 14)
        lblGridSub.Location = New Point(22, 38)
        lblCountBadge.Location = New Point(Math.Max(300, cardW - 200), 14)

        ' Filter bar
        lblFilterSport.Location = New Point(20, 68)
        cmbFilterSport.Location = New Point(68, 64)
        cmbFilterSport.Size = New Size(180, 25)

        lblFilterStatus.Location = New Point(265, 68)
        cmbFilterStatus.Location = New Point(315, 64)
        cmbFilterStatus.Size = New Size(130, 25)

        lblSearch.Location = New Point(460, 68)
        Dim searchX As Integer = lblSearch.Right + 8
        Dim searchW As Integer = Math.Max(150, Math.Min(260, cardW - searchX - 140 - 20))
        txtSearch.Location = New Point(searchX, 64)
        txtSearch.Size = New Size(searchW, 25)

        btnResetFilter.Location = New Point(txtSearch.Right + 12, 63)
        btnResetFilter.Size = New Size(110, 27)

        ' DataGridView
        dgv.Location = New Point(20, 102)
        dgv.Size = New Size(cardW - 40, Math.Max(80, cardH - 116))

        pnlGridCard.ResumeLayout(True)
    End Sub

    ' ========================================================
    '  DATA & LOGIC
    ' ========================================================

    Private Sub LoadSportsIntoCombo(cmb As ComboBox, includeAllOption As Boolean)
        cmb.Items.Clear()
        If includeAllOption Then cmb.Items.Add("All Sports")
        Dim dt As DataTable = DatabaseHelper.GetDataTable("SELECT SportID, SportName FROM Sports WHERE IsActive=1 ORDER BY SportName")
        For Each row As DataRow In dt.Rows
            cmb.Items.Add(New SportItem(CInt(row("SportID")), row("SportName").ToString()))
        Next
        If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0
    End Sub

    Private Sub LoadSchedules()
        Dim sql As String = "SELECT sc.ScheduleID, sp.SportName AS Sport, sc.TryoutDate, sc.TryoutTime, sc.Venue, sc.Status, sc.Notes " &
                             "FROM Schedules sc INNER JOIN Sports sp ON sp.SportID = sc.SportID WHERE 1=1 "
        Dim params As New List(Of SQLiteParameter)

        If cmbFilterSport.SelectedItem IsNot Nothing AndAlso TypeOf cmbFilterSport.SelectedItem Is SportItem Then
            sql &= " AND sc.SportID=@sid "
            params.Add(New SQLiteParameter("@sid", CType(cmbFilterSport.SelectedItem, SportItem).SportID))
        End If

        If cmbFilterStatus.SelectedItem IsNot Nothing AndAlso cmbFilterStatus.Text <> "All" Then
            sql &= " AND sc.Status=@status "
            params.Add(New SQLiteParameter("@status", cmbFilterStatus.Text))
        End If

        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            sql &= " AND (sc.Venue LIKE @search OR sc.Notes LIKE @search OR sp.SportName LIKE @search) "
            params.Add(New SQLiteParameter("@search", "%" & txtSearch.Text.Trim() & "%"))
        End If

        sql &= " ORDER BY sc.TryoutDate, sc.TryoutTime"

        Dim dt As DataTable = DatabaseHelper.GetDataTable(sql, params.ToArray())
        dgv.DataSource = dt
        If dgv.Columns.Contains("ScheduleID") Then dgv.Columns("ScheduleID").Visible = False

        ' Customize column headers and weights
        If dgv.Columns.Contains("Sport") Then
            dgv.Columns("Sport").HeaderText = "Sport Name"
            dgv.Columns("Sport").FillWeight = 120
        End If
        If dgv.Columns.Contains("TryoutDate") Then
            dgv.Columns("TryoutDate").HeaderText = "Date"
            dgv.Columns("TryoutDate").FillWeight = 90
        End If
        If dgv.Columns.Contains("TryoutTime") Then
            dgv.Columns("TryoutTime").HeaderText = "Time"
            dgv.Columns("TryoutTime").FillWeight = 80
        End If
        If dgv.Columns.Contains("Venue") Then
            dgv.Columns("Venue").HeaderText = "Venue / Location"
            dgv.Columns("Venue").FillWeight = 150
        End If
        If dgv.Columns.Contains("Status") Then
            dgv.Columns("Status").HeaderText = "Status"
            dgv.Columns("Status").FillWeight = 90
        End If
        If dgv.Columns.Contains("Notes") Then
            dgv.Columns("Notes").HeaderText = "Notes / Remarks"
            dgv.Columns("Notes").FillWeight = 160
        End If

        lblCountBadge.Text = $"{dt.Rows.Count} Session(s) Listed"
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs) Handles cmbFilterSport.SelectedIndexChanged, cmbFilterStatus.SelectedIndexChanged
        LoadSchedules()
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadSchedules()
    End Sub

    Private Sub BtnResetFilter_Click(sender As Object, e As EventArgs) Handles btnResetFilter.Click
        cmbFilterSport.SelectedIndex = 0
        cmbFilterStatus.SelectedIndex = 0
        txtSearch.Text = ""
        LoadSchedules()
    End Sub

    Private Sub Dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If dgv.Columns Is Nothing OrElse e.ColumnIndex >= dgv.Columns.Count Then Return
            Dim col = dgv.Columns(e.ColumnIndex)
            If col Is Nothing OrElse e.Value Is Nothing Then Return

            ' Format TryoutDate
            If col.Name = "TryoutDate" AndAlso Not IsDBNull(e.Value) Then
                Dim d As Date
                If Date.TryParse(e.Value.ToString(), d) Then
                    e.Value = d.ToString("MMM dd, yyyy")
                    e.FormattingApplied = True
                End If
            End If

            ' Format TryoutTime
            If col.Name = "TryoutTime" AndAlso Not IsDBNull(e.Value) Then
                Dim t As TimeSpan
                If TimeSpan.TryParse(e.Value.ToString(), t) Then
                    Dim dummyDate As DateTime = DateTime.Today.Add(t)
                    e.Value = dummyDate.ToString("hh:mm tt")
                    e.FormattingApplied = True
                Else
                    Dim dt As DateTime
                    If DateTime.TryParse(e.Value.ToString(), dt) Then
                        e.Value = dt.ToString("hh:mm tt")
                        e.FormattingApplied = True
                    End If
                End If
            End If

            ' Format Status
            If col.Name = "Status" Then
                Dim statusText As String = e.Value.ToString().Trim()
                e.CellStyle.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
                Select Case statusText.ToLower()
                    Case "upcoming"
                        e.CellStyle.ForeColor = Color.FromArgb(29, 78, 216)
                        e.CellStyle.BackColor = Color.FromArgb(239, 246, 255)
                    Case "completed"
                        e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52)
                        e.CellStyle.BackColor = Color.FromArgb(240, 253, 244)
                    Case "cancelled"
                        e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28)
                        e.CellStyle.BackColor = Color.FromArgb(254, 242, 242)
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub Dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        If e.RowIndex < 0 Then Return
        Dim row As DataGridViewRow = dgv.Rows(e.RowIndex)
        selectedScheduleId = CInt(row.Cells("ScheduleID").Value)

        Dim sportName As String = row.Cells("Sport").Value.ToString()
        For Each item As Object In cmbSport.Items
            If TypeOf item Is SportItem AndAlso CType(item, SportItem).SportName = sportName Then
                cmbSport.SelectedItem = item
                Exit For
            End If
        Next

        Dim parsedDate As Date
        If Date.TryParse(row.Cells("TryoutDate").Value.ToString(), parsedDate) Then
            dtpDate.Value = parsedDate
        End If

        Dim timeStr As String = row.Cells("TryoutTime").Value.ToString()
        Dim parsedTime As Date
        If Date.TryParse(Date.Today.ToShortDateString() & " " & timeStr, parsedTime) Then
            dtpTime.Value = parsedTime
        End If

        txtVenue.Text = If(IsDBNull(row.Cells("Venue").Value), "", row.Cells("Venue").Value.ToString())
        cmbStatus.Text = If(IsDBNull(row.Cells("Status").Value), "Upcoming", row.Cells("Status").Value.ToString())
        txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())

        lblModeBadge.Text = $"✎ EDITING SESSION #{selectedScheduleId}"
        lblModeBadge.BackColor = Color.FromArgb(254, 240, 138)
        lblModeBadge.ForeColor = Color.FromArgb(133, 77, 14)
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateForm() Then Return
        Try
            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Schedules (SportID, TryoutDate, TryoutTime, Venue, Status, Notes) VALUES (@s,@d,@t,@v,@st,@n)",
                New SQLiteParameter("@s", CType(cmbSport.SelectedItem, SportItem).SportID),
                New SQLiteParameter("@d", dtpDate.Value.ToString("yyyy-MM-dd")),
                New SQLiteParameter("@t", dtpTime.Value.ToString("HH:mm")),
                New SQLiteParameter("@v", txtVenue.Text.Trim()),
                New SQLiteParameter("@st", cmbStatus.Text),
                New SQLiteParameter("@n", txtNotes.Text.Trim()))
            UIHelper.ShowInfo("Tryout schedule added successfully.")
            BtnClear_Click(sender, e)
            LoadSchedules()
        Catch ex As Exception
            UIHelper.ShowError("Failed to add schedule: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedScheduleId = 0 Then
            UIHelper.ShowError("Select a schedule from the list first.")
            Return
        End If
        If Not ValidateForm() Then Return
        Try
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Schedules SET SportID=@s, TryoutDate=@d, TryoutTime=@t, Venue=@v, Status=@st, Notes=@n WHERE ScheduleID=@id",
                New SQLiteParameter("@s", CType(cmbSport.SelectedItem, SportItem).SportID),
                New SQLiteParameter("@d", dtpDate.Value.ToString("yyyy-MM-dd")),
                New SQLiteParameter("@t", dtpTime.Value.ToString("HH:mm")),
                New SQLiteParameter("@v", txtVenue.Text.Trim()),
                New SQLiteParameter("@st", cmbStatus.Text),
                New SQLiteParameter("@n", txtNotes.Text.Trim()),
                New SQLiteParameter("@id", selectedScheduleId))
            UIHelper.ShowInfo("Schedule updated successfully.")
            LoadSchedules()
        Catch ex As Exception
            UIHelper.ShowError("Failed to update schedule: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedScheduleId = 0 Then
            UIHelper.ShowError("Select a schedule from the list first.")
            Return
        End If
        If Not UIHelper.Confirm("Delete this schedule?") Then Return
        Try
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Schedules WHERE ScheduleID=@id", New SQLiteParameter("@id", selectedScheduleId))
            BtnClear_Click(sender, e)
            LoadSchedules()
        Catch ex As Exception
            UIHelper.ShowError("Failed to delete schedule: " & ex.Message)
        End Try
    End Sub

    Private Function ValidateForm() As Boolean
        If cmbSport.SelectedItem Is Nothing OrElse Not TypeOf cmbSport.SelectedItem Is SportItem Then
            UIHelper.ShowError("Select a sport.")
            Return False
        End If
        If txtVenue.Text.Trim() = "" Then
            UIHelper.ShowError("Enter a venue.")
            Return False
        End If
        Return True
    End Function

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        selectedScheduleId = 0
        If cmbSport.Items.Count > 0 Then cmbSport.SelectedIndex = 0
        dtpDate.Value = Date.Today
        dtpTime.Value = Date.Now
        txtVenue.Text = ""
        If cmbStatus.Items.Count > 0 Then cmbStatus.SelectedIndex = 0
        txtNotes.Text = ""

        lblModeBadge.Text = "✚ NEW SESSION MODE"
        lblModeBadge.BackColor = Color.FromArgb(220, 252, 231)
        lblModeBadge.ForeColor = Color.FromArgb(22, 101, 52)
    End Sub

End Class
