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
        AddHandler Me.Resize, Sub(s, e) LayoutContent()
        AddHandler Me.Load, Sub(s, e)
                                LoadUserData()
                                LayoutContent()
                            End Sub
        AddHandler Me.Shown, Sub(s, e) LayoutContent()

        ' Show / hide password toggle
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

    ''' <summary>
    ''' Fills the available window with a two-column card: a slim guidance
    ''' panel on the left and the password form on the right. Recomputed on
    ''' every resize so the layout has no dead space.
    ''' </summary>
    Private Sub LayoutContent()
        If pnlCard Is Nothing Then Return

        Dim margin As Integer = 24
        Dim topOffset As Integer = If(headerPanel IsNot Nothing, headerPanel.Height, 60)
        Dim availW As Integer = Me.ClientSize.Width - margin * 2
        Dim availH As Integer = Me.ClientSize.Height - topOffset - margin * 2
        If availW < 520 OrElse availH < 340 Then Return

        pnlCard.SetBounds(margin, topOffset + margin, availW, availH)

        Dim pad As Integer = 28
        Dim cardW As Integer = pnlCard.Width
        Dim cardH As Integer = pnlCard.Height

        ' ── Left: guidance column ──
        Dim guideW As Integer = Math.Min(340, Math.Max(230, CInt(cardW * 0.33)))
        pnlLeftInfo.SetBounds(pad, pad, guideW, cardH - pad * 2)
        pnlUserBadge.SetBounds(16, pnlLeftInfo.Height - 94, pnlLeftInfo.Width - 34, 78)

        ' ── Right: form column ──
        Dim formX As Integer = pad + guideW + 40
        Dim formW As Integer = cardW - formX - pad
        If formW < 260 Then formW = 260

        Dim labelH As Integer = 18
        Dim fieldH As Integer = 46
        Dim y As Integer = pad + 4

        lblCurrent.SetBounds(formX, y, formW, labelH)
        y += labelH + 6
        LayoutField(pnlCurrentWrap, lblCurIco, txtCurrent, formX, y, formW, fieldH)
        y += fieldH + 22

        lblNew.SetBounds(formX, y, formW, labelH)
        y += labelH + 6
        LayoutField(pnlNewWrap, lblNewIco, txtNew, formX, y, formW, fieldH)
        y += fieldH + 22

        lblConfirm.SetBounds(formX, y, formW, labelH)
        y += labelH + 6
        LayoutField(pnlConfirmWrap, lblConfirmIco, txtConfirm, formX, y, formW, fieldH)
        y += fieldH + 16

        chkShow.SetBounds(formX + 2, y, formW, 22)
        y += 30

        Dim saveW As Integer = CInt(formW * 0.6)
        Dim clearW As Integer = formW - saveW - 12
        btnSave.SetBounds(formX, y, saveW, 48)
        btnClear.SetBounds(formX + saveW + 12, y, clearW, 48)
        y += 48 + 14

        lblHint.SetBounds(formX, y, formW, Math.Max(24, cardH - y - pad))
    End Sub

    Private Sub LayoutField(wrap As Panel, ico As Label, txt As TextBox, x As Integer, y As Integer, w As Integer, h As Integer)
        wrap.SetBounds(x, y, w, h)
        ico.SetBounds(8, 4, 34, h - 8)
        txt.SetBounds(48, (h - 21) \ 2, w - 48 - 12, 21)
    End Sub

    Private Sub LoadUserData()
        If SessionManager.IsLoggedIn Then
            lblUserInfo.Text = SessionManager.CurrentFullName & vbCrLf & SessionManager.CurrentRole
        Else
            lblUserInfo.Text = "Standard User"
        End If
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
