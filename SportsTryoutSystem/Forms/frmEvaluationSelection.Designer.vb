<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEvaluationSelection
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim dataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim dataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.filterAccent = New System.Windows.Forms.Panel()
        Me.lblSport = New System.Windows.Forms.Label()
        Me.cmbFilterSport = New System.Windows.Forms.ComboBox()
        Me.lblStats = New System.Windows.Forms.Label()

        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabEval = New System.Windows.Forms.TabPage()
        Me.pnlContainer = New System.Windows.Forms.Panel()

        Me.pnlRosterCard = New System.Windows.Forms.Panel()
        Me.rosterAccent = New System.Windows.Forms.Panel()
        Me.lblGridTitle = New System.Windows.Forms.Label()
        Me.lblRosterCount = New System.Windows.Forms.Label()
        Me.txtSearchApplicant = New System.Windows.Forms.TextBox()
        Me.dgvApplicants = New System.Windows.Forms.DataGridView()

        Me.pnlCard = New System.Windows.Forms.Panel()
        Me.cardAccent = New System.Windows.Forms.Panel()
        Me.lblApplicantHeader = New System.Windows.Forms.Label()
        Me.lblApplicantSub = New System.Windows.Forms.Label()
        Me.div1 = New System.Windows.Forms.Panel()
        Me.lblCriteriaHeader = New System.Windows.Forms.Label()
        Me.lblSkill = New System.Windows.Forms.Label()
        Me.numSkill = New System.Windows.Forms.NumericUpDown()
        Me.lblSpeed = New System.Windows.Forms.Label()
        Me.numSpeed = New System.Windows.Forms.NumericUpDown()
        Me.lblAgility = New System.Windows.Forms.Label()
        Me.numAgility = New System.Windows.Forms.NumericUpDown()
        Me.lblEndurance = New System.Windows.Forms.Label()
        Me.numEndurance = New System.Windows.Forms.NumericUpDown()
        Me.lblTeamwork = New System.Windows.Forms.Label()
        Me.numTeamwork = New System.Windows.Forms.NumericUpDown()
        Me.lblDiscipline = New System.Windows.Forms.Label()
        Me.numDiscipline = New System.Windows.Forms.NumericUpDown()
        Me.lblOverall = New System.Windows.Forms.Label()
        Me.numOverall = New System.Windows.Forms.NumericUpDown()
        Me.lblScaleHint = New System.Windows.Forms.Label()

        Me.pnlScoreBanner = New System.Windows.Forms.Panel()
        Me.lblFinalTitle = New System.Windows.Forms.Label()
        Me.lblPassingStandard = New System.Windows.Forms.Label()
        Me.lblFinalScoreValue = New System.Windows.Forms.Label()

        Me.div2 = New System.Windows.Forms.Panel()
        Me.lblDecisionTitle = New System.Windows.Forms.Label()
        Me.cmbDecision = New System.Windows.Forms.ComboBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()

        Me.tabRankings = New System.Windows.Forms.TabPage()
        Me.pnlRankings = New System.Windows.Forms.Panel()
        Me.pnlRankCard = New System.Windows.Forms.Panel()
        Me.rankAccent = New System.Windows.Forms.Panel()
        Me.lblBoardTitle = New System.Windows.Forms.Label()
        Me.chkQualifiedOnly = New System.Windows.Forms.CheckBox()
        Me.btnExportRankings = New System.Windows.Forms.Button()
        Me.lblRankSummary = New System.Windows.Forms.Label()
        Me.dgvRankings = New System.Windows.Forms.DataGridView()

        Me.pnlFilter.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabEval.SuspendLayout()
        Me.pnlContainer.SuspendLayout()
        Me.pnlRosterCard.SuspendLayout()
        CType(Me.dgvApplicants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCard.SuspendLayout()
        CType(Me.numSkill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAgility, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numEndurance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTeamwork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDiscipline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOverall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlScoreBanner.SuspendLayout()
        Me.tabRankings.SuspendLayout()
        Me.pnlRankings.SuspendLayout()
        Me.pnlRankCard.SuspendLayout()
        CType(Me.dgvRankings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlFilter
        '
        Me.pnlFilter.BackColor = System.Drawing.Color.White
        Me.pnlFilter.Controls.Add(Me.filterAccent)
        Me.pnlFilter.Controls.Add(Me.lblSport)
        Me.pnlFilter.Controls.Add(Me.cmbFilterSport)
        Me.pnlFilter.Controls.Add(Me.lblStats)
        Me.pnlFilter.Location = New System.Drawing.Point(24, 72)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(1150, 64)
        Me.pnlFilter.TabIndex = 0
        '
        'filterAccent
        '
        Me.filterAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.filterAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.filterAccent.Location = New System.Drawing.Point(0, 0)
        Me.filterAccent.Name = "filterAccent"
        Me.filterAccent.Size = New System.Drawing.Size(1150, 4)
        Me.filterAccent.TabIndex = 0
        '
        'lblSport
        '
        Me.lblSport.AutoSize = True
        Me.lblSport.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSport.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblSport.Location = New System.Drawing.Point(20, 24)
        Me.lblSport.Name = "lblSport"
        Me.lblSport.Size = New System.Drawing.Size(95, 15)
        Me.lblSport.TabIndex = 1
        Me.lblSport.Text = "🏅 SELECT SPORT:"
        '
        'cmbFilterSport
        '
        Me.cmbFilterSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterSport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterSport.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbFilterSport.FormattingEnabled = True
        Me.cmbFilterSport.Location = New System.Drawing.Point(125, 20)
        Me.cmbFilterSport.Name = "cmbFilterSport"
        Me.cmbFilterSport.Size = New System.Drawing.Size(260, 25)
        Me.cmbFilterSport.TabIndex = 2
        '
        'lblStats
        '
        Me.lblStats.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblStats.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblStats.Location = New System.Drawing.Point(405, 18)
        Me.lblStats.Name = "lblStats"
        Me.lblStats.Size = New System.Drawing.Size(720, 28)
        Me.lblStats.TabIndex = 3
        Me.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabEval)
        Me.tabMain.Controls.Add(Me.tabRankings)
        Me.tabMain.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.tabMain.Location = New System.Drawing.Point(24, 146)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Drawing.Point(18, 10)
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1150, 560)
        Me.tabMain.TabIndex = 1
        '
        'tabEval
        '
        Me.tabEval.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.tabEval.Controls.Add(Me.pnlContainer)
        Me.tabEval.Location = New System.Drawing.Point(4, 40)
        Me.tabEval.Name = "tabEval"
        Me.tabEval.Padding = New System.Windows.Forms.Padding(6)
        Me.tabEval.Size = New System.Drawing.Size(1142, 516)
        Me.tabEval.TabIndex = 0
        Me.tabEval.Text = "  1. Athlete Evaluation & Selection  "
        '
        'pnlContainer
        '
        Me.pnlContainer.Controls.Add(Me.pnlRosterCard)
        Me.pnlContainer.Controls.Add(Me.pnlCard)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(6, 6)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(1130, 504)
        Me.pnlContainer.TabIndex = 0
        '
        'pnlRosterCard (Left: Athlete Roster Card)
        '
        Me.pnlRosterCard.BackColor = System.Drawing.Color.White
        Me.pnlRosterCard.Controls.Add(Me.rosterAccent)
        Me.pnlRosterCard.Controls.Add(Me.lblGridTitle)
        Me.pnlRosterCard.Controls.Add(Me.lblRosterCount)
        Me.pnlRosterCard.Controls.Add(Me.txtSearchApplicant)
        Me.pnlRosterCard.Controls.Add(Me.dgvApplicants)
        Me.pnlRosterCard.Location = New System.Drawing.Point(10, 10)
        Me.pnlRosterCard.Name = "pnlRosterCard"
        Me.pnlRosterCard.Size = New System.Drawing.Size(480, 484)
        Me.pnlRosterCard.TabIndex = 0
        '
        'rosterAccent
        '
        Me.rosterAccent.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.rosterAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.rosterAccent.Location = New System.Drawing.Point(0, 0)
        Me.rosterAccent.Name = "rosterAccent"
        Me.rosterAccent.Size = New System.Drawing.Size(480, 4)
        Me.rosterAccent.TabIndex = 0
        '
        'lblGridTitle
        '
        Me.lblGridTitle.AutoSize = True
        Me.lblGridTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblGridTitle.Location = New System.Drawing.Point(16, 14)
        Me.lblGridTitle.Name = "lblGridTitle"
        Me.lblGridTitle.Size = New System.Drawing.Size(170, 21)
        Me.lblGridTitle.TabIndex = 1
        Me.lblGridTitle.Text = "📋 Registered Athletes"
        '
        'lblRosterCount
        '
        Me.lblRosterCount.AutoSize = True
        Me.lblRosterCount.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.lblRosterCount.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblRosterCount.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblRosterCount.Location = New System.Drawing.Point(195, 18)
        Me.lblRosterCount.Name = "lblRosterCount"
        Me.lblRosterCount.Size = New System.Drawing.Size(60, 15)
        Me.lblRosterCount.TabIndex = 2
        Me.lblRosterCount.Text = "0 Athletes"
        '
        'txtSearchApplicant
        '
        Me.txtSearchApplicant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchApplicant.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtSearchApplicant.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.txtSearchApplicant.Location = New System.Drawing.Point(280, 14)
        Me.txtSearchApplicant.Name = "txtSearchApplicant"
        Me.txtSearchApplicant.Size = New System.Drawing.Size(184, 24)
        Me.txtSearchApplicant.TabIndex = 3
        '
        'dgvApplicants
        '
        Me.dgvApplicants.AllowUserToAddRows = False
        Me.dgvApplicants.AllowUserToDeleteRows = False
        Me.dgvApplicants.AllowUserToResizeRows = False
        Me.dgvApplicants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvApplicants.BackgroundColor = System.Drawing.Color.White
        Me.dgvApplicants.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvApplicants.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvApplicants.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(253, 224, 71)
        dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApplicants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
        Me.dgvApplicants.ColumnHeadersHeight = 38
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        dataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254)
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvApplicants.DefaultCellStyle = dataGridViewCellStyle2
        Me.dgvApplicants.EnableHeadersVisualStyles = False
        Me.dgvApplicants.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgvApplicants.Location = New System.Drawing.Point(16, 48)
        Me.dgvApplicants.MultiSelect = False
        Me.dgvApplicants.Name = "dgvApplicants"
        Me.dgvApplicants.ReadOnly = True
        Me.dgvApplicants.RowHeadersVisible = False
        Me.dgvApplicants.RowTemplate.Height = 36
        Me.dgvApplicants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvApplicants.Size = New System.Drawing.Size(448, 420)
        Me.dgvApplicants.TabIndex = 4
        '
        'pnlCard (Right: Scoring & Decision Card)
        '
        Me.pnlCard.AutoScroll = True
        Me.pnlCard.BackColor = System.Drawing.Color.White
        Me.pnlCard.Controls.Add(Me.cardAccent)
        Me.pnlCard.Controls.Add(Me.lblApplicantHeader)
        Me.pnlCard.Controls.Add(Me.lblApplicantSub)
        Me.pnlCard.Controls.Add(Me.div1)
        Me.pnlCard.Controls.Add(Me.lblCriteriaHeader)
        Me.pnlCard.Controls.Add(Me.lblSkill)
        Me.pnlCard.Controls.Add(Me.numSkill)
        Me.pnlCard.Controls.Add(Me.lblSpeed)
        Me.pnlCard.Controls.Add(Me.numSpeed)
        Me.pnlCard.Controls.Add(Me.lblAgility)
        Me.pnlCard.Controls.Add(Me.numAgility)
        Me.pnlCard.Controls.Add(Me.lblEndurance)
        Me.pnlCard.Controls.Add(Me.numEndurance)
        Me.pnlCard.Controls.Add(Me.lblTeamwork)
        Me.pnlCard.Controls.Add(Me.numTeamwork)
        Me.pnlCard.Controls.Add(Me.lblDiscipline)
        Me.pnlCard.Controls.Add(Me.numDiscipline)
        Me.pnlCard.Controls.Add(Me.lblOverall)
        Me.pnlCard.Controls.Add(Me.numOverall)
        Me.pnlCard.Controls.Add(Me.lblScaleHint)
        Me.pnlCard.Controls.Add(Me.pnlScoreBanner)
        Me.pnlCard.Controls.Add(Me.div2)
        Me.pnlCard.Controls.Add(Me.lblDecisionTitle)
        Me.pnlCard.Controls.Add(Me.cmbDecision)
        Me.pnlCard.Controls.Add(Me.lblRemarks)
        Me.pnlCard.Controls.Add(Me.txtRemarks)
        Me.pnlCard.Controls.Add(Me.btnSave)
        Me.pnlCard.Controls.Add(Me.btnClear)
        Me.pnlCard.Location = New System.Drawing.Point(510, 10)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New System.Drawing.Size(610, 484)
        Me.pnlCard.TabIndex = 1
        '
        'cardAccent
        '
        Me.cardAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.cardAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAccent.Location = New System.Drawing.Point(0, 0)
        Me.cardAccent.Name = "cardAccent"
        Me.cardAccent.Size = New System.Drawing.Size(610, 4)
        Me.cardAccent.TabIndex = 0
        '
        'lblApplicantHeader
        '
        Me.lblApplicantHeader.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblApplicantHeader.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblApplicantHeader.Location = New System.Drawing.Point(20, 14)
        Me.lblApplicantHeader.Name = "lblApplicantHeader"
        Me.lblApplicantHeader.Size = New System.Drawing.Size(570, 26)
        Me.lblApplicantHeader.TabIndex = 1
        Me.lblApplicantHeader.Text = "Select an athlete on the left to evaluate or record decision."
        '
        'lblApplicantSub
        '
        Me.lblApplicantSub.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblApplicantSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblApplicantSub.Location = New System.Drawing.Point(22, 40)
        Me.lblApplicantSub.Name = "lblApplicantSub"
        Me.lblApplicantSub.Size = New System.Drawing.Size(566, 18)
        Me.lblApplicantSub.TabIndex = 2
        Me.lblApplicantSub.Text = "Score tryout drills on a scale of 0 to 100. System automatically computes weighted composite."
        '
        'div1
        '
        Me.div1.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.div1.Location = New System.Drawing.Point(20, 62)
        Me.div1.Name = "div1"
        Me.div1.Size = New System.Drawing.Size(570, 1)
        Me.div1.TabIndex = 3
        '
        'lblCriteriaHeader
        '
        Me.lblCriteriaHeader.AutoSize = True
        Me.lblCriteriaHeader.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblCriteriaHeader.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblCriteriaHeader.Location = New System.Drawing.Point(20, 70)
        Me.lblCriteriaHeader.Name = "lblCriteriaHeader"
        Me.lblCriteriaHeader.Size = New System.Drawing.Size(262, 17)
        Me.lblCriteriaHeader.TabIndex = 4
        Me.lblCriteriaHeader.Text = "TRYOUT PERFORMANCE METRICS (0 - 100)"
        '
        'lblSkill
        '
        Me.lblSkill.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSkill.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblSkill.Location = New System.Drawing.Point(20, 98)
        Me.lblSkill.Name = "lblSkill"
        Me.lblSkill.Size = New System.Drawing.Size(160, 22)
        Me.lblSkill.TabIndex = 5
        Me.lblSkill.Text = "🎯 Skill & Technique"
        '
        'numSkill
        '
        Me.numSkill.DecimalPlaces = 1
        Me.numSkill.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.numSkill.Location = New System.Drawing.Point(190, 96)
        Me.numSkill.Name = "numSkill"
        Me.numSkill.Size = New System.Drawing.Size(90, 26)
        Me.numSkill.TabIndex = 6
        Me.numSkill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTeamwork
        '
        Me.lblTeamwork.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblTeamwork.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblTeamwork.Location = New System.Drawing.Point(310, 98)
        Me.lblTeamwork.Name = "lblTeamwork"
        Me.lblTeamwork.Size = New System.Drawing.Size(160, 22)
        Me.lblTeamwork.TabIndex = 7
        Me.lblTeamwork.Text = "🤝 Teamwork & Comms"
        '
        'numTeamwork
        '
        Me.numTeamwork.DecimalPlaces = 1
        Me.numTeamwork.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.numTeamwork.Location = New System.Drawing.Point(480, 96)
        Me.numTeamwork.Name = "numTeamwork"
        Me.numTeamwork.Size = New System.Drawing.Size(90, 26)
        Me.numTeamwork.TabIndex = 8
        Me.numTeamwork.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSpeed
        '
        Me.lblSpeed.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSpeed.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblSpeed.Location = New System.Drawing.Point(20, 134)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(160, 22)
        Me.lblSpeed.TabIndex = 9
        Me.lblSpeed.Text = "⚡ Speed & Acceleration"
        '
        'numSpeed
        '
        Me.numSpeed.DecimalPlaces = 1
        Me.numSpeed.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.numSpeed.Location = New System.Drawing.Point(190, 132)
        Me.numSpeed.Name = "numSpeed"
        Me.numSpeed.Size = New System.Drawing.Size(90, 26)
        Me.numSpeed.TabIndex = 10
        Me.numSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiscipline
        '
        Me.lblDiscipline.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblDiscipline.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblDiscipline.Location = New System.Drawing.Point(310, 134)
        Me.lblDiscipline.Name = "lblDiscipline"
        Me.lblDiscipline.Size = New System.Drawing.Size(160, 22)
        Me.lblDiscipline.TabIndex = 11
        Me.lblDiscipline.Text = "🛡️ Discipline & Attitude"
        '
        'numDiscipline
        '
        Me.numDiscipline.DecimalPlaces = 1
        Me.numDiscipline.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.numDiscipline.Location = New System.Drawing.Point(480, 132)
        Me.numDiscipline.Name = "numDiscipline"
        Me.numDiscipline.Size = New System.Drawing.Size(90, 26)
        Me.numDiscipline.TabIndex = 12
        Me.numDiscipline.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAgility
        '
        Me.lblAgility.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblAgility.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblAgility.Location = New System.Drawing.Point(20, 170)
        Me.lblAgility.Name = "lblAgility"
        Me.lblAgility.Size = New System.Drawing.Size(160, 22)
        Me.lblAgility.TabIndex = 13
        Me.lblAgility.Text = "🌪️ Agility & Footwork"
        '
        'numAgility
        '
        Me.numAgility.DecimalPlaces = 1
        Me.numAgility.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.numAgility.Location = New System.Drawing.Point(190, 168)
        Me.numAgility.Name = "numAgility"
        Me.numAgility.Size = New System.Drawing.Size(90, 26)
        Me.numAgility.TabIndex = 14
        Me.numAgility.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOverall
        '
        Me.lblOverall.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblOverall.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblOverall.Location = New System.Drawing.Point(310, 170)
        Me.lblOverall.Name = "lblOverall"
        Me.lblOverall.Size = New System.Drawing.Size(160, 22)
        Me.lblOverall.TabIndex = 15
        Me.lblOverall.Text = "⭐ Overall Performance"
        '
        'numOverall
        '
        Me.numOverall.DecimalPlaces = 1
        Me.numOverall.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.numOverall.Location = New System.Drawing.Point(480, 168)
        Me.numOverall.Name = "numOverall"
        Me.numOverall.Size = New System.Drawing.Size(90, 26)
        Me.numOverall.TabIndex = 16
        Me.numOverall.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEndurance
        '
        Me.lblEndurance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblEndurance.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblEndurance.Location = New System.Drawing.Point(20, 206)
        Me.lblEndurance.Name = "lblEndurance"
        Me.lblEndurance.Size = New System.Drawing.Size(160, 22)
        Me.lblEndurance.TabIndex = 17
        Me.lblEndurance.Text = "🏃 Endurance & Stamina"
        '
        'numEndurance
        '
        Me.numEndurance.DecimalPlaces = 1
        Me.numEndurance.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.numEndurance.Location = New System.Drawing.Point(190, 204)
        Me.numEndurance.Name = "numEndurance"
        Me.numEndurance.Size = New System.Drawing.Size(90, 26)
        Me.numEndurance.TabIndex = 18
        Me.numEndurance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblScaleHint
        '
        Me.lblScaleHint.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Italic)
        Me.lblScaleHint.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblScaleHint.Location = New System.Drawing.Point(310, 206)
        Me.lblScaleHint.Name = "lblScaleHint"
        Me.lblScaleHint.Size = New System.Drawing.Size(260, 22)
        Me.lblScaleHint.TabIndex = 19
        Me.lblScaleHint.Text = "Scale: 0.0 (Lowest) - 100.0 (Mastery)"
        '
        'pnlScoreBanner
        '
        Me.pnlScoreBanner.BackColor = System.Drawing.Color.FromArgb(240, 253, 244)
        Me.pnlScoreBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlScoreBanner.Controls.Add(Me.lblFinalTitle)
        Me.pnlScoreBanner.Controls.Add(Me.lblPassingStandard)
        Me.pnlScoreBanner.Controls.Add(Me.lblFinalScoreValue)
        Me.pnlScoreBanner.Location = New System.Drawing.Point(20, 242)
        Me.pnlScoreBanner.Name = "pnlScoreBanner"
        Me.pnlScoreBanner.Size = New System.Drawing.Size(570, 56)
        Me.pnlScoreBanner.TabIndex = 20
        '
        'lblFinalTitle
        '
        Me.lblFinalTitle.AutoSize = True
        Me.lblFinalTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblFinalTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblFinalTitle.Location = New System.Drawing.Point(16, 10)
        Me.lblFinalTitle.Name = "lblFinalTitle"
        Me.lblFinalTitle.Size = New System.Drawing.Size(167, 17)
        Me.lblFinalTitle.TabIndex = 0
        Me.lblFinalTitle.Text = "COMPUTED TRYOUT SCORE"
        '
        'lblPassingStandard
        '
        Me.lblPassingStandard.AutoSize = True
        Me.lblPassingStandard.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblPassingStandard.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblPassingStandard.Location = New System.Drawing.Point(16, 30)
        Me.lblPassingStandard.Name = "lblPassingStandard"
        Me.lblPassingStandard.Size = New System.Drawing.Size(188, 15)
        Me.lblPassingStandard.TabIndex = 1
        Me.lblPassingStandard.Text = "Standard: ≥ 75.00 to Qualify Roster"
        '
        'lblFinalScoreValue
        '
        Me.lblFinalScoreValue.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblFinalScoreValue.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.lblFinalScoreValue.Location = New System.Drawing.Point(420, 8)
        Me.lblFinalScoreValue.Name = "lblFinalScoreValue"
        Me.lblFinalScoreValue.Size = New System.Drawing.Size(130, 38)
        Me.lblFinalScoreValue.TabIndex = 2
        Me.lblFinalScoreValue.Text = "0.00"
        Me.lblFinalScoreValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'div2
        '
        Me.div2.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.div2.Location = New System.Drawing.Point(20, 310)
        Me.div2.Name = "div2"
        Me.div2.Size = New System.Drawing.Size(570, 1)
        Me.div2.TabIndex = 21
        '
        'lblDecisionTitle
        '
        Me.lblDecisionTitle.AutoSize = True
        Me.lblDecisionTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDecisionTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblDecisionTitle.Location = New System.Drawing.Point(20, 320)
        Me.lblDecisionTitle.Name = "lblDecisionTitle"
        Me.lblDecisionTitle.Size = New System.Drawing.Size(164, 15)
        Me.lblDecisionTitle.TabIndex = 22
        Me.lblDecisionTitle.Text = "FINAL SELECTION DECISION *"
        '
        'cmbDecision
        '
        Me.cmbDecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDecision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDecision.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbDecision.FormattingEnabled = True
        Me.cmbDecision.Items.AddRange(New Object() {"Pending", "Selected", "Not Selected", "For Further Evaluation"})
        Me.cmbDecision.Location = New System.Drawing.Point(20, 342)
        Me.cmbDecision.Name = "cmbDecision"
        Me.cmbDecision.Size = New System.Drawing.Size(320, 25)
        Me.cmbDecision.TabIndex = 23
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblRemarks.Location = New System.Drawing.Point(20, 380)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(193, 15)
        Me.lblRemarks.TabIndex = 24
        Me.lblRemarks.Text = "ASSESSMENT NOTES & REMARKS"
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtRemarks.Location = New System.Drawing.Point(20, 402)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(570, 72)
        Me.txtRemarks.TabIndex = 25
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(20, 486)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(280, 42)
        Me.btnSave.TabIndex = 26
        Me.btnSave.Text = "💾  Save Evaluation & Decision"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnClear.Location = New System.Drawing.Point(314, 486)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(140, 42)
        Me.btnClear.TabIndex = 27
        Me.btnClear.Text = "↺  Reset Fields"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'tabRankings
        '
        Me.tabRankings.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.tabRankings.Controls.Add(Me.pnlRankings)
        Me.tabRankings.Location = New System.Drawing.Point(4, 40)
        Me.tabRankings.Name = "tabRankings"
        Me.tabRankings.Padding = New System.Windows.Forms.Padding(6)
        Me.tabRankings.Size = New System.Drawing.Size(1142, 516)
        Me.tabRankings.TabIndex = 1
        Me.tabRankings.Text = "  2. Screening & Rankings Board  "
        '
        'pnlRankings
        '
        Me.pnlRankings.Controls.Add(Me.pnlRankCard)
        Me.pnlRankings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRankings.Location = New System.Drawing.Point(6, 6)
        Me.pnlRankings.Name = "pnlRankings"
        Me.pnlRankings.Size = New System.Drawing.Size(1130, 504)
        Me.pnlRankings.TabIndex = 0
        '
        'pnlRankCard
        '
        Me.pnlRankCard.BackColor = System.Drawing.Color.White
        Me.pnlRankCard.Controls.Add(Me.rankAccent)
        Me.pnlRankCard.Controls.Add(Me.lblBoardTitle)
        Me.pnlRankCard.Controls.Add(Me.chkQualifiedOnly)
        Me.pnlRankCard.Controls.Add(Me.btnExportRankings)
        Me.pnlRankCard.Controls.Add(Me.lblRankSummary)
        Me.pnlRankCard.Controls.Add(Me.dgvRankings)
        Me.pnlRankCard.Location = New System.Drawing.Point(10, 10)
        Me.pnlRankCard.Name = "pnlRankCard"
        Me.pnlRankCard.Size = New System.Drawing.Size(1110, 484)
        Me.pnlRankCard.TabIndex = 0
        '
        'rankAccent
        '
        Me.rankAccent.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.rankAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.rankAccent.Location = New System.Drawing.Point(0, 0)
        Me.rankAccent.Name = "rankAccent"
        Me.rankAccent.Size = New System.Drawing.Size(1110, 4)
        Me.rankAccent.TabIndex = 0
        '
        'lblBoardTitle
        '
        Me.lblBoardTitle.AutoSize = True
        Me.lblBoardTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblBoardTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblBoardTitle.Location = New System.Drawing.Point(20, 16)
        Me.lblBoardTitle.Name = "lblBoardTitle"
        Me.lblBoardTitle.Size = New System.Drawing.Size(325, 21)
        Me.lblBoardTitle.TabIndex = 1
        Me.lblBoardTitle.Text = "🏆 Athlete Screening & Ranking Leaderboard"
        '
        'chkQualifiedOnly
        '
        Me.chkQualifiedOnly.AutoSize = True
        Me.chkQualifiedOnly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkQualifiedOnly.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.chkQualifiedOnly.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.chkQualifiedOnly.Location = New System.Drawing.Point(365, 18)
        Me.chkQualifiedOnly.Name = "chkQualifiedOnly"
        Me.chkQualifiedOnly.Size = New System.Drawing.Size(305, 21)
        Me.chkQualifiedOnly.TabIndex = 2
        Me.chkQualifiedOnly.Text = "Show only qualified athletes (Final Score ≥ 75)"
        Me.chkQualifiedOnly.UseVisualStyleBackColor = True
        '
        'btnExportRankings
        '
        Me.btnExportRankings.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnExportRankings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportRankings.FlatAppearance.BorderSize = 0
        Me.btnExportRankings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportRankings.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnExportRankings.ForeColor = System.Drawing.Color.White
        Me.btnExportRankings.Location = New System.Drawing.Point(920, 12)
        Me.btnExportRankings.Name = "btnExportRankings"
        Me.btnExportRankings.Size = New System.Drawing.Size(170, 36)
        Me.btnExportRankings.TabIndex = 3
        Me.btnExportRankings.Text = "📥  Export to CSV"
        Me.btnExportRankings.UseVisualStyleBackColor = False
        '
        'lblRankSummary
        '
        Me.lblRankSummary.AutoSize = True
        Me.lblRankSummary.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblRankSummary.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblRankSummary.Location = New System.Drawing.Point(22, 48)
        Me.lblRankSummary.Name = "lblRankSummary"
        Me.lblRankSummary.Size = New System.Drawing.Size(0, 17)
        Me.lblRankSummary.TabIndex = 4
        '
        'dgvRankings
        '
        Me.dgvRankings.AllowUserToAddRows = False
        Me.dgvRankings.AllowUserToDeleteRows = False
        Me.dgvRankings.AllowUserToResizeRows = False
        Me.dgvRankings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRankings.BackgroundColor = System.Drawing.Color.White
        Me.dgvRankings.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRankings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvRankings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(253, 224, 71)
        dataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRankings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3
        Me.dgvRankings.ColumnHeadersHeight = 38
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        dataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254)
        dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRankings.DefaultCellStyle = dataGridViewCellStyle4
        Me.dgvRankings.EnableHeadersVisualStyles = False
        Me.dgvRankings.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgvRankings.Location = New System.Drawing.Point(20, 76)
        Me.dgvRankings.MultiSelect = False
        Me.dgvRankings.Name = "dgvRankings"
        Me.dgvRankings.ReadOnly = True
        Me.dgvRankings.RowHeadersVisible = False
        Me.dgvRankings.RowTemplate.Height = 36
        Me.dgvRankings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRankings.Size = New System.Drawing.Size(1070, 390)
        Me.dgvRankings.TabIndex = 5
        '
        'frmEvaluationSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1200, 720)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.pnlFilter)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmEvaluationSelection"
        Me.Text = "Athlete Evaluation & Selection"
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tabEval.ResumeLayout(False)
        Me.pnlContainer.ResumeLayout(False)
        Me.pnlRosterCard.ResumeLayout(False)
        Me.pnlRosterCard.PerformLayout()
        CType(Me.dgvApplicants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCard.ResumeLayout(False)
        Me.pnlCard.PerformLayout()
        CType(Me.numSkill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAgility, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numEndurance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTeamwork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDiscipline, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOverall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlScoreBanner.ResumeLayout(False)
        Me.pnlScoreBanner.PerformLayout()
        Me.tabRankings.ResumeLayout(False)
        Me.pnlRankings.ResumeLayout(False)
        Me.pnlRankCard.ResumeLayout(False)
        Me.pnlRankCard.PerformLayout()
        CType(Me.dgvRankings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents filterAccent As System.Windows.Forms.Panel
    Friend WithEvents lblSport As System.Windows.Forms.Label
    Friend WithEvents cmbFilterSport As System.Windows.Forms.ComboBox
    Friend WithEvents lblStats As System.Windows.Forms.Label

    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabEval As System.Windows.Forms.TabPage
    Friend WithEvents pnlContainer As System.Windows.Forms.Panel

    Friend WithEvents pnlRosterCard As System.Windows.Forms.Panel
    Friend WithEvents rosterAccent As System.Windows.Forms.Panel
    Friend WithEvents lblGridTitle As System.Windows.Forms.Label
    Friend WithEvents lblRosterCount As System.Windows.Forms.Label
    Friend WithEvents txtSearchApplicant As System.Windows.Forms.TextBox
    Friend WithEvents dgvApplicants As System.Windows.Forms.DataGridView

    Friend WithEvents pnlCard As System.Windows.Forms.Panel
    Friend WithEvents cardAccent As System.Windows.Forms.Panel
    Friend WithEvents lblApplicantHeader As System.Windows.Forms.Label
    Friend WithEvents lblApplicantSub As System.Windows.Forms.Label
    Friend WithEvents div1 As System.Windows.Forms.Panel
    Friend WithEvents lblCriteriaHeader As System.Windows.Forms.Label
    Friend WithEvents lblSkill As System.Windows.Forms.Label
    Friend WithEvents numSkill As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents numSpeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAgility As System.Windows.Forms.Label
    Friend WithEvents numAgility As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblEndurance As System.Windows.Forms.Label
    Friend WithEvents numEndurance As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTeamwork As System.Windows.Forms.Label
    Friend WithEvents numTeamwork As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDiscipline As System.Windows.Forms.Label
    Friend WithEvents numDiscipline As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblOverall As System.Windows.Forms.Label
    Friend WithEvents numOverall As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblScaleHint As System.Windows.Forms.Label

    Friend WithEvents pnlScoreBanner As System.Windows.Forms.Panel
    Friend WithEvents lblFinalTitle As System.Windows.Forms.Label
    Friend WithEvents lblPassingStandard As System.Windows.Forms.Label
    Friend WithEvents lblFinalScoreValue As System.Windows.Forms.Label

    Friend WithEvents div2 As System.Windows.Forms.Panel
    Friend WithEvents lblDecisionTitle As System.Windows.Forms.Label
    Friend WithEvents cmbDecision As System.Windows.Forms.ComboBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button

    Friend WithEvents tabRankings As System.Windows.Forms.TabPage
    Friend WithEvents pnlRankings As System.Windows.Forms.Panel
    Friend WithEvents pnlRankCard As System.Windows.Forms.Panel
    Friend WithEvents rankAccent As System.Windows.Forms.Panel
    Friend WithEvents lblBoardTitle As System.Windows.Forms.Label
    Friend WithEvents chkQualifiedOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnExportRankings As System.Windows.Forms.Button
    Friend WithEvents lblRankSummary As System.Windows.Forms.Label
    Friend WithEvents dgvRankings As System.Windows.Forms.DataGridView

End Class
