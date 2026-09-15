Public Class frmUserManagement
    Inherits Form

    Private dgv As DataGridView
    Private txtUsername As TextBox
    Private txtFullName As TextBox
    Private txtPassword As TextBox
    Private cmbRole As ComboBox
    Private chkIsActive As CheckBox
    Private selectedUserId As Integer = 0

    Public Sub New()
        Me.Text = "User Account Management"
        Me.Dock = DockStyle.Fill
        Me.BackColor = UIHelper.ColorBackground
        BuildUI()
        LoadUsers()
    End Sub

    Private Sub BuildUI()
        Dim header As Panel = UIHelper.MakePanelHeader("User Account Management", Me.Width)
        Me.Controls.Add(header)

        ' ── Input card ──
        Dim pnlForm As New Panel()
        pnlForm.Location = New Point(30, 75)
        pnlForm.Size = New Size(950, 125)
        pnlForm.BackColor = Color.White
        pnlForm.BorderStyle = BorderStyle.None

        Dim formAccent As New Panel()
        formAccent.Dock = DockStyle.Top
        formAccent.Height = 3
        formAccent.BackColor = UIHelper.ColorGold
        pnlForm.Controls.Add(formAccent)

        Dim lblUsername As Label = UIHelper.MakeLabel("USERNAME", 20, 12, 150)
        lblUsername.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblUsername.ForeColor = UIHelper.ColorTextSecondary
        txtUsername = UIHelper.MakeTextBox(20, 32, 200)

        Dim lblFullName As Label = UIHelper.MakeLabel("FULL NAME", 240, 12, 150)
        lblFullName.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblFullName.ForeColor = UIHelper.ColorTextSecondary
        txtFullName = UIHelper.MakeTextBox(240, 32, 200)

        Dim lblRole As Label = UIHelper.MakeLabel("ROLE", 460, 12, 150)
        lblRole.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblRole.ForeColor = UIHelper.ColorTextSecondary
        cmbRole = UIHelper.MakeComboBox(460, 32, 140)
        cmbRole.Items.AddRange(New String() {"Admin", "Coach", "Staff"})

        Dim lblPassword As Label = UIHelper.MakeLabel("PASSWORD (NEW / RESET)", 620, 12, 200)
        lblPassword.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblPassword.ForeColor = UIHelper.ColorTextSecondary
        txtPassword = UIHelper.MakeTextBox(620, 32, 180, True)

        chkIsActive = New CheckBox()
        chkIsActive.Text = "Active"
        chkIsActive.Location = New Point(820, 34)
        chkIsActive.Checked = True
        chkIsActive.Font = UIHelper.FontRegular
        chkIsActive.ForeColor = UIHelper.ColorTextPrimary

        pnlForm.Controls.Add(lblUsername)
        pnlForm.Controls.Add(txtUsername)
        pnlForm.Controls.Add(lblFullName)
        pnlForm.Controls.Add(txtFullName)
        pnlForm.Controls.Add(lblRole)
        pnlForm.Controls.Add(cmbRole)
        pnlForm.Controls.Add(lblPassword)
        pnlForm.Controls.Add(txtPassword)
        pnlForm.Controls.Add(chkIsActive)

        ' ── Action buttons inside card ──
        Dim btnAdd As Button = UIHelper.MakeButton("✚ Add User", 20, 76, 130, "success")
        btnAdd.Height = 34
        AddHandler btnAdd.Click, AddressOf BtnAdd_Click
        pnlForm.Controls.Add(btnAdd)

        Dim btnUpdate As Button = UIHelper.MakeButton("✎ Update Info", 158, 76, 140, "primary")
        btnUpdate.Height = 34
        AddHandler btnUpdate.Click, AddressOf BtnUpdate_Click
        pnlForm.Controls.Add(btnUpdate)

        Dim btnResetPassword As Button = UIHelper.MakeButton("🔑 Reset Password", 306, 76, 170, "warning")
        btnResetPassword.Height = 34
        AddHandler btnResetPassword.Click, AddressOf BtnResetPassword_Click
        pnlForm.Controls.Add(btnResetPassword)

        Dim btnClear As Button = UIHelper.MakeButton("Clear Form", 484, 76, 120, "secondary")
        btnClear.Height = 34
        AddHandler btnClear.Click, AddressOf BtnClear_Click
        pnlForm.Controls.Add(btnClear)

        Me.Controls.Add(pnlForm)

        ' ── Data grid ──
        dgv = UIHelper.MakeDataGridView(30, 215, 950, 360)
        AddHandler dgv.CellClick, AddressOf Dgv_CellClick
        Me.Controls.Add(dgv)
    End Sub

    Private Sub LoadUsers()
        dgv.DataSource = DatabaseHelper.GetDataTable(
            "SELECT UserID, Username, FullName, Role, CASE WHEN IsActive=1 THEN 'Yes' ELSE 'No' END AS Active, DateCreated " &
            "FROM Users ORDER BY FullName")
        If dgv.Columns.Contains("UserID") Then dgv.Columns("UserID").Visible = False
    End Sub

    Private Sub Dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs)
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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
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

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs)
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

    Private Sub BtnResetPassword_Click(sender As Object, e As EventArgs)
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

    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        selectedUserId = 0
        txtUsername.Text = ""
        txtFullName.Text = ""
        cmbRole.Text = ""
        txtPassword.Text = ""
        chkIsActive.Checked = True
        txtUsername.Enabled = True
    End Sub

End Class
