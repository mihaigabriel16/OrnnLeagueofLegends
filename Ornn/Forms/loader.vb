Imports System.ComponentModel

Public Class Loader
    Private bw As New BackgroundWorker()

    Private Sub Loader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.RunWorkerCompleted, AddressOf bw_Complete
        bw.RunWorkerAsync()
    End Sub

    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs)
        Try

            Theme.LoadTheme()
        Catch ex As Exception
            MsgBox("Classes malfunctioned.")
        End Try
    End Sub

    Private Sub bw_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        mainApp.Show()
        Lang.LoadLanguage("en", mainApp)
        Me.Hide()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class