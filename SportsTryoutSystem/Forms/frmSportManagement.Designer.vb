<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSportManagement
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
        Me.btnCreateSport = New System.Windows.Forms.Button()
        Me.lblHeaderSub = New System.Windows.Forms.Label()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.pnlToolbar = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblStatusFilter = New System.Windows.Forms.Label()
        Me.cmbStatusFilter = New System.Windows.Forms.ComboBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.cardGrid = New System.Windows.Forms.Panel()
        Me.stripeGrid = New System.Windows.Forms.Panel()
        Me.dgvSports = New System.Windows.Forms.DataGridView()

        Me.pnlTopHeader.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.cardGrid.SuspendLayout()
        CType(Me.dgvSports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTopHeader
        '
        Me.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        Me.pnlTopHeader.Controls.Add(Me.headerStripe)
        Me.pnlTopHeader.Controls.Add(Me.btnCreateSport)
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
        'btnCreateSport
        '
        Me.btnCreateSport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateSport.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnCreateSport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreateSport.FlatAppearance.BorderSize = 0
        Me.btnCreateSport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateSport.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnCreateSport.ForeColor = System.Drawing.Color.White
        Me.btnCreateSport.Location = New System.Drawing.Point(936, 18)
        Me.btnCreateSport.Name = "btnCreateSport"
        Me.btnCreateSport.Size = New System.Drawing.Size(190, 44)
        Me.btnCreateSport.TabIndex = 3
        Me.btnCreateSport.Text = "✚  Create Sport"
        Me.btnCreateSport.UseVisualStyleBackColor = False
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(185, 210, 240)
        Me.lblHeaderSub.Location = New System.Drawing.Point(26, 46)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(526, 19)
        Me.lblHeaderSub.TabIndex = 2
        Me.lblHeaderSub.Text = "Manage sports disciplines, tryout availability, coach assignments, and participant counts."
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(24, 14)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(342, 30)
        Me.lblHeaderTitle.TabIndex = 1
        Me.lblHeaderTitle.Text = "🏆  Sport Disciplines Management"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.Color.White
        Me.pnlToolbar.Controls.Add(Me.lblSearch)
        Me.pnlToolbar.Controls.Add(Me.txtSearch)
        Me.pnlToolbar.Controls.Add(Me.lblStatusFilter)
        Me.pnlToolbar.Controls.Add(Me.cmbStatusFilter)
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
        Me.txtSearch.Size = New System.Drawing.Size(260, 25)
        Me.txtSearch.TabIndex = 1
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.AutoSize = True
        Me.lblStatusFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatusFilter.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStatusFilter.Location = New System.Drawing.Point(335, 20)
        Me.lblStatusFilter.Name = "lblStatusFilter"
        Me.lblStatusFilter.Size = New System.Drawing.Size(43, 15)
        Me.lblStatusFilter.TabIndex = 2
        Me.lblStatusFilter.Text = "Status:"
        '
        'cmbStatusFilter
        '
        Me.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatusFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStatusFilter.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbStatusFilter.FormattingEnabled = True
        Me.cmbStatusFilter.Items.AddRange(New Object() {"All Status", "Active Only", "Inactive Only"})
        Me.cmbStatusFilter.Location = New System.Drawing.Point(384, 15)
        Me.cmbStatusFilter.Name = "cmbStatusFilter"
        Me.cmbStatusFilter.Size = New System.Drawing.Size(140, 25)
        Me.cmbStatusFilter.TabIndex = 3
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnRefresh.Location = New System.Drawing.Point(542, 14)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(95, 28)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "↺  Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'lblRecordCount
        '
        Me.lblRecordCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRecordCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblRecordCount.Location = New System.Drawing.Point(880, 18)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(246, 20)
        Me.lblRecordCount.TabIndex = 5
        Me.lblRecordCount.Text = "Showing 0 Sports"
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
        Me.pnlBody.Size = New System.Drawing.Size(1150, 564)
        Me.pnlBody.TabIndex = 2
        '
        'cardGrid
        '
        Me.cardGrid.BackColor = System.Drawing.Color.White
        Me.cardGrid.Controls.Add(Me.stripeGrid)
        Me.cardGrid.Controls.Add(Me.dgvSports)
        Me.cardGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardGrid.Location = New System.Drawing.Point(24, 16)
        Me.cardGrid.Name = "cardGrid"
        Me.cardGrid.Size = New System.Drawing.Size(1102, 528)
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
        'dgvSports
        '
        Me.dgvSports.AllowUserToAddRows = False
        Me.dgvSports.AllowUserToDeleteRows = False
        Me.dgvSports.AllowUserToResizeRows = False
        Me.dgvSports.BackgroundColor = System.Drawing.Color.White
        Me.dgvSports.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvSports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(253, 224, 71)
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSports.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSports.ColumnHeadersHeight = 42
        Me.dgvSports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSports.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSports.EnableHeadersVisualStyles = False
        Me.dgvSports.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgvSports.Location = New System.Drawing.Point(0, 3)
        Me.dgvSports.MultiSelect = False
        Me.dgvSports.Name = "dgvSports"
        Me.dgvSports.ReadOnly = True
        Me.dgvSports.RowHeadersVisible = False
        Me.dgvSports.RowTemplate.Height = 42
        Me.dgvSports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSports.Size = New System.Drawing.Size(1102, 525)
        Me.dgvSports.TabIndex = 1
        '
        'frmSportManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1150, 700)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.pnlTopHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSportManagement"
        Me.Text = "Sport Management"
        Me.pnlTopHeader.ResumeLayout(False)
        Me.pnlTopHeader.PerformLayout()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        Me.cardGrid.ResumeLayout(False)
        CType(Me.dgvSports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTopHeader As System.Windows.Forms.Panel
    Friend WithEvents headerStripe As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents btnCreateSport As System.Windows.Forms.Button
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblStatusFilter As System.Windows.Forms.Label
    Friend WithEvents cmbStatusFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents cardGrid As System.Windows.Forms.Panel
    Friend WithEvents stripeGrid As System.Windows.Forms.Panel
    Friend WithEvents dgvSports As System.Windows.Forms.DataGridView

End Class
