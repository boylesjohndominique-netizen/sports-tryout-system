Imports System.IO

Public Class frmReports

    Private currentReportTable As DataTable

    ' Selected student profile state
    Private selectedStudentId As Integer = 0
    Private studentInfo As New Dictionary(Of String, String)
    Private studentSportsTable As DataTable

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
            LoadStudents()
        Catch ex As Exception
            UIHelper.ShowError("Failed to initialize reports: " & ex.Message)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════════
    '  REPORT TYPE / FILTERS
    ' ═══════════════════════════════════════════════════════════════════

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
            lblSummary.Text = "Report: " & reportType & "     •     Total Rows: " & currentReportTable.Rows.Count.ToString()
        Catch ex As Exception
            UIHelper.ShowError("Failed to generate report: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If currentReportTable Is Nothing OrElse currentReportTable.Rows.Count = 0 Then
            UIHelper.ShowError("Generate a report with data before exporting.")
            Return
        End If

        Dim reportType As String = cmbReportType.Text

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
        sfd.FileName = reportType.Replace(" ", "_") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".xlsx"
        If sfd.ShowDialog() <> DialogResult.OK Then Return

        Try
            ExcelHelper.ExportDataTable(sfd.FileName, reportType, currentReportTable,
                                        reportType, "Generated " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"))
            UIHelper.ShowInfo("Report exported to:" & vbCrLf & sfd.FileName)
        Catch ex As Exception
            UIHelper.ShowError("Export failed: " & ex.Message)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════════
    '  STUDENT PROFILE (preview + export)
    ' ═══════════════════════════════════════════════════════════════════

    Private Sub LoadStudents()
        cmbStudent.Items.Clear()
        Dim dt As DataTable = DatabaseHelper.GetDataTable(
            "SELECT StudentID, StudentNumber, FirstName, LastName FROM Students ORDER BY LastName, FirstName")
        For Each row As DataRow In dt.Rows
            cmbStudent.Items.Add(New StudentItem(CInt(row("StudentID")),
                                                 SafeText(row("StudentNumber")),
                                                 (row("FirstName").ToString() & " " & row("LastName").ToString()).Trim()))
        Next
        If cmbStudent.Items.Count > 0 Then cmbStudent.SelectedIndex = 0
    End Sub

    Private Sub CmbStudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStudent.SelectedIndexChanged
        LoadStudentProfile()
    End Sub

    Private Sub LoadStudentProfile()
        ResetProfile()

        Dim item As StudentItem = TryCast(cmbStudent.SelectedItem, StudentItem)
        If item Is Nothing Then Return

        selectedStudentId = item.StudentID

        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT StudentNumber, FirstName, MiddleName, LastName, CourseYear, Gender, ContactNumber, Email, DateRegistered " &
                "FROM Students WHERE StudentID=@id", New SQLiteParameter("@id", item.StudentID))
            If dt.Rows.Count = 0 Then
                lblStuName.Text = "Student record not found."
                Return
            End If

            Dim r As DataRow = dt.Rows(0)
            Dim middle As String = If(IsDBNull(r("MiddleName")), "", r("MiddleName").ToString())
            Dim fullName As String = (r("FirstName").ToString() & " " &
                                      If(middle <> "", middle & " ", "") &
                                      r("LastName").ToString()).Trim()

            studentInfo("Full Name") = fullName
            studentInfo("Student No") = SafeText(r("StudentNumber"))
            studentInfo("Course / Year") = SafeText(r("CourseYear"))
            studentInfo("Gender") = SafeText(r("Gender"))
            studentInfo("Contact Number") = SafeText(r("ContactNumber"))
            studentInfo("Email") = SafeText(r("Email"))
            studentInfo("Date Registered") = FormatDate(r("DateRegistered"))

            lblStuName.Text = fullName
            lblStuMeta.Text = "Student No:    " & Pad(studentInfo("Student No")) & vbCrLf &
                              "Course/Year:   " & Pad(studentInfo("Course / Year")) & vbCrLf &
                              "Gender:        " & Pad(studentInfo("Gender")) & vbCrLf &
                              "Contact:       " & Pad(studentInfo("Contact Number")) & vbCrLf &
                              "Email:         " & Pad(studentInfo("Email")) & vbCrLf &
                              "Registered:    " & Pad(studentInfo("Date Registered"))

            studentSportsTable = DatabaseHelper.GetDataTable(
                "SELECT sp.SportName AS [Sport], r.SelectionStatus AS [StatusRaw], e.FinalScore AS [Score], " &
                "u.FullName AS [Evaluator], e.EvaluationDate AS [Date] " &
                "FROM Registrations r " &
                "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                "LEFT JOIN Evaluations e ON e.RegistrationID = r.RegistrationID " &
                "LEFT JOIN Users u ON u.UserID = e.EvaluatorUserID " &
                "WHERE r.StudentID=@id ORDER BY sp.SportName",
                New SQLiteParameter("@id", item.StudentID))

            BuildStudentPreviewGrid()
        Catch ex As Exception
            UIHelper.ShowError("Failed to load student profile: " & ex.Message)
        End Try
    End Sub

    Private Sub BuildStudentPreviewGrid()
        Dim preview As New DataTable()
        preview.Columns.Add("Sport", GetType(String))
        preview.Columns.Add("Status", GetType(String))
        preview.Columns.Add("Score", GetType(String))

        If studentSportsTable IsNot Nothing Then
            For Each rr As DataRow In studentSportsTable.Rows
                Dim score As String = If(IsDBNull(rr("Score")), "—", FormatScore(rr("Score")))
                preview.Rows.Add(SafeText(rr("Sport")),
                                 AppLogic.DisplaySelectionStatus(SafeText(rr("StatusRaw"))),
                                 score)
            Next
        End If
        dgvStudent.DataSource = preview
    End Sub

    Private Sub ResetProfile()
        selectedStudentId = 0
        studentInfo.Clear()
        studentSportsTable = Nothing
        lblStuName.Text = "Select a student to preview."
        lblStuMeta.Text = ""
        dgvStudent.DataSource = Nothing
    End Sub

    Private Sub BtnStudentExport_Click(sender As Object, e As EventArgs) Handles btnStudentExport.Click
        If selectedStudentId = 0 Then
            UIHelper.ShowError("Select a student first, then export the profile.")
            Return
        End If

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
        sfd.FileName = "Student_" & SafeFileName(lblStuName.Text) & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".xlsx"
        If sfd.ShowDialog() <> DialogResult.OK Then Return

        Try
            Dim rows As New List(Of Object())
            Dim bold As New HashSet(Of Integer)()

            rows.Add(New Object() {"STUDENT OVERALL INFORMATION"})
            bold.Add(rows.Count)
            rows.Add(New Object() {"Generated", DateTime.Now.ToString("yyyy-MM-dd HH:mm")})
            rows.Add(New Object() {""})

            rows.Add(New Object() {"PERSONAL INFORMATION"})
            bold.Add(rows.Count)
            For Each key In New String() {"Full Name", "Student No", "Course / Year", "Gender", "Contact Number", "Email", "Date Registered"}
                rows.Add(New Object() {key, GetInfo(key)})
            Next
            rows.Add(New Object() {""})

            rows.Add(New Object() {"SPORTS & RESULTS"})
            bold.Add(rows.Count)
            rows.Add(New Object() {"Sport", "Status", "Final Score", "Evaluator", "Evaluation Date"})
            bold.Add(rows.Count)

            If studentSportsTable IsNot Nothing Then
                For Each rr As DataRow In studentSportsTable.Rows
                    rows.Add(New Object() {
                        SafeText(rr("Sport")),
                        AppLogic.DisplaySelectionStatus(SafeText(rr("StatusRaw"))),
                        If(IsDBNull(rr("Score")), "", rr("Score")),
                        SafeText(rr("Evaluator")),
                        FormatDate(If(IsDBNull(rr("Date")), Nothing, rr("Date")))
                    })
                Next
            End If

            Dim widths As Integer() = {22, 30, 14, 24, 20}
            ExcelHelper.WriteWorkbook(sfd.FileName, "Student Profile", rows, bold, widths)
            UIHelper.ShowInfo("Student profile exported to:" & vbCrLf & sfd.FileName)
        Catch ex As Exception
            UIHelper.ShowError("Export failed: " & ex.Message)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════════
    '  HELPERS
    ' ═══════════════════════════════════════════════════════════════════

    Private Function GetInfo(key As String) As String
        Dim value As String = Nothing
        If studentInfo.TryGetValue(key, value) Then Return value
        Return ""
    End Function

    Private Function SafeText(value As Object) As String
        If value Is Nothing OrElse IsDBNull(value) Then Return ""
        Return value.ToString().Trim()
    End Function

    Private Function Pad(value As String) As String
        Return If(String.IsNullOrWhiteSpace(value), "—", value)
    End Function

    Private Function FormatScore(value As Object) As String
        If value Is Nothing OrElse IsDBNull(value) Then Return "—"
        Dim d As Double
        If Double.TryParse(value.ToString(), d) Then Return d.ToString("0.##")
        Return value.ToString()
    End Function

    Private Function FormatDate(value As Object) As String
        If value Is Nothing OrElse IsDBNull(value) Then Return "—"
        Dim dt As DateTime
        If DateTime.TryParse(value.ToString(), dt) Then Return dt.ToString("MMM dd, yyyy")
        Return value.ToString()
    End Function

    Private Function SafeFileName(name As String) As String
        Dim clean As String = If(String.IsNullOrWhiteSpace(name), "Student", name)
        For Each ch In Path.GetInvalidFileNameChars()
            clean = clean.Replace(ch, "_"c)
        Next
        Return clean.Replace(" "c, "_"c)
    End Function

End Class
