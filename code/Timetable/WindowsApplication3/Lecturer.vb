Public Class Lecturer
    Private m_lecturerName As String

    Public Sub New(ByVal lName As String)
        m_lecturerName = lName
    End Sub

    ReadOnly Property lName() As String
        Get
            Return m_lecturerName
        End Get
    End Property
End Class
