<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmApplicantRecords
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
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.filterAccent = New System.Windows.Forms.Panel()
        Me.lblFilterTitle = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtSearchName = New System.Windows.Forms.TextBox()
        Me.lblId = New System.Windows.Forms.Label()
        Me.txtSearchStudentNumber = New System.Windows.Forms.TextBox()
        Me.lblSport = New System.Windows.Forms.Label()
        Me.cmbFilterSport = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbFilterStatus = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.btnViewDetails = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.pnlFilter.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlFilter
        '
        Me.pnlFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilter.BackColor = System.Drawing.Color.White
        Me.pnlFilter.Controls.Add(Me.filterAccent)
        Me.pnlFilter.Controls.Add(Me.lblFilterTitle)
        Me.pnlFilter.Controls.Add(Me.lblName)
        Me.pnlFilter.Controls.Add(Me.txtSearchName)
        Me.pnlFilter.Controls.Add(Me.lblId)
        Me.pnlFilter.Controls.Add(Me.txtSearchStudentNumber)
        Me.pnlFilter.Controls.Add(Me.lblSport)
        Me.pnlFilter.Controls.Add(Me.cmbFilterSport)
        Me.pnlFilter.Controls.Add(Me.lblStatus)
        Me.pnlFilter.Controls.Add(Me.cmbFilterStatus)
        Me.pnlFilter.Controls.Add(Me.btnSearch)
        Me.pnlFilter.Controls.Add(Me.btnClearFilter)
        Me.pnlFilter.Location = New System.Drawing.Point(30, 75)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(950, 105)
        Me.pnlFilter.TabIndex = 0
        '
        'filterAccent
        '
        Me.filterAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.filterAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.filterAccent.Location = New System.Drawing.Point(0, 0)
        Me.filterAccent.Name = "filterAccent"
        Me.filterAccent.Size = New System.Drawing.Size(950, 3)
        Me.filterAccent.TabIndex = 0
        '
        'lblFilterTitle
        '
        Me.lblFilterTitle.AutoSize = True
        Me.lblFilterTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblFilterTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblFilterTitle.Location = New System.Drawing.Point(20, 10)
        Me.lblFilterTitle.Name = "lblFilterTitle"
        Me.lblFilterTitle.Size = New System.Drawing.Size(147, 21)
        Me.lblFilterTitle.TabIndex = 1
        Me.lblFilterTitle.Text = "🔍  Search & Filter"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblName.Location = New System.Drawing.Point(20, 38)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "NAME"
        '
        'txtSearchName
        '
        Me.txtSearchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchName.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtSearchName.Location = New System.Drawing.Point(20, 56)
        Me.txtSearchName.Name = "txtSearchName"
        Me.txtSearchName.Size = New System.Drawing.Size(180, 24)
        Me.txtSearchName.TabIndex = 3
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblId.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblId.Location = New System.Drawing.Point(210, 38)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(68, 13)
        Me.lblId.TabIndex = 4
        Me.lblId.Text = "STUDENT ID"
        '
        'txtSearchStudentNumber
        '
        Me.txtSearchStudentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchStudentNumber.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtSearchStudentNumber.Location = New System.Drawing.Point(210, 56)
        Me.txtSearchStudentNumber.Name = "txtSearchStudentNumber"
        Me.txtSearchStudentNumber.Size = New System.Drawing.Size(160, 24)
        Me.txtSearchStudentNumber.TabIndex = 5
        '
        'lblSport
        '
        Me.lblSport.AutoSize = True
        Me.lblSport.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSport.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSport.Location = New System.Drawing.Point(380, 38)
        Me.lblSport.Name = "lblSport"
        Me.lblSport.Size = New System.Drawing.Size(41, 13)
        Me.lblSport.TabIndex = 6
        Me.lblSport.Text = "SPORT"
        '
        'cmbFilterSport
        '
        Me.cmbFilterSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterSport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterSport.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbFilterSport.FormattingEnabled = True
        Me.cmbFilterSport.Location = New System.Drawing.Point(380, 56)
        Me.cmbFilterSport.Name = "cmbFilterSport"
        Me.cmbFilterSport.Size = New System.Drawing.Size(175, 24)
        Me.cmbFilterSport.TabIndex = 7
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStatus.Location = New System.Drawing.Point(565, 38)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(107, 13)
        Me.lblStatus.TabIndex = 8
        Me.lblStatus.Text = "SELECTION STATUS"
        '
        'cmbFilterStatus
        '
        Me.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterStatus.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbFilterStatus.FormattingEnabled = True
        Me.cmbFilterStatus.Items.AddRange(New Object() {"All", "Pending", "Selected", "NotSelected", "ForFurtherEvaluation"})
        Me.cmbFilterStatus.Location = New System.Drawing.Point(565, 56)
        Me.cmbFilterStatus.Name = "cmbFilterStatus"
        Me.cmbFilterStatus.Size = New System.Drawing.Size(155, 24)
        Me.cmbFilterStatus.TabIndex = 9
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(730, 53)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnClearFilter
        '
        Me.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.btnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearFilter.FlatAppearance.BorderSize = 0
        Me.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnClearFilter.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnClearFilter.Location = New System.Drawing.Point(838, 53)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(90, 30)
        Me.btnClearFilter.TabIndex = 11
        Me.btnClearFilter.Text = "Clear"
        Me.btnClearFilter.UseVisualStyleBackColor = False
        '
        'btnViewDetails
        '
        Me.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.btnViewDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewDetails.FlatAppearance.BorderSize = 0
        Me.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewDetails.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnViewDetails.ForeColor = System.Drawing.Color.FromArgb(14, 38, 72)
        Me.btnViewDetails.Location = New System.Drawing.Point(30, 192)
        Me.btnViewDetails.Name = "btnViewDetails"
        Me.btnViewDetails.Size = New System.Drawing.Size(160, 34)
        Me.btnViewDetails.TabIndex = 1
        Me.btnViewDetails.Text = "📋 View Details"
        Me.btnViewDetails.UseVisualStyleBackColor = False
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
        Me.dgv.Location = New System.Drawing.Point(30, 235)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 30
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(950, 345)
        Me.dgv.TabIndex = 2
        '
        'frmApplicantRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1020, 600)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.btnViewDetails)
        Me.Controls.Add(Me.pnlFilter)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmApplicantRecords"
        Me.Text = "Applicant Records"
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents filterAccent As System.Windows.Forms.Panel
    Friend WithEvents lblFilterTitle As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtSearchName As System.Windows.Forms.TextBox
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtSearchStudentNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblSport As System.Windows.Forms.Label
    Friend WithEvents cmbFilterSport As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmbFilterStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClearFilter As System.Windows.Forms.Button
    Friend WithEvents btnViewDetails As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
End Class
