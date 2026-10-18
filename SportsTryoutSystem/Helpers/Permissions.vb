''' <summary>
''' Central catalog of system permissions plus the default permission
''' sets assigned to each user role. Permission keys are stored on the
''' Users table as a comma-separated string.
''' </summary>
Public Module Permissions

    Public Class PermissionItem
        Public Property Key As String
        Public Property Label As String

        Public Sub New(key As String, label As String)
            Me.Key = key
            Me.Label = label
        End Sub

        Public Overrides Function ToString() As String
            Return Label
        End Function
    End Class

    Public Const ManageUsers As String = "manage_users"
    Public Const ManageSports As String = "manage_sports"
    Public Const ManageSchedules As String = "manage_schedules"
    Public Const ManageRegistration As String = "manage_registration"
    Public Const ViewApplicants As String = "view_applicants"
    Public Const Evaluate As String = "evaluate"
    Public Const ViewReports As String = "view_reports"

    Public ReadOnly Catalog As PermissionItem() = {
        New PermissionItem(ManageUsers, "Manage user accounts"),
        New PermissionItem(ManageSports, "Manage sports"),
        New PermissionItem(ManageSchedules, "Manage tryout schedules"),
        New PermissionItem(ManageRegistration, "Register applicants"),
        New PermissionItem(ViewApplicants, "View applicant records"),
        New PermissionItem(Evaluate, "Evaluate & select athletes"),
        New PermissionItem(ViewReports, "View & export reports")
    }

    ''' <summary>Default permission set for a role (comma-separated keys).</summary>
    Public Function DefaultsForRole(role As String) As String
        Select Case If(role, "").Trim().ToLowerInvariant()
            Case "admin"
                Return AllKeys()
            Case "coach", "evaluator"
                Return String.Join(",", {Evaluate, ViewApplicants, ViewReports})
            Case "staff"
                Return String.Join(",", {ManageSchedules, ManageRegistration, ViewApplicants, ViewReports})
            Case Else
                Return ""
        End Select
    End Function

    Public Function AllKeys() As String
        Return String.Join(",", Catalog.Select(Function(o) o.Key))
    End Function

    Public Function Parse(keys As String) As HashSet(Of String)
        Dim parsed As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        If Not String.IsNullOrWhiteSpace(keys) Then
            For Each part In keys.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
                parsed.Add(part.Trim())
            Next
        End If
        Return parsed
    End Function

    ''' <summary>Human-readable summary of a comma-separated permission string.</summary>
    Public Function Describe(keys As String) As String
        Dim parsed As HashSet(Of String) = Parse(keys)
        Dim labels As New List(Of String)
        For Each opt In Catalog
            If parsed.Contains(opt.Key) Then labels.Add(opt.Label)
        Next
        Return If(labels.Count = 0, "None", String.Join(", ", labels))
    End Function

End Module
