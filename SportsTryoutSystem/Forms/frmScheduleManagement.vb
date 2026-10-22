Imports System.Data
Imports System.Drawing

''' <summary>
''' Tryout Schedule Management Form.
''' Displays the full-page table of scheduled tryout sessions across all sports.
''' Features a "+ Create Schedule" pop-up dialog, inline "Edit" pop-up, and safe "Delete" with confirmation.
''' </summary>
Public Class frmScheduleManagement

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
        AddHandler btnCreateSchedule.Click, AddressOf BtnCreateSchedule_Click
        AddHandler btnRefresh.Click, AddressOf BtnRefresh_Click
        AddHandler txtSearch.TextChanged, AddressOf FilterChanged
        AddHandler cmbFilterSport.SelectedIndexChanged, AddressOf FilterChanged
        AddHandler cmbFilterStatus.SelectedIndexChanged, AddressOf FilterChanged

        ' Grid events
        AddHandler dgvSchedules.CellContentClick, AddressOf DgvSchedules_CellContentClick
        AddHandler dgvSchedules.CellClick, AddressOf DgvSchedules_CellClick
        AddHandler dgvSchedules.CellDoubleClick, AddressOf DgvSchedules_CellDoubleClick
        AddHandler dgvSchedules.CellPainting, AddressOf DgvSchedules_CellPainting
        AddHandler dgvSchedules.CellFormatting, AddressOf DgvSchedules_CellFormatting

        ' Card border painting
        AddHandler cardGrid.Paint, AddressOf DrawGridCardBorder
    End Sub

    Private Sub OnFormLoad(sender As Object, e As EventArgs)
        LoadSportsIntoFilter()
        If cmbFilterStatus.Items.Count > 0 Then cmbFilterStatus.SelectedIndex = 0
        LoadSchedules()
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
        dgvSchedules.AutoGenerateColumns = False
        dgvSchedules.Columns.Clear()

        ' Hidden ScheduleID
        dgvSchedules.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ScheduleID",
            .DataPropertyName = "ScheduleID",
            .Visible = False
        })

        ' Sport Discipline
        dgvSchedules.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Sport",
            .DataPropertyName = "Sport",
            .HeaderText = "Sport Discipline",
            .Width = 175,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)}
        })

        ' Tryout Date
        dgvSchedules.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "TryoutDate",
            .DataPropertyName = "TryoutDate",
            .HeaderText = "Tryout Date",
            .Width = 120,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
        })

        ' Session Time
        dgvSchedules.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "TryoutTime",
            .DataPropertyName = "TryoutTime",
            .HeaderText = "Session Time",
            .Width = 110,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
        })

        ' Venue / Location
        dgvSchedules.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Venue",
            .DataPropertyName = "Venue",
            .HeaderText = "Venue / Location",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .FillWeight = 140
        })

        ' Status
        dgvSchedules.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Status",
            .DataPropertyName = "Status",
            .HeaderText = "Status",
            .Width = 110,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
        })

        ' Notes / Remarks
        dgvSchedules.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Notes",
            .DataPropertyName = "Notes",
            .HeaderText = "Special Notes / Remarks",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .FillWeight = 130
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
        dgvSchedules.Columns.Add(colEdit)

        Dim colDelete As New DataGridViewButtonColumn() With {
            .Name = "colDelete",
            .HeaderText = "",
            .Text = "🗑 Delete",
            .UseColumnTextForButtonValue = True,
            .Width = 95,
            .FlatStyle = FlatStyle.Flat
        }
        colDelete.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvSchedules.Columns.Add(colDelete)
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  DATA ACCESS & BINDING
    ' ═══════════════════════════════════════════════════════════════
    Private Sub LoadSportsIntoFilter()
        Try
            cmbFilterSport.Items.Clear()
            cmbFilterSport.Items.Add("All Sports")
            Dim dt As DataTable = DatabaseHelper.GetDataTable("SELECT SportID, SportName FROM Sports WHERE IsActive=1 ORDER BY SportName ASC")
            For Each row As DataRow In dt.Rows
                cmbFilterSport.Items.Add(New SportItem(Convert.ToInt32(row("SportID")), row("SportName").ToString()))
            Next
            If cmbFilterSport.Items.Count > 0 Then cmbFilterSport.SelectedIndex = 0
        Catch ex As Exception
            UIHelper.ShowError("Error loading sports for filter: " & ex.Message)
        End Try
    End Sub

    Public Sub LoadSchedules()
        Try
            Dim sql As String = "SELECT sc.ScheduleID, sp.SportName AS Sport, sc.TryoutDate, sc.TryoutTime, sc.Venue, sc.Status, COALESCE(sc.Notes, '') AS Notes " &
                                "FROM Schedules sc INNER JOIN Sports sp ON sp.SportID = sc.SportID WHERE 1=1 "
            Dim params As New List(Of SQLiteParameter)

            ' Sport filter
            If cmbFilterSport.SelectedItem IsNot Nothing AndAlso TypeOf cmbFilterSport.SelectedItem Is SportItem Then
                sql &= " AND sc.SportID=@sid "
                params.Add(New SQLiteParameter("@sid", CType(cmbFilterSport.SelectedItem, SportItem).SportID))
            End If

            ' Status filter
            If cmbFilterStatus.SelectedIndex > 0 Then
                Dim selectedStatus As String = cmbFilterStatus.SelectedItem.ToString()
                sql &= " AND sc.Status=@status "
                params.Add(New SQLiteParameter("@status", selectedStatus))
            End If

            ' Search filter (Venue, Notes, or Sport Name)
            Dim term As String = txtSearch.Text.Trim()
            If Not String.IsNullOrEmpty(term) Then
                sql &= " AND (sc.Venue LIKE @search OR sc.Notes LIKE @search OR sp.SportName LIKE @search) "
                params.Add(New SQLiteParameter("@search", "%" & term & "%"))
            End If

            sql &= " ORDER BY sc.TryoutDate ASC, sc.TryoutTime ASC"

            Dim dt As DataTable = DatabaseHelper.GetDataTable(sql, params.ToArray())
            dgvSchedules.DataSource = dt
            lblRecordCount.Text = String.Format("Showing {0} Session{1}", dt.Rows.Count, If(dt.Rows.Count = 1, "", "s"))

        Catch ex As Exception
            UIHelper.ShowError("Error loading schedules: " & ex.Message)
        End Try
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs)
        LoadSchedules()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs)
        txtSearch.Clear()
        If cmbFilterSport.Items.Count > 0 Then cmbFilterSport.SelectedIndex = 0
        If cmbFilterStatus.Items.Count > 0 Then cmbFilterStatus.SelectedIndex = 0
        LoadSchedules()
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  POP-UP ACTIONS (Create, Edit, Delete)
    ' ═══════════════════════════════════════════════════════════════
    Private Sub BtnCreateSchedule_Click(sender As Object, e As EventArgs)
        Using dlg As New frmScheduleDialog(0)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                LoadSchedules()
            End If
        End Using
    End Sub

    Private Sub DgvSchedules_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim colName As String = dgvSchedules.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            EditSchedule(e.RowIndex)
        ElseIf colName = "colDelete" Then
            DeleteSchedule(e.RowIndex)
        End If
    End Sub

    Private Sub DgvSchedules_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim colName As String = dgvSchedules.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            EditSchedule(e.RowIndex)
        ElseIf colName = "colDelete" Then
            DeleteSchedule(e.RowIndex)
        End If
    End Sub

    Private Sub DgvSchedules_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            EditSchedule(e.RowIndex)
        End If
    End Sub

    Private Sub EditSchedule(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvSchedules.Rows.Count Then Return
        Try
            Dim scheduleId As Integer = Convert.ToInt32(dgvSchedules.Rows(rowIndex).Cells("ScheduleID").Value)
            Using dlg As New frmScheduleDialog(scheduleId)
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    LoadSchedules()
                End If
            End Using
        Catch ex As Exception
            UIHelper.ShowError("Could not open edit dialog: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteSchedule(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvSchedules.Rows.Count Then Return

        Try
            Dim row = dgvSchedules.Rows(rowIndex)
            Dim scheduleId As Integer = Convert.ToInt32(row.Cells("ScheduleID").Value)
            Dim sportName As String = row.Cells("Sport").Value.ToString()
            Dim tryoutDate As String = row.Cells("TryoutDate").Value.ToString()
            Dim venue As String = If(IsDBNull(row.Cells("Venue").Value), "", row.Cells("Venue").Value.ToString())

            ' Format date nicely for prompt
            Dim formattedDate As String = tryoutDate
            Dim parsedDate As Date
            If Date.TryParse(tryoutDate, parsedDate) Then
                formattedDate = parsedDate.ToString("MMM dd, yyyy")
            End If

            ' Confirmation prompt
            Dim confirmPrompt As String = String.Format(
                "Are you sure you want to permanently delete the tryout session for '{0}' scheduled on {1} at {2}?",
                sportName, formattedDate, venue)

            If UIHelper.Confirm(confirmPrompt, "Confirm Delete Schedule") Then
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM Schedules WHERE ScheduleID=@id",
                    New SQLiteParameter("@id", scheduleId))

                UIHelper.ShowInfo(String.Format("Tryout session for '{0}' on {1} was deleted successfully.", sportName, formattedDate), "Schedule Deleted")
                LoadSchedules()
            End If
        Catch ex As Exception
            UIHelper.ShowError("Failed to delete tryout schedule: " & ex.Message)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  STYLING & CELL PAINTING
    ' ═══════════════════════════════════════════════════════════════
    Private Sub DgvSchedules_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim colName As String = dgvSchedules.Columns(e.ColumnIndex).Name

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

    Private Sub DgvSchedules_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If dgvSchedules.Columns Is Nothing OrElse e.ColumnIndex >= dgvSchedules.Columns.Count Then Return
            Dim col = dgvSchedules.Columns(e.ColumnIndex)
            If col Is Nothing OrElse e.Value Is Nothing Then Return

            ' Format TryoutDate
            If col.Name = "TryoutDate" AndAlso Not IsDBNull(e.Value) Then
                Dim d As Date
                If Date.TryParse(e.Value.ToString(), d) Then
                    e.Value = d.ToString("MMM dd, yyyy")
                    e.FormattingApplied = True
                End If
            End If

            ' Format TryoutTime
            If col.Name = "TryoutTime" AndAlso Not IsDBNull(e.Value) Then
                Dim t As TimeSpan
                If TimeSpan.TryParse(e.Value.ToString(), t) Then
                    Dim dummyDate As DateTime = DateTime.Today.Add(t)
                    e.Value = dummyDate.ToString("hh:mm tt")
                    e.FormattingApplied = True
                Else
                    Dim dt As DateTime
                    If DateTime.TryParse(e.Value.ToString(), dt) Then
                        e.Value = dt.ToString("hh:mm tt")
                        e.FormattingApplied = True
                    End If
                End If
            End If

            ' Format Status with badge colors
            If col.Name = "Status" AndAlso Not IsDBNull(e.Value) Then
                Dim statusText As String = e.Value.ToString().Trim()
                e.CellStyle.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
                Select Case statusText.ToLower()
                    Case "upcoming"
                        e.CellStyle.ForeColor = Color.FromArgb(29, 78, 216)
                        e.CellStyle.BackColor = Color.FromArgb(239, 246, 255)
                    Case "completed"
                        e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52)
                        e.CellStyle.BackColor = Color.FromArgb(240, 253, 244)
                    Case "cancelled"
                        e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28)
                        e.CellStyle.BackColor = Color.FromArgb(254, 242, 242)
                End Select
            End If

        Catch
        End Try
    End Sub

End Class
