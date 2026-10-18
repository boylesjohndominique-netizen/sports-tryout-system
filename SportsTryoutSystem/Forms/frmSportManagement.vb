Imports System.Data
Imports System.Drawing

Public Class frmSportManagement

    Private selectedSportId As Integer = 0
    Private headerPanel As Panel

    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True

        headerPanel = UIHelper.MakePanelHeader("Sport Management", Me.Width)
        Me.Controls.Add(headerPanel)
        headerPanel.SendToBack()

        AddHandler Me.Resize, AddressOf OnFormResized
        AddHandler Me.Shown, AddressOf OnFormShown
        AddHandler dgv.CellFormatting, AddressOf Dgv_CellFormatting
    End Sub

    Private Sub OnFormShown(sender As Object, e As EventArgs)
        LayoutPanels()
        Try
            LoadSports()
            LoadCoachesList()
        Catch ex As Exception
            UIHelper.ShowError("Failed to load sports data: " & ex.Message)
        End Try
    End Sub

    Private Sub OnFormResized(sender As Object, e As EventArgs)
        LayoutPanels()
    End Sub

    Private Sub LayoutPanels()
        If pnlForm Is Nothing OrElse pnlGridCard Is Nothing OrElse pnlCoaches Is Nothing Then Return
        If Me.ClientSize.Width < 600 OrElse Me.ClientSize.Height < 400 Then Return

        Try
            Me.SuspendLayout()

            If headerPanel IsNot Nothing Then
                headerPanel.Width = Me.ClientSize.Width
            End If

            Dim topY As Integer = 72
            Dim marginX As Integer = 24
            Dim gapX As Integer = 20
            Dim bottomMargin As Integer = 20
            Dim availW As Integer = Me.ClientSize.Width - (marginX * 2) - gapX
            Dim availH As Integer = Me.ClientSize.Height - topY - bottomMargin

            If availW < 500 Then availW = 500
            If availH < 350 Then availH = 350

            ' Proportional column widths (Right: 36% to 42%, bounded between 360 and 500)
            Dim coachW As Integer = CInt(Math.Max(360, Math.Min(500, availW * 0.38)))
            Dim leftW As Integer = availW - coachW

            ' Left column heights: form is 240px, remainder is grid card
            Dim formH As Integer = 240
            Dim gridH As Integer = availH - formH - 14

            pnlForm.Location = New Point(marginX, topY)
            pnlForm.Size = New Size(leftW, formH)

            pnlGridCard.Location = New Point(marginX, topY + formH + 14)
            pnlGridCard.Size = New Size(leftW, Math.Max(150, gridH))

            ' Right column (Coaches)
            pnlCoaches.Location = New Point(marginX + leftW + gapX, topY)
            pnlCoaches.Size = New Size(coachW, availH)

            ' Internal element layouts
            LayoutFormCard(leftW)
            LayoutGridCard(leftW, pnlGridCard.Height)
            LayoutCoachesCard(coachW, availH)

            Me.ResumeLayout(True)
        Catch
        End Try
    End Sub

    Private Sub LayoutFormCard(cardW As Integer)
        pnlForm.SuspendLayout()

        formAccent.Width = cardW

        lblFormHeader.Location = New Point(20, 14)
        lblFormSub.Location = New Point(22, 38)

        lblSportIdBadge.Location = New Point(Math.Max(260, cardW - lblSportIdBadge.Width - 20), 14)

        ' Row 1: Sport Name and Active Checkbox
        lblName.Location = New Point(20, 68)
        Dim nameW As Integer = CInt((cardW - 40 - 180) * 0.95)
        If nameW < 220 Then nameW = 220
        txtSportName.Location = New Point(20, 88)
        txtSportName.Size = New Size(nameW, 26)

        chkIsActive.Location = New Point(20 + nameW + 24, 88)
        chkIsActive.Size = New Size(160, 26)

        ' Row 2: Description
        lblDesc.Location = New Point(20, 124)
        txtDescription.Location = New Point(20, 144)
        txtDescription.Size = New Size(cardW - 40, 25)

        ' Row 3: Action Buttons
        Dim btnGap As Integer = 12
        Dim btnW As Integer = CInt((cardW - 40 - (btnGap * 3)) / 4)
        btnW = Math.Max(110, Math.Min(160, btnW))

        btnAdd.Location = New Point(20, 184)
        btnAdd.Size = New Size(btnW, 40)

        btnUpdate.Location = New Point(20 + btnW + btnGap, 184)
        btnUpdate.Size = New Size(btnW, 40)

        btnDelete.Location = New Point(20 + (btnW + btnGap) * 2, 184)
        btnDelete.Size = New Size(btnW, 40)

        btnClear.Location = New Point(20 + (btnW + btnGap) * 3, 184)
        btnClear.Size = New Size(btnW, 40)

        pnlForm.ResumeLayout(True)
    End Sub

    Private Sub LayoutGridCard(cardW As Integer, cardH As Integer)
        pnlGridCard.SuspendLayout()

        gridAccent.Width = cardW

        lblGridTitle.Location = New Point(20, 14)
        lblGridCounter.Location = New Point(lblGridTitle.Right + 12, 16)

        Dim searchW As Integer = Math.Min(220, Math.Max(150, cardW - lblGridTitle.Right - 200))
        txtSearchSport.Location = New Point(cardW - searchW - 20, 14)
        txtSearchSport.Size = New Size(searchW, 24)

        lblSearch.Location = New Point(txtSearchSport.Left - lblSearch.Width - 6, 17)

        dgv.Location = New Point(20, 48)
        dgv.Size = New Size(cardW - 40, Math.Max(80, cardH - 64))

        pnlGridCard.ResumeLayout(True)
    End Sub

    Private Sub LayoutCoachesCard(cardW As Integer, cardH As Integer)
        pnlCoaches.SuspendLayout()

        coachAccent.Width = cardW

        lblCoachTitle.Location = New Point(20, 14)
        lblCoachHint.Location = New Point(22, 38)

        pnlSelectedSportInfo.Location = New Point(20, 60)
        pnlSelectedSportInfo.Size = New Size(cardW - 40, 36)

        btnSelectAllCoaches.Location = New Point(20, 104)
        btnSelectAllCoaches.Size = New Size(95, 28)

        btnClearAllCoaches.Location = New Point(122, 104)
        btnClearAllCoaches.Size = New Size(95, 28)

        lblCoachCount.Location = New Point(Math.Max(230, cardW - lblCoachCount.Width - 20), 110)

        Dim clbH As Integer = cardH - 140 - 58
        clbCoaches.Location = New Point(20, 140)
        clbCoaches.Size = New Size(cardW - 40, Math.Max(80, clbH))

        btnSaveCoaches.Location = New Point(20, cardH - 50)
        btnSaveCoaches.Size = New Size(cardW - 40, 42)

        pnlCoaches.ResumeLayout(True)
    End Sub

    ' ========================================================
    '  DATA ACCESS & BINDING
    ' ========================================================

    Private Sub LoadSports()
        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT SportID, SportName, Description, CASE WHEN IsActive=1 THEN 'Yes' ELSE 'No' END AS Active " &
                "FROM Sports ORDER BY SportName")
            dgv.DataSource = dt
            If dgv.Columns.Contains("SportID") Then dgv.Columns("SportID").Visible = False

            If dgv.Columns.Contains("SportName") Then
                dgv.Columns("SportName").HeaderText = "Sport Name"
                dgv.Columns("SportName").FillWeight = 32
            End If
            If dgv.Columns.Contains("Description") Then
                dgv.Columns("Description").HeaderText = "Description / Rules"
                dgv.Columns("Description").FillWeight = 53
            End If
            If dgv.Columns.Contains("Active") Then
                dgv.Columns("Active").HeaderText = "Active"
                dgv.Columns("Active").FillWeight = 15
                dgv.Columns("Active").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns("Active").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            UpdateSportCounts()
        Catch ex As Exception
            UIHelper.ShowError("Error loading sports: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateSportCounts()
        Dim count As Integer = 0
        If dgv.DataSource IsNot Nothing Then
            Dim dt As DataTable = TryCast(dgv.DataSource, DataTable)
            If dt IsNot Nothing Then count = dt.DefaultView.Count
        End If
        lblGridCounter.Text = String.Format("Total: {0} Sports", count)
    End Sub

    Private Sub LoadCoachesList()
        Try
            clbCoaches.Items.Clear()
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT UserID, FullName FROM Users WHERE Role='Coach' AND IsActive=1 ORDER BY FullName")
            For Each row As DataRow In dt.Rows
                clbCoaches.Items.Add(New CoachItem(CInt(row("UserID")), row("FullName").ToString()))
            Next
            lblCoachCount.Text = String.Format("{0} Coaches Avail", clbCoaches.Items.Count)
        Catch ex As Exception
            lblCoachCount.Text = "Coaches: N/A"
        End Try
    End Sub

    Private Sub Dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If dgv.Columns Is Nothing OrElse e.ColumnIndex >= dgv.Columns.Count Then Return
            Dim col = dgv.Columns(e.ColumnIndex)
            If col Is Nothing OrElse col.Name <> "Active" OrElse e.Value Is Nothing Then Return

            If e.Value.ToString() = "Yes" Then
                e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                e.CellStyle.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
            Else
                e.CellStyle.ForeColor = Color.FromArgb(148, 163, 184)
                e.CellStyle.Font = New Font("Segoe UI", 9.5!, FontStyle.Regular)
            End If
        Catch
        End Try
    End Sub

    Private Sub TxtSearchSport_TextChanged(sender As Object, e As EventArgs) Handles txtSearchSport.TextChanged
        If dgv.DataSource Is Nothing Then Return
        Dim dt As DataTable = TryCast(dgv.DataSource, DataTable)
        If dt Is Nothing Then Return

        Dim term As String = txtSearchSport.Text.Trim().Replace("'", "''")
        If String.IsNullOrEmpty(term) Then
            dt.DefaultView.RowFilter = ""
        Else
            dt.DefaultView.RowFilter = String.Format("SportName LIKE '%{0}%' OR Description LIKE '%{0}%'", term)
        End If
        UpdateSportCounts()
    End Sub

    Private Sub Dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        If e.RowIndex < 0 Then Return
        Dim row As DataGridViewRow = dgv.Rows(e.RowIndex)
        selectedSportId = CInt(row.Cells("SportID").Value)
        txtSportName.Text = row.Cells("SportName").Value.ToString()
        txtDescription.Text = If(IsDBNull(row.Cells("Description").Value), "", row.Cells("Description").Value.ToString())
        chkIsActive.Checked = row.Cells("Active").Value.ToString() = "Yes"

        ' Update visual state indicators
        lblSportIdBadge.Text = "Editing ID #" & selectedSportId.ToString()
        lblSportIdBadge.BackColor = Color.FromArgb(254, 243, 199)
        lblSportIdBadge.ForeColor = Color.FromArgb(180, 83, 9)

        lblSelectedSportPrompt.Text = "★ Selected Sport: " & txtSportName.Text & " (ID #" & selectedSportId & ")"
        lblSelectedSportPrompt.ForeColor = Color.FromArgb(22, 55, 100)
        pnlSelectedSportInfo.BackColor = Color.FromArgb(239, 246, 255)

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

    ' ========================================================
    '  ACTIONS & EVENT HANDLERS
    ' ========================================================

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtSportName.Text.Trim() = "" Then
            UIHelper.ShowError("Please enter a sport name.")
            txtSportName.Focus()
            Return
        End If
        Try
            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Sports (SportName, Description, IsActive) VALUES (@n,@d,@a)",
                New SQLiteParameter("@n", txtSportName.Text.Trim()),
                New SQLiteParameter("@d", txtDescription.Text.Trim()),
                New SQLiteParameter("@a", If(chkIsActive.Checked, 1, 0)))
            UIHelper.ShowInfo("Sport registered successfully.")
            BtnClear_Click(sender, e)
            LoadSports()
        Catch ex As Exception
            UIHelper.ShowError("Failed to add sport (it may already exist): " & ex.Message)
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedSportId = 0 Then
            UIHelper.ShowError("Select a sport from the directory first.")
            Return
        End If
        If txtSportName.Text.Trim() = "" Then
            UIHelper.ShowError("Sport name cannot be empty.")
            txtSportName.Focus()
            Return
        End If
        Try
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Sports SET SportName=@n, Description=@d, IsActive=@a WHERE SportID=@id",
                New SQLiteParameter("@n", txtSportName.Text.Trim()),
                New SQLiteParameter("@d", txtDescription.Text.Trim()),
                New SQLiteParameter("@a", If(chkIsActive.Checked, 1, 0)),
                New SQLiteParameter("@id", selectedSportId))
            UIHelper.ShowInfo("Sport details updated successfully.")
            LoadSports()
        Catch ex As Exception
            UIHelper.ShowError("Failed to update sport: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedSportId = 0 Then
            UIHelper.ShowError("Select a sport from the directory first.")
            Return
        End If
        Dim inUse As Object = DatabaseHelper.ExecuteScalar(
            "SELECT COUNT(*) FROM Registrations WHERE SportID=@id", New SQLiteParameter("@id", selectedSportId))
        If CInt(inUse) > 0 Then
            UIHelper.ShowError("This sport already has applicants registered. Set it to Inactive instead of deleting it to preserve tryout records.")
            Return
        End If
        If Not UIHelper.Confirm("Permanently delete sport '" & txtSportName.Text & "'?") Then Return
        Try
            DatabaseHelper.ExecuteNonQuery("DELETE FROM SportCoaches WHERE SportID=@id", New SQLiteParameter("@id", selectedSportId))
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Sports WHERE SportID=@id", New SQLiteParameter("@id", selectedSportId))
            UIHelper.ShowInfo("Sport deleted successfully.")
            BtnClear_Click(sender, e)
            LoadSports()
        Catch ex As Exception
            UIHelper.ShowError("Failed to delete sport: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnSaveCoaches_Click(sender As Object, e As EventArgs) Handles btnSaveCoaches.Click
        If selectedSportId = 0 Then
            UIHelper.ShowError("Select a sport from the directory first before saving coach assignments.")
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
            UIHelper.ShowInfo("Coach assignments for '" & txtSportName.Text & "' saved successfully.")
        Catch ex As Exception
            UIHelper.ShowError("Failed to save coach assignments: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnSelectAllCoaches_Click(sender As Object, e As EventArgs) Handles btnSelectAllCoaches.Click
        For i As Integer = 0 To clbCoaches.Items.Count - 1
            clbCoaches.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub BtnClearAllCoaches_Click(sender As Object, e As EventArgs) Handles btnClearAllCoaches.Click
        For i As Integer = 0 To clbCoaches.Items.Count - 1
            clbCoaches.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        selectedSportId = 0
        txtSportName.Text = ""
        txtDescription.Text = ""
        chkIsActive.Checked = True
        For i As Integer = 0 To clbCoaches.Items.Count - 1
            clbCoaches.SetItemChecked(i, False)
        Next

        lblSportIdBadge.Text = "Mode: New Sport"
        lblSportIdBadge.BackColor = Color.FromArgb(241, 245, 249)
        lblSportIdBadge.ForeColor = Color.FromArgb(71, 85, 105)

        lblSelectedSportPrompt.Text = "ℹ️ Select a sport from the directory to assign coaches."
        lblSelectedSportPrompt.ForeColor = Color.FromArgb(71, 85, 105)
        pnlSelectedSportInfo.BackColor = Color.FromArgb(248, 250, 252)
    End Sub

End Class
