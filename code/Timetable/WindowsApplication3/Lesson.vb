Public Class Lesson

    Private m_room As Room
    Private m_module As Modules

    Public Sub New(ByVal roomName As String, moduleCode As String)

        m_room = New Room(roomName)
        m_module = New Modules(moduleCode)

    End Sub

    Public Function displayString() As String

        Return m_room.name()
        Return m_module.moduleCode()

    End Function

    Public Sub saveData(ByRef writer As IO.StreamWriter)
        Dim mday As String
        mday = "Monday"
        writer.WriteLine(m_room.name() + "," + m_module.moduleCode() + "," + mday)
    End Sub
End Class
