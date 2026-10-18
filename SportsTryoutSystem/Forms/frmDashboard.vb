Imports System.Data
Imports System.Drawing.Drawing2D

''' <summary>
''' Executive Dashboard for the Sports Tryout Management System.
''' Redesigned for optimal space utilization, modern visual aesthetics,
''' and resilient layout mechanics (zero overlapping, clean responsive grid,
''' and high-impact analytics).
''' </summary>
Public Class frmDashboard

    ' ── Dynamic UI State ──
    Private ReadOnly sportBars As New List(Of SportBarRow)()
    Private maxSportCount As Integer = 0

    ' ── Operational Metrics State ──
    Private totalRegs As Integer = 0
    Private pendingCount As Integer = 0
    Private selectedCount As Integer = 0

    Public Sub New()
        InitializeComponent()
        SetupDashboardUI()
        AddHandler Me.Shown, AddressOf OnDashboardShown
    End Sub

    Private Sub SetupDashboardUI()
        ' Set user greeting
        lblWelcome.Text = "Welcome back, " & If(String.IsNullOrEmpty(SessionManager.CurrentFullName), "Administrator", SessionManager.CurrentFullName)
        lblDatePill.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")

        ' Wire up actions
        AddHandler btnRefresh.Click, AddressOf BtnRefresh_Click
        AddHandler btnRegister.Click, AddressOf BtnRegister_Click
        AddHandler btnEvaluate.Click, AddressOf BtnEvaluate_Click
        AddHandler btnSchedules.Click, AddressOf BtnSchedules_Click
        AddHandler btnUpcomingAll.Click, AddressOf BtnSchedules_Click
        AddHandler btnRecentAll.Click, AddressOf BtnApplicants_Click

        AddHandler pnlPipelineTrack.Resize, AddressOf LayoutPipelineBar
        AddHandler pnlBarsList.Resize, AddressOf LayoutSportChart
        pnlSportBody.Tag = pnlBarsList

        AddHandler dgvUpcoming.CellFormatting, AddressOf FormatStatusCell
        AddHandler dgvRecent.CellFormatting, AddressOf FormatRecentCell
    End Sub

    ' ========================================================
    '  DATA LOADING & REFRESH LOGIC
    ' ========================================================
    Public Sub LoadDashboardData()
        Try
            ' 1. Load Summary Numbers
            totalRegs = GetCountInt("SELECT COUNT(*) FROM Registrations")
            pendingCount = GetCountInt("SELECT COUNT(*) FROM Registrations WHERE SelectionStatus='Pending'")
            selectedCount = GetCountInt("SELECT COUNT(*) FROM Registrations WHERE SelectionStatus='Selected'")
            Dim evaluatedCount As Integer = GetCountInt("SELECT COUNT(DISTINCT r.StudentID) FROM Evaluations e INNER JOIN Registrations r ON e.RegistrationID = r.RegistrationID")
            Dim upcomingSessions As Integer = GetCountInt("SELECT COUNT(*) FROM Schedules WHERE Status='Upcoming'")
            Dim activeSportsCount As Integer = GetCountInt("SELECT COUNT(*) FROM Sports WHERE IsActive=1")

            ' Update Banner Pills
            lblPendingPill.Text = String.Format("● {0} Pending Decisions", pendingCount)
            lblSelectedPill.Text = String.Format("✓ {0} Selected", selectedCount)

            ' 2. Load KPI Cards
            LoadKpiCards(totalRegs, upcomingSessions, evaluatedCount, selectedCount, pendingCount, activeSportsCount)

            ' 3. Load Pipeline Status & Benchmark
            LoadPipelineData(totalRegs)

            ' 4. Load Sports Breakdown
            LoadSportsChartData()

            ' 5. Load Grids
            LoadUpcomingGridData()
            LoadRecentGridData()

        Catch ex As Exception
            UIHelper.ShowError("Error loading dashboard metrics: " & ex.Message)
        End Try
    End Sub

    ' ── KPI Strip Population ──
    Private Sub LoadKpiCards(total As Integer, upcoming As Integer, evaluated As Integer, selected As Integer, pending As Integer, activeSports As Integer)
        tlpKpi.Controls.Clear()

        Dim evalRate As String = If(total > 0, String.Format("{0}% of total", CInt(Math.Round(evaluated * 100.0 / total))), "0% of total")
        Dim selectRate As String = If(total > 0, String.Format("{0}% success rate", CInt(Math.Round(selected * 100.0 / total))), "0% rate")
        Dim pendingRate As String = If(total > 0, String.Format("{0}% awaiting", CInt(Math.Round(pending * 100.0 / total))), "0% awaiting")

        Dim cardsData = New List(Of Tuple(Of String, Integer, Color, String, String)) From {
            Tuple.Create("Total Applicants", total, UIHelper.ColorPrimaryDark, "[Athletes]", "All registered"),
            Tuple.Create("Upcoming Tryouts", upcoming, UIHelper.ColorGold, "[Sessions]", "Scheduled sessions"),
            Tuple.Create("Evaluated", evaluated, UIHelper.ColorPrimary, "[Evaluated]", evalRate),
            Tuple.Create("Selected Athletes", selected, UIHelper.ColorSuccess, "[Selected]", selectRate),
            Tuple.Create("Pending Decisions", pending, UIHelper.ColorGoldDark, "[Pending]", pendingRate),
            Tuple.Create("Active Programs", activeSports, UIHelper.ColorAccent, "[Sports]", "Open tryouts")
        }

        For i As Integer = 0 To cardsData.Count - 1
            Dim d = cardsData(i)
            Dim kpiCard As Panel = CreateKpiTile(d.Item1, d.Item2, d.Item3, d.Item4, d.Item5)
            tlpKpi.Controls.Add(kpiCard, i, 0)
        Next
    End Sub

    Private Function CreateKpiTile(title As String, value As Integer, accentColor As Color, iconText As String, subText As String) As Panel
        Dim pnl As New DoubleBufferedPanel()
        pnl.Dock = DockStyle.Fill
        pnl.Margin = New Padding(0, 0, 8, 0)
        pnl.BackColor = Color.White
        pnl.Padding = New Padding(14, 10, 14, 10)

        ' Top Accent Strip
        Dim topStrip As New Panel()
        topStrip.Dock = DockStyle.Top
        topStrip.Height = 4
        topStrip.BackColor = accentColor
        pnl.Controls.Add(topStrip)

        ' Title Label
        Dim lblTitle As New Label()
        lblTitle.Text = title.ToUpper()
        lblTitle.Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold)
        lblTitle.ForeColor = UIHelper.ColorTextSecondary
        lblTitle.Location = New Point(12, 12)
        lblTitle.AutoSize = True
        pnl.Controls.Add(lblTitle)

        ' Value Count
        Dim lblVal As New Label()
        lblVal.Text = value.ToString("N0")
        lblVal.Font = New Font("Segoe UI Semibold", 22.0!, FontStyle.Bold)
        lblVal.ForeColor = UIHelper.ColorTextPrimary
        lblVal.Location = New Point(10, 32)
        lblVal.AutoSize = True
        pnl.Controls.Add(lblVal)

        ' Subtext / Trend
        Dim lblSub As New Label()
        lblSub.Text = subText
        lblSub.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
        lblSub.ForeColor = UIHelper.ColorTextSecondary
        lblSub.Location = New Point(12, 74)
        lblSub.AutoSize = True
        pnl.Controls.Add(lblSub)

        Return pnl
    End Function

    ' ── Pipeline Data Population ──
    Private Sub LoadPipelineData(total As Integer)
        Dim further As Integer = 0
        Dim notSelected As Integer = 0

        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT SelectionStatus, COUNT(*) AS Cnt FROM Registrations GROUP BY SelectionStatus")
            For Each row As DataRow In dt.Rows
                Dim code As String = row("SelectionStatus").ToString()
                Dim cnt As Integer = CInt(row("Cnt"))
                If code = "NotSelected" Then notSelected = cnt
                If code = "ForFurtherEvaluation" Then further = cnt
            Next
        Catch
        End Try

        Dim decided As Integer = selectedCount + notSelected + further

        ' 1. Legend
        pnlPipelineLegend.Controls.Clear()
        pnlPipelineLegend.Controls.Add(CreateLegendItem("Selected", UIHelper.ColorSuccess))
        pnlPipelineLegend.Controls.Add(CreateLegendItem("Further Eval", UIHelper.ColorAccent))
        pnlPipelineLegend.Controls.Add(CreateLegendItem("Not Selected", UIHelper.ColorDanger))
        pnlPipelineLegend.Controls.Add(CreateLegendItem("Pending", UIHelper.ColorGold))

        ' 2. Segments Data Tag
        pnlPipelineTrack.Tag = New Integer() {selectedCount, further, notSelected, pendingCount, total}

        ' 3. Tiles
        tlpPipeTiles.Controls.Clear()
        Dim pctSelected As Integer = If(total > 0, CInt(Math.Round(selectedCount * 100.0 / total)), 0)
        Dim pctFurther As Integer = If(total > 0, CInt(Math.Round(further * 100.0 / total)), 0)
        Dim pctNotSelected As Integer = If(total > 0, CInt(Math.Round(notSelected * 100.0 / total)), 0)
        Dim pctPending As Integer = If(total > 0, CInt(Math.Round(pendingCount * 100.0 / total)), 0)

        tlpPipeTiles.Controls.Add(CreatePipeTile("SELECTED", selectedCount, pctSelected, UIHelper.ColorSuccess, "Qualified for team"), 0, 0)
        tlpPipeTiles.Controls.Add(CreatePipeTile("FURTHER EVAL", further, pctFurther, UIHelper.ColorAccent, "Callbacks / re-tests"), 1, 0)
        tlpPipeTiles.Controls.Add(CreatePipeTile("NOT SELECTED", notSelected, pctNotSelected, UIHelper.ColorDanger, "Did not qualify"), 2, 0)
        tlpPipeTiles.Controls.Add(CreatePipeTile("PENDING", pendingCount, pctPending, UIHelper.ColorGold, "Awaiting review"), 3, 0)

        ' 4. Performance Benchmarks
        pnlBenchmarkFooter.Controls.Clear()
        Dim avgScoreStr As String = "--"
        Dim topScoreStr As String = "--"
        Dim evalCount As Integer = 0
        Try
            Dim avgObj = DatabaseHelper.ExecuteScalar("SELECT AVG(FinalScore) FROM Evaluations")
            If avgObj IsNot Nothing AndAlso Not IsDBNull(avgObj) Then
                avgScoreStr = CDbl(avgObj).ToString("0.0") & " / 100"
            End If
            Dim topObj = DatabaseHelper.ExecuteScalar("SELECT MAX(FinalScore) FROM Evaluations")
            If topObj IsNot Nothing AndAlso Not IsDBNull(topObj) Then
                topScoreStr = CDbl(topObj).ToString("0.0") & " / 100"
            End If
            evalCount = GetCountInt("SELECT COUNT(*) FROM Evaluations")
        Catch
        End Try

        Dim lblBench As New Label()
        lblBench.Dock = DockStyle.Fill
        lblBench.Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold)
        lblBench.ForeColor = UIHelper.ColorTextPrimary
        lblBench.TextAlign = ContentAlignment.MiddleLeft
        lblBench.Text = String.Format("📊 Avg Score: {0}   |   🏆 Top Score: {1}   |   🎯 Passing Threshold: {2:0.0}   |   Evaluated: {3} of {4}",
                                      avgScoreStr, topScoreStr, AppLogic.PassingScore, evalCount, total)
        pnlBenchmarkFooter.Controls.Add(lblBench)

        ' 5. Progress Fill
        Dim progressPct As Integer = If(total > 0, CInt(Math.Round(decided * 100.0 / total)), 0)
        progressPct = Math.Max(0, Math.Min(100, progressPct))
        lblDecisionProgress.Text = String.Format("{0} of {1} decisions completed ({2}% completed)", decided, total, progressPct)

        LayoutPipelineBar()
    End Sub

    Private Function CreateLegendItem(text As String, col As Color) As Panel
        Dim p As New Panel()
        p.AutoSize = True
        p.Height = 22
        p.Margin = New Padding(0, 0, 16, 0)

        Dim dot As New Panel()
        dot.Size = New Size(12, 12)
        dot.Location = New Point(0, 5)
        dot.BackColor = col
        p.Controls.Add(dot)

        Dim lbl As New Label()
        lbl.Text = text
        lbl.Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold)
        lbl.ForeColor = UIHelper.ColorTextSecondary
        lbl.Location = New Point(16, 2)
        lbl.AutoSize = True
        p.Controls.Add(lbl)

        Return p
    End Function

    Private Function CreatePipeTile(label As String, count As Integer, pct As Integer, col As Color, hint As String) As Panel
        Dim p As New DoubleBufferedPanel()
        p.Dock = DockStyle.Fill
        p.Margin = New Padding(0, 4, 8, 4)
        p.BackColor = Color.FromArgb(248, 250, 252)
        p.Padding = New Padding(10, 6, 10, 6)

        Dim lTop As New Label()
        lTop.Text = label
        lTop.Font = New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold)
        lTop.ForeColor = col
        lTop.Location = New Point(8, 6)
        lTop.AutoSize = True
        p.Controls.Add(lTop)

        Dim lVal As New Label()
        lVal.Text = String.Format("{0} ({1}%)", count, pct)
        lVal.Font = New Font("Segoe UI Semibold", 12.0!, FontStyle.Bold)
        lVal.ForeColor = UIHelper.ColorTextPrimary
        lVal.Location = New Point(7, 24)
        lVal.AutoSize = True
        p.Controls.Add(lVal)

        Dim lHint As New Label()
        lHint.Text = hint
        lHint.Font = New Font("Segoe UI", 7.5!, FontStyle.Regular)
        lHint.ForeColor = UIHelper.ColorTextSecondary
        lHint.Location = New Point(8, 50)
        lHint.AutoSize = True
        p.Controls.Add(lHint)

        Return p
    End Function

    Private Sub LayoutPipelineBar(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing)
        If pnlPipelineTrack Is Nothing OrElse pnlPipelineTrack.Tag Is Nothing Then Return
        Dim data = DirectCast(pnlPipelineTrack.Tag, Integer())
        Dim sel As Integer = data(0)
        Dim fur As Integer = data(1)
        Dim notSel As Integer = data(2)
        Dim pend As Integer = data(3)
        Dim total As Integer = data(4)

        pnlPipelineTrack.Controls.Clear()
        If total <= 0 Then Return

        Dim trackW As Integer = pnlPipelineTrack.ClientSize.Width
        Dim trackH As Integer = pnlPipelineTrack.ClientSize.Height

        Dim wSel As Integer = CInt(Math.Round(trackW * (sel / CDbl(total))))
        Dim wFur As Integer = CInt(Math.Round(trackW * (fur / CDbl(total))))
        Dim wNot As Integer = CInt(Math.Round(trackW * (notSel / CDbl(total))))
        Dim wPend As Integer = trackW - wSel - wFur - wNot
        If wPend < 0 Then wPend = 0

        Dim curX As Integer = 0
        Dim segs = New Tuple(Of Integer, Color)() {
            Tuple.Create(wSel, UIHelper.ColorSuccess),
            Tuple.Create(wFur, UIHelper.ColorAccent),
            Tuple.Create(wNot, UIHelper.ColorDanger),
            Tuple.Create(wPend, UIHelper.ColorGold)
        }

        For Each seg In segs
            If seg.Item1 > 0 Then
                Dim p As New Panel()
                p.SetBounds(curX, 0, seg.Item1, trackH)
                p.BackColor = seg.Item2
                pnlPipelineTrack.Controls.Add(p)
                curX += seg.Item1
            End If
        Next
    End Sub

    ' ── Sports Breakdown Data Population ──
    Private Sub LoadSportsChartData()
        If pnlBarsList Is Nothing Then Return

        pnlBarsList.Controls.Clear()
        sportBars.Clear()

        Dim dt As DataTable = DatabaseHelper.GetDataTable(
            "SELECT sp.SportName, COUNT(r.RegistrationID) AS RegCount " &
            "FROM Sports sp " &
            "LEFT JOIN Registrations r ON r.SportID = sp.SportID " &
            "WHERE sp.IsActive = 1 " &
            "GROUP BY sp.SportID, sp.SportName " &
            "ORDER BY RegCount DESC, sp.SportName ASC")

        maxSportCount = 0
        Dim totalProgramRegs As Integer = 0
        For Each row As DataRow In dt.Rows
            Dim cnt As Integer = CInt(row("RegCount"))
            If cnt > maxSportCount Then maxSportCount = cnt
            totalProgramRegs += cnt
        Next

        Dim colors As Color() = {
            UIHelper.ColorPrimary,
            UIHelper.ColorAccent,
            UIHelper.ColorGoldDark,
            UIHelper.ColorSuccess,
            Color.FromArgb(147, 51, 234),
            Color.FromArgb(13, 148, 136),
            Color.FromArgb(225, 29, 72)
        }

        Dim colorIdx As Integer = 0
        For Each row As DataRow In dt.Rows
            Dim sName As String = row("SportName").ToString()
            Dim sCount As Integer = CInt(row("RegCount"))
            Dim pct As Integer = If(totalProgramRegs > 0, CInt(Math.Round(sCount * 100.0 / totalProgramRegs)), 0)

            Dim rowContainer As New Panel()

            Dim lblName As New Label()
            lblName.Text = sName
            lblName.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
            lblName.ForeColor = UIHelper.ColorTextPrimary
            lblName.TextAlign = ContentAlignment.MiddleLeft
            rowContainer.Controls.Add(lblName)

            Dim pTrack As New Panel()
            pTrack.BackColor = Color.FromArgb(241, 245, 249)
            rowContainer.Controls.Add(pTrack)

            Dim pFill As New Panel()
            pFill.BackColor = colors(colorIdx Mod colors.Length)
            pTrack.Controls.Add(pFill)

            Dim lblCount As New Label()
            lblCount.Text = String.Format("{0} ({1}%)", sCount, pct)
            lblCount.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
            lblCount.ForeColor = UIHelper.ColorTextSecondary
            lblCount.TextAlign = ContentAlignment.MiddleRight
            rowContainer.Controls.Add(lblCount)

            pnlBarsList.Controls.Add(rowContainer)

            Dim barRow As New SportBarRow()
            barRow.Container = rowContainer
            barRow.LblName = lblName
            barRow.PnlTrack = pTrack
            barRow.PnlFill = pFill
            barRow.LblCount = lblCount
            barRow.SportName = sName
            barRow.Count = sCount
            sportBars.Add(barRow)

            colorIdx += 1
        Next

        Dim topSportName As String = If(dt.Rows.Count > 0, dt.Rows(0)("SportName").ToString(), "N/A")
        Dim topSportCount As Integer = If(dt.Rows.Count > 0, CInt(dt.Rows(0)("RegCount")), 0)
        Dim avgPerSport As Double = If(dt.Rows.Count > 0, Math.Round(totalProgramRegs / CDbl(dt.Rows.Count), 1), 0.0)

        lblSportSummary.Text = String.Format("Top Sport: {0} ({1} athletes)   |   Programs: {2}   |   Avg / Sport: {3}",
                                             topSportName, topSportCount, dt.Rows.Count, avgPerSport)

        LayoutSportChart()
    End Sub

    Private Sub LayoutSportChart(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing)
        If pnlBarsList Is Nothing OrElse sportBars.Count = 0 Then Return

        Dim w As Integer = pnlBarsList.ClientSize.Width
        Dim nameW As Integer = 150
        Dim countW As Integer = 105
        Dim trackW As Integer = Math.Max(40, w - nameW - countW - 18)
        Dim y As Integer = 4

        For Each row As SportBarRow In sportBars
            row.Container.SetBounds(0, y, w, 34)
            row.LblName.SetBounds(0, 4, nameW, 26)
            row.PnlTrack.SetBounds(nameW, 9, trackW, 16)

            Dim fillW As Integer = 0
            If row.Count > 0 AndAlso maxSportCount > 0 Then
                fillW = Math.Max(8, CInt(Math.Round(trackW * (row.Count / CDbl(maxSportCount)))))
            End If
            row.PnlFill.SetBounds(0, 0, fillW, 16)
            row.LblCount.SetBounds(nameW + trackW + 8, 4, countW, 26)

            y += 38
        Next
    End Sub

    ' ── Upcoming Tryouts Data ──
    Private Sub LoadUpcomingGridData()
        Dim dt As New DataTable()
        Try
            dt = DatabaseHelper.GetDataTable(
                "SELECT sp.SportName AS Sport, sc.TryoutDate AS [Date], sc.TryoutTime AS [Time], sc.Venue, sc.Status " &
                "FROM Schedules sc INNER JOIN Sports sp ON sp.SportID = sc.SportID " &
                "WHERE sc.Status = 'Upcoming' ORDER BY sc.TryoutDate, sc.TryoutTime LIMIT 10")
        Catch
        End Try

        dgvUpcoming.DataSource = dt
        Dim isEmpty As Boolean = (dt Is Nothing OrElse dt.Rows.Count = 0)
        dgvUpcoming.Visible = Not isEmpty
        lblUpcomingEmpty.Visible = isEmpty

        If Not isEmpty AndAlso dgvUpcoming.Columns.Count >= 5 Then
            dgvUpcoming.Columns("Sport").FillWeight = 24
            dgvUpcoming.Columns("Date").FillWeight = 20
            dgvUpcoming.Columns("Time").FillWeight = 16
            dgvUpcoming.Columns("Venue").FillWeight = 26
            dgvUpcoming.Columns("Status").FillWeight = 14
        End If
    End Sub

    ' ── Recent Registrations Data ──
    Private Sub LoadRecentGridData()
        Dim dt As New DataTable()
        Try
            dt = DatabaseHelper.GetDataTable(
                "SELECT CONCAT(s.FirstName, ' ', s.LastName) AS Student, sp.SportName AS Sport, " &
                "r.RegistrationDate AS [Registered], r.SelectionStatus AS Status " &
                "FROM Registrations r " &
                "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                "ORDER BY r.RegistrationDate DESC LIMIT 10")
        Catch
        End Try

        dgvRecent.DataSource = dt
        Dim isEmpty As Boolean = (dt Is Nothing OrElse dt.Rows.Count = 0)
        dgvRecent.Visible = Not isEmpty
        lblRecentEmpty.Visible = isEmpty

        If Not isEmpty AndAlso dgvRecent.Columns.Count >= 4 Then
            dgvRecent.Columns("Student").FillWeight = 32
            dgvRecent.Columns("Sport").FillWeight = 22
            dgvRecent.Columns("Registered").FillWeight = 26
            dgvRecent.Columns("Status").FillWeight = 20
        End If
    End Sub

    ' ── Grid Cell Formatting ──
    Private Sub FormatStatusCell(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            Dim dgv = DirectCast(sender, DataGridView)
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If dgv.Columns Is Nothing OrElse e.ColumnIndex >= dgv.Columns.Count Then Return
            Dim col = dgv.Columns(e.ColumnIndex)
            If col Is Nothing OrElse col.Name <> "Status" Then Return
            Dim v As String = If(e.Value, "").ToString()
            If v = "Upcoming" Then
                e.CellStyle.ForeColor = UIHelper.ColorSuccess
                e.CellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
            End If
        Catch
        End Try
    End Sub

    Private Sub FormatRecentCell(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            Dim dgv = DirectCast(sender, DataGridView)
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If dgv.Columns Is Nothing OrElse e.ColumnIndex >= dgv.Columns.Count Then Return
            Dim col = dgv.Columns(e.ColumnIndex)
            If col Is Nothing Then Return
            Dim colName As String = col.Name

            If colName = "Registered" AndAlso TypeOf e.Value Is Date Then
                e.Value = CDate(e.Value).ToString("MMM dd, yyyy hh:mm tt")
                e.FormattingApplied = True
            ElseIf colName = "Status" Then
                Dim v As String = If(e.Value, "").ToString()
                If v.Length > 0 Then
                    e.Value = AppLogic.DisplaySelectionStatus(v)
                    e.FormattingApplied = True
                    Select Case v
                        Case "Selected"
                            e.CellStyle.ForeColor = UIHelper.ColorSuccess
                            e.CellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
                        Case "Pending"
                            e.CellStyle.ForeColor = UIHelper.ColorGoldDark
                            e.CellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
                        Case "NotSelected"
                            e.CellStyle.ForeColor = UIHelper.ColorDanger
                        Case "ForFurtherEvaluation"
                            e.CellStyle.ForeColor = UIHelper.ColorAccent
                            e.CellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
                    End Select
                End If
            End If
        Catch
        End Try
    End Sub

    ' ========================================================
    '  ACTIONS & NAVIGATION
    ' ========================================================
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs)
        LoadDashboardData()
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs)
        NavigateTo(GetType(frmStudentRegistration))
    End Sub

    Private Sub BtnEvaluate_Click(sender As Object, e As EventArgs)
        NavigateTo(GetType(frmEvaluationSelection))
    End Sub

    Private Sub BtnSchedules_Click(sender As Object, e As EventArgs)
        NavigateTo(GetType(frmScheduleManagement))
    End Sub

    Private Sub BtnApplicants_Click(sender As Object, e As EventArgs)
        NavigateTo(GetType(frmApplicantRecords))
    End Sub

    Private Sub NavigateTo(formType As Type)
        Dim mainForm = TryCast(Me.MdiParent, frmMain)
        If mainForm Is Nothing Then Return
        Try
            Dim targetForm As Form = DirectCast(Activator.CreateInstance(formType), Form)
            mainForm.OpenChild(targetForm)
        Catch ex As Exception
            UIHelper.ShowError("Could not open form: " & ex.Message)
        End Try
    End Sub

    Private Function GetCountInt(sql As String) As Integer
        Try
            Dim result As Object = DatabaseHelper.ExecuteScalar(sql)
            If result Is Nothing OrElse IsDBNull(result) Then Return 0
            Return CInt(result)
        Catch
            Return 0
        End Try
    End Function

    Private Sub OnDashboardShown(sender As Object, e As EventArgs)
        LoadDashboardData()
        LayoutPipelineBar()
        LayoutSportChart()
    End Sub

End Class
