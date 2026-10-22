Imports System.Data
Imports System.Drawing
Imports System.IO

Public Class frmReports

    Private currentReportTable As DataTable
    Private isInitializing As Boolean = False

    ' Selected student profile state
    Private selectedStudentId As Integer = 0
    Private studentInfo As New Dictionary(Of String, String)
    Private studentSportsTable As DataTable

    ' Structured single-line row labels inside pnlStuInfoBox (prevents multi-line wrapping misalignment)
    Private ReadOnly metaKeyLabels(5) As Label
    Private ReadOnly metaValLabels(5) As Label
    Private ReadOnly metaKeys As String() = {"Student No:", "Course/Year:", "Gender:", "Contact No:", "Email:", "Registered:"}

    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True

        Dim header As Panel = UIHelper.MakePanelHeader("Reports & Analytics", Me.Width)
        Me.Controls.Add(header)
        header.SendToBack()

        InitializeStructuredProfileRows()

        AddHandler Me.Resize, AddressOf OnFormResized
        AddHandler Me.Shown, AddressOf OnFormShown
        AddHandler dgv.CellFormatting, AddressOf Dgv_CellFormatting
        AddHandler dgvStudent.CellFormatting, AddressOf DgvStudent_CellFormatting
    End Sub

    Private Sub InitializeStructuredProfileRows()
        ' Hide legacy multi-line labels and replace with 6 locked single-line row pairs
        lblStuMetaLabels.Visible = False
        lblStuMeta.Visible = False

        For i As Integer = 0 To 5
            Dim lblK As New Label()
            lblK.AutoSize = False
            lblK.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
            lblK.ForeColor = Color.FromArgb(100, 116, 139)
            lblK.Text = metaKeys(i)
            lblK.TextAlign = ContentAlignment.MiddleLeft
            lblK.UseMnemonic = False
            pnlStuInfoBox.Controls.Add(lblK)
            metaKeyLabels(i) = lblK

            Dim lblV As New Label()
            lblV.AutoSize = False
            lblV.AutoEllipsis = True
            lblV.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
            lblV.ForeColor = Color.FromArgb(30, 41, 59)
            lblV.Text = "—"
            lblV.TextAlign = ContentAlignment.MiddleLeft
            lblV.UseMnemonic = False
            pnlStuInfoBox.Controls.Add(lblV)
            metaValLabels(i) = lblV
        Next
    End Sub

    Private Sub OnFormShown(sender As Object, e As EventArgs)
        LayoutPanels()
        Try
            isInitializing = True
            LoadSportsFilter()
            If cmbReportType.Items.Count > 0 Then cmbReportType.SelectedIndex = 0
            LoadStudents()
        Catch ex As Exception
            UIHelper.ShowError("Failed to initialize reports: " & ex.Message)
        Finally
            isInitializing = False
        End Try

        GenerateReport()
    End Sub

    Private Sub OnFormResized(sender As Object, e As EventArgs)
        LayoutPanels()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════
    '  DYNAMIC RESPONSIVE LAYOUT ENGINE
    ' ═══════════════════════════════════════════════════════════════════

    Private Sub LayoutPanels()
        If Me.ClientSize.Width < 700 OrElse Me.ClientSize.Height < 450 Then Return

        Me.SuspendLayout()

        Dim topY As Integer = 66
        Dim marginX As Integer = 20
        Dim bottomMargin As Integer = 14
        Dim gapX As Integer = 16
        Dim totalW As Integer = Me.ClientSize.Width - (marginX * 2)

        ' 1. Top Filter & Action Bar
        pnlSelector.SuspendLayout()
        pnlSelector.Location = New Point(marginX, topY)
        pnlSelector.Size = New Size(totalW, 74)
        selectorAccent.Size = New Size(totalW, 3)

        Dim typeW As Integer = Math.Min(260, Math.Max(190, CInt(totalW * 0.22)))
        lblTypeLabel.Location = New Point(18, 10)
        cmbReportType.Location = New Point(18, 30)
        cmbReportType.Size = New Size(typeW, 30)

        Dim sportLeft As Integer = cmbReportType.Right + 16
        Dim sportW As Integer = Math.Min(210, Math.Max(150, CInt(totalW * 0.17)))
        lblSportLabel.Location = New Point(sportLeft, 10)
        cmbFilterSport.Location = New Point(sportLeft, 30)
        cmbFilterSport.Size = New Size(sportW, 30)

        Dim btnW As Integer = 142
        Dim btnH As Integer = 38
        Dim btnGenLeft As Integer = cmbFilterSport.Right + 16
        btnGenerate.Location = New Point(btnGenLeft, 24)
        btnGenerate.Size = New Size(btnW, btnH)

        Dim btnExpLeft As Integer = btnGenerate.Right + 12
        btnExport.Location = New Point(btnExpLeft, 24)
        btnExport.Size = New Size(btnW, btnH)

        Dim sumLeft As Integer = btnExport.Right + 16
        Dim sumW As Integer = Math.Max(160, totalW - sumLeft - 18)
        lblSummary.Location = New Point(sumLeft, 23)
        lblSummary.Size = New Size(sumW, 40)
        pnlSelector.ResumeLayout(True)

        ' 2. Main Split Content Area (Left: Report Card, Right: Student Profile Card)
        Dim cardsY As Integer = topY + pnlSelector.Height + 12
        Dim cardsH As Integer = Math.Max(340, Me.ClientSize.Height - cardsY - bottomMargin)

        ' Right Student Profile Card: ~34% of total width, bounded between 380 and 500
        Dim rightW As Integer = CInt(Math.Max(380, Math.Min(500, (totalW - gapX) * 0.34)))
        Dim leftW As Integer = totalW - rightW - gapX

        ' Left Report Data Card
        pnlReportCard.SuspendLayout()
        pnlReportCard.Location = New Point(marginX, cardsY)
        pnlReportCard.Size = New Size(leftW, cardsH)
        reportAccent.Size = New Size(leftW, 3)

        lblReportCardTitle.Location = New Point(18, 15)
        lblReportRowCount.Location = New Point(lblReportCardTitle.Right + 12, 16)

        Dim searchBoxW As Integer = Math.Min(220, Math.Max(130, leftW - lblReportRowCount.Right - 95))
        txtSearchReport.Size = New Size(searchBoxW, 28)
        txtSearchReport.Location = New Point(leftW - searchBoxW - 18, 14)
        lblReportSearch.Location = New Point(txtSearchReport.Left - lblReportSearch.Width - 6, 18)

        dgv.Location = New Point(18, 54)
        dgv.Size = New Size(leftW - 36, Math.Max(140, cardsH - 70))
        pnlReportCard.ResumeLayout(True)

        ' Right Student Profile Card
        LayoutStudentCard(marginX + leftW + gapX, cardsY, rightW, cardsH)

        Me.ResumeLayout(True)
    End Sub

    Private Sub LayoutStudentCard(cardX As Integer, cardY As Integer, cardW As Integer, cardH As Integer)
        pnlStudent.SuspendLayout()
        pnlStudent.Location = New Point(cardX, cardY)
        pnlStudent.Size = New Size(cardW, cardH)
        studentAccent.Size = New Size(cardW, 3)

        Dim padX As Integer = 18
        Dim usableW As Integer = cardW - (padX * 2)

        lblStudentTitle.Location = New Point(padX, 14)
        lblStudentSelect.Location = New Point(padX, 44)

        cmbStudent.Location = New Point(padX, 63)
        cmbStudent.Size = New Size(usableW, 30)

        pnlStudentDivider.Location = New Point(padX, 101)
        pnlStudentDivider.Size = New Size(usableW, 1)

        ' Structured Student Identity Box
        Dim infoBoxY As Integer = 110
        Dim infoBoxH As Integer = 176
        pnlStuInfoBox.Location = New Point(padX, infoBoxY)
        pnlStuInfoBox.Size = New Size(usableW, infoBoxH)

        Dim innerW As Integer = usableW - 24
        lblStuName.Location = New Point(12, 8)
        lblStuName.Size = New Size(innerW, 26)

        Dim valWidth As Integer = Math.Max(120, usableW - 114)
        For i As Integer = 0 To 5
            Dim rowY As Integer = 38 + (i * 22)
            If metaKeyLabels(i) IsNot Nothing Then
                metaKeyLabels(i).Location = New Point(12, rowY)
                metaKeyLabels(i).Size = New Size(90, 20)
            End If
            If metaValLabels(i) IsNot Nothing Then
                metaValLabels(i).Location = New Point(104, rowY)
                metaValLabels(i).Size = New Size(valWidth, 20)
            End If
        Next

        ' Registered Sports & Results Section
        Dim sportsHeaderY As Integer = infoBoxY + infoBoxH + 12
        lblStuSports.Location = New Point(padX, sportsHeaderY)

        Dim btnH As Integer = 42
        Dim btnY As Integer = cardH - btnH - 14
        btnStudentExport.Location = New Point(padX, btnY)
        btnStudentExport.Size = New Size(usableW, btnH)

        Dim dgvStuY As Integer = sportsHeaderY + 22
        Dim dgvStuH As Integer = Math.Max(80, btnY - 12 - dgvStuY)
        dgvStudent.Location = New Point(padX, dgvStuY)
        dgvStudent.Size = New Size(usableW, dgvStuH)

        pnlStudent.ResumeLayout(True)
    End Sub

    ' ═══════════════════════════════════════════════════════════════════
    '  REPORT TYPE / FILTERS & GENERATION
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

    Private Sub CmbReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReportType.SelectedIndexChanged
        If isInitializing Then Return
        GenerateReport()
    End Sub

    Private Sub CmbFilterSport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterSport.SelectedIndexChanged
        If isInitializing Then Return
        GenerateReport()
    End Sub

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        GenerateReport()
    End Sub

    Private Sub GenerateReport()
        If cmbReportType.SelectedItem Is Nothing Then Return

        Dim reportType As String = cmbReportType.SelectedItem.ToString()
        Dim sportName As String = If(cmbFilterSport.SelectedItem IsNot Nothing, cmbFilterSport.SelectedItem.ToString(), "All Sports")
        Dim sportFilter As String = If(cmbFilterSport.SelectedItem IsNot Nothing AndAlso TypeOf cmbFilterSport.SelectedItem Is SportItem,
                                       " AND sp.SportID = " & CType(cmbFilterSport.SelectedItem, SportItem).SportID, "")

        Dim sql As String = ""

        Select Case reportType
            Case "Registered Applicants"
                sql = "SELECT s.StudentNumber AS [ID], CONCAT(s.FirstName, ' ', s.LastName) AS [Name], " &
                      "s.CourseYear AS [Course/Year], s.Gender, sp.SportName AS [Sport], " &
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
                      "s.CourseYear AS [Course/Year], sp.SportName AS [Sport], e.FinalScore AS [Score], r.SelectionStatus AS [Status] " &
                      "FROM Evaluations e " &
                      "INNER JOIN Registrations r ON r.RegistrationID = e.RegistrationID " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                      "WHERE e.FinalScore >= " & AppLogic.PassingScore.ToString() & sportFilter &
                      " ORDER BY sp.SportName, e.FinalScore DESC"

            Case "Selected Athletes"
                sql = "SELECT s.StudentNumber AS [ID], s.FirstName || ' ' || s.LastName AS [Name], " &
                      "s.CourseYear AS [Course/Year], s.ContactNumber AS [Contact], s.Email, sp.SportName AS [Sport], " &
                      "e.FinalScore AS [Score] " &
                      "FROM Registrations r " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                      "LEFT JOIN Evaluations e ON e.RegistrationID = r.RegistrationID " &
                      "WHERE r.SelectionStatus = 'Selected' " & sportFilter &
                      " ORDER BY sp.SportName, s.LastName"

            Case "Non-Selected Athletes"
                sql = "SELECT s.StudentNumber AS [ID], s.FirstName || ' ' || s.LastName AS [Name], " &
                      "s.CourseYear AS [Course/Year], sp.SportName AS [Sport], " &
                      "r.SelectionStatus AS [Status], e.FinalScore AS [Score] " &
                      "FROM Registrations r " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                      "LEFT JOIN Evaluations e ON e.RegistrationID = r.RegistrationID " &
                      "WHERE r.SelectionStatus IN ('NotSelected', 'ForFurtherEvaluation') " & sportFilter &
                      " ORDER BY sp.SportName, s.LastName"
        End Select

        Try
            lblReportCardTitle.Text = reportType
            txtSearchReport.Text = ""

            Dim rawTable As DataTable = DatabaseHelper.GetDataTable(sql)
            currentReportTable = NormalizeReportTable(rawTable)
            UpdateReportCounts(sportName)
            LayoutPanels()

            dgv.DataSource = currentReportTable
            ConfigureReportGridColumns()
        Catch ex As Exception
            UIHelper.ShowError("Failed to generate report: " & ex.Message)
        End Try
    End Sub

    Private Function NormalizeReportTable(raw As DataTable) As DataTable
        If raw Is Nothing Then Return Nothing

        ' Create string-friendly clone where Status and Date columns are cleanly formatted
        Dim formatted As New DataTable()
        For Each col As DataColumn In raw.Columns
            If col.ColumnName = "Status" OrElse col.ColumnName = "Registered" OrElse col.ColumnName = "Date" OrElse col.ColumnName = "Score" OrElse col.ColumnName = "Final Score" Then
                formatted.Columns.Add(col.ColumnName, GetType(String))
            Else
                formatted.Columns.Add(col.ColumnName, col.DataType)
            End If
        Next

        For Each row As DataRow In raw.Rows
            Dim newRow As DataRow = formatted.NewRow()
            For Each col As DataColumn In raw.Columns
                Dim cName As String = col.ColumnName
                Dim val As Object = row(cName)
                If IsDBNull(val) OrElse val Is Nothing Then
                    If formatted.Columns(cName).DataType Is GetType(String) Then
                        newRow(cName) = "—"
                    Else
                        newRow(cName) = DBNull.Value
                    End If
                ElseIf cName = "Status" Then
                    newRow(cName) = AppLogic.DisplaySelectionStatus(val.ToString())
                ElseIf cName = "Registered" OrElse cName = "Date" Then
                    newRow(cName) = FormatDate(val)
                ElseIf cName = "Score" OrElse cName = "Final Score" Then
                    newRow(cName) = FormatScore(val)
                Else
                    newRow(cName) = val
                End If
            Next
            formatted.Rows.Add(newRow)
        Next

        Return formatted
    End Function

    Private Sub ConfigureReportGridColumns()
        If dgv.Columns.Count = 0 Then Return

        For Each col As DataGridViewColumn In dgv.Columns
            Dim cName As String = col.Name
            Select Case cName
                Case "Rank"
                    col.FillWeight = 6
                    col.MinimumWidth = 48
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "ID"
                    col.FillWeight = 11
                    col.MinimumWidth = 75
                Case "Name"
                    col.FillWeight = 30
                    col.MinimumWidth = 140
                Case "Course/Year"
                    col.FillWeight = 16
                    col.MinimumWidth = 95
                Case "Sport"
                    col.FillWeight = 13
                    col.MinimumWidth = 80
                Case "Gender"
                    col.FillWeight = 8
                    col.MinimumWidth = 55
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Registered", "Date"
                    col.FillWeight = 15
                    col.MinimumWidth = 95
                Case "Score", "Final Score", "Skill", "Speed", "Agility", "Endurance", "Teamwork", "Discipline", "Overall",
                     "Total Applicants", "Selected", "Pending", "Not Selected", "Further Eval"
                    col.FillWeight = 9
                    col.MinimumWidth = 60
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Status"
                    col.FillWeight = 13
                    col.MinimumWidth = 85
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    col.FillWeight = 14
                    col.MinimumWidth = 78
            End Select
        Next
    End Sub

    Private Sub UpdateReportCounts(Optional sportName As String = "")
        If String.IsNullOrEmpty(sportName) AndAlso cmbFilterSport.SelectedItem IsNot Nothing Then
            sportName = cmbFilterSport.SelectedItem.ToString()
        End If
        Dim count As Integer = If(currentReportTable IsNot Nothing, currentReportTable.DefaultView.Count, 0)
        lblReportRowCount.Text = String.Format("{0} {1}", count, If(count = 1, "Record", "Records"))
        lblSummary.Text = String.Format("Filter: {0}   |   Showing: {1} {2}",
                                        sportName, count, If(count = 1, "row", "rows"))
    End Sub

    Private Sub TxtSearchReport_TextChanged(sender As Object, e As EventArgs) Handles txtSearchReport.TextChanged
        If currentReportTable Is Nothing Then Return

        Dim term As String = txtSearchReport.Text.Trim().Replace("'", "''")
        If String.IsNullOrEmpty(term) Then
            currentReportTable.DefaultView.RowFilter = ""
        Else
            Dim filters As New List(Of String)()
            For Each col As DataColumn In currentReportTable.Columns
                filters.Add(String.Format("CONVERT([{0}], 'System.String') LIKE '%{1}%'", col.ColumnName, term))
            Next
            currentReportTable.DefaultView.RowFilter = String.Join(" OR ", filters)
        End If

        UpdateReportCounts()
    End Sub

    Private Sub Dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        If e.RowIndex < 0 Then Return
        If Not dgv.Columns.Contains("ID") Then Return

        Dim val As Object = dgv.Rows(e.RowIndex).Cells("ID").Value
        If val Is Nothing OrElse IsDBNull(val) Then Return

        Dim studentNum As String = val.ToString().Trim()
        For i As Integer = 0 To cmbStudent.Items.Count - 1
            Dim item As StudentItem = TryCast(cmbStudent.Items(i), StudentItem)
            If item IsNot Nothing AndAlso String.Equals(item.StudentNumber, studentNum, StringComparison.OrdinalIgnoreCase) Then
                cmbStudent.SelectedIndex = i
                Exit For
            End If
        Next
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
        If cmbStudent.Items.Count > 0 Then
            cmbStudent.SelectedIndex = 0
        Else
            ResetProfile()
        End If
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
            Dim vals As String() = {
                Pad(studentInfo("Student No")),
                Pad(studentInfo("Course / Year")),
                Pad(studentInfo("Gender")),
                Pad(studentInfo("Contact Number")),
                Pad(studentInfo("Email")),
                Pad(studentInfo("Date Registered"))
            }
            For i As Integer = 0 To 5
                If metaValLabels(i) IsNot Nothing Then metaValLabels(i).Text = vals(i)
            Next

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

        If dgvStudent.Columns.Contains("Sport") Then dgvStudent.Columns("Sport").FillWeight = 42
        If dgvStudent.Columns.Contains("Status") Then
            dgvStudent.Columns("Status").FillWeight = 36
            dgvStudent.Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvStudent.Columns("Status").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvStudent.Columns.Contains("Score") Then
            dgvStudent.Columns("Score").FillWeight = 22
            dgvStudent.Columns("Score").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvStudent.Columns("Score").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    Private Sub ResetProfile()
        selectedStudentId = 0
        studentInfo.Clear()
        studentSportsTable = Nothing
        lblStuName.Text = "Select a student to preview."
        For i As Integer = 0 To 5
            If metaValLabels(i) IsNot Nothing Then metaValLabels(i).Text = "—"
        Next
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
    '  GRID CELL FORMATTING
    ' ═══════════════════════════════════════════════════════════════════

    Private Sub Dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        Dim colName As String = dgv.Columns(e.ColumnIndex).Name

        If colName = "Status" Then
            ApplyStatusStyle(e, e.Value.ToString(), 9.5!)
        ElseIf colName = "Score" OrElse colName = "Final Score" Then
            Dim sc As Double
            If Double.TryParse(e.Value.ToString(), sc) Then
                If sc >= AppLogic.PassingScore Then
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                    e.CellStyle.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
                Else
                    e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6)
                End If
            End If
        End If
    End Sub

    Private Sub DgvStudent_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        Dim colName As String = dgvStudent.Columns(e.ColumnIndex).Name

        If colName = "Status" Then
            ApplyStatusStyle(e, e.Value.ToString(), 9.5!)
        ElseIf colName = "Score" Then
            Dim sc As Double
            If Double.TryParse(e.Value.ToString(), sc) Then
                If sc >= AppLogic.PassingScore Then
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                    e.CellStyle.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
                Else
                    e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6)
                End If
            End If
        End If
    End Sub

    Private Sub ApplyStatusStyle(e As DataGridViewCellFormattingEventArgs, statusText As String, fontSize As Single)
        Select Case statusText
            Case "Selected", "Completed"
                e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                e.CellStyle.Font = New Font("Segoe UI Semibold", fontSize, FontStyle.Bold)
            Case "Not Selected", "Cancelled"
                e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38)
                e.CellStyle.Font = New Font("Segoe UI Semibold", fontSize, FontStyle.Bold)
            Case "For Further Evaluation"
                e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6)
                e.CellStyle.Font = New Font("Segoe UI Semibold", fontSize, FontStyle.Bold)
            Case Else
                e.CellStyle.ForeColor = Color.FromArgb(100, 116, 139)
        End Select
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
        If Double.TryParse(value.ToString(), d) Then Return d.ToString("0.00")
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
