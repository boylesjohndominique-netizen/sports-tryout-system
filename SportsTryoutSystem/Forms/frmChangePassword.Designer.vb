<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmChangePassword
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
        Me.pnlCard = New System.Windows.Forms.Panel()
        Me.cardAccent = New System.Windows.Forms.Panel()
        Me.lblIcon = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.pnlDivider = New System.Windows.Forms.Panel()
        Me.pnlLeftInfo = New System.Windows.Forms.Panel()
        Me.lblPolicyTitle = New System.Windows.Forms.Label()
        Me.pnlPolicyLine = New System.Windows.Forms.Panel()
        Me.lblReq1 = New System.Windows.Forms.Label()
        Me.lblReq2 = New System.Windows.Forms.Label()
        Me.lblReq3 = New System.Windows.Forms.Label()
        Me.lblReq4 = New System.Windows.Forms.Label()
        Me.pnlUserBadge = New System.Windows.Forms.Panel()
        Me.lblUserBadgeTitle = New System.Windows.Forms.Label()
        Me.lblUserInfo = New System.Windows.Forms.Label()
        Me.lblSecurityNotice = New System.Windows.Forms.Label()
        Me.lblCurrent = New System.Windows.Forms.Label()
        Me.pnlCurrentWrap = New System.Windows.Forms.Panel()
        Me.lblCurIco = New System.Windows.Forms.Label()
        Me.txtCurrent = New System.Windows.Forms.TextBox()
        Me.lblNew = New System.Windows.Forms.Label()
        Me.pnlNewWrap = New System.Windows.Forms.Panel()
        Me.lblNewIco = New System.Windows.Forms.Label()
        Me.txtNew = New System.Windows.Forms.TextBox()
        Me.lblConfirm = New System.Windows.Forms.Label()
        Me.pnlConfirmWrap = New System.Windows.Forms.Panel()
        Me.lblConfirmIco = New System.Windows.Forms.Label()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.chkShow = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblHint = New System.Windows.Forms.Label()
        Me.pnlCard.SuspendLayout()
        Me.pnlLeftInfo.SuspendLayout()
        Me.pnlUserBadge.SuspendLayout()
        Me.pnlCurrentWrap.SuspendLayout()
        Me.pnlNewWrap.SuspendLayout()
        Me.pnlConfirmWrap.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCard
        '
        Me.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlCard.BackColor = System.Drawing.Color.White
        Me.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCard.Controls.Add(Me.cardAccent)
        Me.pnlCard.Controls.Add(Me.lblIcon)
        Me.pnlCard.Controls.Add(Me.lblTitle)
        Me.pnlCard.Controls.Add(Me.lblSubtitle)
        Me.pnlCard.Controls.Add(Me.pnlDivider)
        Me.pnlCard.Controls.Add(Me.pnlLeftInfo)
        Me.pnlCard.Controls.Add(Me.lblCurrent)
        Me.pnlCard.Controls.Add(Me.pnlCurrentWrap)
        Me.pnlCard.Controls.Add(Me.lblNew)
        Me.pnlCard.Controls.Add(Me.pnlNewWrap)
        Me.pnlCard.Controls.Add(Me.lblConfirm)
        Me.pnlCard.Controls.Add(Me.pnlConfirmWrap)
        Me.pnlCard.Controls.Add(Me.chkShow)
        Me.pnlCard.Controls.Add(Me.btnSave)
        Me.pnlCard.Controls.Add(Me.btnClear)
        Me.pnlCard.Controls.Add(Me.lblHint)
        Me.pnlCard.Location = New System.Drawing.Point(40, 75)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New System.Drawing.Size(870, 540)
        Me.pnlCard.TabIndex = 1
        '
        'cardAccent
        '
        Me.cardAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.cardAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAccent.Location = New System.Drawing.Point(0, 0)
        Me.cardAccent.Name = "cardAccent"
        Me.cardAccent.Size = New System.Drawing.Size(868, 4)
        Me.cardAccent.TabIndex = 0
        '
        'lblIcon
        '
        Me.lblIcon.Font = New System.Drawing.Font("Segoe UI", 26.0!)
        Me.lblIcon.Location = New System.Drawing.Point(30, 16)
        Me.lblIcon.Name = "lblIcon"
        Me.lblIcon.Size = New System.Drawing.Size(50, 50)
        Me.lblIcon.TabIndex = 1
        Me.lblIcon.Text = "🔒"
        Me.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 17.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblTitle.Location = New System.Drawing.Point(86, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(315, 31)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "Account Security & Password"
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSubtitle.Location = New System.Drawing.Point(88, 48)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(437, 19)
        Me.lblSubtitle.TabIndex = 3
        Me.lblSubtitle.Text = "Update your login credentials to keep your portal access fully protected."
        '
        'pnlDivider
        '
        Me.pnlDivider.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.pnlDivider.Location = New System.Drawing.Point(30, 74)
        Me.pnlDivider.Name = "pnlDivider"
        Me.pnlDivider.Size = New System.Drawing.Size(810, 1)
        Me.pnlDivider.TabIndex = 4
        '
        'pnlLeftInfo
        '
        Me.pnlLeftInfo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlLeftInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeftInfo.Controls.Add(Me.lblPolicyTitle)
        Me.pnlLeftInfo.Controls.Add(Me.pnlPolicyLine)
        Me.pnlLeftInfo.Controls.Add(Me.lblReq1)
        Me.pnlLeftInfo.Controls.Add(Me.lblReq2)
        Me.pnlLeftInfo.Controls.Add(Me.lblReq3)
        Me.pnlLeftInfo.Controls.Add(Me.lblReq4)
        Me.pnlLeftInfo.Controls.Add(Me.pnlUserBadge)
        Me.pnlLeftInfo.Controls.Add(Me.lblSecurityNotice)
        Me.pnlLeftInfo.Location = New System.Drawing.Point(30, 90)
        Me.pnlLeftInfo.Name = "pnlLeftInfo"
        Me.pnlLeftInfo.Size = New System.Drawing.Size(345, 420)
        Me.pnlLeftInfo.TabIndex = 5
        '
        'lblPolicyTitle
        '
        Me.lblPolicyTitle.AutoSize = True
        Me.lblPolicyTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblPolicyTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblPolicyTitle.Location = New System.Drawing.Point(16, 16)
        Me.lblPolicyTitle.Name = "lblPolicyTitle"
        Me.lblPolicyTitle.Size = New System.Drawing.Size(183, 19)
        Me.lblPolicyTitle.TabIndex = 0
        Me.lblPolicyTitle.Text = "SECURITY REQUIREMENTS"
        '
        'pnlPolicyLine
        '
        Me.pnlPolicyLine.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.pnlPolicyLine.Location = New System.Drawing.Point(16, 40)
        Me.pnlPolicyLine.Name = "pnlPolicyLine"
        Me.pnlPolicyLine.Size = New System.Drawing.Size(48, 2)
        Me.pnlPolicyLine.TabIndex = 1
        '
        'lblReq1
        '
        Me.lblReq1.AutoSize = True
        Me.lblReq1.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblReq1.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblReq1.Location = New System.Drawing.Point(16, 52)
        Me.lblReq1.Name = "lblReq1"
        Me.lblReq1.Size = New System.Drawing.Size(193, 17)
        Me.lblReq1.TabIndex = 2
        Me.lblReq1.Text = "✔  Minimum 6 characters long"
        '
        'lblReq2
        '
        Me.lblReq2.AutoSize = True
        Me.lblReq2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblReq2.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblReq2.Location = New System.Drawing.Point(16, 80)
        Me.lblReq2.Name = "lblReq2"
        Me.lblReq2.Size = New System.Drawing.Size(242, 17)
        Me.lblReq2.TabIndex = 3
        Me.lblReq2.Text = "✔  Case-sensitive password matching"
        '
        'lblReq3
        '
        Me.lblReq3.AutoSize = True
        Me.lblReq3.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblReq3.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblReq3.Location = New System.Drawing.Point(16, 108)
        Me.lblReq3.Name = "lblReq3"
        Me.lblReq3.Size = New System.Drawing.Size(242, 17)
        Me.lblReq3.TabIndex = 4
        Me.lblReq3.Text = "✔  Letters, numbers && symbols allowed"
        '
        'lblReq4
        '
        Me.lblReq4.AutoSize = True
        Me.lblReq4.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblReq4.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblReq4.Location = New System.Drawing.Point(16, 136)
        Me.lblReq4.Name = "lblReq4"
        Me.lblReq4.Size = New System.Drawing.Size(236, 17)
        Me.lblReq4.TabIndex = 5
        Me.lblReq4.Text = "✔  Cannot match empty or blank value"
        '
        'pnlUserBadge
        '
        Me.pnlUserBadge.BackColor = System.Drawing.Color.FromArgb(239, 246, 255)
        Me.pnlUserBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUserBadge.Controls.Add(Me.lblUserBadgeTitle)
        Me.pnlUserBadge.Controls.Add(Me.lblUserInfo)
        Me.pnlUserBadge.Location = New System.Drawing.Point(16, 172)
        Me.pnlUserBadge.Name = "pnlUserBadge"
        Me.pnlUserBadge.Size = New System.Drawing.Size(310, 80)
        Me.pnlUserBadge.TabIndex = 6
        '
        'lblUserBadgeTitle
        '
        Me.lblUserBadgeTitle.AutoSize = True
        Me.lblUserBadgeTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblUserBadgeTitle.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175)
        Me.lblUserBadgeTitle.Location = New System.Drawing.Point(12, 10)
        Me.lblUserBadgeTitle.Name = "lblUserBadgeTitle"
        Me.lblUserBadgeTitle.Size = New System.Drawing.Size(155, 15)
        Me.lblUserBadgeTitle.TabIndex = 0
        Me.lblUserBadgeTitle.Text = "CURRENTLY SIGNED IN AS:"
        '
        'lblUserInfo
        '
        Me.lblUserInfo.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblUserInfo.Location = New System.Drawing.Point(12, 28)
        Me.lblUserInfo.Name = "lblUserInfo"
        Me.lblUserInfo.Size = New System.Drawing.Size(286, 44)
        Me.lblUserInfo.TabIndex = 1
        Me.lblUserInfo.Text = "User (Role)"
        '
        'lblSecurityNotice
        '
        Me.lblSecurityNotice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSecurityNotice.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSecurityNotice.Location = New System.Drawing.Point(16, 266)
        Me.lblSecurityNotice.Name = "lblSecurityNotice"
        Me.lblSecurityNotice.Size = New System.Drawing.Size(310, 140)
        Me.lblSecurityNotice.TabIndex = 7
        Me.lblSecurityNotice.Text = "ℹ  Security Notice:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "After changing your password, your new credentials will be required immediately for all future sign-ins. Always keep your password confidential and never share access."
        '
        'lblCurrent
        '
        Me.lblCurrent.AutoSize = True
        Me.lblCurrent.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblCurrent.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCurrent.Location = New System.Drawing.Point(405, 90)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(139, 17)
        Me.lblCurrent.TabIndex = 6
        Me.lblCurrent.Text = "CURRENT PASSWORD"
        '
        'pnlCurrentWrap
        '
        Me.pnlCurrentWrap.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlCurrentWrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCurrentWrap.Controls.Add(Me.lblCurIco)
        Me.pnlCurrentWrap.Controls.Add(Me.txtCurrent)
        Me.pnlCurrentWrap.Location = New System.Drawing.Point(405, 112)
        Me.pnlCurrentWrap.Name = "pnlCurrentWrap"
        Me.pnlCurrentWrap.Size = New System.Drawing.Size(435, 48)
        Me.pnlCurrentWrap.TabIndex = 7
        '
        'lblCurIco
        '
        Me.lblCurIco.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblCurIco.Location = New System.Drawing.Point(6, 4)
        Me.lblCurIco.Name = "lblCurIco"
        Me.lblCurIco.Size = New System.Drawing.Size(32, 40)
        Me.lblCurIco.TabIndex = 0
        Me.lblCurIco.Text = "🔑"
        Me.lblCurIco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCurrent
        '
        Me.txtCurrent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.txtCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCurrent.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.txtCurrent.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.txtCurrent.Location = New System.Drawing.Point(42, 13)
        Me.txtCurrent.Name = "txtCurrent"
        Me.txtCurrent.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtCurrent.Size = New System.Drawing.Size(382, 21)
        Me.txtCurrent.TabIndex = 1
        '
        'lblNew
        '
        Me.lblNew.AutoSize = True
        Me.lblNew.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblNew.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNew.Location = New System.Drawing.Point(405, 174)
        Me.lblNew.Name = "lblNew"
        Me.lblNew.Size = New System.Drawing.Size(110, 17)
        Me.lblNew.TabIndex = 8
        Me.lblNew.Text = "NEW PASSWORD"
        '
        'pnlNewWrap
        '
        Me.pnlNewWrap.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlNewWrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNewWrap.Controls.Add(Me.lblNewIco)
        Me.pnlNewWrap.Controls.Add(Me.txtNew)
        Me.pnlNewWrap.Location = New System.Drawing.Point(405, 196)
        Me.pnlNewWrap.Name = "pnlNewWrap"
        Me.pnlNewWrap.Size = New System.Drawing.Size(435, 48)
        Me.pnlNewWrap.TabIndex = 9
        '
        'lblNewIco
        '
        Me.lblNewIco.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblNewIco.Location = New System.Drawing.Point(6, 4)
        Me.lblNewIco.Name = "lblNewIco"
        Me.lblNewIco.Size = New System.Drawing.Size(32, 40)
        Me.lblNewIco.TabIndex = 0
        Me.lblNewIco.Text = "🔒"
        Me.lblNewIco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNew
        '
        Me.txtNew.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.txtNew.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNew.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.txtNew.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.txtNew.Location = New System.Drawing.Point(42, 13)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtNew.Size = New System.Drawing.Size(382, 21)
        Me.txtNew.TabIndex = 1
        '
        'lblConfirm
        '
        Me.lblConfirm.AutoSize = True
        Me.lblConfirm.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblConfirm.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblConfirm.Location = New System.Drawing.Point(405, 258)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(175, 17)
        Me.lblConfirm.TabIndex = 10
        Me.lblConfirm.Text = "CONFIRM NEW PASSWORD"
        '
        'pnlConfirmWrap
        '
        Me.pnlConfirmWrap.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlConfirmWrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlConfirmWrap.Controls.Add(Me.lblConfirmIco)
        Me.pnlConfirmWrap.Controls.Add(Me.txtConfirm)
        Me.pnlConfirmWrap.Location = New System.Drawing.Point(405, 280)
        Me.pnlConfirmWrap.Name = "pnlConfirmWrap"
        Me.pnlConfirmWrap.Size = New System.Drawing.Size(435, 48)
        Me.pnlConfirmWrap.TabIndex = 11
        '
        'lblConfirmIco
        '
        Me.lblConfirmIco.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblConfirmIco.Location = New System.Drawing.Point(6, 4)
        Me.lblConfirmIco.Name = "lblConfirmIco"
        Me.lblConfirmIco.Size = New System.Drawing.Size(32, 40)
        Me.lblConfirmIco.TabIndex = 0
        Me.lblConfirmIco.Text = "✔"
        Me.lblConfirmIco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtConfirm
        '
        Me.txtConfirm.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConfirm.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.txtConfirm.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.txtConfirm.Location = New System.Drawing.Point(42, 13)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtConfirm.Size = New System.Drawing.Size(382, 21)
        Me.txtConfirm.TabIndex = 1
        '
        'chkShow
        '
        Me.chkShow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkShow.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.chkShow.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.chkShow.Location = New System.Drawing.Point(407, 338)
        Me.chkShow.Name = "chkShow"
        Me.chkShow.Size = New System.Drawing.Size(430, 24)
        Me.chkShow.TabIndex = 12
        Me.chkShow.Text = "Show password characters"
        Me.chkShow.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(405, 372)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(292, 50)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Update Password  ➔"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnClear.Location = New System.Drawing.Point(707, 372)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(133, 50)
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'lblHint
        '
        Me.lblHint.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblHint.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblHint.Location = New System.Drawing.Point(405, 432)
        Me.lblHint.Name = "lblHint"
        Me.lblHint.Size = New System.Drawing.Size(435, 50)
        Me.lblHint.TabIndex = 15
        '
        'frmChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(960, 640)
        Me.Controls.Add(Me.pnlCard)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmChangePassword"
        Me.Text = "Change Password"
        Me.pnlCard.ResumeLayout(False)
        Me.pnlCard.PerformLayout()
        Me.pnlLeftInfo.ResumeLayout(False)
        Me.pnlLeftInfo.PerformLayout()
        Me.pnlUserBadge.ResumeLayout(False)
        Me.pnlUserBadge.PerformLayout()
        Me.pnlCurrentWrap.ResumeLayout(False)
        Me.pnlCurrentWrap.PerformLayout()
        Me.pnlNewWrap.ResumeLayout(False)
        Me.pnlNewWrap.PerformLayout()
        Me.pnlConfirmWrap.ResumeLayout(False)
        Me.pnlConfirmWrap.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCard As System.Windows.Forms.Panel
    Friend WithEvents cardAccent As System.Windows.Forms.Panel
    Friend WithEvents lblIcon As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    Friend WithEvents pnlDivider As System.Windows.Forms.Panel
    Friend WithEvents pnlLeftInfo As System.Windows.Forms.Panel
    Friend WithEvents lblPolicyTitle As System.Windows.Forms.Label
    Friend WithEvents pnlPolicyLine As System.Windows.Forms.Panel
    Friend WithEvents lblReq1 As System.Windows.Forms.Label
    Friend WithEvents lblReq2 As System.Windows.Forms.Label
    Friend WithEvents lblReq3 As System.Windows.Forms.Label
    Friend WithEvents lblReq4 As System.Windows.Forms.Label
    Friend WithEvents pnlUserBadge As System.Windows.Forms.Panel
    Friend WithEvents lblUserBadgeTitle As System.Windows.Forms.Label
    Friend WithEvents lblUserInfo As System.Windows.Forms.Label
    Friend WithEvents lblSecurityNotice As System.Windows.Forms.Label
    Friend WithEvents lblCurrent As System.Windows.Forms.Label
    Friend WithEvents pnlCurrentWrap As System.Windows.Forms.Panel
    Friend WithEvents lblCurIco As System.Windows.Forms.Label
    Friend WithEvents txtCurrent As System.Windows.Forms.TextBox
    Friend WithEvents lblNew As System.Windows.Forms.Label
    Friend WithEvents pnlNewWrap As System.Windows.Forms.Panel
    Friend WithEvents lblNewIco As System.Windows.Forms.Label
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirm As System.Windows.Forms.Label
    Friend WithEvents pnlConfirmWrap As System.Windows.Forms.Panel
    Friend WithEvents lblConfirmIco As System.Windows.Forms.Label
    Friend WithEvents txtConfirm As System.Windows.Forms.TextBox
    Friend WithEvents chkShow As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lblHint As System.Windows.Forms.Label
End Class
