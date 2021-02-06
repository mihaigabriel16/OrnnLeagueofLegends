Public Class Theme
    Shared test As Boolean = True
    Public Shared Sub LoadTheme()
        If test = False Then
            mainApp.FormBorderStyle = FormBorderStyle.None
        End If
    End Sub

End Class
