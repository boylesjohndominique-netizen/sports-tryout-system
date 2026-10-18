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
    ''' Explicitly positions the left and right panels with 0% overlap,
    ''' guaranteeing the login card is always centered in the right panel.
    ''' </summary>
    Private Sub LayoutPanels()
        Dim totalW As Integer = Me.ClientSize.Width
        Dim totalH As Integer = Me.ClientSize.Height

        If totalW <= 0 OrElse totalH <= 0 Then Return

        ' Left panel takes 52% of screen width, right takes remainder
        Dim leftW As Integer = CInt(totalW * 0.52)
        Dim rightW As Integer = totalW - leftW

        pnlLeft.SetBounds(0, 0, leftW, totalH)
        pnlRight.SetBounds(leftW, 0, rightW, totalH)

        ' Position window controls in the top-right of the right panel
        pnlWindowControls.Location = New Point(rightW - pnlWindowControls.Width - 10, 10)

        ' Center login card inside the right panel
        Dim cardX As Integer = (rightW - pnlCard.Width) \ 2
        Dim cardY As Integer = (totalH - pnlCard.Height) \ 2
        If cardX < 15 Then cardX = 15
        If cardY < 20 Then cardY = 20

        pnlCard.Location = New Point(cardX, cardY)
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  LEFT SHOWCASE PAINTING — High-Resolution, Zero-Flicker, Scaled
    ' ═══════════════════════════════════════════════════════════════
    Private Sub PaintLeftPanel(sender As Object, e As PaintEventArgs)
        Dim pnl As Panel = DirectCast(sender, Panel)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' ── 1. Gradient Background ──
        Using bgBrush As New LinearGradientBrush(
            New Point(0, 0), New Point(pnl.Width, pnl.Height),
            Color.FromArgb(10, 26, 50),
            Color.FromArgb(22, 55, 100))
            g.FillRectangle(bgBrush, pnl.ClientRectangle)
        End Using

        ' ── 2. Top Gold Accent Bar ──
        Using goldBrush As New LinearGradientBrush(
            New Rectangle(0, 0, pnl.Width, 4),
            UIHelper.ColorGold,
            UIHelper.ColorGoldLight,
            LinearGradientMode.Horizontal)
            g.FillRectangle(goldBrush, 0, 0, pnl.Width, 4)
        End Using

        ' ── 3. Geometric Background Accents ──
        Using pGold As New Pen(Color.FromArgb(14, 234, 179, 8), 1.5!)
            g.DrawEllipse(pGold, pnl.Width - 160, 40, 240, 240)
        End Using
        Using pWhite As New Pen(Color.FromArgb(10, 255, 255, 255), 1.5!)
            g.DrawEllipse(pWhite, -60, pnl.Height - 260, 280, 280)
        End Using

        ' ── 4. Dynamic Vertical Spacing ──
        Dim cardW As Integer = Math.Min(560, pnl.Width - 80)
        If cardW < 300 Then cardW = Math.Max(260, pnl.Width - 40)
        Dim startX As Integer = Math.Max(35, (pnl.Width - cardW) \ 2)

        Dim totalBlockHeight As Integer = 500
        Dim curY As Integer = Math.Max(25, (pnl.Height - totalBlockHeight - 35) \ 2)

        ' Top Badge Pill
        Dim badgeText As String = "⚽  OFFICIAL TRYOUT PLATFORM"
        Using fntBadge As New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
            Dim szBadge = g.MeasureString(badgeText, fntBadge)
            Dim badgeRect As New Rectangle(startX, curY, CInt(szBadge.Width) + 20, 28)
            Using bBrush As New SolidBrush(Color.FromArgb(28, 234, 179, 8))
                g.FillRectangle(bBrush, badgeRect)
            End Using
            Using bPen As New Pen(UIHelper.ColorGold, 1.2!)
                g.DrawRectangle(bPen, badgeRect)
            End Using
            Using textBrush As New SolidBrush(UIHelper.ColorGoldLight)
                g.DrawString(badgeText, fntBadge, textBrush, startX + 10, curY + 5)
            End Using
        End Using

        curY += 40

        ' Title
        Using fntTitle As New Font("Segoe UI", 33.0!, FontStyle.Bold)
            Using brushTitle As New SolidBrush(Color.White)
                g.DrawString("Sports Tryout", fntTitle, brushTitle, startX, curY)
            End Using
        End Using

        curY += 50

        ' Subtitle
        Using fntSub As New Font("Segoe UI Semibold", 12.5!, FontStyle.Bold)
            Using brushGold As New SolidBrush(UIHelper.ColorGold)
                g.DrawString("MANAGEMENT & EVALUATION SYSTEM", fntSub, brushGold, startX, curY)
            End Using
        End Using

        curY += 26

        ' Gold accent line
        Using pLine As New Pen(UIHelper.ColorGold, 3.5!)
            g.DrawLine(pLine, startX, curY, startX + 110, curY)
        End Using

        curY += 16

        ' Description
        Using fntDesc As New Font("Segoe UI", 10.5!, FontStyle.Regular)
            Using brushDesc As New SolidBrush(Color.FromArgb(200, 220, 245))
                Dim desc As String = "Digital evaluation portal for coaches and scouting staff to record" & vbCrLf &
                                     "rubric scores, monitor leaderboards, and draft athlete rosters."
                g.DrawString(desc, fntDesc, brushDesc, startX, curY)
            End Using
        End Using

        curY += 50

        ' Feature Cards
        Dim cardH As Integer = 64
        DrawFeatureCard(g, startX, curY, cardW, cardH, "🏅", "Objective Skill Rubrics", "Standardized physical, tactical, and game IQ criteria.")
        curY += 76

        DrawFeatureCard(g, startX, curY, cardW, cardH, "📊", "Real-Time Ranking & Analytics", "Instant calculation of coach scores, ranks, and percentiles.")
        curY += 76

        DrawFeatureCard(g, startX, curY, cardW, cardH, "📋", "Instant Roster Selection", "Filter qualified applicants and generate draft reports.")
        curY += 82

        ' Athletic Stats Strip (only if screen height allows)
        If curY + 30 < pnl.Height - 35 Then
            Using fntTag As New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
                Dim tags As String() = {"⚡ Fast Scoring", "🔒 Secure Database", "🎯 Objective Criteria"}
                Dim tagX As Integer = startX
                For i As Integer = 0 To tags.Length - 1
                    Dim tagText As String = tags(i)
                    Dim sz = g.MeasureString(tagText, fntTag)
                    Dim tRect As New Rectangle(tagX, curY, CInt(sz.Width) + 16, 26)
                    Using tbBrush As New SolidBrush(Color.FromArgb(24, 255, 255, 255))
                        g.FillRectangle(tbBrush, tRect)
                    End Using
                    Using tbPen As New Pen(Color.FromArgb(60, 255, 255, 255), 1.0!)
                        g.DrawRectangle(tbPen, tRect)
                    End Using
                    Using tBrush As New SolidBrush(Color.FromArgb(215, 230, 250))
                        g.DrawString(tagText, fntTag, tBrush, tagX + 8, curY + 4)
                    End Using
                    tagX += CInt(sz.Width) + 22
                Next
            End Using
        End If

        ' Bottom Status Line
        Using fntVer As New Font("Segoe UI", 8.5!, FontStyle.Regular)
            Using brushVer As New SolidBrush(Color.FromArgb(130, 160, 200))
                g.DrawString("● System Online  •  Version 2.0  •  Enterprise Ready", fntVer, brushVer, startX, pnl.Height - 28)
            End Using
        End Using
    End Sub

    Private Sub DrawFeatureCard(g As Graphics, x As Integer, y As Integer, w As Integer, h As Integer, icon As String, title As String, desc As String)
        Dim rect As New Rectangle(x, y, w, h)

        ' Card background
        Using bBrush As New SolidBrush(Color.FromArgb(24, 255, 255, 255))
            g.FillRectangle(bBrush, rect)
        End Using

        ' Left gold border accent
        Using pGold As New Pen(UIHelper.ColorGold, 3.5!)
            g.DrawLine(pGold, x, y, x, y + h)
        End Using

        ' Border
        Using pBorder As New Pen(Color.FromArgb(45, 255, 255, 255), 1.0!)
            g.DrawRectangle(pBorder, rect)
        End Using

        ' Icon
        Using fntIcon As New Font("Segoe UI", 18.0!, FontStyle.Regular)
            Using brushIcon As New SolidBrush(Color.White)
                g.DrawString(icon, fntIcon, brushIcon, x + 12, y + 12)
            End Using
        End Using

        ' Title
        Using fntTitle As New Font("Segoe UI Semibold", 11.0!, FontStyle.Bold)
            Using brushTitle As New SolidBrush(Color.White)
                g.DrawString(title, fntTitle, brushTitle, x + 52, y + 10)
            End Using
        End Using

        ' Description
        Using fntDesc As New Font("Segoe UI", 9.0!, FontStyle.Regular)
            Using brushDesc As New SolidBrush(Color.FromArgb(190, 215, 240))
                g.DrawString(desc, fntDesc, brushDesc, x + 52, y + 34)
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

            SessionManager.SetSession(
                CInt(dt.Rows(0)("UserID")),
                dt.Rows(0)("Username").ToString(),
                dt.Rows(0)("FullName").ToString(),
                dt.Rows(0)("Role").ToString(),
                GetPermissionsValue(dt.Rows(0)))

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
