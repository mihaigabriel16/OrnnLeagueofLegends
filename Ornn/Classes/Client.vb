Public Class Client
    Public Shared api As RiotAPI
    Public Shared Sub SetApiKey()
        ' api = New RiotAPI(Globals.RIOT_API_KEY, 4)
        api = New RiotAPI("RGAPI-0a4c4c3f-bca9-4d4d-826b-47253dd5772e", 4)
    End Sub

End Class
