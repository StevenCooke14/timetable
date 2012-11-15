Public Class Timetable
    Private m_lessons As New List(Of Lesson)

    Public Sub addLesson(ByRef l As Lesson)
        m_lessons.Add(l)

    End Sub

    Public Sub showLessons(ByRef l As ListBox)
        ''List in Listbox

        l.Items.Clear()
        For Each lm In m_lessons
            l.Items.Add(lm.displayString())
        Next
        
    End Sub

    Public Sub saveData(ByRef theStream As IO.StreamWriter)
        For Each lm In m_lessons
            lm.saveData(theStream)
        Next
    End Sub

    Public Sub removeData(ByVal i As Integer, ByRef l As ListBox)
        m_lessons.RemoveAt(i)
        showLessons(l)
    End Sub

    Public Sub showSelected(ByVal i As Integer, ByRef l As ListBox)
        m_lessons(i)

    End Sub
End Class
