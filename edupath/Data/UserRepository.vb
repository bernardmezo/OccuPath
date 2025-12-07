' ============================================
' Repository: UserRepository
' Data Access Layer untuk tabel 'users'
' ============================================

Imports MySql.Data.MySqlClient
Imports OccuPath.Models

Namespace Data
    Public Class UserRepository
        ''' <summary>
        ''' Mencari user berdasarkan username
        ''' </summary>
        Public Function FindByUsername(username As String) As User
            Dim query As String = "SELECT id_user, username, password_hash, nama_lengkap, email, created_at FROM users WHERE username = @username"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New User() With {
                                .Id = reader.GetInt32("id_user"),
                                .Username = reader.GetString("username"),
                                .PasswordHash = reader.GetString("password_hash"),
                                .NamaLengkap = reader.GetString("nama_lengkap"),
                                .Email = reader.GetString("email"),
                                .CreatedAt = reader.GetDateTime("created_at")
                            }
                        End If
                    End Using
                End Using
            End Using

            Return Nothing
        End Function

        ''' <summary>
        ''' Mencari user berdasarkan ID
        ''' </summary>
        Public Function FindById(id As Integer) As User
            Dim query As String = "SELECT id_user, username, password_hash, nama_lengkap, email, created_at FROM users WHERE id_user = @id"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New User() With {
                                .Id = reader.GetInt32("id_user"),
                                .Username = reader.GetString("username"),
                                .PasswordHash = reader.GetString("password_hash"),
                                .NamaLengkap = reader.GetString("nama_lengkap"),
                                .Email = reader.GetString("email"),
                                .CreatedAt = reader.GetDateTime("created_at")
                            }
                        End If
                    End Using
                End Using
            End Using

            Return Nothing
        End Function

        ''' <summary>
        ''' Cek apakah username sudah ada
        ''' </summary>
        Public Function ExistsByUsername(username As String) As Boolean
            Dim query As String = "SELECT COUNT(*) FROM users WHERE username = @username"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Cek apakah email sudah ada
        ''' </summary>
        Public Function ExistsByEmail(email As String) As Boolean
            Dim query As String = "SELECT COUNT(*) FROM users WHERE email = @email"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@email", email)
                    Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Membuat user baru dan mengembalikan ID
        ''' </summary>
        Public Function Create(user As User) As Integer
            Dim query As String = "INSERT INTO users (username, password_hash, nama_lengkap, email) VALUES (@username, @password, @nama, @email); SELECT LAST_INSERT_ID();"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", user.Username)
                    cmd.Parameters.AddWithValue("@password", user.PasswordHash)
                    cmd.Parameters.AddWithValue("@nama", user.NamaLengkap)
                    cmd.Parameters.AddWithValue("@email", user.Email)

                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Update data user
        ''' </summary>
        Public Sub Update(user As User)
            Dim query As String = "UPDATE users SET nama_lengkap = @nama, email = @email WHERE id_user = @id"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", user.Id)
                    cmd.Parameters.AddWithValue("@nama", user.NamaLengkap)
                    cmd.Parameters.AddWithValue("@email", user.Email)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub
    End Class
End Namespace
