<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
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
        Me.pnlLeft = New SportsTryoutSystem.DoubleBufferedPanel()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.pnlWindowControls = New System.Windows.Forms.Panel()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlCard = New System.Windows.Forms.Panel()
        Me.cardTopStripe = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.pnlDiv = New System.Windows.Forms.Panel()
        Me.lblUserTitle = New System.Windows.Forms.Label()
        Me.pnlUserWrap = New System.Windows.Forms.Panel()
        Me.lblUserIco = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblPassTitle = New System.Windows.Forms.Label()
        Me.pnlPassWrap = New System.Windows.Forms.Panel()
        Me.lblPassIco = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pnlRight.SuspendLayout()
        Me.pnlWindowControls.SuspendLayout()
        Me.pnlCard.SuspendLayout()
        Me.pnlUserWrap.SuspendLayout()
        Me.pnlPassWrap.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLeft
        '
        Me.pnlLeft.BackColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(560, 700)
        Me.pnlLeft.TabIndex = 0
        '
        'pnlRight
        '
        Me.pnlRight.BackColor = System.Drawing.Color.FromArgb(248, 250, 253)
        Me.pnlRight.Controls.Add(Me.pnlWindowControls)
        Me.pnlRight.Controls.Add(Me.pnlCard)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRight.Location = New System.Drawing.Point(560, 0)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(540, 700)
        Me.pnlRight.TabIndex = 1
        '
        'pnlWindowControls
        '
        Me.pnlWindowControls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlWindowControls.BackColor = System.Drawing.Color.Transparent
        Me.pnlWindowControls.Controls.Add(Me.btnMinimize)
        Me.pnlWindowControls.Controls.Add(Me.btnClose)
        Me.pnlWindowControls.Location = New System.Drawing.Point(432, 10)
        Me.pnlWindowControls.Name = "pnlWindowControls"
        Me.pnlWindowControls.Size = New System.Drawing.Size(96, 38)
        Me.pnlWindowControls.TabIndex = 0
        '
        'btnMinimize
        '
        Me.btnMinimize.BackColor = System.Drawing.Color.FromArgb(235, 240, 248)
        Me.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMinimize.FlatAppearance.BorderSize = 0
        Me.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimize.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95)
        Me.btnMinimize.Location = New System.Drawing.Point(4, 3)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(42, 32)
        Me.btnMinimize.TabIndex = 0
        Me.btnMinimize.Text = "—"
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(235, 240, 248)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95)
        Me.btnClose.Location = New System.Drawing.Point(50, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(42, 32)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "✕"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'pnlCard
        '
        Me.pnlCard.BackColor = System.Drawing.Color.White
        Me.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCard.Controls.Add(Me.cardTopStripe)
        Me.pnlCard.Controls.Add(Me.lblTitle)
        Me.pnlCard.Controls.Add(Me.lblSubtitle)
        Me.pnlCard.Controls.Add(Me.pnlDiv)
        Me.pnlCard.Controls.Add(Me.lblUserTitle)
        Me.pnlCard.Controls.Add(Me.pnlUserWrap)
        Me.pnlCard.Controls.Add(Me.lblPassTitle)
        Me.pnlCard.Controls.Add(Me.pnlPassWrap)
        Me.pnlCard.Controls.Add(Me.chkShowPassword)
        Me.pnlCard.Controls.Add(Me.btnLogin)
        Me.pnlCard.Controls.Add(Me.lblStatus)
        Me.pnlCard.Location = New System.Drawing.Point(60, 80)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New System.Drawing.Size(540, 620)
        Me.pnlCard.TabIndex = 1
        '
        'cardTopStripe
        '
        Me.cardTopStripe.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.cardTopStripe.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardTopStripe.Location = New System.Drawing.Point(0, 0)
        Me.cardTopStripe.Name = "cardTopStripe"
        Me.cardTopStripe.Size = New System.Drawing.Size(538, 4)
        Me.cardTopStripe.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 26.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblTitle.Location = New System.Drawing.Point(0, 90)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(540, 46)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Welcome Back"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSubtitle
        '
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSubtitle.Location = New System.Drawing.Point(0, 142)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(540, 24)
        Me.lblSubtitle.TabIndex = 2
        Me.lblSubtitle.Text = "Sign in to your account"
        Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDiv
        '
        Me.pnlDiv.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.pnlDiv.Location = New System.Drawing.Point(238, 182)
        Me.pnlDiv.Name = "pnlDiv"
        Me.pnlDiv.Size = New System.Drawing.Size(64, 3)
        Me.pnlDiv.TabIndex = 3
        '
        'lblUserTitle
        '
        Me.lblUserTitle.AutoSize = True
        Me.lblUserTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUserTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblUserTitle.Location = New System.Drawing.Point(60, 214)
        Me.lblUserTitle.Name = "lblUserTitle"
        Me.lblUserTitle.Size = New System.Drawing.Size(66, 15)
        Me.lblUserTitle.TabIndex = 4
        Me.lblUserTitle.Text = "USERNAME"
        '
        'pnlUserWrap
        '
        Me.pnlUserWrap.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlUserWrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUserWrap.Controls.Add(Me.lblUserIco)
        Me.pnlUserWrap.Controls.Add(Me.txtUsername)
        Me.pnlUserWrap.Location = New System.Drawing.Point(60, 236)
        Me.pnlUserWrap.Name = "pnlUserWrap"
        Me.pnlUserWrap.Size = New System.Drawing.Size(420, 56)
        Me.pnlUserWrap.TabIndex = 5
        '
        'lblUserIco
        '
        Me.lblUserIco.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblUserIco.Location = New System.Drawing.Point(0, 0)
        Me.lblUserIco.Name = "lblUserIco"
        Me.lblUserIco.Size = New System.Drawing.Size(46, 56)
        Me.lblUserIco.TabIndex = 0
        Me.lblUserIco.Text = "👤"
        Me.lblUserIco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtUsername.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.txtUsername.Location = New System.Drawing.Point(48, 17)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(360, 22)
        Me.txtUsername.TabIndex = 1
        '
        'lblPassTitle
        '
        Me.lblPassTitle.AutoSize = True
        Me.lblPassTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPassTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblPassTitle.Location = New System.Drawing.Point(60, 312)
        Me.lblPassTitle.Name = "lblPassTitle"
        Me.lblPassTitle.Size = New System.Drawing.Size(68, 15)
        Me.lblPassTitle.TabIndex = 6
        Me.lblPassTitle.Text = "PASSWORD"
        '
        'pnlPassWrap
        '
        Me.pnlPassWrap.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlPassWrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPassWrap.Controls.Add(Me.lblPassIco)
        Me.pnlPassWrap.Controls.Add(Me.txtPassword)
        Me.pnlPassWrap.Location = New System.Drawing.Point(60, 334)
        Me.pnlPassWrap.Name = "pnlPassWrap"
        Me.pnlPassWrap.Size = New System.Drawing.Size(420, 56)
        Me.pnlPassWrap.TabIndex = 7
        '
        'lblPassIco
        '
        Me.lblPassIco.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblPassIco.Location = New System.Drawing.Point(0, 0)
        Me.lblPassIco.Name = "lblPassIco"
        Me.lblPassIco.Size = New System.Drawing.Size(46, 56)
        Me.lblPassIco.TabIndex = 0
        Me.lblPassIco.Text = "🔒"
        Me.lblPassIco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtPassword.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.txtPassword.Location = New System.Drawing.Point(48, 17)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.Size = New System.Drawing.Size(360, 22)
        Me.txtPassword.TabIndex = 1
        '
        'chkShowPassword
        '
        Me.chkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkShowPassword.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.chkShowPassword.Location = New System.Drawing.Point(62, 406)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(416, 22)
        Me.chkShowPassword.TabIndex = 8
        Me.chkShowPassword.Text = "Show password"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(37, 80, 140)
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(60, 448)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(420, 56)
        Me.btnLogin.TabIndex = 9
        Me.btnLogin.Text = "SIGN IN"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblStatus.Location = New System.Drawing.Point(60, 514)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(420, 34)
        Me.lblStatus.TabIndex = 10
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1100, 700)
        Me.Controls.Add(Me.pnlRight)
        Me.Controls.Add(Me.pnlLeft)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sports Tryout Management System - Login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlRight.ResumeLayout(False)
        Me.pnlWindowControls.ResumeLayout(False)
        Me.pnlCard.ResumeLayout(False)
        Me.pnlCard.PerformLayout()
        Me.pnlUserWrap.ResumeLayout(False)
        Me.pnlUserWrap.PerformLayout()
        Me.pnlPassWrap.ResumeLayout(False)
        Me.pnlPassWrap.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlLeft As SportsTryoutSystem.DoubleBufferedPanel
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlWindowControls As System.Windows.Forms.Panel
    Friend WithEvents btnMinimize As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pnlCard As System.Windows.Forms.Panel
    Friend WithEvents cardTopStripe As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    Friend WithEvents pnlDiv As System.Windows.Forms.Panel
    Friend WithEvents lblUserTitle As System.Windows.Forms.Label
    Friend WithEvents pnlUserWrap As System.Windows.Forms.Panel
    Friend WithEvents lblUserIco As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblPassTitle As System.Windows.Forms.Label
    Friend WithEvents pnlPassWrap As System.Windows.Forms.Panel
    Friend WithEvents lblPassIco As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
End Class
