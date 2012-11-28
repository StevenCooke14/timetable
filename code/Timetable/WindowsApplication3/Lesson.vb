Public Class Lesson
    'Each of the attributes
    Private m_room As Room
    Private m_module As Modules
    Private m_group As Group
    Private m_lecturer As Lecturer
    Private m_day As String
    Private m_start As String
    Private m_end As String
    'The constructor for the lesson
    Public Sub New(ByVal roomName As String, moduleCode As String, groupName As String, lecturerName As String, day As String, start As String, finish As String)
        m_room = New Room(roomName)
        m_module = New Modules(moduleCode)
        m_group = New Group(groupName)
        m_lecturer = New Lecturer(lecturerName)
        m_day = New String(day)
        m_start = New String(start)
        m_end = New String(finish)
    End Sub
    'Display the lesson in the listbox
    Public Function displayString() As String
        Return m_room.name() + "," + m_module.moduleCode() + "," + m_group.gName() + "," + m_lecturer.lName() + "," + m_day.ToString() + "," + m_start.ToString() + "," + m_end.ToString()
    End Function
    'Save the lesson to the text file
    Public Sub saveData(ByRef writer As IO.StreamWriter)
        writer.WriteLine(m_room.name() + "," + m_module.moduleCode() + "," + m_group.gName() + "," + m_lecturer.lName() + "," + m_day.ToString() + "," + m_start.ToString() + "," + m_end.ToString())
    End Sub
    'Get the index number of the day
    Public Function getDaynum() As Integer
        If m_day = "Monday" Then Return 0
        If m_day = "Tuesday" Then Return 1
        If m_day = "Wednesday" Then Return 2
        If m_day = "Thursday" Then Return 3
        If m_day = "Friday" Then Return 4
        If m_day = "Saturday" Then Return 5
        Return MsgBox("day not available")
    End Function
    'Get the start time
    Public Function getStart() As String
        Return m_start
    End Function
    'Get the finish time
    Public Function getEnd() As String
        Return m_end
    End Function

    Public Function getLecturer() As String
        Return m_lecturer.lName
    End Function
    Public Function getRoomDayTime() As String
        Return m_room.name() + "," + m_day.ToString() + "," + m_start.ToString() + "," + m_end.ToString()
    End Function
    Public Function getLecturerDayTime() As String
        Return m_lecturer.lName + "," + m_day.ToString() + "," + m_start.ToString() + "," + m_end.ToString()
    End Function

    Public Function getGroupDayTime() As String
        Return m_group.gName() + "," + m_day.ToString() + "," + m_start.ToString() + "," + m_end.ToString()
    End Function

    Public Function getModuleDayTime() As String
        Return m_module.moduleCode() + "," + m_day.ToString() + "," + m_start.ToString() + "," + m_end.ToString()
    End Function

    Public Function getDayTime() As String
        Return m_day.ToString() + "," + m_start.ToString() + "," + m_end.ToString()
    End Function
End Class
