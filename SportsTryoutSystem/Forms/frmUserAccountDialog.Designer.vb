<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUserAccountDialog
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
        Me.pnlDialogHeader = New System.Windows.Forms.Panel()
        Me.headerStripe = New System.Windows.Forms.Panel()
        Me.lblSub = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.sepFooter = New System.Windows.Forms.Panel()
        Me.lblFeedback = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.cardContent = New System.Windows.Forms.Panel()
        Me.stripeCard = New System.Windows.Forms.Panel()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.cmbRole = New System.Windows.Forms.ComboBox()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.lblPasswordHint = New System.Windows.Forms.Label()
        Me.sepPerms = New System.Windows.Forms.Panel()
        Me.lblPermissionsTitle = New System.Windows.Forms.Label()
        Me.btnRoleDefaults = New System.Windows.Forms.Button()
        Me.clbPermissions = New System.Windows.Forms.CheckedListBox()

        Me.pnlDialogHeader.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.cardContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDialogHeader
        '
        Me.pnlDialogHeader.BackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        Me.pnlDialogHeader.Controls.Add(Me.headerStripe)
        Me.pnlDialogHeader.Controls.Add(Me.lblSub)
        Me.pnlDialogHeader.Controls.Add(Me.lblTitle)
        Me.pnlDialogHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDialogHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlDialogHeader.Name = "pnlDialogHeader"
        Me.pnlDialogHeader.Size = New System.Drawing.Size(640, 72)
        Me.pnlDialogHeader.TabIndex = 0
        '
        'headerStripe
        '
        Me.headerStripe.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.headerStripe.Dock = System.Windows.Forms.DockStyle.Top
        Me.headerStripe.Location = New System.Drawing.Point(0, 0)
        Me.headerStripe.Name = "headerStripe"
        Me.headerStripe.Size = New System.Drawing.Size(640, 4)
        Me.headerStripe.TabIndex = 0
        '
        'lblSub
        '
        Me.lblSub.AutoSize = True
        Me.lblSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSub.ForeColor = System.Drawing.Color.FromArgb(185, 210, 240)
        Me.lblSub.Location = New System.Drawing.Point(24, 42)
        Me.lblSub.Name = "lblSub"
        Me.lblSub.Size = New System.Drawing.Size(370, 15)
        Me.lblSub.TabIndex = 2
        Me.lblSub.Text = "Set up login credentials, profile details, and role module permissions."
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 13.5!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(22, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(252, 25)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "✚  Create New User Account"
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlFooter.Controls.Add(Me.sepFooter)
        Me.pnlFooter.Controls.Add(Me.lblFeedback)
        Me.pnlFooter.Controls.Add(Me.btnCancel)
        Me.pnlFooter.Controls.Add(Me.btnSave)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 606)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(640, 64)
        Me.pnlFooter.TabIndex = 2
        '
        'sepFooter
        '
        Me.sepFooter.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.sepFooter.Dock = System.Windows.Forms.DockStyle.Top
        Me.sepFooter.Location = New System.Drawing.Point(0, 0)
        Me.sepFooter.Name = "sepFooter"
        Me.sepFooter.Size = New System.Drawing.Size(640, 1)
        Me.sepFooter.TabIndex = 0
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoEllipsis = True
        Me.lblFeedback.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblFeedback.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblFeedback.Location = New System.Drawing.Point(20, 20)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(325, 24)
        Me.lblFeedback.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.btnCancel.Location = New System.Drawing.Point(355, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 40)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(465, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(155, 40)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "✚  Create Account"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlBody
        '
        Me.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.pnlBody.Controls.Add(Me.cardContent)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 72)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(18, 14, 18, 14)
        Me.pnlBody.Size = New System.Drawing.Size(640, 534)
        Me.pnlBody.TabIndex = 1
        '
        'cardContent
        '
        Me.cardContent.BackColor = System.Drawing.Color.White
        Me.cardContent.Controls.Add(Me.stripeCard)
        Me.cardContent.Controls.Add(Me.lblUsername)
        Me.cardContent.Controls.Add(Me.txtUsername)
        Me.cardContent.Controls.Add(Me.lblRole)
        Me.cardContent.Controls.Add(Me.cmbRole)
        Me.cardContent.Controls.Add(Me.chkIsActive)
        Me.cardContent.Controls.Add(Me.lblFullName)
        Me.cardContent.Controls.Add(Me.txtFullName)
        Me.cardContent.Controls.Add(Me.lblEmail)
        Me.cardContent.Controls.Add(Me.txtEmail)
        Me.cardContent.Controls.Add(Me.lblContact)
        Me.cardContent.Controls.Add(Me.txtContact)
        Me.cardContent.Controls.Add(Me.lblPassword)
        Me.cardContent.Controls.Add(Me.txtPassword)
        Me.cardContent.Controls.Add(Me.chkShowPassword)
        Me.cardContent.Controls.Add(Me.lblPasswordHint)
        Me.cardContent.Controls.Add(Me.sepPerms)
        Me.cardContent.Controls.Add(Me.lblPermissionsTitle)
        Me.cardContent.Controls.Add(Me.btnRoleDefaults)
        Me.cardContent.Controls.Add(Me.clbPermissions)
        Me.cardContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardContent.Location = New System.Drawing.Point(18, 14)
        Me.cardContent.Name = "cardContent"
        Me.cardContent.Size = New System.Drawing.Size(604, 506)
        Me.cardContent.TabIndex = 0
        '
        'stripeCard
        '
        Me.stripeCard.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.stripeCard.Dock = System.Windows.Forms.DockStyle.Top
        Me.stripeCard.Location = New System.Drawing.Point(0, 0)
        Me.stripeCard.Name = "stripeCard"
        Me.stripeCard.Size = New System.Drawing.Size(604, 3)
        Me.stripeCard.TabIndex = 0
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblUsername.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblUsername.Location = New System.Drawing.Point(20, 16)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(79, 15)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "USERNAME *"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtUsername.Location = New System.Drawing.Point(20, 36)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(260, 25)
        Me.txtUsername.TabIndex = 2
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblRole.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblRole.Location = New System.Drawing.Point(300, 16)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(46, 15)
        Me.lblRole.TabIndex = 3
        Me.lblRole.Text = "ROLE *"
        '
        'cmbRole
        '
        Me.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRole.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbRole.FormattingEnabled = True
        Me.cmbRole.Items.AddRange(New Object() {"Admin", "Coach", "Evaluator", "Staff"})
        Me.cmbRole.Location = New System.Drawing.Point(300, 36)
        Me.cmbRole.Name = "cmbRole"
        Me.cmbRole.Size = New System.Drawing.Size(160, 25)
        Me.cmbRole.TabIndex = 4
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.chkIsActive.Location = New System.Drawing.Point(480, 38)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(117, 21)
        Me.chkIsActive.TabIndex = 5
        Me.chkIsActive.Text = "Active Account"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblFullName.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblFullName.Location = New System.Drawing.Point(20, 74)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(78, 15)
        Me.lblFullName.TabIndex = 6
        Me.lblFullName.Text = "FULL NAME *"
        '
        'txtFullName
        '
        Me.txtFullName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtFullName.Location = New System.Drawing.Point(20, 94)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(260, 25)
        Me.txtFullName.TabIndex = 7
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblEmail.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblEmail.Location = New System.Drawing.Point(300, 74)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(96, 15)
        Me.lblEmail.TabIndex = 8
        Me.lblEmail.Text = "EMAIL ADDRESS"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtEmail.Location = New System.Drawing.Point(300, 94)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(285, 25)
        Me.txtEmail.TabIndex = 9
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblContact.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblContact.Location = New System.Drawing.Point(20, 132)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(111, 15)
        Me.lblContact.TabIndex = 10
        Me.lblContact.Text = "CONTACT NUMBER"
        '
        'txtContact
        '
        Me.txtContact.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtContact.Location = New System.Drawing.Point(20, 152)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(260, 25)
        Me.txtContact.TabIndex = 11
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblPassword.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblPassword.Location = New System.Drawing.Point(300, 132)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(78, 15)
        Me.lblPassword.TabIndex = 12
        Me.lblPassword.Text = "PASSWORD *"
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtPassword.Location = New System.Drawing.Point(300, 152)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.Size = New System.Drawing.Size(285, 25)
        Me.txtPassword.TabIndex = 13
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkShowPassword.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.chkShowPassword.Location = New System.Drawing.Point(300, 186)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(108, 19)
        Me.chkShowPassword.TabIndex = 14
        Me.chkShowPassword.Text = "Show password"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'lblPasswordHint
        '
        Me.lblPasswordHint.AutoSize = True
        Me.lblPasswordHint.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblPasswordHint.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblPasswordHint.Location = New System.Drawing.Point(420, 188)
        Me.lblPasswordHint.Name = "lblPasswordHint"
        Me.lblPasswordHint.Size = New System.Drawing.Size(107, 13)
        Me.lblPasswordHint.TabIndex = 15
        Me.lblPasswordHint.Text = "(Min 6 characters)"
        '
        'sepPerms
        '
        Me.sepPerms.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.sepPerms.Location = New System.Drawing.Point(20, 218)
        Me.sepPerms.Name = "sepPerms"
        Me.sepPerms.Size = New System.Drawing.Size(565, 1)
        Me.sepPerms.TabIndex = 16
        '
        'lblPermissionsTitle
        '
        Me.lblPermissionsTitle.AutoSize = True
        Me.lblPermissionsTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblPermissionsTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblPermissionsTitle.Location = New System.Drawing.Point(20, 228)
        Me.lblPermissionsTitle.Name = "lblPermissionsTitle"
        Me.lblPermissionsTitle.Size = New System.Drawing.Size(228, 15)
        Me.lblPermissionsTitle.TabIndex = 17
        Me.lblPermissionsTitle.Text = "ACCESS RIGHTS && MODULE PERMISSIONS"
        '
        'btnRoleDefaults
        '
        Me.btnRoleDefaults.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnRoleDefaults.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRoleDefaults.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnRoleDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRoleDefaults.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnRoleDefaults.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnRoleDefaults.Location = New System.Drawing.Point(415, 224)
        Me.btnRoleDefaults.Name = "btnRoleDefaults"
        Me.btnRoleDefaults.Size = New System.Drawing.Size(170, 26)
        Me.btnRoleDefaults.TabIndex = 18
        Me.btnRoleDefaults.Text = "↺  Reset to Role Defaults"
        Me.btnRoleDefaults.UseVisualStyleBackColor = False
        '
        'clbPermissions
        '
        Me.clbPermissions.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.clbPermissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbPermissions.CheckOnClick = True
        Me.clbPermissions.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.clbPermissions.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.clbPermissions.FormattingEnabled = True
        Me.clbPermissions.IntegralHeight = False
        Me.clbPermissions.Location = New System.Drawing.Point(20, 256)
        Me.clbPermissions.Name = "clbPermissions"
        Me.clbPermissions.Size = New System.Drawing.Size(565, 235)
        Me.clbPermissions.TabIndex = 19
        '
        'frmUserAccountDialog
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(640, 670)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlDialogHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserAccountDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Account"
        Me.pnlDialogHeader.ResumeLayout(False)
        Me.pnlDialogHeader.PerformLayout()
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.cardContent.ResumeLayout(False)
        Me.cardContent.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDialogHeader As System.Windows.Forms.Panel
    Friend WithEvents headerStripe As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSub As System.Windows.Forms.Label
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents sepFooter As System.Windows.Forms.Panel
    Friend WithEvents lblFeedback As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents cardContent As System.Windows.Forms.Panel
    Friend WithEvents stripeCard As System.Windows.Forms.Panel
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents cmbRole As System.Windows.Forms.ComboBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents lblPasswordHint As System.Windows.Forms.Label
    Friend WithEvents sepPerms As System.Windows.Forms.Panel
    Friend WithEvents lblPermissionsTitle As System.Windows.Forms.Label
    Friend WithEvents btnRoleDefaults As System.Windows.Forms.Button
    Friend WithEvents clbPermissions As System.Windows.Forms.CheckedListBox

End Class
