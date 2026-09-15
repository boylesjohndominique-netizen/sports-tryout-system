Public Class frmStudentRegistration
    Inherits Form

    Private txtStudentNumber As TextBox
    Private txtFirstName As TextBox
    Private txtLastName As TextBox
    Private txtCourseYear As TextBox
    Private txtContact As TextBox
    Private txtEmail As TextBox
    Private cmbGender As ComboBox
    Private cmbSport As ComboBox
    Private txtSearchStudentNumber As TextBox
    Private dgvStatus As DataGridView

    Public Sub New()
        Me.Text = "Student Registration"
        Me.Dock = DockStyle.Fill
        Me.BackColor = UIHelper.ColorBackground
        BuildUI()
        LoadSports()
    End Sub

    Private Sub BuildUI()
        Dim header As Panel = UIHelper.MakePanelHeader("Student-Athlete Registration", Me.Width)
        Me.Controls.Add(header)

        ' ═══════════════════════════════════════════════════════════
        '  REGISTRATION CARD
        ' ═══════════════════════════════════════════════════════════
        ' ── Registration Form Card ──
        Dim pnlRegCard As New Panel()
        pnlRegCard.Location = New Point(30, 75)
        pnlRegCard.Size = New Size(930, 215)
        pnlRegCard.BackColor = Color.White
        pnlRegCard.BorderStyle = BorderStyle.None

        Dim cardAccent As New Panel()
        cardAccent.Dock = DockStyle.Top
        cardAccent.Height = 3
        cardAccent.BackColor = UIHelper.ColorGold
        pnlRegCard.Controls.Add(cardAccent)

        Dim lblSection1 As New Label()
        lblSection1.Text = "📝  Register New Applicant"
        lblSection1.Font = UIHelper.FontSubHeader
        lblSection1.ForeColor = UIHelper.ColorPrimary
        lblSection1.Location = New Point(20, 10)
        lblSection1.AutoSize = True
        pnlRegCard.Controls.Add(lblSection1)

        ' Row 1: Student ID, First Name, Last Name, Course/Grade
        Dim lblStudentNo As Label = UIHelper.MakeLabel("STUDENT ID", 20, 38, 150)
        lblStudentNo.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblStudentNo.ForeColor = UIHelper.ColorTextSecondary
        txtStudentNumber = UIHelper.MakeTextBox(20, 56, 190)

        Dim lblFirst As Label = UIHelper.MakeLabel("FIRST NAME", 220, 38, 150)
        lblFirst.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblFirst.ForeColor = UIHelper.ColorTextSecondary
        txtFirstName = UIHelper.MakeTextBox(220, 56, 190)

        Dim lblLast As Label = UIHelper.MakeLabel("LAST NAME", 420, 38, 150)
        lblLast.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblLast.ForeColor = UIHelper.ColorTextSecondary
        txtLastName = UIHelper.MakeTextBox(420, 56, 190)

        Dim lblCourse As Label = UIHelper.MakeLabel("COURSE / GRADE", 620, 38, 150)
        lblCourse.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblCourse.ForeColor = UIHelper.ColorTextSecondary
        txtCourseYear = UIHelper.MakeTextBox(620, 56, 190)

        ' Row 2: Gender, Contact, Email, Sport
        Dim lblGender As Label = UIHelper.MakeLabel("GENDER", 20, 96, 150)
        lblGender.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblGender.ForeColor = UIHelper.ColorTextSecondary
        cmbGender = UIHelper.MakeComboBox(20, 114, 190)
        cmbGender.Items.AddRange(New String() {"Male", "Female", "Other"})

        Dim lblContact As Label = UIHelper.MakeLabel("CONTACT NUMBER", 220, 96, 150)
        lblContact.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblContact.ForeColor = UIHelper.ColorTextSecondary
        txtContact = UIHelper.MakeTextBox(220, 114, 190)

        Dim lblEmail As Label = UIHelper.MakeLabel("EMAIL ADDRESS", 420, 96, 150)
        lblEmail.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblEmail.ForeColor = UIHelper.ColorTextSecondary
        txtEmail = UIHelper.MakeTextBox(420, 114, 190)

        Dim lblSport As Label = UIHelper.MakeLabel("PREFERRED SPORT", 620, 96, 150)
        lblSport.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblSport.ForeColor = UIHelper.ColorTextSecondary
        cmbSport = UIHelper.MakeComboBox(620, 114, 190)

        ' Action buttons
        Dim btnRegister As Button = UIHelper.MakeButton("✚ Register Applicant", 20, 160, 200, "gold")
        btnRegister.Height = 36
        AddHandler btnRegister.Click, AddressOf BtnRegister_Click
        pnlRegCard.Controls.Add(btnRegister)

        Dim btnClear As Button = UIHelper.MakeButton("Clear Form", 230, 160, 140, "secondary")
        btnClear.Height = 36
        AddHandler btnClear.Click, AddressOf BtnClear_Click
        pnlRegCard.Controls.Add(btnClear)

        pnlRegCard.Controls.Add(lblStudentNo)
        pnlRegCard.Controls.Add(txtStudentNumber)
        pnlRegCard.Controls.Add(lblFirst)
        pnlRegCard.Controls.Add(txtFirstName)
        pnlRegCard.Controls.Add(lblLast)
        pnlRegCard.Controls.Add(txtLastName)
        pnlRegCard.Controls.Add(lblCourse)
        pnlRegCard.Controls.Add(txtCourseYear)
        pnlRegCard.Controls.Add(lblGender)
        pnlRegCard.Controls.Add(cmbGender)
        pnlRegCard.Controls.Add(lblContact)
        pnlRegCard.Controls.Add(txtContact)
        pnlRegCard.Controls.Add(lblEmail)
        pnlRegCard.Controls.Add(txtEmail)
        pnlRegCard.Controls.Add(lblSport)
        pnlRegCard.Controls.Add(cmbSport)

        Me.Controls.Add(pnlRegCard)

        ' ═══════════════════════════════════════════════════════════
        '  STATUS CHECK CARD
        ' ═══════════════════════════════════════════════════════════
        Dim pnlStatus As New Panel()
        pnlStatus.Location = New Point(30, 305)
        pnlStatus.Size = New Size(930, 56)
        pnlStatus.BackColor = Color.White
        pnlStatus.BorderStyle = BorderStyle.None

        Dim statusAccent As New Panel()
        statusAccent.Dock = DockStyle.Top
        statusAccent.Height = 3
        statusAccent.BackColor = UIHelper.ColorAccent
        pnlStatus.Controls.Add(statusAccent)

        Dim lblSection2 As New Label()
        lblSection2.Text = "🔍  Check Registration Status"
        lblSection2.Font = UIHelper.FontSubHeader
        lblSection2.ForeColor = UIHelper.ColorPrimary
        lblSection2.Location = New Point(20, 17)
        lblSection2.AutoSize = True
        pnlStatus.Controls.Add(lblSection2)

        Dim lblSearchId As Label = UIHelper.MakeLabel("Student ID:", 280, 18, 80)
        lblSearchId.ForeColor = UIHelper.ColorTextSecondary
        pnlStatus.Controls.Add(lblSearchId)

        txtSearchStudentNumber = UIHelper.MakeTextBox(365, 14, 180)
        pnlStatus.Controls.Add(txtSearchStudentNumber)

        Dim btnCheckStatus As Button = UIHelper.MakeButton("Check Status", 560, 12, 140, "primary")
        btnCheckStatus.Height = 32
        AddHandler btnCheckStatus.Click, AddressOf BtnCheckStatus_Click
        pnlStatus.Controls.Add(btnCheckStatus)

        Me.Controls.Add(pnlStatus)

        ' ── Data grid ──
        dgvStatus = UIHelper.MakeDataGridView(30, 375, 930, 215)
        Me.Controls.Add(dgvStatus)
    End Sub

    Private Sub LoadSports()
        cmbSport.Items.Clear()
        Dim dt As DataTable = DatabaseHelper.GetDataTable("SELECT SportID, SportName FROM Sports WHERE IsActive=1 ORDER BY SportName")
        For Each row As DataRow In dt.Rows
            cmbSport.Items.Add(New SportItem(CInt(row("SportID")), row("SportName").ToString()))
        Next
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs)
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
            Dim sportId As Integer = CType(cmbSport.SelectedItem, SportItem).SportID

            Dim existingStudent As DataTable = DatabaseHelper.GetDataTable(
                "SELECT StudentID FROM Students WHERE StudentNumber=@sn", New SQLiteParameter("@sn", studentNumber))

            Dim studentId As Integer

            If existingStudent.Rows.Count > 0 Then
                studentId = CInt(existingStudent.Rows(0)("StudentID"))
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Students SET FirstName=@f, LastName=@l, CourseYear=@c, Gender=@g, ContactNumber=@ct, Email=@e WHERE StudentID=@id",
                    New SQLiteParameter("@f", txtFirstName.Text.Trim()),
                    New SQLiteParameter("@l", txtLastName.Text.Trim()),
                    New SQLiteParameter("@c", txtCourseYear.Text.Trim()),
                    New SQLiteParameter("@g", cmbGender.Text),
                    New SQLiteParameter("@ct", txtContact.Text.Trim()),
                    New SQLiteParameter("@e", txtEmail.Text.Trim()),
                    New SQLiteParameter("@id", studentId))
            Else
                Using conn As SQLiteConnection = DatabaseHelper.GetConnection()
                    DatabaseHelper.ExecuteNonQuery(
                        "INSERT INTO Students (StudentNumber, FirstName, LastName, CourseYear, Gender, ContactNumber, Email, DateRegistered) " &
                        "VALUES (@sn,@f,@l,@c,@g,@ct,@e,@d)", conn,
                        New SQLiteParameter("@sn", studentNumber),
                        New SQLiteParameter("@f", txtFirstName.Text.Trim()),
                        New SQLiteParameter("@l", txtLastName.Text.Trim()),
                        New SQLiteParameter("@c", txtCourseYear.Text.Trim()),
                        New SQLiteParameter("@g", cmbGender.Text),
                        New SQLiteParameter("@ct", txtContact.Text.Trim()),
                        New SQLiteParameter("@e", txtEmail.Text.Trim()),
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

            UIHelper.ShowInfo("Applicant registered successfully.")
            BtnClear_Click(sender, e)
        Catch ex As Exception
            UIHelper.ShowError("Registration failed: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnCheckStatus_Click(sender As Object, e As EventArgs)
        If txtSearchStudentNumber.Text.Trim() = "" Then
            UIHelper.ShowError("Enter a student ID number to search.")
            Return
        End If

        Dim dt As DataTable = DatabaseHelper.GetDataTable(
            "SELECT r.RegistrationID, sp.SportName AS Sport, r.RegistrationDate, s.FirstName, s.LastName " &
            "FROM Registrations r " &
            "INNER JOIN Students s ON s.StudentID = r.StudentID " &
            "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
            "WHERE s.StudentNumber=@sn ORDER BY r.RegistrationDate",
            New SQLiteParameter("@sn", txtSearchStudentNumber.Text.Trim()))

        If dt.Rows.Count = 0 Then
            UIHelper.ShowInfo("No registration found for that student ID.")
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
            display.Rows.Add(row("FirstName").ToString() & " " & row("LastName").ToString(), row("Sport").ToString(),
                              row("RegistrationDate").ToString(), status)
        Next

        dgvStatus.DataSource = display
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        txtStudentNumber.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtCourseYear.Text = ""
        cmbGender.SelectedIndex = -1
        txtContact.Text = ""
        txtEmail.Text = ""
        If cmbSport.Items.Count > 0 Then cmbSport.SelectedIndex = -1
    End Sub

End Class
