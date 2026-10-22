Imports System.Drawing.Drawing2D

Public Class frmLogin

    Public Sub New()
        InitializeComponent()
        SetupEventHandlers()
    End Sub

    Private Sub SetupEventHandlers()
        AddHandler Me.KeyDown, Sub(s, e)
                                   If e.KeyCode = Keys.Escape Then Me.Close()
                               End Sub
        AddHandler btnMinimize.Click, Sub(s, e) Me.WindowState = FormWindowState.Minimized
        AddHandler btnClose.Click, Sub(s, e) Me.Close()
        AddHandler pnlLeft.Paint, AddressOf PaintLeftPanel
        AddHandler txtUsername.KeyDown, AddressOf Input_KeyDown
        AddHandler txtPassword.KeyDown, AddressOf Input_KeyDown
        AddHandler chkShowPassword.CheckedChanged, Sub(s, e)
                                                       txtPassword.PasswordChar = If(chkShowPassword.Checked, CChar(vbNullChar), CChar("●"))
                                                   End Sub
        AddHandler txtUsername.GotFocus, Sub(s, e)
                                            pnlUserWrap.BackColor = Color.White
                                            txtUsername.BackColor = Color.White
                                        End Sub
        AddHandler txtUsername.LostFocus, Sub(s, e)
                                             pnlUserWrap.BackColor = Color.FromArgb(248, 250, 252)
                                             txtUsername.BackColor = Color.FromArgb(248, 250, 252)
                                         End Sub
        AddHandler txtPassword.GotFocus, Sub(s, e)
                                            pnlPassWrap.BackColor = Color.White
                                            txtPassword.BackColor = Color.White
                                        End Sub
        AddHandler txtPassword.LostFocus, Sub(s, e)
                                             pnlPassWrap.BackColor = Color.FromArgb(248, 250, 252)
                                             txtPassword.BackColor = Color.FromArgb(248, 250, 252)
                                         End Sub
        AddHandler btnLogin.Click, AddressOf BtnLogin_Click
        AddHandler Me.Resize, Sub(s, e) LayoutPanels()
        AddHandler Me.Load, Sub(s, e) LayoutPanels()
        AddHandler Me.Shown, Sub(s, e) LayoutPanels()
    End Sub

    ''' <summary>
    ''' Splits the window into the left showcase and right login area, then
    ''' sizes and centers the card so it fills the available space.
    ''' </summary>
    Private Sub LayoutPanels()
        Dim totalW As Integer = Me.ClientSize.Width
        Dim totalH As Integer = Me.ClientSize.Height

        If totalW <= 0 OrElse totalH <= 0 Then Return

        Dim leftW As Integer = CInt(totalW * 0.52)
        Dim rightW As Integer = totalW - leftW

        pnlLeft.SetBounds(0, 0, leftW, totalH)
        pnlRight.SetBounds(leftW, 0, rightW, totalH)

        pnlWindowControls.Location = New Point(rightW - pnlWindowControls.Width - 12, 12)

        ' Grow the card with the window, clamped to comfortable limits
        Dim cardW As Integer = Math.Min(620, Math.Max(440, rightW - 160))
        Dim cardH As Integer = Math.Min(680, Math.Max(500, totalH - 160))
        If cardW > rightW - 60 Then cardW = rightW - 60
        If cardH > totalH - 60 Then cardH = totalH - 60

        pnlCard.Size = New Size(cardW, cardH)
        LayoutCard()

        Dim cardX As Integer = (rightW - cardW) \ 2
        Dim cardY As Integer = (totalH - cardH) \ 2
        If cardX < 15 Then cardX = 15
        If cardY < 20 Then cardY = 20

        pnlCard.Location = New Point(cardX, cardY)
    End Sub

    ''' <summary>
    ''' Reflows the controls inside the card so they stay centered and evenly
    ''' spaced at any card size.
    ''' </summary>
    Private Sub LayoutCard()
        Dim w As Integer = pnlCard.ClientSize.Width
        Dim h As Integer = pnlCard.ClientSize.Height
        If w <= 0 OrElse h <= 0 Then Return

        Dim pad As Integer = CInt(w * 0.11)
        If pad < 44 Then pad = 44
        Dim contentW As Integer = w - pad * 2
        If contentW < 220 Then
            pad = 24
            contentW = w - pad * 2
        End If

        Dim titleH As Integer = 46
        Dim subH As Integer = 24
        Dim divH As Integer = 3
        Dim lblH As Integer = 16
        Dim boxH As Integer = 56
        Dim chkH As Integer = 22
        Dim btnH As Integer = 56
        Dim statusH As Integer = 34

        Dim blockH As Integer = titleH + 6 + subH + 16 + divH + 26 + lblH + 8 + boxH + 20 + lblH + 8 + boxH + 16 + chkH + 20 + btnH + 10 + statusH

        Dim y As Integer = (h - blockH) \ 2
        If y < 30 Then y = 30

        lblTitle.SetBounds(0, y, w, titleH)
        y += titleH + 6

        lblSubtitle.SetBounds(0, y, w, subH)
        y += subH + 16

        pnlDiv.SetBounds((w - 64) \ 2, y, 64, divH)
        y += divH + 26

        lblUserTitle.Location = New Point(pad, y)
        y += lblH + 8

        pnlUserWrap.SetBounds(pad, y, contentW, boxH)
        lblUserIco.SetBounds(0, 0, 46, boxH - 2)
        txtUsername.SetBounds(48, (boxH - txtUsername.PreferredHeight) \ 2, contentW - 60, txtUsername.PreferredHeight)
        y += boxH + 20

        lblPassTitle.Location = New Point(pad, y)
        y += lblH + 8

        pnlPassWrap.SetBounds(pad, y, contentW, boxH)
        lblPassIco.SetBounds(0, 0, 46, boxH - 2)
        txtPassword.SetBounds(48, (boxH - txtPassword.PreferredHeight) \ 2, contentW - 60, txtPassword.PreferredHeight)
        y += boxH + 16

        chkShowPassword.SetBounds(pad + 2, y, contentW - 4, chkH)
        y += chkH + 20

        btnLogin.SetBounds(pad, y, contentW, btnH)
        y += btnH + 10

        lblStatus.SetBounds(pad, y, contentW, statusH)
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  LEFT SHOWCASE PAINTING — Decluttered, Centered, Responsive
    ' ═══════════════════════════════════════════════════════════════
    Private Sub PaintLeftPanel(sender As Object, e As PaintEventArgs)
        Dim pnl As Panel = DirectCast(sender, Panel)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' ── Gradient background ──
        Using bgBrush As New LinearGradientBrush(
            New Point(0, 0), New Point(pnl.Width, pnl.Height),
            Color.FromArgb(10, 26, 50),
            Color.FromArgb(22, 55, 100))
            g.FillRectangle(bgBrush, pnl.ClientRectangle)
        End Using

        ' ── Top gold accent bar ──
        Using goldBrush As New LinearGradientBrush(
            New Rectangle(0, 0, pnl.Width, 4),
            UIHelper.ColorGold,
            UIHelper.ColorGoldLight,
            LinearGradientMode.Horizontal)
            g.FillRectangle(goldBrush, 0, 0, pnl.Width, 4)
        End Using

        ' ── Subtle geometric accents ──
        Using pGold As New Pen(Color.FromArgb(16, 234, 179, 8), 1.5!)
            g.DrawEllipse(pGold, pnl.Width - 150, 30, 240, 240)
        End Using
        Using pWhite As New Pen(Color.FromArgb(10, 255, 255, 255), 1.5!)
            g.DrawEllipse(pWhite, -70, pnl.Height - 240, 260, 260)
        End Using

        ' ── Layout metrics ──
        Dim pad As Integer = Math.Max(48, CInt(pnl.Width * 0.1))
        Dim contentW As Integer = pnl.Width - pad * 2
        Dim titleH As Integer = 62
        Dim subH As Integer = 30
        Dim lineH As Integer = 4
        Dim tagH As Integer = 26
        Dim rowH As Integer = 58
        Dim rowGap As Integer = 14

        Dim blockH As Integer = titleH + 4 + subH + 18 + lineH + 22 + tagH + 34 + 3 * rowH + 2 * rowGap
        Dim y As Integer = Math.Max(60, (pnl.Height - blockH) \ 2)

        ' Title
        Using fntTitle As New Font("Segoe UI", 34.0!, FontStyle.Bold)
            g.DrawString("Sports Tryout", fntTitle, Brushes.White, pad, y)
        End Using
        y += titleH + 4

        ' Subtitle
        Using fntSub As New Font("Segoe UI Semibold", 12.5!, FontStyle.Bold)
            Using b As New SolidBrush(UIHelper.ColorGold)
                g.DrawString("MANAGEMENT & EVALUATION SYSTEM", fntSub, b, pad, y)
            End Using
        End Using
        y += subH + 18

        ' Gold accent line
        Using pLine As New Pen(UIHelper.ColorGold, 4.0!)
            g.DrawLine(pLine, pad, y, pad + 96, y)
        End Using
        y += lineH + 22

        ' One-line tagline
        Using fntTag As New Font("Segoe UI", 12.0!)
            Using b As New SolidBrush(Color.FromArgb(205, 222, 245))
                g.DrawString("Score objectively. Rank instantly. Select confidently.", fntTag, b, pad, y)
            End Using
        End Using
        y += tagH + 34

        ' Feature highlights (compact)
        DrawFeatureRow(g, pad, y, contentW, rowH, "🏅", "Objective Skill Rubrics")
        y += rowH + rowGap

        DrawFeatureRow(g, pad, y, contentW, rowH, "📊", "Real-Time Rankings & Analytics")
        y += rowH + rowGap

        DrawFeatureRow(g, pad, y, contentW, rowH, "📋", "Instant Roster Selection")
    End Sub

    Private Sub DrawFeatureRow(g As Graphics, x As Integer, y As Integer, w As Integer, h As Integer, icon As String, title As String)
        Dim rect As New Rectangle(x, y, w, h)

        Using bBrush As New SolidBrush(Color.FromArgb(22, 255, 255, 255))
            g.FillRectangle(bBrush, rect)
        End Using

        Using pGold As New Pen(UIHelper.ColorGold, 3.5!)
            g.DrawLine(pGold, x, y, x, y + h)
        End Using

        Using pBorder As New Pen(Color.FromArgb(40, 255, 255, 255), 1.0!)
            g.DrawRectangle(pBorder, rect)
        End Using

        Using fntIcon As New Font("Segoe UI", 15.0!)
            Using b As New SolidBrush(UIHelper.ColorGoldLight)
                g.DrawString(icon, fntIcon, b, x + 16, y + (h - 28) \ 2)
            End Using
        End Using

        Using fntTitle As New Font("Segoe UI Semibold", 11.5!, FontStyle.Bold)
            Using b As New SolidBrush(Color.White)
                g.DrawString(title, fntTitle, b, x + 58, y + (h - 24) \ 2)
            End Using
        End Using
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  INPUT & LOGIN HANDLING
    ' ═══════════════════════════════════════════════════════════════
    Private Sub Input_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            BtnLogin_Click(sender, e)
        End If
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs)
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        If username = "" OrElse password = "" Then
            lblStatus.Text = "Please enter both username and password."
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

            If Not SecurityHelper.VerifyPassword(password, storedHash) AndAlso
               Not SecurityHelper.VerifyPassword(password.Trim(), storedHash) Then
                lblStatus.Text = "Incorrect password. Please try again."
                Return
            End If

            Dim picBase64 As String = ""
            If dt.Columns.Contains("ProfilePicture") AndAlso dt.Rows(0)("ProfilePicture") IsNot DBNull.Value Then
                picBase64 = dt.Rows(0)("ProfilePicture").ToString()
            End If
            Dim emailVal As String = ""
            If dt.Columns.Contains("Email") AndAlso dt.Rows(0)("Email") IsNot DBNull.Value Then
                emailVal = dt.Rows(0)("Email").ToString()
            End If
            Dim contactVal As String = ""
            If dt.Columns.Contains("ContactNumber") AndAlso dt.Rows(0)("ContactNumber") IsNot DBNull.Value Then
                contactVal = dt.Rows(0)("ContactNumber").ToString()
            End If

            SessionManager.SetSession(
                CInt(dt.Rows(0)("UserID")),
                dt.Rows(0)("Username").ToString(),
                dt.Rows(0)("FullName").ToString(),
                dt.Rows(0)("Role").ToString(),
                GetPermissionsValue(dt.Rows(0)),
                picBase64,
                emailVal,
                contactVal)

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            UIHelper.ShowError("Login failed: " & ex.Message)
        End Try
    End Sub

    Private Function GetPermissionsValue(row As DataRow) As String
        If row.Table.Columns.Contains("Permissions") AndAlso row("Permissions") IsNot DBNull.Value Then
            Return row("Permissions").ToString()
        End If
        Return Nothing
    End Function

End Class
