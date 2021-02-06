Imports System.IO
Imports System.Net

Public Class summonerPage
    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub summonerPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tClient As WebClient = New WebClient
        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData("http://raw.communitydragon.org/latest/plugins/rcp-fe-lcu-bootstrap-ui/global/default/images/cli-patcher-magicbg.png")))
        'TabPage1.BackgroundImage = tImage

    End Sub
End Class