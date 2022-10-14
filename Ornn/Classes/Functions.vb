Imports System.Xml
Imports System.Net
Imports System.IO
Public Class Functions
    Dim brain As New Brain


    Public Sub SearchAutoComplete(ByRef txt As TextBox, ByRef lst As List(Of String))
        Dim MySource As New AutoCompleteStringCollection()
        lst.Add("mihai")
        MySource.AddRange(lst.ToArray)
        txt.AutoCompleteCustomSource = MySource
        txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txt.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Public Function TranslateRank(ByRef rank As String) As String
        Dim translated As String = ""
        If rank = "I" Then
            translated = "1"
        ElseIf rank = "II" Then
            translated = "2"
        ElseIf rank = "III" Then
            translated = "3"
        ElseIf rank = "IV" Then
            translated = "4"
        End If
        Return translated
    End Function

    Public Function TranslateRegion(reg As String) As String
        Dim translated As String = ""
        If reg = "EUNE" Then
            translated = "eun1"
        ElseIf reg = "EUW" Then
            translated = "euw1"
        ElseIf reg = "BR" Then
            translated = "br1"
        ElseIf reg = "JP" Then
            translated = "jp1"
        ElseIf reg = "KR" Then
            translated = "kr"
        ElseIf reg = "LAN" Then
            translated = "la1"
        ElseIf reg = "LAS" Then
            translated = "la2"
        ElseIf reg = "NA" Then
            translated = "na1"
        ElseIf reg = "OCE" Then
            translated = "oc1"
        ElseIf reg = "TR" Then
            translated = "tr1"
        ElseIf reg = "RU" Then
            translated = "ru1"
        ElseIf reg = "PBE" Then
            translated = "pbe1"
        End If
        Return translated
    End Function

    Public Sub AddLog(richtextbox As RichTextBox, txt As String)
        richtextbox.AppendText(txt)
    End Sub



    Public Function SetRegion(reg As String) As String

    End Function

    Public Sub GetSummonerInfo(name As String, region As String, canvas As Panel)
        Dim summoner As SummonerDTO = Client.api.GetSummonerByName(name, region)
        Dim summoner_league As New List(Of LeagueEntryDTO)
        summoner_league = Client.api.GetLeagueBySummonerID(summoner.id, region)
        Dim sm As New summonerPage
        sm.TopMost = True
        sm.TopLevel = False
        canvas.Controls.Add(sm)
        sm.Show()
        sm.Label3.Text = summoner.name
        sm.Label4.Text = "Level: " & summoner.summonerLevel
        For Each item In summoner_league
            Dim urank As New userRank
            Dim rankSolo As String
            Dim rankFlex As String
            urank.TopMost = True
            urank.TopLevel = False
            sm.FlowLayoutPanel2.Controls.Add(urank)
            urank.Show()
            If item.queueType = "RANKED_SOLO_5x5" Then
                rankSolo = item.tier & " " & item.rank & " (" & item.leaguePoints & " LP)"
                Dim rankUrl As String = "https://opgg-static.akamaized.net/images/medals/" & item.tier.ToLower & "_" & TranslateRank(item.rank) & ".png"
                Dim rankClient As WebClient = New WebClient
                Dim rankImage As Bitmap = Bitmap.FromStream(New MemoryStream(rankClient.DownloadData(rankUrl)))
                urank.PictureBox1.BackgroundImage = rankImage
                Dim lblRank As New Label
                Dim lblQ As New Label
                Dim lblGames As New Label
                lblRank.Text = rankSolo
                lblQ.Text = "Ranked Solo/Duo"
                lblGames.Text = item.wins & " Wins / " & item.losses & " Losses"
                urank.FlowLayoutPanel1.Controls.Add(lblRank)
                urank.FlowLayoutPanel1.Controls.Add(lblQ)
                urank.FlowLayoutPanel1.Controls.Add(lblGames)
            End If
            If item.queueType = "RANKED_FLEX_SR" Then
                rankFlex = item.tier & " " & item.rank & " (" & item.leaguePoints & " LP)"
                Dim rankUrl As String = "https://opgg-static.akamaized.net/images/medals/" & item.tier.ToLower & "_" & TranslateRank(item.rank) & ".png"
                Dim rankClient As WebClient = New WebClient
                Dim rankImage As Bitmap = Bitmap.FromStream(New MemoryStream(rankClient.DownloadData(rankUrl)))
                urank.PictureBox1.BackgroundImage = rankImage
                Dim lblRank As New Label
                Dim lblQ As New Label
                Dim lblGames As New Label
                lblRank.Text = rankFlex
                lblQ.Text = "Ranked Flex"
                lblGames.Text = item.wins & " Wins / " & item.losses & " Losses"
                urank.FlowLayoutPanel1.Controls.Add(lblRank)
                urank.FlowLayoutPanel1.Controls.Add(lblQ)
                urank.FlowLayoutPanel1.Controls.Add(lblGames)
            End If
            sm.Label5.Text = rankSolo
        Next
        Dim tClient As WebClient = New WebClient
        'Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData("http://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/profile-icons/" & summoner.profileIconId & ".jpg")))
        'sm.PictureBox1.BackgroundImage = tImage

        Try
            Dim spectator As CurrentGameInfoDTO = Client.api.SpectateActiveGame(summoner.id, region)
            Dim ag As New activeGame
            ag.TopMost = True
            ag.TopLevel = False
            sm.Panel9.Controls.Add(ag)
            ag.Show()
            For Each champ In spectator.participants
                Dim orderTeam As New List(Of Object)
                Dim chaosTeam As New List(Of Object)
                If champ.teamId = 100 Then
                    orderTeam.Add(champ)
                Else
                    chaosTeam.Add(champ)
                End If
                For Each champs As CurrentGameParticipantDTO In orderTeam
                    Dim ap As New activePlayer
                    ap.TopLevel = False
                    ap.TopMost = True
                    ap.PictureBox1.BackColor = Color.Blue
                    ap.Label1.Text = champs.summonerName
                    ap.Label2.Text = champs.championId
                    ag.FlowLayoutPanel1.Controls.Add(ap)
                    ap.Show()
                Next
                For Each champs As CurrentGameParticipantDTO In chaosTeam
                    Dim accWrapper As New FlowLayoutPanel
                    Dim accName As New Label
                    Dim accImage As New PictureBox
                    Dim accChamp As New Label
                    accWrapper.Size = New Size(200, 60)
                    accImage.Size = New Size(60, 60)
                    accImage.BorderStyle = BorderStyle.FixedSingle
                    accImage.BackColor = Color.Red
                    accName.Text = champs.summonerName
                    accChamp.Text = champs.championId
                    ag.FlowLayoutPanel2.Controls.Add(accWrapper)
                    accWrapper.Controls.Add(accImage)
                    accWrapper.Controls.Add(accName)
                    accWrapper.Controls.Add(accChamp)
                Next
            Next
        Catch ex As Exception
            'MsgBox(ex.ToString & vbNewLine & "Active Game Not Found")
        End Try
    End Sub


End Class
