Public Class pingChecker
    Dim br As New Brain
    Private Sub pingChecker_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Sub TimerTick(ByVal sender As Object, e As EventArgs)
        If ComboBox1.SelectedItem = "EUW" Then
            Label1.Text = br.GetPingMs("104.160.141.3")
            Label3.Text = "IP 104.160.141.3"
            If Label1.Text >= 25 Then
                PictureBox1.BackColor = Color.LightGreen
            End If
            If Label1.Text >= 45 Then
                PictureBox1.BackColor = Color.DarkGreen
            End If
            If Label1.Text >= 65 Then
                PictureBox1.BackColor = Color.Orange
            End If
            If Label1.Text >= 125 Then
                PictureBox1.BackColor = Color.OrangeRed
            End If
        ElseIf ComboBox1.SelectedItem = "NA" Then
            Label1.Text = br.GetPingMs("104.160.131.3")
            Label3.Text = "IP 104.160.131.3"
            If Label1.Text >= 25 Then
                PictureBox1.BackColor = Color.LightGreen
            End If
            If Label1.Text >= 45 Then
                PictureBox1.BackColor = Color.DarkGreen
            End If
            If Label1.Text >= 65 Then
                PictureBox1.BackColor = Color.Orange
            End If
            If Label1.Text >= 125 Then
                PictureBox1.BackColor = Color.OrangeRed
            End If
        ElseIf ComboBox1.SelectedItem = "EUNE" Then
            Label1.Text = br.GetPingMs("104.160.142.3")
            Label3.Text = "IP 104.160.142.3"
            If Label1.Text >= 25 Then
                PictureBox1.BackColor = Color.LightGreen
            End If
            If Label1.Text >= 45 Then
                PictureBox1.BackColor = Color.DarkGreen
            End If
            If Label1.Text >= 65 Then
                PictureBox1.BackColor = Color.Orange
            End If
            If Label1.Text >= 125 Then
                PictureBox1.BackColor = Color.OrangeRed
            End If
        ElseIf ComboBox1.SelectedItem = "LAN" Then
            Label1.Text = br.GetPingMs("104.160.136.3")
            Label3.Text = "IP 104.160.136.3"
            If Label1.Text >= 25 Then
                PictureBox1.BackColor = Color.LightGreen
            End If
            If Label1.Text >= 45 Then
                PictureBox1.BackColor = Color.DarkGreen
            End If
            If Label1.Text >= 65 Then
                PictureBox1.BackColor = Color.Orange
            End If
            If Label1.Text >= 125 Then
                PictureBox1.BackColor = Color.OrangeRed
            End If
        ElseIf ComboBox1.SelectedItem = "OCE" Then
            Label1.Text = br.GetPingMs("104.160.156.1")
            Label3.Text = "IP 104.160.156.1"
            If Label1.Text >= 25 Then
                PictureBox1.BackColor = Color.LightGreen
            End If
            If Label1.Text >= 45 Then
                PictureBox1.BackColor = Color.DarkGreen
            End If
            If Label1.Text >= 65 Then
                PictureBox1.BackColor = Color.Orange
            End If
            If Label1.Text >= 125 Then
                PictureBox1.BackColor = Color.OrangeRed
            End If
        ElseIf ComboBox1.SelectedItem = "BR" Then
            Label1.Text = br.GetPingMs("104.160.152.3")
            Label3.Text = "IP 104.160.152.3"
            If Label1.Text >= 25 Then
                PictureBox1.BackColor = Color.LightGreen
            End If
            If Label1.Text >= 45 Then
                PictureBox1.BackColor = Color.DarkGreen
            End If
            If Label1.Text >= 65 Then
                PictureBox1.BackColor = Color.Orange
            End If
            If Label1.Text >= 125 Then
                PictureBox1.BackColor = Color.OrangeRed
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Dim tim As New Timer
        AddHandler tim.Tick, AddressOf TimerTick
        tim.Start()
    End Sub
End Class