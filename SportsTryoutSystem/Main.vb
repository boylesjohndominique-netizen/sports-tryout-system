' =========================================================================
' Sports Tryout Management System
' Entry point. Initializes the local database, then shows the login screen.
' =========================================================================
Module MainModule

    <STAThread()>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Try
            DatabaseHelper.InitializeDatabase()
        Catch ex As Exception
            MessageBox.Show(
                "Failed to initialize the local database." & vbCrLf & vbCrLf & ex.Message,
                "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Application.Run(New frmLogin())
    End Sub

End Module
