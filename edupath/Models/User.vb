' ============================================
' Model: User
' Representasi data user dari tabel 'users'
' ============================================

Namespace Models
    Public Class User
        Public Property Id As Integer
        Public Property Username As String
        Public Property PasswordHash As String
        Public Property NamaLengkap As String
        Public Property Email As String
        Public Property CreatedAt As DateTime
        Public Property UpdatedAt As DateTime

        Public Sub New()
        End Sub

        Public Sub New(id As Integer, username As String, namaLengkap As String, email As String)
            Me.Id = id
            Me.Username = username
            Me.NamaLengkap = namaLengkap
            Me.Email = email
        End Sub
    End Class
End Namespace
