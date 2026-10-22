Imports System.Data
Imports System.Drawing.Drawing2D

''' <summary>
''' Comprehensive User Profile & Account Management Form.
''' Allows viewing and editing profile details, uploading or removing
''' profile picture, and securely updating the login password.
''' </summary>
Public Class frmProfile

    Public Sub New()
        InitializeComponent()
        SetupEventHandlers()
    End Sub

    Private Sub SetupEventHandlers()
        AddHandler Me.Load, AddressOf OnProfileLoad
        AddHandler Me.Resize, AddressOf OnProfileResize

        ' Card border painting for clean elevated appearance
        AddHandler cardIdentity.Paint, AddressOf DrawCardBorder
        AddHandler cardDetails.Paint, AddressOf DrawCardBorder
        AddHandler cardSecurity.Paint, AddressOf DrawCardBorder
        AddHandler pnlMetaBox.Paint, AddressOf DrawCardBorder
        AddHandler pnlPermissionsBox.Paint, AddressOf DrawCardBorder
        AddHandler pnlSecurityNotice.Paint, AddressOf DrawNoticeBorder

        ' Profile photo actions
        AddHandler btnUploadPic.Click, AddressOf BtnUploadPic_Click
        AddHandler btnRemovePic.Click, AddressOf BtnRemovePic_Click

        ' Profile details actions
        AddHandler btnSaveDetails.Click, AddressOf BtnSaveDetails_Click
        AddHandler btnResetDetails.Click, Sub(s, e) LoadProfileData()

        ' Password security actions
        AddHandler btnSavePassword.Click, AddressOf BtnSavePassword_Click
        AddHandler btnClearPassword.Click, AddressOf ClearPasswordFields
        AddHandler chkShowPassword.CheckedChanged, AddressOf ChkShowPassword_CheckedChanged

        ' Keyboard enter shortcuts
        AddHandler txtFullName.KeyDown, AddressOf DetailsInput_KeyDown
        AddHandler txtEmail.KeyDown, AddressOf DetailsInput_KeyDown
        AddHandler txtContact.KeyDown, AddressOf DetailsInput_KeyDown

        AddHandler txtCurrentPass.KeyDown, AddressOf PasswordInput_KeyDown
        AddHandler txtNewPass.KeyDown, AddressOf PasswordInput_KeyDown
        AddHandler txtConfirmPass.KeyDown, AddressOf PasswordInput_KeyDown
    End Sub

    Private Sub DrawCardBorder(sender As Object, e As PaintEventArgs)
        Dim pnl = TryCast(sender, Panel)
        If pnl Is Nothing Then Return
        Using pen As New Pen(Color.FromArgb(226, 232, 240), 1)
            e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
    End Sub

    Private Sub DrawNoticeBorder(sender As Object, e As PaintEventArgs)
        Dim pnl = TryCast(sender, Panel)
        If pnl Is Nothing Then Return
        Using pen As New Pen(Color.FromArgb(254, 202, 202), 1)
            e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
    End Sub

    Private Sub OnProfileLoad(sender As Object, e As EventArgs)
        LoadProfileData()
        LayoutProfileCards()
    End Sub

    Private Sub OnProfileResize(sender As Object, e As EventArgs)
        LayoutProfileCards()
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  RESPONSIVE CARD LAYOUT (Zero Overlapping, Fills Available Space)
    ' ═══════════════════════════════════════════════════════════════
    Private Sub LayoutProfileCards()
        If cardIdentity Is Nothing OrElse cardDetails Is Nothing OrElse cardSecurity Is Nothing Then Return

        Try
            pnlBody.SuspendLayout()

            Dim pad As Integer = 24
            Dim clientW As Integer = pnlBody.ClientSize.Width
            Dim clientH As Integer = pnlBody.ClientSize.Height

            If clientW >= 980 Then
                ' ── Two-Column Layout ──
                Dim idW As Integer = If(clientW >= 1260, 420, 380)
                Dim rightX As Integer = pad + idW + 20
                Dim rightW As Integer = Math.Max(520, clientW - rightX - pad)

                ' Available vertical height in viewport
                Dim availH As Integer = clientH - (pad * 2)
                Dim totalCardsH As Integer = Math.Max(730, Math.Min(availH, 840))

                Dim detailsH As Integer = Math.Max(380, CInt(totalCardsH * 0.535))
                Dim securityH As Integer = totalCardsH - detailsH - 20

                cardIdentity.Location = New Point(pad, pad)
                cardIdentity.Size = New Size(idW, totalCardsH)

                cardDetails.Location = New Point(rightX, pad)
                cardDetails.Size = New Size(rightW, detailsH)

                cardSecurity.Location = New Point(rightX, pad + detailsH + 20)
                cardSecurity.Size = New Size(rightW, securityH)

                LayoutIdentityCard(idW, totalCardsH)
                LayoutDetailsCard(rightW, detailsH)
                LayoutSecurityCard(rightW, securityH)
            Else
                ' ── Single Column Stacked Layout (Narrow screen mode) ──
                Dim cardW As Integer = Math.Max(480, clientW - (pad * 2))

                cardIdentity.Location = New Point(pad, pad)
                cardIdentity.Size = New Size(cardW, 710)

                cardDetails.Location = New Point(pad, pad + 710 + 20)
                cardDetails.Size = New Size(cardW, 390)

                cardSecurity.Location = New Point(pad, pad + 710 + 20 + 390 + 20)
                cardSecurity.Size = New Size(cardW, 340)

                LayoutIdentityCard(cardW, 710)
                LayoutDetailsCard(cardW, 390)
                LayoutSecurityCard(cardW, 340)
            End If

        Catch
        Finally
            pnlBody.ResumeLayout(True)
        End Try
    End Sub

    Private Sub LayoutIdentityCard(idW As Integer, idH As Integer)
        ' 1. Header stripe & title
        stripeIdentity.Width = idW
        lblIdentityTitle.Left = 24
        lblIdentityTitle.Top = 18

        ' 2. Avatar container (170x170)
        pnlAvatarContainer.Size = New Size(170, 170)
        pnlAvatarContainer.Left = (idW - 170) \ 2
        pnlAvatarContainer.Top = 54

        ' 3. Avatar buttons (Upload / Remove)
        flpAvatarButtons.Size = New Size(280, 44)
        flpAvatarButtons.Left = (idW - 280) \ 2
        flpAvatarButtons.Top = 236

        ' 4. Separator 1
        sepIdentity.Left = 24
        sepIdentity.Top = 292
        sepIdentity.Width = idW - 48

        ' 5. Display Name
        lblDisplayName.Left = 12
        lblDisplayName.Top = 306
        lblDisplayName.Width = idW - 24
        lblDisplayName.Height = 34

        ' 6. Role Badge
        lblDisplayRole.Top = 346
        lblDisplayRole.Left = (idW - lblDisplayRole.Width) \ 2

        ' 7. Username
        lblDisplayUsername.Left = 12
        lblDisplayUsername.Top = 380
        lblDisplayUsername.Width = idW - 24
        lblDisplayUsername.Height = 26

        ' 8. Account Status
        lblDisplayStatus.Left = 12
        lblDisplayStatus.Top = 410
        lblDisplayStatus.Width = idW - 24
        lblDisplayStatus.Height = 26

        ' 9. Separator 2
        sepIdentity2.Left = 24
        sepIdentity2.Top = 446
        sepIdentity2.Width = idW - 48

        ' 10. Meta Box
        pnlMetaBox.Left = 24
        pnlMetaBox.Top = 460
        pnlMetaBox.Width = idW - 48
        Dim metaH As Integer = Math.Max(180, idH - 460 - 24)
        pnlMetaBox.Height = metaH

        lblMetaHeader.Left = 16
        lblMetaHeader.Top = 14

        lblMetaUserId.Left = 16
        lblMetaUserId.Top = 40

        lblMetaCreated.Left = 16
        lblMetaCreated.Top = 70

        lblMetaRole.Left = 16
        lblMetaRole.Top = 100

        lblMetaStatus.Left = 16
        lblMetaStatus.Top = 130
    End Sub

    Private Sub LayoutDetailsCard(dW As Integer, dH As Integer)
        stripeDetails.Width = dW
        lblDetailsTitle.Left = 24
        lblDetailsTitle.Top = 18
        lblDetailsSub.Left = 25
        lblDetailsSub.Top = 46

        ' Calculate 2 columns of inputs
        Dim padX As Integer = 24
        Dim gapX As Integer = 20
        Dim colW As Integer = (dW - (padX * 2) - gapX) \ 2
        If colW < 200 Then colW = 200

        ' Row 1: Full Name & Username
        lblFullName.Left = padX
        lblFullName.Top = 78
        txtFullName.Left = padX
        txtFullName.Top = 104
        txtFullName.Width = colW

        Dim col2X As Integer = padX + colW + gapX
        lblUsername.Left = col2X
        lblUsername.Top = 78
        txtUsername.Left = col2X
        txtUsername.Top = 104
        txtUsername.Width = colW

        ' Row 2: Email & Contact
        lblEmail.Left = padX
        lblEmail.Top = 154
        txtEmail.Left = padX
        txtEmail.Top = 180
        txtEmail.Width = colW

        lblContact.Left = col2X
        lblContact.Top = 154
        txtContact.Left = col2X
        txtContact.Top = 180
        txtContact.Width = colW

        ' Permissions Box
        pnlPermissionsBox.Left = padX
        pnlPermissionsBox.Top = 228
        pnlPermissionsBox.Width = dW - (padX * 2)
        pnlPermissionsBox.Height = 64
        lblPermissionsTitle.Left = 14
        lblPermissionsTitle.Top = 10
        lblPermissionsText.Left = 14
        lblPermissionsText.Top = 34
        lblPermissionsText.Width = pnlPermissionsBox.Width - 28

        ' Action row at bottom of card
        Dim btnY As Integer = Math.Max(308, dH - 44 - 20)
        btnResetDetails.Top = btnY
        btnResetDetails.Left = dW - btnResetDetails.Width - padX

        btnSaveDetails.Top = btnY
        btnSaveDetails.Left = btnResetDetails.Left - btnSaveDetails.Width - 12

        lblDetailsFeedback.Top = btnY + 10
        lblDetailsFeedback.Left = padX
        lblDetailsFeedback.Width = Math.Max(100, btnSaveDetails.Left - padX - 12)
    End Sub

    Private Sub LayoutSecurityCard(sW As Integer, sH As Integer)
        stripeSecurity.Width = sW
        lblSecurityTitle.Left = 24
        lblSecurityTitle.Top = 18
        lblSecuritySub.Left = 25
        lblSecuritySub.Top = 46

        Dim padX As Integer = 24
        Dim gapX As Integer = 18

        If sW >= 680 Then
            ' 3 Columns side-by-side
            Dim colW As Integer = (sW - (padX * 2) - (gapX * 2)) \ 3

            lblCurrentPass.Left = padX
            lblCurrentPass.Top = 78
            txtCurrentPass.Left = padX
            txtCurrentPass.Top = 104
            txtCurrentPass.Width = colW

            Dim c2X As Integer = padX + colW + gapX
            lblNewPass.Left = c2X
            lblNewPass.Top = 78
            txtNewPass.Left = c2X
            txtNewPass.Top = 104
            txtNewPass.Width = colW

            Dim c3X As Integer = c2X + colW + gapX
            lblConfirmPass.Left = c3X
            lblConfirmPass.Top = 78
            txtConfirmPass.Left = c3X
            txtConfirmPass.Top = 104
            txtConfirmPass.Width = colW

            chkShowPassword.Left = padX
            chkShowPassword.Top = 150

            lblPasswordHint.Left = chkShowPassword.Right + 16
            lblPasswordHint.Top = 152
            lblPasswordHint.Width = Math.Max(200, sW - lblPasswordHint.Left - padX)
        Else
            ' Narrow 2-row layout
            Dim fullW As Integer = sW - (padX * 2)
            lblCurrentPass.Left = padX
            lblCurrentPass.Top = 76
            txtCurrentPass.Left = padX
            txtCurrentPass.Top = 98
            txtCurrentPass.Width = fullW

            Dim halfW As Integer = (fullW - gapX) \ 2
            lblNewPass.Left = padX
            lblNewPass.Top = 138
            txtNewPass.Left = padX
            txtNewPass.Top = 160
            txtNewPass.Width = halfW

            Dim c2X As Integer = padX + halfW + gapX
            lblConfirmPass.Left = c2X
            lblConfirmPass.Top = 138
            txtConfirmPass.Left = c2X
            txtConfirmPass.Top = 160
            txtConfirmPass.Width = halfW

            chkShowPassword.Left = padX
            chkShowPassword.Top = 202

            lblPasswordHint.Left = chkShowPassword.Right + 16
            lblPasswordHint.Top = 204
            lblPasswordHint.Width = Math.Max(200, sW - lblPasswordHint.Left - padX)
        End If

        ' Security notice box
        pnlSecurityNotice.Left = padX
        pnlSecurityNotice.Top = If(sW >= 680, 184, 236)
        pnlSecurityNotice.Width = sW - (padX * 2)
        pnlSecurityNotice.Height = 44
        lblSecurityNoticeText.Left = 14
        lblSecurityNoticeText.Top = 12
        lblSecurityNoticeText.Width = pnlSecurityNotice.Width - 28

        ' Action row at bottom of card
        Dim btnY As Integer = Math.Max(If(sW >= 680, 248, 298), sH - 44 - 20)
        btnClearPassword.Top = btnY
        btnClearPassword.Left = sW - btnClearPassword.Width - padX

        btnSavePassword.Top = btnY
        btnSavePassword.Left = btnClearPassword.Left - btnSavePassword.Width - 12

        lblSecurityFeedback.Top = btnY + 10
        lblSecurityFeedback.Left = padX
        lblSecurityFeedback.Width = Math.Max(100, btnSavePassword.Left - padX - 12)
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  DATA LOADING
    ' ═══════════════════════════════════════════════════════════════
    Public Sub LoadProfileData()
        lblDetailsFeedback.Text = ""
        lblSecurityFeedback.Text = ""

        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT * FROM Users WHERE UserID=@id",
                New SQLiteParameter("@id", SessionManager.CurrentUserID))

            If dt.Rows.Count > 0 Then
                Dim row = dt.Rows(0)

                Dim fullName As String = row("FullName").ToString()
                Dim username As String = row("Username").ToString()
                Dim role As String = row("Role").ToString()
                Dim email As String = If(dt.Columns.Contains("Email") AndAlso Not IsDBNull(row("Email")), row("Email").ToString(), "")
                Dim contact As String = If(dt.Columns.Contains("ContactNumber") AndAlso Not IsDBNull(row("ContactNumber")), row("ContactNumber").ToString(), "")
                Dim picBase64 As String = If(dt.Columns.Contains("ProfilePicture") AndAlso Not IsDBNull(row("ProfilePicture")), row("ProfilePicture").ToString(), "")
                Dim dateCreated As String = If(dt.Columns.Contains("DateCreated") AndAlso Not IsDBNull(row("DateCreated")), Convert.ToDateTime(row("DateCreated")).ToString("MMMM dd, yyyy"), "October 2026")

                ' Update session cache
                SessionManager.CurrentFullName = fullName
                SessionManager.CurrentUsername = username
                SessionManager.CurrentRole = role
                SessionManager.CurrentEmail = email
                SessionManager.CurrentContactNumber = contact
                SessionManager.CurrentProfilePictureBase64 = picBase64

                ' Identity Card
                lblDisplayName.Text = fullName
                lblDisplayRole.Text = " " & role.ToUpper() & " "
                lblDisplayUsername.Text = "@" & username
                lblMetaUserId.Text = "User Account ID: #" & SessionManager.CurrentUserID
                lblMetaCreated.Text = "Member Since: " & dateCreated
                lblMetaRole.Text = "Role Level: " & If(role.ToLower() = "admin", "System Administrator (Full Access)", role)
                lblMetaStatus.Text = "Account Status: Active & Verified"

                ' Form Fields
                txtFullName.Text = fullName
                txtUsername.Text = username
                txtEmail.Text = email
                txtContact.Text = contact

                ' Permissions summary
                If SessionManager.IsAdmin Then
                    lblPermissionsText.Text = "Super Administrator: Unrestricted operational and management access across all modules."
                Else
                    Dim perms = SessionManager.CurrentPermissions
                    If String.IsNullOrWhiteSpace(perms) Then
                        lblPermissionsText.Text = "Standard role permissions (" & role & ")."
                    Else
                        lblPermissionsText.Text = "Active Permissions: " & perms.Replace(",", ", ")
                    End If
                End If

                ' Render avatar
                UpdateAvatarDisplay()
            Else
                ' Fallback
                txtFullName.Text = SessionManager.CurrentFullName
                txtUsername.Text = SessionManager.CurrentUsername
                lblDisplayName.Text = SessionManager.CurrentFullName
                lblDisplayRole.Text = " " & SessionManager.CurrentRole.ToUpper() & " "
                lblMetaUserId.Text = "User Account ID: #" & SessionManager.CurrentUserID
                lblMetaCreated.Text = "Member Since: Active"
                lblMetaRole.Text = "Role Level: " & SessionManager.CurrentRole
                lblMetaStatus.Text = "Account Status: Active & Verified"
                UpdateAvatarDisplay()
            End If

        Catch ex As Exception
            UIHelper.ShowError("Could not load user profile: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateAvatarDisplay()
        Dim pic As Image = Nothing
        If Not String.IsNullOrEmpty(SessionManager.CurrentProfilePictureBase64) Then
            Dim rawPic = UIHelper.Base64ToImage(SessionManager.CurrentProfilePictureBase64)
            If rawPic IsNot Nothing Then
                pic = UIHelper.MakeCircularImage(rawPic, 160)
            End If
        End If

        If pic Is Nothing Then
            pic = UIHelper.CreateDefaultAvatar(SessionManager.CurrentFullName, 160)
        End If

        If pbProfilePic.Image IsNot Nothing Then
            Try : pbProfilePic.Image.Dispose() : Catch : End Try
        End If
        pbProfilePic.Image = pic
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  PROFILE PICTURE ACTIONS
    ' ═══════════════════════════════════════════════════════════════
    Private Sub BtnUploadPic_Click(sender As Object, e As EventArgs)
        Try
            Using ofd As New OpenFileDialog()
                ofd.Title = "Select Profile Picture"
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
                If ofd.ShowDialog() = DialogResult.OK Then
                    Dim fi As New System.IO.FileInfo(ofd.FileName)
                    If fi.Length > 5 * 1024 * 1024 Then
                        UIHelper.ShowError("Image size must be less than 5 MB.")
                        Return
                    End If

                    Using origImg As Image = Image.FromFile(ofd.FileName)
                        ' Resize to max 400x400 for optimal storage and rendering
                        Dim maxDim As Integer = 400
                        Dim newW As Integer = origImg.Width
                        Dim newH As Integer = origImg.Height
                        If newW > maxDim OrElse newH > maxDim Then
                            Dim ratio As Single = Math.Min(CSng(maxDim) / newW, CSng(maxDim) / newH)
                            newW = Math.Max(1, CInt(newW * ratio))
                            newH = Math.Max(1, CInt(newH * ratio))
                        End If

                        Using resizedBmp As New Bitmap(newW, newH)
                            Using g As Graphics = Graphics.FromImage(resizedBmp)
                                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                                g.DrawImage(origImg, 0, 0, newW, newH)
                            End Using

                            Dim base64Str As String = UIHelper.ImageToBase64(resizedBmp)

                            DatabaseHelper.ExecuteNonQuery(
                                "UPDATE Users SET ProfilePicture=@p WHERE UserID=@id",
                                New SQLiteParameter("@p", base64Str),
                                New SQLiteParameter("@id", SessionManager.CurrentUserID))

                            SessionManager.CurrentProfilePictureBase64 = base64Str

                            UpdateAvatarDisplay()

                            ' Synchronize main navigation profile button
                            If Me.MdiParent IsNot Nothing AndAlso TypeOf Me.MdiParent Is frmMain Then
                                CType(Me.MdiParent, frmMain).UpdateProfileDisplay()
                            End If

                            UIHelper.ShowInfo("Profile picture updated successfully!", "Photo Updated")
                        End Using
                    End Using
                End If
            End Using
        Catch ex As Exception
            UIHelper.ShowError("Failed to update profile picture: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnRemovePic_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(SessionManager.CurrentProfilePictureBase64) Then
            UIHelper.ShowInfo("No custom profile picture to remove.")
            Return
        End If

        If Not UIHelper.Confirm("Are you sure you want to remove your profile picture?") Then Return

        Try
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Users SET ProfilePicture=NULL WHERE UserID=@id",
                New SQLiteParameter("@id", SessionManager.CurrentUserID))

            SessionManager.CurrentProfilePictureBase64 = ""

            UpdateAvatarDisplay()

            ' Synchronize main navigation profile button
            If Me.MdiParent IsNot Nothing AndAlso TypeOf Me.MdiParent Is frmMain Then
                CType(Me.MdiParent, frmMain).UpdateProfileDisplay()
            End If

            UIHelper.ShowInfo("Profile picture removed successfully.", "Photo Removed")
        Catch ex As Exception
            UIHelper.ShowError("Failed to remove profile picture: " & ex.Message)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  EDIT PROFILE DETAILS
    ' ═══════════════════════════════════════════════════════════════
    Private Sub BtnSaveDetails_Click(sender As Object, e As EventArgs)
        lblDetailsFeedback.Text = ""

        Dim fullName As String = txtFullName.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim contact As String = txtContact.Text.Trim()

        If String.IsNullOrWhiteSpace(fullName) Then
            lblDetailsFeedback.ForeColor = Color.FromArgb(220, 38, 38)
            lblDetailsFeedback.Text = "Full Name cannot be empty."
            txtFullName.Focus()
            Return
        End If

        Try
            Dim rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Users SET FullName=@f, Email=@e, ContactNumber=@c WHERE UserID=@id",
                New SQLiteParameter("@f", fullName),
                New SQLiteParameter("@e", email),
                New SQLiteParameter("@c", contact),
                New SQLiteParameter("@id", SessionManager.CurrentUserID))

            SessionManager.CurrentFullName = fullName
            SessionManager.CurrentEmail = email
            SessionManager.CurrentContactNumber = contact

            lblDisplayName.Text = fullName
            UpdateAvatarDisplay()

            ' Synchronize main navigation profile button
            If Me.MdiParent IsNot Nothing AndAlso TypeOf Me.MdiParent Is frmMain Then
                CType(Me.MdiParent, frmMain).UpdateProfileDisplay()
            End If

            lblDetailsFeedback.ForeColor = Color.FromArgb(22, 163, 74)
            lblDetailsFeedback.Text = "✓ Profile details updated successfully."
            UIHelper.ShowInfo("Profile details saved successfully!", "Profile Updated")

        Catch ex As Exception
            lblDetailsFeedback.ForeColor = Color.FromArgb(220, 38, 38)
            lblDetailsFeedback.Text = "Error: " & ex.Message
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  CHANGE PASSWORD
    ' ═══════════════════════════════════════════════════════════════
    Private Sub BtnSavePassword_Click(sender As Object, e As EventArgs)
        lblSecurityFeedback.Text = ""

        Dim curPass As String = txtCurrentPass.Text.Trim()
        Dim newPass As String = txtNewPass.Text.Trim()
        Dim confirmPass As String = txtConfirmPass.Text.Trim()

        If curPass = "" OrElse newPass = "" OrElse confirmPass = "" Then
            lblSecurityFeedback.ForeColor = Color.FromArgb(220, 38, 38)
            lblSecurityFeedback.Text = "Please fill in all password fields."
            Return
        End If

        If newPass <> confirmPass Then
            lblSecurityFeedback.ForeColor = Color.FromArgb(220, 38, 38)
            lblSecurityFeedback.Text = "New password and confirmation do not match."
            Return
        End If

        If newPass.Length < 6 Then
            lblSecurityFeedback.ForeColor = Color.FromArgb(220, 38, 38)
            lblSecurityFeedback.Text = "New password must be at least 6 characters long."
            Return
        End If

        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT PasswordHash FROM Users WHERE UserID=@id",
                New SQLiteParameter("@id", SessionManager.CurrentUserID))

            If dt.Rows.Count = 0 Then
                lblSecurityFeedback.ForeColor = Color.FromArgb(220, 38, 38)
                lblSecurityFeedback.Text = "User record not found in system."
                Return
            End If

            Dim storedHash As String = dt.Rows(0)("PasswordHash").ToString()
            If Not SecurityHelper.VerifyPassword(txtCurrentPass.Text, storedHash) AndAlso
               Not SecurityHelper.VerifyPassword(curPass, storedHash) Then
                lblSecurityFeedback.ForeColor = Color.FromArgb(220, 38, 38)
                lblSecurityFeedback.Text = "Current password is incorrect. Please try again."
                txtCurrentPass.Focus()
                Return
            End If

            Dim newHash As String = SecurityHelper.HashPassword(newPass)
            Dim updated As Integer = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Users SET PasswordHash=@p WHERE UserID=@id",
                New SQLiteParameter("@p", newHash),
                New SQLiteParameter("@id", SessionManager.CurrentUserID))

            If updated > 0 Then
                ClearPasswordFields()
                lblSecurityFeedback.ForeColor = Color.FromArgb(220, 38, 38)
                lblSecurityFeedback.Text = "✓ Password updated successfully."
                UIHelper.ShowInfo("Your account password has been updated successfully.", "Security Updated")
            Else
                lblSecurityFeedback.ForeColor = Color.FromArgb(220, 38, 38)
                lblSecurityFeedback.Text = "Failed to update password. Please try again."
            End If

        Catch ex As Exception
            lblSecurityFeedback.ForeColor = Color.FromArgb(220, 38, 38)
            lblSecurityFeedback.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub ClearPasswordFields(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing)
        txtCurrentPass.Clear()
        txtNewPass.Clear()
        txtConfirmPass.Clear()
        lblSecurityFeedback.Text = ""
        txtCurrentPass.Focus()
    End Sub

    Private Sub ChkShowPassword_CheckedChanged(sender As Object, e As EventArgs)
        Dim ch As Char = If(chkShowPassword.Checked, CChar(vbNullChar), Global.Microsoft.VisualBasic.ChrW(9679))
        txtCurrentPass.PasswordChar = ch
        txtNewPass.PasswordChar = ch
        txtConfirmPass.PasswordChar = ch
    End Sub

    Private Sub DetailsInput_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSaveDetails.PerformClick()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub PasswordInput_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSavePassword.PerformClick()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

End Class
