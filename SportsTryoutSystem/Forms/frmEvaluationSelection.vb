Imports System.Data
Imports System.Drawing

Public Class frmEvaluationSelection

    Private selectedRegistrationId As Integer = 0
    Private headerPanel As Panel

    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True

        headerPanel = UIHelper.MakePanelHeader("Athlete Evaluation & Selection", Me.Width)
        Me.Controls.Add(headerPanel)
        headerPanel.SendToBack()

        AddHandler Me.Resize, AddressOf OnFormResized
        AddHandler Me.Shown, AddressOf OnFormShown
        AddHandler dgvApplicants.CellFormatting, AddressOf DgvApplicants_CellFormatting
        AddHandler dgvRankings.CellFormatting, AddressOf DgvRankings_CellFormatting
    End Sub

    Private Sub OnFormShown(sender As Object, e As EventArgs)
        LayoutPanels()
        Try
            LoadSportsFilter()
            RefreshAll()
        Catch ex As Exception
            UIHelper.ShowError("Failed to initialize evaluations: " & ex.Message)
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

        Dim topY As Integer = 66
        Dim marginX As Integer = 20
        Dim bottomMargin As Integer = 14
        Dim totalW As Integer = Me.ClientSize.Width - (marginX * 2)

        ' 1. Top Filter & KPI Bar
        pnlFilter.Location = New Point(marginX, topY)
        pnlFilter.Size = New Size(totalW, 64)
        filterAccent.Width = totalW

        lblSport.Location = New Point(20, 20)
        cmbFilterSport.Location = New Point(lblSport.Right + 12, 16)
        cmbFilterSport.Size = New Size(260, 30)

        Dim statsLeft As Integer = cmbFilterSport.Right + 20
        Dim statsW As Integer = Math.Max(200, totalW - statsLeft - 20)
        lblStats.Location = New Point(statsLeft, 14)
        lblStats.Size = New Size(statsW, 36)

        ' 2. Main Tab Control
        Dim tabY As Integer = topY + pnlFilter.Height + 10
        Dim tabH As Integer = Me.ClientSize.Height - tabY - bottomMargin
        tabMain.Location = New Point(marginX, tabY)
        tabMain.Size = New Size(totalW, Math.Max(350, tabH))

        ' 3. Layout Tabs
        LayoutTabEval()
        LayoutTabRankings()

        Me.ResumeLayout(True)
    End Sub

    Private Sub LayoutTabEval()
        Dim containerW As Integer = pnlContainer.ClientSize.Width
        Dim containerH As Integer = pnlContainer.ClientSize.Height
        If containerW < 500 OrElse containerH < 300 Then Return

        pnlContainer.SuspendLayout()

        Dim gapX As Integer = 16
        ' Left Roster Card: ~38% of width, bounded between 380 and 600
        Dim leftW As Integer = CInt(Math.Max(380, Math.Min(600, (containerW - gapX) * 0.38)))
        Dim rightW As Integer = containerW - leftW - gapX

        ' Roster Card (Left)
        pnlRosterCard.Location = New Point(8, 8)
        pnlRosterCard.Size = New Size(leftW, containerH - 16)
        rosterAccent.Width = leftW

        lblGridTitle.Location = New Point(18, 14)
        lblRosterCount.Location = New Point(lblGridTitle.Right + 10, 16)

        lblSearch.Location = New Point(18, 50)
        Dim searchLeft As Integer = lblSearch.Right + 8
        Dim searchW As Integer = Math.Max(100, leftW - searchLeft - 18)
        txtSearchApplicant.Location = New Point(searchLeft, 46)
        txtSearchApplicant.Size = New Size(searchW, 28)

        dgvApplicants.Location = New Point(18, 84)
        dgvApplicants.Size = New Size(leftW - 36, Math.Max(120, pnlRosterCard.Height - 98))

        ' Evaluation Detail Card (Right)
        pnlCard.Location = New Point(8 + leftW + gapX, 8)
        pnlCard.Size = New Size(rightW, containerH - 16)
        cardAccent.Width = rightW

        LayoutEvaluationCard(rightW, pnlCard.ClientSize.Height)

        pnlContainer.ResumeLayout(True)
    End Sub

    Private Sub LayoutEvaluationCard(cardW As Integer, cardH As Integer)
        pnlCard.SuspendLayout()

        cardAccent.Width = cardW

        Dim marginX As Integer = 20
        Dim usableW As Integer = cardW - (marginX * 2)

        Dim isTall As Boolean = cardH >= 600

        ' Top Applicant Headers (Row 1: Title/Selected Athlete, Row 2: Subtitle instructions)
        Dim topHeaderY As Integer = If(isTall, 14, 10)
        lblApplicantHeader.Location = New Point(marginX, topHeaderY)
        lblApplicantHeader.Size = New Size(usableW, 24)
        lblApplicantHeader.TextAlign = ContentAlignment.MiddleLeft

        Dim topSubY As Integer = topHeaderY + 26
        lblApplicantSub.Location = New Point(marginX, topSubY)
        lblApplicantSub.Size = New Size(usableW, 18)
        lblApplicantSub.TextAlign = ContentAlignment.MiddleLeft

        Dim div1Y As Integer = topSubY + 22
        div1.Location = New Point(marginX, div1Y)
        div1.Size = New Size(usableW, 1)
        div1.Visible = True

        Dim critY As Integer = div1Y + If(isTall, 8, 6)
        lblCriteriaHeader.Location = New Point(marginX, critY)
        lblCriteriaHeader.Size = New Size(usableW, 18)

        ' 2-column scoring grid
        Dim colGap As Integer = 20
        Dim colW As Integer = CInt((usableW - colGap) / 2)
        Dim col1X As Integer = marginX
        Dim col2X As Integer = marginX + colW + colGap

        Dim numW As Integer = 95
        Dim numH As Integer = If(isTall, 30, 26)
        Dim lblW As Integer = colW - numW - 8

        ' Row spacing adapted to available height
        Dim rowGap As Integer = If(isTall, 36, 31)
        Dim row1Y As Integer = critY + lblCriteriaHeader.Height + If(isTall, 8, 5)

        ' Row 1: Skill & Teamwork
        Dim r1Y As Integer = row1Y
        lblSkill.Location = New Point(col1X, r1Y + 2)
        lblSkill.Size = New Size(lblW, 22)
        numSkill.Location = New Point(col1X + colW - numW, r1Y)
        numSkill.Size = New Size(numW, numH)

        lblTeamwork.Location = New Point(col2X, r1Y + 2)
        lblTeamwork.Size = New Size(lblW, 22)
        numTeamwork.Location = New Point(col2X + colW - numW, r1Y)
        numTeamwork.Size = New Size(numW, numH)

        ' Row 2: Speed & Discipline
        Dim r2Y As Integer = r1Y + rowGap
        lblSpeed.Location = New Point(col1X, r2Y + 2)
        lblSpeed.Size = New Size(lblW, 22)
        numSpeed.Location = New Point(col1X + colW - numW, r2Y)
        numSpeed.Size = New Size(numW, numH)

        lblDiscipline.Location = New Point(col2X, r2Y + 2)
        lblDiscipline.Size = New Size(lblW, 22)
        numDiscipline.Location = New Point(col2X + colW - numW, r2Y)
        numDiscipline.Size = New Size(numW, numH)

        ' Row 3: Agility & Overall
        Dim r3Y As Integer = r2Y + rowGap
        lblAgility.Location = New Point(col1X, r3Y + 2)
        lblAgility.Size = New Size(lblW, 22)
        numAgility.Location = New Point(col1X + colW - numW, r3Y)
        numAgility.Size = New Size(numW, numH)

        lblOverall.Location = New Point(col2X, r3Y + 2)
        lblOverall.Size = New Size(lblW, 22)
        numOverall.Location = New Point(col2X + colW - numW, r3Y)
        numOverall.Size = New Size(numW, numH)

        ' Row 4: Endurance & Scale Hint
        Dim r4Y As Integer = r3Y + rowGap
        lblEndurance.Location = New Point(col1X, r4Y + 2)
        lblEndurance.Size = New Size(lblW, 22)
        numEndurance.Location = New Point(col1X + colW - numW, r4Y)
        numEndurance.Size = New Size(numW, numH)

        lblScaleHint.Location = New Point(col2X, r4Y + 3)
        lblScaleHint.Size = New Size(colW, 22)

        ' Computed Score Banner
        Dim bannerY As Integer = r4Y + numH + If(isTall, 14, 10)
        Dim bannerH As Integer = If(isTall, 70, 66)
        pnlScoreBanner.Location = New Point(marginX, bannerY)
        pnlScoreBanner.Size = New Size(usableW, bannerH)

        Dim titleY As Integer = If(isTall, 10, 8)
        lblFinalTitle.Location = New Point(18, titleY)
        lblPassingStandard.Location = New Point(18, titleY + 26)
        lblPassingStandard.Size = New Size(320, 20)
        lblFinalScoreValue.Location = New Point(usableW - 170, If(isTall, 8, 6))
        lblFinalScoreValue.Size = New Size(150, If(isTall, 50, 46))

        ' Hide div2 since Score Banner already has a styled container
        div2.Visible = False
        div2.Size = Size.Empty

        ' Selection Decision Row (Horizontal aligned)
        Dim decY As Integer = bannerY + bannerH + If(isTall, 12, 10)
        lblDecisionTitle.Location = New Point(marginX, decY + 4)
        lblDecisionTitle.Text = "DECISION: *"

        Dim decComboLeft As Integer = lblDecisionTitle.Right + 12
        Dim decComboW As Integer = Math.Min(220, Math.Max(180, CInt(usableW * 0.32)))
        cmbDecision.Location = New Point(decComboLeft, decY)
        cmbDecision.Size = New Size(decComboW, 28)

        Dim hintX As Integer = decComboLeft + decComboW + 14
        Dim hintW As Integer = Math.Max(120, usableW - (hintX - marginX))
        lblDecisionHint.Location = New Point(hintX, decY + 2)
        lblDecisionHint.Size = New Size(hintW, 36)

        ' Remarks Header & TextBox
        Dim remTitleY As Integer = decY + 40
        lblRemarks.Location = New Point(marginX, remTitleY)

        Dim remBoxY As Integer = remTitleY + 22

        ' Action Buttons (Pinned to bottom of card)
        Dim btnH As Integer = 42
        Dim btnY As Integer = cardH - btnH - 12

        ' Remarks TextBox dynamically takes ALL remaining vertical space!
        Dim remarksH As Integer = Math.Max(48, btnY - 10 - remBoxY)
        txtRemarks.Location = New Point(marginX, remBoxY)
        txtRemarks.Size = New Size(usableW, remarksH)

        ' Action Buttons span full usable width
        Dim btnGap As Integer = 16
        Dim btnSaveW As Integer = CInt((usableW - btnGap) * 0.65)
        Dim btnClearW As Integer = usableW - btnGap - btnSaveW

        btnSave.Location = New Point(marginX, btnY)
        btnSave.Size = New Size(btnSaveW, btnH)

        btnClear.Location = New Point(marginX + btnSaveW + btnGap, btnY)
        btnClear.Size = New Size(btnClearW, btnH)

        pnlCard.ResumeLayout(True)
    End Sub

    Private Sub LayoutTabRankings()
        Dim rankW As Integer = pnlRankings.ClientSize.Width
        Dim rankH As Integer = pnlRankings.ClientSize.Height
        If rankW < 500 OrElse rankH < 300 Then Return

        pnlRankings.SuspendLayout()

        pnlRankCard.Location = New Point(8, 8)
        pnlRankCard.Size = New Size(rankW - 16, rankH - 16)
        rankAccent.Width = pnlRankCard.Width

        Dim cardW As Integer = pnlRankCard.Width
        Dim cardH As Integer = pnlRankCard.Height

        Dim exportW As Integer = 180
        Dim exportH As Integer = 40
        btnExportRankings.Size = New Size(exportW, exportH)
        btnExportRankings.Location = New Point(cardW - exportW - 20, 14)

        lblBoardTitle.Location = New Point(20, 16)

        ' Responsive header layout for Tab 2
        If cardW >= 1060 Then
            ' Wide layout: Title, Checkbox, Export all on Row 1
            chkQualifiedOnly.Location = New Point(lblBoardTitle.Right + 24, 22)
            lblRankSummary.Location = New Point(20, 54)
            dgvRankings.Location = New Point(20, 84)
            dgvRankings.Size = New Size(cardW - 40, Math.Max(120, cardH - 98))
        Else
            ' Narrower layout: Row 1 = Title & Export, Row 2 = Checkbox & Summary
            chkQualifiedOnly.Location = New Point(20, 50)
            Dim sumLeft As Integer = chkQualifiedOnly.Right + 20
            lblRankSummary.Location = New Point(sumLeft, 52)
            dgvRankings.Location = New Point(20, 84)
            dgvRankings.Size = New Size(cardW - 40, Math.Max(120, cardH - 98))
        End If

        pnlRankings.ResumeLayout(True)
    End Sub

    ' ========================================================
    '  FILTER & DATA LOADING
    ' ========================================================

    Private Sub LoadSportsFilter()
        cmbFilterSport.Items.Clear()
        Dim sql As String = "SELECT SportID, SportName FROM Sports WHERE IsActive=1 "
        If SessionManager.IsCoach OrElse SessionManager.IsEvaluator Then
            sql &= " AND SportID IN (SELECT SportID FROM SportCoaches WHERE UserID=" & SessionManager.CurrentUserID & ") "
        End If
        sql &= "ORDER BY SportName"
        Dim dt As DataTable = DatabaseHelper.GetDataTable(sql)
        For Each row As DataRow In dt.Rows
            cmbFilterSport.Items.Add(New SportItem(CInt(row("SportID")), row("SportName").ToString()))
        Next
        If cmbFilterSport.Items.Count > 0 Then cmbFilterSport.SelectedIndex = 0
    End Sub

    Private Sub CmbFilterSport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterSport.SelectedIndexChanged
        selectedRegistrationId = 0
        ResetDetailForm()
        RefreshAll()
    End Sub

    Private Sub TabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged
        If tabMain.SelectedTab Is tabRankings Then
            LoadRankings()
            LayoutTabRankings()
        Else
            LoadApplicants()
            LayoutTabEval()
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

            lblStats.Text = String.Format("Total Applicants: {0}   |   Evaluated: {1}   |   Qualified (≥ {2:0}): {3}   |   Selected: {4}",
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

        If dgvApplicants.Columns.Contains("Student ID") Then
            dgvApplicants.Columns("Student ID").FillWeight = 22
            dgvApplicants.Columns("Student ID").MinimumWidth = 90
        End If
        If dgvApplicants.Columns.Contains("Full Name") Then
            dgvApplicants.Columns("Full Name").FillWeight = 38
            dgvApplicants.Columns("Full Name").MinimumWidth = 120
        End If
        If dgvApplicants.Columns.Contains("Final Score") Then
            dgvApplicants.Columns("Final Score").FillWeight = 18
            dgvApplicants.Columns("Final Score").MinimumWidth = 75
            dgvApplicants.Columns("Final Score").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvApplicants.Columns("Final Score").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvApplicants.Columns.Contains("Selection Status") Then
            dgvApplicants.Columns("Selection Status").FillWeight = 22
            dgvApplicants.Columns("Selection Status").MinimumWidth = 95
            dgvApplicants.Columns("Selection Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvApplicants.Columns("Selection Status").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        lblRosterCount.Text = String.Format("{0} Athletes", display.Rows.Count)

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

    Private Sub TxtSearchApplicant_TextChanged(sender As Object, e As EventArgs) Handles txtSearchApplicant.TextChanged
        If dgvApplicants.DataSource Is Nothing Then Return
        Dim dt As DataTable = TryCast(dgvApplicants.DataSource, DataTable)
        If dt Is Nothing Then Return

        Dim term As String = txtSearchApplicant.Text.Trim().Replace("'", "''")
        If String.IsNullOrEmpty(term) Then
            dt.DefaultView.RowFilter = ""
        Else
            dt.DefaultView.RowFilter = String.Format("[Full Name] LIKE '%{0}%' OR [Student ID] LIKE '%{0}%' OR [Selection Status] LIKE '%{0}%'", term)
        End If
        lblRosterCount.Text = String.Format("{0} Athletes", dt.DefaultView.Count)
    End Sub

    Private Sub DgvApplicants_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApplicants.CellClick
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

        lblApplicantHeader.Text = String.Format("★ Evaluating: {0} ({1})", fullName, studentNum)

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

    Private Sub AnyScore_Changed(sender As Object, e As EventArgs) Handles numSkill.ValueChanged, numSpeed.ValueChanged, numAgility.ValueChanged, numEndurance.ValueChanged, numTeamwork.ValueChanged, numDiscipline.ValueChanged, numOverall.ValueChanged
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
            lblFinalScoreValue.ForeColor = Color.FromArgb(22, 163, 74)
            pnlScoreBanner.BackColor = Color.FromArgb(240, 253, 244)
        ElseIf score > 0 Then
            lblFinalScoreValue.ForeColor = Color.FromArgb(217, 119, 6)
            pnlScoreBanner.BackColor = Color.FromArgb(254, 252, 232)
        Else
            lblFinalScoreValue.ForeColor = Color.FromArgb(37, 99, 235)
            pnlScoreBanner.BackColor = Color.FromArgb(239, 246, 255)
        End If
    End Sub

    ' ========================================================
    '  DATA GRID FORMATTING (VISUAL BADGES)
    ' ========================================================

    Private Sub DgvApplicants_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If dgvApplicants.Columns Is Nothing OrElse e.ColumnIndex >= dgvApplicants.Columns.Count Then Return
            Dim col = dgvApplicants.Columns(e.ColumnIndex)
            If col Is Nothing OrElse e.Value Is Nothing Then Return

            Dim colName As String = col.Name
            If colName = "Final Score" Then
                Dim sc As Double
                If Double.TryParse(e.Value.ToString(), sc) Then
                    If sc >= AppLogic.PassingScore Then
                        e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                        e.CellStyle.Font = New Font("Segoe UI Semibold", 10.5!, FontStyle.Bold)
                    Else
                        e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6)
                    End If
                End If
            ElseIf colName = "Selection Status" Then
                Dim st As String = e.Value.ToString()
                Select Case st
                    Case "Selected"
                        e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                        e.CellStyle.Font = New Font("Segoe UI Semibold", 10.5!, FontStyle.Bold)
                    Case "Not Selected"
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38)
                    Case "For Further Evaluation"
                        e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235)
                    Case Else
                        e.CellStyle.ForeColor = Color.FromArgb(202, 138, 4)
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub DgvRankings_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If dgvRankings.Columns Is Nothing OrElse e.ColumnIndex >= dgvRankings.Columns.Count Then Return
            Dim col = dgvRankings.Columns(e.ColumnIndex)
            If col Is Nothing OrElse e.Value Is Nothing Then Return

            Dim colName As String = col.Name
            If colName = "Final Score" Then
                Dim sc As Double
                If Double.TryParse(e.Value.ToString(), sc) Then
                    If sc >= AppLogic.PassingScore Then
                        e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                        e.CellStyle.Font = New Font("Segoe UI Semibold", 10.5!, FontStyle.Bold)
                    Else
                        e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6)
                    End If
                End If
            ElseIf colName = "Qualifies (>=75)" Then
                If e.Value.ToString() = "Yes" Then
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                    e.CellStyle.Font = New Font("Segoe UI Semibold", 10.5!, FontStyle.Bold)
                Else
                    e.CellStyle.ForeColor = Color.FromArgb(148, 163, 184)
                End If
            ElseIf colName = "Selection Status" Then
                Select Case e.Value.ToString()
                    Case "Selected"
                        e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                        e.CellStyle.Font = New Font("Segoe UI Semibold", 10.5!, FontStyle.Bold)
                    Case "Not Selected"
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38)
                    Case "For Further Evaluation"
                        e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235)
                    Case Else
                        e.CellStyle.ForeColor = Color.FromArgb(202, 138, 4)
                End Select
            End If
        Catch
        End Try
    End Sub

    ' ========================================================
    '  ACTIONS & SAVING
    ' ========================================================

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If selectedRegistrationId = 0 Then
            UIHelper.ShowError("Please select an applicant from the roster first.")
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

            Try
                CType(Me.MdiParent, frmMain)?.RefreshNavMetrics()
            Catch
            End Try
        Catch ex As Exception
            UIHelper.ShowError("Failed to save evaluation & selection: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ResetDetailForm()
    End Sub

    Private Sub ResetDetailForm()
        selectedRegistrationId = 0
        lblApplicantHeader.Text = "Select an athlete on the left to evaluate or record decision."
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

    Private Sub ChkQualifiedOnly_CheckedChanged(sender As Object, e As EventArgs) Handles chkQualifiedOnly.CheckedChanged
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

        If dgvRankings.Columns.Contains("Rank") Then
            dgvRankings.Columns("Rank").FillWeight = 5
            dgvRankings.Columns("Rank").MinimumWidth = 50
            dgvRankings.Columns("Rank").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Rank").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Student ID") Then
            dgvRankings.Columns("Student ID").FillWeight = 10
            dgvRankings.Columns("Student ID").MinimumWidth = 85
            dgvRankings.Columns("Student ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Student ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Name") Then
            dgvRankings.Columns("Name").FillWeight = 16
            dgvRankings.Columns("Name").MinimumWidth = 130
        End If
        If dgvRankings.Columns.Contains("Skill") Then
            dgvRankings.Columns("Skill").FillWeight = 6
            dgvRankings.Columns("Skill").MinimumWidth = 60
            dgvRankings.Columns("Skill").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Skill").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Speed") Then
            dgvRankings.Columns("Speed").FillWeight = 6
            dgvRankings.Columns("Speed").MinimumWidth = 60
            dgvRankings.Columns("Speed").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Speed").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Agility") Then
            dgvRankings.Columns("Agility").FillWeight = 6
            dgvRankings.Columns("Agility").MinimumWidth = 60
            dgvRankings.Columns("Agility").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Agility").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Endurance") Then
            dgvRankings.Columns("Endurance").FillWeight = 8
            dgvRankings.Columns("Endurance").MinimumWidth = 85
            dgvRankings.Columns("Endurance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Endurance").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Teamwork") Then
            dgvRankings.Columns("Teamwork").FillWeight = 8
            dgvRankings.Columns("Teamwork").MinimumWidth = 85
            dgvRankings.Columns("Teamwork").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Teamwork").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Discipline") Then
            dgvRankings.Columns("Discipline").FillWeight = 9
            dgvRankings.Columns("Discipline").MinimumWidth = 90
            dgvRankings.Columns("Discipline").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Discipline").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Overall") Then
            dgvRankings.Columns("Overall").FillWeight = 7
            dgvRankings.Columns("Overall").MinimumWidth = 70
            dgvRankings.Columns("Overall").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Overall").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Final Score") Then
            dgvRankings.Columns("Final Score").FillWeight = 8
            dgvRankings.Columns("Final Score").MinimumWidth = 85
            dgvRankings.Columns("Final Score").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Final Score").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Qualifies (>=75)") Then
            dgvRankings.Columns("Qualifies (>=75)").HeaderText = "Qualifies"
            dgvRankings.Columns("Qualifies (>=75)").FillWeight = 8
            dgvRankings.Columns("Qualifies (>=75)").MinimumWidth = 75
            dgvRankings.Columns("Qualifies (>=75)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Qualifies (>=75)").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvRankings.Columns.Contains("Selection Status") Then
            dgvRankings.Columns("Selection Status").FillWeight = 11
            dgvRankings.Columns("Selection Status").MinimumWidth = 100
            dgvRankings.Columns("Selection Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvRankings.Columns("Selection Status").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        lblRankSummary.Text = String.Format("Total Ranked: {0} athlete(s)   |   Meeting Qualifying Standard (≥ {1:0}): {2}",
                                            dt.Rows.Count, AppLogic.PassingScore, qualifiedCount)
    End Sub

    Private Sub DgvRankings_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRankings.CellDoubleClick
        If e.RowIndex < 0 Then Return
        Dim regId As Integer = CInt(dgvRankings.Rows(e.RowIndex).Cells("RegistrationID").Value)
        If regId > 0 Then
            tabMain.SelectedTab = tabEval
            LoadApplicantForEditing(regId)
        End If
    End Sub

    Private Sub BtnExportRankings_Click(sender As Object, e As EventArgs) Handles btnExportRankings.Click
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
