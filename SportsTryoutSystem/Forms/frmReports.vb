Imports System.IO
Imports System.Text

Public Class frmReports

    Private currentReportTable As DataTable

    Public Sub New()
        InitializeComponent()
        Dim header As Panel = UIHelper.MakePanelHeader("Reports", Me.Width)
        Me.Controls.Add(header)
        header.SendToBack()
        AddHandler Me.Shown, AddressOf OnFormShown
    End Sub

    Private Sub OnFormShown(sender As Object, e As EventArgs)
        Try
            LoadSportsFilter()
            If cmbReportType.Items.Count > 0 Then cmbReportType.SelectedIndex = 0
        Catch ex As Exception
            UIHelper.ShowError("Failed to initialize reports: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadSportsFilter()
        cmbFilterSport.Items.Clear()
        cmbFilterSport.Items.Add("All Sports")
        Dim dt As DataTable = DatabaseHelper.GetDataTable("SELECT SportID, SportName FROM Sports ORDER BY SportName")
        For Each row As DataRow In dt.Rows
            cmbFilterSport.Items.Add(New SportItem(CInt(row("SportID")), row("SportName").ToString()))
        Next
        cmbFilterSport.SelectedIndex = 0
    End Sub

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If cmbReportType.SelectedItem Is Nothing Then
            UIHelper.ShowError("Select a report type.")
            Return
        End If

        Dim reportType As String = cmbReportType.SelectedItem.ToString()
        Dim sportFilter As String = If(cmbFilterSport.SelectedItem IsNot Nothing AndAlso TypeOf cmbFilterSport.SelectedItem Is SportItem,
                                       " AND sp.SportID = " & CType(cmbFilterSport.SelectedItem, SportItem).SportID, "")

        Dim sql As String = ""

        Select Case reportType
            Case "Registered Applicants"
                sql = "SELECT s.StudentNumber AS [ID], CONCAT(s.FirstName, ' ', s.LastName) AS [Name], " &
                      "s.CourseYear AS [Course/Grade], s.Gender, sp.SportName AS [Sport], " &
                      "r.RegistrationDate AS [Registered], r.SelectionStatus AS [Status] " &
                      "FROM Registrations r " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID WHERE 1=1 " & sportFilter &
                      " ORDER BY sp.SportName, s.LastName"

            Case "Applicants per Sport"
                sql = "SELECT sp.SportName AS [Sport], COUNT(r.RegistrationID) AS [Total Applicants], " &
                      "SUM(CASE WHEN r.SelectionStatus='Selected' THEN 1 ELSE 0 END) AS [Selected], " &
                      "SUM(CASE WHEN r.SelectionStatus='Pending' THEN 1 ELSE 0 END) AS [Pending], " &
                      "SUM(CASE WHEN r.SelectionStatus='NotSelected' THEN 1 ELSE 0 END) AS [Not Selected], " &
                      "SUM(CASE WHEN r.SelectionStatus='ForFurtherEvaluation' THEN 1 ELSE 0 END) AS [Further Eval] " &
                      "FROM Sports sp " &
                      "LEFT JOIN Registrations r ON r.SportID = sp.SportID " &
                      "WHERE 1=1 " & If(sportFilter <> "", " AND sp.SportID = " & CType(cmbFilterSport.SelectedItem, SportItem).SportID, "") &
                      " GROUP BY sp.SportID, sp.SportName ORDER BY sp.SportName"

            Case "Tryout Schedules"
                sql = "SELECT sp.SportName AS [Sport], sc.TryoutDate AS [Date], sc.TryoutTime AS [Time], " &
                      "sc.Venue, sc.Status, sc.Notes " &
                      "FROM Schedules sc " &
                      "INNER JOIN Sports sp ON sp.SportID = sc.SportID WHERE 1=1 " & sportFilter &
                      " ORDER BY sc.TryoutDate, sc.TryoutTime"

            Case "Athlete Evaluation Results"
                sql = "SELECT s.StudentNumber AS [ID], CONCAT(s.FirstName, ' ', s.LastName) AS [Name], " &
                      "sp.SportName AS [Sport], e.SkillScore AS [Skill], " &
                      "e.SpeedScore AS [Speed], e.AgilityScore AS [Agility], " &
                      "e.EnduranceScore AS [Endurance], e.TeamworkScore AS [Teamwork], " &
                      "e.DisciplineScore AS [Discipline], e.OverallPerformanceScore AS [Overall], " &
                      "e.FinalScore AS [Final Score], r.SelectionStatus AS [Status], " &
                      "u.FullName AS [Evaluator], e.EvaluationDate AS [Date] " &
                      "FROM Evaluations e " &
                      "INNER JOIN Registrations r ON r.RegistrationID = e.RegistrationID " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                      "LEFT JOIN Users u ON u.UserID = e.EvaluatorUserID WHERE 1=1 " & sportFilter &
                      " ORDER BY sp.SportName, e.FinalScore DESC"

            Case "Applicant Rankings"
                sql = "SELECT RANK() OVER (PARTITION BY sp.SportID ORDER BY e.FinalScore DESC) AS [Rank], " &
                      "s.StudentNumber AS [ID], CONCAT(s.FirstName, ' ', s.LastName) AS [Name], " &
                      "sp.SportName AS [Sport], e.FinalScore AS [Score], r.SelectionStatus AS [Status] " &
                      "FROM Evaluations e " &
                      "INNER JOIN Registrations r ON r.RegistrationID = e.RegistrationID " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID WHERE 1=1 " & sportFilter &
                      " ORDER BY sp.SportName, e.FinalScore DESC"

            Case "Qualified Students"
                sql = "SELECT s.StudentNumber AS [ID], CONCAT(s.FirstName, ' ', s.LastName) AS [Name], " &
                      "s.CourseYear, sp.SportName AS [Sport], e.FinalScore AS [Score], r.SelectionStatus AS [Status] " &
                      "FROM Evaluations e " &
                      "INNER JOIN Registrations r ON r.RegistrationID = e.RegistrationID " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                      "WHERE e.FinalScore >= " & AppLogic.PassingScore.ToString() & sportFilter &
                      " ORDER BY sp.SportName, e.FinalScore DESC"

            Case "Selected Athletes"
                sql = "SELECT s.StudentNumber AS [ID], s.FirstName || ' ' || s.LastName AS [Name], " &
                      "s.CourseYear, s.ContactNumber, s.Email, sp.SportName AS [Sport], " &
                      "e.FinalScore AS [Score] " &
                      "FROM Registrations r " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                      "LEFT JOIN Evaluations e ON e.RegistrationID = r.RegistrationID " &
                      "WHERE r.SelectionStatus = 'Selected' " & sportFilter &
                      " ORDER BY sp.SportName, s.LastName"

            Case "Non-Selected Athletes"
                sql = "SELECT s.StudentNumber AS [ID], s.FirstName || ' ' || s.LastName AS [Name], " &
                      "s.CourseYear, sp.SportName AS [Sport], " &
                      "r.SelectionStatus AS [Status], e.FinalScore AS [Score] " &
                      "FROM Registrations r " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                      "LEFT JOIN Evaluations e ON e.RegistrationID = r.RegistrationID " &
                      "WHERE r.SelectionStatus IN ('NotSelected', 'ForFurtherEvaluation') " & sportFilter &
                      " ORDER BY sp.SportName, s.LastName"
        End Select

        Try
            currentReportTable = DatabaseHelper.GetDataTable(sql)
            dgv.DataSource = currentReportTable
            lblSummary.Text = "Report: " & reportType & "   |   Total Rows: " & currentReportTable.Rows.Count.ToString()
        Catch ex As Exception
            UIHelper.ShowError("Failed to generate report: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If currentReportTable Is Nothing OrElse currentReportTable.Rows.Count = 0 Then
            UIHelper.ShowError("Generate a report with data before exporting.")
            Return
        End If

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "CSV Files (*.csv)|*.csv"
        sfd.FileName = cmbReportType.Text.Replace(" ", "_") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"

        If sfd.ShowDialog() <> DialogResult.OK Then Return

        Try
            Dim sb As New StringBuilder()

            ' Column headers
            Dim colNames As New List(Of String)
            For Each col As DataColumn In currentReportTable.Columns
                colNames.Add("""" & col.ColumnName.Replace("""", """""") & """")
            Next
            sb.AppendLine(String.Join(",", colNames))

            ' Rows
            For Each row As DataRow In currentReportTable.Rows
                Dim fields As New List(Of String)
                For Each item In row.ItemArray
                    Dim val As String = If(IsDBNull(item), "", item.ToString())
                    fields.Add("""" & val.Replace("""", """""") & """")
                Next
                sb.AppendLine(String.Join(",", fields))
            Next

            File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8)
            UIHelper.ShowInfo("Report exported to: " & sfd.FileName)
        Catch ex As Exception
            UIHelper.ShowError("Export failed: " & ex.Message)
        End Try
    End Sub

End Class
