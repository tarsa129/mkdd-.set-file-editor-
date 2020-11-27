Imports System.IO
Public Class InfoStuff
    Public Shared Sub fillBox(ByVal lookup As String)
        Dim strLines() As String
        strLines = getlines(lookup)
        For i As Integer = 0 To strLines.Length - 1
            Form1.txtInfo.Text += strLines(i) & vbCrLf
        Next
    End Sub
    Public Shared Function getlines(ByVal lookup As String)
        Dim fs As New FileStream("information.txt", FileMode.Open, FileAccess.Read) 'make a filestream object using the path
        Dim TextFile As New StreamReader(fs)

        Dim strLineOfText As String
        Dim strLine(0) As String
        strLine(0) = "--" & lookup & "--"
        Dim found As Boolean = False
        Dim i As Integer = 1

        Do While TextFile.Peek > -1
            strLineOfText = TextFile.ReadLine()
            If checkadd(strLineOfText, lookup) Then
                ReDim Preserve strLine(i)
                strLine(i) = strLineOfText.Substring(4)
                i += 1
                found = True
            ElseIf found = True Then
                Return strLine
            End If
        Loop
        Return strLine
        TextFile.Close()
        fs.Close()
    End Function
    Public Shared Function checkadd(ByVal potstr As String, ByVal lookup As String)
        If potstr.Substring(0, 2) = lookup Then
            Return True
        End If
        Return False
    End Function
    Public Shared Sub lblClicked(sender As Object, e As EventArgs)
        Dim index = sender.Name.Substring(sender.Name.Length - 2)
        index = editIndex(index)
        Call fillBox(index)
    End Sub
    Public Shared Function editIndex(ByVal lookup As String)
        If IsNumeric(lookup) = False Then
            Return lookup
        Else
            Dim numind As Integer = Val(lookup) * 4
            Dim strind As String = Hex(numind)
            If Len(strind) = 1 Then
                strind = "0" & strind
            End If
            Return strind
        End If
    End Function
End Class

