Public Class Modules

    Private m_moduleCode As String

    Public Sub New(ByVal moduleCode As String)
        m_moduleCode = moduleCode
    End Sub

    ReadOnly Property moduleCode() As String
        Get
            Return m_moduleCode
        End Get
    End Property
End Class
