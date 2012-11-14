Public Class Lecturer
    Private m_lName As String

    Public Sub New(ByVal lectureName As String)
        m_lName = lecturerName
    End Sub

    ReadOnly Property name() As String
        Get
            Return m_lname
        End Get
    End Property
End Class
