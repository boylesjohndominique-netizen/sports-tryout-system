Public Class frmSportManagement
    Inherits Form

    Private dgv As DataGridView
    Private txtSportName As TextBox
    Private txtDescription As TextBox
    Private chkIsActive As CheckBox
    Private clbCoaches As CheckedListBox
    Private selectedSportId As Integer = 0

    Public Sub New()
        Me.Text = "Sport Management"
        Me.Dock = DockStyle.Fill
        Me.BackColor = UIHelper.ColorBackground
        BuildUI()
        LoadSports()
        LoadCoachesList()
    End Sub

    Private Sub BuildUI()
        Dim header As Panel = UIHelper.MakePanelHeader("Sport Management", Me.Width)
        Me.Controls.Add(header)

        ' ── Input card ──
        Dim pnlForm As New Panel()
        pnlForm.Location = New Point(30, 75)
        pnlForm.Size = New Size(620, 125)
        pnlForm.BackColor = Color.White
        pnlForm.BorderStyle = BorderStyle.None

        Dim formAccent As New Panel()
        formAccent.Dock = DockStyle.Top
        formAccent.Height = 3
        formAccent.BackColor = UIHelper.ColorGold
        pnlForm.Controls.Add(formAccent)

        Dim lblName As Label = UIHelper.MakeLabel("SPORT NAME", 20, 12, 200)
        lblName.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblName.ForeColor = UIHelper.ColorTextSecondary
        txtSportName = UIHelper.MakeTextBox(20, 32, 230)

        Dim lblDesc As Label = UIHelper.MakeLabel("DESCRIPTION", 270, 12, 200)
        lblDesc.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblDesc.ForeColor = UIHelper.ColorTextSecondary
        txtDescription = UIHelper.MakeTextBox(270, 32, 250)

        chkIsActive = New CheckBox()
        chkIsActive.Text = "Active"
        chkIsActive.Location = New Point(535, 34)
        chkIsActive.Checked = True
        chkIsActive.Font = UIHelper.FontRegular
        chkIsActive.ForeColor = UIHelper.ColorTextPrimary

        pnlForm.Controls.Add(lblName)
        pnlForm.Controls.Add(txtSportName)
        pnlForm.Controls.Add(lblDesc)
        pnlForm.Controls.Add(txtDescription)
        pnlForm.Controls.Add(chkIsActive)

        ' Action buttons inside card
        Dim btnAdd As Button = UIHelper.MakeButton("✚ Add Sport", 20, 76, 135, "success")
        btnAdd.Height = 34
        AddHandler btnAdd.Click, AddressOf BtnAdd_Click
        pnlForm.Controls.Add(btnAdd)

        Dim btnUpdate As Button = UIHelper.MakeButton("✎ Update", 165, 76, 120, "primary")
        btnUpdate.Height = 34
        AddHandler btnUpdate.Click, AddressOf BtnUpdate_Click
        pnlForm.Controls.Add(btnUpdate)

        Dim btnDelete As Button = UIHelper.MakeButton("✕ Delete", 295, 76, 120, "danger")
        btnDelete.Height = 34
        AddHandler btnDelete.Click, AddressOf BtnDelete_Click
        pnlForm.Controls.Add(btnDelete)

        Dim btnClear As Button = UIHelper.MakeButton("Clear", 425, 76, 100, "secondary")
        btnClear.Height = 34
        AddHandler btnClear.Click, AddressOf BtnClear_Click
        pnlForm.Controls.Add(btnClear)

        Me.Controls.Add(pnlForm)

        ' ── Data grid ──
        dgv = UIHelper.MakeDataGridView(30, 215, 620, 340)
        AddHandler dgv.CellClick, AddressOf Dgv_CellClick
        Me.Controls.Add(dgv)

        ' ── Coach assignment card ──
        Dim pnlCoaches As New Panel()
        pnlCoaches.Location = New Point(670, 75)
        pnlCoaches.Size = New Size(310, 480)
        pnlCoaches.BackColor = Color.White
        pnlCoaches.BorderStyle = BorderStyle.None

        Dim coachAccent As New Panel()
        coachAccent.Dock = DockStyle.Top
        coachAccent.Height = 3
        coachAccent.BackColor = UIHelper.ColorAccent
        pnlCoaches.Controls.Add(coachAccent)

        Dim lblCoachTitle As New Label()
        lblCoachTitle.Text = "ASSIGN COACHES / EVALUATORS"
        lblCoachTitle.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblCoachTitle.ForeColor = UIHelper.ColorTextSecondary
        lblCoachTitle.Location = New Point(15, 15)
        lblCoachTitle.AutoSize = True
        pnlCoaches.Controls.Add(lblCoachTitle)

        Dim lblCoachHint As New Label()
        lblCoachHint.Text = "Select a sport first, then check coaches to assign."
        lblCoachHint.Font = UIHelper.FontCaption
        lblCoachHint.ForeColor = UIHelper.ColorTextMuted
        lblCoachHint.Location = New Point(15, 35)
        lblCoachHint.AutoSize = True
        pnlCoaches.Controls.Add(lblCoachHint)

        clbCoaches = New CheckedListBox()
        clbCoaches.Location = New Point(15, 60)
        clbCoaches.Size = New Size(280, 340)
        clbCoaches.Font = UIHelper.FontRegular
        clbCoaches.CheckOnClick = True
        clbCoaches.BorderStyle = BorderStyle.FixedSingle
        clbCoaches.BackColor = Color.FromArgb(248, 250, 252)
        pnlCoaches.Controls.Add(clbCoaches)

        Dim btnSaveCoaches As Button = UIHelper.MakeButton("💾 Save Assignments", 15, 410, 280, "primary")
        AddHandler btnSaveCoaches.Click, AddressOf BtnSaveCoaches_Click
        pnlCoaches.Controls.Add(btnSaveCoaches)

        Me.Controls.Add(pnlCoaches)
    End Sub

    Private Sub LoadSports()
        dgv.DataSource = DatabaseHelper.GetDataTable(
            "SELECT SportID, SportName, Description, CASE WHEN IsActive=1 THEN 'Yes' ELSE 'No' END AS Active " &
            "FROM Sports ORDER BY SportName")
        If dgv.Columns.Contains("SportID") Then dgv.Columns("SportID").Visible = False
    End Sub

    Private Sub LoadCoachesList()
        clbCoaches.Items.Clear()
        Dim dt As DataTable = DatabaseHelper.GetDataTable(
            "SELECT UserID, FullName FROM Users WHERE Role='Coach' AND IsActive=1 ORDER BY FullName")
        For Each row As DataRow In dt.Rows
            clbCoaches.Items.Add(New CoachItem(CInt(row("UserID")), row("FullName").ToString()))
        Next
    End Sub

    Private Sub Dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim row As DataGridViewRow = dgv.Rows(e.RowIndex)
        selectedSportId = CInt(row.Cells("SportID").Value)
        txtSportName.Text = row.Cells("SportName").Value.ToString()
        txtDescription.Text = If(IsDBNull(row.Cells("Description").Value), "", row.Cells("Description").Value.ToString())
        chkIsActive.Checked = row.Cells("Active").Value.ToString() = "Yes"
        LoadAssignedCoaches()
    End Sub

    Private Sub LoadAssignedCoaches()
        Dim assigned As DataTable = DatabaseHelper.GetDataTable(
            "SELECT UserID FROM SportCoaches WHERE SportID=@id", New SQLiteParameter("@id", selectedSportId))
        Dim assignedIds As New List(Of Integer)
        For Each r As DataRow In assigned.Rows
            assignedIds.Add(CInt(r("UserID")))
        Next

        For i As Integer = 0 To clbCoaches.Items.Count - 1
            Dim item As CoachItem = CType(clbCoaches.Items(i), CoachItem)
            clbCoaches.SetItemChecked(i, assignedIds.Contains(item.UserID))
        Next
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        If txtSportName.Text.Trim() = "" Then
            UIHelper.ShowError("Enter a sport name.")
            Return
        End If
        Try
            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Sports (SportName, Description, IsActive) VALUES (@n,@d,@a)",
                New SQLiteParameter("@n", txtSportName.Text.Trim()),
                New SQLiteParameter("@d", txtDescription.Text.Trim()),
                New SQLiteParameter("@a", If(chkIsActive.Checked, 1, 0)))
            UIHelper.ShowInfo("Sport added.")
            BtnClear_Click(sender, e)
            LoadSports()
        Catch ex As Exception
            UIHelper.ShowError("Failed to add sport (it may already exist): " & ex.Message)
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs)
        If selectedSportId = 0 Then
            UIHelper.ShowError("Select a sport from the list first.")
            Return
        End If
        Try
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Sports SET SportName=@n, Description=@d, IsActive=@a WHERE SportID=@id",
                New SQLiteParameter("@n", txtSportName.Text.Trim()),
                New SQLiteParameter("@d", txtDescription.Text.Trim()),
                New SQLiteParameter("@a", If(chkIsActive.Checked, 1, 0)),
                New SQLiteParameter("@id", selectedSportId))
            UIHelper.ShowInfo("Sport updated.")
            LoadSports()
        Catch ex As Exception
            UIHelper.ShowError("Failed to update sport: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)
        If selectedSportId = 0 Then
            UIHelper.ShowError("Select a sport from the list first.")
            Return
        End If
        Dim inUse As Object = DatabaseHelper.ExecuteScalar(
            "SELECT COUNT(*) FROM Registrations WHERE SportID=@id", New SQLiteParameter("@id", selectedSportId))
        If CInt(inUse) > 0 Then
            UIHelper.ShowError("This sport already has applicants registered. Set it to Inactive instead of deleting it.")
            Return
        End If
        If Not UIHelper.Confirm("Delete this sport permanently?") Then Return
        Try
            DatabaseHelper.ExecuteNonQuery("DELETE FROM SportCoaches WHERE SportID=@id", New SQLiteParameter("@id", selectedSportId))
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Sports WHERE SportID=@id", New SQLiteParameter("@id", selectedSportId))
            UIHelper.ShowInfo("Sport deleted.")
            BtnClear_Click(sender, e)
            LoadSports()
        Catch ex As Exception
            UIHelper.ShowError("Failed to delete sport: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnSaveCoaches_Click(sender As Object, e As EventArgs)
        If selectedSportId = 0 Then
            UIHelper.ShowError("Select a sport from the list first.")
            Return
        End If
        Try
            DatabaseHelper.ExecuteNonQuery("DELETE FROM SportCoaches WHERE SportID=@id", New SQLiteParameter("@id", selectedSportId))
            For i As Integer = 0 To clbCoaches.Items.Count - 1
                If clbCoaches.GetItemChecked(i) Then
                    Dim item As CoachItem = CType(clbCoaches.Items(i), CoachItem)
                    DatabaseHelper.ExecuteNonQuery(
                        "INSERT INTO SportCoaches (SportID, UserID) VALUES (@s,@u)",
                        New SQLiteParameter("@s", selectedSportId),
                        New SQLiteParameter("@u", item.UserID))
                End If
            Next
            UIHelper.ShowInfo("Coach assignments saved.")
        Catch ex As Exception
            UIHelper.ShowError("Failed to save assignments: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        selectedSportId = 0
        txtSportName.Text = ""
        txtDescription.Text = ""
        chkIsActive.Checked = True
        For i As Integer = 0 To clbCoaches.Items.Count - 1
            clbCoaches.SetItemChecked(i, False)
        Next
    End Sub

End Class
