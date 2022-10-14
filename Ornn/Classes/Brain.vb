Imports System.Net

Public Class Brain
    Public Function CheckForProcess(name As String)
        Dim found As Boolean
        Dim pName As String = name
        Dim psList() As Process
        Try
            psList = Process.GetProcesses()

            For Each p As Process In psList
                If (pName = p.ProcessName) Then
                    found = True
                End If
            Next p
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            found = False
        End Try
        Return found
    End Function

    Public Function Translate(trans As String, translated As String) As String
        Return translated
    End Function

    Public Sub RemoveAllControlsFromPanel(pnl As Panel)
        For Each ctrl As Control In pnl.Controls
            pnl.Controls.Remove(ctrl)
        Next
    End Sub

    Public Sub Shake(frm As Form)
        Dim shake As Integer = 0
        If shake >= 1000 Then
            shake = 0
        End If
        Do Until shake = 50
            frm.Left -= 7
            frm.Top -= 2
            frm.Left += 7
            frm.Top += 2
            shake += 1
        Loop
    End Sub

    Public Function GetIPAddress() As String
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim address As String = ""
        Try
            address = hostEntry.AddressList().Where(Function(a) a.AddressFamily = Sockets.AddressFamily.InterNetworkV6).First().ToString()
        Catch
        End Try
        Return address
    End Function

    Public Function GetPingMs(ByRef hostNameOrAddress As String)
        Dim ping As New System.Net.NetworkInformation.Ping
        Return ping.Send(hostNameOrAddress).RoundtripTime
    End Function

    Public Function GetResponseTime(ByRef hostNameOrAddress As String)
        Dim Result As Net.NetworkInformation.PingReply
        Dim SendPing As New Net.NetworkInformation.Ping
        Dim ResponseTime As Long '<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        Try
            Result = SendPing.Send(hostNameOrAddress)
            ResponseTime = Result.RoundtripTime
            If Result.Status = Net.NetworkInformation.IPStatus.Success Then
                Debug.WriteLine(ResponseTime.ToString)
                Return ResponseTime.ToString
            Else
                Debug.WriteLine("")
            End If
        Catch ex As Exception
        End Try
    End Function

    Public Sub AddForm(frm As Form, pnl As Panel)
        RemoveAllControlsFromPanel(pnl)
        frm.TopMost = True
        frm.TopLevel = False
        pnl.Controls.Add(frm)
        frm.Show()
    End Sub

End Class
