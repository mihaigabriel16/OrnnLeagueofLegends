Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Reflection
Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports System.Xml
Imports Newtonsoft
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class mainApp
    Dim brain As New Brain
    Dim funcs As New Functions
    Dim client As New Client
    Dim lst As New List(Of String)
    Shared regList As New List(Of String)
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Globals.RIOT_API_KEY = GetApiKey()
        Client.SetApiKey()


        Dim news As New newsPage
        news.TopMost = True
        news.TopLevel = False
        Panel3.Controls.Add(news)
        news.Show()

        Lang.LoadLanguage("en", Me)
        funcs.SearchAutoComplete(TextBox1, lst)
        Dim list = Client.api.getVersion
        Dim lol_ver As String = list(0)
        ToolStripStatusLabel1.Text = brain.GetIPAddress()
        Label2.Text = "League of Legends Patch:" & lol_ver & vbNewLine & "Ornn Version: 1.0.0"
        If Me.FormBorderStyle = FormBorderStyle.Sizable Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If

        regList.AddRange({"br1", "eun1", "euw1"})

        Dim found As Boolean = brain.CheckForProcess("League of Legends")
        If found = True Then
            brain.RemoveAllControlsFromPanel(Panel3)
            Dim gamedata As AllGameDataDTO = Client.api.getAllGameData()

            For Each item In regList
                Try
                    funcs.GetSummonerInfo(gamedata.activePlayer.summonerName, item, Panel3)
                    'MsgBox("found on " & item & gamedata.activePlayer.summonerName)
                Catch ex As Exception
                    'MsgBox("not found on " & item & gamedata.activePlayer.summonerName)
                End Try
            Next
        End If
    End Sub

    Private Function GetApiKey()
        Dim request As WebRequest = WebRequest.Create("https://www.pubstatic.com/ornn.txt")
        Dim response As WebResponse = request.GetResponse()
        Dim data As Stream = response.GetResponseStream()
        Dim html As String = String.Empty

        Using sr As StreamReader = New StreamReader(data)
            html = sr.ReadToEnd()

        End Using
        Debug.Print(html)
        Return html
    End Function

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not lst.Contains(TextBox1.Text) Then
                TextBox1.AutoCompleteCustomSource.Add(TextBox1.Text)
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            Dim coll As AutoCompleteStringCollection = TextBox1.AutoCompleteCustomSource
            coll.Remove(TextBox1.Text)
            TextBox1.AutoCompleteCustomSource = coll
            TextBox1.Clear()
        End If
    End Sub




    Private Sub home_search_button_Click(sender As Object, e As EventArgs) Handles home_seach_button.Click
        If TextBox1.Text = "" Or ComboBox1.SelectedItem = "" Then
            MsgBox("Make sure to enter a Summoner name and selected the region.")
        Else
            brain.RemoveAllControlsFromPanel(Panel3)
            funcs.GetSummonerInfo(TextBox1.Text, funcs.TranslateRegion(ComboBox1.SelectedItem), Panel3)
        End If
    End Sub

    Private Sub Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub SourceCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SourceCodeToolStripMenuItem.Click
        sourceCode.Show()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Me.FormBorderStyle = FormBorderStyle.None
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Me.FormBorderStyle = FormBorderStyle.Sizable
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        brain.Shake(Me)
    End Sub

    Private Sub CheckForLoLGame_Tick(sender As Object, e As EventArgs) Handles CheckForLoLGame.Tick

        Dim found As Boolean = brain.CheckForProcess("League of Legends")
        If found = True Then
            brain.RemoveAllControlsFromPanel(Panel3)
            Dim gamedata As AllGameDataDTO = Client.api.getAllGameData()

            For Each item In regList
                Try
                    funcs.GetSummonerInfo(gamedata.activePlayer.summonerName, item, Panel3)
                    MsgBox("found on " & item & gamedata.activePlayer.summonerName)
                Catch ex As Exception
                    MsgBox("not found on " & item & gamedata.activePlayer.summonerName)
                End Try
            Next
            CheckForLoLGame.Stop()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        brain.AddForm(pingChecker, Panel1)
    End Sub

    Private Sub mainApp_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        For Each ctrl As Control In Panel3.Controls
            ctrl.Size = New Size(Panel3.Width, Panel3.Height)
        Next
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        optionsForm.ShowDialog()
    End Sub

    Private Sub DesignToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesignToolStripMenuItem.Click
        overlayOne.Show()

    End Sub

    Private Sub mainApp_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub
End Class
