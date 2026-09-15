Public Class frmReports
    Inherits Form

    Private cmbReportType As ComboBox
    Private cmbFilterSport As ComboBox
    Private dgv As DataGridView
    Private lblSummary As Label
    Private currentReportTable As DataTable

    Public Sub New()
        Me.Text = "Reports"
        Me.Dock = DockStyle.Fill
        Me.BackColor = UIHelper.ColorBackground
        BuildUI()
        LoadSportsFilter()
    End Sub

    Private Sub BuildUI()
        Dim header As Panel = UIHelper.MakePanelHeader("Reports", Me.Width)
        Me.Controls.Add(header)

        ' ── Report selector card ──
        Dim pnlSelector As New Panel()
        pnlSelector.Location = New Point(30, 75)
        pnlSelector.Size = New Size(950, 76)
        pnlSelector.BackColor = Color.White
        pnlSelector.BorderStyle = BorderStyle.None

        Dim selectorAccent As New Panel()
        selectorAccent.Dock = DockStyle.Top
        selectorAccent.Height = 3
        selectorAccent.BackColor = UIHelper.ColorGold
        pnlSelector.Controls.Add(selectorAccent)

        ' Report type field
        Dim lblTypeLabel As Label = UIHelper.MakeLabel("REPORT TYPE", 20, 12, 120)
        lblTypeLabel.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblTypeLabel.ForeColor = UIHelper.ColorTextSecondary
        pnlSelector.Controls.Add(lblTypeLabel)

        cmbReportType = UIHelper.MakeComboBox(20, 32, 330)
        cmbReportType.Items.AddRange(New String() {
            "Registered Applicants",
            "Applicants per Sport",
            "Tryout Schedules",
            "Athlete Evaluation Results",
            "Applicant Rankings",
            "Qualified Students",
            "Selected Athletes",
            "Non-Selected Athletes"
        })
        pnlSelector.Controls.Add(cmbReportType)

        ' Sport filter field
        Dim lblSportLabel As Label = UIHelper.MakeLabel("SPORT FILTER", 370, 12, 120)
        lblSportLabel.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblSportLabel.ForeColor = UIHelper.ColorTextSecondary
        pnlSelector.Controls.Add(lblSportLabel)

        cmbFilterSport = UIHelper.MakeComboBox(370, 32, 250)
        pnlSelector.Controls.Add(cmbFilterSport)

        ' Action buttons aligned with combo boxes
        Dim btnGenerate As Button = UIHelper.MakeButton("📊 Generate", 640, 30, 140, "gold")
        btnGenerate.Height = 30
        AddHandler btnGenerate.Click, AddressOf BtnGenerate_Click
        pnlSelector.Controls.Add(btnGenerate)

        Dim btnExport As Button = UIHelper.MakeButton("📁 Export CSV", 790, 30, 140, "success")
        btnExport.Height = 30
        AddHandler btnExport.Click, AddressOf BtnExport_Click
        pnlSelector.Controls.Add(btnExport)

        Me.Controls.Add(pnlSelector)

        ' ── Summary label ──
        lblSummary = New Label()
        lblSummary.Location = New Point(30, 160)
        lblSummary.AutoSize = True
        lblSummary.Font = UIHelper.FontBold
        lblSummary.ForeColor = UIHelper.ColorPrimary

        Me.Controls.Add(lblSummary)

        ' ── Data grid ──
        dgv = UIHelper.MakeDataGridView(30, 188, 950, 390)
        Me.Controls.Add(dgv)
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

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs)
        If cmbReportType.Text = "" Then
            UIHelper.ShowError("Select a report type.")
            Return
        End If

        Dim sportFilterSql As String = ""
        Dim sportParam As SQLiteParameter = Nothing
        If cmbFilterSport.SelectedItem IsNot Nothing AndAlso TypeOf cmbFilterSport.SelectedItem Is SportItem Then
            sportFilterSql = " AND r.SportID=@sid "
            sportParam = New SQLiteParameter("@sid", CType(cmbFilterSport.SelectedItem, SportItem).SportID)
        End If

        Dim sql As String = ""
        Dim useParam As Boolean = False

        Select Case cmbReportType.Text
            Case "Registered Applicants"
                sql = "SELECT s.StudentNumber AS [Student ID], (s.FirstName || ' ' || s.LastName) AS Name, " &
                      "s.CourseYear AS [Course/Grade], sp.SportName AS Sport, r.RegistrationDate AS [Registration Date] " &
                      "FROM Registrations r INNER JOIN Students s ON s.StudentID=r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID=r.SportID WHERE 1=1 " & sportFilterSql & " ORDER BY r.RegistrationDate DESC"
                useParam = True

            Case "Applicants per Sport"
                sql = "SELECT sp.SportName AS Sport, COUNT(r.RegistrationID) AS [Total Applicants] " &
                      "FROM Sports sp LEFT JOIN Registrations r ON r.SportID = sp.SportID " &
                      "GROUP BY sp.SportName ORDER BY sp.SportName"

            Case "Tryout Schedules"
                sql = "SELECT sp.SportName AS Sport, sc.TryoutDate AS Date, sc.TryoutTime AS Time, sc.Venue, sc.Status " &
                      "FROM Schedules sc INNER JOIN Sports sp ON sp.SportID = sc.SportID WHERE 1=1 " &
                      Replace(sportFilterSql, "r.SportID", "sc.SportID") & " ORDER BY sc.TryoutDate"
                useParam = True

            Case "Athlete Evaluation Results"
                sql = "SELECT s.StudentNumber AS [Student ID], (s.FirstName || ' ' || s.LastName) AS Name, sp.SportName AS Sport, " &
                      "e.SkillScore AS Skill, e.SpeedScore AS Speed, e.AgilityScore AS Agility, e.EnduranceScore AS Endurance, " &
                      "e.TeamworkScore AS Teamwork, e.DisciplineScore AS Discipline, e.OverallPerformanceScore AS [Overall Perf.], " &
                      "e.FinalScore AS [Final Score] " &
                      "FROM Evaluations e INNER JOIN Registrations r ON r.RegistrationID = e.RegistrationID " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID WHERE 1=1 " & sportFilterSql & " ORDER BY e.FinalScore DESC"
                useParam = True

            Case "Applicant Rankings"
                sql = "SELECT s.StudentNumber AS [Student ID], (s.FirstName || ' ' || s.LastName) AS Name, sp.SportName AS Sport, " &
                      "e.FinalScore AS [Final Score] " &
                      "FROM Evaluations e INNER JOIN Registrations r ON r.RegistrationID = e.RegistrationID " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID WHERE 1=1 " & sportFilterSql & " ORDER BY sp.SportName, e.FinalScore DESC"
                useParam = True

            Case "Qualified Students"
                sql = "SELECT s.StudentNumber AS [Student ID], (s.FirstName || ' ' || s.LastName) AS Name, sp.SportName AS Sport, " &
                      "e.FinalScore AS [Final Score] " &
                      "FROM Evaluations e INNER JOIN Registrations r ON r.RegistrationID = e.RegistrationID " &
                      "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                      "WHERE e.FinalScore >= " & AppLogic.PassingScore.ToString("0.##") & " " & sportFilterSql & " ORDER BY sp.SportName, e.FinalScore DESC"
                useParam = True

            Case "Selected Athletes"
                sql = "SELECT s.StudentNumber AS [Student ID], (s.FirstName || ' ' || s.LastName) AS Name, sp.SportName AS Sport, " &
                      "r.SelectionDate AS [Decision Date], r.SelectionRemarks AS Remarks " &
                      "FROM Registrations r INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                      "WHERE r.SelectionStatus='Selected' " & sportFilterSql & " ORDER BY sp.SportName"
                useParam = True

            Case "Non-Selected Athletes"
                sql = "SELECT s.StudentNumber AS [Student ID], (s.FirstName || ' ' || s.LastName) AS Name, sp.SportName AS Sport, " &
                      "r.SelectionDate AS [Decision Date], r.SelectionRemarks AS Remarks " &
                      "FROM Registrations r INNER JOIN Students s ON s.StudentID = r.StudentID " &
                      "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                      "WHERE r.SelectionStatus='NotSelected' " & sportFilterSql & " ORDER BY sp.SportName"
                useParam = True
        End Select

        Try
            If useParam AndAlso sportParam IsNot Nothing Then
                currentReportTable = DatabaseHelper.GetDataTable(sql, sportParam)
            Else
                currentReportTable = DatabaseHelper.GetDataTable(sql)
            End If

            dgv.DataSource = currentReportTable
            lblSummary.Text = "📊  " & cmbReportType.Text & "  —  " & currentReportTable.Rows.Count & " record(s)"
        Catch ex As Exception
            UIHelper.ShowError("Failed to generate report: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs)
        If currentReportTable Is Nothing OrElse currentReportTable.Rows.Count = 0 Then
            UIHelper.ShowError("Generate a report first.")
            Return
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV File|*.csv"
            sfd.FileName = cmbReportType.Text.Replace(" ", "_") & ".csv"
            If sfd.ShowDialog() = DialogResult.OK Then
                If AppLogic.ExportDataTableToCsv(currentReportTable, sfd.FileName) Then
                    UIHelper.ShowInfo("Report exported successfully.")
                End If
            End If
        End Using
    End Sub

End Class
