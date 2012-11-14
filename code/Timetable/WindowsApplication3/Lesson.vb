Public Class Lesson

    Private m_room As Room
    Private m_module As Modules
    Private m_group As Group
    Private m_lecturer As Lecturer


    Public Sub New(ByVal roomName As String, moduleCode As String, groupName As String, lecturerName As String)

        m_room = New Room(roomName)
        m_module = New Modules(moduleCode)
        m_group = New Group(groupName)
        m_lecturer = New Lecturer(lecturerName)
    End Sub

    Public Function displayString() As String

        Return m_room.name()
        Return m_module.moduleCode()
        Return m_group.gName()
        Return m_lecturer.lName()


    End Function

    Public Sub saveData(ByRef writer As IO.StreamWriter)
        Dim mday As String
        mday = "Monday"
        writer.WriteLine(m_room.name() + "," + m_module.moduleCode() + "," + m_group.gName() + "," + m_lecturer.lName() + "," + mday)
    End Sub
End Class
