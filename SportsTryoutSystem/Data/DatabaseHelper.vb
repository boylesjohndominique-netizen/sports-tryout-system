Imports System.Configuration
Imports System.Data
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

''' <summary>
''' Centralized MySQL data access helper for the Sports Tryout Management System.
''' Connects to MySQL Database (configured via App.config connectionStrings).
''' </summary>
Public Module DatabaseHelper

    Private ReadOnly _lock As New Object()

    Public ReadOnly Property ConnectionString As String
        Get
            Dim setting = ConfigurationManager.ConnectionStrings("SportsTryoutDB")
            If setting IsNot Nothing AndAlso Not String.IsNullOrEmpty(setting.ConnectionString) Then
                Return setting.ConnectionString
            End If
            ' Fallback default for local development
            Return "Server=localhost;Port=3306;Database=sports_tryout_db;Uid=root;Pwd=boyles2005;ConnectionTimeout=30;"
        End Get
    End Property

    Public Function GetConnection() As SQLiteConnection
        Return New SQLiteConnection(ConnectionString)
    End Function

    ''' <summary>
    ''' Initializes MySQL database connection, sets session compatibility mode,
    ''' creates tables if not present, and seeds initial data.
    ''' </summary>
    Public Sub InitializeDatabase()
        SyncLock _lock
            Try
                Using conn As SQLiteConnection = GetConnection()
                    conn.Open()
                    ConfigureSession(conn.InnerConnection)

                    ' Create tables if they do not exist
                    ExecuteDDL(conn.InnerConnection)

                    ' Seed initial data if Users table is empty
                    Dim userCountObj As Object = ExecuteScalarInternal("SELECT COUNT(*) FROM Users", conn.InnerConnection)
                    Dim userCount As Long = 0
                    If userCountObj IsNot Nothing AndAlso Not IsDBNull(userCountObj) Then
                        userCount = Convert.ToInt64(userCountObj)
                    End If

                    If userCount = 0 Then
                        SeedInitialData(conn.InnerConnection)
                    Else
                        ' Ensure default accounts have the exact SHA-256 hashes
                        UpdateDefaultAccountHash(conn.InnerConnection, "admin", "admin123")
                        UpdateDefaultAccountHash(conn.InnerConnection, "coach", "coach123")
                        UpdateDefaultAccountHash(conn.InnerConnection, "staff", "staff123")
                    End If
                End Using
            Catch ex As Exception
                ' Let exception be logged; in case MySQL is offline, 
                ' the app can still open and report connection failure.
                System.Diagnostics.Debug.WriteLine("Database initialization error: " & ex.Message)
            End Try
        End SyncLock
    End Sub

    Private Sub ConfigureSession(conn As MySqlConnection)
        Try
            Using cmd As New MySqlCommand("SET SESSION sql_mode = 'PIPES_AS_CONCAT,ANSI_QUOTES,NO_ENGINE_SUBSTITUTION';", conn)
                cmd.ExecuteNonQuery()
            End Using
        Catch
            ' Ignore if restricted by MySQL host permissions
        End Try
    End Sub

    Private Function NormalizeSql(sql As String) As String
        If String.IsNullOrEmpty(sql) Then Return sql
        ' Replace [Column Name] with `Column Name` for MySQL identifier compatibility
        Dim normalized As String = Regex.Replace(sql, "\[([^\]]+)\]", "`$1`")
        ' Normalize a || ' ' || b (with or without parentheses) to CONCAT(a, ' ', b)
        normalized = Regex.Replace(normalized, "(?:\()?([a-zA-Z0-9_\.]+)\s*\|\|\s*' '\s*\|\|\s*([a-zA-Z0-9_\.]+)(?:\))?", "CONCAT($1, ' ', $2)", RegexOptions.IgnoreCase)
        ' Normalize generic a || b to CONCAT(a, b)
        normalized = Regex.Replace(normalized, "(?:\()?([a-zA-Z0-9_\.]+)\s*\|\|\s*([a-zA-Z0-9_\.]+)(?:\))?", "CONCAT($1, $2)", RegexOptions.IgnoreCase)
        ' Normalize CAST(... AS TEXT) to CAST(... AS CHAR) for MySQL
        normalized = Regex.Replace(normalized, "\bAS\s+TEXT\b", "AS CHAR", RegexOptions.IgnoreCase)
        Return normalized
    End Function

    Private Sub AttachParameters(cmd As MySqlCommand, params() As SQLiteParameter)
        If params IsNot Nothing Then
            For Each p In params
                If p IsNot Nothing Then
                    Dim pName As String = p.ParameterName
                    If Not pName.StartsWith("@") Then pName = "@" & pName
                    cmd.Parameters.AddWithValue(pName, If(p.Value, DBNull.Value))
                End If
            Next
        End If
    End Sub


    Public Function GetLastInsertId(Optional conn As SQLiteConnection = Nothing) As Long
        Dim myConn As MySqlConnection = If(conn IsNot Nothing, conn.InnerConnection, Nothing)
        If myConn IsNot Nothing Then
            If myConn.State <> ConnectionState.Open Then myConn.Open()
            Using cmd As New MySqlCommand("SELECT LAST_INSERT_ID();", myConn)
                Dim res = cmd.ExecuteScalar()
                If res IsNot Nothing AndAlso Not IsDBNull(res) Then
                    Return Convert.ToInt64(res)
                End If
            End Using
        Else
            Using c As SQLiteConnection = GetConnection()
                c.Open()
                Using cmd As New MySqlCommand("SELECT LAST_INSERT_ID();", c.InnerConnection)
                    Dim res = cmd.ExecuteScalar()
                    If res IsNot Nothing AndAlso Not IsDBNull(res) Then
                        Return Convert.ToInt64(res)
                    End If
                End Using
            End Using
        End If
        Return 0
    End Function

    ' ------------------------------------------------------------------
    ' ExecuteNonQuery Overloads
    ' ------------------------------------------------------------------

    Public Function ExecuteNonQuery(sql As String, ParamArray params() As SQLiteParameter) As Integer
        Using conn As SQLiteConnection = GetConnection()
            conn.Open()
            ConfigureSession(conn.InnerConnection)
            Using cmd As New MySqlCommand(NormalizeSql(sql), conn.InnerConnection)
                AttachParameters(cmd, params)
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Function ExecuteNonQuery(sql As String, conn As SQLiteConnection, ParamArray params() As SQLiteParameter) As Integer
        If conn Is Nothing Then Throw New ArgumentNullException(NameOf(conn))
        conn.Open()
        ConfigureSession(conn.InnerConnection)
        Using cmd As New MySqlCommand(NormalizeSql(sql), conn.InnerConnection)
            AttachParameters(cmd, params)
            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    ' ------------------------------------------------------------------
    ' ExecuteScalar Overloads
    ' ------------------------------------------------------------------

    Public Function ExecuteScalar(sql As String, ParamArray params() As SQLiteParameter) As Object
        Using conn As SQLiteConnection = GetConnection()
            conn.Open()
            ConfigureSession(conn.InnerConnection)
            Using cmd As New MySqlCommand(NormalizeSql(sql), conn.InnerConnection)
                AttachParameters(cmd, params)
                Dim res = cmd.ExecuteScalar()
                If IsDBNull(res) Then Return Nothing
                Return res
            End Using
        End Using
    End Function

    Private Function ExecuteScalarInternal(sql As String, conn As MySqlConnection) As Object
        Using cmd As New MySqlCommand(NormalizeSql(sql), conn)
            Dim res = cmd.ExecuteScalar()
            If IsDBNull(res) Then Return Nothing
            Return res
        End Using
    End Function

    ' ------------------------------------------------------------------
    ' GetDataTable Overloads
    ' ------------------------------------------------------------------

    Public Function GetDataTable(sql As String, ParamArray params() As SQLiteParameter) As DataTable
        Dim dt As New DataTable()
        Using conn As SQLiteConnection = GetConnection()
            conn.Open()
            ConfigureSession(conn.InnerConnection)
            Using cmd As New MySqlCommand(NormalizeSql(sql), conn.InnerConnection)
                AttachParameters(cmd, params)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' ------------------------------------------------------------------
    ' Schema Setup & Seeding
    ' ------------------------------------------------------------------

    Private Sub ExecuteDDL(conn As MySqlConnection)
        Dim list As New List(Of String)()

        list.Add("CREATE TABLE IF NOT EXISTS Users (" &
                 "UserID INT AUTO_INCREMENT PRIMARY KEY, " &
                 "Username VARCHAR(50) NOT NULL UNIQUE, " &
                 "PasswordHash VARCHAR(255) NOT NULL, " &
                 "FullName VARCHAR(100) NOT NULL, " &
                 "Role VARCHAR(20) NOT NULL, " &
                 "Email VARCHAR(100) NULL, " &
                 "ContactNumber VARCHAR(50) NULL, " &
                 "ProfilePicture LONGTEXT NULL, " &
                 "Permissions VARCHAR(500) NULL, " &
                 "IsActive TINYINT(1) NOT NULL DEFAULT 1, " &
                 "DateCreated DATETIME DEFAULT CURRENT_TIMESTAMP) ENGINE=InnoDB;")

        list.Add("CREATE TABLE IF NOT EXISTS Sports (" &
                 "SportID INT AUTO_INCREMENT PRIMARY KEY, " &
                 "SportName VARCHAR(100) NOT NULL, " &
                 "Description TEXT, " &
                 "IsActive TINYINT(1) NOT NULL DEFAULT 1) ENGINE=InnoDB;")

        list.Add("CREATE TABLE IF NOT EXISTS SportCoaches (" &
                 "SportCoachID INT AUTO_INCREMENT PRIMARY KEY, " &
                 "SportID INT NOT NULL, " &
                 "UserID INT NOT NULL, " &
                 "CONSTRAINT fk_sc_sport FOREIGN KEY (SportID) REFERENCES Sports(SportID) ON DELETE CASCADE, " &
                 "CONSTRAINT fk_sc_user FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE) ENGINE=InnoDB;")

        list.Add("CREATE TABLE IF NOT EXISTS Students (" &
                 "StudentID INT AUTO_INCREMENT PRIMARY KEY, " &
                 "StudentNumber VARCHAR(50) NOT NULL UNIQUE, " &
                 "FirstName VARCHAR(100) NOT NULL, " &
                 "MiddleName VARCHAR(100) NULL, " &
                 "LastName VARCHAR(100) NOT NULL, " &
                 "CourseYear VARCHAR(50), " &
                 "Gender VARCHAR(20), " &
                 "ContactNumber VARCHAR(50), " &
                 "Email VARCHAR(100), " &
                 "DateRegistered DATETIME DEFAULT CURRENT_TIMESTAMP) ENGINE=InnoDB;")

        list.Add("CREATE TABLE IF NOT EXISTS Registrations (" &
                 "RegistrationID INT AUTO_INCREMENT PRIMARY KEY, " &
                 "StudentID INT NOT NULL, " &
                 "SportID INT NOT NULL, " &
                 "RegistrationDate DATETIME DEFAULT CURRENT_TIMESTAMP, " &
                 "SelectionStatus VARCHAR(50) NOT NULL DEFAULT 'Pending', " &
                 "SelectionDate DATETIME NULL, " &
                 "SelectionRemarks TEXT, " &
                 "SelectionBy VARCHAR(100) NULL, " &
                 "CONSTRAINT fk_reg_student FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE, " &
                 "CONSTRAINT fk_reg_sport FOREIGN KEY (SportID) REFERENCES Sports(SportID) ON DELETE CASCADE, " &
                 "CONSTRAINT uq_student_sport UNIQUE (StudentID, SportID)) ENGINE=InnoDB;")

        list.Add("CREATE TABLE IF NOT EXISTS Schedules (" &
                 "ScheduleID INT AUTO_INCREMENT PRIMARY KEY, " &
                 "SportID INT NOT NULL, " &
                 "TryoutDate VARCHAR(50) NOT NULL, " &
                 "TryoutTime VARCHAR(50) NOT NULL, " &
                 "Venue VARCHAR(100) NOT NULL, " &
                 "Status VARCHAR(50) NOT NULL DEFAULT 'Upcoming', " &
                 "Notes TEXT, " &
                 "CONSTRAINT fk_sched_sport FOREIGN KEY (SportID) REFERENCES Sports(SportID) ON DELETE CASCADE) ENGINE=InnoDB;")

        list.Add("CREATE TABLE IF NOT EXISTS Evaluations (" &
                 "EvaluationID INT AUTO_INCREMENT PRIMARY KEY, " &
                 "RegistrationID INT NOT NULL, " &
                 "EvaluatorUserID INT NOT NULL, " &
                 "SkillScore DECIMAL(5,2) NOT NULL DEFAULT 0.00, " &
                 "SpeedScore DECIMAL(5,2) NOT NULL DEFAULT 0.00, " &
                 "AgilityScore DECIMAL(5,2) NOT NULL DEFAULT 0.00, " &
                 "EnduranceScore DECIMAL(5,2) NOT NULL DEFAULT 0.00, " &
                 "TeamworkScore DECIMAL(5,2) NOT NULL DEFAULT 0.00, " &
                 "DisciplineScore DECIMAL(5,2) NOT NULL DEFAULT 0.00, " &
                 "OverallPerformanceScore DECIMAL(5,2) NOT NULL DEFAULT 0.00, " &
                 "FinalScore DECIMAL(5,2) NOT NULL DEFAULT 0.00, " &
                 "Remarks TEXT, " &
                 "EvaluationDate DATETIME DEFAULT CURRENT_TIMESTAMP, " &
                 "CONSTRAINT fk_eval_reg FOREIGN KEY (RegistrationID) REFERENCES Registrations(RegistrationID) ON DELETE CASCADE, " &
                 "CONSTRAINT fk_eval_user FOREIGN KEY (EvaluatorUserID) REFERENCES Users(UserID)) ENGINE=InnoDB;")

        For Each ddl In list
            Using cmd As New MySqlCommand(ddl, conn)
                cmd.ExecuteNonQuery()
            End Using
        Next

        ' Run migration for existing databases to add MiddleName if missing
        Try
            Using cmdCol As New MySqlCommand("ALTER TABLE Students ADD COLUMN MiddleName VARCHAR(100) NULL AFTER FirstName;", conn)
                cmdCol.ExecuteNonQuery()
            End Using
        Catch
            ' Ignore if column already exists
        End Try

        ' Run migration for existing databases to add Permissions if missing
        Try
            Using cmdCol As New MySqlCommand("ALTER TABLE Users ADD COLUMN Permissions VARCHAR(500) NULL;", conn)
                cmdCol.ExecuteNonQuery()
            End Using
        Catch
            ' Ignore if column already exists
        End Try

        ' Run migration for ProfilePicture, Email, and ContactNumber if missing
        Try
            Using cmdCol As New MySqlCommand("ALTER TABLE Users ADD COLUMN ProfilePicture LONGTEXT NULL;", conn)
                cmdCol.ExecuteNonQuery()
            End Using
        Catch
        End Try

        Try
            Using cmdCol As New MySqlCommand("ALTER TABLE Users ADD COLUMN Email VARCHAR(100) NULL;", conn)
                cmdCol.ExecuteNonQuery()
            End Using
        Catch
        End Try

        Try
            Using cmdCol As New MySqlCommand("ALTER TABLE Users ADD COLUMN ContactNumber VARCHAR(50) NULL;", conn)
                cmdCol.ExecuteNonQuery()
            End Using
        Catch
        End Try
    End Sub

    Public Sub EnsureStudentsMiddleNameColumn()
        Try
            Using conn = GetConnection()
                conn.Open()
                Using cmdCol As New MySqlCommand("ALTER TABLE Students ADD COLUMN MiddleName VARCHAR(100) NULL AFTER FirstName;", conn.InnerConnection)
                    cmdCol.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' Ignore if column already exists or MySQL connection offline
        End Try
    End Sub

    Private Sub SeedInitialData(conn As MySqlConnection)
        ' Seed default accounts
        Dim seedUsersSql As String =
            "INSERT INTO Users (Username, PasswordHash, FullName, Role, Permissions, IsActive) VALUES " &
            "(@u1, @p1, @f1, @r1, @perm1, 1), " &
            "(@u2, @p2, @f2, @r2, @perm2, 1), " &
            "(@u3, @p3, @f3, @r3, @perm3, 1) " &
            "ON DUPLICATE KEY UPDATE Username=Username;"

        Using cmd As New MySqlCommand(seedUsersSql, conn)
            cmd.Parameters.AddWithValue("@u1", "admin")
            cmd.Parameters.AddWithValue("@p1", SecurityHelper.HashPassword("admin123"))
            cmd.Parameters.AddWithValue("@f1", "System Administrator")
            cmd.Parameters.AddWithValue("@r1", "Admin")
            cmd.Parameters.AddWithValue("@perm1", Permissions.DefaultsForRole("Admin"))

            cmd.Parameters.AddWithValue("@u2", "coach")
            cmd.Parameters.AddWithValue("@p2", SecurityHelper.HashPassword("coach123"))
            cmd.Parameters.AddWithValue("@f2", "Sample Coach")
            cmd.Parameters.AddWithValue("@r2", "Coach")
            cmd.Parameters.AddWithValue("@perm2", Permissions.DefaultsForRole("Coach"))

            cmd.Parameters.AddWithValue("@u3", "staff")
            cmd.Parameters.AddWithValue("@p3", SecurityHelper.HashPassword("staff123"))
            cmd.Parameters.AddWithValue("@f3", "Sample Registrar")
            cmd.Parameters.AddWithValue("@r3", "Staff")
            cmd.Parameters.AddWithValue("@perm3", Permissions.DefaultsForRole("Staff"))

            cmd.ExecuteNonQuery()
        End Using

        ' Starter sports
        Dim sports As String() = {"Basketball", "Volleyball", "Football", "Badminton", "Table Tennis"}
        For Each sp In sports
            Dim insertSportSql As String = "INSERT INTO Sports (SportName, Description, IsActive) VALUES (@n, '', 1) ON DUPLICATE KEY UPDATE SportName=SportName;"
            Using cmd As New MySqlCommand(insertSportSql, conn)
                cmd.Parameters.AddWithValue("@n", sp)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub UpdateDefaultAccountHash(conn As MySqlConnection, username As String, defaultPassword As String)
        Try
            Dim correctHash As String = SecurityHelper.HashPassword(defaultPassword)
            ' Check current hash for the user
            Using cmdCheck As New MySqlCommand("SELECT PasswordHash FROM Users WHERE Username=@u", conn)
                cmdCheck.Parameters.AddWithValue("@u", username)
                Dim curHashObj As Object = cmdCheck.ExecuteScalar()
                If curHashObj IsNot Nothing AndAlso Not IsDBNull(curHashObj) Then
                    Dim curHash As String = curHashObj.ToString()
                    ' If the stored hash is invalid or is the old sample script hash, update it
                    If curHash.Length <> 64 OrElse Not SecurityHelper.VerifyPassword(defaultPassword, curHash) Then
                        ' Only update if it wasn't intentionally changed to something else valid
                        If curHash.StartsWith("240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa82280f1a8230e8d") OrElse
                           curHash.StartsWith("3f40f0c0556b6b7a2d83769c0d35969eb2796ac6c507cfa3748be74955b23d90") OrElse
                           curHash.StartsWith("c2b535804369408fc0f8ecfa832c3f873ea4bf690e0e0fa70b67ffcc85ec157a") OrElse
                           curHash = defaultPassword Then
                            Using cmdUpd As New MySqlCommand("UPDATE Users SET PasswordHash=@p WHERE Username=@u", conn)
                                cmdUpd.Parameters.AddWithValue("@p", correctHash)
                                cmdUpd.Parameters.AddWithValue("@u", username)
                                cmdUpd.ExecuteNonQuery()
                            End Using
                        End If
                    End If
                End If
            End Using
        Catch
            ' Best-effort update
        End Try
    End Sub

End Module

' ------------------------------------------------------------------
' Compatibility type adapters so existing forms compile seamlessly
' ------------------------------------------------------------------

Public Class SQLiteParameter
    Public Property ParameterName As String
    Public Property Value As Object

    Public Sub New()
    End Sub

    Public Sub New(name As String, value As Object)
        Me.ParameterName = If(name.StartsWith("@"), name, "@" & name)
        Me.Value = If(value, DBNull.Value)
    End Sub
End Class

Public Class DataParameter
    Inherits SQLiteParameter

    Public Sub New(name As String, value As Object)
        MyBase.New(name, value)
    End Sub
End Class

Public Class SQLiteConnection
    Implements IDisposable

    Public Property InnerConnection As MySqlConnection

    Public Sub New()
        InnerConnection = New MySqlConnection(DatabaseHelper.ConnectionString)
    End Sub

    Public Sub New(connString As String)
        InnerConnection = New MySqlConnection(connString)
    End Sub

    Public ReadOnly Property State As ConnectionState
        Get
            Return If(InnerConnection IsNot Nothing, InnerConnection.State, ConnectionState.Closed)
        End Get
    End Property

    Public Sub Open()
        If InnerConnection IsNot Nothing AndAlso InnerConnection.State <> ConnectionState.Open Then
            InnerConnection.Open()
        End If
    End Sub

    Public Sub Close()
        If InnerConnection IsNot Nothing AndAlso InnerConnection.State <> ConnectionState.Closed Then
            InnerConnection.Close()
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If InnerConnection IsNot Nothing Then
            InnerConnection.Dispose()
            InnerConnection = Nothing
        End If
    End Sub
End Class
