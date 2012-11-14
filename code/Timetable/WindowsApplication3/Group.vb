Public Class Group
    Private m_group As String

    Public Sub New(ByVal cName As String)
        m_group = cName
    End Sub

    ReadOnly Property gName() As String
        Get
            Return m_group
        End Get
    End Property
End Class
