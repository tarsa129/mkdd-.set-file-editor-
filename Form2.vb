Imports System.IO
Public Class Documentation
    Inherits Form
    Dim fileloaded As String
    Dim tarsasnotes As Boolean
    Private Sub Documentation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tarsasnotes = True
        fileloaded = "documentation.txt"
        Dim fs As New FileStream(fileloaded, FileMode.Open, FileAccess.Read)
        Dim TextFile As New StreamReader(fs)
        Me.txtDocu.Text = Nothing
        Dim strLineOfText As String
        Do While TextFile.Peek > -1
            strLineOfText = TextFile.ReadLine()
            Me.txtDocu.Text = Me.txtDocu.Text & strLineOfText & vbCrLf
        Loop
        TextFile.Close()
        fs.Close()
    End Sub
    Private Sub BtnSwitch_Click(sender As Object, e As EventArgs) Handles btnSwitch.Click
        If fileloaded = "documentation.txt" Then
            fileloaded = "theirdocumentation.txt"
            lblTitle.Text = "Your Documentation:"
            btnSwitch.Text = "Switch to Tarsa's Notes"
        Else
            fileloaded = "documentation.txt"
            lblTitle.Text = "Tarsa's Documentation:"
            btnSwitch.Text = "Switch to Personal Notes"
        End If
        tarsasnotes = Not tarsasnotes
        lblContact.Visible = Not lblContact.Visible
        txtDocu.ReadOnly = Not txtDocu.ReadOnly
        btnSave.Enabled = False
        btnRestore.Enabled = False

        Call loaddocu(fileloaded)
    End Sub
    Public Sub loaddocu(ByVal fileloaded As String)
        Dim fs As New FileStream(fileloaded, FileMode.Open, FileAccess.Read)
        Dim TextFile As New StreamReader(fs)
        Me.txtDocu.Text = Nothing
        Dim strLineOfText As String
        Do While TextFile.Peek > -1
            strLineOfText = TextFile.ReadLine()
            Me.txtDocu.Text = Me.txtDocu.Text & strLineOfText & vbCrLf
        Loop
        TextFile.Close()
        fs.Close()
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim fs As New FileStream("theirdocumentation.txt", FileMode.Create, FileAccess.Write)
        Dim TextFile As New StreamWriter(fs)
        TextFile.Write(Me.txtDocu.Text)
        TextFile.Close()
        fs.Close()
    End Sub
    Private Sub TxtDocu_TextChanged(sender As Object, e As EventArgs) Handles txtDocu.TextChanged
        If tarsasnotes = False Then
            btnSave.Enabled = True
            btnRestore.Enabled = True
        End If
    End Sub
    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        Call loaddocu(fileloaded)
    End Sub
End Class