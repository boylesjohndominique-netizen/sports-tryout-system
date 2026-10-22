Public Class frmMain

    Public LoggedOut As Boolean = False
    Private activeNavButton As Button = Nothing
    Private metricsTimer As Timer = Nothing

    Private canManageUsers As Boolean
    Private canManageSports As Boolean
    Private canManageSchedules As Boolean
    Private canManageRegistration As Boolean
    Private canViewApplicants As Boolean
    Private canEvaluate As Boolean
    Private canViewReports As Boolean

    Public Sub New()
        InitializeComponent()
        SetupNavRolePermissions()
        SetupEventHandlers()
    End Sub

    Private Sub SetupNavRolePermissions()
        ' Update user info and profile button in main navigation
        UpdateProfileDisplay()

        ' Permission based visibility
        canManageUsers = SessionManager.HasPermission(Permissions.ManageUsers)
        canManageSports = SessionManager.HasPermission(Permissions.ManageSports)
        canManageSchedules = SessionManager.HasPermission(Permissions.ManageSchedules)
        canManageRegistration = SessionManager.HasPermission(Permissions.ManageRegistration)
        canViewApplicants = SessionManager.HasPermission(Permissions.ViewApplicants)
        canEvaluate = SessionManager.HasPermission(Permissions.Evaluate)
        canViewReports = SessionManager.HasPermission(Permissions.ViewReports)

        lblAdminSection.Visible = canManageUsers OrElse canManageSports
        btnUsers.Visible = canManageUsers
        btnSports.Visible = canManageSports

        ' Combined Student Registration & Records into one button
        Dim canAccessRegistration As Boolean = canManageRegistration OrElse canViewApplicants
        lblOpsSection.Visible = canManageSchedules OrElse canAccessRegistration
        btnSchedules.Visible = canManageSchedules
        btnRegistration.Visible = canAccessRegistration

        ' Records section now contains Evaluation & Selection, and Reports
        lblRecordsSection.Visible = canEvaluate OrElse canViewReports
        btnApplicants.Visible = False
        btnEvaluation.Visible = canEvaluate
        btnReports.Visible = canViewReports

        ' Reflow nav layout based on visibility
        ReflowNavMenu()
    End Sub

    Private Sub ReflowNavMenu()
        pnlNav.SuspendLayout()
        Dim curY As Integer = 55
        btnDashboard.Location = New Point(0, curY)
        curY += 44

        If canManageUsers OrElse canManageSports Then
            lblAdminSection.Location = New Point(20, curY + 8)
            curY += 26
            If canManageUsers Then
                btnUsers.Location = New Point(0, curY)
                curY += 44
            End If
            If canManageSports Then
                btnSports.Location = New Point(0, curY)
                curY += 44
            End If
        End If

        Dim canAccessRegistration As Boolean = canManageRegistration OrElse canViewApplicants
        If canManageSchedules OrElse canAccessRegistration Then
            lblOpsSection.Location = New Point(20, curY + 8)
            curY += 26
            If canManageSchedules Then
                btnSchedules.Location = New Point(0, curY)
                curY += 44
            End If
            If canAccessRegistration Then
                btnRegistration.Location = New Point(0, curY)
                curY += 44
            End If
        End If

        If canEvaluate OrElse canViewReports Then
            lblRecordsSection.Location = New Point(20, curY + 8)
            curY += 26
            If canEvaluate Then
                btnEvaluation.Location = New Point(0, curY)
                curY += 44
            End If
            If canViewReports Then
                btnReports.Location = New Point(0, curY)
                curY += 44
            End If
        End If

        pnlNav.ResumeLayout(True)
    End Sub

    Private Sub SetupEventHandlers()
        AddHandler btnLogout.Click, AddressOf BtnLogout_Click
        AddHandler btnLogout.MouseEnter, Sub(s, ev) btnLogout.BackColor = Color.FromArgb(239, 68, 68)
        AddHandler btnLogout.MouseLeave, Sub(s, ev) btnLogout.BackColor = Color.FromArgb(220, 38, 38)

        ' Profile Button in Corner Right
        Dim profileClick As EventHandler = Sub(s, ev) ShowProfile()
        AddHandler pnlProfileBtn.Click, profileClick
        AddHandler pbProfileAvatar.Click, profileClick
        AddHandler lblProfileUser.Click, profileClick
        AddHandler lblProfileRole.Click, profileClick
        AddHandler lblProfileArrow.Click, profileClick

        Dim profileEnter As EventHandler = Sub(s, ev) pnlProfileBtn.BackColor = Color.FromArgb(28, 65, 110)
        Dim profileLeave As EventHandler = Sub(s, ev) pnlProfileBtn.BackColor = Color.FromArgb(16, 42, 76)
        AddHandler pnlProfileBtn.MouseEnter, profileEnter
        AddHandler pbProfileAvatar.MouseEnter, profileEnter
        AddHandler lblProfileUser.MouseEnter, profileEnter
        AddHandler lblProfileRole.MouseEnter, profileEnter
        AddHandler lblProfileArrow.MouseEnter, profileEnter

        AddHandler pnlProfileBtn.MouseLeave, profileLeave
        AddHandler pbProfileAvatar.MouseLeave, profileLeave
        AddHandler lblProfileUser.MouseLeave, profileLeave
        AddHandler lblProfileRole.MouseLeave, profileLeave
        AddHandler lblProfileArrow.MouseLeave, profileLeave

        AddHandler lblPendingPill.Click, AddressOf LblPendingPill_Click
        AddHandler lblSelectedPill.Click, AddressOf LblSelectedPill_Click

        AddNavClickHandler(btnDashboard, AddressOf BtnDashboard_Click)
        AddNavClickHandler(btnUsers, AddressOf BtnUsers_Click)
        AddNavClickHandler(btnSports, AddressOf BtnSports_Click)
        AddNavClickHandler(btnSchedules, AddressOf BtnSchedules_Click)
        AddNavClickHandler(btnRegistration, AddressOf BtnRegistration_Click)
        AddNavClickHandler(btnApplicants, AddressOf BtnApplicants_Click)
        AddNavClickHandler(btnEvaluation, AddressOf BtnEvaluationSelection_Click)
        AddNavClickHandler(btnReports, AddressOf BtnReports_Click)

        AddHandler pnlTop.Resize, AddressOf RepositionTopControls
        AddHandler Me.Shown, AddressOf RepositionTopControls
        AddHandler Me.Shown, AddressOf OnMainShown
        AddHandler Me.Activated, Sub(s, ev)
                                      RefreshNavMetrics()
                                      UpdateProfileDisplay()
                                  End Sub

        ' Periodic refresh of operational metrics across all pages
        metricsTimer = New Timer()
        metricsTimer.Interval = 5000
        AddHandler metricsTimer.Tick, Sub(s, ev) RefreshNavMetrics()
        metricsTimer.Start()

        AddHandler Me.FormClosed, Sub(s, ev)
                                      If metricsTimer IsNot Nothing Then
                                          metricsTimer.Stop()
                                          metricsTimer.Dispose()
                                          metricsTimer = Nothing
                                      End If
                                  End Sub
    End Sub

    Private Sub AddNavClickHandler(btn As Button, handler As EventHandler)
        AddHandler btn.Click, Sub(s, ev)
                                  SetActiveNavButton(btn)
                                  handler.Invoke(s, ev)
                              End Sub
    End Sub

    Private Sub RepositionTopControls(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing)
        If pnlTop Is Nothing OrElse pnlProfileBtn Is Nothing Then Return

        Dim centerY As Integer = (pnlTop.ClientSize.Height - 3) \ 2 + 1

        ' 1. Re-measure and position profile pill inside corner right
        If lblProfileUser IsNot Nothing AndAlso lblProfileRole IsNot Nothing AndAlso lblProfileArrow IsNot Nothing Then
            lblProfileUser.Location = New Point(38, (pnlProfileBtn.Height - lblProfileUser.Height) \ 2)
            lblProfileRole.Location = New Point(lblProfileUser.Right + 8, (pnlProfileBtn.Height - lblProfileRole.Height) \ 2)
            lblProfileArrow.Location = New Point(lblProfileRole.Right + 8, (pnlProfileBtn.Height - lblProfileArrow.Height) \ 2)
            pnlProfileBtn.Width = lblProfileArrow.Right + 12
        End If

        Dim profY As Integer = centerY - (pnlProfileBtn.Height \ 2)
        pnlProfileBtn.Location = New Point(pnlTop.ClientSize.Width - pnlProfileBtn.Width - 18, Math.Max(10, profY))

        ' 2. Navigation Pills (next to main title label)
        If pnlPills IsNot Nothing AndAlso lblBrand IsNot Nothing Then
            Dim pillsY As Integer = centerY - (pnlPills.Height \ 2)
            Dim targetX As Integer = lblBrand.Right + 24

            ' Responsive protection: if window is resized narrow, ensure pills don't collide with profile button
            If targetX + pnlPills.Width > pnlProfileBtn.Left - 10 Then
                targetX = Math.Max(lblBrand.Right + 10, pnlProfileBtn.Left - pnlPills.Width - 10)
            End If

            pnlPills.Location = New Point(targetX, Math.Max(12, pillsY))
        End If
    End Sub

    Private Sub SetActiveNavButton(btn As Button)
        Try
            Dim allNavBtns As Button() = {btnDashboard, btnUsers, btnSports, btnSchedules, btnRegistration, btnApplicants, btnEvaluation, btnReports}
            For Each b In allNavBtns
                If b IsNot Nothing Then
                    b.BackColor = Color.FromArgb(12, 32, 62)
                    b.ForeColor = Color.FromArgb(190, 210, 235)
                    b.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
                End If
            Next

            activeNavButton = btn
            If btn IsNot Nothing Then
                btn.BackColor = Color.FromArgb(25, 55, 95)
                btn.ForeColor = Color.FromArgb(250, 204, 21)
                btn.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
            End If
        Catch
        End Try
    End Sub

    Public Sub OpenChild(childForm As Form)
        Try
            If childForm Is Nothing Then Return

            ' Close and dispose previous MDI children to avoid multi-maximized MDI collisions
            ' in native WinForms window callback
            Dim existingChildren As Form() = Me.MdiChildren
            For Each f As Form In existingChildren
                If f.GetType() Is childForm.GetType() Then
                    f.WindowState = FormWindowState.Maximized
                    f.BringToFront()
                    f.Activate()
                    Try
                        childForm.Dispose()
                    Catch
                    End Try
                    Return
                Else
                    Try
                        f.Close()
                        f.Dispose()
                    Catch
                    End Try
                End If
            Next

            childForm.MdiParent = Me
            childForm.WindowState = FormWindowState.Maximized
            childForm.Show()
            childForm.BringToFront()
            RefreshNavMetrics()
        Catch ex As Exception
            Try
                If childForm IsNot Nothing Then childForm.Dispose()
            Catch
            End Try
            UIHelper.ShowError("Failed to open form: " & ex.Message)
        End Try
    End Sub

    Private Sub ShowDashboard()
        Try
            SetActiveNavButton(btnDashboard)
            OpenChild(New frmDashboard())
        Catch ex As Exception
            UIHelper.ShowError("Could not open Dashboard: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnDashboard_Click(sender As Object, e As EventArgs)
        ShowDashboard()
    End Sub

    Private Sub BtnUsers_Click(sender As Object, e As EventArgs)
        Try
            OpenChild(New frmUserManagement())
        Catch ex As Exception
            UIHelper.ShowError("Could not open User Management: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnSports_Click(sender As Object, e As EventArgs)
        Try
            OpenChild(New frmSportManagement())
        Catch ex As Exception
            UIHelper.ShowError("Could not open Sport Management: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnSchedules_Click(sender As Object, e As EventArgs)
        Try
            OpenChild(New frmScheduleManagement())
        Catch ex As Exception
            UIHelper.ShowError("Could not open Schedule Management: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnRegistration_Click(sender As Object, e As EventArgs)
        Try
            OpenChild(New frmStudentRegistration())
        Catch ex As Exception
            UIHelper.ShowError("Could not open Registration: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnApplicants_Click(sender As Object, e As EventArgs)
        BtnRegistration_Click(sender, e)
    End Sub

    Private Sub BtnEvaluationSelection_Click(sender As Object, e As EventArgs)
        Try
            OpenChild(New frmEvaluationSelection())
        Catch ex As Exception
            UIHelper.ShowError("Could not open Evaluation & Selection: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnReports_Click(sender As Object, e As EventArgs)
        Try
            OpenChild(New frmReports())
        Catch ex As Exception
            UIHelper.ShowError("Could not open Reports: " & ex.Message)
        End Try
    End Sub

    Public Sub ShowProfile()
        Try
            SetActiveNavButton(Nothing)
            OpenChild(New frmProfile())
        Catch ex As Exception
            UIHelper.ShowError("Could not open Profile: " & ex.Message)
        End Try
    End Sub

    Public Sub UpdateProfileDisplay()
        Try
            Dim name As String = If(String.IsNullOrEmpty(SessionManager.CurrentFullName), "Administrator", SessionManager.CurrentFullName)
            Dim role As String = If(String.IsNullOrEmpty(SessionManager.CurrentRole), "ADMIN", SessionManager.CurrentRole.ToUpper())

            If lblProfileUser IsNot Nothing Then lblProfileUser.Text = name
            If lblProfileRole IsNot Nothing Then lblProfileRole.Text = " " & role & " "

            ' Load profile picture or default initials avatar
            If pbProfileAvatar IsNot Nothing Then
                Dim pic As Image = Nothing
                If Not String.IsNullOrEmpty(SessionManager.CurrentProfilePictureBase64) Then
                    Dim rawPic = UIHelper.Base64ToImage(SessionManager.CurrentProfilePictureBase64)
                    If rawPic IsNot Nothing Then
                        pic = UIHelper.MakeCircularImage(rawPic, 28)
                    End If
                End If

                If pic Is Nothing Then
                    pic = UIHelper.CreateDefaultAvatar(name, 28)
                End If

                If pbProfileAvatar.Image IsNot Nothing Then
                    Try : pbProfileAvatar.Image.Dispose() : Catch : End Try
                End If
                pbProfileAvatar.Image = pic
            End If

            RepositionTopControls()
        Catch
        End Try
    End Sub

    Private Sub BtnLogout_Click(sender As Object, e As EventArgs)
        If UIHelper.Confirm("Are you sure you want to sign out?") Then
            LoggedOut = True
            Me.Close()
        End If
    End Sub

    Public Sub RefreshNavMetrics()
        Try
            If lblDatePill IsNot Nothing Then
                lblDatePill.Text = DateTime.Now.ToString("MMMM dd, yyyy")
            End If

            Dim pendingCount As Integer = 0
            Dim selectedCount As Integer = 0

            Dim resPending As Object = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Registrations WHERE SelectionStatus='Pending'")
            If resPending IsNot Nothing AndAlso Not IsDBNull(resPending) Then
                pendingCount = Convert.ToInt32(resPending)
            End If

            Dim resSelected As Object = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Registrations WHERE SelectionStatus='Selected'")
            If resSelected IsNot Nothing AndAlso Not IsDBNull(resSelected) Then
                selectedCount = Convert.ToInt32(resSelected)
            End If

            If lblPendingPill IsNot Nothing Then
                lblPendingPill.Text = String.Format("● {0} Pending Decisions", pendingCount)
            End If
            If lblSelectedPill IsNot Nothing Then
                lblSelectedPill.Text = String.Format("✓ {0} Selected", selectedCount)
            End If

            RepositionTopControls()
        Catch
        End Try
    End Sub

    Private Sub LblPendingPill_Click(sender As Object, e As EventArgs)
        If canEvaluate Then
            BtnEvaluationSelection_Click(sender, e)
        ElseIf canManageRegistration OrElse canViewApplicants Then
            BtnRegistration_Click(sender, e)
        End If
    End Sub

    Private Sub LblSelectedPill_Click(sender As Object, e As EventArgs)
        If canManageRegistration OrElse canViewApplicants Then
            BtnRegistration_Click(sender, e)
        ElseIf canEvaluate Then
            BtnEvaluationSelection_Click(sender, e)
        End If
    End Sub

    Private Sub OnMainShown(sender As Object, e As EventArgs)
        UpdateProfileDisplay()
        RefreshNavMetrics()
        RepositionTopControls()
        ShowDashboard()
    End Sub

End Class
