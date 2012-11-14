Public Class Lesson

    Private m_room As Room
    Private m_module As Modules
    Private m_group As Group
    Private m_lecturer As Lecturer
    Private m_day As String
    Private m_start As String
    Private m_end As String

    Public Sub New(ByVal roomName As String, moduleCode As String, groupName As String, lecturerName As String, day As String, start As String, finish As String)

        m_room = New Room(roomName)
        m_module = New Modules(moduleCode)
        m_group = New Group(groupName)
        m_lecturer = New Lecturer(lecturerName)
        m_day = New String(day)
        m_start = New String(start)
        m_end = New String(finish)
    End Sub

    Public Function displayString() As String

        Return m_room.name() + "," + m_module.moduleCode() + "," + m_group.gName() + "," + m_lecturer.lName() + "," + m_day.ToString() + "," + m_start.ToString() + "," + m_end.ToString()
        
        
    End Function

    Public Sub saveData(ByRef writer As IO.StreamWriter)
        
        writer.WriteLine(m_room.name() + "," + m_module.moduleCode() + "," + m_group.gName() + "," + m_lecturer.lName() + "," + m_day.ToString() + "," + m_start.ToString() + "," + m_end.ToString())
    End Sub
End Class
