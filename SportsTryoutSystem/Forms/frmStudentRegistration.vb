Imports System.Data
Imports System.Drawing

Public Class frmStudentRegistration

    Private headerPanel As Panel

    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True

        headerPanel = UIHelper.MakePanelHeader("Student-Athlete Registration", Me.Width)
        Me.Controls.Add(headerPanel)
        headerPanel.SendToBack()

        AddHandler Me.Resize, AddressOf OnFormResized
        AddHandler Me.Shown, AddressOf OnFormShown
        AddHandler dgvStatus.CellFormatting, AddressOf DgvStatus_CellFormatting
    End Sub

    Private Sub OnFormShown(sender As Object, e As EventArgs)
        LayoutPanels()
        Try
            DatabaseHelper.EnsureStudentsMiddleNameColumn()
            LoadSports()
            LoadRecentRegistrations()
        Catch ex As Exception
            UIHelper.ShowError("Failed to initialize registration data: " & ex.Message)
        End Try
    End Sub

    Private Sub OnFormResized(sender As Object, e As EventArgs)
        LayoutPanels()
    End Sub

    ' ========================================================
    '  DYNAMIC RESPONSIVE LAYOUT ENGINE (ZERO OVERLAPPING)
    ' ========================================================

    Private Sub LayoutPanels()
        If Me.ClientSize.Width < 700 OrElse Me.ClientSize.Height < 450 Then Return

        Me.SuspendLayout()

        Dim topY As Integer = 72
        Dim marginX As Integer = 24
        Dim bottomMargin As Integer = 20
        Dim totalW As Integer = Me.ClientSize.Width - (marginX * 2)

        ' 1. Top Card: Registration Form (pnlRegCard) - Increased height for 3 clean rows
        Dim regH As Integer = 320
        pnlRegCard.Location = New Point(marginX, topY)
        pnlRegCard.Size = New Size(totalW, regH)

        LayoutRegistrationCard(totalW)

        ' 2. Bottom Card: Status Verification & Recent Records (pnlStatusCard)
        Dim statusY As Integer = topY + regH + 16
        Dim statusH As Integer = Me.ClientSize.Height - statusY - bottomMargin
        pnlStatusCard.Location = New Point(marginX, statusY)
        pnlStatusCard.Size = New Size(totalW, Math.Max(180, statusH))

        LayoutStatusCard(totalW, pnlStatusCard.Height)

        Me.ResumeLayout(True)
    End Sub

    Private Sub LayoutRegistrationCard(cardW As Integer)
        pnlRegCard.SuspendLayout()

        cardAccent.Width = cardW

        lblSection1.Location = New Point(20, 14)
        lblRegSub.Location = New Point(22, 38)
        lblRegBadge.Location = New Point(Math.Max(260, cardW - 200), 14)

        ' 4 columns evenly distributed
        Dim colGap As Integer = 20
        Dim colW As Integer = CInt((cardW - 40 - (colGap * 3)) / 4)
        If colW < 140 Then colW = 140

        Dim col1X As Integer = 20
        Dim col2X As Integer = 20 + colW + colGap
        Dim col3X As Integer = 20 + (colW + colGap) * 2
        Dim col4X As Integer = 20 + (colW + colGap) * 3

        ' Row 1: Student ID, First Name, Middle Name, Last Name
        lblStudentNo.Location = New Point(col1X, 62)
        txtStudentNumber.Location = New Point(col1X, 82)
        txtStudentNumber.Size = New Size(colW, 26)

        lblFirst.Location = New Point(col2X, 62)
        txtFirstName.Location = New Point(col2X, 82)
        txtFirstName.Size = New Size(colW, 26)

        lblMiddle.Location = New Point(col3X, 62)
        txtMiddleName.Location = New Point(col3X, 82)
        txtMiddleName.Size = New Size(colW, 26)

        lblLast.Location = New Point(col4X, 62)
        txtLastName.Location = New Point(col4X, 82)
        txtLastName.Size = New Size(colW, 26)

        ' Row 2: Course, Year Level, Gender, Preferred Sport
        lblCourse.Location = New Point(col1X, 122)
        cmbCourse.Location = New Point(col1X, 142)
        cmbCourse.Size = New Size(colW, 26)

        lblYear.Location = New Point(col2X, 122)
        cmbYear.Location = New Point(col2X, 142)
        cmbYear.Size = New Size(colW, 26)

        lblGender.Location = New Point(col3X, 122)
        cmbGender.Location = New Point(col3X, 142)
        cmbGender.Size = New Size(colW, 26)

        lblSport.Location = New Point(col4X, 122)
        cmbSport.Location = New Point(col4X, 142)
        cmbSport.Size = New Size(colW, 26)

        ' Row 3: Contact Number, Email Address (span 2 columns each for generous typing room)
        Dim wideColW As Integer = (colW * 2) + colGap
        lblContact.Location = New Point(col1X, 182)
        txtContact.Location = New Point(col1X, 202)
        txtContact.Size = New Size(wideColW, 26)

        lblEmail.Location = New Point(col3X, 182)
        txtEmail.Location = New Point(col3X, 202)
        txtEmail.Size = New Size(wideColW, 26)

        ' Separator & Action Buttons
        div1.Location = New Point(20, 246)
        div1.Size = New Size(cardW - 40, 1)

        btnRegister.Location = New Point(20, 258)
        btnRegister.Size = New Size(220, 42)

        btnClear.Location = New Point(252, 258)
        btnClear.Size = New Size(140, 42)

        lblNoteHint.Location = New Point(408, 266)
        lblNoteHint.Size = New Size(Math.Max(200, cardW - 428), 26)

        pnlRegCard.ResumeLayout(True)
    End Sub

    Private Sub LayoutStatusCard(cardW As Integer, cardH As Integer)
        pnlStatusCard.SuspendLayout()

        statusAccent.Width = cardW

        lblSection2.Location = New Point(20, 14)
        lblStatusSub.Location = New Point(22, 38)

        ' Search bar right aligned
        Dim searchBtnW As Integer = 160
        Dim searchTxtW As Integer = 200
        Dim searchGrpW As Integer = searchBtnW + searchTxtW + 85

        Dim startSearchX As Integer = Math.Max(320, cardW - searchGrpW - 20)
        lblSearchId.Location = New Point(startSearchX, 20)
        txtSearchStudentNumber.Location = New Point(startSearchX + 75, 17)
        txtSearchStudentNumber.Size = New Size(searchTxtW, 25)

        btnCheckStatus.Location = New Point(startSearchX + 75 + searchTxtW + 10, 14)
        btnCheckStatus.Size = New Size(searchBtnW, 32)

        dgvStatus.Location = New Point(20, 62)
        dgvStatus.Size = New Size(cardW - 40, Math.Max(80, cardH - 80))

        pnlStatusCard.ResumeLayout(True)
    End Sub

    ' ========================================================
    '  DATA ACCESS & BINDING
    ' ========================================================

    Private Sub LoadSports()
        Try
            cmbSport.Items.Clear()
            Dim dt As DataTable = DatabaseHelper.GetDataTable("SELECT SportID, SportName FROM Sports WHERE IsActive=1 ORDER BY SportName")
            For Each row As DataRow In dt.Rows
                cmbSport.Items.Add(New SportItem(CInt(row("SportID")), row("SportName").ToString()))
            Next
        Catch ex As Exception
            UIHelper.ShowError("Error loading sports: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadRecentRegistrations()
        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT r.RegistrationID, sp.SportName AS Sport, r.RegistrationDate, s.FirstName, s.MiddleName, s.LastName " &
                "FROM Registrations r " &
                "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                "ORDER BY r.RegistrationID DESC LIMIT 15")

            Dim display As New DataTable()
            display.Columns.Add("Applicant")
            display.Columns.Add("Sport")
            display.Columns.Add("Registration Date")
            display.Columns.Add("Current Status")

            For Each row As DataRow In dt.Rows
                Dim status As String = AppLogic.GetRegistrationStatusText(CInt(row("RegistrationID")))
                Dim mName As String = If(IsDBNull(row("MiddleName")), "", row("MiddleName").ToString().Trim())
                Dim fullName As String = row("FirstName").ToString().Trim() &
                    If(mName <> "", " " & mName, "") & " " &
                    row("LastName").ToString().Trim()

                display.Rows.Add(fullName,
                                  row("Sport").ToString(),
                                  row("RegistrationDate").ToString(), status)
            Next

            dgvStatus.DataSource = display
            FormatStatusGridColumns()
        Catch
            dgvStatus.DataSource = Nothing
        End Try
    End Sub

    Private Sub FormatStatusGridColumns()
        If dgvStatus.Columns.Contains("Applicant") Then dgvStatus.Columns("Applicant").FillWeight = 28
        If dgvStatus.Columns.Contains("Sport") Then dgvStatus.Columns("Sport").FillWeight = 22
        If dgvStatus.Columns.Contains("Registration Date") Then
            dgvStatus.Columns("Registration Date").FillWeight = 25
            dgvStatus.Columns("Registration Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvStatus.Columns("Registration Date").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvStatus.Columns.Contains("Current Status") Then
            dgvStatus.Columns("Current Status").FillWeight = 25
            dgvStatus.Columns("Current Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvStatus.Columns("Current Status").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    Private Sub DgvStatus_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If dgvStatus.Columns Is Nothing OrElse e.ColumnIndex >= dgvStatus.Columns.Count Then Return
            Dim col = dgvStatus.Columns(e.ColumnIndex)
            If col Is Nothing OrElse col.Name <> "Current Status" OrElse e.Value Is Nothing Then Return

            Dim st As String = e.Value.ToString()
            If st.Contains("Selected") AndAlso Not st.Contains("Not Selected") Then
                e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74)
                e.CellStyle.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
            ElseIf st.Contains("Not Selected") Then
                e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38)
            ElseIf st.Contains("For Further Evaluation") Then
                e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235)
            Else
                e.CellStyle.ForeColor = Color.FromArgb(202, 138, 4)
            End If
        Catch
        End Try
    End Sub

    ' ========================================================
    '  ACTION BUTTONS & REGISTRATION LOGIC
    ' ========================================================

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If txtStudentNumber.Text.Trim() = "" OrElse txtFirstName.Text.Trim() = "" OrElse txtLastName.Text.Trim() = "" Then
            UIHelper.ShowError("Student ID, first name, and last name are required.")
            Return
        End If
        If cmbSport.SelectedItem Is Nothing OrElse Not TypeOf cmbSport.SelectedItem Is SportItem Then
            UIHelper.ShowError("Please select a preferred sport.")
            Return
        End If

        Try
            Dim studentNumber As String = txtStudentNumber.Text.Trim()
            Dim firstName As String = txtFirstName.Text.Trim()
            Dim middleName As String = txtMiddleName.Text.Trim()
            Dim lastName As String = txtLastName.Text.Trim()
            Dim course As String = cmbCourse.Text.Trim()
            Dim yearLvl As String = cmbYear.Text.Trim()
            Dim courseYear As String = ""

            If course <> "" AndAlso yearLvl <> "" Then
                courseYear = course & " - " & yearLvl
            ElseIf course <> "" Then
                courseYear = course
            Else
                courseYear = yearLvl
            End If

            Dim gender As String = cmbGender.Text.Trim()
            Dim contact As String = txtContact.Text.Trim()
            Dim email As String = txtEmail.Text.Trim()
            Dim sportId As Integer = CType(cmbSport.SelectedItem, SportItem).SportID

            Dim existingStudent As DataTable = DatabaseHelper.GetDataTable(
                "SELECT StudentID FROM Students WHERE StudentNumber=@sn", New SQLiteParameter("@sn", studentNumber))

            Dim studentId As Integer

            If existingStudent.Rows.Count > 0 Then
                studentId = CInt(existingStudent.Rows(0)("StudentID"))
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Students SET FirstName=@f, MiddleName=@m, LastName=@l, CourseYear=@c, Gender=@g, ContactNumber=@ct, Email=@e WHERE StudentID=@id",
                    New SQLiteParameter("@f", firstName),
                    New SQLiteParameter("@m", middleName),
                    New SQLiteParameter("@l", lastName),
                    New SQLiteParameter("@c", courseYear),
                    New SQLiteParameter("@g", gender),
                    New SQLiteParameter("@ct", contact),
                    New SQLiteParameter("@e", email),
                    New SQLiteParameter("@id", studentId))
            Else
                Using conn As SQLiteConnection = DatabaseHelper.GetConnection()
                    DatabaseHelper.ExecuteNonQuery(
                        "INSERT INTO Students (StudentNumber, FirstName, MiddleName, LastName, CourseYear, Gender, ContactNumber, Email, DateRegistered) " &
                        "VALUES (@sn,@f,@m,@l,@c,@g,@ct,@e,@d)", conn,
                        New SQLiteParameter("@sn", studentNumber),
                        New SQLiteParameter("@f", firstName),
                        New SQLiteParameter("@m", middleName),
                        New SQLiteParameter("@l", lastName),
                        New SQLiteParameter("@c", courseYear),
                        New SQLiteParameter("@g", gender),
                        New SQLiteParameter("@ct", contact),
                        New SQLiteParameter("@e", email),
                        New SQLiteParameter("@d", Now.ToString("s")))
                    studentId = CInt(DatabaseHelper.GetLastInsertId(conn))
                End Using
            End If

            Dim duplicateCheck As Object = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Registrations WHERE StudentID=@sid AND SportID=@spid",
                New SQLiteParameter("@sid", studentId), New SQLiteParameter("@spid", sportId))

            If CInt(duplicateCheck) > 0 Then
                UIHelper.ShowError("This student is already registered for the selected sport. Duplicate registrations are not allowed.")
                Return
            End If

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Registrations (StudentID, SportID, RegistrationDate, SelectionStatus) VALUES (@sid,@spid,@d,'Pending')",
                New SQLiteParameter("@sid", studentId),
                New SQLiteParameter("@spid", sportId),
                New SQLiteParameter("@d", Now.ToString("s")))

            Dim displayFullName As String = firstName & If(middleName <> "", " " & middleName, "") & " " & lastName
            UIHelper.ShowInfo("Applicant '" & displayFullName & "' registered successfully!")

            ' Clear input fields and show newly registered record in tracker
            BtnClear_Click(sender, e)
            txtSearchStudentNumber.Text = studentNumber
            BtnCheckStatus_Click(sender, e)

        Catch ex As Exception
            UIHelper.ShowError("Registration failed: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnCheckStatus_Click(sender As Object, e As EventArgs) Handles btnCheckStatus.Click
        Dim searchId As String = txtSearchStudentNumber.Text.Trim()
        If searchId = "" Then
            LoadRecentRegistrations()
            Return
        End If

        Dim dt As DataTable = DatabaseHelper.GetDataTable(
            "SELECT r.RegistrationID, sp.SportName AS Sport, r.RegistrationDate, s.FirstName, s.MiddleName, s.LastName " &
            "FROM Registrations r " &
            "INNER JOIN Students s ON s.StudentID = r.StudentID " &
            "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
            "WHERE s.StudentNumber=@sn ORDER BY r.RegistrationDate",
            New SQLiteParameter("@sn", searchId))

        If dt.Rows.Count = 0 Then
            UIHelper.ShowInfo("No registration records found for Student ID: " & searchId)
            dgvStatus.DataSource = Nothing
            Return
        End If

        Dim display As New DataTable()
        display.Columns.Add("Applicant")
        display.Columns.Add("Sport")
        display.Columns.Add("Registration Date")
        display.Columns.Add("Current Status")

        For Each row As DataRow In dt.Rows
            Dim status As String = AppLogic.GetRegistrationStatusText(CInt(row("RegistrationID")))
            Dim mName As String = If(IsDBNull(row("MiddleName")), "", row("MiddleName").ToString().Trim())
            Dim fullName As String = row("FirstName").ToString().Trim() &
                If(mName <> "", " " & mName, "") & " " &
                row("LastName").ToString().Trim()

            display.Rows.Add(fullName, row("Sport").ToString(),
                              row("RegistrationDate").ToString(), status)
        Next

        dgvStatus.DataSource = display
        FormatStatusGridColumns()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtStudentNumber.Text = ""
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        cmbCourse.SelectedIndex = -1
        cmbYear.SelectedIndex = -1
        cmbGender.SelectedIndex = -1
        txtContact.Text = ""
        txtEmail.Text = ""
        If cmbSport.Items.Count > 0 Then cmbSport.SelectedIndex = -1
    End Sub

End Class
