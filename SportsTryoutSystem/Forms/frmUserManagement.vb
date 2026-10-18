Public Class frmUserManagement

    Private selectedUserId As Integer = 0

    Public Sub New()
        InitializeComponent()
        Dim header As Panel = UIHelper.MakePanelHeader("User Account Management", Me.Width)
        Me.Controls.Add(header)
        header.SendToBack()
        AddHandler Me.Shown, AddressOf OnFormShown
    End Sub

    Private Sub OnFormShown(sender As Object, e As EventArgs)
        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        Try
            dgv.DataSource = DatabaseHelper.GetDataTable(
                "SELECT UserID, Username, FullName, Role, CASE WHEN IsActive=1 THEN 'Yes' ELSE 'No' END AS Active, DateCreated " &
                "FROM Users ORDER BY FullName")
            If dgv.Columns.Contains("UserID") Then dgv.Columns("UserID").Visible = False
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
                "INSERT INTO Users (Username, PasswordHash, FullName, Role, IsActive, DateCreated) VALUES (@u,@p,@f,@r,@a,@d)",
                New SQLiteParameter("@u", txtUsername.Text.Trim()),
                New SQLiteParameter("@p", SecurityHelper.HashPassword(txtPassword.Text)),
                New SQLiteParameter("@f", txtFullName.Text.Trim()),
                New SQLiteParameter("@r", cmbRole.Text),
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
                "UPDATE Users SET FullName=@f, Role=@r, IsActive=@a WHERE UserID=@id",
                New SQLiteParameter("@f", txtFullName.Text.Trim()),
                New SQLiteParameter("@r", cmbRole.Text),
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
    End Sub

End Class
