Public Class frmUserManagement

    Private selectedUserId As Integer = 0

    Public Sub New()
        InitializeComponent()
        LoadPermissionCatalog()
        Dim header As Panel = UIHelper.MakePanelHeader("User Account Management", Me.Width)
        Me.Controls.Add(header)
        header.SendToBack()
        AddHandler Me.Shown, AddressOf OnFormShown
    End Sub

    Private Sub LoadPermissionCatalog()
        clbPermissions.Items.Clear()
        For Each opt In Permissions.Catalog
            clbPermissions.Items.Add(opt)
        Next
    End Sub

    Private Sub OnFormShown(sender As Object, e As EventArgs)
        LoadUsers()
        Dim existing As DataGridViewRow = GetSelectedRow()
        If existing Is Nothing Then
            ApplyPermissions(Permissions.DefaultsForRole(cmbRole.Text))
        End If
    End Sub

    Private Function GetSelectedRow() As DataGridViewRow
        If dgv.SelectedRows.Count > 0 Then Return dgv.SelectedRows(0)
        Return Nothing
    End Function

    Private Sub LoadUsers()
        Try
            dgv.DataSource = DatabaseHelper.GetDataTable(
                "SELECT UserID, Username, FullName, Role, Permissions, CASE WHEN IsActive=1 THEN 'Yes' ELSE 'No' END AS Active, DateCreated " &
                "FROM Users ORDER BY FullName")
            If dgv.Columns.Contains("UserID") Then dgv.Columns("UserID").Visible = False
            If dgv.Columns.Contains("Permissions") Then dgv.Columns("Permissions").Visible = False
        Catch ex As Exception
            UIHelper.ShowError("Error loading users: " & ex.Message)
        End Try
    End Sub

    Private Sub Dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        If e.RowIndex < 0 Then Return
        Dim row As DataGridViewRow = dgv.Rows(e.RowIndex)
        selectedUserId = CInt(row.Cells("UserID").Value)
        txtUsername.Text = row.Cells("Username").Value.ToString()
        txtFullName.Text = row.Cells("FullName").Value.ToString()
        cmbRole.Text = row.Cells("Role").Value.ToString()
        chkIsActive.Checked = row.Cells("Active").Value.ToString() = "Yes"
        txtUsername.Enabled = False
        txtPassword.Text = ""

        Dim perms As String = Nothing
        If row.Cells("Permissions").Value IsNot Nothing AndAlso row.Cells("Permissions").Value IsNot DBNull.Value Then
            perms = row.Cells("Permissions").Value.ToString()
        End If
        ApplyPermissions(If(String.IsNullOrWhiteSpace(perms), Permissions.DefaultsForRole(cmbRole.Text), perms))
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtUsername.Text.Trim() = "" OrElse txtFullName.Text.Trim() = "" OrElse cmbRole.Text = "" OrElse txtPassword.Text = "" Then
            UIHelper.ShowError("Please fill in username, full name, role, and password.")
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

            UIHelper.ShowInfo("User account created successfully.")
            BtnClear_Click(sender, e)
            LoadUsers()
        Catch ex As Exception
            UIHelper.ShowError("Failed to add user: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedUserId = 0 Then
            UIHelper.ShowError("Select a user from the list first.")
            Return
        End If

        Try
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Users SET FullName=@f, Role=@r, Permissions=@perm, IsActive=@a WHERE UserID=@id",
                New SQLiteParameter("@f", txtFullName.Text.Trim()),
                New SQLiteParameter("@r", cmbRole.Text),
                New SQLiteParameter("@perm", SelectedPermissions()),
                New SQLiteParameter("@a", If(chkIsActive.Checked, 1, 0)),
                New SQLiteParameter("@id", selectedUserId))

            UIHelper.ShowInfo("User information updated.")
            BtnClear_Click(sender, e)
            LoadUsers()
        Catch ex As Exception
            UIHelper.ShowError("Failed to update user: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        If selectedUserId = 0 Then
            UIHelper.ShowError("Select a user from the list first.")
            Return
        End If
        If txtPassword.Text.Trim() = "" Then
            UIHelper.ShowError("Enter the new password in the Password field first.")
            Return
        End If

        Try
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Users SET PasswordHash=@p WHERE UserID=@id",
                New SQLiteParameter("@p", SecurityHelper.HashPassword(txtPassword.Text.Trim())),
                New SQLiteParameter("@id", selectedUserId))
            UIHelper.ShowInfo("Password reset successfully.")
            txtPassword.Text = ""
        Catch ex As Exception
            UIHelper.ShowError("Failed to reset password: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        selectedUserId = 0
        txtUsername.Text = ""
        txtFullName.Text = ""
        cmbRole.Text = ""
        txtPassword.Text = ""
        chkIsActive.Checked = True
        txtUsername.Enabled = True
        ApplyPermissions("")
    End Sub

    Private Sub CmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        ' When composing a brand-new account, preload the role's default permissions.
        If selectedUserId = 0 AndAlso cmbRole.SelectedIndex >= 0 Then
            ApplyPermissions(Permissions.DefaultsForRole(cmbRole.Text))
        End If
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
