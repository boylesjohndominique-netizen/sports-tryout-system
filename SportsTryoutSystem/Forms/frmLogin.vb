Public Class frmLogin
    Inherits Form

    Private txtUsername As TextBox
    Private txtPassword As TextBox
    Private btnLogin As Button
    Private lblStatus As Label

    Public Sub New()
        BuildUI()
    End Sub

    Private Sub BuildUI()
        Me.Text = "Sports Tryout Management System"
        Me.Size = New Size(480, 560)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = UIHelper.ColorPrimary

        ' ── Left accent stripe ──
        Dim pnlStripe As New Panel()
        pnlStripe.Size = New Size(8, Me.ClientSize.Height)
        pnlStripe.Location = New Point(0, 0)
        pnlStripe.BackColor = UIHelper.ColorGold
        Me.Controls.Add(pnlStripe)

        ' ── Main card ──
        Dim pnlCard As New Panel()
        pnlCard.Size = New Size(400, 440)
        pnlCard.Location = New Point(35, 45)
        pnlCard.BackColor = Color.White
        pnlCard.BorderStyle = BorderStyle.None

        ' Gold top accent bar on card
        Dim cardAccent As New Panel()
        cardAccent.Size = New Size(400, 5)
        cardAccent.Location = New Point(0, 0)
        cardAccent.BackColor = UIHelper.ColorGold
        pnlCard.Controls.Add(cardAccent)

        ' ── Branding section ──
        Dim lblIcon As New Label()
        lblIcon.Text = "⚽"
        lblIcon.Font = New Font("Segoe UI", 28, FontStyle.Regular)
        lblIcon.ForeColor = UIHelper.ColorGold
        lblIcon.TextAlign = ContentAlignment.MiddleCenter
        lblIcon.Location = New Point(10, 28)
        lblIcon.Size = New Size(380, 50)
        pnlCard.Controls.Add(lblIcon)

        Dim lblTitle As New Label()
        lblTitle.Text = "Sports Tryout"
        lblTitle.Font = New Font("Segoe UI Semibold", 20, FontStyle.Bold)
        lblTitle.ForeColor = UIHelper.ColorPrimary
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Location = New Point(10, 80)
        lblTitle.Size = New Size(380, 34)
        pnlCard.Controls.Add(lblTitle)

        Dim lblSubtitle As New Label()
        lblSubtitle.Text = "MANAGEMENT SYSTEM"
        lblSubtitle.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
        lblSubtitle.ForeColor = UIHelper.ColorTextSecondary
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        lblSubtitle.Location = New Point(10, 114)
        lblSubtitle.Size = New Size(380, 20)
        pnlCard.Controls.Add(lblSubtitle)

        ' Divider under title
        Dim divider As New Panel()
        divider.Size = New Size(80, 3)
        divider.Location = New Point(160, 145)
        divider.BackColor = UIHelper.ColorGold
        pnlCard.Controls.Add(divider)

        ' ── Form fields ──
        Dim lblWelcome As New Label()
        lblWelcome.Text = "Sign in to your account"
        lblWelcome.Font = UIHelper.FontRegular
        lblWelcome.ForeColor = UIHelper.ColorTextSecondary
        lblWelcome.TextAlign = ContentAlignment.MiddleCenter
        lblWelcome.Location = New Point(10, 162)
        lblWelcome.Size = New Size(380, 24)
        pnlCard.Controls.Add(lblWelcome)

        Dim lblUser As New Label()
        lblUser.Text = "USERNAME"
        lblUser.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblUser.ForeColor = UIHelper.ColorTextSecondary
        lblUser.Location = New Point(50, 200)
        lblUser.Size = New Size(300, 16)
        pnlCard.Controls.Add(lblUser)

        txtUsername = New TextBox()
        txtUsername.Location = New Point(50, 218)
        txtUsername.Size = New Size(300, 32)
        txtUsername.Font = New Font("Segoe UI", 11!)
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.BackColor = Color.FromArgb(248, 250, 252)
        txtUsername.ForeColor = UIHelper.ColorTextPrimary
        pnlCard.Controls.Add(txtUsername)

        Dim lblPass As New Label()
        lblPass.Text = "PASSWORD"
        lblPass.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblPass.ForeColor = UIHelper.ColorTextSecondary
        lblPass.Location = New Point(50, 258)
        lblPass.Size = New Size(300, 16)
        pnlCard.Controls.Add(lblPass)

        txtPassword = New TextBox()
        txtPassword.Location = New Point(50, 276)
        txtPassword.Size = New Size(300, 32)
        txtPassword.Font = New Font("Segoe UI", 11!)
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.BackColor = Color.FromArgb(248, 250, 252)
        txtPassword.ForeColor = UIHelper.ColorTextPrimary
        txtPassword.PasswordChar = CChar("●")
        pnlCard.Controls.Add(txtPassword)

        ' ── Login button ──
        btnLogin = New Button()
        btnLogin.Text = "SIGN IN"
        btnLogin.Location = New Point(50, 330)
        btnLogin.Size = New Size(300, 44)
        btnLogin.Font = New Font("Segoe UI Semibold", 11!, FontStyle.Bold)
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.BackColor = UIHelper.ColorGold
        btnLogin.ForeColor = UIHelper.ColorPrimaryDark
        btnLogin.Cursor = Cursors.Hand
        btnLogin.FlatAppearance.MouseOverBackColor = UIHelper.ColorGoldDark
        AddHandler btnLogin.Click, AddressOf BtnLogin_Click
        pnlCard.Controls.Add(btnLogin)

        ' ── Status label ──
        lblStatus = New Label()
        lblStatus.Location = New Point(50, 385)
        lblStatus.Size = New Size(300, 36)
        lblStatus.ForeColor = UIHelper.ColorDanger
        lblStatus.Font = UIHelper.FontRegular
        lblStatus.TextAlign = ContentAlignment.MiddleCenter
        pnlCard.Controls.Add(lblStatus)

        Me.Controls.Add(pnlCard)

        AddHandler txtPassword.KeyDown, AddressOf TxtPassword_KeyDown
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            BtnLogin_Click(sender, e)
        End If
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs)
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        If username = "" OrElse password = "" Then
            lblStatus.Text = "Please enter username and password."
            Return
        End If

        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT * FROM Users WHERE Username=@u AND IsActive=1",
                New SQLiteParameter("@u", username))

            If dt.Rows.Count = 0 Then
                lblStatus.Text = "Invalid username or account is inactive."
                Return
            End If

            Dim storedHash As String = dt.Rows(0)("PasswordHash").ToString()

            If Not SecurityHelper.VerifyPassword(password, storedHash) Then
                lblStatus.Text = "Incorrect password."
                Return
            End If

            SessionManager.SetSession(
                CInt(dt.Rows(0)("UserID")),
                dt.Rows(0)("Username").ToString(),
                dt.Rows(0)("FullName").ToString(),
                dt.Rows(0)("Role").ToString())

            Dim main As New frmMain()
            Me.Hide()
            main.ShowDialog()

            Dim wasLogout As Boolean = main.LoggedOut
            SessionManager.ClearSession()

            If wasLogout Then
                txtUsername.Text = ""
                txtPassword.Text = ""
                lblStatus.Text = ""
                Me.Show()
            Else
                Me.Close()
            End If

        Catch ex As Exception
            UIHelper.ShowError("Login failed: " & ex.Message)
        End Try
    End Sub

End Class
