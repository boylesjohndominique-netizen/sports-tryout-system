Imports System.Data
Imports System.Diagnostics
Imports MySql.Data.MySqlClient

''' <summary>
''' Presentation-ready demo data for every table in the system.
'''
''' The seeder is idempotent: accounts, sports, coach assignments and
''' schedules are upserted, while students, registrations and evaluations
''' are only generated when no demo records exist yet.
'''
''' Usage:
'''   SportsTryoutSystem.exe --demo         add demo data to the current database
'''   SportsTryoutSystem.exe --demo-reset   replace demo records with a fresh set
'''
''' On a normal launch the app seeds automatically when the database still
''' looks empty (fewer than five registrations).
''' </summary>
Public Module DemoData

    Public Const DemoStudentPrefix As String = "2026-"
    Private Const DemoStudentEmailDomain As String = "@students.sts.edu.ph"
    Private Const AdminName As String = "Dr. Ramon M. Villanueva"
    Private Const AutoSeedThreshold As Integer = 5

    Private ReadOnly Rng As New Random(20261022)

    Private ReadOnly CoursePrograms As String() = {
        "BSIT (Bachelor of Science in Information Technology)",
        "BSCrim (Bachelor of Science in Criminology)",
        "BSOA (Bachelor of Science in Office Administration)",
        "BSED (Bachelor of Secondary Education)",
        "CAS (College of Arts and Sciences)",
        "BSPolSci (Bachelor of Science in Political Science)"
    }

    Private ReadOnly YearLevels As String() = {"1st Year", "2nd Year", "3rd Year", "4th Year"}

    Private ReadOnly MaleFirstNames As String() = {
        "Miguel", "Jose", "Juan", "Carlo", "Rafael", "Gabriel", "Angelo", "Mark", "Joshua", "Christian",
        "Daniel", "Paolo", "Adrian", "Nico", "Emmanuel", "Lorenzo", "Marco", "Andres", "Ricardo", "Francis"
    }

    Private ReadOnly FemaleFirstNames As String() = {
        "Maria", "Sofia", "Angela", "Bianca", "Camille", "Danielle", "Erika", "Jasmine", "Katrina", "Liza",
        "Marian", "Nicole", "Patricia", "Rachelle", "Samantha", "Teresa", "Vanessa", "Ysabel", "Kristine", "Althea"
    }

    Private ReadOnly MiddleNames As String() = {
        "Santos", "Reyes", "Cruz", "Bautista", "Garcia", "Mendoza", "Dela Cruz", "Ramos",
        "Aquino", "Villanueva", "Castillo", "Flores", "Navarro", "Salazar", "Torres", "Domingo"
    }

    Private ReadOnly LastNames As String() = {
        "Santos", "Reyes", "Cruz", "Bautista", "Garcia", "Mendoza", "Dela Cruz", "Ramos",
        "Aquino", "Villanueva", "Castillo", "Flores", "Navarro", "Salazar", "Torres", "Pascual",
        "Lim", "Tan", "Mercado", "Velasco", "Soriano", "Fernandez", "Lagman", "Ocampo"
    }

    Private ReadOnly EvaluationRemarks As String() = {
        "Outstanding court awareness and composure under pressure.",
        "Strong fundamentals with excellent work rate during drills.",
        "Good athleticism; needs refinement on decision making.",
        "Consistent execution and strong leadership during scrimmage.",
        "Shows promise but requires conditioning and repetition.",
        "Disciplined and coachable; responded well to in-game adjustments."
    }

    ''' <summary>
    ''' True when the database still looks empty enough to auto-populate
    ''' with presentation data on startup.
    ''' </summary>
    Public Function ShouldAutoSeed() As Boolean
        Try
            Dim value As Object = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Registrations")
            If value Is Nothing OrElse IsDBNull(value) Then Return True
            Return Convert.ToInt32(value) < AutoSeedThreshold
        Catch ex As Exception
            Debug.WriteLine("Demo auto-seed check failed: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Seeds demo data at startup only when the database is still empty.
    ''' </summary>
    Public Function SeedForPresentation() As Boolean
        Try
            If ShouldAutoSeed() Then
                SeedDemoData(False)
                Return True
            End If
        Catch ex As Exception
            Debug.WriteLine("Demo auto-seed failed: " & ex.Message)
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Inserts the full demo data set and returns a short summary suitable
    ''' for a message box.
    ''' </summary>
    Public Function SeedDemoData(Optional resetExisting As Boolean = False) As String
        SyncLock GetType(DemoData)
            Using conn As New SQLiteConnection()
                conn.Open()
                Dim tx As MySqlTransaction = conn.InnerConnection.BeginTransaction()
                Try
                    If resetExisting Then
                        DeleteDemoRecords(conn.InnerConnection, tx)
                    End If

                    EnsureUsers(conn.InnerConnection, tx)
                    Dim sports As Dictionary(Of String, Integer) = EnsureSports(conn.InnerConnection, tx)
                    EnsureCoaches(conn.InnerConnection, tx, sports)
                    EnsureSchedules(conn.InnerConnection, tx, sports)
                    SeedStudentsAndResults(conn.InnerConnection, tx, sports)

                    tx.Commit()
                Catch
                    Try
                        tx.Rollback()
                    Catch
                    End Try
                    Throw
                End Try
            End Using

            Return BuildSummary(resetExisting)
        End SyncLock
    End Function

    ' ------------------------------------------------------------------
    '  RESET
    ' ------------------------------------------------------------------

    Private Sub DeleteDemoRecords(conn As MySqlConnection, tx As MySqlTransaction)
        ' Registrations and evaluations cascade from Students.
        Exec(conn, tx,
             "DELETE FROM Students WHERE StudentNumber LIKE @prefix AND Email LIKE @domain",
             New SQLiteParameter("@prefix", DemoStudentPrefix & "%"),
             New SQLiteParameter("@domain", "%" & DemoStudentEmailDomain))
    End Sub

    ' ------------------------------------------------------------------
    '  USERS
    ' ------------------------------------------------------------------

    Private Sub EnsureUsers(conn As MySqlConnection, tx As MySqlTransaction)
        Dim users As New List(Of DemoUser) From {
            New DemoUser("admin", "admin123", "Dr. Ramon M. Villanueva", "Admin",
                         "ramon.villanueva@sts.edu.ph", "0917 500 1001", True),
            New DemoUser("coach", "coach123", "Coach Eduardo S. Reyes", "Coach",
                         "eduardo.reyes@sts.edu.ph", "0917 500 1002", True),
            New DemoUser("staff", "staff123", "Ms. Lorna P. Bautista", "Staff",
                         "lorna.bautista@sts.edu.ph", "0917 500 1003", True),
            New DemoUser("coach.santos", "coach123", "Coach Maria L. Santos", "Coach",
                         "maria.santos@sts.edu.ph", "0917 500 1004", True),
            New DemoUser("coach.salazar", "coach123", "Coach Marco D. Salazar", "Coach",
                         "marco.salazar@sts.edu.ph", "0917 500 1005", True),
            New DemoUser("evaluator.cruz", "coach123", "Prof. Antonio T. Cruz", "Evaluator",
                         "antonio.cruz@sts.edu.ph", "0917 500 1006", True),
            New DemoUser("evaluator.lim", "coach123", "Prof. Beatrice O. Lim", "Evaluator",
                         "beatrice.lim@sts.edu.ph", "0917 500 1007", True),
            New DemoUser("staff.registrar", "staff123", "Mr. Dennis R. Aquino", "Staff",
                         "dennis.aquino@sts.edu.ph", "0917 500 1008", True),
            New DemoUser("admin.ops", "admin123", "Ms. Catherine D. Mercado", "Admin",
                         "catherine.mercado@sts.edu.ph", "0917 500 1009", True),
            New DemoUser("coach.tan", "coach123", "Coach Vincent K. Tan", "Coach",
                         "vincent.tan@sts.edu.ph", "0917 500 1010", False)
        }

        For Each u As DemoUser In users
            Dim avatar As String = BuildAvatar(u.FullName)
            Dim permissionSet As String = Permissions.DefaultsForRole(u.Role)
            Exec(conn, tx,
                 "INSERT INTO Users (Username, PasswordHash, FullName, Role, Email, ContactNumber, ProfilePicture, Permissions, IsActive) " &
                 "VALUES (@u, @p, @f, @r, @e, @c, @pic, @perm, @active) " &
                 "ON DUPLICATE KEY UPDATE FullName=VALUES(FullName), Role=VALUES(Role), Email=VALUES(Email), " &
                 "ContactNumber=VALUES(ContactNumber), Permissions=VALUES(Permissions), IsActive=VALUES(IsActive), " &
                 "ProfilePicture=IF(ProfilePicture IS NULL OR ProfilePicture='', VALUES(ProfilePicture), ProfilePicture)",
                 New SQLiteParameter("@u", u.Username),
                 New SQLiteParameter("@p", SecurityHelper.HashPassword(u.Password)),
                 New SQLiteParameter("@f", u.FullName),
                 New SQLiteParameter("@r", u.Role),
                 New SQLiteParameter("@e", u.Email),
                 New SQLiteParameter("@c", u.ContactNumber),
                 New SQLiteParameter("@pic", avatar),
                 New SQLiteParameter("@perm", permissionSet),
                 New SQLiteParameter("@active", If(u.IsActive, 1, 0)))
        Next
    End Sub

    Private Function BuildAvatar(fullName As String) As String
        Try
            Using img As Image = UIHelper.CreateDefaultAvatar(fullName, 192)
                Return UIHelper.ImageToBase64(img)
            End Using
        Catch
            Return ""
        End Try
    End Function

    ' ------------------------------------------------------------------
    '  SPORTS
    ' ------------------------------------------------------------------

    Private Function EnsureSports(conn As MySqlConnection, tx As MySqlTransaction) As Dictionary(Of String, Integer)
        Dim sports As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
        Dim definitions As New List(Of DemoSport) From {
            New DemoSport("Basketball", "5-on-5 varsity program competing in the inter-collegiate league.", True),
            New DemoSport("Volleyball", "Men's and women's indoor volleyball varsity program.", True),
            New DemoSport("Football", "11-a-side varsity football team with weekly skills sessions.", True),
            New DemoSport("Badminton", "Singles and doubles badminton squad for regional tournaments.", True),
            New DemoSport("Table Tennis", "Table tennis varsity program for individual and team events.", True),
            New DemoSport("Pickle Ball", "Fast-growing racket sport offered as a recreational varsity program.", True),
            New DemoSport("Swimming", "Competitive swimming team covering freestyle, breaststroke, and relays.", True),
            New DemoSport("Track & Field", "Track and field program for sprints, distance, jumps, and throws.", True),
            New DemoSport("Chess", "Mind sports program for strategic team competitions.", True),
            New DemoSport("Dance Sport", "Archived program retained for historical records.", False)
        }

        For Each d As DemoSport In definitions
            Dim existing As Object = Scalar(conn, tx,
                "SELECT SportID FROM Sports WHERE SportName=@n ORDER BY SportID LIMIT 1",
                New SQLiteParameter("@n", d.Name))

            Dim sportId As Integer
            If existing IsNot Nothing AndAlso Not IsDBNull(existing) Then
                sportId = Convert.ToInt32(existing)
                Exec(conn, tx,
                     "UPDATE Sports SET Description=@d, IsActive=@a WHERE SportID=@id",
                     New SQLiteParameter("@d", d.Description),
                     New SQLiteParameter("@a", If(d.IsActive, 1, 0)),
                     New SQLiteParameter("@id", sportId))
            Else
                Exec(conn, tx,
                     "INSERT INTO Sports (SportName, Description, IsActive) VALUES (@n, @d, @a)",
                     New SQLiteParameter("@n", d.Name),
                     New SQLiteParameter("@d", d.Description),
                     New SQLiteParameter("@a", If(d.IsActive, 1, 0)))
                sportId = LastId(conn, tx)
            End If

            sports(d.Name) = sportId
        Next

        Return sports
    End Function

    Private Sub EnsureCoaches(conn As MySqlConnection, tx As MySqlTransaction, sports As Dictionary(Of String, Integer))
        Dim assignments As New List(Of String()) From {
            New String() {"coach", "Basketball"},
            New String() {"coach", "Football"},
            New String() {"coach.santos", "Volleyball"},
            New String() {"coach.santos", "Badminton"},
            New String() {"coach.santos", "Pickle Ball"},
            New String() {"coach.salazar", "Track & Field"},
            New String() {"coach.salazar", "Swimming"},
            New String() {"evaluator.cruz", "Basketball"},
            New String() {"evaluator.cruz", "Volleyball"},
            New String() {"evaluator.cruz", "Football"},
            New String() {"evaluator.cruz", "Track & Field"},
            New String() {"evaluator.lim", "Badminton"},
            New String() {"evaluator.lim", "Table Tennis"},
            New String() {"evaluator.lim", "Pickle Ball"},
            New String() {"evaluator.lim", "Chess"}
        }

        For Each pair As String() In assignments
            Dim userIdObj As Object = Scalar(conn, tx,
                "SELECT UserID FROM Users WHERE Username=@u",
                New SQLiteParameter("@u", pair(0)))
            If userIdObj Is Nothing OrElse IsDBNull(userIdObj) Then Continue For
            If Not sports.ContainsKey(pair(1)) Then Continue For

            Exec(conn, tx,
                 "INSERT INTO SportCoaches (SportID, UserID) " &
                 "SELECT @sid, @uid FROM DUAL " &
                 "WHERE NOT EXISTS (SELECT 1 FROM SportCoaches WHERE SportID=@sid AND UserID=@uid)",
                 New SQLiteParameter("@sid", sports(pair(1))),
                 New SQLiteParameter("@uid", Convert.ToInt32(userIdObj)))
        Next
    End Sub

    ' ------------------------------------------------------------------
    '  SCHEDULES
    ' ------------------------------------------------------------------

    Private Sub EnsureSchedules(conn As MySqlConnection, tx As MySqlTransaction, sports As Dictionary(Of String, Integer))
        Dim today As Date = Date.Today
        Dim plans As New List(Of DemoSchedule) From {
            New DemoSchedule("Basketball", 3, "08:00", "Main Gymnasium", "Upcoming", "Open tryout for all enrolled students."),
            New DemoSchedule("Volleyball", 4, "13:00", "Covered Court A", "Upcoming", "Skills assessment and scrimmage."),
            New DemoSchedule("Football", 6, "07:30", "Athletics Oval", "Upcoming", "Open tryout for all enrolled students."),
            New DemoSchedule("Badminton", 7, "09:00", "Student Center Hall", "Upcoming", "Singles and doubles evaluation."),
            New DemoSchedule("Swimming", 9, "08:00", "Swimming Pool Complex", "Upcoming", "Time trials for all stroke categories."),
            New DemoSchedule("Table Tennis", 10, "13:30", "Student Center Hall", "Upcoming", "Skills assessment and ladder matches."),
            New DemoSchedule("Track & Field", 12, "06:30", "Athletics Oval", "Upcoming", "Sprint, distance, and field event trials."),
            New DemoSchedule("Pickle Ball", 13, "15:00", "Covered Court B", "Upcoming", "Open tryout for beginners and experienced players."),
            New DemoSchedule("Chess", 15, "14:00", "Library Function Room", "Upcoming", "Rapid and blitz qualifying rounds."),
            New DemoSchedule("Basketball", 18, "08:00", "Main Gymnasium", "Upcoming", "Final cut and varsity roster announcement."),
            New DemoSchedule("Basketball", -6, "08:00", "Main Gymnasium", "Completed", "Varsity screening and skills assessment."),
            New DemoSchedule("Volleyball", -9, "13:00", "Covered Court A", "Completed", "Varsity screening and skills assessment."),
            New DemoSchedule("Football", -12, "07:30", "Athletics Oval", "Completed", "First round of tryouts and conditioning test."),
            New DemoSchedule("Badminton", -15, "09:00", "Student Center Hall", "Completed", "Varsity screening and skills assessment."),
            New DemoSchedule("Table Tennis", -18, "13:30", "Student Center Hall", "Completed", "Varsity screening and skills assessment."),
            New DemoSchedule("Swimming", -21, "08:00", "Swimming Pool Complex", "Completed", "Time trials and relay team selection."),
            New DemoSchedule("Track & Field", 8, "06:30", "Athletics Oval", "Cancelled", "Rescheduled due to bad weather."),
            New DemoSchedule("Pickle Ball", -3, "15:00", "Covered Court B", "Cancelled", "Venue became unavailable.")
        }

        For Each p As DemoSchedule In plans
            If Not sports.ContainsKey(p.SportName) Then Continue For
            Dim dateText As String = today.AddDays(p.DayOffset).ToString("yyyy-MM-dd")
            Exec(conn, tx,
                 "INSERT INTO Schedules (SportID, TryoutDate, TryoutTime, Venue, Status, Notes) " &
                 "SELECT @sid, @d, @t, @v, @st, @n FROM DUAL " &
                 "WHERE NOT EXISTS (SELECT 1 FROM Schedules WHERE SportID=@sid AND TryoutDate=@d AND TryoutTime=@t AND Venue=@v)",
                 New SQLiteParameter("@sid", sports(p.SportName)),
                 New SQLiteParameter("@d", dateText),
                 New SQLiteParameter("@t", p.TimeText),
                 New SQLiteParameter("@v", p.Venue),
                 New SQLiteParameter("@st", p.Status),
                 New SQLiteParameter("@n", p.Notes))
        Next
    End Sub

    ' ------------------------------------------------------------------
    '  STUDENTS, REGISTRATIONS & EVALUATIONS
    ' ------------------------------------------------------------------

    Private Sub SeedStudentsAndResults(conn As MySqlConnection, tx As MySqlTransaction, sports As Dictionary(Of String, Integer))
        Dim existingDemo As Object = Scalar(conn, tx,
            "SELECT COUNT(*) FROM Students WHERE StudentNumber LIKE @prefix AND Email LIKE @domain",
            New SQLiteParameter("@prefix", DemoStudentPrefix & "%"),
            New SQLiteParameter("@domain", "%" & DemoStudentEmailDomain))
        If existingDemo IsNot Nothing AndAlso Convert.ToInt32(existingDemo) > 0 Then
            Return
        End If

        Dim activeSportNames As String() = {
            "Basketball", "Volleyball", "Football", "Badminton", "Table Tennis",
            "Pickle Ball", "Swimming", "Track & Field", "Chess"
        }
        Dim availableSports As New List(Of String)()
        For Each name As String In activeSportNames
            If sports.ContainsKey(name) Then availableSports.Add(name)
        Next
        If availableSports.Count = 0 Then Return

        Dim evaluatorIds As List(Of Integer) = GetEvaluatorIds(conn, tx)
        If evaluatorIds.Count = 0 Then
            Dim fallbackId As Integer = SessionManager.CurrentUserID
            If fallbackId <= 0 Then fallbackId = GetUserId(conn, tx, "admin")
            evaluatorIds.Add(fallbackId)
        End If

        Dim today As Date = Date.Today
        Dim registrations As New List(Of DemoRegistration)()

        For i As Integer = 0 To 59
            Dim isMale As Boolean = Rng.Next(2) = 0
            Dim firstName As String = If(isMale,
                                         MaleFirstNames(Rng.Next(MaleFirstNames.Length)),
                                         FemaleFirstNames(Rng.Next(FemaleFirstNames.Length)))
            Dim middleName As String = MiddleNames(Rng.Next(MiddleNames.Length))
            Dim lastName As String = LastNames(Rng.Next(LastNames.Length))
            Dim studentNumber As String = DemoStudentPrefix & (i + 1).ToString("0000")
            Dim course As String = CoursePrograms(i Mod CoursePrograms.Length)
            Dim yearLevel As String = YearLevels(Rng.Next(YearLevels.Length))
            Dim gender As String = If(isMale, "Male", "Female")
            Dim email As String = firstName.ToLowerInvariant() & "." & lastName.Replace(" ", "").ToLowerInvariant() &
                                  (i + 1).ToString("00") & DemoStudentEmailDomain
            Dim contact As String = "0917 " & (1000000 + i * 7919).ToString("000") & " " & (2000 + i * 137).ToString("0000")
            Dim dateRegistered As Date = today.AddDays(-Rng.Next(30, 75)).AddHours(8 + (i Mod 9)).AddMinutes((i * 7) Mod 60)

            Dim studentId As Integer = EnsureStudent(conn, tx, studentNumber, firstName, middleName, lastName,
                                                     course & " - " & yearLevel, gender, contact, email, dateRegistered)

            Dim primaryIndex As Integer = Rng.Next(availableSports.Count)
            Dim primaryRegistration As DemoRegistration = AddRegistration(conn, tx, studentId, sports(availableSports(primaryIndex)), today)
            If primaryRegistration IsNot Nothing Then registrations.Add(primaryRegistration)

            If i Mod 3 <> 0 AndAlso availableSports.Count > 1 Then
                Dim secondaryIndex As Integer = (primaryIndex + 1 + Rng.Next(availableSports.Count - 1)) Mod availableSports.Count
                Dim secondaryRegistration As DemoRegistration = AddRegistration(conn, tx, studentId, sports(availableSports(secondaryIndex)), today)
                If secondaryRegistration IsNot Nothing Then registrations.Add(secondaryRegistration)
            End If
        Next

        For Each reg As DemoRegistration In registrations
            SaveDemoEvaluation(conn, tx, reg, evaluatorIds, today)
        Next
    End Sub

    Private Function EnsureStudent(conn As MySqlConnection, tx As MySqlTransaction,
                                   studentNumber As String, firstName As String, middleName As String,
                                   lastName As String, courseYear As String, gender As String,
                                   contact As String, email As String, dateRegistered As Date) As Integer
        Dim existing As Object = Scalar(conn, tx,
            "SELECT StudentID FROM Students WHERE StudentNumber=@sn",
            New SQLiteParameter("@sn", studentNumber))
        Dim registeredText As String = dateRegistered.ToString("yyyy-MM-dd HH:mm:ss")

        If existing IsNot Nothing AndAlso Not IsDBNull(existing) Then
            Dim studentId As Integer = Convert.ToInt32(existing)
            Exec(conn, tx,
                 "UPDATE Students SET FirstName=@f, MiddleName=@m, LastName=@l, CourseYear=@c, Gender=@g, " &
                 "ContactNumber=@ct, Email=@e, DateRegistered=@dr WHERE StudentID=@id",
                 New SQLiteParameter("@f", firstName),
                 New SQLiteParameter("@m", middleName),
                 New SQLiteParameter("@l", lastName),
                 New SQLiteParameter("@c", courseYear),
                 New SQLiteParameter("@g", gender),
                 New SQLiteParameter("@ct", contact),
                 New SQLiteParameter("@e", email),
                 New SQLiteParameter("@dr", registeredText),
                 New SQLiteParameter("@id", studentId))
            Return studentId
        End If

        Exec(conn, tx,
             "INSERT INTO Students (StudentNumber, FirstName, MiddleName, LastName, CourseYear, Gender, " &
             "ContactNumber, Email, DateRegistered) VALUES (@sn, @f, @m, @l, @c, @g, @ct, @e, @dr)",
             New SQLiteParameter("@sn", studentNumber),
             New SQLiteParameter("@f", firstName),
             New SQLiteParameter("@m", middleName),
             New SQLiteParameter("@l", lastName),
             New SQLiteParameter("@c", courseYear),
             New SQLiteParameter("@g", gender),
             New SQLiteParameter("@ct", contact),
             New SQLiteParameter("@e", email),
             New SQLiteParameter("@dr", registeredText))
        Return LastId(conn, tx)
    End Function

    Private Function AddRegistration(conn As MySqlConnection, tx As MySqlTransaction, studentId As Integer, sportId As Integer, today As Date) As DemoRegistration
        Dim existing As Object = Scalar(conn, tx,
            "SELECT RegistrationID FROM Registrations WHERE StudentID=@sid AND SportID=@spid",
            New SQLiteParameter("@sid", studentId),
            New SQLiteParameter("@spid", sportId))
        If existing IsNot Nothing AndAlso Not IsDBNull(existing) Then Return Nothing

        Dim registrationDate As Date = today.AddDays(-Rng.Next(1, 28)).AddHours(9 + Rng.Next(0, 8)).AddMinutes(Rng.Next(0, 60))

        Exec(conn, tx,
             "INSERT INTO Registrations (StudentID, SportID, RegistrationDate, SelectionStatus) " &
             "VALUES (@sid, @spid, @d, 'Pending')",
             New SQLiteParameter("@sid", studentId),
             New SQLiteParameter("@spid", sportId),
             New SQLiteParameter("@d", registrationDate.ToString("yyyy-MM-dd HH:mm:ss")))
        Return New DemoRegistration(LastId(conn, tx), registrationDate)
    End Function

    Private Sub SaveDemoEvaluation(conn As MySqlConnection, tx As MySqlTransaction, reg As DemoRegistration,
                                   evaluatorIds As List(Of Integer), today As Date)
        ' Roughly 4 out of 5 demo applicants have already been evaluated.
        If Rng.NextDouble() > 0.80 Then Return

        Dim baseline As Integer = 64 + Rng.Next(0, 33)
        Dim skill As Double = ClampScore(baseline + Rng.Next(-8, 9))
        Dim speed As Double = ClampScore(baseline + Rng.Next(-8, 9))
        Dim agility As Double = ClampScore(baseline + Rng.Next(-8, 9))
        Dim endurance As Double = ClampScore(baseline + Rng.Next(-9, 8))
        Dim teamwork As Double = ClampScore(baseline + Rng.Next(-6, 10))
        Dim discipline As Double = ClampScore(baseline + Rng.Next(-5, 11))
        Dim overall As Double = ClampScore(baseline + Rng.Next(-7, 10))
        Dim finalScore As Double = AppLogic.ComputeFinalScore(skill, speed, agility, endurance, teamwork, discipline, overall)

        Dim evaluatorId As Integer = evaluatorIds(Rng.Next(evaluatorIds.Count))
        Dim evaluationDate As Date = reg.RegisteredOn.AddDays(Rng.Next(4, 12))
        If evaluationDate > today Then evaluationDate = today

        Dim remarks As String = EvaluationRemarks(Rng.Next(EvaluationRemarks.Length))

        Exec(conn, tx,
             "INSERT INTO Evaluations (RegistrationID, EvaluatorUserID, SkillScore, SpeedScore, AgilityScore, " &
             "EnduranceScore, TeamworkScore, DisciplineScore, OverallPerformanceScore, FinalScore, Remarks, EvaluationDate) " &
             "VALUES (@id, @ev, @sk, @sp, @ag, @en, @tw, @di, @ov, @fs, @rm, @ed)",
             New SQLiteParameter("@id", reg.RegistrationId),
             New SQLiteParameter("@ev", evaluatorId),
             New SQLiteParameter("@sk", skill),
             New SQLiteParameter("@sp", speed),
             New SQLiteParameter("@ag", agility),
             New SQLiteParameter("@en", endurance),
             New SQLiteParameter("@tw", teamwork),
             New SQLiteParameter("@di", discipline),
             New SQLiteParameter("@ov", overall),
             New SQLiteParameter("@fs", finalScore),
             New SQLiteParameter("@rm", remarks),
             New SQLiteParameter("@ed", evaluationDate.ToString("yyyy-MM-dd HH:mm:ss")))

        ' Most evaluated applicants already have a screening decision.
        If Rng.NextDouble() < 0.16 Then Return

        Dim decision As String
        If finalScore >= 84 Then
            decision = "Selected"
        ElseIf finalScore >= 76 Then
            decision = If(Rng.NextDouble() < 0.72, "Selected", "ForFurtherEvaluation")
        ElseIf finalScore >= 68 Then
            decision = If(Rng.NextDouble() < 0.62, "ForFurtherEvaluation", "NotSelected")
        Else
            decision = "NotSelected"
        End If

        Dim selectionRemarks As String
        Select Case decision
            Case "Selected"
                selectionRemarks = "Qualified for the varsity roster. Recommended for regular training."
            Case "ForFurtherEvaluation"
                selectionRemarks = "Invited for a second round of skills assessment."
            Case Else
                selectionRemarks = "Did not meet the qualifying standard for this tryout cycle."
        End Select

        Dim decisionDate As Date = evaluationDate.AddDays(2)
        If decisionDate > today Then decisionDate = today

        Exec(conn, tx,
             "UPDATE Registrations SET SelectionStatus=@st, SelectionDate=@d, SelectionRemarks=@rm, SelectionBy=@by " &
             "WHERE RegistrationID=@id",
             New SQLiteParameter("@st", decision),
             New SQLiteParameter("@d", decisionDate.ToString("yyyy-MM-dd HH:mm:ss")),
             New SQLiteParameter("@rm", selectionRemarks),
             New SQLiteParameter("@by", AdminName),
             New SQLiteParameter("@id", reg.RegistrationId))
    End Sub

    Private Function ClampScore(value As Integer) As Double
        If value < 40 Then value = 40
        If value > 100 Then value = 100
        Return value
    End Function

    Private Function GetEvaluatorIds(conn As MySqlConnection, tx As MySqlTransaction) As List(Of Integer)
        Dim ids As New List(Of Integer)()
        Using cmd As New MySqlCommand(
            "SELECT UserID FROM Users WHERE Username IN ('coach','coach.santos','coach.salazar','evaluator.cruz','evaluator.lim')", conn, tx)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    ids.Add(Convert.ToInt32(reader.GetValue(0)))
                End While
            End Using
        End Using
        Return ids
    End Function

    Private Function GetUserId(conn As MySqlConnection, tx As MySqlTransaction, username As String) As Integer
        Dim value As Object = Scalar(conn, tx,
            "SELECT UserID FROM Users WHERE Username=@u",
            New SQLiteParameter("@u", username))
        If value Is Nothing OrElse IsDBNull(value) Then Return 0
        Return Convert.ToInt32(value)
    End Function

    ' ------------------------------------------------------------------
    '  SUMMARY
    ' ------------------------------------------------------------------

    Private Function BuildSummary(resetExisting As Boolean) As String
        Dim demoFilterSql As String =
            " FROM Students s WHERE s.StudentNumber LIKE @prefix AND s.Email LIKE @domain"
        Dim parameters As SQLiteParameter() = {
            New SQLiteParameter("@prefix", DemoStudentPrefix & "%"),
            New SQLiteParameter("@domain", "%" & DemoStudentEmailDomain)
        }

        Dim students As Integer = CountRows("SELECT COUNT(*)" & demoFilterSql, parameters)
        Dim registrations As Integer = CountRows(
            "SELECT COUNT(*) FROM Registrations r INNER JOIN Students s ON s.StudentID=r.StudentID " &
            "WHERE s.StudentNumber LIKE @prefix AND s.Email LIKE @domain", parameters)
        Dim evaluations As Integer = CountRows(
            "SELECT COUNT(*) FROM Evaluations e INNER JOIN Registrations r ON r.RegistrationID=e.RegistrationID " &
            "INNER JOIN Students s ON s.StudentID=r.StudentID " &
            "WHERE s.StudentNumber LIKE @prefix AND s.Email LIKE @domain", parameters)
        Dim schedules As Integer = CountRows("SELECT COUNT(*) FROM Schedules", Nothing)
        Dim users As Integer = CountRows("SELECT COUNT(*) FROM Users", Nothing)
        Dim sports As Integer = CountRows("SELECT COUNT(*) FROM Sports", Nothing)

        Dim intro As String = If(resetExisting,
                                 "Demo records were replaced with a fresh presentation data set.",
                                 "Presentation demo data is ready.")

        Return intro & vbCrLf & vbCrLf &
               "Student-athletes: " & students & vbCrLf &
               "Registrations: " & registrations & vbCrLf &
               "Evaluations: " & evaluations & vbCrLf &
               "Schedule sessions: " & schedules & vbCrLf &
               "User accounts: " & users & vbCrLf &
               "Sports: " & sports & vbCrLf & vbCrLf &
               "Sign in with admin / admin123, coach / coach123, or staff / staff123."
    End Function

    Private Function CountRows(sql As String, parameters As SQLiteParameter()) As Integer
        Try
            Dim value As Object = DatabaseHelper.ExecuteScalar(sql, If(parameters, New SQLiteParameter() {}))
            If value Is Nothing OrElse IsDBNull(value) Then Return 0
            Return Convert.ToInt32(value)
        Catch
            Return 0
        End Try
    End Function

    ' ------------------------------------------------------------------
    '  LOW-LEVEL HELPERS
    ' ------------------------------------------------------------------

    Private Sub Exec(conn As MySqlConnection, tx As MySqlTransaction, sql As String, ParamArray values() As SQLiteParameter)
        Using cmd As New MySqlCommand(sql, conn, tx)
            If values IsNot Nothing Then
                For Each p As SQLiteParameter In values
                    cmd.Parameters.AddWithValue(p.ParameterName, If(p.Value, DBNull.Value))
                Next
            End If
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Function Scalar(conn As MySqlConnection, tx As MySqlTransaction, sql As String, ParamArray values() As SQLiteParameter) As Object
        Using cmd As New MySqlCommand(sql, conn, tx)
            If values IsNot Nothing Then
                For Each p As SQLiteParameter In values
                    cmd.Parameters.AddWithValue(p.ParameterName, If(p.Value, DBNull.Value))
                Next
            End If
            Dim result As Object = cmd.ExecuteScalar()
            If result Is DBNull.Value Then Return Nothing
            Return result
        End Using
    End Function

    Private Function LastId(conn As MySqlConnection, tx As MySqlTransaction) As Integer
        Using cmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn, tx)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    ' ------------------------------------------------------------------
    '  SMALL DATA HOLDERS
    ' ------------------------------------------------------------------

    Private Class DemoUser
        Public ReadOnly Username As String
        Public ReadOnly Password As String
        Public ReadOnly FullName As String
        Public ReadOnly Role As String
        Public ReadOnly Email As String
        Public ReadOnly ContactNumber As String
        Public ReadOnly IsActive As Boolean

        Public Sub New(username As String, password As String, fullName As String, role As String,
                       email As String, contactNumber As String, isActive As Boolean)
            Me.Username = username
            Me.Password = password
            Me.FullName = fullName
            Me.Role = role
            Me.Email = email
            Me.ContactNumber = contactNumber
            Me.IsActive = isActive
        End Sub
    End Class

    Private Class DemoSport
        Public ReadOnly Name As String
        Public ReadOnly Description As String
        Public ReadOnly IsActive As Boolean

        Public Sub New(name As String, description As String, isActive As Boolean)
            Me.Name = name
            Me.Description = description
            Me.IsActive = isActive
        End Sub
    End Class

    Private Class DemoSchedule
        Public ReadOnly SportName As String
        Public ReadOnly DayOffset As Integer
        Public ReadOnly TimeText As String
        Public ReadOnly Venue As String
        Public ReadOnly Status As String
        Public ReadOnly Notes As String

        Public Sub New(sportName As String, dayOffset As Integer, timeText As String,
                       venue As String, status As String, notes As String)
            Me.SportName = sportName
            Me.DayOffset = dayOffset
            Me.TimeText = timeText
            Me.Venue = venue
            Me.Status = status
            Me.Notes = notes
        End Sub
    End Class

    Private Class DemoRegistration
        Public ReadOnly RegistrationId As Integer
        Public ReadOnly RegisteredOn As Date

        Public Sub New(registrationId As Integer, registeredOn As Date)
            Me.RegistrationId = registrationId
            Me.RegisteredOn = registeredOn
        End Sub
    End Class

End Module
