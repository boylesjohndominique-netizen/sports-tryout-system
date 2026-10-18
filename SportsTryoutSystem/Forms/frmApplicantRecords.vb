Imports System.Text

Public Class frmApplicantRecords

    Public Sub New()
        InitializeComponent()
        Dim header As Panel = UIHelper.MakePanelHeader("Applicant Records", Me.Width)
        Me.Controls.Add(header)
        header.SendToBack()
        AddHandler Me.Shown, AddressOf OnFormShown
    End Sub

    Private Sub OnFormShown(sender As Object, e As EventArgs)
        Try
            LoadSportsFilter()
            LoadApplicants()
        Catch ex As Exception
            UIHelper.ShowError("Failed to initialize applicants list: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadSportsFilter()
        cmbFilterSport.Items.Clear()
        cmbFilterSport.Items.Add("All Sports")
        Dim dt As DataTable = DatabaseHelper.GetDataTable("SELECT SportID, SportName FROM Sports WHERE IsActive=1 ORDER BY SportName")
        For Each row As DataRow In dt.Rows
            cmbFilterSport.Items.Add(New SportItem(CInt(row("SportID")), row("SportName").ToString()))
        Next
        cmbFilterSport.SelectedIndex = 0
    End Sub

    Private Sub LoadApplicants()
        Try
            Dim sql As String = "SELECT r.RegistrationID, s.StudentNumber, " &
                                 "CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name], " &
                                 "s.CourseYear AS [Course/Grade], s.Gender, s.ContactNumber AS [Contact], " &
                                 "sp.SportName AS [Sport], r.RegistrationDate AS [Reg Date], " &
                                 "r.SelectionStatus AS [Status] " &
                                 "FROM Registrations r " &
                                 "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                                 "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                                 "WHERE 1=1 "

            Dim params As New List(Of SQLiteParameter)

            If txtSearchName.Text.Trim() <> "" Then
                sql &= " AND (s.FirstName LIKE @name OR s.LastName LIKE @name) "
                params.Add(New SQLiteParameter("@name", "%" & txtSearchName.Text.Trim() & "%"))
            End If

            If txtSearchStudentNumber.Text.Trim() <> "" Then
                sql &= " AND s.StudentNumber LIKE @snum "
                params.Add(New SQLiteParameter("@snum", "%" & txtSearchStudentNumber.Text.Trim() & "%"))
            End If

            If cmbFilterSport.SelectedItem IsNot Nothing AndAlso TypeOf cmbFilterSport.SelectedItem Is SportItem Then
                sql &= " AND r.SportID = @sport "
                params.Add(New SQLiteParameter("@sport", CType(cmbFilterSport.SelectedItem, SportItem).SportID))
            End If

            If cmbFilterStatus.SelectedItem IsNot Nothing AndAlso cmbFilterStatus.Text <> "All" Then
                sql &= " AND r.SelectionStatus = @status "
                params.Add(New SQLiteParameter("@status", cmbFilterStatus.Text))
            End If

            sql &= " ORDER BY r.RegistrationDate DESC"

            Dim dt As DataTable = DatabaseHelper.GetDataTable(sql, params.ToArray())
            dgv.DataSource = dt
            If dgv.Columns.Contains("RegistrationID") Then dgv.Columns("RegistrationID").Visible = False
        Catch ex As Exception
            UIHelper.ShowError("Error loading applicants: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadApplicants()
    End Sub

    Private Sub BtnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        txtSearchName.Text = ""
        txtSearchStudentNumber.Text = ""
        cmbFilterSport.SelectedIndex = 0
        cmbFilterStatus.SelectedIndex = 0
        LoadApplicants()
    End Sub

    Private Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If e.RowIndex >= 0 Then ShowDetails()
    End Sub

    Private Sub BtnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        ShowDetails()
    End Sub

    Private Sub ShowDetails()
        If dgv.SelectedRows.Count = 0 Then
            UIHelper.ShowError("Select an applicant from the list first.")
            Return
        End If

        Dim row As DataGridViewRow = dgv.SelectedRows(0)
        Dim regId As Integer = CInt(row.Cells("RegistrationID").Value)
        Dim studentNo As String = row.Cells("StudentNumber").Value.ToString()
        Dim fullName As String = row.Cells("Full Name").Value.ToString()
        Dim sport As String = row.Cells("Sport").Value.ToString()
        Dim status As String = row.Cells("Status").Value.ToString()

        ' Query evaluation info if available
        Dim evalDt As DataTable = DatabaseHelper.GetDataTable(
            "SELECT e.EvaluationID, e.SkillScore, e.SpeedScore, e.AgilityScore, e.EnduranceScore, " &
            "e.TeamworkScore, e.DisciplineScore, e.OverallPerformanceScore, e.FinalScore, " &
            "e.Remarks, u.FullName AS Evaluator, e.EvaluationDate " &
            "FROM Evaluations e " &
            "LEFT JOIN Users u ON u.UserID = e.EvaluatorUserID " &
            "WHERE e.RegistrationID = @rid", New SQLiteParameter("@rid", regId))

        Dim sb As New StringBuilder()
        sb.AppendLine("=== APPLICANT DETAILS ===")
        sb.AppendLine("Student ID : " & studentNo)
        sb.AppendLine("Name       : " & fullName)
        sb.AppendLine("Sport      : " & sport)
        sb.AppendLine("Status     : " & AppLogic.DisplaySelectionStatus(status))
        sb.AppendLine()

        If evalDt.Rows.Count > 0 Then
            Dim erow As DataRow = evalDt.Rows(0)
            sb.AppendLine("=== EVALUATION SCORES ===")
            sb.AppendLine("Skill               : " & erow("SkillScore").ToString() & " / 100")
            sb.AppendLine("Speed               : " & erow("SpeedScore").ToString() & " / 100")
            sb.AppendLine("Agility             : " & erow("AgilityScore").ToString() & " / 100")
            sb.AppendLine("Endurance           : " & erow("EnduranceScore").ToString() & " / 100")
            sb.AppendLine("Teamwork            : " & erow("TeamworkScore").ToString() & " / 100")
            sb.AppendLine("Discipline          : " & erow("DisciplineScore").ToString() & " / 100")
            sb.AppendLine("Overall Performance : " & erow("OverallPerformanceScore").ToString() & " / 100")
            sb.AppendLine("------------------------------------")
            sb.AppendLine("Final Weighted Score: " & erow("FinalScore").ToString() & " / 100")
            sb.AppendLine("Evaluator           : " & erow("Evaluator").ToString())
            sb.AppendLine("Date Evaluated      : " & erow("EvaluationDate").ToString())
            If Not IsDBNull(erow("Remarks")) AndAlso erow("Remarks").ToString() <> "" Then
                sb.AppendLine("Remarks             : " & erow("Remarks").ToString())
            End If
        Else
            sb.AppendLine("Evaluation: Not yet evaluated.")
        End If

        MessageBox.Show(sb.ToString(), "Applicant Profile: " & fullName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
