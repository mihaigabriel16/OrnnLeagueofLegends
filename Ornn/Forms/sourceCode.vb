Public Class sourceCode
    Public tForm As New Form
    Private Sub Source_Code_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getAllForms(Me)
    End Sub

    Public Sub getAllForms(ByVal sender As Object)
        Dim Forms As New List(Of Form)()
        Dim formType As Type = Type.GetType("System.Windows.Forms.Form")
        For Each t As Type In sender.GetType().Assembly.GetTypes()
            If UCase(t.BaseType.ToString) = "SYSTEM.WINDOWS.FORMS.FORM" Then
                ' MsgBox(t.Name)
                ListBox1.Items.Add(t.Name)
            End If
        Next
    End Sub

    Public Function getSelectedForm(ByVal txt As String)
        If txt = "loader" Then
            tForm = Loader
        ElseIf txt = "pingChecker" Then
            tForm = pingChecker
        End If
        Return tForm
    End Function

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each ctrl As Control In FlowLayoutPanel1.Controls
            FlowLayoutPanel1.Controls.Remove(ctrl)
        Next
        tForm = getSelectedForm(ListBox1.SelectedItem.ToString)
        tForm.TopMost = True
        tForm.TopLevel = False
        tForm.Size = New Size(FlowLayoutPanel1.Width, FlowLayoutPanel1.Height)
        FlowLayoutPanel1.Controls.Add(tForm)
        tForm.Show()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class