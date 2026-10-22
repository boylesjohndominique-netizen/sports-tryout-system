Imports System.Data
Imports System.Drawing

''' <summary>
''' Floating pop-up modal dialog for registering student-athletes and editing registration records.
''' Manages student demographics, contact details, academic program, sport discipline, and status.
''' </summary>
Public Class frmStudentRegistrationDialog

    Private targetRegistrationId As Integer = 0
    Private currentStudentId As Integer = 0
    Private isEditMode As Boolean = False

    Public Sub New(Optional registrationId As Integer = 0)
        InitializeComponent()
        Me.targetRegistrationId = registrationId
        Me.isEditMode = (registrationId > 0)
        SetupDialog()
    End Sub

    Private Sub SetupDialog()
        ' Paint card border
        AddHandler cardContent.Paint, AddressOf DrawCardBorder

        ' Populate standard courses
        PopulateCourses()

        ' Load active sports
        LoadSports()

        ' Wire buttons
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        AddHandler btnCancel.Click, Sub(s, e) Me.Close()

        If isEditMode Then
            ' ── EDIT MODE ──
            Me.Text = "Edit Student Registration"
            lblTitle.Text = "✎  Edit Student Registration"
            lblSub.Text = "Update student athlete profile, contact details, sport discipline, or selection status."
            btnSave.Text = "💾  Save Changes"
            lblStatus.Visible = True
            cmbStatus.Visible = True

            LoadExistingRegistration()
        Else
            ' ── CREATE MODE ──
            Me.Text = "Register Student-Athlete"
            lblTitle.Text = "📝  Register Student-Athlete"
            lblSub.Text = "Enter student details, contact info, college degree program, and select preferred sport discipline."
            btnSave.Text = "✚  Register Student"

            If cmbGender.Items.Count > 0 Then cmbGender.SelectedIndex = 0
            If cmbCourse.Items.Count > 0 Then cmbCourse.SelectedIndex = 0
            If cmbYear.Items.Count > 0 Then cmbYear.SelectedIndex = 0
            If cmbStatus.Items.Count > 0 Then cmbStatus.SelectedIndex = 0
            lblStatus.Visible = False
            cmbStatus.Visible = False
        End If
    End Sub

    Private Sub DrawCardBorder(sender As Object, e As PaintEventArgs)
        Dim pnl = TryCast(sender, Panel)
        If pnl Is Nothing Then Return
        Using pen As New Pen(Color.FromArgb(226, 232, 240), 1)
            e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
    End Sub

    ''' <summary>
    ''' Populates the college degree programs strictly offered by the institution:
    ''' BSIT, BSCrim, BSOA, BSED, CAS, BSPolSci with full official program titles.
    ''' </summary>
    Private Sub PopulateCourses()
        cmbCourse.Items.Clear()
        cmbCourse.Items.AddRange(New Object() {
            "BSIT (Bachelor of Science in Information Technology)",
            "BSCrim (Bachelor of Science in Criminology)",
            "BSOA (Bachelor of Science in Office Administration)",
            "BSED (Bachelor of Secondary Education)",
            "CAS (College of Arts and Sciences)",
            "BSPolSci (Bachelor of Science in Political Science)"
        })
    End Sub

    Private Sub MatchCourse(courseText As String)
        If String.IsNullOrWhiteSpace(courseText) Then
            If cmbCourse.Items.Count > 0 Then cmbCourse.SelectedIndex = 0
            Return
        End If

        Dim trimmed As String = courseText.Trim()

        ' 1. Exact match
        Dim idx As Integer = cmbCourse.FindStringExact(trimmed)
        If idx >= 0 Then
            cmbCourse.SelectedIndex = idx
            Return
        End If

        ' 2. Match by acronym or keywords (BSIT, BSCrim, BSOA, BSED, CAS, BSPolSci)
        Dim upper As String = trimmed.ToUpper()
        For i As Integer = 0 To cmbCourse.Items.Count - 1
            Dim itemStr As String = cmbCourse.Items(i).ToString()
            Dim itemUpper As String = itemStr.ToUpper()
            Dim acronym As String = itemStr.Split("("c)(0).Trim().ToUpper()

            If upper.StartsWith(acronym) OrElse upper.Contains(acronym) OrElse itemUpper.Contains(upper) Then
                cmbCourse.SelectedIndex = i
                Return
            End If
        Next

        ' 3. Preserve legacy / custom entry if not in official list
        cmbCourse.Items.Add(trimmed)
        cmbCourse.SelectedItem = trimmed
    End Sub

    Private Sub MatchYear(yearText As String)
        If String.IsNullOrWhiteSpace(yearText) Then
            If cmbYear.Items.Count > 0 Then cmbYear.SelectedIndex = 0
            Return
        End If

        Dim trimmed As String = yearText.Trim()
        Dim idx As Integer = cmbYear.FindStringExact(trimmed)
        If idx >= 0 Then
            cmbYear.SelectedIndex = idx
            Return
        End If

        Dim upper As String = trimmed.ToUpper()
        If upper.Contains("1") OrElse upper.Contains("FIRST") Then
            cmbYear.SelectedIndex = 0 ' 1st Year
        ElseIf upper.Contains("2") OrElse upper.Contains("SECOND") Then
            cmbYear.SelectedIndex = 1 ' 2nd Year
        ElseIf upper.Contains("3") OrElse upper.Contains("THIRD") Then
            cmbYear.SelectedIndex = 2 ' 3rd Year
        ElseIf upper.Contains("4") OrElse upper.Contains("FOURTH") Then
            cmbYear.SelectedIndex = 3 ' 4th Year
        Else
            cmbYear.Items.Add(trimmed)
            cmbYear.SelectedItem = trimmed
        End If
    End Sub

    Private Sub LoadSports()
        Try
            cmbSport.Items.Clear()
            Dim dt As DataTable = DatabaseHelper.GetDataTable("SELECT SportID, SportName FROM Sports WHERE IsActive=1 ORDER BY SportName ASC")
            For Each row As DataRow In dt.Rows
                cmbSport.Items.Add(New SportItem(Convert.ToInt32(row("SportID")), row("SportName").ToString()))
            Next
            If cmbSport.Items.Count > 0 Then cmbSport.SelectedIndex = 0
        Catch ex As Exception
            lblFeedback.Text = "Error loading sports: " & ex.Message
        End Try
    End Sub

    Private Sub LoadExistingRegistration()
        lblFeedback.Text = ""
        Try
            Dim dt As DataTable = DatabaseHelper.GetDataTable(
                "SELECT r.RegistrationID, r.StudentID, r.SportID, r.SelectionStatus, " &
                "s.StudentNumber, s.FirstName, s.MiddleName, s.LastName, s.CourseYear, s.Gender, s.ContactNumber, s.Email, " &
                "sp.SportName " &
                "FROM Registrations r " &
                "INNER JOIN Students s ON s.StudentID = r.StudentID " &
                "INNER JOIN Sports sp ON sp.SportID = r.SportID " &
                "WHERE r.RegistrationID = @rid",
                New SQLiteParameter("@rid", targetRegistrationId))

            If dt.Rows.Count > 0 Then
                Dim row = dt.Rows(0)
                currentStudentId = Convert.ToInt32(row("StudentID"))
                txtStudentNumber.Text = row("StudentNumber").ToString()
                txtFirstName.Text = row("FirstName").ToString()
                txtMiddleName.Text = If(IsDBNull(row("MiddleName")), "", row("MiddleName").ToString())
                txtLastName.Text = row("LastName").ToString()

                Dim gender As String = If(IsDBNull(row("Gender")), "Male", row("Gender").ToString())
                Dim genderIdx As Integer = cmbGender.FindStringExact(gender)
                If genderIdx >= 0 Then cmbGender.SelectedIndex = genderIdx Else cmbGender.Text = gender

                ' Course / Year
                Dim courseYear As String = If(IsDBNull(row("CourseYear")), "", row("CourseYear").ToString())
                If courseYear.Contains(" - ") Then
                    Dim parts As String() = courseYear.Split(New String() {" - "}, StringSplitOptions.None)
                    MatchCourse(parts(0).Trim())
                    If parts.Length > 1 Then
                        MatchYear(parts(1).Trim())
                    End If
                Else
                    MatchCourse(courseYear)
                End If

                txtContact.Text = If(IsDBNull(row("ContactNumber")), "", row("ContactNumber").ToString())
                txtEmail.Text = If(IsDBNull(row("Email")), "", row("Email").ToString())

                ' Sport
                Dim sportId As Integer = Convert.ToInt32(row("SportID"))
                Dim sportName As String = row("SportName").ToString()
                Dim matchedSport As Boolean = False
                For Each item As Object In cmbSport.Items
                    If TypeOf item Is SportItem AndAlso CType(item, SportItem).SportID = sportId Then
                        cmbSport.SelectedItem = item
                        matchedSport = True
                        Exit For
                    End If
                Next
                If Not matchedSport Then
                    Dim inactiveSport As New SportItem(sportId, sportName)
                    cmbSport.Items.Add(inactiveSport)
                    cmbSport.SelectedItem = inactiveSport
                End If

                ' Status
                Dim st As String = If(IsDBNull(row("SelectionStatus")), "Pending", row("SelectionStatus").ToString())
                Dim stIdx As Integer = cmbStatus.FindStringExact(st)
                If stIdx >= 0 Then cmbStatus.SelectedIndex = stIdx Else cmbStatus.Text = st
            End If

        Catch ex As Exception
            lblFeedback.Text = "Failed to load applicant details: " & ex.Message
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        lblFeedback.Text = ""

        Dim snum As String = txtStudentNumber.Text.Trim()
        Dim fname As String = txtFirstName.Text.Trim()
        Dim mname As String = txtMiddleName.Text.Trim()
        Dim lname As String = txtLastName.Text.Trim()

        ' Validation
        If String.IsNullOrWhiteSpace(snum) Then
            lblFeedback.Text = "Student ID / Number is required."
            txtStudentNumber.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(fname) Then
            lblFeedback.Text = "First name is required."
            txtFirstName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(lname) Then
            lblFeedback.Text = "Last name is required."
            txtLastName.Focus()
            Return
        End If

        If cmbCourse.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(cmbCourse.Text) Then
            lblFeedback.Text = "Please select a college degree program / course."
            cmbCourse.Focus()
            Return
        End If

        If cmbYear.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(cmbYear.Text) Then
            lblFeedback.Text = "Please select a year level (1st Year to 4th Year)."
            cmbYear.Focus()
            Return
        End If

        If cmbSport.SelectedItem Is Nothing OrElse Not TypeOf cmbSport.SelectedItem Is SportItem Then
            lblFeedback.Text = "Please select a preferred sport discipline."
            cmbSport.Focus()
            Return
        End If

        Dim selectedSport = CType(cmbSport.SelectedItem, SportItem)
        Dim gender As String = If(cmbGender.SelectedItem IsNot Nothing, cmbGender.Text, "Male")
        Dim contact As String = txtContact.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()

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

        Dim statusStr As String = If(cmbStatus.SelectedItem IsNot Nothing, cmbStatus.Text, "Pending")

        Try
            If isEditMode Then
                ' ── UPDATE EXISTING REGISTRATION ──

                ' Check duplicate registration if sport changed
                Dim dupCheck = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM Registrations WHERE StudentID=@sid AND SportID=@spid AND RegistrationID <> @rid",
                    New SQLiteParameter("@sid", currentStudentId),
                    New SQLiteParameter("@spid", selectedSport.SportID),
                    New SQLiteParameter("@rid", targetRegistrationId))

                If dupCheck IsNot Nothing AndAlso Convert.ToInt32(dupCheck) > 0 Then
                    lblFeedback.Text = "This student is already registered for " & selectedSport.SportName & "."
                    Return
                End If

                ' Update Students record
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Students SET StudentNumber=@sn, FirstName=@f, MiddleName=@m, LastName=@l, CourseYear=@c, Gender=@g, ContactNumber=@ct, Email=@e WHERE StudentID=@sid",
                    New SQLiteParameter("@sn", snum),
                    New SQLiteParameter("@f", fname),
                    New SQLiteParameter("@m", mname),
                    New SQLiteParameter("@l", lname),
                    New SQLiteParameter("@c", courseYear),
                    New SQLiteParameter("@g", gender),
                    New SQLiteParameter("@ct", contact),
                    New SQLiteParameter("@e", email),
                    New SQLiteParameter("@sid", currentStudentId))

                ' Update Registrations record
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Registrations SET SportID=@spid, SelectionStatus=@status WHERE RegistrationID=@rid",
                    New SQLiteParameter("@spid", selectedSport.SportID),
                    New SQLiteParameter("@status", statusStr),
                    New SQLiteParameter("@rid", targetRegistrationId))

                UIHelper.ShowInfo("Student registration updated successfully.", "Registration Updated")

            Else
                ' ── CREATE NEW REGISTRATION ──

                Dim studentId As Integer = 0
                Dim dtExisting = DatabaseHelper.GetDataTable(
                    "SELECT StudentID FROM Students WHERE StudentNumber=@sn",
                    New SQLiteParameter("@sn", snum))

                If dtExisting.Rows.Count > 0 Then
                    studentId = Convert.ToInt32(dtExisting.Rows(0)("StudentID"))
                    ' Update student profile info
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Students SET FirstName=@f, MiddleName=@m, LastName=@l, CourseYear=@c, Gender=@g, ContactNumber=@ct, Email=@e WHERE StudentID=@id",
                        New SQLiteParameter("@f", fname),
                        New SQLiteParameter("@m", mname),
                        New SQLiteParameter("@l", lname),
                        New SQLiteParameter("@c", courseYear),
                        New SQLiteParameter("@g", gender),
                        New SQLiteParameter("@ct", contact),
                        New SQLiteParameter("@e", email),
                        New SQLiteParameter("@id", studentId))
                Else
                    ' Insert new student
                    Using conn = DatabaseHelper.GetConnection()
                        DatabaseHelper.ExecuteNonQuery(
                            "INSERT INTO Students (StudentNumber, FirstName, MiddleName, LastName, CourseYear, Gender, ContactNumber, Email, DateRegistered) " &
                            "VALUES (@sn, @f, @m, @l, @c, @g, @ct, @e, @d)", conn,
                            New SQLiteParameter("@sn", snum),
                            New SQLiteParameter("@f", fname),
                            New SQLiteParameter("@m", mname),
                            New SQLiteParameter("@l", lname),
                            New SQLiteParameter("@c", courseYear),
                            New SQLiteParameter("@g", gender),
                            New SQLiteParameter("@ct", contact),
                            New SQLiteParameter("@e", email),
                            New SQLiteParameter("@d", DateTime.Now.ToString("s")))
                        studentId = Convert.ToInt32(DatabaseHelper.GetLastInsertId(conn))
                    End Using
                End If

                ' Check duplicate registration for the same sport
                Dim dupCheck = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM Registrations WHERE StudentID=@sid AND SportID=@spid",
                    New SQLiteParameter("@sid", studentId),
                    New SQLiteParameter("@spid", selectedSport.SportID))

                If dupCheck IsNot Nothing AndAlso Convert.ToInt32(dupCheck) > 0 Then
                    lblFeedback.Text = "This student is already registered for " & selectedSport.SportName & "."
                    Return
                End If

                ' Insert Registration
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO Registrations (StudentID, SportID, RegistrationDate, SelectionStatus) VALUES (@sid, @spid, @d, 'Pending')",
                    New SQLiteParameter("@sid", studentId),
                    New SQLiteParameter("@spid", selectedSport.SportID),
                    New SQLiteParameter("@d", DateTime.Now.ToString("s")))

                Dim displayName As String = fname & If(mname <> "", " " & mname, "") & " " & lname
                UIHelper.ShowInfo(String.Format("Student-athlete '{0}' registered successfully for {1}!", displayName, selectedSport.SportName), "Registration Successful")
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            lblFeedback.Text = "Database error: " & ex.Message
        End Try
    End Sub

End Class
