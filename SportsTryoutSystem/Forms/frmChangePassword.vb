Public Class frmChangePassword
    Inherits Form

    Private txtCurrent As TextBox
    Private txtNew As TextBox
    Private txtConfirm As TextBox

    Public Sub New()
        Me.Text = "Change Password"
        Me.Dock = DockStyle.Fill
        Me.BackColor = UIHelper.ColorBackground
        BuildUI()
    End Sub

    Private Sub BuildUI()
        Dim header As Panel = UIHelper.MakePanelHeader("Change Password", Me.Width)
        Me.Controls.Add(header)

        ' Card container for the password form
        Dim pnlCard As New Panel()
        pnlCard.Location = New Point(30, 80)
        pnlCard.Size = New Size(380, 340)
        pnlCard.BackColor = Color.White
        pnlCard.BorderStyle = BorderStyle.None

        ' Gold accent stripe at top of card
        Dim cardAccent As New Panel()
        cardAccent.Dock = DockStyle.Top
        cardAccent.Height = 4
        cardAccent.BackColor = UIHelper.ColorGold
        pnlCard.Controls.Add(cardAccent)

        Dim lblIcon As New Label()
        lblIcon.Text = "🔒"
        lblIcon.Font = New Font("Segoe UI", 22!)
        lblIcon.Location = New Point(30, 22)
        lblIcon.AutoSize = True
        pnlCard.Controls.Add(lblIcon)

        Dim lblTitle As New Label()
        lblTitle.Text = "Update Your Password"
        lblTitle.Font = UIHelper.FontSubHeader
        lblTitle.ForeColor = UIHelper.ColorPrimary
        lblTitle.Location = New Point(70, 28)
        lblTitle.AutoSize = True
        pnlCard.Controls.Add(lblTitle)

        Dim lblCurrent As New Label()
        lblCurrent.Text = "CURRENT PASSWORD"
        lblCurrent.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblCurrent.ForeColor = UIHelper.ColorTextSecondary
        lblCurrent.Location = New Point(30, 72)
        lblCurrent.AutoSize = True
        pnlCard.Controls.Add(lblCurrent)

        txtCurrent = UIHelper.MakeTextBox(30, 90, 320, True)
        pnlCard.Controls.Add(txtCurrent)

        Dim lblNew As New Label()
        lblNew.Text = "NEW PASSWORD"
        lblNew.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblNew.ForeColor = UIHelper.ColorTextSecondary
        lblNew.Location = New Point(30, 132)
        lblNew.AutoSize = True
        pnlCard.Controls.Add(lblNew)

        txtNew = UIHelper.MakeTextBox(30, 150, 320, True)
        pnlCard.Controls.Add(txtNew)

        Dim lblConfirm As New Label()
        lblConfirm.Text = "CONFIRM NEW PASSWORD"
        lblConfirm.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblConfirm.ForeColor = UIHelper.ColorTextSecondary
        lblConfirm.Location = New Point(30, 192)
        lblConfirm.AutoSize = True
        pnlCard.Controls.Add(lblConfirm)

        txtConfirm = UIHelper.MakeTextBox(30, 210, 320, True)
        pnlCard.Controls.Add(txtConfirm)

        Dim btnSave As Button = UIHelper.MakeButton("Update Password", 30, 260, 320, "gold")
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        pnlCard.Controls.Add(btnSave)

        Me.Controls.Add(pnlCard)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        If txtCurrent.Text = "" OrElse txtNew.Text = "" OrElse txtConfirm.Text = "" Then
            UIHelper.ShowError("Fill in all fields.")
            Return
        End If
        If txtNew.Text <> txtConfirm.Text Then
            UIHelper.ShowError("New password and confirmation do not match.")
            Return
        End If

        Dim dt As DataTable = DatabaseHelper.GetDataTable(
            "SELECT PasswordHash FROM Users WHERE UserID=@id", New SQLiteParameter("@id", SessionManager.CurrentUserID))

        If dt.Rows.Count = 0 OrElse Not SecurityHelper.VerifyPassword(txtCurrent.Text, dt.Rows(0)("PasswordHash").ToString()) Then
            UIHelper.ShowError("Current password is incorrect.")
            Return
        End If

        Try
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Users SET PasswordHash=@p WHERE UserID=@id",
                New SQLiteParameter("@p", SecurityHelper.HashPassword(txtNew.Text)),
                New SQLiteParameter("@id", SessionManager.CurrentUserID))
            UIHelper.ShowInfo("Password updated successfully.")
            txtCurrent.Text = ""
            txtNew.Text = ""
            txtConfirm.Text = ""
        Catch ex As Exception
            UIHelper.ShowError("Failed to update password: " & ex.Message)
        End Try
    End Sub

End Class
