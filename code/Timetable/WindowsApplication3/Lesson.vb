Public Class Lesson

    Private m_room As Room

    Public Sub New(ByVal roomName As String)

        m_room = New Room(roomName)

    End Sub

    Public Function displayString() As String

        Return m_room.name()

    End Function

    Public Sub saveData(ByRef writer As IO.StreamWriter)
        Dim mday As String
        mday = "Monday"
        writer.WriteLine(m_room.name() + "," + mday)
    End Sub
End Class
