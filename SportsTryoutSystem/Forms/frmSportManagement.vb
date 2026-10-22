Imports System.Data
Imports System.Drawing

''' <summary>
''' Sport Management & Directory Form.
''' Displays the full-page table of sports disciplines with search/status filters.
''' Features a "+ Create Sport" pop-up dialog, inline "Edit" pop-up, and safe "Delete" with validation.
''' </summary>
Public Class frmSportManagement

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
        AddHandler btnCreateSport.Click, AddressOf BtnCreateSport_Click
        AddHandler btnRefresh.Click, AddressOf BtnRefresh_Click
        AddHandler txtSearch.TextChanged, AddressOf FilterChanged
        AddHandler cmbStatusFilter.SelectedIndexChanged, AddressOf FilterChanged

        ' Grid events
        AddHandler dgvSports.CellContentClick, AddressOf DgvSports_CellContentClick
        AddHandler dgvSports.CellClick, AddressOf DgvSports_CellClick
        AddHandler dgvSports.CellDoubleClick, AddressOf DgvSports_CellDoubleClick
        AddHandler dgvSports.CellPainting, AddressOf DgvSports_CellPainting
        AddHandler dgvSports.CellFormatting, AddressOf DgvSports_CellFormatting

        ' Card border painting
        AddHandler cardGrid.Paint, AddressOf DrawGridCardBorder
    End Sub

    Private Sub OnFormLoad(sender As Object, e As EventArgs)
        cmbStatusFilter.SelectedIndex = 0
        LoadSports()
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
        dgvSports.AutoGenerateColumns = False
        dgvSports.Columns.Clear()

        dgvSports.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "SportID",
            .DataPropertyName = "SportID",
            .Visible = False
        })

        dgvSports.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "SportName",
            .DataPropertyName = "SportName",
            .HeaderText = "Sport Discipline",
            .Width = 180,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)}
        })

        dgvSports.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Description",
            .DataPropertyName = "Description",
            .HeaderText = "Description / Rules & Criteria",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .FillWeight = 140
        })

        dgvSports.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Coaches",
            .DataPropertyName = "Coaches",
            .HeaderText = "Assigned Coaches",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .FillWeight = 120
        })

        dgvSports.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ApplicantCount",
            .DataPropertyName = "ApplicantCount",
            .HeaderText = "Applicants",
            .Width = 100,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
        })

        dgvSports.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Active",
            .DataPropertyName = "Active",
            .HeaderText = "Status",
            .Width = 95,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
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
        dgvSports.Columns.Add(colEdit)

        Dim colDelete As New DataGridViewButtonColumn() With {
            .Name = "colDelete",
            .HeaderText = "",
            .Text = "🗑 Delete",
            .UseColumnTextForButtonValue = True,
            .Width = 95,
            .FlatStyle = FlatStyle.Flat
        }
        colDelete.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvSports.Columns.Add(colDelete)
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  DATA ACCESS & BINDING
    ' ═══════════════════════════════════════════════════════════════
    Public Sub LoadSports()
        Try
            Dim sql As String = "SELECT SportID, SportName, COALESCE(Description, '') AS Description, " &
                                "CASE WHEN IsActive=1 THEN 'Active' ELSE 'Inactive' END AS Active " &
                                "FROM Sports WHERE 1=1"

            Dim params As New List(Of SQLiteParameter)

            ' Search filter
            Dim term As String = txtSearch.Text.Trim()
            If Not String.IsNullOrEmpty(term) Then
                sql &= " AND (SportName LIKE @term OR Description LIKE @term)"
                params.Add(New SQLiteParameter("@term", "%" & term & "%"))
            End If

            ' Status filter
            If cmbStatusFilter.SelectedIndex = 1 Then
                sql &= " AND IsActive = 1"
            ElseIf cmbStatusFilter.SelectedIndex = 2 Then
                sql &= " AND IsActive = 0"
            End If

            sql &= " ORDER BY SportName ASC"

            Dim dtSports As DataTable = DatabaseHelper.GetDataTable(sql, params.ToArray())

            ' Add aggregated columns for coaches and applicants in code for universal database compatibility
            dtSports.Columns.Add("Coaches", GetType(String))
            dtSports.Columns.Add("ApplicantCount", GetType(String))

            ' Query coach assignments
            Dim dtCoaches As DataTable = DatabaseHelper.GetDataTable(
                "SELECT sc.SportID, u.FullName FROM SportCoaches sc " &
                "INNER JOIN Users u ON u.UserID = sc.UserID WHERE u.IsActive=1 ORDER BY u.FullName")

            Dim coachesBySport As New Dictionary(Of Integer, List(Of String))
            For Each row As DataRow In dtCoaches.Rows
                Dim sId As Integer = Convert.ToInt32(row("SportID"))
                Dim cName As String = row("FullName").ToString()
                If Not coachesBySport.ContainsKey(sId) Then
                    coachesBySport(sId) = New List(Of String)()
                End If
                coachesBySport(sId).Add(cName)
            Next

            ' Query applicant registration counts
            Dim dtApplicants As DataTable = DatabaseHelper.GetDataTable(
                "SELECT SportID, COUNT(*) AS Cnt FROM Registrations GROUP BY SportID")

            Dim applicantsBySport As New Dictionary(Of Integer, Integer)
            For Each row As DataRow In dtApplicants.Rows
                Dim sId As Integer = Convert.ToInt32(row("SportID"))
                Dim cnt As Integer = Convert.ToInt32(row("Cnt"))
                applicantsBySport(sId) = cnt
            Next

            ' Populate aggregated values
            For Each row As DataRow In dtSports.Rows
                Dim sId As Integer = Convert.ToInt32(row("SportID"))

                If coachesBySport.ContainsKey(sId) AndAlso coachesBySport(sId).Count > 0 Then
                    row("Coaches") = String.Join(", ", coachesBySport(sId))
                Else
                    row("Coaches") = "None Assigned"
                End If

                If applicantsBySport.ContainsKey(sId) Then
                    row("ApplicantCount") = applicantsBySport(sId).ToString()
                Else
                    row("ApplicantCount") = "0"
                End If
            Next

            dgvSports.DataSource = dtSports
            lblRecordCount.Text = String.Format("Showing {0} Sport{1}", dtSports.Rows.Count, If(dtSports.Rows.Count = 1, "", "s"))

        Catch ex As Exception
            UIHelper.ShowError("Error loading sports directory: " & ex.Message)
        End Try
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs)
        LoadSports()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs)
        txtSearch.Clear()
        cmbStatusFilter.SelectedIndex = 0
        LoadSports()
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  POP-UP ACTIONS (Create, Edit, Delete)
    ' ═══════════════════════════════════════════════════════════════
    Private Sub BtnCreateSport_Click(sender As Object, e As EventArgs)
        Using dlg As New frmSportDialog(0)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                LoadSports()
            End If
        End Using
    End Sub

    Private Sub DgvSports_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim colName As String = dgvSports.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            EditSport(e.RowIndex)
        ElseIf colName = "colDelete" Then
            DeleteSport(e.RowIndex)
        End If
    End Sub

    Private Sub DgvSports_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim colName As String = dgvSports.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            EditSport(e.RowIndex)
        ElseIf colName = "colDelete" Then
            DeleteSport(e.RowIndex)
        End If
    End Sub

    Private Sub DgvSports_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            EditSport(e.RowIndex)
        End If
    End Sub

    Private Sub EditSport(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvSports.Rows.Count Then Return
        Try
            Dim sportId As Integer = Convert.ToInt32(dgvSports.Rows(rowIndex).Cells("SportID").Value)
            Using dlg As New frmSportDialog(sportId)
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    LoadSports()
                End If
            End Using
        Catch ex As Exception
            UIHelper.ShowError("Could not open edit dialog: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteSport(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvSports.Rows.Count Then Return

        Try
            Dim row = dgvSports.Rows(rowIndex)
            Dim sportId As Integer = Convert.ToInt32(row.Cells("SportID").Value)
            Dim sportName As String = row.Cells("SportName").Value.ToString()

            ' Safeguard 1: Check for registered applicants
            Dim inUseRegistrations As Object = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Registrations WHERE SportID=@id",
                New SQLiteParameter("@id", sportId))

            If inUseRegistrations IsNot Nothing AndAlso Convert.ToInt32(inUseRegistrations) > 0 Then
                UIHelper.ShowError(String.Format(
                    "Cannot delete '{0}'. It has {1} applicant registration record(s). Set this sport to Inactive instead to preserve historical records.",
                    sportName, inUseRegistrations))
                Return
            End If

            ' Safeguard 2: Check for tryout schedules
            Dim inUseSchedules As Object = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM TryoutSchedules WHERE SportID=@id",
                New SQLiteParameter("@id", sportId))

            If inUseSchedules IsNot Nothing AndAlso Convert.ToInt32(inUseSchedules) > 0 Then
                UIHelper.ShowError(String.Format(
                    "Cannot delete '{0}'. It has {1} tryout schedule(s) scheduled. Remove or reassign the schedules first.",
                    sportName, inUseSchedules))
                Return
            End If

            ' Confirmation
            Dim confirmPrompt As String = String.Format(
                "Are you sure you want to permanently delete the sport discipline '{0}'?{1}{1}All associated coach assignments for this sport will also be removed.",
                sportName, Environment.NewLine)

            If UIHelper.Confirm(confirmPrompt, "Confirm Delete Sport") Then
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM SportCoaches WHERE SportID=@id",
                    New SQLiteParameter("@id", sportId))

                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM Sports WHERE SportID=@id",
                    New SQLiteParameter("@id", sportId))

                UIHelper.ShowInfo(String.Format("Sport discipline '{0}' was deleted successfully.", sportName), "Sport Deleted")
                LoadSports()
            End If
        Catch ex As Exception
            UIHelper.ShowError("Failed to delete sport discipline: " & ex.Message)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  STYLING & CELL PAINTING
    ' ═══════════════════════════════════════════════════════════════
    Private Sub DgvSports_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim colName As String = dgvSports.Columns(e.ColumnIndex).Name

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

    Private Sub DgvSports_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        Dim colName As String = dgvSports.Columns(e.ColumnIndex).Name

        If colName = "Active" AndAlso e.Value IsNot Nothing Then
            If e.Value.ToString() = "Active" Then
                e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                e.CellStyle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
            Else
                e.CellStyle.ForeColor = Color.FromArgb(148, 163, 184)
                e.CellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            End If
        ElseIf colName = "Coaches" AndAlso e.Value IsNot Nothing Then
            If e.Value.ToString() = "None Assigned" Then
                e.CellStyle.ForeColor = Color.FromArgb(148, 163, 184)
                e.CellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Italic)
            Else
                e.CellStyle.ForeColor = Color.FromArgb(2, 132, 199)
                e.CellStyle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
            End If
        ElseIf colName = "ApplicantCount" AndAlso e.Value IsNot Nothing Then
            Dim countVal As Integer = 0
            If Integer.TryParse(e.Value.ToString(), countVal) AndAlso countVal > 0 Then
                e.CellStyle.ForeColor = Color.FromArgb(22, 55, 100)
                e.CellStyle.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
            Else
                e.CellStyle.ForeColor = Color.FromArgb(148, 163, 184)
            End If
        End If
    End Sub

End Class
