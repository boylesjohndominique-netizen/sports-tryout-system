Public Class frmChangePassword

    Private headerPanel As Panel

    Public Sub New()
        InitializeComponent()
        headerPanel = UIHelper.MakePanelHeader("Change Password", Me.Width)
        Me.Controls.Add(headerPanel)
        headerPanel.SendToBack()
        SetupEventHandlers()
    End Sub

    Private Sub SetupEventHandlers()
        AddHandler Me.Resize, Sub(s, e) CenterCard()
        AddHandler Me.Load, Sub(s, e)
                                LoadUserData()
                                CenterCard()
                            End Sub
        AddHandler Me.Shown, Sub(s, e) CenterCard()

        ' Show / Hide Password toggle
        AddHandler chkShow.CheckedChanged, Sub(s, e)
                                               Dim ch As Char = If(chkShow.Checked, CChar(vbNullChar), CChar("●"))
                                               txtCurrent.PasswordChar = ch
                                               txtNew.PasswordChar = ch
                                               txtConfirm.PasswordChar = ch
                                           End Sub

        ' Focus styling for wrappers
        SetupFocusState(txtCurrent, pnlCurrentWrap)
        SetupFocusState(txtNew, pnlNewWrap)
        SetupFocusState(txtConfirm, pnlConfirmWrap)

        ' Enter key shortcuts
        AddHandler txtCurrent.KeyDown, AddressOf Input_KeyDown
        AddHandler txtNew.KeyDown, AddressOf Input_KeyDown
        AddHandler txtConfirm.KeyDown, AddressOf Input_KeyDown

        ' Clear button
        AddHandler btnClear.Click, Sub(s, e)
                                       txtCurrent.Clear()
                                       txtNew.Clear()
                                       txtConfirm.Clear()
                                       lblHint.Text = ""
                                       txtCurrent.Focus()
                                   End Sub
    End Sub

    Private Sub LoadUserData()
        If SessionManager.IsLoggedIn Then
            lblUserInfo.Text = $"{SessionManager.CurrentFullName}" & vbCrLf & $"Role: {SessionManager.CurrentRole}"
        Else
            lblUserInfo.Text = "Standard User"
        End If
    End Sub

    Private Sub CenterCard()
        If pnlCard Is Nothing Then Return
        Dim topOffset As Integer = If(headerPanel IsNot Nothing, headerPanel.Height, 60)
        Dim availW As Integer = Me.ClientSize.Width
        Dim availH As Integer = Me.ClientSize.Height - topOffset

        If availW <= 0 OrElse availH <= 0 Then Return

        Dim posX As Integer = Math.Max(20, (availW - pnlCard.Width) \ 2)
        Dim posY As Integer = Math.Max(topOffset + 15, topOffset + (availH - pnlCard.Height) \ 2)

        pnlCard.Location = New Point(posX, posY)
    End Sub

    Private Sub SetupFocusState(txt As TextBox, wrap As Panel)
        AddHandler txt.GotFocus, Sub(s, e)
                                     wrap.BackColor = Color.White
                                     txt.BackColor = Color.White
                                     lblHint.Text = ""
                                 End Sub
        AddHandler txt.LostFocus, Sub(s, e)
                                      wrap.BackColor = Color.FromArgb(248, 250, 252)
                                      txt.BackColor = Color.FromArgb(248, 250, 252)
                                  End Sub
    End Sub

    Private Sub Input_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSave.PerformClick()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        lblHint.Text = ""

        Dim curPass As String = txtCurrent.Text.Trim()
        Dim newPass As String = txtNew.Text.Trim()
        Dim confirmPass As String = txtConfirm.Text.Trim()

        If curPass = "" OrElse newPass = "" OrElse confirmPass = "" Then
            lblHint.ForeColor = Color.FromArgb(220, 38, 38)
            lblHint.Text = "Please fill in all password fields."
            Return
        End If

        If newPass <> confirmPass Then
            lblHint.ForeColor = Color.FromArgb(220, 38, 38)
            lblHint.Text = "New password and confirmation do not match."
            Return
        End If

        If newPass.Length < 6 Then
            lblHint.ForeColor = Color.FromArgb(220, 38, 38)
            lblHint.Text = "New password must be at least 6 characters long."
            Return
        End If

        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT PasswordHash FROM Users WHERE UserID=@id",
                New SQLiteParameter("@id", SessionManager.CurrentUserID))

            If dt.Rows.Count = 0 Then
                lblHint.ForeColor = Color.FromArgb(220, 38, 38)
                lblHint.Text = "User record not found in system."
                Return
            End If

            Dim storedHash As String = dt.Rows(0)("PasswordHash").ToString()
            If Not SecurityHelper.VerifyPassword(txtCurrent.Text, storedHash) AndAlso
               Not SecurityHelper.VerifyPassword(curPass, storedHash) Then
                lblHint.ForeColor = Color.FromArgb(220, 38, 38)
                lblHint.Text = "Current password is incorrect. Please try again."
                Return
            End If

            Dim newHash As String = SecurityHelper.HashPassword(newPass)
            Dim updated As Integer = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Users SET PasswordHash=@p WHERE UserID=@id",
                New SQLiteParameter("@p", newHash),
                New SQLiteParameter("@id", SessionManager.CurrentUserID))

            If updated > 0 Then
                txtCurrent.Clear()
                txtNew.Clear()
                txtConfirm.Clear()
                lblHint.ForeColor = Color.FromArgb(22, 163, 74)
                lblHint.Text = "✓ Password updated successfully."
                UIHelper.ShowInfo("Password updated successfully.", "Security Updated")
            Else
                lblHint.ForeColor = Color.FromArgb(220, 38, 38)
                lblHint.Text = "Failed to update password. Please try again."
            End If

        Catch ex As Exception
            lblHint.ForeColor = Color.FromArgb(220, 38, 38)
            lblHint.Text = "Error: " & ex.Message
        End Try
    End Sub

End Class
