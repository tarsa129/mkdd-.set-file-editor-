Public Class Form1
    Inherits Form
    Private Sub MnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        FileStuff.openmenu()

    End Sub
    Private Sub LblLoaded_Change(sender As Object, e As EventArgs)
        Dim names() As String = {"babymario", "babyluigi", "nokonoko", "patapata", "diddykong",
            "koopajr", "kinopio_", "kinopiogirl", "_mario_", "_luigi", "peach", "daisy", "yoshi",
            "catherine", "waluigi", "wario", "donkey", "koopa", "pakkun", "teresa", "extra"}
        Dim i As Integer
        Dim found As Boolean

        For i = 0 To names.Length - 1
            If FileStuff.filename.Contains(names(i)) Then
                Dim imageid As String = names(i).Replace("_", "")
                'Me.kartpic.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory & "Images\" & imageid & ".png")
                found = True
                Exit For
            End If
        Next
        If found = False Then
            'Me.kartpic.Image = Nothing
        End If
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click
        Call FileStuff.saveas()
    End Sub
    Private Sub MnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        Call FileStuff.writefile(FileStuff.filename)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each tb As TextBox In grpAll.Controls.OfType(Of TextBox)()
            AddHandler tb.TextChanged, AddressOf ObjectStuff.textchanged
        Next
        For Each tb As TextBox In grpKnown.Controls.OfType(Of TextBox)()
            AddHandler tb.TextChanged, AddressOf ObjectStuff.textchanged
        Next
        For Each tb As TextBox In grpAll.Controls.OfType(Of TextBox)()
            AddHandler tb.Click, AddressOf ObjectStuff.txtclicked
        Next
        For Each tb As TextBox In grpKnown.Controls.OfType(Of TextBox)()
            AddHandler tb.Click, AddressOf ObjectStuff.txtclicked
        Next
        For Each lbl As Label In grpAll.Controls.OfType(Of Label)()
            AddHandler lbl.Click, AddressOf InfoStuff.lblClicked
        Next
        For Each lbl As Label In grpKnown.Controls.OfType(Of Label)()
            AddHandler lbl.Click, AddressOf InfoStuff.lblClicked
        Next
    End Sub
    Private Sub Radkph_CheckedChanged(sender As Object, e As EventArgs) Handles radUnits.CheckedChanged, radmph.CheckedChanged, radkph.CheckedChanged
        Call ObjectStuff.dealwithunits()
    End Sub
    Private Sub ClearInformationBoxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuClearInfo.Click
        txtInfo.Text = Nothing
    End Sub
    Private Sub LblinfoGN_Click(sender As Object, e As EventArgs) Handles lblinfoGN.Click
        Call InfoStuff.fillBox("GN")
    End Sub
    Private Sub SourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuSource.Click
        Process.Start("https://www.mariowiki.com/Mario_Kart:_Double_Dash!!#Actual_stats")
    End Sub

End Class
