Public Class frmScheduleManagement
    Inherits Form

    Private dgv As DataGridView
    Private cmbSport As ComboBox
    Private cmbStatus As ComboBox
    Private cmbFilterSport As ComboBox
    Private cmbFilterStatus As ComboBox
    Private dtpDate As DateTimePicker
    Private dtpTime As DateTimePicker
    Private txtVenue As TextBox
    Private txtNotes As TextBox
    Private selectedScheduleId As Integer = 0

    Public Sub New()
        Me.Text = "Tryout Schedule Management"
        Me.Dock = DockStyle.Fill
        Me.BackColor = UIHelper.ColorBackground
        BuildUI()
        LoadSportsIntoCombo(cmbSport, False)
        LoadSportsIntoCombo(cmbFilterSport, True)
        LoadSchedules()
    End Sub

    Private Sub BuildUI()
        Dim header As Panel = UIHelper.MakePanelHeader("Tryout Schedule Management", Me.Width)
        Me.Controls.Add(header)

        ' ── Input card ──
        Dim pnlForm As New Panel()
        pnlForm.Location = New Point(30, 75)
        pnlForm.Size = New Size(950, 125)
        pnlForm.BackColor = Color.White
        pnlForm.BorderStyle = BorderStyle.None

        Dim formAccent As New Panel()
        formAccent.Dock = DockStyle.Top
        formAccent.Height = 3
        formAccent.BackColor = UIHelper.ColorGold
        pnlForm.Controls.Add(formAccent)

        Dim lblSport As Label = UIHelper.MakeLabel("SPORT", 20, 12, 100)
        lblSport.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblSport.ForeColor = UIHelper.ColorTextSecondary
        cmbSport = UIHelper.MakeComboBox(20, 32, 170)

        Dim lblDate As Label = UIHelper.MakeLabel("DATE", 200, 12, 100)
        lblDate.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblDate.ForeColor = UIHelper.ColorTextSecondary
        dtpDate = New DateTimePicker()
        dtpDate.Location = New Point(200, 32)
        dtpDate.Size = New Size(145, 28)
        dtpDate.Format = DateTimePickerFormat.Short
        dtpDate.Font = UIHelper.FontRegular

        Dim lblTime As Label = UIHelper.MakeLabel("TIME", 355, 12, 80)
        lblTime.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblTime.ForeColor = UIHelper.ColorTextSecondary
        dtpTime = New DateTimePicker()
        dtpTime.Location = New Point(355, 32)
        dtpTime.Size = New Size(110, 28)
        dtpTime.Format = DateTimePickerFormat.Time
        dtpTime.ShowUpDown = True
        dtpTime.Font = UIHelper.FontRegular

        Dim lblVenue As Label = UIHelper.MakeLabel("VENUE", 475, 12, 100)
        lblVenue.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblVenue.ForeColor = UIHelper.ColorTextSecondary
        txtVenue = UIHelper.MakeTextBox(475, 32, 180)

        Dim lblStatus As Label = UIHelper.MakeLabel("STATUS", 665, 12, 100)
        lblStatus.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblStatus.ForeColor = UIHelper.ColorTextSecondary
        cmbStatus = UIHelper.MakeComboBox(665, 32, 130)
        cmbStatus.Items.AddRange(New String() {"Upcoming", "Completed", "Cancelled"})
        cmbStatus.SelectedIndex = 0

        Dim lblNotes As Label = UIHelper.MakeLabel("NOTES", 805, 12, 100)
        lblNotes.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblNotes.ForeColor = UIHelper.ColorTextSecondary
        txtNotes = UIHelper.MakeTextBox(805, 32, 130)

        pnlForm.Controls.Add(lblSport)
        pnlForm.Controls.Add(cmbSport)
        pnlForm.Controls.Add(lblDate)
        pnlForm.Controls.Add(dtpDate)
        pnlForm.Controls.Add(lblTime)
        pnlForm.Controls.Add(dtpTime)
        pnlForm.Controls.Add(lblVenue)
        pnlForm.Controls.Add(txtVenue)
        pnlForm.Controls.Add(lblStatus)
        pnlForm.Controls.Add(cmbStatus)
        pnlForm.Controls.Add(lblNotes)
        pnlForm.Controls.Add(txtNotes)

        ' Action buttons
        Dim btnAdd As Button = UIHelper.MakeButton("✚ Add Schedule", 20, 76, 155, "success")
        btnAdd.Height = 34
        AddHandler btnAdd.Click, AddressOf BtnAdd_Click
        pnlForm.Controls.Add(btnAdd)

        Dim btnUpdate As Button = UIHelper.MakeButton("✎ Update", 185, 76, 120, "primary")
        btnUpdate.Height = 34
        AddHandler btnUpdate.Click, AddressOf BtnUpdate_Click
        pnlForm.Controls.Add(btnUpdate)

        Dim btnDelete As Button = UIHelper.MakeButton("✕ Delete", 315, 76, 120, "danger")
        btnDelete.Height = 34
        AddHandler btnDelete.Click, AddressOf BtnDelete_Click
        pnlForm.Controls.Add(btnDelete)

        Dim btnClear As Button = UIHelper.MakeButton("Clear", 445, 76, 100, "secondary")
        btnClear.Height = 34
        AddHandler btnClear.Click, AddressOf BtnClear_Click
        pnlForm.Controls.Add(btnClear)

        Me.Controls.Add(pnlForm)

        ' ── Filter bar ──
        Dim pnlFilter As New Panel()
        pnlFilter.Location = New Point(30, 215)
        pnlFilter.Size = New Size(950, 42)
        pnlFilter.BackColor = Color.FromArgb(248, 250, 252)
        pnlFilter.BorderStyle = BorderStyle.None

        Dim lblFilterIcon As New Label()
        lblFilterIcon.Text = "🔍"
        lblFilterIcon.Font = New Font("Segoe UI", 12!)
        lblFilterIcon.Location = New Point(10, 8)
        lblFilterIcon.AutoSize = True
        pnlFilter.Controls.Add(lblFilterIcon)

        Dim lblFilterSport As Label = UIHelper.MakeLabel("Sport:", 38, 12, 45)
        lblFilterSport.ForeColor = UIHelper.ColorTextSecondary
        cmbFilterSport = UIHelper.MakeComboBox(85, 8, 180)
        AddHandler cmbFilterSport.SelectedIndexChanged, AddressOf Filter_Changed

        Dim lblFilterStatus As Label = UIHelper.MakeLabel("Status:", 280, 12, 50)
        lblFilterStatus.ForeColor = UIHelper.ColorTextSecondary
        cmbFilterStatus = UIHelper.MakeComboBox(335, 8, 160)
        cmbFilterStatus.Items.AddRange(New String() {"All", "Upcoming", "Completed", "Cancelled"})
        cmbFilterStatus.SelectedIndex = 0
        AddHandler cmbFilterStatus.SelectedIndexChanged, AddressOf Filter_Changed

        pnlFilter.Controls.Add(lblFilterSport)
        pnlFilter.Controls.Add(cmbFilterSport)
        pnlFilter.Controls.Add(lblFilterStatus)
        pnlFilter.Controls.Add(cmbFilterStatus)
        Me.Controls.Add(pnlFilter)

        ' ── Data grid ──
        dgv = UIHelper.MakeDataGridView(30, 268, 950, 310)
        AddHandler dgv.CellClick, AddressOf Dgv_CellClick
        Me.Controls.Add(dgv)
    End Sub

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

        sql &= " ORDER BY sc.TryoutDate, sc.TryoutTime"

        dgv.DataSource = DatabaseHelper.GetDataTable(sql, params.ToArray())
        If dgv.Columns.Contains("ScheduleID") Then dgv.Columns("ScheduleID").Visible = False
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        LoadSchedules()
    End Sub

    Private Sub Dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs)
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

        dtpDate.Value = Date.Parse(row.Cells("TryoutDate").Value.ToString())
        dtpTime.Value = Date.Parse(Date.Today.ToShortDateString() & " " & row.Cells("TryoutTime").Value.ToString())
        txtVenue.Text = row.Cells("Venue").Value.ToString()
        cmbStatus.Text = row.Cells("Status").Value.ToString()
        txtNotes.Text = If(IsDBNull(row.Cells("Notes").Value), "", row.Cells("Notes").Value.ToString())
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
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
            UIHelper.ShowInfo("Tryout schedule added.")
            BtnClear_Click(sender, e)
            LoadSchedules()
        Catch ex As Exception
            UIHelper.ShowError("Failed to add schedule: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs)
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
            UIHelper.ShowInfo("Schedule updated.")
            LoadSchedules()
        Catch ex As Exception
            UIHelper.ShowError("Failed to update schedule: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)
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

    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        selectedScheduleId = 0
        If cmbSport.Items.Count > 0 Then cmbSport.SelectedIndex = 0
        dtpDate.Value = Date.Today
        dtpTime.Value = Date.Now
        txtVenue.Text = ""
        cmbStatus.SelectedIndex = 0
        txtNotes.Text = ""
    End Sub

End Class
