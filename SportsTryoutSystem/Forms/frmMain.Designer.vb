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
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.btnLogoutTop = New System.Windows.Forms.Button()
        Me.pnlNav = New System.Windows.Forms.Panel()
        Me.pnlSideHeader = New System.Windows.Forms.Panel()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.lblAdminSection = New System.Windows.Forms.Label()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.btnCreateAccount = New System.Windows.Forms.Button()
        Me.btnSports = New System.Windows.Forms.Button()
        Me.lblOpsSection = New System.Windows.Forms.Label()
        Me.btnSchedules = New System.Windows.Forms.Button()
        Me.btnRegistration = New System.Windows.Forms.Button()
        Me.lblRecordsSection = New System.Windows.Forms.Label()
        Me.btnApplicants = New System.Windows.Forms.Button()
        Me.btnEvaluation = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.lblAccountSection = New System.Windows.Forms.Label()
        Me.btnChangePassword = New System.Windows.Forms.Button()

        Me.pnlTop.SuspendLayout()
        Me.pnlNav.SuspendLayout()
        Me.pnlSideHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.pnlTop.Controls.Add(Me.btnLogoutTop)
        Me.pnlTop.Controls.Add(Me.lblRole)
        Me.pnlTop.Controls.Add(Me.lblUser)
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
        'lblUser
        '
        Me.lblUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(950, 21)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(91, 17)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "Administrator"
        '
        'lblRole
        '
        Me.lblRole.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRole.AutoSize = True
        Me.lblRole.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.lblRole.Font = New System.Drawing.Font("Segoe UI Semibold", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRole.ForeColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.lblRole.Location = New System.Drawing.Point(1055, 23)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Padding = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.lblRole.Size = New System.Drawing.Size(51, 16)
        Me.lblRole.TabIndex = 3
        Me.lblRole.Text = " ADMIN "
        '
        'btnLogoutTop
        '
        Me.btnLogoutTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogoutTop.BackColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnLogoutTop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogoutTop.FlatAppearance.BorderSize = 0
        Me.btnLogoutTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogoutTop.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogoutTop.ForeColor = System.Drawing.Color.White
        Me.btnLogoutTop.Location = New System.Drawing.Point(1170, 14)
        Me.btnLogoutTop.Name = "btnLogoutTop"
        Me.btnLogoutTop.Size = New System.Drawing.Size(95, 32)
        Me.btnLogoutTop.TabIndex = 4
        Me.btnLogoutTop.Text = "Sign Out"
        Me.btnLogoutTop.UseVisualStyleBackColor = False
        '
        'pnlNav
        '
        Me.pnlNav.AutoScroll = True
        Me.pnlNav.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.pnlNav.Controls.Add(Me.btnChangePassword)
        Me.pnlNav.Controls.Add(Me.lblAccountSection)
        Me.pnlNav.Controls.Add(Me.btnReports)
        Me.pnlNav.Controls.Add(Me.btnEvaluation)
        Me.pnlNav.Controls.Add(Me.btnApplicants)
        Me.pnlNav.Controls.Add(Me.lblRecordsSection)
        Me.pnlNav.Controls.Add(Me.btnRegistration)
        Me.pnlNav.Controls.Add(Me.btnSchedules)
        Me.pnlNav.Controls.Add(Me.lblOpsSection)
        Me.pnlNav.Controls.Add(Me.btnSports)
        Me.pnlNav.Controls.Add(Me.btnCreateAccount)
        Me.pnlNav.Controls.Add(Me.btnUsers)
        Me.pnlNav.Controls.Add(Me.lblAdminSection)
        Me.pnlNav.Controls.Add(Me.btnDashboard)
        Me.pnlNav.Controls.Add(Me.pnlSideHeader)
        Me.pnlNav.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlNav.Location = New System.Drawing.Point(0, 58)
        Me.pnlNav.Name = "pnlNav"
        Me.pnlNav.Size = New System.Drawing.Size(240, 653)
        Me.pnlNav.TabIndex = 1
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
        'btnCreateAccount
        '
        Me.btnCreateAccount.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.btnCreateAccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreateAccount.FlatAppearance.BorderSize = 0
        Me.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateAccount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateAccount.ForeColor = System.Drawing.Color.FromArgb(190, 210, 235)
        Me.btnCreateAccount.Location = New System.Drawing.Point(0, 169)
        Me.btnCreateAccount.Name = "btnCreateAccount"
        Me.btnCreateAccount.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnCreateAccount.Size = New System.Drawing.Size(240, 42)
        Me.btnCreateAccount.TabIndex = 4
        Me.btnCreateAccount.Text = "➕  Create Account"
        Me.btnCreateAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateAccount.UseVisualStyleBackColor = False
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
        'lblAccountSection
        '
        Me.lblAccountSection.AutoSize = True
        Me.lblAccountSection.Font = New System.Drawing.Font("Segoe UI Semibold", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountSection.ForeColor = System.Drawing.Color.FromArgb(100, 140, 180)
        Me.lblAccountSection.Location = New System.Drawing.Point(20, 493)
        Me.lblAccountSection.Name = "lblAccountSection"
        Me.lblAccountSection.Size = New System.Drawing.Size(56, 12)
        Me.lblAccountSection.TabIndex = 12
        Me.lblAccountSection.Text = "ACCOUNT"
        '
        'btnChangePassword
        '
        Me.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChangePassword.FlatAppearance.BorderSize = 0
        Me.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangePassword.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(190, 210, 235)
        Me.btnChangePassword.Location = New System.Drawing.Point(0, 511)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.btnChangePassword.Size = New System.Drawing.Size(240, 42)
        Me.btnChangePassword.TabIndex = 13
        Me.btnChangePassword.Text = "🔒  Change Password"
        Me.btnChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChangePassword.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1284, 711)
        Me.Controls.Add(Me.pnlNav)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sports Tryout Management System"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlNav.ResumeLayout(False)
        Me.pnlNav.PerformLayout()
        Me.pnlSideHeader.ResumeLayout(False)
        Me.pnlSideHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents topStripe As System.Windows.Forms.Panel
    Friend WithEvents lblBrand As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents btnLogoutTop As System.Windows.Forms.Button
    Friend WithEvents pnlNav As System.Windows.Forms.Panel
    Friend WithEvents pnlSideHeader As System.Windows.Forms.Panel
    Friend WithEvents lblMenu As System.Windows.Forms.Label
    Friend WithEvents btnDashboard As System.Windows.Forms.Button
    Friend WithEvents lblAdminSection As System.Windows.Forms.Label
    Friend WithEvents btnUsers As System.Windows.Forms.Button
    Friend WithEvents btnCreateAccount As System.Windows.Forms.Button
    Friend WithEvents btnSports As System.Windows.Forms.Button
    Friend WithEvents lblOpsSection As System.Windows.Forms.Label
    Friend WithEvents btnSchedules As System.Windows.Forms.Button
    Friend WithEvents btnRegistration As System.Windows.Forms.Button
    Friend WithEvents lblRecordsSection As System.Windows.Forms.Label
    Friend WithEvents btnApplicants As System.Windows.Forms.Button
    Friend WithEvents btnEvaluation As System.Windows.Forms.Button
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents lblAccountSection As System.Windows.Forms.Label
    Friend WithEvents btnChangePassword As System.Windows.Forms.Button


End Class
