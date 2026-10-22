<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.topStripe = New System.Windows.Forms.Panel()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.pnlPills = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblDatePill = New System.Windows.Forms.Label()
        Me.lblPendingPill = New System.Windows.Forms.Label()
        Me.lblSelectedPill = New System.Windows.Forms.Label()
        Me.pnlProfileBtn = New System.Windows.Forms.Panel()
        Me.pbProfileAvatar = New System.Windows.Forms.PictureBox()
        Me.lblProfileUser = New System.Windows.Forms.Label()
        Me.lblProfileRole = New System.Windows.Forms.Label()
        Me.lblProfileArrow = New System.Windows.Forms.Label()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.pnlSideBottom = New System.Windows.Forms.Panel()
        Me.pnlSideBottomSep = New System.Windows.Forms.Panel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.pnlNav = New System.Windows.Forms.Panel()
        Me.pnlSideHeader = New System.Windows.Forms.Panel()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.lblAdminSection = New System.Windows.Forms.Label()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.btnSports = New System.Windows.Forms.Button()
        Me.lblOpsSection = New System.Windows.Forms.Label()
        Me.btnSchedules = New System.Windows.Forms.Button()
        Me.btnRegistration = New System.Windows.Forms.Button()
        Me.lblRecordsSection = New System.Windows.Forms.Label()
        Me.btnApplicants = New System.Windows.Forms.Button()
        Me.btnEvaluation = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()

        Me.pnlTop.SuspendLayout()
        Me.pnlPills.SuspendLayout()
        Me.pnlProfileBtn.SuspendLayout()
        CType(Me.pbProfileAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSidebar.SuspendLayout()
        Me.pnlSideBottom.SuspendLayout()
        Me.pnlNav.SuspendLayout()
        Me.pnlSideHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.pnlTop.Controls.Add(Me.pnlProfileBtn)
        Me.pnlTop.Controls.Add(Me.pnlPills)
        Me.pnlTop.Controls.Add(Me.lblBrand)
        Me.pnlTop.Controls.Add(Me.topStripe)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1284, 58)
        Me.pnlTop.TabIndex = 0
        '
        'topStripe
        '
        Me.topStripe.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.topStripe.Dock = System.Windows.Forms.DockStyle.Top
        Me.topStripe.Location = New System.Drawing.Point(0, 0)
        Me.topStripe.Name = "topStripe"
        Me.topStripe.Size = New System.Drawing.Size(1284, 3)
        Me.topStripe.TabIndex = 0
        '
        'lblBrand
        '
        Me.lblBrand.AutoSize = True
        Me.lblBrand.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrand.ForeColor = System.Drawing.Color.White
        Me.lblBrand.Location = New System.Drawing.Point(20, 18)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(288, 21)
        Me.lblBrand.TabIndex = 1
        Me.lblBrand.Text = "⚽  Sports Tryout Management System"
        '
        'pnlProfileBtn
        '
        Me.pnlProfileBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlProfileBtn.BackColor = System.Drawing.Color.FromArgb(16, 42, 76)
        Me.pnlProfileBtn.Controls.Add(Me.lblProfileArrow)
        Me.pnlProfileBtn.Controls.Add(Me.lblProfileRole)
        Me.pnlProfileBtn.Controls.Add(Me.lblProfileUser)
        Me.pnlProfileBtn.Controls.Add(Me.pbProfileAvatar)
        Me.pnlProfileBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlProfileBtn.Location = New System.Drawing.Point(1040, 10)
        Me.pnlProfileBtn.Name = "pnlProfileBtn"
        Me.pnlProfileBtn.Size = New System.Drawing.Size(225, 38)
        Me.pnlProfileBtn.TabIndex = 2
        '
        'pbProfileAvatar
        '
        Me.pbProfileAvatar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbProfileAvatar.Location = New System.Drawing.Point(6, 5)
        Me.pbProfileAvatar.Name = "pbProfileAvatar"
        Me.pbProfileAvatar.Size = New System.Drawing.Size(28, 28)
        Me.pbProfileAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbProfileAvatar.TabIndex = 0
        Me.pbProfileAvatar.TabStop = False
        '
        'lblProfileUser
        '
        Me.lblProfileUser.AutoSize = True
        Me.lblProfileUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblProfileUser.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblProfileUser.ForeColor = System.Drawing.Color.White
        Me.lblProfileUser.Location = New System.Drawing.Point(38, 11)
        Me.lblProfileUser.Name = "lblProfileUser"
        Me.lblProfileUser.Size = New System.Drawing.Size(81, 15)
        Me.lblProfileUser.TabIndex = 1
        Me.lblProfileUser.Text = "Administrator"
        '
        'lblProfileRole
        '
        Me.lblProfileRole.AutoSize = True
        Me.lblProfileRole.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.lblProfileRole.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblProfileRole.Font = New System.Drawing.Font("Segoe UI Semibold", 7.0!, System.Drawing.FontStyle.Bold)
        Me.lblProfileRole.ForeColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.lblProfileRole.Location = New System.Drawing.Point(125, 13)
        Me.lblProfileRole.Name = "lblProfileRole"
        Me.lblProfileRole.Padding = New System.Windows.Forms.Padding(4, 1, 4, 1)
        Me.lblProfileRole.Size = New System.Drawing.Size(46, 14)
        Me.lblProfileRole.TabIndex = 2
        Me.lblProfileRole.Text = " ADMIN "
        '
        'lblProfileArrow
        '
        Me.lblProfileArrow.AutoSize = True
        Me.lblProfileArrow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblProfileArrow.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblProfileArrow.ForeColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.lblProfileArrow.Location = New System.Drawing.Point(178, 11)
        Me.lblProfileArrow.Name = "lblProfileArrow"
        Me.lblProfileArrow.Size = New System.Drawing.Size(18, 15)
        Me.lblProfileArrow.TabIndex = 3
        Me.lblProfileArrow.Text = "⚙"
        '
        'pnlPills
        '
        Me.pnlPills.AutoSize = True
        Me.pnlPills.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlPills.BackColor = System.Drawing.Color.Transparent
        Me.pnlPills.Controls.Add(Me.lblDatePill)
        Me.pnlPills.Controls.Add(Me.lblPendingPill)
        Me.pnlPills.Controls.Add(Me.lblSelectedPill)
        Me.pnlPills.Location = New System.Drawing.Point(325, 15)
        Me.pnlPills.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlPills.Name = "pnlPills"
        Me.pnlPills.Padding = New System.Windows.Forms.Padding(0)
        Me.pnlPills.Size = New System.Drawing.Size(420, 27)
        Me.pnlPills.TabIndex = 4
        Me.pnlPills.WrapContents = False
        '
        'lblDatePill
        '
        Me.lblDatePill.AutoSize = True
        Me.lblDatePill.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDatePill.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblDatePill.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.lblDatePill.Location = New System.Drawing.Point(0, 0)
        Me.lblDatePill.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblDatePill.Name = "lblDatePill"
        Me.lblDatePill.Padding = New System.Windows.Forms.Padding(9, 3, 9, 3)
        Me.lblDatePill.Size = New System.Drawing.Size(107, 21)
        Me.lblDatePill.TabIndex = 0
        Me.lblDatePill.Text = "October 22, 2026"
        '
        'lblPendingPill
        '
        Me.lblPendingPill.AutoSize = True
        Me.lblPendingPill.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.lblPendingPill.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPendingPill.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblPendingPill.ForeColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.lblPendingPill.Location = New System.Drawing.Point(115, 0)
        Me.lblPendingPill.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblPendingPill.Name = "lblPendingPill"
        Me.lblPendingPill.Padding = New System.Windows.Forms.Padding(9, 3, 9, 3)
        Me.lblPendingPill.Size = New System.Drawing.Size(142, 21)
        Me.lblPendingPill.TabIndex = 1
        Me.lblPendingPill.Text = "● 0 Pending Decisions"
        '
        'lblSelectedPill
        '
        Me.lblSelectedPill.AutoSize = True
        Me.lblSelectedPill.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblSelectedPill.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSelectedPill.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSelectedPill.ForeColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.lblSelectedPill.Location = New System.Drawing.Point(265, 0)
        Me.lblSelectedPill.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSelectedPill.Padding = New System.Windows.Forms.Padding(9, 3, 9, 3)
        Me.lblSelectedPill.Size = New System.Drawing.Size(95, 21)
        Me.lblSelectedPill.TabIndex = 2
        Me.lblSelectedPill.Text = "✓ 0 Selected"
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.pnlSidebar.Controls.Add(Me.pnlNav)
        Me.pnlSidebar.Controls.Add(Me.pnlSideBottom)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 58)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(240, 653)
        Me.pnlSidebar.TabIndex = 1
        '
        'pnlSideBottom
        '
        Me.pnlSideBottom.BackColor = System.Drawing.Color.FromArgb(10, 26, 50)
        Me.pnlSideBottom.Controls.Add(Me.btnLogout)
        Me.pnlSideBottom.Controls.Add(Me.pnlSideBottomSep)
        Me.pnlSideBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSideBottom.Location = New System.Drawing.Point(0, 593)
        Me.pnlSideBottom.Name = "pnlSideBottom"
        Me.pnlSideBottom.Size = New System.Drawing.Size(240, 60)
        Me.pnlSideBottom.TabIndex = 1
        '
        'pnlSideBottomSep
        '
        Me.pnlSideBottomSep.BackColor = System.Drawing.Color.FromArgb(25, 55, 95)
        Me.pnlSideBottomSep.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSideBottomSep.Location = New System.Drawing.Point(0, 0)
        Me.pnlSideBottomSep.Name = "pnlSideBottomSep"
        Me.pnlSideBottomSep.Size = New System.Drawing.Size(240, 1)
        Me.pnlSideBottomSep.TabIndex = 0
        '
        'btnLogout
        '
        Me.btnLogout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(14, 11)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(212, 38)
        Me.btnLogout.TabIndex = 1
        Me.btnLogout.Text = "🚪  Sign Out"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'pnlNav
        '
        Me.pnlNav.AutoScroll = True
        Me.pnlNav.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.pnlNav.Controls.Add(Me.btnReports)
        Me.pnlNav.Controls.Add(Me.btnEvaluation)
        Me.pnlNav.Controls.Add(Me.lblRecordsSection)
        Me.pnlNav.Controls.Add(Me.btnRegistration)
        Me.pnlNav.Controls.Add(Me.btnSchedules)
        Me.pnlNav.Controls.Add(Me.lblOpsSection)
        Me.pnlNav.Controls.Add(Me.btnSports)
        Me.pnlNav.Controls.Add(Me.btnUsers)
        Me.pnlNav.Controls.Add(Me.lblAdminSection)
        Me.pnlNav.Controls.Add(Me.btnDashboard)
        Me.pnlNav.Controls.Add(Me.pnlSideHeader)
        Me.pnlNav.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNav.Location = New System.Drawing.Point(0, 0)
        Me.pnlNav.Name = "pnlNav"
        Me.pnlNav.Size = New System.Drawing.Size(240, 593)
        Me.pnlNav.TabIndex = 0
        '
        'pnlSideHeader
        '
        Me.pnlSideHeader.BackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        Me.pnlSideHeader.Controls.Add(Me.lblMenu)
        Me.pnlSideHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSideHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlSideHeader.Name = "pnlSideHeader"
        Me.pnlSideHeader.Size = New System.Drawing.Size(240, 50)
        Me.pnlSideHeader.TabIndex = 0
        '
        'lblMenu
        '
        Me.lblMenu.AutoSize = True
        Me.lblMenu.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenu.ForeColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.lblMenu.Location = New System.Drawing.Point(20, 18)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.Size = New System.Drawing.Size(73, 13)
        Me.lblMenu.TabIndex = 0
        Me.lblMenu.Text = "NAVIGATION"
        '
        'btnDashboard
        '
        Me.btnDashboard.BackColor = System.Drawing.Color.FromArgb(25, 55, 95)
        Me.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDashboard.FlatAppearance.BorderSize = 0
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21)
        Me.btnDashboard.Location = New System.Drawing.Point(0, 55)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnDashboard.Size = New System.Drawing.Size(240, 42)
        Me.btnDashboard.TabIndex = 1
        Me.btnDashboard.Text = "📊  Dashboard"
        Me.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashboard.UseVisualStyleBackColor = False
        '
        'lblAdminSection
        '
        Me.lblAdminSection.AutoSize = True
        Me.lblAdminSection.Font = New System.Drawing.Font("Segoe UI Semibold", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdminSection.ForeColor = System.Drawing.Color.FromArgb(100, 140, 180)
        Me.lblAdminSection.Location = New System.Drawing.Point(20, 107)
        Me.lblAdminSection.Name = "lblAdminSection"
        Me.lblAdminSection.Size = New System.Drawing.Size(91, 12)
        Me.lblAdminSection.TabIndex = 2
        Me.lblAdminSection.Text = "ADMINISTRATION"
        '
        'btnUsers
        '
        Me.btnUsers.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUsers.FlatAppearance.BorderSize = 0
        Me.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsers.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUsers.ForeColor = System.Drawing.Color.FromArgb(190, 210, 235)
        Me.btnUsers.Location = New System.Drawing.Point(0, 125)
        Me.btnUsers.Name = "btnUsers"
        Me.btnUsers.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnUsers.Size = New System.Drawing.Size(240, 42)
        Me.btnUsers.TabIndex = 3
        Me.btnUsers.Text = "👥  User Accounts"
        Me.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUsers.UseVisualStyleBackColor = False
        '
        'btnSports
        '
        Me.btnSports.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.btnSports.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSports.FlatAppearance.BorderSize = 0
        Me.btnSports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSports.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSports.ForeColor = System.Drawing.Color.FromArgb(190, 210, 235)
        Me.btnSports.Location = New System.Drawing.Point(0, 169)
        Me.btnSports.Name = "btnSports"
        Me.btnSports.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnSports.Size = New System.Drawing.Size(240, 42)
        Me.btnSports.TabIndex = 4
        Me.btnSports.Text = "🏅  Sport Management"
        Me.btnSports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSports.UseVisualStyleBackColor = False
        '
        'lblOpsSection
        '
        Me.lblOpsSection.AutoSize = True
        Me.lblOpsSection.Font = New System.Drawing.Font("Segoe UI Semibold", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpsSection.ForeColor = System.Drawing.Color.FromArgb(100, 140, 180)
        Me.lblOpsSection.Location = New System.Drawing.Point(20, 221)
        Me.lblOpsSection.Name = "lblOpsSection"
        Me.lblOpsSection.Size = New System.Drawing.Size(107, 12)
        Me.lblOpsSection.TabIndex = 5
        Me.lblOpsSection.Text = "TRYOUT OPERATIONS"
        '
        'btnSchedules
        '
        Me.btnSchedules.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.btnSchedules.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSchedules.FlatAppearance.BorderSize = 0
        Me.btnSchedules.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSchedules.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSchedules.ForeColor = System.Drawing.Color.FromArgb(190, 210, 235)
        Me.btnSchedules.Location = New System.Drawing.Point(0, 239)
        Me.btnSchedules.Name = "btnSchedules"
        Me.btnSchedules.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnSchedules.Size = New System.Drawing.Size(240, 42)
        Me.btnSchedules.TabIndex = 6
        Me.btnSchedules.Text = "📅  Tryout Schedules"
        Me.btnSchedules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSchedules.UseVisualStyleBackColor = False
        '
        'btnRegistration
        '
        Me.btnRegistration.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.btnRegistration.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegistration.FlatAppearance.BorderSize = 0
        Me.btnRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegistration.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistration.ForeColor = System.Drawing.Color.FromArgb(190, 210, 235)
        Me.btnRegistration.Location = New System.Drawing.Point(0, 283)
        Me.btnRegistration.Name = "btnRegistration"
        Me.btnRegistration.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnRegistration.Size = New System.Drawing.Size(240, 42)
        Me.btnRegistration.TabIndex = 7
        Me.btnRegistration.Text = "📝  Student Registration"
        Me.btnRegistration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRegistration.UseVisualStyleBackColor = False
        '
        'lblRecordsSection
        '
        Me.lblRecordsSection.AutoSize = True
        Me.lblRecordsSection.Font = New System.Drawing.Font("Segoe UI Semibold", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordsSection.ForeColor = System.Drawing.Color.FromArgb(100, 140, 180)
        Me.lblRecordsSection.Location = New System.Drawing.Point(20, 335)
        Me.lblRecordsSection.Name = "lblRecordsSection"
        Me.lblRecordsSection.Size = New System.Drawing.Size(103, 12)
        Me.lblRecordsSection.TabIndex = 8
        Me.lblRecordsSection.Text = "RECORDS & RESULTS"
        '
        'btnApplicants
        '
        Me.btnApplicants.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.btnApplicants.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplicants.FlatAppearance.BorderSize = 0
        Me.btnApplicants.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApplicants.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApplicants.ForeColor = System.Drawing.Color.FromArgb(190, 210, 235)
        Me.btnApplicants.Location = New System.Drawing.Point(0, 353)
        Me.btnApplicants.Name = "btnApplicants"
        Me.btnApplicants.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnApplicants.Size = New System.Drawing.Size(240, 42)
        Me.btnApplicants.TabIndex = 9
        Me.btnApplicants.Text = "📋  Applicant Records"
        Me.btnApplicants.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApplicants.UseVisualStyleBackColor = False
        '
        'btnEvaluation
        '
        Me.btnEvaluation.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.btnEvaluation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEvaluation.FlatAppearance.BorderSize = 0
        Me.btnEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEvaluation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEvaluation.ForeColor = System.Drawing.Color.FromArgb(190, 210, 235)
        Me.btnEvaluation.Location = New System.Drawing.Point(0, 397)
        Me.btnEvaluation.Name = "btnEvaluation"
        Me.btnEvaluation.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnEvaluation.Size = New System.Drawing.Size(240, 42)
        Me.btnEvaluation.TabIndex = 10
        Me.btnEvaluation.Text = "⭐  Evaluation && Selection"
        Me.btnEvaluation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEvaluation.UseVisualStyleBackColor = False
        '
        'btnReports
        '
        Me.btnReports.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.btnReports.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReports.FlatAppearance.BorderSize = 0
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.ForeColor = System.Drawing.Color.FromArgb(190, 210, 235)
        Me.btnReports.Location = New System.Drawing.Point(0, 441)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnReports.Size = New System.Drawing.Size(240, 42)
        Me.btnReports.TabIndex = 11
        Me.btnReports.Text = "📈  Reports"
        Me.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReports.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1284, 711)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sports Tryout Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlPills.ResumeLayout(False)
        Me.pnlPills.PerformLayout()
        Me.pnlProfileBtn.ResumeLayout(False)
        Me.pnlProfileBtn.PerformLayout()
        CType(Me.pbProfileAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSideBottom.ResumeLayout(False)
        Me.pnlNav.ResumeLayout(False)
        Me.pnlNav.PerformLayout()
        Me.pnlSideHeader.ResumeLayout(False)
        Me.pnlSideHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents topStripe As System.Windows.Forms.Panel
    Friend WithEvents lblBrand As System.Windows.Forms.Label
    Friend WithEvents pnlPills As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblDatePill As System.Windows.Forms.Label
    Friend WithEvents lblPendingPill As System.Windows.Forms.Label
    Friend WithEvents lblSelectedPill As System.Windows.Forms.Label
    Friend WithEvents pnlProfileBtn As System.Windows.Forms.Panel
    Friend WithEvents pbProfileAvatar As System.Windows.Forms.PictureBox
    Friend WithEvents lblProfileUser As System.Windows.Forms.Label
    Friend WithEvents lblProfileRole As System.Windows.Forms.Label
    Friend WithEvents lblProfileArrow As System.Windows.Forms.Label
    Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
    Friend WithEvents pnlSideBottom As System.Windows.Forms.Panel
    Friend WithEvents pnlSideBottomSep As System.Windows.Forms.Panel
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents pnlNav As System.Windows.Forms.Panel
    Friend WithEvents pnlSideHeader As System.Windows.Forms.Panel
    Friend WithEvents lblMenu As System.Windows.Forms.Label
    Friend WithEvents btnDashboard As System.Windows.Forms.Button
    Friend WithEvents lblAdminSection As System.Windows.Forms.Label
    Friend WithEvents btnUsers As System.Windows.Forms.Button
    Friend WithEvents btnSports As System.Windows.Forms.Button
    Friend WithEvents lblOpsSection As System.Windows.Forms.Label
    Friend WithEvents btnSchedules As System.Windows.Forms.Button
    Friend WithEvents btnRegistration As System.Windows.Forms.Button
    Friend WithEvents lblRecordsSection As System.Windows.Forms.Label
    Friend WithEvents btnApplicants As System.Windows.Forms.Button
    Friend WithEvents btnEvaluation As System.Windows.Forms.Button
    Friend WithEvents btnReports As System.Windows.Forms.Button

End Class
