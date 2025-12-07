' ============================================
' Core: SessionManager
' Mengelola session user yang sedang login
' ============================================

Imports OccuPath.Models

Namespace Core
    ''' <summary>
    ''' Singleton untuk mengelola session user aktif
    ''' </summary>
    Public NotInheritable Class SessionManager
        ' Current logged in user
        Private Shared _currentUser As User = Nothing

        ' Student profile data (dikumpulkan dari kuesioner)
        Private Shared _studentProfile As StudentProfile = Nothing

        ''' <summary>
        ''' User yang sedang login
        ''' </summary>
        Public Shared ReadOnly Property CurrentUser As User
            Get
                Return _currentUser
            End Get
        End Property

        ''' <summary>
        ''' Profile mahasiswa (data kuesioner)
        ''' </summary>
        Public Shared Property StudentProfile As StudentProfile
            Get
                If _studentProfile Is Nothing Then
                    _studentProfile = New StudentProfile()
                    If IsLoggedIn Then
                        _studentProfile.UserId = _currentUser.Id
                    End If
                End If
                Return _studentProfile
            End Get
            Set(value As StudentProfile)
                _studentProfile = value
            End Set
        End Property

        ''' <summary>
        ''' Cek apakah ada user yang login
        ''' </summary>
        Public Shared ReadOnly Property IsLoggedIn As Boolean
            Get
                Return _currentUser IsNot Nothing AndAlso _currentUser.Id > 0
            End Get
        End Property

        ''' <summary>
        ''' ID user yang sedang login
        ''' </summary>
        Public Shared ReadOnly Property UserId As Integer
            Get
                If IsLoggedIn Then Return _currentUser.Id
                Return 0
            End Get
        End Property

        ''' <summary>
        ''' Nama lengkap user yang sedang login
        ''' </summary>
        Public Shared ReadOnly Property UserName As String
            Get
                If IsLoggedIn Then Return _currentUser.NamaLengkap
                Return ""
            End Get
        End Property

        ''' <summary>
        ''' Set user yang login
        ''' </summary>
        Public Shared Sub Login(user As User)
            _currentUser = user
            _studentProfile = New StudentProfile() With {
                .UserId = user.Id
            }
        End Sub

        ''' <summary>
        ''' Logout user
        ''' </summary>
        Public Shared Sub Logout()
            _currentUser = Nothing
            _studentProfile = Nothing
        End Sub

        ''' <summary>
        ''' Reset student profile data (untuk mulai tes baru)
        ''' </summary>
        Public Shared Sub ResetProfile()
            If IsLoggedIn Then
                _studentProfile = New StudentProfile() With {
                    .UserId = _currentUser.Id
                }
            Else
                _studentProfile = New StudentProfile()
            End If
        End Sub
    End Class
End Namespace
