Public Class Timetable
    Private m_lessons(0 To 50) As Lesson
    Private m_panel(0 To 50) As Panel
    Private m_nLessons As Integer
    Private times As New List(Of String)
    Public Sub New()
        m_nLessons = 0

        times.Add("08:45")

        times.Add("09:00")
        times.Add("09:15")
        times.Add("09:30")
        times.Add("09:45")

        times.Add("10:00")
        times.Add("10:15")
        times.Add("10:30")
        times.Add("10:45")

        times.Add("11:00")
        times.Add("11:15")
        times.Add("11:30")
        times.Add("11:45")

        times.Add("12:00")
        times.Add("12:15")
        times.Add("12:30")
        times.Add("12:45")

        times.Add("13:00")
        times.Add("13:15")
        times.Add("13:30")
        times.Add("13:45")

        times.Add("14:00")
        times.Add("14:15")
        times.Add("14:30")
        times.Add("14:45")

        times.Add("15:00")
        times.Add("15:15")
        times.Add("15:30")
        times.Add("15:45")

        times.Add("16:00")
        times.Add("16:15")
        times.Add("16:30")
        times.Add("16:45")

        times.Add("17:00")
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
    Public Sub showTimetableLessons(ByRef table As System.Windows.Forms.TableLayoutPanel)
        'Dim mP As Panel
        Dim t_start As String
        Dim t_end As String
        Dim x As Integer
        Dim y As Integer

        For intCount = 0 To m_nLessons - 1
            table.Controls.Remove(m_panel(intCount))
        Next intCount

        For intCount = 0 To m_nLessons - 1
            m_panel(intCount) = New Panel()
            m_panel(intCount).BackColor = Color.Red
            t_start = m_lessons(intCount).getStart()
                x = times.IndexOf(t_start)

                t_end = m_lessons(intCount).getEnd()
                y = m_lessons(intCount).getDaynum()
                table.Controls.Add(m_panel(intCount), x, y)
        Next intCount

    End Sub

    Sub removeData(p1 As Integer, listBox As ListBox)
        Throw New NotImplementedException
    End Sub

    Sub showSelected(p1 As Integer, listBox As ListBox)
        Throw New NotImplementedException
    End Sub

End Class
