Imports System.IO
Public Class FileStuff
    Inherits System.Windows.Forms.Form
    Dim filename As String
    Public Shared Sub openmenu()
        Me.opnOpenFile.ShowDialog()
        Dim strFileName As String = Form1.opnOpenFile.FileName()
        filename = strFileName
        mnuSave.Enabled = True
        mnuSaveAs.Enabled = True
        If strFileName <> Nothing Then
            Call ShowFileContents(strFileName)
        End If
    End Sub
End Class
