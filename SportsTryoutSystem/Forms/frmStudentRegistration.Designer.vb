<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStudentRegistration
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlTopHeader = New System.Windows.Forms.Panel()
        Me.headerStripe = New System.Windows.Forms.Panel()
        Me.btnRegisterStudent = New System.Windows.Forms.Button()
        Me.lblHeaderSub = New System.Windows.Forms.Label()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.pnlToolbar = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSportFilter = New System.Windows.Forms.Label()
        Me.cmbFilterSport = New System.Windows.Forms.ComboBox()
        Me.lblStatusFilter = New System.Windows.Forms.Label()
        Me.cmbFilterStatus = New System.Windows.Forms.ComboBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.cardGrid = New System.Windows.Forms.Panel()
        Me.stripeGrid = New System.Windows.Forms.Panel()
        Me.dgvRegistrations = New System.Windows.Forms.DataGridView()

        Me.pnlTopHeader.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.cardGrid.SuspendLayout()
        CType(Me.dgvRegistrations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTopHeader
        '
        Me.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        Me.pnlTopHeader.Controls.Add(Me.headerStripe)
        Me.pnlTopHeader.Controls.Add(Me.btnRegisterStudent)
        Me.pnlTopHeader.Controls.Add(Me.lblHeaderSub)
        Me.pnlTopHeader.Controls.Add(Me.lblHeaderTitle)
        Me.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopHeader.Name = "pnlTopHeader"
        Me.pnlTopHeader.Size = New System.Drawing.Size(1150, 80)
        Me.pnlTopHeader.TabIndex = 0
        '
        'headerStripe
        '
        Me.headerStripe.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.headerStripe.Dock = System.Windows.Forms.DockStyle.Top
        Me.headerStripe.Location = New System.Drawing.Point(0, 0)
        Me.headerStripe.Name = "headerStripe"
        Me.headerStripe.Size = New System.Drawing.Size(1150, 4)
        Me.headerStripe.TabIndex = 0
        '
        'btnRegisterStudent
        '
        Me.btnRegisterStudent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegisterStudent.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnRegisterStudent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegisterStudent.FlatAppearance.BorderSize = 0
        Me.btnRegisterStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegisterStudent.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnRegisterStudent.ForeColor = System.Drawing.Color.White
        Me.btnRegisterStudent.Location = New System.Drawing.Point(920, 18)
        Me.btnRegisterStudent.Name = "btnRegisterStudent"
        Me.btnRegisterStudent.Size = New System.Drawing.Size(206, 44)
        Me.btnRegisterStudent.TabIndex = 3
        Me.btnRegisterStudent.Text = "✚  Register Student"
        Me.btnRegisterStudent.UseVisualStyleBackColor = False
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(185, 210, 240)
        Me.lblHeaderSub.Location = New System.Drawing.Point(26, 46)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(570, 19)
        Me.lblHeaderSub.TabIndex = 2
        Me.lblHeaderSub.Text = "Directory of registered student-athletes, tryout sport applications, and qualification statuses."
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(24, 14)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(370, 30)
        Me.lblHeaderTitle.TabIndex = 1
        Me.lblHeaderTitle.Text = "📝  Student Registration && Records"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.Color.White
        Me.pnlToolbar.Controls.Add(Me.lblSearch)
        Me.pnlToolbar.Controls.Add(Me.txtSearch)
        Me.pnlToolbar.Controls.Add(Me.lblSportFilter)
        Me.pnlToolbar.Controls.Add(Me.cmbFilterSport)
        Me.pnlToolbar.Controls.Add(Me.lblStatusFilter)
        Me.pnlToolbar.Controls.Add(Me.cmbFilterStatus)
        Me.pnlToolbar.Controls.Add(Me.btnRefresh)
        Me.pnlToolbar.Controls.Add(Me.lblRecordCount)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 80)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(1150, 56)
        Me.pnlToolbar.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblSearch.Location = New System.Drawing.Point(24, 17)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(25, 20)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "🔍"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.Location = New System.Drawing.Point(52, 15)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(220, 25)
        Me.txtSearch.TabIndex = 1
        '
        'lblSportFilter
        '
        Me.lblSportFilter.AutoSize = True
        Me.lblSportFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSportFilter.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSportFilter.Location = New System.Drawing.Point(286, 18)
        Me.lblSportFilter.Name = "lblSportFilter"
        Me.lblSportFilter.Size = New System.Drawing.Size(44, 17)
        Me.lblSportFilter.TabIndex = 2
        Me.lblSportFilter.Text = "Sport:"
        '
        'cmbFilterSport
        '
        Me.cmbFilterSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterSport.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbFilterSport.FormattingEnabled = True
        Me.cmbFilterSport.Location = New System.Drawing.Point(334, 15)
        Me.cmbFilterSport.Name = "cmbFilterSport"
        Me.cmbFilterSport.Size = New System.Drawing.Size(170, 24)
        Me.cmbFilterSport.TabIndex = 3
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.AutoSize = True
        Me.lblStatusFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblStatusFilter.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStatusFilter.Location = New System.Drawing.Point(516, 18)
        Me.lblStatusFilter.Name = "lblStatusFilter"
        Me.lblStatusFilter.Size = New System.Drawing.Size(49, 17)
        Me.lblStatusFilter.TabIndex = 4
        Me.lblStatusFilter.Text = "Status:"
        '
        'cmbFilterStatus
        '
        Me.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterStatus.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbFilterStatus.FormattingEnabled = True
        Me.cmbFilterStatus.Items.AddRange(New Object() {"All Statuses", "Pending", "Selected", "Not Selected", "For Further Evaluation"})
        Me.cmbFilterStatus.Location = New System.Drawing.Point(568, 15)
        Me.cmbFilterStatus.Name = "cmbFilterStatus"
        Me.cmbFilterStatus.Size = New System.Drawing.Size(155, 24)
        Me.cmbFilterStatus.TabIndex = 5
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.btnRefresh.Location = New System.Drawing.Point(734, 13)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 28)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "↺ Reset Filters"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecordCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblRecordCount.Location = New System.Drawing.Point(880, 18)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(246, 20)
        Me.lblRecordCount.TabIndex = 7
        Me.lblRecordCount.Text = "Showing 0 Registered Applicants"
        Me.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlBody
        '
        Me.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.pnlBody.Controls.Add(Me.cardGrid)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 136)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(24, 16, 24, 20)
        Me.pnlBody.Size = New System.Drawing.Size(1150, 604)
        Me.pnlBody.TabIndex = 2
        '
        'cardGrid
        '
        Me.cardGrid.BackColor = System.Drawing.Color.White
        Me.cardGrid.Controls.Add(Me.stripeGrid)
        Me.cardGrid.Controls.Add(Me.dgvRegistrations)
        Me.cardGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardGrid.Location = New System.Drawing.Point(24, 16)
        Me.cardGrid.Name = "cardGrid"
        Me.cardGrid.Size = New System.Drawing.Size(1102, 568)
        Me.cardGrid.TabIndex = 0
        '
        'stripeGrid
        '
        Me.stripeGrid.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.stripeGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.stripeGrid.Location = New System.Drawing.Point(0, 0)
        Me.stripeGrid.Name = "stripeGrid"
        Me.stripeGrid.Size = New System.Drawing.Size(1102, 3)
        Me.stripeGrid.TabIndex = 0
        '
        'dgvRegistrations
        '
        Me.dgvRegistrations.AllowUserToAddRows = False
        Me.dgvRegistrations.AllowUserToDeleteRows = False
        Me.dgvRegistrations.AllowUserToResizeRows = False
        Me.dgvRegistrations.BackgroundColor = System.Drawing.Color.White
        Me.dgvRegistrations.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRegistrations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvRegistrations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(212, 160, 23)
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(212, 160, 23)
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRegistrations.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRegistrations.ColumnHeadersHeight = 42
        Me.dgvRegistrations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(239, 246, 255)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(10, 30, 58)
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRegistrations.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRegistrations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRegistrations.EnableHeadersVisualStyles = False
        Me.dgvRegistrations.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgvRegistrations.Location = New System.Drawing.Point(0, 3)
        Me.dgvRegistrations.MultiSelect = False
        Me.dgvRegistrations.Name = "dgvRegistrations"
        Me.dgvRegistrations.ReadOnly = True
        Me.dgvRegistrations.RowHeadersVisible = False
        Me.dgvRegistrations.RowTemplate.Height = 42
        Me.dgvRegistrations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRegistrations.Size = New System.Drawing.Size(1102, 565)
        Me.dgvRegistrations.TabIndex = 1
        '
        'frmStudentRegistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1150, 740)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.pnlTopHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmStudentRegistration"
        Me.Text = "Student-Athlete Registration & Records"
        Me.pnlTopHeader.ResumeLayout(False)
        Me.pnlTopHeader.PerformLayout()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        Me.cardGrid.ResumeLayout(False)
        CType(Me.dgvRegistrations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTopHeader As System.Windows.Forms.Panel
    Friend WithEvents headerStripe As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents btnRegisterStudent As System.Windows.Forms.Button
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSportFilter As System.Windows.Forms.Label
    Friend WithEvents cmbFilterSport As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatusFilter As System.Windows.Forms.Label
    Friend WithEvents cmbFilterStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents cardGrid As System.Windows.Forms.Panel
    Friend WithEvents stripeGrid As System.Windows.Forms.Panel
    Friend WithEvents dgvRegistrations As System.Windows.Forms.DataGridView
End Class
