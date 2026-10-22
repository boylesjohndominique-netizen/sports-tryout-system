<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScheduleManagement
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
        Me.btnCreateSchedule = New System.Windows.Forms.Button()
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
        Me.dgvSchedules = New System.Windows.Forms.DataGridView()

        Me.pnlTopHeader.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.cardGrid.SuspendLayout()
        CType(Me.dgvSchedules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTopHeader
        '
        Me.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        Me.pnlTopHeader.Controls.Add(Me.headerStripe)
        Me.pnlTopHeader.Controls.Add(Me.btnCreateSchedule)
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
        'btnCreateSchedule
        '
        Me.btnCreateSchedule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateSchedule.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnCreateSchedule.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreateSchedule.FlatAppearance.BorderSize = 0
        Me.btnCreateSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateSchedule.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnCreateSchedule.ForeColor = System.Drawing.Color.White
        Me.btnCreateSchedule.Location = New System.Drawing.Point(920, 18)
        Me.btnCreateSchedule.Name = "btnCreateSchedule"
        Me.btnCreateSchedule.Size = New System.Drawing.Size(206, 44)
        Me.btnCreateSchedule.TabIndex = 3
        Me.btnCreateSchedule.Text = "✚  Create Schedule"
        Me.btnCreateSchedule.UseVisualStyleBackColor = False
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(185, 210, 240)
        Me.lblHeaderSub.Location = New System.Drawing.Point(26, 46)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(515, 19)
        Me.lblHeaderSub.TabIndex = 2
        Me.lblHeaderSub.Text = "Overview of tryout sessions, dates, venues, status tracking, and athletic evaluations."
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(24, 14)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(340, 30)
        Me.lblHeaderTitle.TabIndex = 1
        Me.lblHeaderTitle.Text = "📅  Tryout Schedule Management"
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
        Me.txtSearch.Size = New System.Drawing.Size(210, 25)
        Me.txtSearch.TabIndex = 1
        '
        'lblSportFilter
        '
        Me.lblSportFilter.AutoSize = True
        Me.lblSportFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSportFilter.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSportFilter.Location = New System.Drawing.Point(276, 18)
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
        Me.cmbFilterSport.Location = New System.Drawing.Point(324, 15)
        Me.cmbFilterSport.Name = "cmbFilterSport"
        Me.cmbFilterSport.Size = New System.Drawing.Size(175, 24)
        Me.cmbFilterSport.TabIndex = 3
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.AutoSize = True
        Me.lblStatusFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblStatusFilter.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStatusFilter.Location = New System.Drawing.Point(515, 18)
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
        Me.cmbFilterStatus.Items.AddRange(New Object() {"All Statuses", "Upcoming", "Completed", "Cancelled"})
        Me.cmbFilterStatus.Location = New System.Drawing.Point(568, 15)
        Me.cmbFilterStatus.Name = "cmbFilterStatus"
        Me.cmbFilterStatus.Size = New System.Drawing.Size(130, 24)
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
        Me.btnRefresh.Location = New System.Drawing.Point(712, 13)
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
        Me.lblRecordCount.Location = New System.Drawing.Point(920, 18)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(206, 20)
        Me.lblRecordCount.TabIndex = 7
        Me.lblRecordCount.Text = "Showing 0 Sessions"
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
        Me.cardGrid.Controls.Add(Me.dgvSchedules)
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
        'dgvSchedules
        '
        Me.dgvSchedules.AllowUserToAddRows = False
        Me.dgvSchedules.AllowUserToDeleteRows = False
        Me.dgvSchedules.AllowUserToResizeRows = False
        Me.dgvSchedules.BackgroundColor = System.Drawing.Color.White
        Me.dgvSchedules.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSchedules.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvSchedules.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(212, 160, 23)
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(212, 160, 23)
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSchedules.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSchedules.ColumnHeadersHeight = 42
        Me.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(239, 246, 255)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(10, 30, 58)
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSchedules.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSchedules.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSchedules.EnableHeadersVisualStyles = False
        Me.dgvSchedules.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgvSchedules.Location = New System.Drawing.Point(0, 3)
        Me.dgvSchedules.MultiSelect = False
        Me.dgvSchedules.Name = "dgvSchedules"
        Me.dgvSchedules.ReadOnly = True
        Me.dgvSchedules.RowHeadersVisible = False
        Me.dgvSchedules.RowTemplate.Height = 42
        Me.dgvSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSchedules.Size = New System.Drawing.Size(1102, 565)
        Me.dgvSchedules.TabIndex = 1
        '
        'frmScheduleManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1150, 740)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.pnlTopHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmScheduleManagement"
        Me.Text = "Tryout Schedule Management"
        Me.pnlTopHeader.ResumeLayout(False)
        Me.pnlTopHeader.PerformLayout()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        Me.cardGrid.ResumeLayout(False)
        CType(Me.dgvSchedules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTopHeader As System.Windows.Forms.Panel
    Friend WithEvents headerStripe As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents btnCreateSchedule As System.Windows.Forms.Button
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
    Friend WithEvents dgvSchedules As System.Windows.Forms.DataGridView
End Class
