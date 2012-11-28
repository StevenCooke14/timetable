


''*********************************************************
'*  Project Name: Class Scheduling System  		         *
'*                                         		         *
'*  Project Version: 1.0                   		         *
'*				           		                         *
'*  Class Desc: adding a lesson to the timetable  	     *
'*  				           		                     *
'*  Author: Steven Cooke, Daniel Peacher, Daniel Bell    *
'*********************************************************



Public Class Timetable
    'Private m_lessons(0 To 50) As Lesson
    Private m_panel(0 To 50) As Panel
    Private m_nLessons As Integer
    Private times As New List(Of String)
    Private m_lessons As New List(Of Lesson)

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
        ' m_lessons(m_nLessons) = l
        ' m_nLessons = m_nLessons + 1
        Dim exists As Boolean
        exists = False
        Dim msg As String
        msg = ""
        For Each Lesson In m_lessons
            If (String.Compare(l.getLecturerDayTime(), Lesson.getLecturerDayTime()) = 0) Then
                msg = "Lecturer clash"
                exists = True
            End If
            If (String.Compare(l.getRoomDayTime(), Lesson.getRoomDayTime()) = 0) Then
                msg = msg + " Room clash"
                exists = True
            End If
            If (String.Compare(l.getGroupDayTime(), Lesson.getGroupDayTime()) = 0) Then
                msg = msg + " Group clash"
                exists = True
            End If
        Next Lesson

        If (Not exists) Then
            m_lessons.Add(l)
        Else
            MsgBox(msg)
        End If
    End Sub

    'Load all of the saved lessons back into the program after program execution
    Public Sub showLessons(ByRef l As ListBox)

        ''List in Listbox
        'Dim tl As Lesson
        l.Items.Clear()
        'For intCount = 0 To m_nLessons - 1
        '    tl = m_lessons(intCount)
        '    l.Items.Add(tl.displayString)
        'Next intCount
        For Each lm In m_lessons
            l.Items.Add(lm.displayString())
        Next

    End Sub

    Public Sub saveData(ByRef theStream As IO.StreamWriter)
        '    For intCount = 0 To m_nLessons - 1
        '        m_lessons(intCount).saveData(theStream)
        '    Next intCount

        For Each lm In m_lessons
            lm.saveData(theStream)
        Next

    End Sub

    Public Sub removeData(ByVal i As Integer, ByRef l As ListBox)
        m_lessons.RemoveAt(i)
        showLessons(l)

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

        Dim intCount As Integer

        Dim l As Integer

        'For intCount = 0 To m_nLessons

        For intCount = 0 To m_lessons.Count
            table.Controls.Remove(m_panel(intCount))
        Next intCount
        intCount = 0
        For Each Lesson In m_lessons
            m_panel(intCount) = New Panel()
            m_panel(intCount).BackColor = Color.Red
            t_start = Lesson.getStart()
            x = times.IndexOf(t_start)

            t_end = Lesson.getEnd()
            y = Lesson.getDaynum()

            l = times.IndexOf(t_end) - x
            table.Controls.Add(m_panel(intCount), x, y)
            table.SetColumnSpan(m_panel(intCount), l)
            intCount = intCount + 1
        Next Lesson

    End Sub
    'The legnth of the panel

   

       


    Sub showSelected(p1 As Integer, listBox As ListBox)
        Throw New NotImplementedException
    End Sub


    Public Sub showLecturerLessons(ByRef table As System.Windows.Forms.TableLayoutPanel, ByRef lectChoice As String)

        'Dim mP As Panel
        Dim t_start As String
        Dim t_end As String
        Dim x As Integer
        Dim y As Integer
        Dim intCount As Integer

        'For intCount = 0 To m_nLessons

        For intCount = 0 To m_lessons.Count
            table.Controls.Remove(m_panel(intCount))
        Next intCount
        intCount = 0
        Dim ls As String
        For Each Lesson In m_lessons
            Dim val As Integer


            ls = Lesson.getLecturer()
            val = String.Compare(ls, lectChoice, False)
            If val = 0 Then
                m_panel(intCount) = New Panel()
                m_panel(intCount).BackColor = Color.Red
                t_start = Lesson.getStart()
                x = times.IndexOf(t_start)

                t_end = Lesson.getEnd()
                y = Lesson.getDaynum()
                Dim l As String
                l = times.IndexOf(t_end) - x
                table.Controls.Add(m_panel(intCount), x, y)
                table.SetColumnSpan(m_panel(intCount), l)
                intCount = intCount + 1

            End If

        Next Lesson

    End Sub
    Public Sub showRoomLessons(ByRef table As System.Windows.Forms.TableLayoutPanel, ByRef rChoice As String)
        '------------------------------------------not finished----------------------------------
        'Dim mP As Panel
        Dim t_start As String
        Dim t_end As String
        Dim x As Integer
        Dim y As Integer
        Dim intCount As Integer

        'For intCount = 0 To m_nLessons

        For intCount = 0 To m_lessons.Count
            table.Controls.Remove(m_panel(intCount))
        Next intCount
        intCount = 0
        Dim rm As String
        For Each Room In m_lessons
            Dim val As Integer


            rm = Room.getLecturer()
            val = String.Compare(rm, rChoice, False)
            If val = 0 Then
                m_panel(intCount) = New Panel()
                m_panel(intCount).BackColor = Color.Red
                t_start = Room.getStart()
                x = times.IndexOf(t_start)

                t_end = Room.getEnd()
                y = Room.getDaynum()
                Dim l As String
                l = times.IndexOf(t_end) - x
                table.Controls.Add(m_panel(intCount), x, y)
                table.SetColumnSpan(m_panel(intCount), l)
                intCount = intCount + 1

            End If

        Next Room

    End Sub

    Public Sub showGroupLessons(ByRef table As System.Windows.Forms.TableLayoutPanel, ByRef gChoice As String)
        '------------------------------------------not finished----------------------------------
        'Dim mP As Panel
        Dim t_start As String
        Dim t_end As String
        Dim x As Integer
        Dim y As Integer
        Dim intCount As Integer

        'For intCount = 0 To m_nLessons

        For intCount = 0 To m_lessons.Count
            table.Controls.Remove(m_panel(intCount))
        Next intCount
        intCount = 0
        Dim ls As String
        For Each Lesson In m_lessons
            Dim val As Integer


            ls = Lesson.getLecturer()
            val = String.Compare(ls, gChoice, False)
            If val = 0 Then
                m_panel(intCount) = New Panel()
                m_panel(intCount).BackColor = Color.Red
                t_start = Lesson.getStart()
                x = times.IndexOf(t_start)

                t_end = Lesson.getEnd()
                y = Lesson.getDaynum()
                Dim l As String
                l = times.IndexOf(t_end) - x
                table.Controls.Add(m_panel(intCount), x, y)
                table.SetColumnSpan(m_panel(intCount), l)
                intCount = intCount + 1

            End If

        Next Lesson

    End Sub

End Class
