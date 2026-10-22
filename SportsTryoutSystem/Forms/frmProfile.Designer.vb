<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProfile
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
        Me.pnlTopHeader = New System.Windows.Forms.Panel()
        Me.headerStripe = New System.Windows.Forms.Panel()
        Me.lblHeaderSub = New System.Windows.Forms.Label()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.cardIdentity = New System.Windows.Forms.Panel()
        Me.stripeIdentity = New System.Windows.Forms.Panel()
        Me.lblIdentityTitle = New System.Windows.Forms.Label()
        Me.pnlAvatarContainer = New System.Windows.Forms.Panel()
        Me.pbProfilePic = New System.Windows.Forms.PictureBox()
        Me.flpAvatarButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnUploadPic = New System.Windows.Forms.Button()
        Me.btnRemovePic = New System.Windows.Forms.Button()
        Me.sepIdentity = New System.Windows.Forms.Panel()
        Me.lblDisplayName = New System.Windows.Forms.Label()
        Me.lblDisplayRole = New System.Windows.Forms.Label()
        Me.lblDisplayUsername = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.sepIdentity2 = New System.Windows.Forms.Panel()
        Me.pnlMetaBox = New System.Windows.Forms.Panel()
        Me.lblMetaHeader = New System.Windows.Forms.Label()
        Me.lblMetaUserId = New System.Windows.Forms.Label()
        Me.lblMetaCreated = New System.Windows.Forms.Label()
        Me.lblMetaRole = New System.Windows.Forms.Label()
        Me.lblMetaStatus = New System.Windows.Forms.Label()
        Me.cardDetails = New System.Windows.Forms.Panel()
        Me.stripeDetails = New System.Windows.Forms.Panel()
        Me.lblDetailsTitle = New System.Windows.Forms.Label()
        Me.lblDetailsSub = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.pnlPermissionsBox = New System.Windows.Forms.Panel()
        Me.lblPermissionsTitle = New System.Windows.Forms.Label()
        Me.lblPermissionsText = New System.Windows.Forms.Label()
        Me.lblDetailsFeedback = New System.Windows.Forms.Label()
        Me.btnSaveDetails = New System.Windows.Forms.Button()
        Me.btnResetDetails = New System.Windows.Forms.Button()
        Me.cardSecurity = New System.Windows.Forms.Panel()
        Me.stripeSecurity = New System.Windows.Forms.Panel()
        Me.lblSecurityTitle = New System.Windows.Forms.Label()
        Me.lblSecuritySub = New System.Windows.Forms.Label()
        Me.lblCurrentPass = New System.Windows.Forms.Label()
        Me.txtCurrentPass = New System.Windows.Forms.TextBox()
        Me.lblNewPass = New System.Windows.Forms.Label()
        Me.txtNewPass = New System.Windows.Forms.TextBox()
        Me.lblConfirmPass = New System.Windows.Forms.Label()
        Me.txtConfirmPass = New System.Windows.Forms.TextBox()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.lblPasswordHint = New System.Windows.Forms.Label()
        Me.pnlSecurityNotice = New System.Windows.Forms.Panel()
        Me.lblSecurityNoticeText = New System.Windows.Forms.Label()
        Me.lblSecurityFeedback = New System.Windows.Forms.Label()
        Me.btnSavePassword = New System.Windows.Forms.Button()
        Me.btnClearPassword = New System.Windows.Forms.Button()

        Me.pnlTopHeader.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.cardIdentity.SuspendLayout()
        Me.pnlAvatarContainer.SuspendLayout()
        CType(Me.pbProfilePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpAvatarButtons.SuspendLayout()
        Me.pnlMetaBox.SuspendLayout()
        Me.cardDetails.SuspendLayout()
        Me.pnlPermissionsBox.SuspendLayout()
        Me.cardSecurity.SuspendLayout()
        Me.pnlSecurityNotice.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTopHeader
        '
        Me.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        Me.pnlTopHeader.Controls.Add(Me.headerStripe)
        Me.pnlTopHeader.Controls.Add(Me.lblHeaderSub)
        Me.pnlTopHeader.Controls.Add(Me.lblHeaderTitle)
        Me.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopHeader.Name = "pnlTopHeader"
        Me.pnlTopHeader.Size = New System.Drawing.Size(1200, 80)
        Me.pnlTopHeader.TabIndex = 0
        '
        'headerStripe
        '
        Me.headerStripe.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.headerStripe.Dock = System.Windows.Forms.DockStyle.Top
        Me.headerStripe.Location = New System.Drawing.Point(0, 0)
        Me.headerStripe.Name = "headerStripe"
        Me.headerStripe.Size = New System.Drawing.Size(1200, 4)
        Me.headerStripe.TabIndex = 0
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(185, 210, 240)
        Me.lblHeaderSub.Location = New System.Drawing.Point(26, 46)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(535, 19)
        Me.lblHeaderSub.TabIndex = 2
        Me.lblHeaderSub.Text = "Manage your account identity, personal details, profile picture, and login credentials."
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 16.5!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(24, 12)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(392, 30)
        Me.lblHeaderTitle.TabIndex = 1
        Me.lblHeaderTitle.Text = "👤  User Profile & Security Management"
        '
        'pnlBody
        '
        Me.pnlBody.AutoScroll = True
        Me.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.pnlBody.Controls.Add(Me.cardIdentity)
        Me.pnlBody.Controls.Add(Me.cardDetails)
        Me.pnlBody.Controls.Add(Me.cardSecurity)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 80)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(24)
        Me.pnlBody.Size = New System.Drawing.Size(1200, 740)
        Me.pnlBody.TabIndex = 1
        '
        'cardIdentity
        '
        Me.cardIdentity.BackColor = System.Drawing.Color.White
        Me.cardIdentity.Controls.Add(Me.stripeIdentity)
        Me.cardIdentity.Controls.Add(Me.lblIdentityTitle)
        Me.cardIdentity.Controls.Add(Me.pnlAvatarContainer)
        Me.cardIdentity.Controls.Add(Me.flpAvatarButtons)
        Me.cardIdentity.Controls.Add(Me.sepIdentity)
        Me.cardIdentity.Controls.Add(Me.lblDisplayName)
        Me.cardIdentity.Controls.Add(Me.lblDisplayRole)
        Me.cardIdentity.Controls.Add(Me.lblDisplayUsername)
        Me.cardIdentity.Controls.Add(Me.lblDisplayStatus)
        Me.cardIdentity.Controls.Add(Me.sepIdentity2)
        Me.cardIdentity.Controls.Add(Me.pnlMetaBox)
        Me.cardIdentity.Location = New System.Drawing.Point(24, 24)
        Me.cardIdentity.Name = "cardIdentity"
        Me.cardIdentity.Size = New System.Drawing.Size(380, 730)
        Me.cardIdentity.TabIndex = 0
        '
        'stripeIdentity
        '
        Me.stripeIdentity.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.stripeIdentity.Dock = System.Windows.Forms.DockStyle.Top
        Me.stripeIdentity.Location = New System.Drawing.Point(0, 0)
        Me.stripeIdentity.Name = "stripeIdentity"
        Me.stripeIdentity.Size = New System.Drawing.Size(380, 4)
        Me.stripeIdentity.TabIndex = 0
        '
        'lblIdentityTitle
        '
        Me.lblIdentityTitle.AutoSize = True
        Me.lblIdentityTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblIdentityTitle.ForeColor = System.Drawing.Color.FromArgb(14, 38, 72)
        Me.lblIdentityTitle.Location = New System.Drawing.Point(24, 18)
        Me.lblIdentityTitle.Name = "lblIdentityTitle"
        Me.lblIdentityTitle.Size = New System.Drawing.Size(201, 25)
        Me.lblIdentityTitle.TabIndex = 1
        Me.lblIdentityTitle.Text = "Identity & Profile Picture"
        '
        'pnlAvatarContainer
        '
        Me.pnlAvatarContainer.Controls.Add(Me.pbProfilePic)
        Me.pnlAvatarContainer.Location = New System.Drawing.Point(105, 54)
        Me.pnlAvatarContainer.Name = "pnlAvatarContainer"
        Me.pnlAvatarContainer.Size = New System.Drawing.Size(170, 170)
        Me.pnlAvatarContainer.TabIndex = 2
        '
        'pbProfilePic
        '
        Me.pbProfilePic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbProfilePic.Location = New System.Drawing.Point(0, 0)
        Me.pbProfilePic.Name = "pbProfilePic"
        Me.pbProfilePic.Size = New System.Drawing.Size(170, 170)
        Me.pbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbProfilePic.TabIndex = 0
        Me.pbProfilePic.TabStop = False
        '
        'flpAvatarButtons
        '
        Me.flpAvatarButtons.Controls.Add(Me.btnUploadPic)
        Me.flpAvatarButtons.Controls.Add(Me.btnRemovePic)
        Me.flpAvatarButtons.Location = New System.Drawing.Point(50, 236)
        Me.flpAvatarButtons.Name = "flpAvatarButtons"
        Me.flpAvatarButtons.Size = New System.Drawing.Size(280, 44)
        Me.flpAvatarButtons.TabIndex = 3
        Me.flpAvatarButtons.WrapContents = False
        '
        'btnUploadPic
        '
        Me.btnUploadPic.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.btnUploadPic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUploadPic.FlatAppearance.BorderSize = 0
        Me.btnUploadPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUploadPic.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnUploadPic.ForeColor = System.Drawing.Color.White
        Me.btnUploadPic.Location = New System.Drawing.Point(0, 2)
        Me.btnUploadPic.Margin = New System.Windows.Forms.Padding(0, 2, 8, 2)
        Me.btnUploadPic.Name = "btnUploadPic"
        Me.btnUploadPic.Size = New System.Drawing.Size(160, 40)
        Me.btnUploadPic.TabIndex = 0
        Me.btnUploadPic.Text = "📷  Upload Picture"
        Me.btnUploadPic.UseVisualStyleBackColor = False
        '
        'btnRemovePic
        '
        Me.btnRemovePic.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnRemovePic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemovePic.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnRemovePic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemovePic.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnRemovePic.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnRemovePic.Location = New System.Drawing.Point(168, 2)
        Me.btnRemovePic.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.btnRemovePic.Name = "btnRemovePic"
        Me.btnRemovePic.Size = New System.Drawing.Size(110, 40)
        Me.btnRemovePic.TabIndex = 1
        Me.btnRemovePic.Text = "✕  Remove"
        Me.btnRemovePic.UseVisualStyleBackColor = False
        '
        'sepIdentity
        '
        Me.sepIdentity.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.sepIdentity.Location = New System.Drawing.Point(24, 292)
        Me.sepIdentity.Name = "sepIdentity"
        Me.sepIdentity.Size = New System.Drawing.Size(332, 1)
        Me.sepIdentity.TabIndex = 4
        '
        'lblDisplayName
        '
        Me.lblDisplayName.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblDisplayName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblDisplayName.Location = New System.Drawing.Point(12, 306)
        Me.lblDisplayName.Name = "lblDisplayName"
        Me.lblDisplayName.Size = New System.Drawing.Size(356, 34)
        Me.lblDisplayName.TabIndex = 5
        Me.lblDisplayName.Text = "Administrator"
        Me.lblDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDisplayRole
        '
        Me.lblDisplayRole.AutoSize = True
        Me.lblDisplayRole.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.lblDisplayRole.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblDisplayRole.ForeColor = System.Drawing.Color.FromArgb(12, 32, 62)
        Me.lblDisplayRole.Location = New System.Drawing.Point(155, 346)
        Me.lblDisplayRole.Name = "lblDisplayRole"
        Me.lblDisplayRole.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.lblDisplayRole.Size = New System.Drawing.Size(70, 25)
        Me.lblDisplayRole.TabIndex = 6
        Me.lblDisplayRole.Text = " ADMIN "
        Me.lblDisplayRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDisplayUsername
        '
        Me.lblDisplayUsername.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblDisplayUsername.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblDisplayUsername.Location = New System.Drawing.Point(12, 380)
        Me.lblDisplayUsername.Name = "lblDisplayUsername"
        Me.lblDisplayUsername.Size = New System.Drawing.Size(356, 26)
        Me.lblDisplayUsername.TabIndex = 7
        Me.lblDisplayUsername.Text = "@admin"
        Me.lblDisplayUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDisplayStatus.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.lblDisplayStatus.Location = New System.Drawing.Point(12, 410)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(356, 26)
        Me.lblDisplayStatus.TabIndex = 8
        Me.lblDisplayStatus.Text = "● Active Account"
        Me.lblDisplayStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sepIdentity2
        '
        Me.sepIdentity2.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.sepIdentity2.Location = New System.Drawing.Point(24, 446)
        Me.sepIdentity2.Name = "sepIdentity2"
        Me.sepIdentity2.Size = New System.Drawing.Size(332, 1)
        Me.sepIdentity2.TabIndex = 9
        '
        'pnlMetaBox
        '
        Me.pnlMetaBox.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlMetaBox.Controls.Add(Me.lblMetaHeader)
        Me.pnlMetaBox.Controls.Add(Me.lblMetaUserId)
        Me.pnlMetaBox.Controls.Add(Me.lblMetaCreated)
        Me.pnlMetaBox.Controls.Add(Me.lblMetaRole)
        Me.pnlMetaBox.Controls.Add(Me.lblMetaStatus)
        Me.pnlMetaBox.Location = New System.Drawing.Point(24, 460)
        Me.pnlMetaBox.Name = "pnlMetaBox"
        Me.pnlMetaBox.Size = New System.Drawing.Size(332, 180)
        Me.pnlMetaBox.TabIndex = 10
        '
        'lblMetaHeader
        '
        Me.lblMetaHeader.AutoSize = True
        Me.lblMetaHeader.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblMetaHeader.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblMetaHeader.Location = New System.Drawing.Point(16, 14)
        Me.lblMetaHeader.Name = "lblMetaHeader"
        Me.lblMetaHeader.Size = New System.Drawing.Size(142, 15)
        Me.lblMetaHeader.TabIndex = 0
        Me.lblMetaHeader.Text = "ACCOUNT INFORMATION"
        '
        'lblMetaUserId
        '
        Me.lblMetaUserId.AutoSize = True
        Me.lblMetaUserId.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblMetaUserId.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblMetaUserId.Location = New System.Drawing.Point(16, 40)
        Me.lblMetaUserId.Name = "lblMetaUserId"
        Me.lblMetaUserId.Size = New System.Drawing.Size(133, 19)
        Me.lblMetaUserId.TabIndex = 1
        Me.lblMetaUserId.Text = "User Account ID: #1"
        '
        'lblMetaCreated
        '
        Me.lblMetaCreated.AutoSize = True
        Me.lblMetaCreated.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblMetaCreated.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblMetaCreated.Location = New System.Drawing.Point(16, 70)
        Me.lblMetaCreated.Name = "lblMetaCreated"
        Me.lblMetaCreated.Size = New System.Drawing.Size(176, 19)
        Me.lblMetaCreated.TabIndex = 2
        Me.lblMetaCreated.Text = "Member Since: Oct 12, 2026"
        '
        'lblMetaRole
        '
        Me.lblMetaRole.AutoSize = True
        Me.lblMetaRole.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblMetaRole.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblMetaRole.Location = New System.Drawing.Point(16, 100)
        Me.lblMetaRole.Name = "lblMetaRole"
        Me.lblMetaRole.Size = New System.Drawing.Size(200, 19)
        Me.lblMetaRole.TabIndex = 3
        Me.lblMetaRole.Text = "Role Level: System Administrator"
        '
        'lblMetaStatus
        '
        Me.lblMetaStatus.AutoSize = True
        Me.lblMetaStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblMetaStatus.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.lblMetaStatus.Location = New System.Drawing.Point(16, 130)
        Me.lblMetaStatus.Name = "lblMetaStatus"
        Me.lblMetaStatus.Size = New System.Drawing.Size(202, 19)
        Me.lblMetaStatus.TabIndex = 4
        Me.lblMetaStatus.Text = "Account Status: Active & Verified"
        '
        'cardDetails
        '
        Me.cardDetails.BackColor = System.Drawing.Color.White
        Me.cardDetails.Controls.Add(Me.stripeDetails)
        Me.cardDetails.Controls.Add(Me.lblDetailsTitle)
        Me.cardDetails.Controls.Add(Me.lblDetailsSub)
        Me.cardDetails.Controls.Add(Me.lblFullName)
        Me.cardDetails.Controls.Add(Me.txtFullName)
        Me.cardDetails.Controls.Add(Me.lblUsername)
        Me.cardDetails.Controls.Add(Me.txtUsername)
        Me.cardDetails.Controls.Add(Me.lblEmail)
        Me.cardDetails.Controls.Add(Me.txtEmail)
        Me.cardDetails.Controls.Add(Me.lblContact)
        Me.cardDetails.Controls.Add(Me.txtContact)
        Me.cardDetails.Controls.Add(Me.pnlPermissionsBox)
        Me.cardDetails.Controls.Add(Me.lblDetailsFeedback)
        Me.cardDetails.Controls.Add(Me.btnSaveDetails)
        Me.cardDetails.Controls.Add(Me.btnResetDetails)
        Me.cardDetails.Location = New System.Drawing.Point(428, 24)
        Me.cardDetails.Name = "cardDetails"
        Me.cardDetails.Size = New System.Drawing.Size(748, 380)
        Me.cardDetails.TabIndex = 1
        '
        'stripeDetails
        '
        Me.stripeDetails.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.stripeDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.stripeDetails.Location = New System.Drawing.Point(0, 0)
        Me.stripeDetails.Name = "stripeDetails"
        Me.stripeDetails.Size = New System.Drawing.Size(748, 4)
        Me.stripeDetails.TabIndex = 0
        '
        'lblDetailsTitle
        '
        Me.lblDetailsTitle.AutoSize = True
        Me.lblDetailsTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 13.5!, System.Drawing.FontStyle.Bold)
        Me.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(14, 38, 72)
        Me.lblDetailsTitle.Location = New System.Drawing.Point(24, 18)
        Me.lblDetailsTitle.Name = "lblDetailsTitle"
        Me.lblDetailsTitle.Size = New System.Drawing.Size(229, 25)
        Me.lblDetailsTitle.TabIndex = 1
        Me.lblDetailsTitle.Text = "✏️  Edit Profile Information"
        '
        'lblDetailsSub
        '
        Me.lblDetailsSub.AutoSize = True
        Me.lblDetailsSub.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDetailsSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblDetailsSub.Location = New System.Drawing.Point(25, 46)
        Me.lblDetailsSub.Name = "lblDetailsSub"
        Me.lblDetailsSub.Size = New System.Drawing.Size(434, 19)
        Me.lblDetailsSub.TabIndex = 2
        Me.lblDetailsSub.Text = "Update your full display name, contact phone number, and email address."
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblFullName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblFullName.Location = New System.Drawing.Point(24, 78)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(83, 19)
        Me.lblFullName.TabIndex = 3
        Me.lblFullName.Text = "Full Name *"
        '
        'txtFullName
        '
        Me.txtFullName.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.txtFullName.Location = New System.Drawing.Point(24, 104)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(335, 28)
        Me.txtFullName.TabIndex = 4
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblUsername.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblUsername.Location = New System.Drawing.Point(380, 78)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(189, 19)
        Me.lblUsername.TabIndex = 5
        Me.lblUsername.Text = "Username (Login ID - Fixed)"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.txtUsername.Location = New System.Drawing.Point(380, 104)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.Size = New System.Drawing.Size(340, 28)
        Me.txtUsername.TabIndex = 6
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblEmail.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblEmail.Location = New System.Drawing.Point(24, 154)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(96, 19)
        Me.lblEmail.TabIndex = 7
        Me.lblEmail.Text = "Email Address"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.txtEmail.Location = New System.Drawing.Point(24, 180)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(335, 28)
        Me.txtEmail.TabIndex = 8
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblContact.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblContact.Location = New System.Drawing.Point(380, 154)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(111, 19)
        Me.lblContact.TabIndex = 9
        Me.lblContact.Text = "Contact Number"
        '
        'txtContact
        '
        Me.txtContact.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.txtContact.Location = New System.Drawing.Point(380, 180)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(340, 28)
        Me.txtContact.TabIndex = 10
        '
        'pnlPermissionsBox
        '
        Me.pnlPermissionsBox.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlPermissionsBox.Controls.Add(Me.lblPermissionsTitle)
        Me.pnlPermissionsBox.Controls.Add(Me.lblPermissionsText)
        Me.pnlPermissionsBox.Location = New System.Drawing.Point(24, 228)
        Me.pnlPermissionsBox.Name = "pnlPermissionsBox"
        Me.pnlPermissionsBox.Size = New System.Drawing.Size(696, 64)
        Me.pnlPermissionsBox.TabIndex = 11
        '
        'lblPermissionsTitle
        '
        Me.lblPermissionsTitle.AutoSize = True
        Me.lblPermissionsTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPermissionsTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblPermissionsTitle.Location = New System.Drawing.Point(14, 10)
        Me.lblPermissionsTitle.Name = "lblPermissionsTitle"
        Me.lblPermissionsTitle.Size = New System.Drawing.Size(225, 19)
        Me.lblPermissionsTitle.TabIndex = 0
        Me.lblPermissionsTitle.Text = "🔑  Active Role Permissions Scope:"
        '
        'lblPermissionsText
        '
        Me.lblPermissionsText.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPermissionsText.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblPermissionsText.Location = New System.Drawing.Point(14, 34)
        Me.lblPermissionsText.Name = "lblPermissionsText"
        Me.lblPermissionsText.Size = New System.Drawing.Size(668, 22)
        Me.lblPermissionsText.TabIndex = 1
        Me.lblPermissionsText.Text = "Super Administrator: Unrestricted operational and management access across all modules."
        '
        'lblDetailsFeedback
        '
        Me.lblDetailsFeedback.AutoEllipsis = True
        Me.lblDetailsFeedback.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblDetailsFeedback.Location = New System.Drawing.Point(24, 320)
        Me.lblDetailsFeedback.Name = "lblDetailsFeedback"
        Me.lblDetailsFeedback.Size = New System.Drawing.Size(350, 24)
        Me.lblDetailsFeedback.TabIndex = 12
        '
        'btnSaveDetails
        '
        Me.btnSaveDetails.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnSaveDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveDetails.FlatAppearance.BorderSize = 0
        Me.btnSaveDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveDetails.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnSaveDetails.ForeColor = System.Drawing.Color.White
        Me.btnSaveDetails.Location = New System.Drawing.Point(405, 310)
        Me.btnSaveDetails.Name = "btnSaveDetails"
        Me.btnSaveDetails.Size = New System.Drawing.Size(205, 44)
        Me.btnSaveDetails.TabIndex = 13
        Me.btnSaveDetails.Text = "💾  Save Profile Details"
        Me.btnSaveDetails.UseVisualStyleBackColor = False
        '
        'btnResetDetails
        '
        Me.btnResetDetails.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnResetDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResetDetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnResetDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetDetails.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnResetDetails.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnResetDetails.Location = New System.Drawing.Point(619, 310)
        Me.btnResetDetails.Name = "btnResetDetails"
        Me.btnResetDetails.Size = New System.Drawing.Size(105, 44)
        Me.btnResetDetails.TabIndex = 14
        Me.btnResetDetails.Text = "↺  Reset"
        Me.btnResetDetails.UseVisualStyleBackColor = False
        '
        'cardSecurity
        '
        Me.cardSecurity.BackColor = System.Drawing.Color.White
        Me.cardSecurity.Controls.Add(Me.stripeSecurity)
        Me.cardSecurity.Controls.Add(Me.lblSecurityTitle)
        Me.cardSecurity.Controls.Add(Me.lblSecuritySub)
        Me.cardSecurity.Controls.Add(Me.lblCurrentPass)
        Me.cardSecurity.Controls.Add(Me.txtCurrentPass)
        Me.cardSecurity.Controls.Add(Me.lblNewPass)
        Me.cardSecurity.Controls.Add(Me.txtNewPass)
        Me.cardSecurity.Controls.Add(Me.lblConfirmPass)
        Me.cardSecurity.Controls.Add(Me.txtConfirmPass)
        Me.cardSecurity.Controls.Add(Me.chkShowPassword)
        Me.cardSecurity.Controls.Add(Me.lblPasswordHint)
        Me.cardSecurity.Controls.Add(Me.pnlSecurityNotice)
        Me.cardSecurity.Controls.Add(Me.lblSecurityFeedback)
        Me.cardSecurity.Controls.Add(Me.btnSavePassword)
        Me.cardSecurity.Controls.Add(Me.btnClearPassword)
        Me.cardSecurity.Location = New System.Drawing.Point(428, 424)
        Me.cardSecurity.Name = "cardSecurity"
        Me.cardSecurity.Size = New System.Drawing.Size(748, 330)
        Me.cardSecurity.TabIndex = 2
        '
        'stripeSecurity
        '
        Me.stripeSecurity.BackColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.stripeSecurity.Dock = System.Windows.Forms.DockStyle.Top
        Me.stripeSecurity.Location = New System.Drawing.Point(0, 0)
        Me.stripeSecurity.Name = "stripeSecurity"
        Me.stripeSecurity.Size = New System.Drawing.Size(748, 4)
        Me.stripeSecurity.TabIndex = 0
        '
        'lblSecurityTitle
        '
        Me.lblSecurityTitle.AutoSize = True
        Me.lblSecurityTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 13.5!, System.Drawing.FontStyle.Bold)
        Me.lblSecurityTitle.ForeColor = System.Drawing.Color.FromArgb(14, 38, 72)
        Me.lblSecurityTitle.Location = New System.Drawing.Point(24, 18)
        Me.lblSecurityTitle.Name = "lblSecurityTitle"
        Me.lblSecurityTitle.Size = New System.Drawing.Size(309, 25)
        Me.lblSecurityTitle.TabIndex = 1
        Me.lblSecurityTitle.Text = "🔒  Change Password & Credentials"
        '
        'lblSecuritySub
        '
        Me.lblSecuritySub.AutoSize = True
        Me.lblSecuritySub.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSecuritySub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSecuritySub.Location = New System.Drawing.Point(25, 46)
        Me.lblSecuritySub.Name = "lblSecuritySub"
        Me.lblSecuritySub.Size = New System.Drawing.Size(517, 19)
        Me.lblSecuritySub.TabIndex = 2
        Me.lblSecuritySub.Text = "Enter your current password to authorize changes and set a new secure password."
        '
        'lblCurrentPass
        '
        Me.lblCurrentPass.AutoSize = True
        Me.lblCurrentPass.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentPass.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblCurrentPass.Location = New System.Drawing.Point(24, 78)
        Me.lblCurrentPass.Name = "lblCurrentPass"
        Me.lblCurrentPass.Size = New System.Drawing.Size(127, 19)
        Me.lblCurrentPass.TabIndex = 3
        Me.lblCurrentPass.Text = "Current Password *"
        '
        'txtCurrentPass
        '
        Me.txtCurrentPass.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.txtCurrentPass.Location = New System.Drawing.Point(24, 104)
        Me.txtCurrentPass.Name = "txtCurrentPass"
        Me.txtCurrentPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtCurrentPass.Size = New System.Drawing.Size(220, 28)
        Me.txtCurrentPass.TabIndex = 4
        '
        'lblNewPass
        '
        Me.lblNewPass.AutoSize = True
        Me.lblNewPass.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblNewPass.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblNewPass.Location = New System.Drawing.Point(262, 78)
        Me.lblNewPass.Name = "lblNewPass"
        Me.lblNewPass.Size = New System.Drawing.Size(109, 19)
        Me.lblNewPass.TabIndex = 5
        Me.lblNewPass.Text = "New Password *"
        '
        'txtNewPass
        '
        Me.txtNewPass.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.txtNewPass.Location = New System.Drawing.Point(262, 104)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtNewPass.Size = New System.Drawing.Size(220, 28)
        Me.txtNewPass.TabIndex = 6
        '
        'lblConfirmPass
        '
        Me.lblConfirmPass.AutoSize = True
        Me.lblConfirmPass.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblConfirmPass.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblConfirmPass.Location = New System.Drawing.Point(500, 78)
        Me.lblConfirmPass.Name = "lblConfirmPass"
        Me.lblConfirmPass.Size = New System.Drawing.Size(130, 19)
        Me.lblConfirmPass.TabIndex = 7
        Me.lblConfirmPass.Text = "Confirm Password *"
        '
        'txtConfirmPass
        '
        Me.txtConfirmPass.Font = New System.Drawing.Font("Segoe UI", 11.5!)
        Me.txtConfirmPass.Location = New System.Drawing.Point(500, 104)
        Me.txtConfirmPass.Name = "txtConfirmPass"
        Me.txtConfirmPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtConfirmPass.Size = New System.Drawing.Size(220, 28)
        Me.txtConfirmPass.TabIndex = 8
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkShowPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.chkShowPassword.Location = New System.Drawing.Point(24, 150)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(126, 23)
        Me.chkShowPassword.TabIndex = 9
        Me.chkShowPassword.Text = "Show passwords"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'lblPasswordHint
        '
        Me.lblPasswordHint.AutoSize = True
        Me.lblPasswordHint.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblPasswordHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblPasswordHint.Location = New System.Drawing.Point(170, 152)
        Me.lblPasswordHint.Name = "lblPasswordHint"
        Me.lblPasswordHint.Size = New System.Drawing.Size(432, 17)
        Me.lblPasswordHint.TabIndex = 10
        Me.lblPasswordHint.Text = "🛡️ Password requirements: Minimum 6 characters (mix of letters & numbers)."
        '
        'pnlSecurityNotice
        '
        Me.pnlSecurityNotice.BackColor = System.Drawing.Color.FromArgb(254, 242, 242)
        Me.pnlSecurityNotice.Controls.Add(Me.lblSecurityNoticeText)
        Me.pnlSecurityNotice.Location = New System.Drawing.Point(24, 184)
        Me.pnlSecurityNotice.Name = "pnlSecurityNotice"
        Me.pnlSecurityNotice.Size = New System.Drawing.Size(696, 44)
        Me.pnlSecurityNotice.TabIndex = 11
        '
        'lblSecurityNoticeText
        '
        Me.lblSecurityNoticeText.AutoSize = True
        Me.lblSecurityNoticeText.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblSecurityNoticeText.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27)
        Me.lblSecurityNoticeText.Location = New System.Drawing.Point(12, 12)
        Me.lblSecurityNoticeText.Name = "lblSecurityNoticeText"
        Me.lblSecurityNoticeText.Size = New System.Drawing.Size(588, 17)
        Me.lblSecurityNoticeText.TabIndex = 0
        Me.lblSecurityNoticeText.Text = "⚠️ Security Notice: Changes take effect immediately. Keep your password confidential at all times."
        '
        'lblSecurityFeedback
        '
        Me.lblSecurityFeedback.AutoEllipsis = True
        Me.lblSecurityFeedback.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblSecurityFeedback.Location = New System.Drawing.Point(24, 258)
        Me.lblSecurityFeedback.Name = "lblSecurityFeedback"
        Me.lblSecurityFeedback.Size = New System.Drawing.Size(350, 24)
        Me.lblSecurityFeedback.TabIndex = 12
        '
        'btnSavePassword
        '
        Me.btnSavePassword.BackColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnSavePassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSavePassword.FlatAppearance.BorderSize = 0
        Me.btnSavePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSavePassword.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.btnSavePassword.ForeColor = System.Drawing.Color.White
        Me.btnSavePassword.Location = New System.Drawing.Point(405, 248)
        Me.btnSavePassword.Name = "btnSavePassword"
        Me.btnSavePassword.Size = New System.Drawing.Size(205, 44)
        Me.btnSavePassword.TabIndex = 13
        Me.btnSavePassword.Text = "🔐  Update Password"
        Me.btnSavePassword.UseVisualStyleBackColor = False
        '
        'btnClearPassword
        '
        Me.btnClearPassword.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnClearPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnClearPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearPassword.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearPassword.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnClearPassword.Location = New System.Drawing.Point(619, 248)
        Me.btnClearPassword.Name = "btnClearPassword"
        Me.btnClearPassword.Size = New System.Drawing.Size(105, 44)
        Me.btnClearPassword.TabIndex = 14
        Me.btnClearPassword.Text = "Clear"
        Me.btnClearPassword.UseVisualStyleBackColor = False
        '
        'frmProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1200, 820)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlTopHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(900, 650)
        Me.Name = "frmProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "My Profile & Account Settings"
        Me.pnlTopHeader.ResumeLayout(False)
        Me.pnlTopHeader.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        Me.cardIdentity.ResumeLayout(False)
        Me.cardIdentity.PerformLayout()
        Me.pnlAvatarContainer.ResumeLayout(False)
        CType(Me.pbProfilePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpAvatarButtons.ResumeLayout(False)
        Me.pnlMetaBox.ResumeLayout(False)
        Me.pnlMetaBox.PerformLayout()
        Me.cardDetails.ResumeLayout(False)
        Me.cardDetails.PerformLayout()
        Me.pnlPermissionsBox.ResumeLayout(False)
        Me.pnlPermissionsBox.PerformLayout()
        Me.cardSecurity.ResumeLayout(False)
        Me.cardSecurity.PerformLayout()
        Me.pnlSecurityNotice.ResumeLayout(False)
        Me.pnlSecurityNotice.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTopHeader As System.Windows.Forms.Panel
    Friend WithEvents headerStripe As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents cardIdentity As System.Windows.Forms.Panel
    Friend WithEvents stripeIdentity As System.Windows.Forms.Panel
    Friend WithEvents lblIdentityTitle As System.Windows.Forms.Label
    Friend WithEvents pnlAvatarContainer As System.Windows.Forms.Panel
    Friend WithEvents pbProfilePic As System.Windows.Forms.PictureBox
    Friend WithEvents flpAvatarButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnUploadPic As System.Windows.Forms.Button
    Friend WithEvents btnRemovePic As System.Windows.Forms.Button
    Friend WithEvents sepIdentity As System.Windows.Forms.Panel
    Friend WithEvents lblDisplayName As System.Windows.Forms.Label
    Friend WithEvents lblDisplayRole As System.Windows.Forms.Label
    Friend WithEvents lblDisplayUsername As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents sepIdentity2 As System.Windows.Forms.Panel
    Friend WithEvents pnlMetaBox As System.Windows.Forms.Panel
    Friend WithEvents lblMetaHeader As System.Windows.Forms.Label
    Friend WithEvents lblMetaUserId As System.Windows.Forms.Label
    Friend WithEvents lblMetaCreated As System.Windows.Forms.Label
    Friend WithEvents lblMetaRole As System.Windows.Forms.Label
    Friend WithEvents lblMetaStatus As System.Windows.Forms.Label
    Friend WithEvents cardDetails As System.Windows.Forms.Panel
    Friend WithEvents stripeDetails As System.Windows.Forms.Panel
    Friend WithEvents lblDetailsTitle As System.Windows.Forms.Label
    Friend WithEvents lblDetailsSub As System.Windows.Forms.Label
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents pnlPermissionsBox As System.Windows.Forms.Panel
    Friend WithEvents lblPermissionsTitle As System.Windows.Forms.Label
    Friend WithEvents lblPermissionsText As System.Windows.Forms.Label
    Friend WithEvents lblDetailsFeedback As System.Windows.Forms.Label
    Friend WithEvents btnSaveDetails As System.Windows.Forms.Button
    Friend WithEvents btnResetDetails As System.Windows.Forms.Button
    Friend WithEvents cardSecurity As System.Windows.Forms.Panel
    Friend WithEvents stripeSecurity As System.Windows.Forms.Panel
    Friend WithEvents lblSecurityTitle As System.Windows.Forms.Label
    Friend WithEvents lblSecuritySub As System.Windows.Forms.Label
    Friend WithEvents lblCurrentPass As System.Windows.Forms.Label
    Friend WithEvents txtCurrentPass As System.Windows.Forms.TextBox
    Friend WithEvents lblNewPass As System.Windows.Forms.Label
    Friend WithEvents txtNewPass As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmPass As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPass As System.Windows.Forms.TextBox
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents lblPasswordHint As System.Windows.Forms.Label
    Friend WithEvents pnlSecurityNotice As System.Windows.Forms.Panel
    Friend WithEvents lblSecurityNoticeText As System.Windows.Forms.Label
    Friend WithEvents lblSecurityFeedback As System.Windows.Forms.Label
    Friend WithEvents btnSavePassword As System.Windows.Forms.Button
    Friend WithEvents btnClearPassword As System.Windows.Forms.Button

End Class
