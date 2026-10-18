''' <summary>
''' Holds information about the currently logged-in user for the
''' duration of the application session (role-based access control).
''' </summary>
Public Module SessionManager

    Public Property CurrentUserID As Integer = 0
    Public Property CurrentUsername As String = ""
    Public Property CurrentFullName As String = ""
    Public Property CurrentRole As String = ""

    Private _permissions As HashSet(Of String) = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

    Public Sub SetSession(userId As Integer, username As String, fullName As String, role As String, Optional permissionKeys As String = Nothing)
        CurrentUserID = userId
        CurrentUsername = username
        CurrentFullName = fullName
        CurrentRole = role
        Dim raw As String = permissionKeys
        If String.IsNullOrWhiteSpace(raw) Then raw = Permissions.DefaultsForRole(role)
        _permissions = Permissions.Parse(raw)
    End Sub

    Public Sub ClearSession()
        CurrentUserID = 0
        CurrentUsername = ""
        CurrentFullName = ""
        CurrentRole = ""
        _permissions = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
    End Sub

    ''' <summary>
    ''' True when the logged-in user may perform the given permission key.
    ''' Admin always passes; every other account uses its assigned permissions.
    ''' </summary>
    Public ReadOnly Property HasPermission(key As String) As Boolean
        Get
            If IsAdmin Then Return True
            If String.IsNullOrEmpty(key) Then Return False
            Return _permissions.Contains(key)
        End Get
    End Property

    Public ReadOnly Property CurrentPermissions As String
        Get
            If IsAdmin Then Return Permissions.AllKeys()
            Return String.Join(",", _permissions)
        End Get
    End Property

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

    Public ReadOnly Property IsEvaluator As Boolean
        Get
            Return CurrentRole = "Evaluator"
        End Get
    End Property

End Module
