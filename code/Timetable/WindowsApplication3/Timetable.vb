'*********************************************************
'*  Project Name: Class Scheduling System  		         *
'*                                         		         *
'*  Project Version: 1.0                   		         *
'*				           		                         *
'*  Class Desc: adding a lesson to the timetable  	     *
'*  				           		                     *
'*  Author: Steven Cooke, Daniel Peacher, Daniel Bell    *
'*********************************************************

Public Class Timetable
    Private m_lessons(0 To 50) As Lesson
    Private m_panel(0 To 50) As Panel
    Private m_nLessons As Integer
    Private times As New List(Of String)

    Public Sub New()
        'Add the folowing to the array
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

    'Add a lesson to the list box
    Public Sub addLesson(ByRef l As Lesson)
        m_lessons(m_nLessons) = l
        m_nLessons = m_nLessons + 1
    End Sub

    'Load all of the saved lessons back into the program after program execution
    Public Sub showLessons(ByRef l As ListBox)
        'List in Listbox
        Dim tl As Lesson
        'Clear the list box
        l.Items.Clear()
        'Read the text file in
        For intCount = 0 To m_nLessons - 1
            tl = m_lessons(intCount)
            l.Items.Add(tl.displayString)
        Next intCount
    End Sub

    'Add all the lessons to the text file
    Public Sub saveData(ByRef theStream As IO.StreamWriter)
        'Add the lessons to the text file
        For intCount = 0 To m_nLessons - 1
            m_lessons(intCount).saveData(theStream)
        Next intCount
    End Sub

    'Adding the lesson to a panel and then displaying it on the timetable
    Public Sub showTimetableLessons(ByRef table As System.Windows.Forms.TableLayoutPanel)
        'Time Start
        Dim t_start As String
        'Time End
        Dim t_end As String
        'The row on the table
        Dim x As Integer
        'The column on the table
        Dim y As Integer
        'The legnth of the panel
        Dim l As Integer

        'Remove all of the current panels on the timetable
        For intCount = 0 To m_nLessons - 1
            table.Controls.Remove(m_panel(intCount))
        Next intCount

        For intCount = 0 To m_nLessons - 1
            'Create a new panel
            m_panel(intCount) = New Panel()

            'Formatting of the panel
            m_panel(intCount).BackColor = Color.Cyan
            m_panel(intCount).BorderStyle = BorderStyle.FixedSingle

            'Calculate the time start 
            t_start = m_lessons(intCount).getStart()
            'Find the index number of the selected start number
            x = times.IndexOf(t_start)

            'Calculate the end time
            t_end = m_lessons(intCount).getEnd()
            'Find the index number of the selected day
            y = m_lessons(intCount).getDaynum()

            'Calculate the length of the panel
            'Time end index number minus the time start index number
            l = times.IndexOf(t_end) - x

            'Add the Panel to the time table
            table.Controls.Add(m_panel(intCount), x, y)

            'Stretch the panel to the value of l
            table.SetColumnSpan(m_panel(intCount), l)

            'Loop back
        Next intCount
    End Sub


    Sub removeData(p1 As Integer, listBox As ListBox)
        Throw New NotImplementedException
    End Sub


    Sub showSelected(p1 As Integer, listBox As ListBox)
        Throw New NotImplementedException
    End Sub
End Class
