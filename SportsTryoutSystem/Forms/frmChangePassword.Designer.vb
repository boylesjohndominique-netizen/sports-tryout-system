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
        Me.pnlLeftInfo = New System.Windows.Forms.Panel()
        Me.lblPolicyTitle = New System.Windows.Forms.Label()
        Me.pnlPolicyLine = New System.Windows.Forms.Panel()
        Me.lblReq1 = New System.Windows.Forms.Label()
        Me.lblReq2 = New System.Windows.Forms.Label()
        Me.lblReq3 = New System.Windows.Forms.Label()
        Me.pnlUserBadge = New System.Windows.Forms.Panel()
        Me.lblUserBadgeTitle = New System.Windows.Forms.Label()
        Me.lblUserInfo = New System.Windows.Forms.Label()
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
        Me.pnlCard.BackColor = System.Drawing.Color.White
        Me.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCard.Controls.Add(Me.cardAccent)
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
        Me.pnlCard.Location = New System.Drawing.Point(24, 84)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New System.Drawing.Size(952, 552)
        Me.pnlCard.TabIndex = 0
        '
        'cardAccent
        '
        Me.cardAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.cardAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAccent.Location = New System.Drawing.Point(0, 0)
        Me.cardAccent.Name = "cardAccent"
        Me.cardAccent.Size = New System.Drawing.Size(950, 4)
        Me.cardAccent.TabIndex = 0
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
        Me.pnlLeftInfo.Controls.Add(Me.pnlUserBadge)
        Me.pnlLeftInfo.Location = New System.Drawing.Point(28, 28)
        Me.pnlLeftInfo.Name = "pnlLeftInfo"
        Me.pnlLeftInfo.Size = New System.Drawing.Size(310, 496)
        Me.pnlLeftInfo.TabIndex = 1
        '
        'lblPolicyTitle
        '
        Me.lblPolicyTitle.AutoSize = True
        Me.lblPolicyTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblPolicyTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblPolicyTitle.Location = New System.Drawing.Point(16, 18)
        Me.lblPolicyTitle.Name = "lblPolicyTitle"
        Me.lblPolicyTitle.Size = New System.Drawing.Size(108, 19)
        Me.lblPolicyTitle.TabIndex = 0
        Me.lblPolicyTitle.Text = "PASSWORD TIPS"
        '
        'pnlPolicyLine
        '
        Me.pnlPolicyLine.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.pnlPolicyLine.Location = New System.Drawing.Point(16, 44)
        Me.pnlPolicyLine.Name = "pnlPolicyLine"
        Me.pnlPolicyLine.Size = New System.Drawing.Size(48, 2)
        Me.pnlPolicyLine.TabIndex = 1
        '
        'lblReq1
        '
        Me.lblReq1.AutoSize = True
        Me.lblReq1.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblReq1.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblReq1.Location = New System.Drawing.Point(16, 62)
        Me.lblReq1.Name = "lblReq1"
        Me.lblReq1.Size = New System.Drawing.Size(163, 17)
        Me.lblReq1.TabIndex = 2
        Me.lblReq1.Text = "•  Use at least 6 characters"
        '
        'lblReq2
        '
        Me.lblReq2.AutoSize = True
        Me.lblReq2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblReq2.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblReq2.Location = New System.Drawing.Point(16, 92)
        Me.lblReq2.Name = "lblReq2"
        Me.lblReq2.Size = New System.Drawing.Size(224, 17)
        Me.lblReq2.TabIndex = 3
        Me.lblReq2.Text = "•  Mix letters, numbers && symbols"
        '
        'lblReq3
        '
        Me.lblReq3.AutoSize = True
        Me.lblReq3.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblReq3.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblReq3.Location = New System.Drawing.Point(16, 122)
        Me.lblReq3.Name = "lblReq3"
        Me.lblReq3.Size = New System.Drawing.Size(196, 17)
        Me.lblReq3.TabIndex = 4
        Me.lblReq3.Text = "•  Never share your password"
        '
        'pnlUserBadge
        '
        Me.pnlUserBadge.BackColor = System.Drawing.Color.FromArgb(239, 246, 255)
        Me.pnlUserBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUserBadge.Controls.Add(Me.lblUserBadgeTitle)
        Me.pnlUserBadge.Controls.Add(Me.lblUserInfo)
        Me.pnlUserBadge.Location = New System.Drawing.Point(16, 402)
        Me.pnlUserBadge.Name = "pnlUserBadge"
        Me.pnlUserBadge.Size = New System.Drawing.Size(278, 78)
        Me.pnlUserBadge.TabIndex = 5
        '
        'lblUserBadgeTitle
        '
        Me.lblUserBadgeTitle.AutoSize = True
        Me.lblUserBadgeTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblUserBadgeTitle.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175)
        Me.lblUserBadgeTitle.Location = New System.Drawing.Point(12, 10)
        Me.lblUserBadgeTitle.Name = "lblUserBadgeTitle"
        Me.lblUserBadgeTitle.Size = New System.Drawing.Size(90, 15)
        Me.lblUserBadgeTitle.TabIndex = 0
        Me.lblUserBadgeTitle.Text = "SIGNED IN AS"
        '
        'lblUserInfo
        '
        Me.lblUserInfo.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblUserInfo.Location = New System.Drawing.Point(12, 30)
        Me.lblUserInfo.Name = "lblUserInfo"
        Me.lblUserInfo.Size = New System.Drawing.Size(254, 40)
        Me.lblUserInfo.TabIndex = 1
        Me.lblUserInfo.Text = "User"
        '
        'lblCurrent
        '
        Me.lblCurrent.AutoSize = True
        Me.lblCurrent.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblCurrent.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCurrent.Location = New System.Drawing.Point(378, 32)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(139, 17)
        Me.lblCurrent.TabIndex = 2
        Me.lblCurrent.Text = "CURRENT PASSWORD"
        '
        'pnlCurrentWrap
        '
        Me.pnlCurrentWrap.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlCurrentWrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCurrentWrap.Controls.Add(Me.lblCurIco)
        Me.pnlCurrentWrap.Controls.Add(Me.txtCurrent)
        Me.pnlCurrentWrap.Location = New System.Drawing.Point(378, 54)
        Me.pnlCurrentWrap.Name = "pnlCurrentWrap"
        Me.pnlCurrentWrap.Size = New System.Drawing.Size(548, 46)
        Me.pnlCurrentWrap.TabIndex = 3
        '
        'lblCurIco
        '
        Me.lblCurIco.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblCurIco.Location = New System.Drawing.Point(8, 4)
        Me.lblCurIco.Name = "lblCurIco"
        Me.lblCurIco.Size = New System.Drawing.Size(34, 38)
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
        Me.txtCurrent.Location = New System.Drawing.Point(48, 12)
        Me.txtCurrent.Name = "txtCurrent"
        Me.txtCurrent.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtCurrent.Size = New System.Drawing.Size(488, 21)
        Me.txtCurrent.TabIndex = 1
        '
        'lblNew
        '
        Me.lblNew.AutoSize = True
        Me.lblNew.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblNew.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNew.Location = New System.Drawing.Point(378, 122)
        Me.lblNew.Name = "lblNew"
        Me.lblNew.Size = New System.Drawing.Size(110, 17)
        Me.lblNew.TabIndex = 4
        Me.lblNew.Text = "NEW PASSWORD"
        '
        'pnlNewWrap
        '
        Me.pnlNewWrap.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlNewWrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNewWrap.Controls.Add(Me.lblNewIco)
        Me.pnlNewWrap.Controls.Add(Me.txtNew)
        Me.pnlNewWrap.Location = New System.Drawing.Point(378, 144)
        Me.pnlNewWrap.Name = "pnlNewWrap"
        Me.pnlNewWrap.Size = New System.Drawing.Size(548, 46)
        Me.pnlNewWrap.TabIndex = 5
        '
        'lblNewIco
        '
        Me.lblNewIco.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblNewIco.Location = New System.Drawing.Point(8, 4)
        Me.lblNewIco.Name = "lblNewIco"
        Me.lblNewIco.Size = New System.Drawing.Size(34, 38)
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
        Me.txtNew.Location = New System.Drawing.Point(48, 12)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtNew.Size = New System.Drawing.Size(488, 21)
        Me.txtNew.TabIndex = 1
        '
        'lblConfirm
        '
        Me.lblConfirm.AutoSize = True
        Me.lblConfirm.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblConfirm.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblConfirm.Location = New System.Drawing.Point(378, 212)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(175, 17)
        Me.lblConfirm.TabIndex = 6
        Me.lblConfirm.Text = "CONFIRM NEW PASSWORD"
        '
        'pnlConfirmWrap
        '
        Me.pnlConfirmWrap.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlConfirmWrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlConfirmWrap.Controls.Add(Me.lblConfirmIco)
        Me.pnlConfirmWrap.Controls.Add(Me.txtConfirm)
        Me.pnlConfirmWrap.Location = New System.Drawing.Point(378, 234)
        Me.pnlConfirmWrap.Name = "pnlConfirmWrap"
        Me.pnlConfirmWrap.Size = New System.Drawing.Size(548, 46)
        Me.pnlConfirmWrap.TabIndex = 7
        '
        'lblConfirmIco
        '
        Me.lblConfirmIco.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblConfirmIco.Location = New System.Drawing.Point(8, 4)
        Me.lblConfirmIco.Name = "lblConfirmIco"
        Me.lblConfirmIco.Size = New System.Drawing.Size(34, 38)
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
        Me.txtConfirm.Location = New System.Drawing.Point(48, 12)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtConfirm.Size = New System.Drawing.Size(488, 21)
        Me.txtConfirm.TabIndex = 1
        '
        'chkShow
        '
        Me.chkShow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkShow.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.chkShow.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.chkShow.Location = New System.Drawing.Point(380, 296)
        Me.chkShow.Name = "chkShow"
        Me.chkShow.Size = New System.Drawing.Size(546, 22)
        Me.chkShow.TabIndex = 8
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
        Me.btnSave.Location = New System.Drawing.Point(378, 330)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(322, 48)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Update Password"
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
        Me.btnClear.Location = New System.Drawing.Point(712, 330)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(214, 48)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'lblHint
        '
        Me.lblHint.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblHint.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblHint.Location = New System.Drawing.Point(378, 392)
        Me.lblHint.Name = "lblHint"
        Me.lblHint.Size = New System.Drawing.Size(548, 60)
        Me.lblHint.TabIndex = 11
        '
        'frmChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1000, 660)
        Me.Controls.Add(Me.pnlCard)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmChangePassword"
        Me.Text = "Change Password"
        Me.pnlCard.ResumeLayout(False)
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
    Friend WithEvents pnlLeftInfo As System.Windows.Forms.Panel
    Friend WithEvents lblPolicyTitle As System.Windows.Forms.Label
    Friend WithEvents pnlPolicyLine As System.Windows.Forms.Panel
    Friend WithEvents lblReq1 As System.Windows.Forms.Label
    Friend WithEvents lblReq2 As System.Windows.Forms.Label
    Friend WithEvents lblReq3 As System.Windows.Forms.Label
    Friend WithEvents pnlUserBadge As System.Windows.Forms.Panel
    Friend WithEvents lblUserBadgeTitle As System.Windows.Forms.Label
    Friend WithEvents lblUserInfo As System.Windows.Forms.Label
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
