Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

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

        Dim HeroManager = ReadMemory.ReadMemoryP(Globals.OHeroList)
        Dim allChampions As List(Of Integer) = ReadVTable(HeroManager)
        For Each champ In allChampions
            ListBox1.Items.Add(ReadMemory.ReadMemoryP(champ + Globals.ObjName))
        Next
    End Sub

    Private Function ReadVTable(ByVal addr) As List(Of Integer)
        Dim lst = ReadMemory.ReadMemoryP(addr + &H4)
        Dim size = ReadMemory.ReadMemoryP(addr + &H8)
        Dim i = 0
        While i <= size
            Return ReadMemory.ReadMemoryP(lst + (i * &H4))
        End While

    End Function

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

    Private Sub overlayOne_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated


    End Sub
End Class

Module ReadMemory
    <DllImport("kernel32.dll", SetLastError:=True)> Private Function ReadProcessMemory _
(ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByRef lpBuffer As Byte,
 ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    End Function


    Public Function ReadMemoryP(ByVal address As Integer)
        Try

            Dim process0 As String = "League of Legends" 'process0 is the name of pocess

            'Dim prox As Process() = Process.GetProcessesByName(process0)
            Dim proc As Process = Process.GetProcessById(19156)
            Dim data As String = GetTextinMemory(proc.Handle, address, 16) & GetTextinMemory(proc.Handle, address + 32, 16)
            Return data
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private Function GetTextinMemory(ByVal ProcessHandle As IntPtr, ByVal MemoryAddress As IntPtr, ByVal CharsToRead As Integer, Optional ByVal IsUnicode As Boolean = True) As String
        Dim ReturnValue As String = vbNullString
        Dim StringBuffer() As Byte
        If IsUnicode Then
            ReDim StringBuffer(CharsToRead * 2 - 1)
        Else
            ReDim StringBuffer(CharsToRead - 1)
        End If
        Try
            'Dim p As Process() = Process.GetProcessesByName(process0)
            If ReadProcessMemory(ProcessHandle, MemoryAddress, StringBuffer(0), StringBuffer.Length, Nothing) Then
                If IsUnicode Then
                    ReturnValue = System.Text.Encoding.ASCII.GetString(StringBuffer)
                Else
                    ReturnValue = System.Text.Encoding.Default.GetString(StringBuffer)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return ReturnValue
    End Function
End Module