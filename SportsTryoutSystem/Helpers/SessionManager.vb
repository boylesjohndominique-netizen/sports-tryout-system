''' <summary>
''' Holds information about the currently logged-in user for the
''' duration of the application session (role-based access control).
''' </summary>
Public Module SessionManager

    Public Property CurrentUserID As Integer = 0
    Public Property CurrentUsername As String = ""
    Public Property CurrentFullName As String = ""
    Public Property CurrentRole As String = ""

    Public Sub SetSession(userId As Integer, username As String, fullName As String, role As String)
        CurrentUserID = userId
        CurrentUsername = username
        CurrentFullName = fullName
        CurrentRole = role
    End Sub

    Public Sub ClearSession()
        CurrentUserID = 0
        CurrentUsername = ""
        CurrentFullName = ""
        CurrentRole = ""
    End Sub

    Public ReadOnly Property IsLoggedIn As Boolean
        Get
            Return CurrentUserID > 0
        End Get
    End Property

    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return CurrentRole = "Admin"
        End Get
    End Property

    Public ReadOnly Property IsCoach As Boolean
        Get
            Return CurrentRole = "Coach"
        End Get
    End Property

    Public ReadOnly Property IsStaff As Boolean
        Get
            Return CurrentRole = "Staff"
        End Get
    End Property

End Module
