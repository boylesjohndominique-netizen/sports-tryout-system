' =========================================================================
' Sports Tryout Management System
' Entry point. Initializes the local database, then shows the login screen.
' =========================================================================
Module MainModule

    <STAThread()>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        ' Global unhandled exception handlers to display full diagnostics
        AddHandler Application.ThreadException, Sub(sender, args)
                                                     Dim msg As String = If(args.Exception IsNot Nothing, args.Exception.ToString(), "Unknown thread error")
                                                     MessageBox.Show(msg, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                 End Sub

        AddHandler AppDomain.CurrentDomain.UnhandledException, Sub(sender, args)
                                                                    Dim ex As Exception = TryCast(args.ExceptionObject, Exception)
                                                                    Dim msg As String = If(ex IsNot Nothing, ex.ToString(), "Unknown critical error")
                                                                    MessageBox.Show(msg, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                End Sub

        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)

        Try
            DatabaseHelper.InitializeDatabase()
        Catch ex As Exception
            MessageBox.Show(
                "Failed to initialize the local database." & vbCrLf & vbCrLf & ex.Message,
                "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Application Lifecycle: Login modal -> Run modeless MDI frmMain
        While True
            Dim loginSuccess As Boolean = False
            Using login As New frmLogin()
                Dim dr As DialogResult = login.ShowDialog()
                If dr = DialogResult.OK Then
                    loginSuccess = True
                End If
            End Using

            If Not loginSuccess Then
                Exit While
            End If

            ' Run frmMain as the true, modeless Application main form
            Dim main As New frmMain()
            Application.Run(main)

            Dim wasLogout As Boolean = main.LoggedOut
            SessionManager.ClearSession()

            If Not wasLogout Then
                Exit While
            End If
        End While
    End Sub

End Module
