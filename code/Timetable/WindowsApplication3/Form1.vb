Public Class frmMain
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim Lecturer As String
        Dim Group As String
        Dim Subject As String
        Dim Room As String
        Dim Day As String
        Dim TimeStart As Integer
        Dim TimeEnd As Integer

        Dim intCount As Byte

        Dim LessonArray(0 To 6) As String
        'Varibles store lesson data
        Lecturer = cmbLecturer.SelectedItem.ToString

        'Add selected items to variables
        Group = cmbClass.SelectedItem.ToString
        Subject = cmbModule.SelectedItem.ToString
        Room = cmbRoom.SelectedItem.ToString
        Day = cmbDay.SelectedItem.ToString
        TimeStart = cmbTimeStart.SelectedItem
        TimeEnd = cmbTimeFinish.SelectedItem

        'Array
        LessonArray(0) = Lecturer
        LessonArray(1) = Group
        LessonArray(2) = Subject
        LessonArray(3) = Room
        LessonArray(4) = Day
        LessonArray(5) = TimeStart
        LessonArray(6) = TimeEnd

        'List in Listbox
        For intCount = 0 To 6
            'MessageBox.Show(LessonArray(intCount))
            lstLesson.Items.Add(LessonArray(intCount))
        Next intCount

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Define the pathways
        Dim LecturerFileName As String = "\\Win-L410-Server\Netusers\dpeacher\My Documents\Test Text Files\lecturer.txt"
        Dim ClassFileName As String = "\\Win-L410-Server\Netusers\dpeacher\My Documents\Test Text Files\class.txt"
        Dim RoomFileName As String = "\\Win-L410-Server\Netusers\dpeacher\My Documents\Test Text Files\room.txt"
        Dim ModuleFileName As String = "\\Win-L410-Server\Netusers\dpeacher\My Documents\Test Text Files\module.txt"

        'Variables to save the list of data to.
        Dim LecturerLine As String
        Dim ClassLine As String
        Dim RoomLine As String
        Dim ModuleLine As String

        'Read the lecturer file into the dropdown box.
        'If the file path exists then,
        If System.IO.File.Exists(LecturerFileName) = True Then
            Dim objReader As New System.IO.StreamReader(LecturerFileName)
            'Display text,
            Do While objReader.Peek() <> -1
                LecturerLine = ""
                LecturerLine = LecturerLine & objReader.ReadLine() & vbNewLine
                cmbLecturer.Items.Add(LecturerLine)
            Loop
            'If file does not exist then,
        Else
            'Notify user.
            MsgBox("File Does Not Exist")
        End If

        'Read the Class file into the dropdown box.
        'If the file path exists then,
        If System.IO.File.Exists(ClassFileName) = True Then
            Dim objReader As New System.IO.StreamReader(ClassFileName)
            'Display text,
            Do While objReader.Peek() <> -1
                ClassLine = ""
                ClassLine = ClassLine & objReader.ReadLine() & vbNewLine
                cmbClass.Items.Add(ClassLine)
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
                RoomLine = RoomLine & objReader.ReadLine() & vbNewLine
                cmbRoom.Items.Add(RoomLine)
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
                ModuleLine = ModuleLine & objReader.ReadLine() & vbNewLine
                cmbModule.Items.Add(ModuleLine)
            Loop
            'If file does not exist then,
        Else
            'Notify user.
            MsgBox("File Does Not Exist")
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim mP As Panel
        mP = New Panel()
        mP.BackColor = Color.Aquamarine
        TableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        TableLayoutPanel1.Controls.Add(mP, 2, 2)
        TableLayoutPanel1.SetColumnSpan(mP, 8)

        Dim mD As Panel
        mD = New Panel()
        mD.BackColor = Color.Red
        TableLayoutPanel1.Controls.Add(mD, 10, 3)
        TableLayoutPanel1.SetColumnSpan(mD, 4)

        Dim mC As Panel
        mC = New Panel()
        mC.BackColor = Color.Red
        TableLayoutPanel1.Controls.Add(mC, 15, 4)
        TableLayoutPanel1.SetColumnSpan(mC, 4)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim fileLesson As String = "\\Win-L410-Server\Netusers\scook\Desktop\GitHub\timetable\code\Test Text Files\lessons.txt"

        If System.IO.File.Exists(fileLesson) = True Then

            'Open the lesson file
            Dim writer As New IO.StreamWriter(fileLesson)

            'Now we want to loop through each line in the ListBox
            'We use .Count - 1 because the index starts at 0 (zero)
            'so if we go to the actual count we will get an
            'IndexOutOfRangeException
            For i As Integer = 0 To lstLesson.Items.Count - 1
                'Now for each line we call WriteLine to write
                'the item to our text file
                writer.WriteLine(lstLesson.Items.Item(i))
            Next

            'Now we need to close our StreamWriter to
            'free up the resources
            writer.Close()

        Else

            MsgBox("File Does Not Exist")

        End If

        
    End Sub
End Class
