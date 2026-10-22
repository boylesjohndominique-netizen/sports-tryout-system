<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReports
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
        Dim dataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim dataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

        Me.pnlSelector = New System.Windows.Forms.Panel()
        Me.selectorAccent = New System.Windows.Forms.Panel()
        Me.lblTypeLabel = New System.Windows.Forms.Label()
        Me.cmbReportType = New System.Windows.Forms.ComboBox()
        Me.lblSportLabel = New System.Windows.Forms.Label()
        Me.cmbFilterSport = New System.Windows.Forms.ComboBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblSummary = New System.Windows.Forms.Label()

        Me.pnlReportCard = New System.Windows.Forms.Panel()
        Me.reportAccent = New System.Windows.Forms.Panel()
        Me.lblReportCardTitle = New System.Windows.Forms.Label()
        Me.lblReportRowCount = New System.Windows.Forms.Label()
        Me.lblReportSearch = New System.Windows.Forms.Label()
        Me.txtSearchReport = New System.Windows.Forms.TextBox()
        Me.dgv = New System.Windows.Forms.DataGridView()

        Me.pnlStudent = New System.Windows.Forms.Panel()
        Me.studentAccent = New System.Windows.Forms.Panel()
        Me.lblStudentTitle = New System.Windows.Forms.Label()
        Me.lblStudentSelect = New System.Windows.Forms.Label()
        Me.cmbStudent = New System.Windows.Forms.ComboBox()
        Me.pnlStudentDivider = New System.Windows.Forms.Panel()
        Me.pnlStuInfoBox = New System.Windows.Forms.Panel()
        Me.lblStuName = New System.Windows.Forms.Label()
        Me.lblStuMetaLabels = New System.Windows.Forms.Label()
        Me.lblStuMeta = New System.Windows.Forms.Label()
        Me.lblStuSports = New System.Windows.Forms.Label()
        Me.dgvStudent = New System.Windows.Forms.DataGridView()
        Me.btnStudentExport = New System.Windows.Forms.Button()

        Me.pnlSelector.SuspendLayout()
        Me.pnlReportCard.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStudent.SuspendLayout()
        Me.pnlStuInfoBox.SuspendLayout()
        CType(Me.dgvStudent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSelector
        '
        Me.pnlSelector.BackColor = System.Drawing.Color.White
        Me.pnlSelector.Controls.Add(Me.selectorAccent)
        Me.pnlSelector.Controls.Add(Me.lblTypeLabel)
        Me.pnlSelector.Controls.Add(Me.cmbReportType)
        Me.pnlSelector.Controls.Add(Me.lblSportLabel)
        Me.pnlSelector.Controls.Add(Me.cmbFilterSport)
        Me.pnlSelector.Controls.Add(Me.btnGenerate)
        Me.pnlSelector.Controls.Add(Me.btnExport)
        Me.pnlSelector.Controls.Add(Me.lblSummary)
        Me.pnlSelector.Location = New System.Drawing.Point(20, 66)
        Me.pnlSelector.Name = "pnlSelector"
        Me.pnlSelector.Size = New System.Drawing.Size(1160, 74)
        Me.pnlSelector.TabIndex = 0
        '
        'selectorAccent
        '
        Me.selectorAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.selectorAccent.Location = New System.Drawing.Point(0, 0)
        Me.selectorAccent.Name = "selectorAccent"
        Me.selectorAccent.Size = New System.Drawing.Size(1160, 3)
        Me.selectorAccent.TabIndex = 0
        '
        'lblTypeLabel
        '
        Me.lblTypeLabel.AutoSize = True
        Me.lblTypeLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblTypeLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblTypeLabel.Location = New System.Drawing.Point(18, 10)
        Me.lblTypeLabel.Name = "lblTypeLabel"
        Me.lblTypeLabel.Size = New System.Drawing.Size(82, 15)
        Me.lblTypeLabel.TabIndex = 1
        Me.lblTypeLabel.Text = "REPORT TYPE"
        Me.lblTypeLabel.UseMnemonic = False
        '
        'cmbReportType
        '
        Me.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbReportType.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.cmbReportType.FormattingEnabled = True
        Me.cmbReportType.Items.AddRange(New Object() {"Registered Applicants", "Applicants per Sport", "Tryout Schedules", "Athlete Evaluation Results", "Applicant Rankings", "Qualified Students", "Selected Athletes", "Non-Selected Athletes"})
        Me.cmbReportType.Location = New System.Drawing.Point(18, 30)
        Me.cmbReportType.Name = "cmbReportType"
        Me.cmbReportType.Size = New System.Drawing.Size(250, 27)
        Me.cmbReportType.TabIndex = 2
        '
        'lblSportLabel
        '
        Me.lblSportLabel.AutoSize = True
        Me.lblSportLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSportLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSportLabel.Location = New System.Drawing.Point(284, 10)
        Me.lblSportLabel.Name = "lblSportLabel"
        Me.lblSportLabel.Size = New System.Drawing.Size(85, 15)
        Me.lblSportLabel.TabIndex = 3
        Me.lblSportLabel.Text = "SPORT FILTER"
        Me.lblSportLabel.UseMnemonic = False
        '
        'cmbFilterSport
        '
        Me.cmbFilterSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterSport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterSport.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.cmbFilterSport.FormattingEnabled = True
        Me.cmbFilterSport.Location = New System.Drawing.Point(284, 30)
        Me.cmbFilterSport.Name = "cmbFilterSport"
        Me.cmbFilterSport.Size = New System.Drawing.Size(190, 27)
        Me.cmbFilterSport.TabIndex = 4
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerate.FlatAppearance.BorderSize = 0
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerate.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnGenerate.ForeColor = System.Drawing.Color.FromArgb(14, 38, 72)
        Me.btnGenerate.Location = New System.Drawing.Point(490, 24)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(145, 38)
        Me.btnGenerate.TabIndex = 5
        Me.btnGenerate.Text = "Generate Report"
        Me.btnGenerate.UseMnemonic = False
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(647, 24)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(145, 38)
        Me.btnExport.TabIndex = 6
        Me.btnExport.Text = "Export to Excel"
        Me.btnExport.UseMnemonic = False
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'lblSummary
        '
        Me.lblSummary.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.lblSummary.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSummary.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblSummary.Location = New System.Drawing.Point(808, 22)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(334, 40)
        Me.lblSummary.TabIndex = 7
        Me.lblSummary.Text = "Ready to generate reports"
        Me.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSummary.UseMnemonic = False
        '
        'pnlReportCard
        '
        Me.pnlReportCard.BackColor = System.Drawing.Color.White
        Me.pnlReportCard.Controls.Add(Me.reportAccent)
        Me.pnlReportCard.Controls.Add(Me.lblReportCardTitle)
        Me.pnlReportCard.Controls.Add(Me.lblReportRowCount)
        Me.pnlReportCard.Controls.Add(Me.lblReportSearch)
        Me.pnlReportCard.Controls.Add(Me.txtSearchReport)
        Me.pnlReportCard.Controls.Add(Me.dgv)
        Me.pnlReportCard.Location = New System.Drawing.Point(20, 152)
        Me.pnlReportCard.Name = "pnlReportCard"
        Me.pnlReportCard.Size = New System.Drawing.Size(720, 548)
        Me.pnlReportCard.TabIndex = 1
        '
        'reportAccent
        '
        Me.reportAccent.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.reportAccent.Location = New System.Drawing.Point(0, 0)
        Me.reportAccent.Name = "reportAccent"
        Me.reportAccent.Size = New System.Drawing.Size(720, 3)
        Me.reportAccent.TabIndex = 0
        '
        'lblReportCardTitle
        '
        Me.lblReportCardTitle.AutoSize = True
        Me.lblReportCardTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblReportCardTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblReportCardTitle.Location = New System.Drawing.Point(18, 15)
        Me.lblReportCardTitle.Name = "lblReportCardTitle"
        Me.lblReportCardTitle.Size = New System.Drawing.Size(192, 25)
        Me.lblReportCardTitle.TabIndex = 1
        Me.lblReportCardTitle.Text = "Registered Applicants"
        Me.lblReportCardTitle.UseMnemonic = False
        '
        'lblReportRowCount
        '
        Me.lblReportRowCount.AutoSize = True
        Me.lblReportRowCount.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.lblReportRowCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblReportRowCount.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblReportRowCount.Location = New System.Drawing.Point(220, 17)
        Me.lblReportRowCount.Name = "lblReportRowCount"
        Me.lblReportRowCount.Padding = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.lblReportRowCount.Size = New System.Drawing.Size(78, 23)
        Me.lblReportRowCount.TabIndex = 2
        Me.lblReportRowCount.Text = "0 Records"
        Me.lblReportRowCount.UseMnemonic = False
        '
        'lblReportSearch
        '
        Me.lblReportSearch.AutoSize = True
        Me.lblReportSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblReportSearch.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblReportSearch.Location = New System.Drawing.Point(440, 18)
        Me.lblReportSearch.Name = "lblReportSearch"
        Me.lblReportSearch.Size = New System.Drawing.Size(54, 19)
        Me.lblReportSearch.TabIndex = 3
        Me.lblReportSearch.Text = "Search:"
        Me.lblReportSearch.UseMnemonic = False
        '
        'txtSearchReport
        '
        Me.txtSearchReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchReport.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearchReport.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.txtSearchReport.Location = New System.Drawing.Point(500, 15)
        Me.txtSearchReport.Name = "txtSearchReport"
        Me.txtSearchReport.Size = New System.Drawing.Size(202, 25)
        Me.txtSearchReport.TabIndex = 4
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(253, 224, 71)
        dataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
        Me.dgv.ColumnHeadersHeight = 42
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        dataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254)
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = dataGridViewCellStyle3
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgv.Location = New System.Drawing.Point(18, 54)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 38
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(684, 478)
        Me.dgv.TabIndex = 5
        '
        'pnlStudent
        '
        Me.pnlStudent.BackColor = System.Drawing.Color.White
        Me.pnlStudent.Controls.Add(Me.studentAccent)
        Me.pnlStudent.Controls.Add(Me.lblStudentTitle)
        Me.pnlStudent.Controls.Add(Me.lblStudentSelect)
        Me.pnlStudent.Controls.Add(Me.cmbStudent)
        Me.pnlStudent.Controls.Add(Me.pnlStudentDivider)
        Me.pnlStudent.Controls.Add(Me.pnlStuInfoBox)
        Me.pnlStudent.Controls.Add(Me.lblStuSports)
        Me.pnlStudent.Controls.Add(Me.dgvStudent)
        Me.pnlStudent.Controls.Add(Me.btnStudentExport)
        Me.pnlStudent.Location = New System.Drawing.Point(756, 152)
        Me.pnlStudent.Name = "pnlStudent"
        Me.pnlStudent.Size = New System.Drawing.Size(424, 548)
        Me.pnlStudent.TabIndex = 2
        '
        'studentAccent
        '
        Me.studentAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.studentAccent.Location = New System.Drawing.Point(0, 0)
        Me.studentAccent.Name = "studentAccent"
        Me.studentAccent.Size = New System.Drawing.Size(424, 3)
        Me.studentAccent.TabIndex = 0
        '
        'lblStudentTitle
        '
        Me.lblStudentTitle.AutoSize = True
        Me.lblStudentTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 12.5!, System.Drawing.FontStyle.Bold)
        Me.lblStudentTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblStudentTitle.Location = New System.Drawing.Point(18, 14)
        Me.lblStudentTitle.Name = "lblStudentTitle"
        Me.lblStudentTitle.Size = New System.Drawing.Size(242, 23)
        Me.lblStudentTitle.TabIndex = 1
        Me.lblStudentTitle.Text = "Athlete Profile & Dossier"
        Me.lblStudentTitle.UseMnemonic = False
        '
        'lblStudentSelect
        '
        Me.lblStudentSelect.AutoSize = True
        Me.lblStudentSelect.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblStudentSelect.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStudentSelect.Location = New System.Drawing.Point(18, 44)
        Me.lblStudentSelect.Name = "lblStudentSelect"
        Me.lblStudentSelect.Size = New System.Drawing.Size(96, 15)
        Me.lblStudentSelect.TabIndex = 2
        Me.lblStudentSelect.Text = "SELECT ATHLETE"
        Me.lblStudentSelect.UseMnemonic = False
        '
        'cmbStudent
        '
        Me.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStudent.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.cmbStudent.FormattingEnabled = True
        Me.cmbStudent.Location = New System.Drawing.Point(18, 63)
        Me.cmbStudent.Name = "cmbStudent"
        Me.cmbStudent.Size = New System.Drawing.Size(388, 27)
        Me.cmbStudent.TabIndex = 3
        '
        'pnlStudentDivider
        '
        Me.pnlStudentDivider.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.pnlStudentDivider.Location = New System.Drawing.Point(18, 100)
        Me.pnlStudentDivider.Name = "pnlStudentDivider"
        Me.pnlStudentDivider.Size = New System.Drawing.Size(388, 1)
        Me.pnlStudentDivider.TabIndex = 4
        '
        'pnlStuInfoBox
        '
        Me.pnlStuInfoBox.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlStuInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStuInfoBox.Controls.Add(Me.lblStuName)
        Me.pnlStuInfoBox.Controls.Add(Me.lblStuMetaLabels)
        Me.pnlStuInfoBox.Controls.Add(Me.lblStuMeta)
        Me.pnlStuInfoBox.Location = New System.Drawing.Point(18, 110)
        Me.pnlStuInfoBox.Name = "pnlStuInfoBox"
        Me.pnlStuInfoBox.Size = New System.Drawing.Size(388, 174)
        Me.pnlStuInfoBox.TabIndex = 5
        '
        'lblStuName
        '
        Me.lblStuName.AutoEllipsis = True
        Me.lblStuName.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblStuName.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblStuName.Location = New System.Drawing.Point(14, 8)
        Me.lblStuName.Name = "lblStuName"
        Me.lblStuName.Size = New System.Drawing.Size(358, 26)
        Me.lblStuName.TabIndex = 0
        Me.lblStuName.Text = "Select a student to preview."
        Me.lblStuName.UseMnemonic = False
        '
        'lblStuMetaLabels
        '
        Me.lblStuMetaLabels.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblStuMetaLabels.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStuMetaLabels.Location = New System.Drawing.Point(12, 38)
        Me.lblStuMetaLabels.Name = "lblStuMetaLabels"
        Me.lblStuMetaLabels.Size = New System.Drawing.Size(88, 128)
        Me.lblStuMetaLabels.TabIndex = 1
        Me.lblStuMetaLabels.Text = "Student No:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "Course/Year:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "Gender:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "Contact No:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "Email:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
            "Registered:"
        Me.lblStuMetaLabels.UseMnemonic = False
        '
        'lblStuMeta
        '
        Me.lblStuMeta.AutoEllipsis = True
        Me.lblStuMeta.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblStuMeta.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblStuMeta.Location = New System.Drawing.Point(102, 38)
        Me.lblStuMeta.Name = "lblStuMeta"
        Me.lblStuMeta.Size = New System.Drawing.Size(276, 128)
        Me.lblStuMeta.TabIndex = 2
        Me.lblStuMeta.Text = ""
        Me.lblStuMeta.UseMnemonic = False
        '
        'lblStuSports
        '
        Me.lblStuSports.AutoSize = True
        Me.lblStuSports.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblStuSports.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblStuSports.Location = New System.Drawing.Point(18, 294)
        Me.lblStuSports.Name = "lblStuSports"
        Me.lblStuSports.Size = New System.Drawing.Size(225, 17)
        Me.lblStuSports.TabIndex = 6
        Me.lblStuSports.Text = "REGISTERED SPORTS & RESULTS"
        Me.lblStuSports.UseMnemonic = False
        '
        'dgvStudent
        '
        Me.dgvStudent.AllowUserToAddRows = False
        Me.dgvStudent.AllowUserToDeleteRows = False
        Me.dgvStudent.AllowUserToResizeRows = False
        dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.dgvStudent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4
        Me.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStudent.BackgroundColor = System.Drawing.Color.White
        Me.dgvStudent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvStudent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvStudent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(253, 224, 71)
        dataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5
        Me.dgvStudent.ColumnHeadersHeight = 36
        dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        dataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254)
        dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStudent.DefaultCellStyle = dataGridViewCellStyle6
        Me.dgvStudent.EnableHeadersVisualStyles = False
        Me.dgvStudent.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgvStudent.Location = New System.Drawing.Point(18, 316)
        Me.dgvStudent.MultiSelect = False
        Me.dgvStudent.Name = "dgvStudent"
        Me.dgvStudent.ReadOnly = True
        Me.dgvStudent.RowHeadersVisible = False
        Me.dgvStudent.RowTemplate.Height = 34
        Me.dgvStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStudent.Size = New System.Drawing.Size(388, 164)
        Me.dgvStudent.TabIndex = 7
        '
        'btnStudentExport
        '
        Me.btnStudentExport.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.btnStudentExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStudentExport.FlatAppearance.BorderSize = 0
        Me.btnStudentExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStudentExport.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnStudentExport.ForeColor = System.Drawing.Color.White
        Me.btnStudentExport.Location = New System.Drawing.Point(18, 492)
        Me.btnStudentExport.Name = "btnStudentExport"
        Me.btnStudentExport.Size = New System.Drawing.Size(388, 42)
        Me.btnStudentExport.TabIndex = 8
        Me.btnStudentExport.Text = "Export Athlete Profile to Excel"
        Me.btnStudentExport.UseMnemonic = False
        Me.btnStudentExport.UseVisualStyleBackColor = False
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1200, 720)
        Me.Controls.Add(Me.pnlStudent)
        Me.Controls.Add(Me.pnlReportCard)
        Me.Controls.Add(Me.pnlSelector)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmReports"
        Me.Text = "Reports & Analytics"
        Me.pnlSelector.ResumeLayout(False)
        Me.pnlSelector.PerformLayout()
        Me.pnlReportCard.ResumeLayout(False)
        Me.pnlReportCard.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStudent.ResumeLayout(False)
        Me.pnlStudent.PerformLayout()
        Me.pnlStuInfoBox.ResumeLayout(False)
        CType(Me.dgvStudent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSelector As System.Windows.Forms.Panel
    Friend WithEvents selectorAccent As System.Windows.Forms.Panel
    Friend WithEvents lblTypeLabel As System.Windows.Forms.Label
    Friend WithEvents cmbReportType As System.Windows.Forms.ComboBox
    Friend WithEvents lblSportLabel As System.Windows.Forms.Label
    Friend WithEvents cmbFilterSport As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents lblSummary As System.Windows.Forms.Label

    Friend WithEvents pnlReportCard As System.Windows.Forms.Panel
    Friend WithEvents reportAccent As System.Windows.Forms.Panel
    Friend WithEvents lblReportCardTitle As System.Windows.Forms.Label
    Friend WithEvents lblReportRowCount As System.Windows.Forms.Label
    Friend WithEvents lblReportSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearchReport As System.Windows.Forms.TextBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView

    Friend WithEvents pnlStudent As System.Windows.Forms.Panel
    Friend WithEvents studentAccent As System.Windows.Forms.Panel
    Friend WithEvents lblStudentTitle As System.Windows.Forms.Label
    Friend WithEvents lblStudentSelect As System.Windows.Forms.Label
    Friend WithEvents cmbStudent As System.Windows.Forms.ComboBox
    Friend WithEvents pnlStudentDivider As System.Windows.Forms.Panel
    Friend WithEvents pnlStuInfoBox As System.Windows.Forms.Panel
    Friend WithEvents lblStuName As System.Windows.Forms.Label
    Friend WithEvents lblStuMetaLabels As System.Windows.Forms.Label
    Friend WithEvents lblStuMeta As System.Windows.Forms.Label
    Friend WithEvents lblStuSports As System.Windows.Forms.Label
    Friend WithEvents dgvStudent As System.Windows.Forms.DataGridView
    Friend WithEvents btnStudentExport As System.Windows.Forms.Button
End Class
