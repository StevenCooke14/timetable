Public Class frmMain
    Private m_timetable As Timetable

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim l As Lesson

        Try
            l = New Lesson(cmbRoom.SelectedItem.ToString, cmbModule.SelectedItem.ToString, cmbClass.SelectedItem.ToString, cmbLecturer.SelectedItem.ToString, cmbDay.SelectedItem.ToString, cmbTimeStart.SelectedItem.ToString, cmbTimeFinish.SelectedItem.ToString)
            m_timetable.addLesson(l)

        Catch
            MsgBox("please enter all fields")

        End Try

        ' display all lessons on the timetable
        m_timetable.showLessons(lstLesson)

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Define the pathways
        Dim LecturerFileName As String = "Files\lecturer.txt"
        Dim ClassFileName As String = "Files\class.txt"
        Dim RoomFileName As String = "Files\room.txt"
        Dim ModuleFileName As String = "Files\module.txt"
        Dim HoursFileName As String = "Files\lecturer.txt"
        Dim LessonFileName As String = "Files\lessons.txt"

        'Variables to save the list of data to.
        Dim LecturerLine As String
        Dim ClassLine As String
        Dim RoomLine As String
        Dim ModuleLine As String
        Dim LessonLine As String

        ' create the main timetable 
        m_timetable = New Timetable()

        ''Read the lecturer file into the dropdown box.
        ''If the file path exists then,
        If System.IO.File.Exists(LessonFileName) = True Then
            Dim objReader As New System.IO.StreamReader(LessonFileName)
            'Display text,
            Do While objReader.Peek() <> -1
                LessonLine = ""
                LessonLine = LessonLine & objReader.ReadLine()
                lstLesson.Items.Add(LessonLine)
                m_timetable.addLessonString(LessonLine)
            Loop
            'If file does not exist then,
        Else
            'Notify user.
            MsgBox("File Does Not Exist")
        End If

            'Read the lecturer file into the dropdown box.
            'If the file path exists then,
            If System.IO.File.Exists(LecturerFileName) = True Then
                Dim objReader As New System.IO.StreamReader(LecturerFileName)
                'Display text,
                Do While objReader.Peek() <> -1
                    LecturerLine = ""
                    LecturerLine = LecturerLine & objReader.ReadLine()
                    cmbLecturer.Items.Add(LecturerLine)
                    LectChoice.Items.Add(LecturerLine)
                Loop
                'If file does not exist then,
            Else
                'Notify user.
                MsgBox("File Does Not Exist")
            End If

            'Read the Group file into the dropdown box.
            'If the file path exists then,
            If System.IO.File.Exists(ClassFileName) = True Then
                Dim objReader As New System.IO.StreamReader(ClassFileName)
                'Display text,
                Do While objReader.Peek() <> -1
                    ClassLine = ""
                    ClassLine = ClassLine & objReader.ReadLine()
                    cmbClass.Items.Add(ClassLine)
                    GroupChoice.Items.Add(ClassLine)

                Loop
                'If file does not exist then,
            Else
                'Notify user.
                MsgBox("File Does Not Exist")
            End If


            'Read the Room file into the dropdown box.
            'If the file path exists then,
            If System.IO.File.Exists(RoomFileName) = True Then
                Dim objReader As New System.IO.StreamReader(RoomFileName)
                'Display text,
                Do While objReader.Peek() <> -1
                    RoomLine = ""
                    RoomLine = RoomLine & objReader.ReadLine()
                    cmbRoom.Items.Add(RoomLine)
                    RoomChoice.Items.Add(RoomLine)
                Loop
                'If file does not exist then,
            Else
                'Notify user.
                MsgBox("File Does Not Exist")
            End If

            'Read the Module file into the dropdown box.
            'If the file path exists then,
            If System.IO.File.Exists(ModuleFileName) = True Then
                Dim objReader As New System.IO.StreamReader(ModuleFileName)
                'Display text,
                Do While objReader.Peek() <> -1
                    ModuleLine = ""
                    ModuleLine = ModuleLine & objReader.ReadLine()
                    cmbModule.Items.Add(ModuleLine)
                Loop

            Else
                'Notify user.
                MsgBox("File Does Not Exist")


            End If

            '-----------------------------------------------------------------
            'TESTING PURPOSES
            cmbClass.SelectedIndex = 0
            cmbDay.SelectedIndex = 0
            cmbLecturer.SelectedIndex = 0
            cmbModule.SelectedIndex = 0
            cmbRoom.SelectedIndex = 0
            cmbTimeStart.SelectedIndex = 0
            cmbTimeFinish.SelectedIndex = 5
            LectChoice.SelectedIndex = 0
            RoomChoice.SelectedIndex = 0
            GroupChoice.SelectedIndex = 0

            '-------------------------------------------------------------------
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        m_timetable.showGroupLessons(TableLayoutPanel1, GroupChoice.SelectedItem.ToString)
        m_timetable.showLecturerLessons(TableLayoutPanel2, LectChoice.SelectedItem.ToString)
        m_timetable.showRoomLessons(TableLayoutPanel3, RoomChoice.SelectedItem.ToString)

    End Sub

    Private Sub lstLesson_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLesson.SelectedIndexChanged

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim fileLesson As String = "Files\lessons.txt"
        If System.IO.File.Exists(fileLesson) = True Then
            ''Open the lesson file
            Dim writer As New IO.StreamWriter(fileLesson)
            'Loop through the listbox reading each line to file.
            m_timetable.saveData(writer)
            'Close the stream writer
            writer.Close()
        Else
            MsgBox("File Does Not Exist")
        End If
    End Sub
    'clears the combo boxes
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        cmbClass.SelectedIndex = -1
        cmbDay.SelectedIndex = -1
        cmbLecturer.SelectedIndex = -1
        cmbModule.SelectedIndex = -1
        cmbRoom.SelectedIndex = -1
        cmbTimeFinish.SelectedIndex = -1
        cmbTimeStart.SelectedIndex = -1
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        m_timetable.removeData(lstLesson.SelectedIndex, lstLesson)
    End Sub

    Private Sub lstLesson_MouseClick(sender As Object, e As EventArgs)
        m_timetable.showSelected(lstLesson.SelectedIndex, lstLesson)
    End Sub

End Class
