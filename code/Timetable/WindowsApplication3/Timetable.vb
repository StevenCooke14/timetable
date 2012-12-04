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
    Private m_panel_Lect(0 To 50) As Panel
    Private m_panel_Room(0 To 50) As Panel
    Private m_panel_Group(0 To 50) As Panel
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

        Dim exists As Boolean
        exists = False
        Dim msg As String
        msg = "clash code made an exception"
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

    Public Sub addLessonString(ByRef str As String)
        Try
            ' str is a comma delimited string as stored in file
            Dim fields(0 To 6) As String


            ' Split the string at the comma characters and add each field to a ListBox
            fields = Split(str, ",")

            For i = 0 To 6
                Trim$(fields(i))
            Next

            Dim l As Lesson
            l = New Lesson(fields(0), fields(1), fields(2), fields(3), fields(4), fields(5), fields(6))
            m_lessons.Add(l)

        Catch

            MsgBox("could not split string and add lesson as a object")

        End Try
    End Sub

    'Load all of the saved lessons back into the program after program execution
    Public Sub showLessons(ByRef l As ListBox)

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

    Sub showSelected(p1 As Integer, listBox As ListBox)
        Throw New NotImplementedException
    End Sub
    Public Sub showLecturerLessons(ByRef table As System.Windows.Forms.TableLayoutPanel, ByRef lectChoice As String)
        Dim t_start As String
        Dim t_end As String
        Dim x As Integer
        Dim y As Integer
        Dim intCount As Integer

        Try

            For Each Panel In m_panel_Lect
                table.Controls.Remove(Panel)
            Next

            intCount = 0
            Dim ls As String
            For Each Lesson In m_lessons
                Dim val As Integer


                ls = Lesson.getLecturer()
                val = String.Compare(ls, lectChoice, False)
                If val = 0 Then
                    m_panel_Lect(intCount) = New Panel()
                    m_panel_Lect(intCount).BackColor = Color.Aquamarine
                    t_start = Lesson.getStart()
                    x = times.IndexOf(t_start)

                    t_end = Lesson.getEnd()
                    y = Lesson.getDaynum()
                    Dim l As String
                    l = times.IndexOf(t_end) - x
                    table.Controls.Add(m_panel_Lect(intCount), x, y)
                    table.SetColumnSpan(m_panel_Lect(intCount), l)
                    intCount = intCount + 1

                End If

            Next Lesson

        Catch

            MsgBox("please dont enter reversed times")

        End Try

    End Sub
    Public Sub showRoomLessons(ByRef table As System.Windows.Forms.TableLayoutPanel, ByRef rChoice As String)
        Dim t_start As String
        Dim t_end As String
        Dim x As Integer
        Dim y As Integer
        Dim intCount As Integer

        Try

      
        For intCount = 0 To m_lessons.Count
            table.Controls.Remove(m_panel_Room(intCount))
        Next intCount
        intCount = 0
        'Next Room
        Dim rm As String
        For Each Lesson In m_lessons
            Dim val As Integer
            rm = Lesson.getRoom()
            val = String.Compare(rm, rChoice, False)
            If val = 0 Then
                m_panel_Room(intCount) = New Panel()
                m_panel_Room(intCount).BackColor = Color.Red
                t_start = Lesson.getStart()
                x = times.IndexOf(t_start)

                t_end = Lesson.getEnd()
                y = Lesson.getDaynum()
                Dim l As String
                l = times.IndexOf(t_end) - x
                table.Controls.Add(m_panel_Room(intCount), x, y)
                table.SetColumnSpan(m_panel_Room(intCount), l)
                intCount = intCount + 1

            End If

            Next Lesson

        Catch

            MsgBox("please dont enter reversed times")

        End Try
    End Sub

    Public Sub showGroupLessons(ByRef table As System.Windows.Forms.TableLayoutPanel, ByRef gChoice As String)

        Dim t_start As String
        Dim t_end As String
        Dim x As Integer
        Dim y As Integer
        Dim intCount As Integer

        Try

        
        For Each Panel In m_panel_Group
            table.Controls.Remove(Panel)
        Next
        intCount = 0
        Dim ls As String
        For Each Lesson In m_lessons
            Dim val As Integer


            ls = Lesson.getGroup()
            val = String.Compare(ls, gChoice, False)
            If val = 0 Then
                m_panel_Group(intCount) = New Panel()
                m_panel_Group(intCount).BackColor = Color.Red
                t_start = Lesson.getStart()
                x = times.IndexOf(t_start)

                t_end = Lesson.getEnd()
                y = Lesson.getDaynum()
                Dim l As String
                l = times.IndexOf(t_end) - x
                table.Controls.Add(m_panel_Group(intCount), x, y)
                table.SetColumnSpan(m_panel_Group(intCount), l)
                intCount = intCount + 1


            End If

        Next Lesson

        catch 

            MsgBox("please dont enter reversed times")

        End Try



    End Sub

End Class
