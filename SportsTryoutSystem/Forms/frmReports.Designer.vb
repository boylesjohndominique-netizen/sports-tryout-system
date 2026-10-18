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
        Me.pnlSelector = New System.Windows.Forms.Panel()
        Me.selectorAccent = New System.Windows.Forms.Panel()
        Me.lblTypeLabel = New System.Windows.Forms.Label()
        Me.cmbReportType = New System.Windows.Forms.ComboBox()
        Me.lblSportLabel = New System.Windows.Forms.Label()
        Me.cmbFilterSport = New System.Windows.Forms.ComboBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.pnlStudent = New System.Windows.Forms.Panel()
        Me.studentAccent = New System.Windows.Forms.Panel()
        Me.lblStudentTitle = New System.Windows.Forms.Label()
        Me.lblStudentSelect = New System.Windows.Forms.Label()
        Me.cmbStudent = New System.Windows.Forms.ComboBox()
        Me.pnlStudentDivider = New System.Windows.Forms.Panel()
        Me.lblStuName = New System.Windows.Forms.Label()
        Me.lblStuMeta = New System.Windows.Forms.Label()
        Me.lblStuSports = New System.Windows.Forms.Label()
        Me.dgvStudent = New System.Windows.Forms.DataGridView()
        Me.btnStudentExport = New System.Windows.Forms.Button()
        Me.pnlSelector.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStudent.SuspendLayout()
        CType(Me.dgvStudent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSelector
        '
        Me.pnlSelector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSelector.BackColor = System.Drawing.Color.White
        Me.pnlSelector.Controls.Add(Me.selectorAccent)
        Me.pnlSelector.Controls.Add(Me.lblTypeLabel)
        Me.pnlSelector.Controls.Add(Me.cmbReportType)
        Me.pnlSelector.Controls.Add(Me.lblSportLabel)
        Me.pnlSelector.Controls.Add(Me.cmbFilterSport)
        Me.pnlSelector.Controls.Add(Me.btnGenerate)
        Me.pnlSelector.Controls.Add(Me.btnExport)
        Me.pnlSelector.Location = New System.Drawing.Point(24, 76)
        Me.pnlSelector.Name = "pnlSelector"
        Me.pnlSelector.Size = New System.Drawing.Size(1012, 70)
        Me.pnlSelector.TabIndex = 0
        '
        'selectorAccent
        '
        Me.selectorAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.selectorAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.selectorAccent.Location = New System.Drawing.Point(0, 0)
        Me.selectorAccent.Name = "selectorAccent"
        Me.selectorAccent.Size = New System.Drawing.Size(1012, 3)
        Me.selectorAccent.TabIndex = 0
        '
        'lblTypeLabel
        '
        Me.lblTypeLabel.AutoSize = True
        Me.lblTypeLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTypeLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblTypeLabel.Location = New System.Drawing.Point(20, 12)
        Me.lblTypeLabel.Name = "lblTypeLabel"
        Me.lblTypeLabel.Size = New System.Drawing.Size(75, 13)
        Me.lblTypeLabel.TabIndex = 1
        Me.lblTypeLabel.Text = "REPORT TYPE"
        '
        'cmbReportType
        '
        Me.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbReportType.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbReportType.FormattingEnabled = True
        Me.cmbReportType.Items.AddRange(New Object() {"Registered Applicants", "Applicants per Sport", "Tryout Schedules", "Athlete Evaluation Results", "Applicant Rankings", "Qualified Students", "Selected Athletes", "Non-Selected Athletes"})
        Me.cmbReportType.Location = New System.Drawing.Point(20, 30)
        Me.cmbReportType.Name = "cmbReportType"
        Me.cmbReportType.Size = New System.Drawing.Size(300, 25)
        Me.cmbReportType.TabIndex = 2
        '
        'lblSportLabel
        '
        Me.lblSportLabel.AutoSize = True
        Me.lblSportLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSportLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSportLabel.Location = New System.Drawing.Point(336, 12)
        Me.lblSportLabel.Name = "lblSportLabel"
        Me.lblSportLabel.Size = New System.Drawing.Size(78, 13)
        Me.lblSportLabel.TabIndex = 3
        Me.lblSportLabel.Text = "SPORT FILTER"
        '
        'cmbFilterSport
        '
        Me.cmbFilterSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterSport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterSport.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbFilterSport.FormattingEnabled = True
        Me.cmbFilterSport.Location = New System.Drawing.Point(336, 30)
        Me.cmbFilterSport.Name = "cmbFilterSport"
        Me.cmbFilterSport.Size = New System.Drawing.Size(220, 25)
        Me.cmbFilterSport.TabIndex = 4
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerate.FlatAppearance.BorderSize = 0
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnGenerate.ForeColor = System.Drawing.Color.FromArgb(14, 38, 72)
        Me.btnGenerate.Location = New System.Drawing.Point(572, 28)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(140, 32)
        Me.btnGenerate.TabIndex = 5
        Me.btnGenerate.Text = "📊  Generate"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(724, 28)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(150, 32)
        Me.btnExport.TabIndex = 6
        Me.btnExport.Text = "📁  Export Report"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'lblSummary
        '
        Me.lblSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSummary.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSummary.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblSummary.Location = New System.Drawing.Point(24, 154)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(624, 20)
        Me.lblSummary.TabIndex = 1
        Me.lblSummary.Text = ""
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(253, 224, 71)
        dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeight = 36
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        dataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254)
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = dataGridViewCellStyle2
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(218, 225, 234)
        Me.dgv.Location = New System.Drawing.Point(24, 180)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 30
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(624, 456)
        Me.dgv.TabIndex = 2
        '
        'pnlStudent
        '
        Me.pnlStudent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStudent.BackColor = System.Drawing.Color.White
        Me.pnlStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStudent.Controls.Add(Me.studentAccent)
        Me.pnlStudent.Controls.Add(Me.lblStudentTitle)
        Me.pnlStudent.Controls.Add(Me.lblStudentSelect)
        Me.pnlStudent.Controls.Add(Me.cmbStudent)
        Me.pnlStudent.Controls.Add(Me.pnlStudentDivider)
        Me.pnlStudent.Controls.Add(Me.lblStuName)
        Me.pnlStudent.Controls.Add(Me.lblStuMeta)
        Me.pnlStudent.Controls.Add(Me.lblStuSports)
        Me.pnlStudent.Controls.Add(Me.dgvStudent)
        Me.pnlStudent.Controls.Add(Me.btnStudentExport)
        Me.pnlStudent.Location = New System.Drawing.Point(672, 180)
        Me.pnlStudent.Name = "pnlStudent"
        Me.pnlStudent.Size = New System.Drawing.Size(364, 456)
        Me.pnlStudent.TabIndex = 3
        '
        'studentAccent
        '
        Me.studentAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.studentAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.studentAccent.Location = New System.Drawing.Point(0, 0)
        Me.studentAccent.Name = "studentAccent"
        Me.studentAccent.Size = New System.Drawing.Size(362, 3)
        Me.studentAccent.TabIndex = 0
        '
        'lblStudentTitle
        '
        Me.lblStudentTitle.AutoSize = True
        Me.lblStudentTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblStudentTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblStudentTitle.Location = New System.Drawing.Point(16, 14)
        Me.lblStudentTitle.Name = "lblStudentTitle"
        Me.lblStudentTitle.Size = New System.Drawing.Size(131, 19)
        Me.lblStudentTitle.TabIndex = 1
        Me.lblStudentTitle.Text = "STUDENT PROFILE"
        '
        'lblStudentSelect
        '
        Me.lblStudentSelect.AutoSize = True
        Me.lblStudentSelect.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStudentSelect.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStudentSelect.Location = New System.Drawing.Point(16, 44)
        Me.lblStudentSelect.Name = "lblStudentSelect"
        Me.lblStudentSelect.Size = New System.Drawing.Size(95, 13)
        Me.lblStudentSelect.TabIndex = 2
        Me.lblStudentSelect.Text = "SELECT STUDENT"
        '
        'cmbStudent
        '
        Me.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStudent.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbStudent.FormattingEnabled = True
        Me.cmbStudent.Location = New System.Drawing.Point(16, 62)
        Me.cmbStudent.Name = "cmbStudent"
        Me.cmbStudent.Size = New System.Drawing.Size(332, 25)
        Me.cmbStudent.TabIndex = 3
        '
        'pnlStudentDivider
        '
        Me.pnlStudentDivider.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.pnlStudentDivider.Location = New System.Drawing.Point(16, 98)
        Me.pnlStudentDivider.Name = "pnlStudentDivider"
        Me.pnlStudentDivider.Size = New System.Drawing.Size(332, 1)
        Me.pnlStudentDivider.TabIndex = 4
        '
        'lblStuName
        '
        Me.lblStuName.AutoEllipsis = True
        Me.lblStuName.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblStuName.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblStuName.Location = New System.Drawing.Point(16, 108)
        Me.lblStuName.Name = "lblStuName"
        Me.lblStuName.Size = New System.Drawing.Size(332, 26)
        Me.lblStuName.TabIndex = 5
        Me.lblStuName.Text = "Select a student to preview."
        '
        'lblStuMeta
        '
        Me.lblStuMeta.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblStuMeta.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblStuMeta.Location = New System.Drawing.Point(16, 140)
        Me.lblStuMeta.Name = "lblStuMeta"
        Me.lblStuMeta.Size = New System.Drawing.Size(332, 112)
        Me.lblStuMeta.TabIndex = 6
        Me.lblStuMeta.Text = ""
        '
        'lblStuSports
        '
        Me.lblStuSports.AutoSize = True
        Me.lblStuSports.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStuSports.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStuSports.Location = New System.Drawing.Point(16, 256)
        Me.lblStuSports.Name = "lblStuSports"
        Me.lblStuSports.Size = New System.Drawing.Size(106, 13)
        Me.lblStuSports.TabIndex = 7
        Me.lblStuSports.Text = "SPORTS & RESULTS"
        '
        'dgvStudent
        '
        Me.dgvStudent.AllowUserToAddRows = False
        Me.dgvStudent.AllowUserToDeleteRows = False
        Me.dgvStudent.AllowUserToResizeRows = False
        Me.dgvStudent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStudent.BackgroundColor = System.Drawing.Color.White
        Me.dgvStudent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvStudent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvStudent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(253, 224, 71)
        dataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3
        Me.dgvStudent.ColumnHeadersHeight = 30
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        dataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254)
        dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStudent.DefaultCellStyle = dataGridViewCellStyle4
        Me.dgvStudent.EnableHeadersVisualStyles = False
        Me.dgvStudent.GridColor = System.Drawing.Color.FromArgb(218, 225, 234)
        Me.dgvStudent.Location = New System.Drawing.Point(16, 276)
        Me.dgvStudent.MultiSelect = False
        Me.dgvStudent.Name = "dgvStudent"
        Me.dgvStudent.ReadOnly = True
        Me.dgvStudent.RowHeadersVisible = False
        Me.dgvStudent.RowTemplate.Height = 26
        Me.dgvStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStudent.Size = New System.Drawing.Size(332, 110)
        Me.dgvStudent.TabIndex = 8
        '
        'btnStudentExport
        '
        Me.btnStudentExport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStudentExport.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.btnStudentExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStudentExport.FlatAppearance.BorderSize = 0
        Me.btnStudentExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStudentExport.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnStudentExport.ForeColor = System.Drawing.Color.White
        Me.btnStudentExport.Location = New System.Drawing.Point(16, 400)
        Me.btnStudentExport.Name = "btnStudentExport"
        Me.btnStudentExport.Size = New System.Drawing.Size(332, 40)
        Me.btnStudentExport.TabIndex = 9
        Me.btnStudentExport.Text = "⬇  Export Profile to Excel"
        Me.btnStudentExport.UseVisualStyleBackColor = False
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1060, 660)
        Me.Controls.Add(Me.pnlStudent)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.lblSummary)
        Me.Controls.Add(Me.pnlSelector)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmReports"
        Me.Text = "Reports"
        Me.pnlSelector.ResumeLayout(False)
        Me.pnlSelector.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStudent.ResumeLayout(False)
        Me.pnlStudent.PerformLayout()
        CType(Me.dgvStudent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents pnlStudent As System.Windows.Forms.Panel
    Friend WithEvents studentAccent As System.Windows.Forms.Panel
    Friend WithEvents lblStudentTitle As System.Windows.Forms.Label
    Friend WithEvents lblStudentSelect As System.Windows.Forms.Label
    Friend WithEvents cmbStudent As System.Windows.Forms.ComboBox
    Friend WithEvents pnlStudentDivider As System.Windows.Forms.Panel
    Friend WithEvents lblStuName As System.Windows.Forms.Label
    Friend WithEvents lblStuMeta As System.Windows.Forms.Label
    Friend WithEvents lblStuSports As System.Windows.Forms.Label
    Friend WithEvents dgvStudent As System.Windows.Forms.DataGridView
    Friend WithEvents btnStudentExport As System.Windows.Forms.Button
End Class
