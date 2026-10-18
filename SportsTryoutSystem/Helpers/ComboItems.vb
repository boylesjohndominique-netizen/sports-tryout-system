''' <summary>
''' Wraps a Sport row for use as a ComboBox item, showing the sport
''' name while keeping the underlying SportID available to code.
''' </summary>
Public Class SportItem
    Public Property SportID As Integer
    Public Property SportName As String

    Public Sub New(id As Integer, name As String)
        SportID = id
        SportName = name
    End Sub

    Public Overrides Function ToString() As String
        Return SportName
    End Function
End Class

''' <summary>
''' Wraps a Student row for use as a ComboBox item, showing the student
''' number and full name while keeping the StudentID available to code.
''' </summary>
Public Class StudentItem
    Public Property StudentID As Integer
    Public Property StudentNumber As String
    Public Property FullName As String

    Public Sub New(id As Integer, number As String, name As String)
        StudentID = id
        StudentNumber = number
        FullName = name
    End Sub

    Public Overrides Function ToString() As String
        Return If(String.IsNullOrEmpty(StudentNumber), FullName, StudentNumber & "  —  " & FullName)
    End Function
End Class

''' <summary>
''' Wraps a coach/evaluator User row for use in a CheckedListBox when
''' assigning coaches to a sport.
''' </summary>
Public Class CoachItem
    Public Property UserID As Integer
    Public Property FullName As String

    Public Sub New(id As Integer, name As String)
        UserID = id
        FullName = name
    End Sub

    Public Overrides Function ToString() As String
        Return FullName
    End Function
End Class
