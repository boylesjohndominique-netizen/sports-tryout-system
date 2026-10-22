Imports System.Data
Imports System.Drawing

''' <summary>
''' User Accounts Management Form.
''' Displays the full-page table of system user accounts with search/filtering.
''' Provides "+ Create Account" modal pop-up, inline "Edit" pop-up, and safe "Delete" with confirmation.
''' </summary>
Public Class frmUserManagement

    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True
        ConfigureGridColumns()
        SetupEventHandlers()
    End Sub

    Private Sub SetupEventHandlers()
        AddHandler Me.Load, AddressOf OnFormLoad
        AddHandler Me.Resize, AddressOf OnFormResize

        ' Toolbar actions
        AddHandler btnCreateAccount.Click, AddressOf BtnCreateAccount_Click
        AddHandler btnRefresh.Click, AddressOf BtnRefresh_Click
        AddHandler txtSearch.TextChanged, AddressOf FilterChanged
        AddHandler cmbRoleFilter.SelectedIndexChanged, AddressOf FilterChanged
        AddHandler cmbStatusFilter.SelectedIndexChanged, AddressOf FilterChanged

        ' Grid events
        AddHandler dgvUsers.CellContentClick, AddressOf DgvUsers_CellContentClick
        AddHandler dgvUsers.CellClick, AddressOf DgvUsers_CellClick
        AddHandler dgvUsers.CellDoubleClick, AddressOf DgvUsers_CellDoubleClick
        AddHandler dgvUsers.CellPainting, AddressOf DgvUsers_CellPainting
        AddHandler dgvUsers.CellFormatting, AddressOf DgvUsers_CellFormatting

        ' Card border painting
        AddHandler cardGrid.Paint, AddressOf DrawGridCardBorder
    End Sub

    Private Sub OnFormLoad(sender As Object, e As EventArgs)
        cmbRoleFilter.SelectedIndex = 0
        cmbStatusFilter.SelectedIndex = 0
        LoadUsers()
    End Sub

    Private Sub OnFormResize(sender As Object, e As EventArgs)
        If pnlToolbar IsNot Nothing AndAlso lblRecordCount IsNot Nothing Then
            lblRecordCount.Left = pnlToolbar.ClientSize.Width - lblRecordCount.Width - 24
        End If
    End Sub

    Private Sub DrawGridCardBorder(sender As Object, e As PaintEventArgs)
        Dim pnl = TryCast(sender, Panel)
        If pnl Is Nothing Then Return
        Using pen As New Pen(Color.FromArgb(226, 232, 240), 1)
            e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  GRID COLUMN CONFIGURATION
    ' ═══════════════════════════════════════════════════════════════
    Private Sub ConfigureGridColumns()
        dgvUsers.AutoGenerateColumns = False
        dgvUsers.Columns.Clear()

        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "UserID",
            .DataPropertyName = "UserID",
            .Visible = False
        })

        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Username",
            .DataPropertyName = "Username",
            .HeaderText = "Username",
            .Width = 140
        })

        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "FullName",
            .DataPropertyName = "FullName",
            .HeaderText = "Full Name",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .FillWeight = 130
        })

        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Role",
            .DataPropertyName = "Role",
            .HeaderText = "Role",
            .Width = 110,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
        })

        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Email",
            .DataPropertyName = "Email",
            .HeaderText = "Email Address",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .FillWeight = 120
        })

        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ContactNumber",
            .DataPropertyName = "ContactNumber",
            .HeaderText = "Contact Number",
            .Width = 135
        })

        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Active",
            .DataPropertyName = "Active",
            .HeaderText = "Status",
            .Width = 95,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
        })

        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "DateCreated",
            .DataPropertyName = "DateCreated",
            .HeaderText = "Created",
            .Width = 120
        })

        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Permissions",
            .DataPropertyName = "Permissions",
            .Visible = False
        })

        ' ── 2 ACTION BUTTON COLUMNS (Edit & Delete) ──
        Dim colEdit As New DataGridViewButtonColumn() With {
            .Name = "colEdit",
            .HeaderText = "Actions",
            .Text = "✎ Edit",
            .UseColumnTextForButtonValue = True,
            .Width = 85,
            .FlatStyle = FlatStyle.Flat
        }
        colEdit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvUsers.Columns.Add(colEdit)

        Dim colDelete As New DataGridViewButtonColumn() With {
            .Name = "colDelete",
            .HeaderText = "",
            .Text = "🗑 Delete",
            .UseColumnTextForButtonValue = True,
            .Width = 95,
            .FlatStyle = FlatStyle.Flat
        }
        colDelete.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvUsers.Columns.Add(colDelete)
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  DATA LOADING & FILTERING
    ' ═══════════════════════════════════════════════════════════════
    Public Sub LoadUsers()
        Try
            Dim sql As String = "SELECT UserID, Username, FullName, Role, " &
                                "COALESCE(Email, '') AS Email, " &
                                "COALESCE(ContactNumber, '') AS ContactNumber, " &
                                "CASE WHEN IsActive=1 THEN 'Active' ELSE 'Inactive' END AS Active, " &
                                "DateCreated, Permissions " &
                                "FROM Users WHERE 1=1"

            Dim params As New List(Of SQLiteParameter)

            ' Search filter
            Dim q As String = txtSearch.Text.Trim()
            If Not String.IsNullOrEmpty(q) Then
                sql &= " AND (Username LIKE @q OR FullName LIKE @q OR Email LIKE @q)"
                params.Add(New SQLiteParameter("@q", "%" & q & "%"))
            End If

            ' Role filter
            If cmbRoleFilter.SelectedIndex > 0 Then
                sql &= " AND Role = @role"
                params.Add(New SQLiteParameter("@role", cmbRoleFilter.SelectedItem.ToString()))
            End If

            ' Status filter
            If cmbStatusFilter.SelectedIndex = 1 Then
                sql &= " AND IsActive = 1"
            ElseIf cmbStatusFilter.SelectedIndex = 2 Then
                sql &= " AND IsActive = 0"
            End If

            sql &= " ORDER BY FullName ASC"

            Dim dt As DataTable = DatabaseHelper.GetDataTable(sql, params.ToArray())
            dgvUsers.DataSource = dt

            lblRecordCount.Text = String.Format("Showing {0} User Account{1}", dt.Rows.Count, If(dt.Rows.Count = 1, "", "s"))
        Catch ex As Exception
            UIHelper.ShowError("Error loading user accounts: " & ex.Message)
        End Try
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs)
        LoadUsers()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs)
        txtSearch.Clear()
        cmbRoleFilter.SelectedIndex = 0
        cmbStatusFilter.SelectedIndex = 0
        LoadUsers()
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  POP-UP ACTIONS (Create, Edit, Delete)
    ' ═══════════════════════════════════════════════════════════════
    Private Sub BtnCreateAccount_Click(sender As Object, e As EventArgs)
        Using dlg As New frmUserAccountDialog(0)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                LoadUsers()
            End If
        End Using
    End Sub

    Private Sub DgvUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim colName As String = dgvUsers.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            EditUser(e.RowIndex)
        ElseIf colName = "colDelete" Then
            DeleteUser(e.RowIndex)
        End If
    End Sub

    Private Sub DgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim colName As String = dgvUsers.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            EditUser(e.RowIndex)
        ElseIf colName = "colDelete" Then
            DeleteUser(e.RowIndex)
        End If
    End Sub

    Private Sub DgvUsers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            EditUser(e.RowIndex)
        End If
    End Sub

    Private Sub EditUser(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvUsers.Rows.Count Then Return
        Try
            Dim userId As Integer = Convert.ToInt32(dgvUsers.Rows(rowIndex).Cells("UserID").Value)
            Using dlg As New frmUserAccountDialog(userId)
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    LoadUsers()
                End If
            End Using
        Catch ex As Exception
            UIHelper.ShowError("Could not open edit dialog: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteUser(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvUsers.Rows.Count Then Return

        Try
            Dim row = dgvUsers.Rows(rowIndex)
            Dim userId As Integer = Convert.ToInt32(row.Cells("UserID").Value)
            Dim username As String = row.Cells("Username").Value.ToString()
            Dim fullName As String = row.Cells("FullName").Value.ToString()
            Dim role As String = row.Cells("Role").Value.ToString()

            ' Safeguard 1: Cannot delete currently logged-in account
            If userId = SessionManager.CurrentUserID Then
                UIHelper.ShowError("You cannot delete your own currently logged-in account.")
                Return
            End If

            ' Safeguard 2: Cannot delete the last active administrator
            If role.ToLower() = "admin" Then
                Dim adminCountObj As Object = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM Users WHERE Role='Admin' AND IsActive=1 AND UserID<>@id",
                    New SQLiteParameter("@id", userId))
                Dim otherAdmins As Integer = If(adminCountObj IsNot Nothing AndAlso Not IsDBNull(adminCountObj), Convert.ToInt32(adminCountObj), 0)
                If otherAdmins = 0 Then
                    UIHelper.ShowError("Cannot delete this user. The system must retain at least one active Administrator account.")
                    Return
                End If
            End If

            ' Confirmation prompt
            Dim confirmPrompt As String = String.Format(
                "Are you sure you want to permanently delete user account '{0}' ({1})?{2}{2}All login credentials for this account will be removed.",
                username, fullName, Environment.NewLine)

            If UIHelper.Confirm(confirmPrompt, "Confirm Delete User") Then
                Dim rowsAffected As Integer = DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM Users WHERE UserID=@id",
                    New SQLiteParameter("@id", userId))

                If rowsAffected > 0 Then
                    UIHelper.ShowInfo(String.Format("User account '{0}' has been deleted successfully.", username), "User Deleted")
                    LoadUsers()
                Else
                    UIHelper.ShowError("User record could not be deleted or was already removed.")
                End If
            End If
        Catch ex As Exception
            UIHelper.ShowError("Failed to delete user account: " & ex.Message)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  STYLING & CELL PAINTING
    ' ═══════════════════════════════════════════════════════════════
    Private Sub DgvUsers_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim colName As String = dgvUsers.Columns(e.ColumnIndex).Name

        If colName = "colEdit" Then
            e.PaintBackground(e.CellBounds, True)
            Dim btnRect As New Rectangle(e.CellBounds.X + 6, e.CellBounds.Y + 6, e.CellBounds.Width - 12, e.CellBounds.Height - 12)
            Using b As New SolidBrush(Color.FromArgb(22, 55, 100))
                e.Graphics.FillRectangle(b, btnRect)
            End Using
            Using pen As New Pen(Color.FromArgb(14, 38, 72))
                e.Graphics.DrawRectangle(pen, btnRect)
            End Using
            Using sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                Using f As New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold)
                    e.Graphics.DrawString("✎ Edit", f, Brushes.White, btnRect, sf)
                End Using
            End Using
            e.Handled = True

        ElseIf colName = "colDelete" Then
            e.PaintBackground(e.CellBounds, True)
            Dim btnRect As New Rectangle(e.CellBounds.X + 6, e.CellBounds.Y + 6, e.CellBounds.Width - 12, e.CellBounds.Height - 12)
            Using b As New SolidBrush(Color.FromArgb(220, 38, 38))
                e.Graphics.FillRectangle(b, btnRect)
            End Using
            Using pen As New Pen(Color.FromArgb(185, 28, 28))
                e.Graphics.DrawRectangle(pen, btnRect)
            End Using
            Using sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                Using f As New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold)
                    e.Graphics.DrawString("🗑 Delete", f, Brushes.White, btnRect, sf)
                End Using
            End Using
            e.Handled = True
        End If
    End Sub

    Private Sub DgvUsers_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        Dim colName As String = dgvUsers.Columns(e.ColumnIndex).Name

        If colName = "Active" AndAlso e.Value IsNot Nothing Then
            If e.Value.ToString() = "Active" Then
                e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                e.CellStyle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
            Else
                e.CellStyle.ForeColor = Color.FromArgb(148, 163, 184)
                e.CellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            End If
        ElseIf colName = "Role" AndAlso e.Value IsNot Nothing Then
            Select Case e.Value.ToString().ToLower()
                Case "admin"
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9)
                    e.CellStyle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
                Case "coach"
                    e.CellStyle.ForeColor = Color.FromArgb(2, 132, 199)
                    e.CellStyle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
                Case "evaluator"
                    e.CellStyle.ForeColor = Color.FromArgb(147, 51, 234)
                    e.CellStyle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
                Case Else
                    e.CellStyle.ForeColor = Color.FromArgb(71, 85, 105)
                    e.CellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            End Select
        End If
    End Sub

End Class
