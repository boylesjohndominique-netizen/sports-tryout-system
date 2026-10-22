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
    ' ═══════════════════════════════════════════════════════════════
    '  LEFT SHOWCASE PAINTING — Athletic Varsity Command Showcase (Icon-Driven)
    ' ═══════════════════════════════════════════════════════════════
    Private Sub PaintLeftPanel(sender As Object, e As PaintEventArgs)
        Dim pnl As Panel = DirectCast(sender, Panel)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' ── 1. Midnight-Navy Athletic Gradient Background ──
        Using bgBrush As New LinearGradientBrush(
            New Point(0, 0), New Point(pnl.Width, pnl.Height),
            Color.FromArgb(7, 20, 42),
            Color.FromArgb(16, 42, 82))
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

        ' ── 3. Subtle Atmospheric Geometric Accents ──
        Using pGold As New Pen(Color.FromArgb(14, 234, 179, 8), 1.5!)
            g.DrawEllipse(pGold, pnl.Width - 170, 35, 280, 280)
        End Using
        Using pBlue As New Pen(Color.FromArgb(12, 56, 189, 248), 1.5!)
            g.DrawEllipse(pBlue, -90, pnl.Height - 270, 310, 310)
        End Using

        ' ── 4. Layout Metrics & Responsive Dynamic Scaling ──
        Dim pad As Integer = Math.Max(42, CInt(pnl.Width * 0.085))
        Dim contentW As Integer = pnl.Width - (pad * 2)
        If contentW < 220 Then Return

        Dim totalH As Integer = pnl.Height
        Dim isLarge As Boolean = (totalH >= 950)
        Dim isMid As Boolean = (totalH >= 780)

        Dim crestH As Integer = If(isLarge, 50, If(isMid, 44, 38))
        Dim crestGap As Integer = If(isLarge, 14, If(isMid, 12, 10))
        Dim titleH As Integer = If(isLarge, 52, If(isMid, 46, 40))
        Dim titleFontPt As Single = If(isLarge, 36.0!, If(isMid, 32.0!, 28.0!))
        Dim subH As Integer = If(isLarge, 26, If(isMid, 22, 20))
        Dim subFontPt As Single = If(isLarge, 13.0!, If(isMid, 11.5!, 10.5!))
        Dim lineH As Integer = 3
        Dim tagH As Integer = If(isLarge, 38, If(isMid, 32, 28))
        Dim tagFontPt As Single = If(isLarge, 10.5!, If(isMid, 9.8!, 9.0!))
        Dim statsH As Integer = If(isLarge, 38, If(isMid, 32, 28))
        Dim itemH As Integer = If(isLarge, 102, If(isMid, 88, 76))
        Dim itemGap As Integer = If(isLarge, 22, If(isMid, 16, 12))
        Dim footerH As Integer = If(isLarge, 46, If(isMid, 40, 36))

        Dim itemsBlockH As Integer = (itemH * 3) + (itemGap * 2)
        Dim totalBlockH As Integer = crestH + crestGap + titleH + 4 + subH + 12 + lineH + 12 + tagH + 16 + statsH + itemGap + itemsBlockH + itemGap + footerH
        Dim y As Integer = Math.Max(22, (totalH - totalBlockH) \ 2)

        ' ── 5. Top Collegiate Emblem & Header (NO BOX) ──
        Dim medalSize As Integer = crestH
        Dim medalRect As New Rectangle(pad, y, medalSize, medalSize)
        Using pMedal As New GraphicsPath()
            pMedal.AddEllipse(medalRect)
            Using bMed As New LinearGradientBrush(medalRect, Color.FromArgb(65, 234, 179, 8), Color.FromArgb(16, 234, 179, 8), LinearGradientMode.Vertical)
                g.FillPath(bMed, pMedal)
            End Using
            Using pMed As New Pen(Color.FromArgb(180, 234, 179, 8), 1.5!)
                g.DrawPath(pMed, pMedal)
            End Using
        End Using

        Dim crestIcoPt As Single = If(isLarge, 19.0!, If(isMid, 16.0!, 14.0!))
        Using fntCrestIco As New Font("Segoe UI", crestIcoPt)
            Using bGold As New SolidBrush(Color.FromArgb(250, 204, 21))
                Using sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    g.DrawString("🏆", fntCrestIco, bGold, medalRect, sf)
                End Using
            End Using
        End Using

        Dim textX As Integer = pad + medalSize + 14
        Dim textY As Integer = y + (medalSize - If(isLarge, 34, 28)) \ 2
        Using fntTopLabel As New Font("Segoe UI Semibold", If(isLarge, 8.2!, 7.5!), FontStyle.Bold)
            Using bMuted As New SolidBrush(Color.FromArgb(148, 163, 184))
                g.DrawString("COLLEGIATE ATHLETICS & TRYOUT PORTAL", fntTopLabel, bMuted, textX, textY)
            End Using
        End Using
        Using fntBadge As New Font("Segoe UI Semibold", If(isLarge, 9.5!, 8.5!), FontStyle.Bold)
            Using bGold As New SolidBrush(Color.FromArgb(250, 204, 21))
                g.DrawString("OFFICIAL VARSITY EVALUATION SYSTEM", fntBadge, bGold, textX, textY + If(isLarge, 17, 14))
            End Using
        End Using
        y += crestH + crestGap

        ' ── 6. Hero Title & Subtitle ──
        Using fntTitle As New Font("Segoe UI", titleFontPt, FontStyle.Bold)
            g.DrawString("Sports Tryout", fntTitle, Brushes.White, pad, y)
        End Using
        y += titleH + 4

        Using fntSub As New Font("Segoe UI Semibold", subFontPt, FontStyle.Bold)
            Using bSub As New SolidBrush(Color.FromArgb(250, 204, 21))
                g.DrawString("MANAGEMENT & EVALUATION SYSTEM", fntSub, bSub, pad, y)
            End Using
        End Using
        y += subH + 12

        ' Gold Accent Line
        Using pLine As New Pen(Color.FromArgb(234, 179, 8), 3.0!)
            g.DrawLine(pLine, pad, y, pad + 110, y)
        End Using
        y += lineH + 12

        ' Mission Tagline
        Using fntTag As New Font("Segoe UI", tagFontPt)
            Using bTag As New SolidBrush(Color.FromArgb(203, 213, 225))
                Dim tagRect As New Rectangle(pad, y, contentW, tagH)
                g.DrawString("Standardized athletic evaluation, transparent qualification scoring, and real-time varsity roster selection.", fntTag, bTag, tagRect)
            End Using
        End Using
        y += tagH + 16

        ' ── 7. Open Athletic Highlights Strip (NO BOXES) ──
        DrawOpenStatStrip(g, pad, y, contentW, statsH, isLarge)
        y += statsH + itemGap

        ' ── 8. Three Feature Showcase Items Driven by Circular Icon Medallions (NO BOXES!) ──
        ' Feature 1: Standardized Athletic Scoring
        DrawFeatureItem(g, y, pad, contentW, itemH,
                        Color.FromArgb(234, 179, 8),
                        "🎯",
                        "100-POINT OBJECTIVE RUBRIC",
                        "Standardized Athletic Scoring",
                        "Evaluates athletes objectively across 6 core criteria: Skill, Speed, Agility, Endurance, Teamwork, and Discipline.",
                        isLarge)
        y += itemH + itemGap

        ' Feature 2: Automated Ranking & Selection
        DrawFeatureItem(g, y, pad, contentW, itemH,
                        Color.FromArgb(56, 189, 248),
                        "📊",
                        "REAL-TIME LEADERBOARDS & CUTOFFS",
                        "Automated Ranking & Selection",
                        "Instant weighted score calculations, live varsity cutoff leaderboards, and transparent selection tiers.",
                        isLarge)
        y += itemH + itemGap

        ' Feature 3: Unified Collegiate Athlete Directory
        DrawFeatureItem(g, y, pad, contentW, itemH,
                        Color.FromArgb(34, 197, 94),
                        "🎓",
                        "ALL 6 DEGREE PROGRAMS (1ST–4TH YR)",
                        "Collegiate Athlete Registry",
                        "Centralized roster directory exclusively for BSIT, BSCrim, BSOA, BSED, CAS, and BSPolSci student-athletes.",
                        isLarge)
        y += itemH + itemGap

        ' ── 9. Institutional Security Footer (NO BOX) ──
        DrawOpenSecurityFooter(g, pad, y, contentW, footerH, isLarge)
    End Sub

    ''' <summary>
    ''' Draws an open, horizontal statistical highlight strip without any enclosing box.
    ''' </summary>
    Private Sub DrawOpenStatStrip(g As Graphics, x As Integer, y As Integer, w As Integer, h As Integer, isLarge As Boolean)
        Using pDiv As New Pen(Color.FromArgb(32, 255, 255, 255), 1.0!)
            g.DrawLine(pDiv, x, y, x + w, y)
            g.DrawLine(pDiv, x, y + h, x + w, y + h)
        End Using

        Dim colW As Integer = w \ 3
        DrawStatCol(g, x, y, colW, h, "🎯", "6 Rubrics", "Skill & Speed", isLarge)
        DrawStatCol(g, x + colW, y, colW, h, "⚡", "100 Pts", "Weighted Scale", isLarge)
        DrawStatCol(g, x + (colW * 2), y, w - (colW * 2), h, "🎓", "6 Courses", "Varsity Roster", isLarge)
    End Sub

    Private Sub DrawStatCol(g As Graphics, x As Integer, y As Integer, w As Integer, h As Integer, icon As String, title As String, subtitle As String, isLarge As Boolean)
        Dim icoPt As Single = If(isLarge, 12.5!, 10.5!)
        Dim titlePt As Single = If(isLarge, 9.5!, 8.5!)
        Dim subPt As Single = If(isLarge, 8.0!, 7.2!)
        Dim icoW As Integer = If(isLarge, 24, 20)

        Using fntIco As New Font("Segoe UI", icoPt)
            Using bGold As New SolidBrush(Color.FromArgb(250, 204, 21))
                g.DrawString(icon, fntIco, bGold, x + 4, y + (h - If(isLarge, 20, 18)) \ 2)
            End Using
        End Using

        Dim textX As Integer = x + icoW + 8
        Dim textY As Integer = y + (h - If(isLarge, 28, 24)) \ 2
        Using fntTitle As New Font("Segoe UI Semibold", titlePt, FontStyle.Bold)
            g.DrawString(title, fntTitle, Brushes.White, textX, textY)
        End Using
        Using fntSub As New Font("Segoe UI", subPt)
            Using bMuted As New SolidBrush(Color.FromArgb(148, 163, 184))
                g.DrawString(subtitle, fntSub, bMuted, textX, textY + If(isLarge, 14, 12))
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Draws an open feature item anchored by a prominent glowing circular icon medallion,
    ''' eliminating any surrounding card boxes or borders.
    ''' </summary>
    Private Sub DrawFeatureItem(g As Graphics, y As Integer, contentLeft As Integer, contentW As Integer, itemH As Integer,
                               accentColor As Color, icon As String, tag As String, title As String, description As String,
                               isLarge As Boolean)
        ' 1. Prominent Circular Icon Medallion (NO BOX)
        Dim iconDiameter As Integer = If(isLarge, 58, 48)
        Dim iconY As Integer = y + (itemH - iconDiameter) \ 2
        Dim iconRect As New Rectangle(contentLeft, iconY, iconDiameter, iconDiameter)

        Using pathCirc As New GraphicsPath()
            pathCirc.AddEllipse(iconRect)

            ' Multi-stop circular gradient
            Using pgb As New PathGradientBrush(pathCirc)
                pgb.CenterColor = Color.FromArgb(70, accentColor.R, accentColor.G, accentColor.B)
                pgb.SurroundColors = New Color() {Color.FromArgb(16, accentColor.R, accentColor.G, accentColor.B)}
                g.FillPath(pgb, pathCirc)
            End Using

            ' Outer crisp accent ring
            Using pRing As New Pen(Color.FromArgb(180, accentColor.R, accentColor.G, accentColor.B), 1.5!)
                g.DrawPath(pRing, pathCirc)
            End Using

            ' Outer subtle glow ring
            Dim glowRect As New Rectangle(iconRect.X - 3, iconRect.Y - 3, iconRect.Width + 6, iconRect.Height + 6)
            Using pGlow As New GraphicsPath()
                pGlow.AddEllipse(glowRect)
                Using pGlowPen As New Pen(Color.FromArgb(32, accentColor.R, accentColor.G, accentColor.B), 2.0!)
                    g.DrawPath(pGlowPen, pGlow)
                End Using
            End Using
        End Using

        ' Draw Icon centered inside medallion
        Dim iconPt As Single = If(isLarge, 19.0!, 15.5!)
        Using fntIco As New Font("Segoe UI", iconPt)
            Using sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                g.DrawString(icon, fntIco, Brushes.White, iconRect, sf)
            End Using
        End Using

        ' 2. Open Typography directly beside icon (NO BOX!)
        Dim textLeft As Integer = contentLeft + iconDiameter + 18
        Dim textW As Integer = contentW - (iconDiameter + 18)

        Dim curY As Integer = y + If(isLarge, 6, 4)
        Dim tagPt As Single = If(isLarge, 8.2!, 7.5!)
        Using fntTag As New Font("Segoe UI Semibold", tagPt, FontStyle.Bold)
            Using bAccent As New SolidBrush(accentColor)
                g.DrawString(tag, fntTag, bAccent, textLeft, curY)
            End Using
        End Using
        curY += If(isLarge, 18, 15)

        Dim titlePt As Single = If(isLarge, 13.5!, 11.8!)
        Using fntTitle As New Font("Segoe UI Semibold", titlePt, FontStyle.Bold)
            g.DrawString(title, fntTitle, Brushes.White, textLeft, curY)
        End Using
        curY += If(isLarge, 24, 20)

        Dim descPt As Single = If(isLarge, 9.2!, 8.6!)
        Using fntDesc As New Font("Segoe UI", descPt)
            Using bDesc As New SolidBrush(Color.FromArgb(195, 210, 230))
                Dim descRect As New Rectangle(textLeft, curY, textW, itemH - (curY - y))
                g.DrawString(description, fntDesc, bDesc, descRect)
            End Using
        End Using

        ' Subtle soft horizontal divider below item
        Using bLine As New LinearGradientBrush(
            New Rectangle(contentLeft, y + itemH + 6, contentW, 1),
            Color.FromArgb(0, 255, 255, 255),
            Color.FromArgb(40, 255, 255, 255),
            LinearGradientMode.Horizontal)

            Dim cb As New ColorBlend(3)
            cb.Colors = New Color() {Color.FromArgb(0, 255, 255, 255), Color.FromArgb(36, 255, 255, 255), Color.FromArgb(0, 255, 255, 255)}
            cb.Positions = New Single() {0.0!, 0.4!, 1.0!}
            bLine.InterpolationColors = cb
            Using pSep As New Pen(bLine, 1.0!)
                g.DrawLine(pSep, contentLeft, y + itemH + 6, contentLeft + contentW, y + itemH + 6)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Draws an open institutional security badge at the bottom without any bounding box.
    ''' </summary>
    Private Sub DrawOpenSecurityFooter(g As Graphics, x As Integer, y As Integer, w As Integer, h As Integer, isLarge As Boolean)
        Dim icoPt As Single = If(isLarge, 16.0!, 14.0!)
        Dim topPt As Single = If(isLarge, 8.5!, 7.8!)
        Dim subPt As Single = If(isLarge, 8.8!, 8.0!)

        Using fntIco As New Font("Segoe UI", icoPt)
            g.DrawString("🛡️", fntIco, Brushes.White, x + 4, y + (h - If(isLarge, 24, 20)) \ 2)
        End Using

        Dim textX As Integer = x + If(isLarge, 34, 28)
        Using fntTop As New Font("Segoe UI Semibold", topPt, FontStyle.Bold)
            Using bTop As New SolidBrush(Color.FromArgb(148, 163, 184))
                g.DrawString("SECURE INSTITUTIONAL ATHLETIC PORTAL", fntTop, bTop, textX, y + 4)
            End Using
        End Using

        Using fntSub As New Font("Segoe UI", subPt)
            Using bSub As New SolidBrush(Color.FromArgb(203, 213, 225))
                g.DrawString("Authorized for Athletics Directorate, Coaches & Tryout Evaluation Staff", fntSub, bSub, textX, y + 4 + If(isLarge, 17, 15))
            End Using
        End Using
    End Sub

    Private Function CreateRoundedRectanglePath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim d As Integer = radius * 2
        If d > rect.Width Then d = rect.Width
        If d > rect.Height Then d = rect.Height
        If d <= 0 Then
            path.AddRectangle(rect)
            Return path
        End If

        Dim r As New Rectangle(rect.X, rect.Y, d, d)
        path.AddArc(r, 180, 90)
        r.X = rect.Right - d
        path.AddArc(r, 270, 90)
        r.Y = rect.Bottom - d
        path.AddArc(r, 0, 90)
        r.X = rect.Left
        path.AddArc(r, 90, 90)
        path.CloseFigure()
        Return path
    End Function
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
