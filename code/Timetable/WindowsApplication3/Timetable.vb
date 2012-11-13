Public Class Timetable
    Private m_lessons(0 To 50) As Lesson
    Private m_nLessons As Integer

    Public Sub New()
        m_nLessons = 0
    End Sub

    Public Sub addLesson(ByRef l As Lesson)
        m_lessons(m_nLessons) = l
        m_nLessons = m_nLessons + 1
    End Sub

    Public Sub showLessons(ByRef l As ListBox)
        ''List in Listbox
        Dim tl As Lesson
        l.Items.Clear()
        For intCount = 0 To m_nLessons - 1
            tl = m_lessons(intCount)
            l.Items.Add(tl.displayString)
        Next intCount
    End Sub

    Public Sub saveData(ByRef theStream As IO.StreamWriter)
        For intCount = 0 To m_nLessons - 1
            m_lessons(intCount).saveData(theStream)
        Next intCount
    End Sub
End Class
