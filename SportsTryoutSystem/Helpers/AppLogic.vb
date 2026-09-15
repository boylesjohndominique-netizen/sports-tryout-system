''' <summary>
''' Shared business rules for the tryout pipeline: scoring, qualification
''' threshold, human-readable status text, and CSV export for reports.
''' </summary>
Public Module AppLogic

    ''' <summary>
    ''' Minimum final evaluation score (0-100) for an applicant to be
    ''' considered "qualified" during screening. Adjust as needed.
    ''' </summary>
    Public Const PassingScore As Double = 75.0

    Public Function ComputeFinalScore(skill As Double, speed As Double, agility As Double, endurance As Double,
                                       teamwork As Double, discipline As Double, overallPerformance As Double) As Double
        Return Math.Round((skill + speed + agility + endurance + teamwork + discipline + overallPerformance) / 7.0, 2)
    End Function

    ''' <summary>
    ''' Builds a human-readable pipeline status for a registration by
    ''' checking whether it has been scheduled, evaluated, and decided.
    ''' </summary>
    Public Function GetRegistrationStatusText(registrationId As Integer) As String
        Dim regTable As DataTable = DatabaseHelper.GetDataTable(
            "SELECT SelectionStatus, SportID FROM Registrations WHERE RegistrationID=@id",
            New SQLiteParameter("@id", registrationId))

        If regTable.Rows.Count = 0 Then Return "Unknown"

        Dim selectionStatus As String = regTable.Rows(0)("SelectionStatus").ToString()

        If selectionStatus <> "Pending" Then
            Return DisplaySelectionStatus(selectionStatus)
        End If

        Dim evalTable As DataTable = DatabaseHelper.GetDataTable(
            "SELECT FinalScore FROM Evaluations WHERE RegistrationID=@id",
            New SQLiteParameter("@id", registrationId))

        If evalTable.Rows.Count > 0 Then
            Return "Evaluated - Awaiting Decision (Score: " & evalTable.Rows(0)("FinalScore").ToString() & ")"
        End If

        Dim sportId As Integer = CInt(regTable.Rows(0)("SportID"))

        Dim schedTable As DataTable = DatabaseHelper.GetDataTable(
            "SELECT TryoutDate, TryoutTime FROM Schedules WHERE SportID=@sid AND Status='Upcoming' ORDER BY TryoutDate LIMIT 1",
            New SQLiteParameter("@sid", sportId))

        If schedTable.Rows.Count > 0 Then
            Return "Scheduled for Tryout on " & schedTable.Rows(0)("TryoutDate").ToString() & " " & schedTable.Rows(0)("TryoutTime").ToString()
        End If

        Return "Registered - Awaiting Schedule"
    End Function

    Public Function DisplaySelectionStatus(code As String) As String
        Select Case code
            Case "Selected"
                Return "Selected"
            Case "NotSelected"
                Return "Not Selected"
            Case "ForFurtherEvaluation"
                Return "For Further Evaluation"
            Case "Pending"
                Return "Pending"
            Case Else
                Return code
        End Select
    End Function

    Public Function ExportDataTableToCsv(dt As DataTable, filePath As String) As Boolean
        Try
            Using writer As New System.IO.StreamWriter(filePath, False, System.Text.Encoding.UTF8)
                Dim headers As New List(Of String)
                For Each col As DataColumn In dt.Columns
                    headers.Add(EscapeCsv(col.ColumnName))
                Next
                writer.WriteLine(String.Join(",", headers.ToArray()))

                For Each row As DataRow In dt.Rows
                    Dim fields As New List(Of String)
                    For Each col As DataColumn In dt.Columns
                        fields.Add(EscapeCsv(row(col).ToString()))
                    Next
                    writer.WriteLine(String.Join(",", fields.ToArray()))
                Next
            End Using
            Return True
        Catch ex As Exception
            UIHelper.ShowError("Failed to export CSV: " & ex.Message)
            Return False
        End Try
    End Function

    Private Function EscapeCsv(value As String) As String
        If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbCrLf) OrElse value.Contains(vbLf) Then
            Return """" & value.Replace("""", """""") & """"
        End If
        Return value
    End Function

End Module
