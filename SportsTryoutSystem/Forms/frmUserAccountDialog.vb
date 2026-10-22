Imports System.Data
Imports System.Drawing

''' <summary>
''' Floating pop-up modal dialog for creating and editing user accounts.
''' Handles credential verification, role assignment, and granular permission sets.
''' </summary>
Public Class frmUserAccountDialog

    Private targetUserId As Integer = 0
    Private isEditMode As Boolean = False

    Public Sub New(Optional userId As Integer = 0)
        InitializeComponent()
        Me.targetUserId = userId
        Me.isEditMode = (userId > 0)
        SetupDialog()
    End Sub

    Private Sub SetupDialog()
        ' Paint card border
        AddHandler cardContent.Paint, AddressOf DrawCardBorder

        ' Wire action events
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        AddHandler btnCancel.Click, Sub(s, e) Me.Close()
        AddHandler chkShowPassword.CheckedChanged, AddressOf ChkShowPassword_CheckedChanged
        AddHandler cmbRole.SelectedIndexChanged, AddressOf CmbRole_SelectedIndexChanged
        AddHandler btnRoleDefaults.Click, AddressOf BtnRoleDefaults_Click

        ' Populate permissions checklist from catalog
        clbPermissions.Items.Clear()
        For Each opt In Permissions.Catalog
            clbPermissions.Items.Add(opt)
        Next

        If isEditMode Then
            ' ── EDIT MODE ──
            Me.Text = "Edit User Account"
            lblTitle.Text = "✏️  Edit User Account"
            lblSub.Text = "Update account details, role permissions, or reset login password."
            btnSave.Text = "💾  Save Changes"
            lblPassword.Text = "NEW PASSWORD (OPTIONAL)"
            lblPasswordHint.Text = "(Leave blank to keep current)"

            txtUsername.ReadOnly = True
            txtUsername.BackColor = Color.FromArgb(241, 245, 249)

            LoadExistingUserData()
        Else
            ' ── CREATE MODE ──
            Me.Text = "Create New User Account"
            lblTitle.Text = "✚  Create New User Account"
            lblSub.Text = "Set up login credentials, profile details, and role module permissions."
            btnSave.Text = "✚  Create Account"
            lblPassword.Text = "PASSWORD *"
            lblPasswordHint.Text = "(Min 6 characters)"

            chkIsActive.Checked = True
            cmbRole.SelectedItem = "Staff"
            ApplyPermissions(Permissions.DefaultsForRole("Staff"))
        End If
    End Sub

    Private Sub DrawCardBorder(sender As Object, e As PaintEventArgs)
        Dim pnl = TryCast(sender, Panel)
        If pnl Is Nothing Then Return
        Using pen As New Pen(Color.FromArgb(226, 232, 240), 1)
            e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
    End Sub

    Private Sub LoadExistingUserData()
        lblFeedback.Text = ""
        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT * FROM Users WHERE UserID=@id",
                New SQLiteParameter("@id", targetUserId))

            If dt.Rows.Count > 0 Then
                Dim row = dt.Rows(0)
                txtUsername.Text = row("Username").ToString()
                txtFullName.Text = row("FullName").ToString()
                cmbRole.SelectedItem = row("Role").ToString()
                txtEmail.Text = If(dt.Columns.Contains("Email") AndAlso Not IsDBNull(row("Email")), row("Email").ToString(), "")
                txtContact.Text = If(dt.Columns.Contains("ContactNumber") AndAlso Not IsDBNull(row("ContactNumber")), row("ContactNumber").ToString(), "")

                Dim activeVal As Integer = 1
                If dt.Columns.Contains("IsActive") AndAlso Not IsDBNull(row("IsActive")) Then
                    activeVal = Convert.ToInt32(row("IsActive"))
                End If
                chkIsActive.Checked = (activeVal = 1)

                Dim permsStr As String = If(dt.Columns.Contains("Permissions") AndAlso Not IsDBNull(row("Permissions")), row("Permissions").ToString(), "")
                ApplyPermissions(permsStr)
            Else
                UIHelper.ShowError("User account not found.")
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        Catch ex As Exception
            UIHelper.ShowError("Failed to load user account details: " & ex.Message)
        End Try
    End Sub

    Private Sub ChkShowPassword_CheckedChanged(sender As Object, e As EventArgs)
        Dim ch As Char = If(chkShowPassword.Checked, CChar(vbNullChar), Global.Microsoft.VisualBasic.ChrW(9679))
        txtPassword.PasswordChar = ch
    End Sub

    Private Sub CmbRole_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' When creating a new account, automatically apply default permissions for selected role
        If Not isEditMode AndAlso cmbRole.SelectedItem IsNot Nothing Then
            ApplyPermissions(Permissions.DefaultsForRole(cmbRole.SelectedItem.ToString()))
        End If
    End Sub

    Private Sub BtnRoleDefaults_Click(sender As Object, e As EventArgs)
        If cmbRole.SelectedItem IsNot Nothing Then
            ApplyPermissions(Permissions.DefaultsForRole(cmbRole.SelectedItem.ToString()))
        End If
    End Sub

    Private Sub ApplyPermissions(keys As String)
        Dim selected As HashSet(Of String) = Permissions.Parse(keys)
        For i As Integer = 0 To clbPermissions.Items.Count - 1
            Dim opt As Permissions.PermissionItem = DirectCast(clbPermissions.Items(i), Permissions.PermissionItem)
            clbPermissions.SetItemChecked(i, selected.Contains(opt.Key))
        Next
    End Sub

    Private Function SelectedPermissions() As String
        Dim keys As New List(Of String)
        For Each item As Object In clbPermissions.CheckedItems
            Dim opt As Permissions.PermissionItem = TryCast(item, Permissions.PermissionItem)
            If opt IsNot Nothing Then keys.Add(opt.Key)
        Next
        Return String.Join(",", keys)
    End Function

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        lblFeedback.Text = ""

        Dim username As String = txtUsername.Text.Trim()
        Dim fullName As String = txtFullName.Text.Trim()
        Dim role As String = If(cmbRole.SelectedItem IsNot Nothing, cmbRole.SelectedItem.ToString(), "")
        Dim email As String = txtEmail.Text.Trim()
        Dim contact As String = txtContact.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim isActive As Integer = If(chkIsActive.Checked, 1, 0)
        Dim perms As String = SelectedPermissions()

        ' Validation
        If String.IsNullOrWhiteSpace(username) Then
            lblFeedback.Text = "Username is required."
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(fullName) Then
            lblFeedback.Text = "Full Name is required."
            txtFullName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(role) Then
            lblFeedback.Text = "Please select a user role."
            cmbRole.Focus()
            Return
        End If

        If Not isEditMode Then
            ' New user: password required
            If String.IsNullOrWhiteSpace(password) Then
                lblFeedback.Text = "Password is required for new accounts."
                txtPassword.Focus()
                Return
            End If
            If password.Length < 6 Then
                lblFeedback.Text = "Password must be at least 6 characters."
                txtPassword.Focus()
                Return
            End If
        Else
            ' Edit user: password optional, but if entered must be >= 6 chars
            If Not String.IsNullOrEmpty(password) AndAlso password.Length < 6 Then
                lblFeedback.Text = "New password must be at least 6 characters."
                txtPassword.Focus()
                Return
            End If
        End If

        ' Verify unique username
        Try
            Dim countSql As String
            Dim countParam As SQLiteParameter
            If isEditMode Then
                countSql = "SELECT COUNT(*) FROM Users WHERE Username=@u AND UserID<>@id"
                countParam = New SQLiteParameter("@id", targetUserId)
            Else
                countSql = "SELECT COUNT(*) FROM Users WHERE Username=@u"
                countParam = Nothing
            End If

            Dim existing As Object
            If countParam IsNot Nothing Then
                existing = DatabaseHelper.ExecuteScalar(countSql, New SQLiteParameter("@u", username), countParam)
            Else
                existing = DatabaseHelper.ExecuteScalar(countSql, New SQLiteParameter("@u", username))
            End If

            If existing IsNot Nothing AndAlso Convert.ToInt32(existing) > 0 Then
                lblFeedback.Text = "That username is already taken. Please choose another."
                txtUsername.Focus()
                Return
            End If

            ' Execute insert or update
            If Not isEditMode Then
                ' ── INSERT NEW USER ──
                Dim hash As String = SecurityHelper.HashPassword(password)
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO Users (Username, PasswordHash, FullName, Role, Permissions, IsActive, Email, ContactNumber, DateCreated) " &
                    "VALUES (@u, @p, @f, @r, @perm, @a, @e, @c, @d)",
                    New SQLiteParameter("@u", username),
                    New SQLiteParameter("@p", hash),
                    New SQLiteParameter("@f", fullName),
                    New SQLiteParameter("@r", role),
                    New SQLiteParameter("@perm", perms),
                    New SQLiteParameter("@a", isActive),
                    New SQLiteParameter("@e", email),
                    New SQLiteParameter("@c", contact),
                    New SQLiteParameter("@d", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))

                UIHelper.ShowInfo(String.Format("User account '{0}' has been created successfully.", username), "Account Created")
            Else
                ' ── UPDATE EXISTING USER ──
                If Not String.IsNullOrEmpty(password) Then
                    Dim hash As String = SecurityHelper.HashPassword(password)
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Users SET Username=@u, PasswordHash=@p, FullName=@f, Role=@r, Permissions=@perm, IsActive=@a, Email=@e, ContactNumber=@c WHERE UserID=@id",
                        New SQLiteParameter("@u", username),
                        New SQLiteParameter("@p", hash),
                        New SQLiteParameter("@f", fullName),
                        New SQLiteParameter("@r", role),
                        New SQLiteParameter("@perm", perms),
                        New SQLiteParameter("@a", isActive),
                        New SQLiteParameter("@e", email),
                        New SQLiteParameter("@c", contact),
                        New SQLiteParameter("@id", targetUserId))
                Else
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Users SET Username=@u, FullName=@f, Role=@r, Permissions=@perm, IsActive=@a, Email=@e, ContactNumber=@c WHERE UserID=@id",
                        New SQLiteParameter("@u", username),
                        New SQLiteParameter("@f", fullName),
                        New SQLiteParameter("@r", role),
                        New SQLiteParameter("@perm", perms),
                        New SQLiteParameter("@a", isActive),
                        New SQLiteParameter("@e", email),
                        New SQLiteParameter("@c", contact),
                        New SQLiteParameter("@id", targetUserId))
                End If

                ' If updating the currently logged-in user, refresh session cache
                If targetUserId = SessionManager.CurrentUserID Then
                    SessionManager.CurrentFullName = fullName
                    SessionManager.CurrentUsername = username
                    SessionManager.CurrentRole = role
                    SessionManager.CurrentEmail = email
                    SessionManager.CurrentContactNumber = contact
                    SessionManager.UpdatePermissions(perms)

                    ' Refresh profile widget in main window if open
                    For Each f As Form In Application.OpenForms
                        If TypeOf f Is frmMain Then
                            CType(f, frmMain).UpdateProfileDisplay()
                        End If
                    Next
                End If

                UIHelper.ShowInfo(String.Format("User account '{0}' has been updated successfully.", username), "Account Updated")
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            lblFeedback.Text = "Database error: " & ex.Message
        End Try
    End Sub

End Class
