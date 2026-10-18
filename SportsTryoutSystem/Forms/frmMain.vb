Public Class frmMain

    Public LoggedOut As Boolean = False
    Private activeNavButton As Button = Nothing

    Public Sub New()
        InitializeComponent()
        SetupNavRolePermissions()
        SetupEventHandlers()
    End Sub

    Private Sub SetupNavRolePermissions()
        ' Update user info
        lblUser.Text = If(String.IsNullOrEmpty(SessionManager.CurrentFullName), "Administrator", SessionManager.CurrentFullName)
        lblRole.Text = " " & If(String.IsNullOrEmpty(SessionManager.CurrentRole), "ADMIN", SessionManager.CurrentRole.ToUpper()) & " "

        ' Role based visibility
        Dim isAdmin As Boolean = SessionManager.IsAdmin
        Dim isStaffOrAdmin As Boolean = SessionManager.IsAdmin OrElse SessionManager.IsStaff
        Dim isCoachOrAdmin As Boolean = SessionManager.IsAdmin OrElse SessionManager.IsCoach

        lblAdminSection.Visible = isAdmin
        btnUsers.Visible = isAdmin
        btnSports.Visible = isAdmin

        lblOpsSection.Visible = isStaffOrAdmin
        btnSchedules.Visible = isStaffOrAdmin
        btnRegistration.Visible = isStaffOrAdmin

        lblRecordsSection.Visible = True
        btnApplicants.Visible = True
        btnEvaluation.Visible = isCoachOrAdmin
        btnReports.Visible = True

        ' Reflow nav layout based on visibility
        ReflowNavMenu()
    End Sub

    Private Sub ReflowNavMenu()
        pnlNav.SuspendLayout()
        Dim curY As Integer = 55
        btnDashboard.Location = New Point(0, curY)
        curY += 44

        If lblAdminSection.Visible Then
            lblAdminSection.Location = New Point(20, curY + 8)
            curY += 26
            btnUsers.Location = New Point(0, curY)
            curY += 44
            btnSports.Location = New Point(0, curY)
            curY += 44
        End If

        If lblOpsSection.Visible Then
            lblOpsSection.Location = New Point(20, curY + 8)
            curY += 26
            btnSchedules.Location = New Point(0, curY)
            curY += 44
            btnRegistration.Location = New Point(0, curY)
            curY += 44
        End If

        If lblRecordsSection.Visible Then
            lblRecordsSection.Location = New Point(20, curY + 8)
            curY += 26
            btnApplicants.Location = New Point(0, curY)
            curY += 44
            If btnEvaluation.Visible Then
                btnEvaluation.Location = New Point(0, curY)
                curY += 44
            End If
            btnReports.Location = New Point(0, curY)
            curY += 44
        End If

        lblAccountSection.Location = New Point(20, curY + 8)
        curY += 26
        btnChangePassword.Location = New Point(0, curY)
        curY += 44

        pnlNav.ResumeLayout(True)
    End Sub

    Private Sub SetupEventHandlers()
        AddHandler btnLogoutTop.Click, AddressOf BtnLogout_Click

        AddNavClickHandler(btnDashboard, AddressOf BtnDashboard_Click)
        AddNavClickHandler(btnUsers, AddressOf BtnUsers_Click)
        AddNavClickHandler(btnSports, AddressOf BtnSports_Click)
        AddNavClickHandler(btnSchedules, AddressOf BtnSchedules_Click)
        AddNavClickHandler(btnRegistration, AddressOf BtnRegistration_Click)
        AddNavClickHandler(btnApplicants, AddressOf BtnApplicants_Click)
        AddNavClickHandler(btnEvaluation, AddressOf BtnEvaluationSelection_Click)
        AddNavClickHandler(btnReports, AddressOf BtnReports_Click)
        AddNavClickHandler(btnChangePassword, AddressOf BtnChangePassword_Click)

        AddHandler pnlTop.Resize, AddressOf RepositionTopControls
        AddHandler Me.Shown, AddressOf RepositionTopControls
        AddHandler Me.Shown, AddressOf OnMainShown
    End Sub

    Private Sub AddNavClickHandler(btn As Button, handler As EventHandler)
        AddHandler btn.Click, Sub(s, ev)
                                  SetActiveNavButton(btn)
                                  handler.Invoke(s, ev)
                              End Sub
    End Sub

    Private Sub RepositionTopControls(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing)
        If pnlTop Is Nothing OrElse btnLogoutTop Is Nothing OrElse lblUser Is Nothing Then Return
        Dim topY As Integer = (pnlTop.ClientSize.Height - btnLogoutTop.Height) \ 2
        btnLogoutTop.Location = New Point(pnlTop.ClientSize.Width - btnLogoutTop.Width - 20, topY)
        lblRole.Location = New Point(btnLogoutTop.Left - lblRole.Width - 15, topY + 4)
        lblUser.Location = New Point(lblRole.Left - lblUser.Width - 10, topY + 4)
    End Sub

    Private Sub SetActiveNavButton(btn As Button)
        Try
            Dim allNavBtns As Button() = {btnDashboard, btnUsers, btnSports, btnSchedules, btnRegistration, btnApplicants, btnEvaluation, btnReports, btnChangePassword}
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
        Try
            OpenChild(New frmApplicantRecords())
        Catch ex As Exception
            UIHelper.ShowError("Could not open Applicant Records: " & ex.Message)
        End Try
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

    Private Sub BtnChangePassword_Click(sender As Object, e As EventArgs)
        Try
            OpenChild(New frmChangePassword())
        Catch ex As Exception
            UIHelper.ShowError("Could not open Change Password: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnLogout_Click(sender As Object, e As EventArgs)
        If UIHelper.Confirm("Are you sure you want to sign out?") Then
            LoggedOut = True
            Me.Close()
        End If
    End Sub

    Private Sub OnMainShown(sender As Object, e As EventArgs)
        ShowDashboard()
    End Sub

End Class
