Imports System.IO
Public Class FileStuff
    Inherits Form
    Public Shared filename As String = "asdf"
    Public Shared opened As Boolean
    Public Shared Sub openmenu()
        opened = False
        Form1.opnOpenFile.Filter = "MKDD kart setting file|*.set"
        Form1.opnOpenFile.Title = "Open File"
        Form1.opnOpenFile.ShowDialog() 'open the dialog
        Dim strFileName As String = Form1.opnOpenFile.FileName() 'get the path of the file
        filename = strFileName 'make the path available to the whole class
        Form1.mnuSave.Enabled = True 'un-grey out the save menu options
        Form1.mnuSaveAs.Enabled = True
        If strFileName <> Nothing Then 'if there is a file, then load the values from the file
            Call ShowFileContents()
        End If

    End Sub
    Public Shared Sub ShowFileContents()
        Try
            Dim fs As New FileStream(filename, FileMode.Open, FileAccess.Read) 'make a filestream object using the path
            Dim TextFile As New StreamReader(fs) 'make a new text file - may not be needed
            Form1.txtInfo.Text = Nothing 'clear out any existing data
            Form1.lblLoaded.Text = "Loaded: " & filename 'specify which file is loaded
            Call DataStuff.makeFloatArray(filename) 'get the floats and put them in an array
            TextFile.Close() 'close the files
            fs.Close()
            ObjectStuff.MakeAllUsable()
            Call InfoStuff.fillBox("GN")
        Catch ex As Exception

        End Try


    End Sub
    Public Shared Sub saveas()
        Try
            Form1.svFileDialog.Filter = "MKDD kart setting file|*.set" 'make sure that you can only save as a .set file
            Form1.svFileDialog.Title = "Save file" 'set the title
            Form1.svFileDialog.ShowDialog() 'open the dialog
            Call writefile(Form1.svFileDialog.FileName) 'write the file
        Catch ex As Exception

        End Try

    End Sub
    Public Shared Sub writefile(ByVal path As String)
        Dim fs As New FileStream(path, FileMode.Create, FileAccess.Write) 'make a new file to write to
        Dim TextFile As New StreamWriter(fs)
        Dim i As Integer
        For i = 0 To DataStuff.floats.Length - 1 'for all the values in floats, write then to the file
            Dim curval() As Byte = DataStuff.floattobytes(DataStuff.floats(i), False)
            fs.Write(curval, 0, curval.Length)
        Next

        TextFile.Close() 'close the files
        fs.Close()
    End Sub
End Class
