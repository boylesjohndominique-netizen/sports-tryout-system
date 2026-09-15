Imports System.Text

Public Class frmApplicantRecords
    Inherits Form

    Private dgv As DataGridView
    Private txtSearchName As TextBox
    Private txtSearchStudentNumber As TextBox
    Private cmbFilterSport As ComboBox
    Private cmbFilterStatus As ComboBox

    Public Sub New()
        Me.Text = "Applicant Records"
        Me.Dock = DockStyle.Fill
        Me.BackColor = UIHelper.ColorBackground
        BuildUI()
        LoadSportsFilter()
        LoadApplicants()
    End Sub

    Private Sub BuildUI()
        Dim header As Panel = UIHelper.MakePanelHeader("Applicant Records", Me.Width)
        Me.Controls.Add(header)

        ' ── Search & Filter card ──
        Dim pnlFilter As New Panel()
        pnlFilter.Location = New Point(30, 75)
        pnlFilter.Size = New Size(950, 105)
        pnlFilter.BackColor = Color.White
        pnlFilter.BorderStyle = BorderStyle.None

        Dim filterAccent As New Panel()
        filterAccent.Dock = DockStyle.Top
        filterAccent.Height = 3
        filterAccent.BackColor = UIHelper.ColorGold
        pnlFilter.Controls.Add(filterAccent)

        Dim lblFilterTitle As New Label()
        lblFilterTitle.Text = "🔍  Search & Filter"
        lblFilterTitle.Font = UIHelper.FontSubHeader
        lblFilterTitle.ForeColor = UIHelper.ColorPrimary
        lblFilterTitle.Location = New Point(20, 10)
        lblFilterTitle.AutoSize = True
        pnlFilter.Controls.Add(lblFilterTitle)

        Dim lblName As Label = UIHelper.MakeLabel("NAME", 20, 38, 100)
        lblName.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblName.ForeColor = UIHelper.ColorTextSecondary
        txtSearchName = UIHelper.MakeTextBox(20, 56, 180)

        Dim lblId As Label = UIHelper.MakeLabel("STUDENT ID", 210, 38, 100)
        lblId.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblId.ForeColor = UIHelper.ColorTextSecondary
        txtSearchStudentNumber = UIHelper.MakeTextBox(210, 56, 160)

        Dim lblSport As Label = UIHelper.MakeLabel("SPORT", 380, 38, 100)
        lblSport.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblSport.ForeColor = UIHelper.ColorTextSecondary
        cmbFilterSport = UIHelper.MakeComboBox(380, 56, 175)

        Dim lblStatus As Label = UIHelper.MakeLabel("SELECTION STATUS", 565, 38, 130)
        lblStatus.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblStatus.ForeColor = UIHelper.ColorTextSecondary
        cmbFilterStatus = UIHelper.MakeComboBox(565, 56, 155)
        cmbFilterStatus.Items.AddRange(New String() {"All", "Pending", "Selected", "NotSelected", "ForFurtherEvaluation"})
        cmbFilterStatus.SelectedIndex = 0

        Dim btnSearch As Button = UIHelper.MakeButton("Search", 730, 54, 100, "primary")
        btnSearch.Height = 30
        AddHandler btnSearch.Click, AddressOf BtnSearch_Click

        Dim btnClearFilter As Button = UIHelper.MakeButton("Clear", 838, 54, 90, "secondary")
        btnClearFilter.Height = 30
        AddHandler btnClearFilter.Click, AddressOf BtnClearFilter_Click

        pnlFilter.Controls.Add(lblName)
        pnlFilter.Controls.Add(txtSearchName)
        pnlFilter.Controls.Add(lblId)
        pnlFilter.Controls.Add(txtSearchStudentNumber)
        pnlFilter.Controls.Add(lblSport)
        pnlFilter.Controls.Add(cmbFilterSport)
        pnlFilter.Controls.Add(lblStatus)
        pnlFilter.Controls.Add(cmbFilterStatus)
        pnlFilter.Controls.Add(btnSearch)
        pnlFilter.Controls.Add(btnClearFilter)

        Me.Controls.Add(pnlFilter)

        ' ── View Details button ──
        Dim btnViewDetails As Button = UIHelper.MakeButton("📋 View Details", 30, 192, 160, "gold")
        btnViewDetails.Height = 34
        AddHandler btnViewDetails.Click, AddressOf BtnViewDetails_Click
        Me.Controls.Add(btnViewDetails)

        ' ── Data grid ──
        dgv = UIHelper.MakeDataGridView(30, 235, 950, 345)
        AddHandler dgv.CellDoubleClick, AddressOf Dgv_CellDoubleClick
        Me.Controls.Add(dgv)
    End Sub

    Private Sub LoadSportsFilter()
        cmbFilterSport.Items.Clear()
        cmbFilterSport.Items.Add("All Sports")
        Dim sql As String = "SELECT SportID, SportName FROM Sports WHERE 1=1 "
        If SessionManager.IsCoach Then
            sql &= " AND SportID IN (SELECT SportID FROM SportCoaches WHERE UserID=" & SessionManager.CurrentUserID & ") "
        End If
        sql &= " ORDER BY SportName"
        Dim dt As DataTable = DatabaseHelper.GetDataTable(sql)
        For Each row As DataRow In dt.Rows
            cmbFilterSport.Items.Add(New SportItem(CInt(row("SportID")), row("SportName").ToString()))
        Next
        cmbFilterSport.SelectedIndex = 0
    End Sub

    Private Sub LoadApplicants()
        Dim sql As String =
            "SELECT r.RegistrationID, s.StudentNumber, (s.FirstName || ' ' || s.LastName) AS FullName, s.CourseYear, " &
            "sp.SportName AS Sport, r.RegistrationDate, r.SelectionStatus, r.SportID " &
            "FROM Registrations r " &
            "INNER JOIN Students s ON s.StudentID = r.StudentID " &
            "INNER JOIN Sports sp ON sp.SportID = r.SportID WHERE 1=1 "
        Dim params As New List(Of SQLiteParameter)

        If txtSearchName.Text.Trim() <> "" Then
            sql &= " AND (s.FirstName LIKE @name OR s.LastName LIKE @name) "
            params.Add(New SQLiteParameter("@name", "%" & txtSearchName.Text.Trim() & "%"))
        End If

        If txtSearchStudentNumber.Text.Trim() <> "" Then
            sql &= " AND s.StudentNumber LIKE @sn "
            params.Add(New SQLiteParameter("@sn", "%" & txtSearchStudentNumber.Text.Trim() & "%"))
        End If

        If cmbFilterSport.SelectedItem IsNot Nothing AndAlso TypeOf cmbFilterSport.SelectedItem Is SportItem Then
            sql &= " AND r.SportID=@sid "
            params.Add(New SQLiteParameter("@sid", CType(cmbFilterSport.SelectedItem, SportItem).SportID))
        End If

        If cmbFilterStatus.Text <> "All" AndAlso cmbFilterStatus.Text <> "" Then
            sql &= " AND r.SelectionStatus=@status "
            params.Add(New SQLiteParameter("@status", cmbFilterStatus.Text))
        End If

        If SessionManager.IsCoach Then
            sql &= " AND r.SportID IN (SELECT SportID FROM SportCoaches WHERE UserID=@coachId) "
            params.Add(New SQLiteParameter("@coachId", SessionManager.CurrentUserID))
        End If

        sql &= " ORDER BY r.RegistrationDate DESC"

        Dim dt As DataTable = DatabaseHelper.GetDataTable(sql, params.ToArray())
        Dim display As New DataTable()
        display.Columns.Add("RegistrationID", GetType(Integer))
        display.Columns.Add("Student ID")
        display.Columns.Add("Name")
        display.Columns.Add("Course/Grade")
        display.Columns.Add("Sport")
        display.Columns.Add("Registration Date")
        display.Columns.Add("Selection Status")

        For Each row As DataRow In dt.Rows
            display.Rows.Add(CInt(row("RegistrationID")), row("StudentNumber").ToString(), row("FullName").ToString(),
                row("CourseYear").ToString(), row("Sport").ToString(), row("RegistrationDate").ToString(),
                AppLogic.DisplaySelectionStatus(row("SelectionStatus").ToString()))
        Next

        dgv.DataSource = display
        If dgv.Columns.Contains("RegistrationID") Then dgv.Columns("RegistrationID").Visible = False
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs)
        LoadApplicants()
    End Sub

    Private Sub BtnClearFilter_Click(sender As Object, e As EventArgs)
        txtSearchName.Text = ""
        txtSearchStudentNumber.Text = ""
        cmbFilterSport.SelectedIndex = 0
        cmbFilterStatus.SelectedIndex = 0
        LoadApplicants()
    End Sub

    Private Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        BtnViewDetails_Click(sender, e)
    End Sub

    Private Sub BtnViewDetails_Click(sender As Object, e As EventArgs)
        If dgv.SelectedRows.Count = 0 Then
            UIHelper.ShowError("Select an applicant row first.")
            Return
        End If

        Dim regId As Integer = CInt(dgv.SelectedRows(0).Cells("RegistrationID").Value)

        Dim details As DataTable = DatabaseHelper.GetDataTable(
            "SELECT s.StudentNumber, s.FirstName, s.LastName, s.CourseYear, s.Gender, s.ContactNumber, s.Email, " &
            "sp.SportName, r.RegistrationDate, r.SelectionStatus, r.SelectionRemarks " &
            "FROM Registrations r " &
            "INNER JOIN Students s ON s.StudentID = r.StudentID " &
            "INNER JOIN Sports sp ON sp.SportID = r.SportID WHERE r.RegistrationID=@id",
            New SQLiteParameter("@id", regId))

        If details.Rows.Count = 0 Then Return
        Dim d As DataRow = details.Rows(0)

        Dim evalInfo As DataTable = DatabaseHelper.GetDataTable(
            "SELECT SkillScore, SpeedScore, AgilityScore, EnduranceScore, TeamworkScore, DisciplineScore, OverallPerformanceScore, FinalScore, Remarks " &
            "FROM Evaluations WHERE RegistrationID=@id", New SQLiteParameter("@id", regId))

        Dim msg As New StringBuilder()
        msg.AppendLine("Student ID: " & d("StudentNumber").ToString())
        msg.AppendLine("Name: " & d("FirstName").ToString() & " " & d("LastName").ToString())
        msg.AppendLine("Course/Grade Level: " & d("CourseYear").ToString())
        msg.AppendLine("Gender: " & d("Gender").ToString())
        msg.AppendLine("Contact: " & d("ContactNumber").ToString())
        msg.AppendLine("Email: " & d("Email").ToString())
        msg.AppendLine("Sport: " & d("SportName").ToString())
        msg.AppendLine("Registration Date: " & d("RegistrationDate").ToString())
        msg.AppendLine("Selection Status: " & AppLogic.DisplaySelectionStatus(d("SelectionStatus").ToString()))
        If Not IsDBNull(d("SelectionRemarks")) AndAlso d("SelectionRemarks").ToString() <> "" Then
            msg.AppendLine("Selection Remarks: " & d("SelectionRemarks").ToString())
        End If

        If evalInfo.Rows.Count > 0 Then
            Dim ev As DataRow = evalInfo.Rows(0)
            msg.AppendLine("")
            msg.AppendLine("--- Evaluation Scores ---")
            msg.AppendLine("Skill: " & ev("SkillScore").ToString())
            msg.AppendLine("Speed: " & ev("SpeedScore").ToString())
            msg.AppendLine("Agility: " & ev("AgilityScore").ToString())
            msg.AppendLine("Endurance: " & ev("EnduranceScore").ToString())
            msg.AppendLine("Teamwork: " & ev("TeamworkScore").ToString())
            msg.AppendLine("Discipline: " & ev("DisciplineScore").ToString())
            msg.AppendLine("Overall Performance: " & ev("OverallPerformanceScore").ToString())
            msg.AppendLine("Final Score: " & ev("FinalScore").ToString())
        Else
            msg.AppendLine("")
            msg.AppendLine("Not yet evaluated.")
        End If

        MessageBox.Show(msg.ToString(), "Applicant Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
