Public Class DataStuff
    Public Shared floats(-1) As Single
    Public Shared origfloats(-1) As Single
    Public Shared Sub makeFloatArray(ByVal strFileName As String)
        Dim bytes() As Byte = IO.File.ReadAllBytes(strFileName) 'gets all bytes in the file as integers
        Dim hexes() As String = Array.ConvertAll(bytes, Function(b) b.ToString("X2")) 'converts all the bytes to hex, giving us what we see in hxd

        Dim i As Integer 'counter used for each float value in the whole document
        Dim j As Integer 'counter used for each byte in each float
        Dim k As Integer = 0 'counter used for the index in the array of the floats in the document

        For i = 3 To hexes.Length - 1 Step 4
            Dim floatbytes(3) As Byte 'each float is made out of 4 bytes; this makes an array for each of them
            For j = 0 To 3
                floatbytes(j) = bytes(i - j) 'this makes the floats littleendian, the default for visual basic
            Next
            ReDim Preserve floats(k)
            ReDim Preserve origfloats(k)
            floats(k) = BitConverter.ToSingle(floatbytes, 0)
            origfloats(k) = BitConverter.ToSingle(floatbytes, 0)
            k = k + 1
        Next

        Call updateValues() 'puts the values into the text box
    End Sub
    Public Shared Sub changeValue(ByVal index As Integer, ByVal value As Single)
        If index < 0 Then
            MsgBox("Incorrect Value")
            Return
        End If
        floats(index) = value
    End Sub
    Public Shared Function floattobytes(ByVal value As Single, ByVal retearly As Boolean)
        Dim arr = BitConverter.GetBytes(value) 'gets the bytes from the float
        Array.Reverse(arr) 'reverses the array to be big-endian; what is used in mkdd
        Dim vHexSource As String = BitConverter.ToString(arr).Replace("-", "") 'get the value of the float as a hex
        If retearly Then
            Return vHexSource
        End If
        Dim vByteBuffer(vHexSource.Length + 1) As Byte 'creates an array of bytes
        Dim vHexChar As String = String.Empty 'value that will hold each byte
        For i As Integer = 0 To (vHexSource.Length - 1) Step 2
            vHexChar = vHexSource(i) & vHexSource(i + 1)
            vByteBuffer(i) = Byte.Parse(vHexChar, Globalization.NumberStyles.HexNumber) 'gets the bytes as the byte values
        Next

        Dim veditedbyte(3) As Byte 'gets every other value from the bytebuffer array
        Dim index As Integer = 0
        For i As Integer = 0 To 7 Step 2
            veditedbyte(index) = vByteBuffer(i)
            index = index + 1
        Next

        Return veditedbyte
    End Function
    Public Shared Sub updateValues()
        Form1.txtFileContents.Text = Nothing 'clear existing values
        Dim writevalue As String = Nothing 'make a string for all the values
        For i = 0 To floats.Length - 1 'fill the string
            writevalue = writevalue & floattobytes(floats(i), True) & " "
        Next
        Form1.txtFileContents.Text = writevalue 'write values to text box
    End Sub
End Class
