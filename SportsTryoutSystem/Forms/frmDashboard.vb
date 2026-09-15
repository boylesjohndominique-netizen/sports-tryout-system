Public Class frmDashboard
    Inherits Form

    Public Sub New()
        Me.Text = "Dashboard"
        Me.BackColor = UIHelper.ColorBackground
        BuildUI()
    End Sub

    Private Sub BuildUI()
        Dim header As Panel = UIHelper.MakePanelHeader("Dashboard Overview", Me.Width)
        Me.Controls.Add(header)

        Dim cards As New List(Of Tuple(Of String, String, Color, String)) From {
            Tuple.Create("Total Applicants", GetCount("SELECT COUNT(*) FROM Registrations"), UIHelper.ColorAccent, "👤"),
            Tuple.Create("Active Sports", GetCount("SELECT COUNT(*) FROM Sports WHERE IsActive=1"), UIHelper.ColorSuccess, "🏅"),
            Tuple.Create("Upcoming Tryouts", GetCount("SELECT COUNT(*) FROM Schedules WHERE Status='Upcoming'"), UIHelper.ColorGold, "📅"),
            Tuple.Create("Evaluated", GetCount("SELECT COUNT(*) FROM Evaluations"), UIHelper.ColorPrimary, "⭐"),
            Tuple.Create("Selected Athletes", GetCount("SELECT COUNT(*) FROM Registrations WHERE SelectionStatus='Selected'"), UIHelper.ColorSuccess, "✅"),
            Tuple.Create("Pending Decisions", GetCount("SELECT COUNT(*) FROM Registrations WHERE SelectionStatus='Pending'"), UIHelper.ColorDanger, "⏳")
        }

        Dim x As Integer = 30
        Dim y As Integer = 90
        Dim count As Integer = 0

        For Each item As Tuple(Of String, String, Color, String) In cards
            Dim card As Panel = BuildCard(item.Item1, item.Item2, item.Item3, item.Item4)
            card.Location = New Point(x, y)
            Me.Controls.Add(card)
            count += 1
            If count Mod 3 = 0 Then
                x = 30
                y += 170
            Else
                x += 270
            End If
        Next

        ' Footer hint
        Dim pnlHint As New Panel()
        pnlHint.Location = New Point(30, y + 30)
        pnlHint.Size = New Size(780, 50)
        pnlHint.BackColor = Color.White
        pnlHint.BorderStyle = BorderStyle.None

        Dim lblHintIcon As New Label()
        lblHintIcon.Text = "💡"
        lblHintIcon.Font = New Font("Segoe UI", 14!)
        lblHintIcon.Location = New Point(15, 12)
        lblHintIcon.AutoSize = True
        pnlHint.Controls.Add(lblHintIcon)

        Dim lblHint As New Label()
        lblHint.Text = "Use the navigation menu on the left to manage sports, schedules, registrations, evaluations, and reports."
        lblHint.Font = UIHelper.FontRegular
        lblHint.ForeColor = UIHelper.ColorTextSecondary
        lblHint.Location = New Point(48, 16)
        lblHint.AutoSize = True
        pnlHint.Controls.Add(lblHint)
        Me.Controls.Add(pnlHint)
    End Sub

    Private Function BuildCard(title As String, value As String, accent As Color, icon As String) As Panel
        Dim pnl As New Panel()
        pnl.Size = New Size(240, 140)
        pnl.BackColor = Color.White
        pnl.BorderStyle = BorderStyle.None

        ' Gold left accent bar
        Dim leftBar As New Panel()
        leftBar.Size = New Size(4, 140)
        leftBar.Location = New Point(0, 0)
        leftBar.BackColor = accent

        ' Icon
        Dim lblIcon As New Label()
        lblIcon.Text = icon
        lblIcon.Font = New Font("Segoe UI", 20!)
        lblIcon.Location = New Point(18, 18)
        lblIcon.AutoSize = True

        ' Value
        Dim lblValue As New Label()
        lblValue.Text = value
        lblValue.Font = UIHelper.FontLarge
        lblValue.ForeColor = accent
        lblValue.AutoSize = True
        lblValue.Location = New Point(18, 55)

        ' Title
        Dim lblTitle As New Label()
        lblTitle.Text = title.ToUpper()
        lblTitle.Font = New Font("Segoe UI Semibold", 8!, FontStyle.Bold)
        lblTitle.ForeColor = UIHelper.ColorTextSecondary
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(18, 105)

        pnl.Controls.Add(leftBar)
        pnl.Controls.Add(lblIcon)
        pnl.Controls.Add(lblValue)
        pnl.Controls.Add(lblTitle)
        Return pnl
    End Function

    Private Function GetCount(sql As String) As String
        Try
            Dim result As Object = DatabaseHelper.ExecuteScalar(sql)
            If result Is Nothing OrElse IsDBNull(result) Then Return "0"
            Return result.ToString()
        Catch
            Return "0"
        End Try
    End Function

End Class
