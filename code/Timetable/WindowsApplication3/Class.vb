Public Class Class
    Private m_class As String

    Public Sub New(ByVal cName As String)
        m_class = cName
    End Sub

    ReadOnly Property name() As String
        Get
            Return m_class
        End Get
    End Property
End Class
