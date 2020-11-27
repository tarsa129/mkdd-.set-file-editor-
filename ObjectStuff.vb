Public Class ObjectStuff
    'help me
    Public Shared Function makenecessaryChanges(ByVal input As Single)
        If Form1.radmph.Checked = True Then
            Return input * 2.5
        ElseIf Form1.radkph.Checked = True Then
            Return input * 1.75
        Else
            Return input
        End If
    End Function
    Public Shared Function isGood(ByVal input As String)
        If input = Nothing Then
            Return False
        End If
        If Not IsNumeric(input) Then
            Return False
        End If
        Return True

    End Function
    Public Shared Sub dealwithunits()
        Dim txtspeeds() As TextBox = {Form1.txtTopSpeed20, Form1.txtworspeed21, Form1.txtmorspeed22, Form1.txthorspeed23}
        Dim conv As Double = 1

        If Form1.radUnits.Checked Then
            conv = 1
        ElseIf Form1.radmph.Checked Then
            conv = 2.5
        ElseIf Form1.radkph.Checked Then
            conv = 1.75
        End If

        For i As Integer = 0 To 3
            txtspeeds(i).Text = Math.Round(DataStuff.floats(i + 20) / conv, 5)
        Next
    End Sub
    Public Shared Sub MakeAllUsable()
        For Each rad As RadioButton In Form1.grpSpeedUnits.Controls.OfType(Of RadioButton)
            rad.Enabled = True
        Next
        For Each tb As TextBox In Form1.grpKnown.Controls.OfType(Of TextBox)
            tb.ReadOnly = False
            Dim floatindex As Integer = Val(tb.Name.Substring(tb.Name.Length - 2, 2))
            tb.Text = DataStuff.floats(floatindex)
        Next
        For Each tb As TextBox In Form1.grpAll.Controls.OfType(Of TextBox)
            tb.ReadOnly = False
            Dim floatindex As Integer = Val(tb.Name.Substring(tb.Name.Length - 2, 2))
            tb.Text = DataStuff.floats(floatindex)
        Next
        For Each tb As TextBox In Form1.grpCamera.Controls.OfType(Of TextBox)
            tb.ReadOnly = False
            Dim floatindex As Integer = Val(tb.Name.Substring(tb.Name.Length - 2, 2))
            tb.Text = DataStuff.floats(floatindex)
        Next
        Form1.grpKnown.Enabled = True
        Form1.grpCamera.Enabled = True
        Form1.grpAll.Enabled = True
        Form1.txtInfo.Enabled = True
        Form1.txtFileContents.Enabled = True
        Form1.lblinfoGN.Enabled = True
        FileStuff.opened = True
    End Sub
    Public Shared Function formatString(ByVal usetext As String, ByRef sender As Object)
        If usetext.Length = 0 Then
            usetext = "00"
        End If
        If usetext.Chars(usetext.Length - 1) = "." Then
            usetext = usetext & "00"
        End If
        Return usetext
    End Function
    Public Shared Sub textchanged(sender As Object, e As EventArgs)
        If FileStuff.opened Then

            Dim usetext As String = sender.Text
            usetext = formatString(usetext, sender)

            If isGood(usetext) Then
                Dim value As Single
                value = CSng(usetext)

                Dim floatindex As Integer = Val(sender.Name.Substring(sender.Name.Length - 2, 2))
                If floatindex <= 23 And floatindex >= 20 And sender.Name.Length > 5 Then
                    value = makenecessaryChanges(value)
                End If

                DataStuff.changeValue(floatindex, value)

                Dim lastChar As Char = usetext.Chars(Math.Max(usetext.Length - 1, 0))
                Dim lastTwo As String = usetext.Substring(Math.Max(usetext.Length - 2, 0))

                If (Not (lastChar = "." Or lastTwo = ".0")) Then
                    Call dealwithunits()
                    'Call dealwithKnown()
                    DataStuff.updateValues()
                End If
            End If
        End If
    End Sub
    Public Shared Sub txtclicked(sender As Object, e As EventArgs)
        Dim floatindex As Integer = Val(sender.Name.Substring(sender.Name.Length - 2, 2))
        Dim txtindex = floatindex * 9
        Form1.txtFileContents.SelectionStart = txtindex
        Form1.txtFileContents.SelectionLength = 8
    End Sub
End Class
