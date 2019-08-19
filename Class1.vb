Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.IO
Public Class DataStuff
    Sub makeFloatArray(ByVal strFileName As String)

        Dim bytes() As Byte = IO.File.ReadAllBytes(strFileName) 'gets all bytes as integers
        Dim hexes() As String = Array.ConvertAll(bytes, Function(b) b.ToString("X2"))



        Dim i As Integer
        Dim j As Integer
        Dim k As Integer = 0


        For i = 3 To hexes.Length - 1 Step 4
            Dim floatbytes(3) As Byte
            For j = 0 To 3
                floatbytes(j) = bytes(i - j)
            Next
            ReDim Preserve floats(k)
            floats(k) = BitConverter.ToSingle(floatbytes, 0)
            k = k + 1
        Next


        Call updateValues()



    End Sub
    Sub changeValue(ByVal index As Integer, ByVal value As Single)
        floats(index) = value
    End Sub
    Function floattohex(ByVal value As Single)

        Dim arr = BitConverter.GetBytes(value)
        Array.Reverse(arr)
        Return BitConverter.ToString(arr).Replace("-", "")

    End Function
End Class
