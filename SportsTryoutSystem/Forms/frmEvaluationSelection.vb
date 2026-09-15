Public Class frmEvaluationSelection
    Inherits Form

    Private cmbFilterSport As ComboBox
    Private lblStats As Label
    Private tabMain As TabControl
    Private tabEval As TabPage
    Private tabRankings As TabPage

    ' Tab 1 - Evaluation & Selection Controls
    Private dgvApplicants As DataGridView
    Private lblApplicantHeader As Label
    Private numSkill As NumericUpDown
    Private numSpeed As NumericUpDown
    Private numAgility As NumericUpDown
    Private numEndurance As NumericUpDown
    Private numTeamwork As NumericUpDown
    Private numDiscipline As NumericUpDown
    Private numOverall As NumericUpDown
    Private lblFinalScoreValue As Label
    Private cmbDecision As ComboBox
    Private txtRemarks As TextBox
    Private btnSave As Button
    Private btnClear As Button
    Private selectedRegistrationId As Integer = 0

    ' Tab 2 - Screening & Rankings Controls
    Private chkQualifiedOnly As CheckBox
    Private btnExportRankings As Button
    Private lblRankSummary As Label
    Private dgvRankings As DataGridView

    Public Sub New()
        Me.Text = "Evaluation & Selection"
        Me.Dock = DockStyle.Fill
        Me.BackColor = UIHelper.ColorBackground
        BuildUI()
        LoadSportsFilter()
        RefreshAll()
    End Sub

    Private Sub BuildUI()
        Dim header As Panel = UIHelper.MakePanelHeader("Athlete Evaluation & Selection", Me.Width)
        Me.Controls.Add(header)

        ' Filter bar
        Dim pnlFilter As New Panel()
        pnlFilter.Dock = DockStyle.Top
        pnlFilter.Height = 50
        pnlFilter.BackColor = Color.White

        Dim filterAccent As New Panel()
        filterAccent.Dock = DockStyle.Bottom
        filterAccent.Height = 2
        filterAccent.BackColor = UIHelper.ColorGold
        pnlFilter.Controls.Add(filterAccent)

        Dim lblSport As Label = UIHelper.MakeLabel("Select Sport:", 25, 14, 90, True)
        cmbFilterSport = UIHelper.MakeComboBox(120, 10, 250)
        AddHandler cmbFilterSport.SelectedIndexChanged, AddressOf CmbFilterSport_SelectedIndexChanged

        lblStats = New Label()
        lblStats.Location = New Point(390, 13)
        lblStats.Size = New Size(750, 24)
        lblStats.Font = UIHelper.FontBold
        lblStats.ForeColor = UIHelper.ColorPrimary
        lblStats.TextAlign = ContentAlignment.MiddleLeft

        pnlFilter.Controls.Add(lblSport)
        pnlFilter.Controls.Add(cmbFilterSport)
        pnlFilter.Controls.Add(lblStats)
        Me.Controls.Add(pnlFilter)

        ' Tab Control
        tabMain = New TabControl()
        tabMain.Dock = DockStyle.Fill
        tabMain.Font = UIHelper.FontRegular
        tabMain.Padding = New Point(16, 8)

        tabEval = New TabPage("  1. Evaluation & Selection  ")
        tabEval.BackColor = UIHelper.ColorBackground
        BuildEvaluationTab()

        tabRankings = New TabPage("  2. Screening & Rankings Board  ")
        tabRankings.BackColor = UIHelper.ColorBackground
        BuildRankingsTab()

        tabMain.TabPages.Add(tabEval)
        tabMain.TabPages.Add(tabRankings)

        AddHandler tabMain.SelectedIndexChanged, AddressOf TabMain_SelectedIndexChanged

        Me.Controls.Add(tabMain)
        ' Ensure correct docking order: Header on top, Filter bar below it, TabControl fills the rest
        tabMain.BringToFront()
    End Sub

    Private Sub BuildEvaluationTab()
        Dim pnlContainer As New Panel()
        pnlContainer.Dock = DockStyle.Fill
        pnlContainer.Padding = New Padding(20, 15, 20, 15)

        ' Left Panel: Applicants Grid
        Dim lblGridTitle As Label = UIHelper.MakeLabel("Registered Applicants", 20, 10, 300, True)
        lblGridTitle.Font = UIHelper.FontSubHeader
        lblGridTitle.ForeColor = UIHelper.ColorPrimary
        pnlContainer.Controls.Add(lblGridTitle)

        dgvApplicants = UIHelper.MakeDataGridView(20, 38, 520, 480)
        dgvApplicants.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        AddHandler dgvApplicants.CellClick, AddressOf DgvApplicants_CellClick
        pnlContainer.Controls.Add(dgvApplicants)

        ' Right Panel: Assessment & Decision Card
        Dim pnlCard As New Panel()
        pnlCard.Location = New Point(560, 38)
        pnlCard.Size = New Size(540, 520)
        pnlCard.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlCard.BackColor = Color.White
        pnlCard.BorderStyle = BorderStyle.FixedSingle
        pnlCard.AutoScroll = True

        lblApplicantHeader = New Label()
        lblApplicantHeader.Text = "Select an applicant on the left to evaluate or record decision."
        lblApplicantHeader.Font = UIHelper.FontSubHeader
        lblApplicantHeader.ForeColor = UIHelper.ColorPrimary
        lblApplicantHeader.Location = New Point(20, 15)
        lblApplicantHeader.Size = New Size(490, 28)
        pnlCard.Controls.Add(lblApplicantHeader)

        Dim div1 As New Panel()
        div1.Location = New Point(20, 48)
        div1.Size = New Size(490, 1)
        div1.BackColor = Color.FromArgb(220, 224, 230)
        pnlCard.Controls.Add(div1)

        ' Scoring Criteria Header
        Dim lblCriteriaHeader As Label = UIHelper.MakeLabel("Tryout Performance Scores (0 - 100)", 20, 58, 350, True)
        lblCriteriaHeader.ForeColor = Color.FromArgb(70, 80, 95)
        pnlCard.Controls.Add(lblCriteriaHeader)

        Dim yRow1 As Integer = 85
        numSkill = AddScoreControl(pnlCard, "Skill Score", 20, yRow1)
        numSpeed = AddScoreControl(pnlCard, "Speed Score", 280, yRow1)

        Dim yRow2 As Integer = 125
        numAgility = AddScoreControl(pnlCard, "Agility Score", 20, yRow2)
        numEndurance = AddScoreControl(pnlCard, "Endurance Score", 280, yRow2)

        Dim yRow3 As Integer = 165
        numTeamwork = AddScoreControl(pnlCard, "Teamwork Score", 20, yRow3)
        numDiscipline = AddScoreControl(pnlCard, "Discipline Score", 280, yRow3)

        Dim yRow4 As Integer = 205
        numOverall = AddScoreControl(pnlCard, "Overall Perf.", 20, yRow4)

        ' Live Final Score Box
        Dim lblFinalTitle As Label = UIHelper.MakeLabel("Computed Score:", 280, yRow4 + 3, 110, True)
        pnlCard.Controls.Add(lblFinalTitle)

        lblFinalScoreValue = New Label()
        lblFinalScoreValue.Location = New Point(395, yRow4)
        lblFinalScoreValue.Size = New Size(100, 26)
        lblFinalScoreValue.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblFinalScoreValue.ForeColor = UIHelper.ColorAccent
        lblFinalScoreValue.Text = "0.00"
        pnlCard.Controls.Add(lblFinalScoreValue)

        Dim div2 As New Panel()
        div2.Location = New Point(20, 245)
        div2.Size = New Size(490, 1)
        div2.BackColor = Color.FromArgb(220, 224, 230)
        pnlCard.Controls.Add(div2)

        ' Final Selection Decision Area
        Dim lblDecisionTitle As Label = UIHelper.MakeLabel("Final Selection Status", 20, 255, 200, True)
        lblDecisionTitle.ForeColor = Color.FromArgb(70, 80, 95)
        pnlCard.Controls.Add(lblDecisionTitle)

        cmbDecision = UIHelper.MakeComboBox(20, 280, 230)
        cmbDecision.Items.AddRange(New String() {"Pending", "Selected", "Not Selected", "For Further Evaluation"})
        cmbDecision.SelectedIndex = 0
        pnlCard.Controls.Add(cmbDecision)

        Dim lblRemarks As Label = UIHelper.MakeLabel("Remarks / Assessment Notes:", 20, 318, 300)
        pnlCard.Controls.Add(lblRemarks)

        txtRemarks = UIHelper.MakeTextBox(20, 340, 480, False, True)
        txtRemarks.Height = 70
        pnlCard.Controls.Add(txtRemarks)

        btnSave = UIHelper.MakeButton("Save Evaluation & Selection", 20, 425, 260, "success")
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        pnlCard.Controls.Add(btnSave)

        btnClear = UIHelper.MakeButton("Reset", 295, 425, 120, "secondary")
        AddHandler btnClear.Click, AddressOf BtnClear_Click
        pnlCard.Controls.Add(btnClear)

        pnlContainer.Controls.Add(pnlCard)
        tabEval.Controls.Add(pnlContainer)
    End Sub

    Private Function AddScoreControl(parent As Panel, labelText As String, x As Integer, y As Integer) As NumericUpDown
        Dim lbl As Label = UIHelper.MakeLabel(labelText, x, y + 2, 100)
        parent.Controls.Add(lbl)

        Dim num As New NumericUpDown()
        num.Location = New Point(x + 105, y)
        num.Size = New Size(75, 24)
        num.Minimum = 0
        num.Maximum = 100
        num.DecimalPlaces = 0
        num.Font = UIHelper.FontRegular
        AddHandler num.ValueChanged, AddressOf AnyScore_Changed
        parent.Controls.Add(num)
        Return num
    End Function

    Private Sub BuildRankingsTab()
        Dim pnlRankings As New Panel()
        pnlRankings.Dock = DockStyle.Fill
        pnlRankings.Padding = New Padding(20, 15, 20, 15)

        Dim lblBoardTitle As Label = UIHelper.MakeLabel("Athlete Screening & Ranking Leaderboard", 20, 12, 350, True)
        lblBoardTitle.Font = UIHelper.FontSubHeader
        lblBoardTitle.ForeColor = UIHelper.ColorPrimary
        pnlRankings.Controls.Add(lblBoardTitle)

        chkQualifiedOnly = New CheckBox()
        chkQualifiedOnly.Text = "Show only qualified athletes (Final Score >= " & AppLogic.PassingScore.ToString("0") & ")"
        chkQualifiedOnly.Location = New Point(380, 14)
        chkQualifiedOnly.AutoSize = True
        chkQualifiedOnly.Font = UIHelper.FontRegular
        AddHandler chkQualifiedOnly.CheckedChanged, AddressOf ChkQualifiedOnly_CheckedChanged
        pnlRankings.Controls.Add(chkQualifiedOnly)

        btnExportRankings = UIHelper.MakeButton("Export to CSV", 820, 8, 150, "success")
        btnExportRankings.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AddHandler btnExportRankings.Click, AddressOf BtnExportRankings_Click
        pnlRankings.Controls.Add(btnExportRankings)

        lblRankSummary = New Label()
        lblRankSummary.Location = New Point(20, 42)
        lblRankSummary.AutoSize = True
        lblRankSummary.Font = UIHelper.FontBold
        lblRankSummary.ForeColor = Color.Gray
        pnlRankings.Controls.Add(lblRankSummary)

        dgvRankings = UIHelper.MakeDataGridView(20, 70, 950, 460)
        dgvRankings.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        AddHandler dgvRankings.CellDoubleClick, AddressOf DgvRankings_CellDoubleClick
        pnlRankings.Controls.Add(dgvRankings)

        Dim lblHint As New Label()
        lblHint.Text = "Tip: Double-click any athlete in the leaderboard to jump to Evaluation & Selection."
        lblHint.Location = New Point(20, 535)
        lblHint.AutoSize = True
        lblHint.Font = UIHelper.FontRegular
        lblHint.ForeColor = Color.Gray
        lblHint.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        pnlRankings.Controls.Add(lblHint)

        tabRankings.Controls.Add(pnlRankings)
    End Sub

    Private Sub LoadSportsFilter()
        cmbFilterSport.Items.Clear()
        Dim sql As String = "SELECT SportID, SportName FROM Sports WHERE IsActive=1 "
        If SessionManager.IsCoach Then
            sql &= " AND SportID IN (SELECT SportID FROM SportCoaches WHERE UserID=" & SessionManager.CurrentUserID & ") "
        End If
        sql &= "ORDER BY SportName"
        Dim dt As DataTable = DatabaseHelper.GetDataTable(sql)
        For Each row As DataRow In dt.Rows
            cmbFilterSport.Items.Add(New SportItem(CInt(row("SportID")), row("SportName").ToString()))
        Next
        If cmbFilterSport.Items.Count > 0 Then cmbFilterSport.SelectedIndex = 0
    End Sub

    Private Sub CmbFilterSport_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectedRegistrationId = 0
        ResetDetailForm()
        RefreshAll()
    End Sub

    Private Sub TabMain_SelectedIndexChanged(sender As Object, e As EventArgs)
        If tabMain.SelectedTab Is tabRankings Then
            LoadRankings()
        Else
            LoadApplicants()
        End If
    End Sub

    Private Function GetCurrentSportId() As Integer
        If cmbFilterSport.SelectedItem IsNot Nothing AndAlso TypeOf cmbFilterSport.SelectedItem Is SportItem Then
            Return CType(cmbFilterSport.SelectedItem, SportItem).SportID
        End If
        Return 0
    End Function

    Private Sub RefreshAll()
        Dim sportId As Integer = GetCurrentSportId()
        If sportId = 0 Then
            dgvApplicants.DataSource = Nothing
            dgvRankings.DataSource = Nothing
            lblStats.Text = "No active sports assigned or available."
            Return
        End If

        UpdateSummaryStats(sportId)
        LoadApplicants()
        LoadRankings()
    End Sub

    Private Sub UpdateSummaryStats(sportId As Integer)
        Try
            Dim totalApplicants As Object = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Registrations WHERE SportID=@sid", New SQLiteParameter("@sid", sportId))
            Dim evaluatedCount As Object = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(e.EvaluationID) FROM Evaluations e INNER JOIN Registrations r ON r.RegistrationID=e.RegistrationID WHERE r.SportID=@sid",
                New SQLiteParameter("@sid", sportId))
            Dim selectedCount As Object = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Registrations WHERE SportID=@sid AND SelectionStatus='Selected'",
                New SQLiteParameter("@sid", sportId))

            Dim dtEvals As DataTable = DatabaseHelper.GetDataTable(
                "SELECT e.FinalScore FROM Evaluations e INNER JOIN Registrations r ON r.RegistrationID=e.RegistrationID WHERE r.SportID=@sid",
                New SQLiteParameter("@sid", sportId))

            Dim qualifiedCount As Integer = 0
            For Each row As DataRow In dtEvals.Rows
                If Not IsDBNull(row("FinalScore")) AndAlso CDbl(row("FinalScore")) >= AppLogic.PassingScore Then
                    qualifiedCount += 1
                End If
            Next

            lblStats.Text = String.Format("Total Applicants: {0}   |   Evaluated: {1}   |   Qualified (>= {2:0}): {3}   |   Selected: {4}",
                                          If(totalApplicants, 0), If(evaluatedCount, 0), AppLogic.PassingScore, qualifiedCount, If(selectedCount, 0))
        Catch
            lblStats.Text = ""
        End Try
    End Sub

    Private Sub LoadApplicants()
        Dim sportId As Integer = GetCurrentSportId()
        If sportId = 0 Then Return

        Dim dt As DataTable = DatabaseHelper.GetDataTable(
            "SELECT r.RegistrationID, s.StudentNumber, (s.FirstName || ' ' || s.LastName) AS FullName, " &
            "CASE WHEN e.FinalScore IS NULL THEN 'N/A' ELSE CAST(e.FinalScore AS CHAR) END AS FinalScore, " &
            "r.SelectionStatus " &
            "FROM Registrations r " &
            "INNER JOIN Students s ON s.StudentID = r.StudentID " &
            "LEFT JOIN Evaluations e ON e.RegistrationID = r.RegistrationID " &
            "WHERE r.SportID=@sid ORDER BY e.FinalScore DESC",
            New SQLiteParameter("@sid", sportId))

        Dim display As New DataTable()
        display.Columns.Add("RegistrationID", GetType(Integer))
        display.Columns.Add("Student ID")
        display.Columns.Add("Full Name")
        display.Columns.Add("Final Score")
        display.Columns.Add("Selection Status")

        For Each row As DataRow In dt.Rows
            display.Rows.Add(
                CInt(row("RegistrationID")),
                row("StudentNumber").ToString(),
                row("FullName").ToString(),
                row("FinalScore").ToString(),
                AppLogic.DisplaySelectionStatus(row("SelectionStatus").ToString()))
        Next

        dgvApplicants.DataSource = display
        If dgvApplicants.Columns.Contains("RegistrationID") Then dgvApplicants.Columns("RegistrationID").Visible = False

        ' Highlight currently selected row if any
        If selectedRegistrationId > 0 Then
            For Each r As DataGridViewRow In dgvApplicants.Rows
                If CInt(r.Cells("RegistrationID").Value) = selectedRegistrationId Then
                    r.Selected = True
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub DgvApplicants_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim regId As Integer = CInt(dgvApplicants.Rows(e.RowIndex).Cells("RegistrationID").Value)
        LoadApplicantForEditing(regId)
    End Sub

    Private Sub LoadApplicantForEditing(regId As Integer)
        selectedRegistrationId = regId

        Dim studentNum As String = ""
        Dim fullName As String = ""
        For Each r As DataGridViewRow In dgvApplicants.Rows
            If CInt(r.Cells("RegistrationID").Value) = regId Then
                studentNum = r.Cells("Student ID").Value.ToString()
                fullName = r.Cells("Full Name").Value.ToString()
                Exit For
            End If
        Next

        lblApplicantHeader.Text = String.Format("Applicant: {0} ({1})", fullName, studentNum)

        ' Load evaluation scores
        Dim evTable As DataTable = DatabaseHelper.GetDataTable(
            "SELECT * FROM Evaluations WHERE RegistrationID=@id", New SQLiteParameter("@id", regId))

        If evTable.Rows.Count > 0 Then
            Dim ev As DataRow = evTable.Rows(0)
            numSkill.Value = CDec(ev("SkillScore"))
            numSpeed.Value = CDec(ev("SpeedScore"))
            numAgility.Value = CDec(ev("AgilityScore"))
            numEndurance.Value = CDec(ev("EnduranceScore"))
            numTeamwork.Value = CDec(ev("TeamworkScore"))
            numDiscipline.Value = CDec(ev("DisciplineScore"))
            numOverall.Value = CDec(ev("OverallPerformanceScore"))
            lblFinalScoreValue.Text = CDbl(ev("FinalScore")).ToString("0.00")
            txtRemarks.Text = If(IsDBNull(ev("Remarks")), "", ev("Remarks").ToString())
        Else
            numSkill.Value = 0
            numSpeed.Value = 0
            numAgility.Value = 0
            numEndurance.Value = 0
            numTeamwork.Value = 0
            numDiscipline.Value = 0
            numOverall.Value = 0
            lblFinalScoreValue.Text = "0.00"
            txtRemarks.Text = ""
        End If

        UpdateFinalScoreColor()

        ' Load selection decision
        Dim regTable As DataTable = DatabaseHelper.GetDataTable(
            "SELECT SelectionStatus, SelectionRemarks FROM Registrations WHERE RegistrationID=@id",
            New SQLiteParameter("@id", regId))

        If regTable.Rows.Count > 0 Then
            Dim status As String = regTable.Rows(0)("SelectionStatus").ToString()
            cmbDecision.Text = AppLogic.DisplaySelectionStatus(status)
            If txtRemarks.Text = "" AndAlso Not IsDBNull(regTable.Rows(0)("SelectionRemarks")) Then
                txtRemarks.Text = regTable.Rows(0)("SelectionRemarks").ToString()
            End If
        Else
            cmbDecision.Text = "Pending"
        End If
    End Sub

    Private Sub AnyScore_Changed(sender As Object, e As EventArgs)
        Dim finalScore As Double = AppLogic.ComputeFinalScore(
            CDbl(numSkill.Value), CDbl(numSpeed.Value), CDbl(numAgility.Value), CDbl(numEndurance.Value),
            CDbl(numTeamwork.Value), CDbl(numDiscipline.Value), CDbl(numOverall.Value))
        lblFinalScoreValue.Text = finalScore.ToString("0.00")
        UpdateFinalScoreColor()
    End Sub

    Private Sub UpdateFinalScoreColor()
        Dim score As Double = 0
        Double.TryParse(lblFinalScoreValue.Text, score)
        If score >= AppLogic.PassingScore Then
            lblFinalScoreValue.ForeColor = UIHelper.ColorSuccess
        ElseIf score > 0 Then
            lblFinalScoreValue.ForeColor = UIHelper.ColorWarning
        Else
            lblFinalScoreValue.ForeColor = UIHelper.ColorAccent
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        If selectedRegistrationId = 0 Then
            UIHelper.ShowError("Please select an applicant from the list first.")
            Return
        End If

        Dim finalScore As Double = AppLogic.ComputeFinalScore(
            CDbl(numSkill.Value), CDbl(numSpeed.Value), CDbl(numAgility.Value), CDbl(numEndurance.Value),
            CDbl(numTeamwork.Value), CDbl(numDiscipline.Value), CDbl(numOverall.Value))

        Dim statusCode As String
        Select Case cmbDecision.Text
            Case "Selected"
                statusCode = "Selected"
            Case "Not Selected"
                statusCode = "NotSelected"
            Case "For Further Evaluation"
                statusCode = "ForFurtherEvaluation"
            Case Else
                statusCode = "Pending"
        End Select

        Try
            ' 1. Save Evaluation Scores
            Dim existing As Object = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Evaluations WHERE RegistrationID=@id", New SQLiteParameter("@id", selectedRegistrationId))

            If CInt(existing) > 0 Then
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Evaluations SET SkillScore=@sk, SpeedScore=@sp, AgilityScore=@ag, EnduranceScore=@en, " &
                    "TeamworkScore=@tw, DisciplineScore=@di, OverallPerformanceScore=@ov, FinalScore=@fs, Remarks=@rm, " &
                    "EvaluatorUserID=@ev, EvaluationDate=@ed WHERE RegistrationID=@id",
                    New SQLiteParameter("@sk", numSkill.Value), New SQLiteParameter("@sp", numSpeed.Value),
                    New SQLiteParameter("@ag", numAgility.Value), New SQLiteParameter("@en", numEndurance.Value),
                    New SQLiteParameter("@tw", numTeamwork.Value), New SQLiteParameter("@di", numDiscipline.Value),
                    New SQLiteParameter("@ov", numOverall.Value), New SQLiteParameter("@fs", finalScore),
                    New SQLiteParameter("@rm", txtRemarks.Text.Trim()), New SQLiteParameter("@ev", SessionManager.CurrentUserID),
                    New SQLiteParameter("@ed", Now.ToString("s")), New SQLiteParameter("@id", selectedRegistrationId))
            Else
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO Evaluations (RegistrationID, EvaluatorUserID, SkillScore, SpeedScore, AgilityScore, EnduranceScore, " &
                    "TeamworkScore, DisciplineScore, OverallPerformanceScore, FinalScore, Remarks, EvaluationDate) " &
                    "VALUES (@id,@ev,@sk,@sp,@ag,@en,@tw,@di,@ov,@fs,@rm,@ed)",
                    New SQLiteParameter("@id", selectedRegistrationId), New SQLiteParameter("@ev", SessionManager.CurrentUserID),
                    New SQLiteParameter("@sk", numSkill.Value), New SQLiteParameter("@sp", numSpeed.Value),
                    New SQLiteParameter("@ag", numAgility.Value), New SQLiteParameter("@en", numEndurance.Value),
                    New SQLiteParameter("@tw", numTeamwork.Value), New SQLiteParameter("@di", numDiscipline.Value),
                    New SQLiteParameter("@ov", numOverall.Value), New SQLiteParameter("@fs", finalScore),
                    New SQLiteParameter("@rm", txtRemarks.Text.Trim()), New SQLiteParameter("@ed", Now.ToString("s")))
            End If

            ' 2. Save Selection Decision
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Registrations SET SelectionStatus=@st, SelectionDate=@d, SelectionRemarks=@r, SelectionBy=@by WHERE RegistrationID=@id",
                New SQLiteParameter("@st", statusCode),
                New SQLiteParameter("@d", Now.ToString("s")),
                New SQLiteParameter("@r", txtRemarks.Text.Trim()),
                New SQLiteParameter("@by", SessionManager.CurrentFullName),
                New SQLiteParameter("@id", selectedRegistrationId))

            UIHelper.ShowInfo(String.Format("Evaluation & selection saved successfully!{0}Final Score: {1:0.00}{0}Status: {2}",
                                            vbCrLf, finalScore, AppLogic.DisplaySelectionStatus(statusCode)))

            Dim currSportId As Integer = GetCurrentSportId()
            UpdateSummaryStats(currSportId)
            LoadApplicants()
            LoadRankings()
        Catch ex As Exception
            UIHelper.ShowError("Failed to save evaluation & selection: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        ResetDetailForm()
    End Sub

    Private Sub ResetDetailForm()
        selectedRegistrationId = 0
        lblApplicantHeader.Text = "Select an applicant on the left to evaluate or record decision."
        numSkill.Value = 0
        numSpeed.Value = 0
        numAgility.Value = 0
        numEndurance.Value = 0
        numTeamwork.Value = 0
        numDiscipline.Value = 0
        numOverall.Value = 0
        lblFinalScoreValue.Text = "0.00"
        cmbDecision.Text = "Pending"
        txtRemarks.Text = ""
        UpdateFinalScoreColor()
    End Sub

    ' ----------------------------------------------------
    ' Tab 2: Screening & Rankings Board Implementation
    ' ----------------------------------------------------

    Private Sub ChkQualifiedOnly_CheckedChanged(sender As Object, e As EventArgs)
        LoadRankings()
    End Sub

    Private Sub LoadRankings()
        Dim sportId As Integer = GetCurrentSportId()
        If sportId = 0 Then
            dgvRankings.DataSource = Nothing
            lblRankSummary.Text = ""
            Return
        End If

        Dim dt As DataTable = DatabaseHelper.GetDataTable(
            "SELECT s.StudentNumber, (s.FirstName || ' ' || s.LastName) AS FullName, " &
            "e.SkillScore, e.SpeedScore, e.AgilityScore, e.EnduranceScore, e.TeamworkScore, e.DisciplineScore, " &
            "e.OverallPerformanceScore, e.FinalScore " &
            "FROM Evaluations e " &
            "INNER JOIN Registrations r ON r.RegistrationID = e.RegistrationID " &
            "INNER JOIN Students s ON s.StudentID = r.StudentID " &
            "WHERE r.SportID=@sid ORDER BY e.FinalScore DESC",
            New SQLiteParameter("@sid", sportId))

        ' Fetch selection status for each registration in this sport
        Dim dtSel As DataTable = DatabaseHelper.GetDataTable(
            "SELECT r.RegistrationID, s.StudentNumber, r.SelectionStatus FROM Registrations r INNER JOIN Students s ON s.StudentID=r.StudentID WHERE r.SportID=@sid",
            New SQLiteParameter("@sid", sportId))
        Dim statusMap As New Dictionary(Of String, String)()
        Dim regIdMap As New Dictionary(Of String, Integer)()
        For Each row As DataRow In dtSel.Rows
            Dim sn As String = row("StudentNumber").ToString()
            statusMap(sn) = AppLogic.DisplaySelectionStatus(row("SelectionStatus").ToString())
            regIdMap(sn) = CInt(row("RegistrationID"))
        Next

        Dim display As New DataTable()
        display.Columns.Add("Rank", GetType(Integer))
        display.Columns.Add("RegistrationID", GetType(Integer))
        display.Columns.Add("Student ID")
        display.Columns.Add("Name")
        display.Columns.Add("Skill")
        display.Columns.Add("Speed")
        display.Columns.Add("Agility")
        display.Columns.Add("Endurance")
        display.Columns.Add("Teamwork")
        display.Columns.Add("Discipline")
        display.Columns.Add("Overall")
        display.Columns.Add("Final Score")
        display.Columns.Add("Qualifies (>=75)")
        display.Columns.Add("Selection Status")

        Dim rank As Integer = 0
        Dim qualifiedCount As Integer = 0

        For Each row As DataRow In dt.Rows
            rank += 1
            Dim sn As String = row("StudentNumber").ToString()
            Dim finalScore As Double = CDbl(row("FinalScore"))
            Dim qualifies As Boolean = finalScore >= AppLogic.PassingScore
            If qualifies Then qualifiedCount += 1

            If chkQualifiedOnly.Checked AndAlso Not qualifies Then Continue For

            Dim status As String = If(statusMap.ContainsKey(sn), statusMap(sn), "Pending")
            Dim regId As Integer = If(regIdMap.ContainsKey(sn), regIdMap(sn), 0)

            display.Rows.Add(rank, regId, sn, row("FullName").ToString(),
                             row("SkillScore"), row("SpeedScore"), row("AgilityScore"), row("EnduranceScore"),
                             row("TeamworkScore"), row("DisciplineScore"), row("OverallPerformanceScore"),
                             finalScore.ToString("0.00"), If(qualifies, "Yes", "No"), status)
        Next

        dgvRankings.DataSource = display
        If dgvRankings.Columns.Contains("RegistrationID") Then dgvRankings.Columns("RegistrationID").Visible = False

        lblRankSummary.Text = String.Format("Total Ranked: {0} athlete(s)   |   Meeting Qualifying Standard (>= {1:0}): {2}",
                                            dt.Rows.Count, AppLogic.PassingScore, qualifiedCount)
    End Sub

    Private Sub DgvRankings_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim regId As Integer = CInt(dgvRankings.Rows(e.RowIndex).Cells("RegistrationID").Value)
        If regId > 0 Then
            tabMain.SelectedTab = tabEval
            LoadApplicantForEditing(regId)
        End If
    End Sub

    Private Sub BtnExportRankings_Click(sender As Object, e As EventArgs)
        If dgvRankings.DataSource Is Nothing OrElse CType(dgvRankings.DataSource, DataTable).Rows.Count = 0 Then
            UIHelper.ShowInfo("No rankings data to export.")
            Return
        End If

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "CSV File (*.csv)|*.csv"
        Dim sportName As String = If(cmbFilterSport.SelectedItem IsNot Nothing, cmbFilterSport.Text, "Sport")
        sfd.FileName = "Rankings_" & sportName.Replace(" ", "_") & "_" & Now.ToString("yyyyMMdd") & ".csv"

        If sfd.ShowDialog() = DialogResult.OK Then
            Dim dtExport As DataTable = CType(dgvRankings.DataSource, DataTable).Copy()
            If dtExport.Columns.Contains("RegistrationID") Then dtExport.Columns.Remove("RegistrationID")
            If AppLogic.ExportDataTableToCsv(dtExport, sfd.FileName) Then
                UIHelper.ShowInfo("Rankings exported successfully to " & sfd.FileName)
            End If
        End If
    End Sub

End Class
