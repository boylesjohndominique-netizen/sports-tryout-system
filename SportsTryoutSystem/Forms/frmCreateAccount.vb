Public Class frmCreateAccount
    Inherits System.Windows.Forms.Form

    Private pnlCard As Panel
    Private txtUsername As TextBox
    Private txtFullName As TextBox
    Private cmbRole As ComboBox
    Private txtPassword As TextBox
    Private txtConfirm As TextBox
    Private clbPermissions As CheckedListBox
    Private chkIsActive As CheckBox
    Private btnCreate As Button
    Private btnClear As Button

    Public Sub New()
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        Me.Text = "Create User Account"
        Me.ClientSize = New Size(1000, 620)
        Me.BackColor = UIHelper.ColorBackground
        Me.Font = UIHelper.FontRegular
        Me.StartPosition = FormStartPosition.CenterParent

        Dim header As Panel = UIHelper.MakePanelHeader("Create User Account", Me.Width)
        Me.Controls.Add(header)
        header.SendToBack()

        pnlCard = New Panel()
        pnlCard.BackColor = Color.White
        pnlCard.Location = New Point(30, 80)
        pnlCard.Size = New Size(940, 520)
        Me.Controls.Add(pnlCard)

        Dim accent As New Panel()
        accent.BackColor = UIHelper.ColorGold
        accent.Dock = DockStyle.Top
        accent.Height = 3
        pnlCard.Controls.Add(accent)

        ' ── Left column: account details ──
        AddFieldLabel("USERNAME", 30, 30)
        txtUsername = UIHelper.MakeTextBox(30, 52, 280)
        pnlCard.Controls.Add(txtUsername)

        AddFieldLabel("FULL NAME", 30, 100)
        txtFullName = UIHelper.MakeTextBox(30, 122, 280)
        pnlCard.Controls.Add(txtFullName)

        AddFieldLabel("ROLE", 30, 170)
        cmbRole = UIHelper.MakeComboBox(30, 192, 280)
        cmbRole.Items.AddRange(New Object() {"Coach", "Evaluator", "Staff"})
        pnlCard.Controls.Add(cmbRole)

        AddFieldLabel("PASSWORD", 30, 240)
        txtPassword = UIHelper.MakeTextBox(30, 262, 280, True)
        pnlCard.Controls.Add(txtPassword)

        AddFieldLabel("CONFIRM PASSWORD", 30, 310)
        txtConfirm = UIHelper.MakeTextBox(30, 332, 280, True)
        pnlCard.Controls.Add(txtConfirm)

        ' ── Right column: permissions ──
        AddFieldLabel("PERMISSIONS ALLOWED", 350, 30)
        clbPermissions = New CheckedListBox()
        clbPermissions.Location = New Point(350, 52)
        clbPermissions.Size = New Size(560, 310)
        clbPermissions.Font = UIHelper.FontRegular
        clbPermissions.ForeColor = UIHelper.ColorTextPrimary
        clbPermissions.BorderStyle = BorderStyle.FixedSingle
        clbPermissions.CheckOnClick = True
        For Each opt In Permissions.Catalog
            clbPermissions.Items.Add(opt)
        Next
        pnlCard.Controls.Add(clbPermissions)

        chkIsActive = New CheckBox()
        chkIsActive.Text = "Account is active"
        chkIsActive.Checked = True
        chkIsActive.AutoSize = True
        chkIsActive.Font = UIHelper.FontRegular
        chkIsActive.ForeColor = UIHelper.ColorTextPrimary
        chkIsActive.Location = New Point(350, 378)
        pnlCard.Controls.Add(chkIsActive)

        btnCreate = UIHelper.MakeButton("✚  Create Account", 350, 420, 200, "success")
        pnlCard.Controls.Add(btnCreate)

        btnClear = UIHelper.MakeButton("Clear", 560, 420, 120, "secondary")
        pnlCard.Controls.Add(btnClear)

        AddHandler cmbRole.SelectedIndexChanged, AddressOf CmbRole_SelectedIndexChanged
        AddHandler btnCreate.Click, AddressOf BtnCreate_Click
        AddHandler btnClear.Click, AddressOf BtnClear_Click
        AddHandler Me.Shown, AddressOf OnFormShown

        cmbRole.SelectedIndex = 0
        ApplyPermissions(Permissions.DefaultsForRole(cmbRole.Text))
    End Sub

    Private Sub AddFieldLabel(text As String, x As Integer, y As Integer)
        Dim lbl As New Label()
        lbl.Text = text
        lbl.AutoSize = True
        lbl.Font = New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold)
        lbl.ForeColor = UIHelper.ColorTextSecondary
        lbl.Location = New Point(x, y)
        pnlCard.Controls.Add(lbl)
    End Sub

    Private Sub OnFormShown(sender As Object, e As EventArgs)
        If Not SessionManager.HasPermission(Permissions.ManageUsers) Then
            UIHelper.ShowError("You do not have permission to create user accounts.")
            Me.Close()
        End If
    End Sub

    Private Sub CmbRole_SelectedIndexChanged(sender As Object, e As EventArgs)
        ApplyPermissions(Permissions.DefaultsForRole(cmbRole.Text))
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs)
        If txtUsername.Text.Trim() = "" OrElse txtFullName.Text.Trim() = "" OrElse cmbRole.Text = "" OrElse txtPassword.Text = "" Then
            UIHelper.ShowError("Please fill in username, full name, role, and password.")
            Return
        End If

        If txtPassword.Text <> txtConfirm.Text Then
            UIHelper.ShowError("The password and confirmation do not match.")
            Return
        End If

        Try
            Dim existing As Object = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Users WHERE Username=@u", New SQLiteParameter("@u", txtUsername.Text.Trim()))
            If CInt(existing) > 0 Then
                UIHelper.ShowError("That username already exists.")
                Return
            End If

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Users (Username, PasswordHash, FullName, Role, Permissions, IsActive, DateCreated) VALUES (@u,@p,@f,@r,@perm,@a,@d)",
                New SQLiteParameter("@u", txtUsername.Text.Trim()),
                New SQLiteParameter("@p", SecurityHelper.HashPassword(txtPassword.Text)),
                New SQLiteParameter("@f", txtFullName.Text.Trim()),
                New SQLiteParameter("@r", cmbRole.Text),
                New SQLiteParameter("@perm", SelectedPermissions()),
                New SQLiteParameter("@a", If(chkIsActive.Checked, 1, 0)),
                New SQLiteParameter("@d", Now.ToString("s")))

            UIHelper.ShowInfo("The " & cmbRole.Text & " account for " & txtFullName.Text.Trim() & " was created successfully.")
            ClearForm()
        Catch ex As Exception
            UIHelper.ShowError("Failed to create account: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtUsername.Text = ""
        txtFullName.Text = ""
        txtPassword.Text = ""
        txtConfirm.Text = ""
        chkIsActive.Checked = True
        cmbRole.SelectedIndex = 0
        ApplyPermissions(Permissions.DefaultsForRole(cmbRole.Text))
        txtUsername.Focus()
    End Sub

    ''' <summary>Comma-separated keys for the currently checked permissions.</summary>
    Private Function SelectedPermissions() As String
        Dim keys As New List(Of String)
        For Each item As Object In clbPermissions.CheckedItems
            Dim opt As Permissions.PermissionItem = TryCast(item, Permissions.PermissionItem)
            If opt IsNot Nothing Then keys.Add(opt.Key)
        Next
        Return String.Join(",", keys)
    End Function

    Private Sub ApplyPermissions(keys As String)
        Dim selected As HashSet(Of String) = Permissions.Parse(keys)
        For i As Integer = 0 To clbPermissions.Items.Count - 1
            Dim opt As Permissions.PermissionItem = DirectCast(clbPermissions.Items(i), Permissions.PermissionItem)
            clbPermissions.SetItemChecked(i, selected.Contains(opt.Key))
        Next
    End Sub

End Class
