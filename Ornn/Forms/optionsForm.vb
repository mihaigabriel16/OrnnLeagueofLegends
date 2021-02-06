Public Class optionsForm
    Dim changesDone As Boolean = False
    Private Sub optionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If changesDone = False Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub
End Class