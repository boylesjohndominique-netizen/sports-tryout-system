Imports System.Data
Imports System.Drawing

''' <summary>
''' Student-Athlete Registration & Records Management Form.
''' Displays the full-page table of registered student applicants across all sports disciplines.
''' Features a "+ Register Student" pop-up dialog, inline "Edit" pop-up, and safe "Delete" with confirmation.
''' </summary>
Public Class frmStudentRegistration

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
        AddHandler btnRegisterStudent.Click, AddressOf BtnRegisterStudent_Click
        AddHandler btnRefresh.Click, AddressOf BtnRefresh_Click
        AddHandler txtSearch.TextChanged, AddressOf FilterChanged
        AddHandler cmbFilterSport.SelectedIndexChanged, AddressOf FilterChanged
        AddHandler cmbFilterStatus.SelectedIndexChanged, AddressOf FilterChanged

        ' Grid events
        AddHandler dgvRegistrations.CellContentClick, AddressOf DgvRegistrations_CellContentClick
        AddHandler dgvRegistrations.CellClick, AddressOf DgvRegistrations_CellClick
        AddHandler dgvRegistrations.CellDoubleClick, AddressOf DgvRegistrations_CellDoubleClick
        AddHandler dgvRegistrations.CellPainting, AddressOf DgvRegistrations_CellPainting
        AddHandler dgvRegistrations.CellFormatting, AddressOf DgvRegistrations_CellFormatting

        ' Card border painting
        AddHandler cardGrid.Paint, AddressOf DrawGridCardBorder
    End Sub

    Private Sub OnFormLoad(sender As Object, e As EventArgs)
        LoadSportsIntoFilter()
        If cmbFilterStatus.Items.Count > 0 Then cmbFilterStatus.SelectedIndex = 0
        LoadRegistrations()
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
        dgvRegistrations.AutoGenerateColumns = False
        dgvRegistrations.Columns.Clear()

        ' Hidden IDs
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "RegistrationID",
            .DataPropertyName = "RegistrationID",
            .Visible = False
        })
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "StudentID",
            .DataPropertyName = "StudentID",
            .Visible = False
        })

        ' Student ID
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "StudentNumber",
            .DataPropertyName = "StudentNumber",
            .HeaderText = "Student ID",
            .Width = 110,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter, .Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
        })

        ' Full Name
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ApplicantName",
            .DataPropertyName = "ApplicantName",
            .HeaderText = "Applicant Name",
            .Width = 175,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)}
        })

        ' Preferred Sport
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Sport",
            .DataPropertyName = "Sport",
            .HeaderText = "Preferred Sport",
            .Width = 135,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)}
        })

        ' Course & Year
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "CourseYear",
            .DataPropertyName = "CourseYear",
            .HeaderText = "Course & Year Level",
            .Width = 240
        })

        ' Gender
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Gender",
            .DataPropertyName = "Gender",
            .HeaderText = "Gender",
            .Width = 80,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
        })

        ' Contact Number
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Contact",
            .DataPropertyName = "Contact",
            .HeaderText = "Contact No.",
            .Width = 115
        })

        ' Email Address
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Email",
            .DataPropertyName = "Email",
            .HeaderText = "Email Address",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .FillWeight = 115
        })

        ' Registration Date
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "RegistrationDate",
            .DataPropertyName = "RegistrationDate",
            .HeaderText = "Reg. Date",
            .Width = 110,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
        })

        ' Status
        dgvRegistrations.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Status",
            .DataPropertyName = "Status",
            .HeaderText = "Status",
            .Width = 120,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter},
            .HeaderCell = New DataGridViewColumnHeaderCell() With {.Style = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleCenter}}
        })

        ' ── 2 ACTION BUTTON COLUMNS (Edit & Delete) ──
        Dim colEdit As New DataGridViewButtonColumn() With {
            .Name = "colEdit",
            .HeaderText = "Actions",
            .Text = "✎ Edit",
            .UseColumnTextForButtonValue = True,
            .Width = 80,
            .FlatStyle = FlatStyle.Flat
        }
        colEdit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvRegistrations.Columns.Add(colEdit)

        Dim colDelete As New DataGridViewButtonColumn() With {
            .Name = "colDelete",
            .HeaderText = "",
            .Text = "🗑 Delete",
            .UseColumnTextForButtonValue = True,
            .Width = 90,
            .FlatStyle = FlatStyle.Flat
        }
        colDelete.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvRegistrations.Columns.Add(colDelete)
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

    Public Sub LoadRegistrations()
        Try
            Dim sql As String = "SELECT r.RegistrationID, r.StudentID, s.StudentNumber, " &
                                "s.FirstName, s.MiddleName, s.LastName, " &
                                "COALESCE(s.CourseYear, '') AS CourseYear, COALESCE(s.Gender, '') AS Gender, " &
                                "COALESCE(s.ContactNumber, '') AS Contact, COALESCE(s.Email, '') AS Email, " &
                                "sp.SportName AS Sport, r.RegistrationDate, r.SelectionStatus AS Status " &
                                "FROM Registrations r " &
                                "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                                "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                                "WHERE 1=1 "
            Dim params As New List(Of SQLiteParameter)

            ' Sport filter
            If cmbFilterSport.SelectedItem IsNot Nothing AndAlso TypeOf cmbFilterSport.SelectedItem Is SportItem Then
                sql &= " AND r.SportID=@sid "
                params.Add(New SQLiteParameter("@sid", CType(cmbFilterSport.SelectedItem, SportItem).SportID))
            End If

            ' Status filter
            If cmbFilterStatus.SelectedIndex > 0 Then
                Dim selectedStatus As String = cmbFilterStatus.SelectedItem.ToString()
                sql &= " AND r.SelectionStatus=@status "
                params.Add(New SQLiteParameter("@status", selectedStatus))
            End If

            ' Search filter (Name, Student Number, Course, Email)
            Dim term As String = txtSearch.Text.Trim()
            If Not String.IsNullOrEmpty(term) Then
                sql &= " AND (s.StudentNumber LIKE @term OR s.FirstName LIKE @term OR s.LastName LIKE @term OR s.CourseYear LIKE @term OR s.Email LIKE @term OR sp.SportName LIKE @term) "
                params.Add(New SQLiteParameter("@term", "%" & term & "%"))
            End If

            sql &= " ORDER BY r.RegistrationID DESC"

            Dim dtRaw As DataTable = DatabaseHelper.GetDataTable(sql, params.ToArray())

            ' Build display table with composite full name
            Dim dtDisplay As New DataTable()
            dtDisplay.Columns.Add("RegistrationID", GetType(Integer))
            dtDisplay.Columns.Add("StudentID", GetType(Integer))
            dtDisplay.Columns.Add("StudentNumber", GetType(String))
            dtDisplay.Columns.Add("ApplicantName", GetType(String))
            dtDisplay.Columns.Add("Sport", GetType(String))
            dtDisplay.Columns.Add("CourseYear", GetType(String))
            dtDisplay.Columns.Add("Gender", GetType(String))
            dtDisplay.Columns.Add("Contact", GetType(String))
            dtDisplay.Columns.Add("Email", GetType(String))
            dtDisplay.Columns.Add("RegistrationDate", GetType(String))
            dtDisplay.Columns.Add("Status", GetType(String))

            For Each row As DataRow In dtRaw.Rows
                Dim mName As String = If(IsDBNull(row("MiddleName")), "", row("MiddleName").ToString().Trim())
                Dim fullName As String = row("FirstName").ToString().Trim() &
                    If(mName <> "", " " & mName, "") & " " &
                    row("LastName").ToString().Trim()

                dtDisplay.Rows.Add(
                    Convert.ToInt32(row("RegistrationID")),
                    Convert.ToInt32(row("StudentID")),
                    row("StudentNumber").ToString(),
                    fullName,
                    row("Sport").ToString(),
                    row("CourseYear").ToString(),
                    row("Gender").ToString(),
                    row("Contact").ToString(),
                    row("Email").ToString(),
                    row("RegistrationDate").ToString(),
                    row("Status").ToString())
            Next

            dgvRegistrations.DataSource = dtDisplay
            lblRecordCount.Text = String.Format("Showing {0} Registered Applicant{1}", dtDisplay.Rows.Count, If(dtDisplay.Rows.Count = 1, "", "s"))

        Catch ex As Exception
            UIHelper.ShowError("Error loading registrations: " & ex.Message)
        End Try
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs)
        LoadRegistrations()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs)
        txtSearch.Clear()
        If cmbFilterSport.Items.Count > 0 Then cmbFilterSport.SelectedIndex = 0
        If cmbFilterStatus.Items.Count > 0 Then cmbFilterStatus.SelectedIndex = 0
        LoadRegistrations()
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  POP-UP ACTIONS (Register, Edit, Delete)
    ' ═══════════════════════════════════════════════════════════════
    Private Sub BtnRegisterStudent_Click(sender As Object, e As EventArgs)
        Using dlg As New frmStudentRegistrationDialog(0)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                LoadRegistrations()
                Try
                    CType(Me.MdiParent, frmMain)?.RefreshNavMetrics()
                Catch
                End Try
            End If
        End Using
    End Sub

    Private Sub DgvRegistrations_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim colName As String = dgvRegistrations.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            EditRegistration(e.RowIndex)
        ElseIf colName = "colDelete" Then
            DeleteRegistration(e.RowIndex)
        End If
    End Sub

    Private Sub DgvRegistrations_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim colName As String = dgvRegistrations.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            EditRegistration(e.RowIndex)
        ElseIf colName = "colDelete" Then
            DeleteRegistration(e.RowIndex)
        End If
    End Sub

    Private Sub DgvRegistrations_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            EditRegistration(e.RowIndex)
        End If
    End Sub

    Private Sub EditRegistration(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvRegistrations.Rows.Count Then Return
        Try
            Dim regId As Integer = Convert.ToInt32(dgvRegistrations.Rows(rowIndex).Cells("RegistrationID").Value)
            Using dlg As New frmStudentRegistrationDialog(regId)
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    LoadRegistrations()
                    Try
                        CType(Me.MdiParent, frmMain)?.RefreshNavMetrics()
                    Catch
                    End Try
                End If
            End Using
        Catch ex As Exception
            UIHelper.ShowError("Could not open edit dialog: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteRegistration(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvRegistrations.Rows.Count Then Return

        Try
            Dim row = dgvRegistrations.Rows(rowIndex)
            Dim regId As Integer = Convert.ToInt32(row.Cells("RegistrationID").Value)
            Dim applicantName As String = row.Cells("ApplicantName").Value.ToString()
            Dim sportName As String = row.Cells("Sport").Value.ToString()

            ' Check if evaluation scores exist for this registration
            Dim evalCountObj As Object = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Evaluations WHERE RegistrationID=@rid",
                New SQLiteParameter("@rid", regId))
            Dim evalCount As Integer = If(evalCountObj IsNot Nothing AndAlso Not IsDBNull(evalCountObj), Convert.ToInt32(evalCountObj), 0)

            Dim confirmPrompt As String
            If evalCount > 0 Then
                confirmPrompt = String.Format(
                    "Applicant '{0}' has {1} evaluation score(s) on record for {2}.{3}{3}Deleting this registration will permanently delete the registration and all associated evaluation scores.{3}{3}Are you sure you want to proceed?",
                    applicantName, evalCount, sportName, Environment.NewLine)
            Else
                confirmPrompt = String.Format(
                    "Are you sure you want to permanently delete the registration record for '{0}' in {1}?",
                    applicantName, sportName)
            End If

            If UIHelper.Confirm(confirmPrompt, "Confirm Delete Registration") Then
                ' Delete evaluation scores first
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM Evaluations WHERE RegistrationID=@rid",
                    New SQLiteParameter("@rid", regId))

                ' Delete registration
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM Registrations WHERE RegistrationID=@rid",
                    New SQLiteParameter("@rid", regId))

                UIHelper.ShowInfo(String.Format("Registration for '{0}' in {1} was deleted successfully.", applicantName, sportName), "Registration Deleted")
                LoadRegistrations()

                Try
                    CType(Me.MdiParent, frmMain)?.RefreshNavMetrics()
                Catch
                End Try
            End If

        Catch ex As Exception
            UIHelper.ShowError("Failed to delete registration record: " & ex.Message)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    '  STYLING & CELL PAINTING
    ' ═══════════════════════════════════════════════════════════════
    Private Sub DgvRegistrations_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim colName As String = dgvRegistrations.Columns(e.ColumnIndex).Name

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

    Private Sub DgvRegistrations_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If dgvRegistrations.Columns Is Nothing OrElse e.ColumnIndex >= dgvRegistrations.Columns.Count Then Return
            Dim col = dgvRegistrations.Columns(e.ColumnIndex)
            If col Is Nothing OrElse e.Value Is Nothing Then Return

            ' Format RegistrationDate
            If col.Name = "RegistrationDate" AndAlso Not IsDBNull(e.Value) Then
                Dim d As Date
                If Date.TryParse(e.Value.ToString(), d) Then
                    e.Value = d.ToString("MMM dd, yyyy")
                    e.FormattingApplied = True
                End If
            End If

            ' Format Status with badge colors
            If col.Name = "Status" AndAlso Not IsDBNull(e.Value) Then
                Dim statusText As String = e.Value.ToString().Trim()
                e.CellStyle.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
                Select Case statusText.ToLower()
                    Case "selected"
                        e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52)
                        e.CellStyle.BackColor = Color.FromArgb(240, 253, 244)
                    Case "not selected"
                        e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28)
                        e.CellStyle.BackColor = Color.FromArgb(254, 242, 242)
                    Case "for further evaluation"
                        e.CellStyle.ForeColor = Color.FromArgb(29, 78, 216)
                        e.CellStyle.BackColor = Color.FromArgb(239, 246, 255)
                    Case "pending"
                        e.CellStyle.ForeColor = Color.FromArgb(161, 98, 7)
                        e.CellStyle.BackColor = Color.FromArgb(254, 252, 232)
                End Select
            End If

        Catch
        End Try
    End Sub

End Class
