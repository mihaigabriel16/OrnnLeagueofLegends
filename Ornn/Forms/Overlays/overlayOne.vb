Imports System.IO
Imports System.Runtime.InteropServices
Public Class overlayOne
    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer

    Private makel As String
    Private InitialStyle As Integer
    Dim PercentVisible As Decimal
    Public path As String

    Dim winposx As Integer
    Dim winposy As Integer
    Dim textpath As String

    Private Sub overlayOne_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(winposx, winposy)
        InitialStyle = GetWindowLong(Me.Handle, -20)
        PercentVisible = 0.1

        SetWindowLong(Me.Handle, -20, InitialStyle Or &H80000 Or &H20)

        Me.TopMost = True
    End Sub

    Private Function GetCaption() As String
        Dim Caption As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindowLong")> Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetWindowLong")> Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetLayeredWindowAttributes")> Public Shared Function SetLayeredWindowAttributes(ByVal hWnd As IntPtr, ByVal crKey As Integer, ByVal alpha As Byte, ByVal dwFlags As Integer) As Boolean
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Location = New Point(winposx, winposy)

        Dim CapTxt As String = GetCaption()
        Dim Path As String = textpath
        Dim debugMode As Boolean = False

        If CapTxt = "League of Legends (TM) Client" Or debugMode = True Then
            ' League of Legends (TM) Client

            Me.TopMost = True
            Me.Show()
            Me.BringToFront()

            If debugMode = True Then
                Me.TransparencyKey = Color.Transparent
            ElseIf debugMode = False Then
                Me.TransparencyKey = Color.Black
            End If


            Try

            Catch ex As Exception

            End Try

        Else
            Me.TopMost = False
            Me.Hide()
        End If
    End Sub
End Class