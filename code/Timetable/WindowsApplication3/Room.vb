Public Class Room

    Private m_name As String

    Public Sub New(ByVal name As String)
        m_name = name
    End Sub

    ReadOnly Property name() As String
        Get
            Return m_name
        End Get
    End Property

End Class
