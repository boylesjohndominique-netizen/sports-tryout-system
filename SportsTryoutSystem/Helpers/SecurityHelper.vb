Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Basic password hashing so plain-text passwords are never stored
''' in the local database.
''' </summary>
Public Module SecurityHelper

    Public Function HashPassword(plainText As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha.ComputeHash(Encoding.UTF8.GetBytes(plainText))
            Dim sb As New StringBuilder()
            For Each b As Byte In bytes
                sb.Append(b.ToString("x2"))
            Next
            Return sb.ToString()
        End Using
    End Function

    Public Function VerifyPassword(plainText As String, storedHash As String) As Boolean
        Return String.Equals(HashPassword(plainText), storedHash, StringComparison.OrdinalIgnoreCase)
    End Function

End Module
