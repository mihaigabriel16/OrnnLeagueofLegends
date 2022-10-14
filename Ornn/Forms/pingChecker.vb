Public Class pingChecker
    Dim br As New Brain
    Private Sub pingChecker_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Sub TimerTick(ByVal sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem = "EUW" Then
            Label1.Text = br.GetPingMs("104.160.141.3")
            Label3.Text = "IP 104.160.141.3"
        ElseIf ComboBox1.SelectedItem = "NA" Then
            Label1.Text = br.GetPingMs("104.160.131.3")
            Label3.Text = "IP 104.160.131.3"
        ElseIf ComboBox1.SelectedItem = "EUNE" Then
            Label1.Text = br.GetPingMs("104.160.142.3")
            Label3.Text = "IP 104.160.142.3"
        End If
    End Sub
End Class