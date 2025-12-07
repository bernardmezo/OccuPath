' ============================================
' Service: AuthService
' Business Logic untuk autentikasi
' ============================================

Imports OccuPath.Data
Imports OccuPath.Models
Imports OccuPath.Core

Namespace Services
    ''' <summary>
    ''' Service untuk mengelola autentikasi user
    ''' </summary>
    Public Class AuthService
        Private ReadOnly _userRepository As New UserRepository()

        ''' <summary>
        ''' Result dari operasi autentikasi
        ''' </summary>
        Public Class AuthResult
            Public Property Success As Boolean
            Public Property Message As String
            Public Property User As User

            Public Sub New(success As Boolean, message As String, Optional user As User = Nothing)
                Me.Success = success
                Me.Message = message
                Me.User = user
            End Sub
        End Class

        ''' <summary>
        ''' Login dengan username dan password
        ''' </summary>
        Public Function Login(username As String, password As String) As AuthResult
            Try
                ' Cari user
                Dim user = _userRepository.FindByUsername(username)
                If user Is Nothing Then
                    Return New AuthResult(False, "Username tidak ditemukan!")
                End If

                ' Verifikasi password
                Dim inputHash = HashPassword(password)
                If user.PasswordHash <> inputHash Then
                    Return New AuthResult(False, "Password salah!")
                End If

                ' Set current session
                SessionManager.Login(user)

                Return New AuthResult(True, "Login berhasil!", user)

            Catch ex As Exception
                Return New AuthResult(False, $"Error: {ex.Message}")
            End Try
        End Function

        ''' <summary>
        ''' Registrasi user baru
        ''' </summary>
        Public Function Register(username As String, password As String, namaLengkap As String, email As String) As AuthResult
            Try
                ' Validasi username unik
                If _userRepository.ExistsByUsername(username) Then
                    Return New AuthResult(False, "Username sudah digunakan!")
                End If

                ' Validasi email unik
                If _userRepository.ExistsByEmail(email) Then
                    Return New AuthResult(False, "Email sudah terdaftar!")
                End If

                ' Buat user baru
                Dim newUser As New User() With {
                    .Username = username,
                    .PasswordHash = HashPassword(password),
                    .NamaLengkap = namaLengkap,
                    .Email = email
                }

                ' Simpan ke database
                newUser.Id = _userRepository.Create(newUser)

                Return New AuthResult(True, "Registrasi berhasil!", newUser)

            Catch ex As Exception
                Return New AuthResult(False, $"Error: {ex.Message}")
            End Try
        End Function

        ''' <summary>
        ''' Logout user
        ''' </summary>
        Public Sub Logout()
            SessionManager.Logout()
        End Sub

        ''' <summary>
        ''' Hash password menggunakan SHA256
        ''' </summary>
        Private Function HashPassword(password As String) As String
            Using sha256 = System.Security.Cryptography.SHA256.Create()
                Dim bytes = System.Text.Encoding.UTF8.GetBytes(password)
                Dim hash = sha256.ComputeHash(bytes)
                Dim builder As New System.Text.StringBuilder()
                For Each b In hash
                    builder.Append(b.ToString("x2"))
                Next
                Return builder.ToString()
            End Using
        End Function
    End Class
End Namespace
