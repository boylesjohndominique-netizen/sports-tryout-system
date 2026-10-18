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
        Me.pnlSelector.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlSelector.Location = New System.Drawing.Point(30, 75)
        Me.pnlSelector.Name = "pnlSelector"
        Me.pnlSelector.Size = New System.Drawing.Size(950, 76)
        Me.pnlSelector.TabIndex = 0
        '
        'selectorAccent
        '
        Me.selectorAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.selectorAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.selectorAccent.Location = New System.Drawing.Point(0, 0)
        Me.selectorAccent.Name = "selectorAccent"
        Me.selectorAccent.Size = New System.Drawing.Size(950, 3)
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
        Me.cmbReportType.Location = New System.Drawing.Point(20, 32)
        Me.cmbReportType.Name = "cmbReportType"
        Me.cmbReportType.Size = New System.Drawing.Size(330, 24)
        Me.cmbReportType.TabIndex = 2
        '
        'lblSportLabel
        '
        Me.lblSportLabel.AutoSize = True
        Me.lblSportLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSportLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSportLabel.Location = New System.Drawing.Point(370, 12)
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
        Me.cmbFilterSport.Location = New System.Drawing.Point(370, 32)
        Me.cmbFilterSport.Name = "cmbFilterSport"
        Me.cmbFilterSport.Size = New System.Drawing.Size(250, 24)
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
        Me.btnGenerate.Location = New System.Drawing.Point(640, 29)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(140, 30)
        Me.btnGenerate.TabIndex = 5
        Me.btnGenerate.Text = "📊 Generate"
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
        Me.btnExport.Location = New System.Drawing.Point(790, 29)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(140, 30)
        Me.btnExport.TabIndex = 6
        Me.btnExport.Text = "📁 Export CSV"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSummary.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblSummary.Location = New System.Drawing.Point(30, 160)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(0, 17)
        Me.lblSummary.TabIndex = 1
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
        Me.dgv.Location = New System.Drawing.Point(30, 188)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 30
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(950, 390)
        Me.dgv.TabIndex = 2
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1020, 600)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.lblSummary)
        Me.Controls.Add(Me.pnlSelector)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmReports"
        Me.Text = "Reports"
        Me.pnlSelector.ResumeLayout(False)
        Me.pnlSelector.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
