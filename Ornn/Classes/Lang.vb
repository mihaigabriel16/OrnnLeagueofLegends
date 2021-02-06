Imports System.Xml

Public Class Lang
    Shared settingsXML As XmlDocument = New XmlDocument()
    Shared xmlNodes As XmlNodeList = settingsXML.SelectNodes("//lang/loc")
    Public Shared Sub LoadLanguage(ByVal loc As String, ByRef form As Form)
        settingsXML.Load("Locale/" & loc & ".xml")
        For Each XMLNode In xmlNodes
            Dim xmlname As String = XMLNode.InnerText
            'loc_list.Add(xmlname)
            Dim value As String = XMLNode.Attributes("value").Value
            Try
                For Each ctrl As Control In form.Controls
                    If (TypeOf ctrl Is MenuStrip) Then
                        LoadMenuStrip(ctrl, xmlname, value)
                    ElseIf (TypeOf ctrl Is TabControl) Then
                        LoadTabControl(ctrl, xmlname, value)
                    Else
                        If ctrl.Name = xmlname Then
                            ctrl.Text = value
                        Else
                        End If
                    End If
                Next
            Catch ex As Exception
                MsgBox("Missing loc configs", MsgBoxStyle.Critical)
                MsgBox(ex.ToString)
                Exit For
            End Try
        Next
        'MsgBox(loc_list(0))
    End Sub

    Public Shared Sub LoadMenuStrip(ByRef ms As MenuStrip, ByVal xmlnm As String, ByVal xmlvalue As String)
        Try
            For Each ctrl As ToolStripItem In ms.Items
                If ctrl.Name = xmlnm Then
                    ctrl.Text = xmlvalue
                Else
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Shared Sub LoadTabControl(ByRef ms As TabControl, ByVal xmlnm As String, ByVal xmlvalue As String)
        Try
            For Each ctrl As TabPage In ms.TabPages
                If ctrl.Name = xmlnm Then
                    ctrl.Text = xmlvalue
                Else
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class
