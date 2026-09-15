Public Class frmMain
    Inherits Form

    Public LoggedOut As Boolean = False

    Private pnlNav As Panel
    Private pnlTop As Panel
    Private lblUser As Label
    Private lblRole As Label
    Private btnLogoutTop As Button
    Private activeNavButton As Button = Nothing

    Public Sub New()
        BuildUI()
        ShowDashboard()
    End Sub

    Private Sub BuildUI()
        Me.Text = "Sports Tryout Management System"
        Me.Size = New Size(1300, 750)
        Me.IsMdiContainer = True
        Me.BackColor = UIHelper.ColorBackground

        ' ════════════════════════════════════════════════════════════
        '  TOP BAR — Deep blue with gold brand accent
        ' ════════════════════════════════════════════════════════════
        pnlTop = New Panel()
        pnlTop.Dock = DockStyle.Top
        pnlTop.Height = 58
        pnlTop.BackColor = UIHelper.ColorPrimary

        ' Gold accent stripe at very top
        Dim topStripe As New Panel()
        topStripe.Dock = DockStyle.Top
        topStripe.Height = 3
        topStripe.BackColor = UIHelper.ColorGold
        pnlTop.Controls.Add(topStripe)

        Dim lblBrand As New Label()
        lblBrand.Text = "⚽  Sports Tryout Management System"
        lblBrand.Font = New Font("Segoe UI Semibold", 12!, FontStyle.Bold)
        lblBrand.ForeColor = Color.White
        lblBrand.AutoSize = True
        lblBrand.Location = New Point(20, 20)
        pnlTop.Controls.Add(lblBrand)

        ' User info (name + role badge)
        lblUser = New Label()
        lblUser.Text = SessionManager.CurrentFullName
        lblUser.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
        lblUser.ForeColor = Color.White
        lblUser.AutoSize = True

        lblRole = New Label()
        lblRole.Text = " " & SessionManager.CurrentRole.ToUpper() & " "
        lblRole.Font = New Font("Segoe UI Semibold", 7.5!, FontStyle.Bold)
        lblRole.ForeColor = UIHelper.ColorPrimaryDark
        lblRole.BackColor = UIHelper.ColorGold
        lblRole.AutoSize = True
        lblRole.Padding = New Padding(4, 2, 4, 2)

        btnLogoutTop = UIHelper.MakeButton("Sign Out", 0, 0, 100, "danger")
        btnLogoutTop.Height = 32
        btnLogoutTop.Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold)
        AddHandler btnLogoutTop.Click, AddressOf BtnLogout_Click

        pnlTop.Controls.Add(lblUser)
        pnlTop.Controls.Add(lblRole)
        pnlTop.Controls.Add(btnLogoutTop)
        AddHandler pnlTop.Resize, AddressOf RepositionTopControls

        ' ════════════════════════════════════════════════════════════
        '  SIDEBAR — Midnight blue with subtle gold active indicators
        ' ════════════════════════════════════════════════════════════
        pnlNav = New Panel()
        pnlNav.Dock = DockStyle.Left
        pnlNav.Width = 240
        pnlNav.BackColor = UIHelper.ColorPrimaryDark
        pnlNav.AutoScroll = True

        ' Sidebar header
        Dim pnlSideHeader As New Panel()
        pnlSideHeader.Size = New Size(240, 50)
        pnlSideHeader.Location = New Point(0, 0)
        pnlSideHeader.BackColor = Color.FromArgb(10, 30, 58)

        Dim lblMenu As New Label()
        lblMenu.Text = "NAVIGATION"
        lblMenu.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblMenu.ForeColor = UIHelper.ColorGold
        lblMenu.Location = New Point(20, 18)
        lblMenu.AutoSize = True
        pnlSideHeader.Controls.Add(lblMenu)
        pnlNav.Controls.Add(pnlSideHeader)

        Dim navY As Integer = 60
        AddNavButton("📊  Dashboard", navY, AddressOf BtnDashboard_Click)
        navY += 44

        If SessionManager.IsAdmin Then
            navY = AddNavSection("ADMINISTRATION", navY)
            AddNavButton("👥  User Accounts", navY, AddressOf BtnUsers_Click)
            navY += 44
            AddNavButton("🏅  Sport Management", navY, AddressOf BtnSports_Click)
            navY += 44
        End If

        If SessionManager.IsAdmin OrElse SessionManager.IsStaff Then
            navY = AddNavSection("TRYOUT OPERATIONS", navY)
            AddNavButton("📅  Tryout Schedules", navY, AddressOf BtnSchedules_Click)
            navY += 44
            AddNavButton("📝  Student Registration", navY, AddressOf BtnRegistration_Click)
            navY += 44
        End If

        navY = AddNavSection("RECORDS & RESULTS", navY)
        AddNavButton("📋  Applicant Records", navY, AddressOf BtnApplicants_Click)
        navY += 44

        If SessionManager.IsAdmin OrElse SessionManager.IsCoach Then
            AddNavButton("⭐  Evaluation && Selection", navY, AddressOf BtnEvaluationSelection_Click)
            navY += 44
        End If

        AddNavButton("📈  Reports", navY, AddressOf BtnReports_Click)
        navY += 44

        navY = AddNavSection("ACCOUNT", navY)
        AddNavButton("🔒  Change Password", navY, AddressOf BtnChangePassword_Click)
        navY += 44

        ' Divider
        navY += 8
        Dim sep As New Panel()
        sep.Location = New Point(20, navY)
        sep.Size = New Size(200, 1)
        sep.BackColor = Color.FromArgb(40, 60, 90)
        pnlNav.Controls.Add(sep)
        navY += 12

        ' Log Out nav button
        AddNavLogoutButton("🚪  Sign Out", navY, AddressOf BtnLogout_Click)

        Me.Controls.Add(pnlTop)
        Me.Controls.Add(pnlNav)

        AddHandler Me.Resize, AddressOf RepositionTopControls
        AddHandler Me.Shown, AddressOf RepositionTopControls

        Me.WindowState = FormWindowState.Maximized
        RepositionTopControls()
    End Sub

    Private Function AddNavSection(sectionTitle As String, y As Integer) As Integer
        y += 10
        Dim lbl As New Label()
        lbl.Text = sectionTitle
        lbl.Font = New Font("Segoe UI Semibold", 7.5!, FontStyle.Bold)
        lbl.ForeColor = Color.FromArgb(100, 140, 180)
        lbl.Location = New Point(20, y)
        lbl.AutoSize = True
        pnlNav.Controls.Add(lbl)
        Return y + 22
    End Function

    Private Sub RepositionTopControls(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing)
        If pnlTop Is Nothing OrElse btnLogoutTop Is Nothing OrElse lblUser Is Nothing Then Return
        Dim topY As Integer = (pnlTop.ClientSize.Height - btnLogoutTop.Height) \ 2
        btnLogoutTop.Location = New Point(pnlTop.ClientSize.Width - btnLogoutTop.Width - 20, topY)
        lblRole.Location = New Point(btnLogoutTop.Left - lblRole.Width - 15, topY + 4)
        lblUser.Location = New Point(lblRole.Left - lblUser.Width - 10, topY + 4)
    End Sub

    Private Sub AddNavLogoutButton(text As String, y As Integer, handler As EventHandler)
        Dim btn As New Button()
        btn.Text = text
        btn.Location = New Point(10, y)
        btn.Size = New Size(220, 40)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 1
        btn.FlatAppearance.BorderColor = UIHelper.ColorDanger
        btn.BackColor = Color.FromArgb(50, UIHelper.ColorDanger.R, UIHelper.ColorDanger.G, UIHelper.ColorDanger.B)
        btn.ForeColor = Color.FromArgb(252, 165, 165)
        btn.Font = UIHelper.FontBold
        btn.TextAlign = ContentAlignment.MiddleCenter
        btn.Cursor = Cursors.Hand
        btn.FlatAppearance.MouseOverBackColor = UIHelper.ColorDanger
        AddHandler btn.Click, handler
        pnlNav.Controls.Add(btn)
    End Sub

    Private Sub AddNavButton(text As String, y As Integer, handler As EventHandler)
        Dim btn As New Button()
        btn.Text = text
        btn.Location = New Point(0, y)
        btn.Size = New Size(240, 42)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = UIHelper.ColorPrimaryDark
        btn.ForeColor = Color.FromArgb(190, 210, 235)
        btn.Font = UIHelper.FontRegular
        btn.TextAlign = ContentAlignment.MiddleLeft
        btn.Padding = New Padding(18, 0, 0, 0)
        btn.Cursor = Cursors.Hand
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 55, 95)

        ' Click handler with active state highlight
        Dim wrappedHandler As EventHandler = Sub(s, ev)
                                                 SetActiveNavButton(btn)
                                                 handler.Invoke(s, ev)
                                             End Sub
        AddHandler btn.Click, wrappedHandler
        pnlNav.Controls.Add(btn)
    End Sub

    Private Sub SetActiveNavButton(btn As Button)
        ' Reset all nav buttons
        If activeNavButton IsNot Nothing Then
            activeNavButton.BackColor = UIHelper.ColorPrimaryDark
            activeNavButton.ForeColor = Color.FromArgb(190, 210, 235)
            activeNavButton.Font = UIHelper.FontRegular
        End If
        ' Highlight active
        activeNavButton = btn
        btn.BackColor = Color.FromArgb(25, 55, 95)
        btn.ForeColor = UIHelper.ColorGoldLight
        btn.Font = UIHelper.FontBold
    End Sub

    Private Sub OpenChild(childForm As Form)
        For Each f As Form In Me.MdiChildren
            If f.GetType() Is childForm.GetType() Then
                f.Activate()
                childForm.Dispose()
                Return
            End If
        Next
        childForm.MdiParent = Me
        childForm.WindowState = FormWindowState.Maximized
        childForm.Show()
    End Sub

    Private Sub ShowDashboard()
        OpenChild(New frmDashboard())
    End Sub

    Private Sub BtnDashboard_Click(sender As Object, e As EventArgs)
        ShowDashboard()
    End Sub

    Private Sub BtnUsers_Click(sender As Object, e As EventArgs)
        OpenChild(New frmUserManagement())
    End Sub

    Private Sub BtnSports_Click(sender As Object, e As EventArgs)
        OpenChild(New frmSportManagement())
    End Sub

    Private Sub BtnSchedules_Click(sender As Object, e As EventArgs)
        OpenChild(New frmScheduleManagement())
    End Sub

    Private Sub BtnRegistration_Click(sender As Object, e As EventArgs)
        OpenChild(New frmStudentRegistration())
    End Sub

    Private Sub BtnApplicants_Click(sender As Object, e As EventArgs)
        OpenChild(New frmApplicantRecords())
    End Sub

    Private Sub BtnEvaluationSelection_Click(sender As Object, e As EventArgs)
        OpenChild(New frmEvaluationSelection())
    End Sub

    Private Sub BtnReports_Click(sender As Object, e As EventArgs)
        OpenChild(New frmReports())
    End Sub

    Private Sub BtnChangePassword_Click(sender As Object, e As EventArgs)
        OpenChild(New frmChangePassword())
    End Sub

    Private Sub BtnLogout_Click(sender As Object, e As EventArgs)
        If UIHelper.Confirm("Are you sure you want to sign out?") Then
            LoggedOut = True
            Me.Close()
        End If
    End Sub

End Class
