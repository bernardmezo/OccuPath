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
            ' MVP1 schema: uses 'password' and 'full_name' columns, 'id' not 'id_user'
            Dim query As String = "SELECT id, username, password, full_name, email, created_at FROM users WHERE username = @username"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New User() With {
                                .Id = reader.GetInt32("id"),
                                .Username = reader.GetString("username"),
                                .PasswordHash = reader.GetString("password"),
                                .NamaLengkap = reader.GetString("full_name"),
                                .Email = If(reader.IsDBNull(reader.GetOrdinal("email")), "", reader.GetString("email")),
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
            ' MVP1 schema: uses 'password' and 'full_name' columns, 'id' not 'id_user'
            Dim query As String = "SELECT id, username, password, full_name, email, created_at FROM users WHERE id = @id"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New User() With {
                                .Id = reader.GetInt32("id"),
                                .Username = reader.GetString("username"),
                                .PasswordHash = reader.GetString("password"),
                                .NamaLengkap = reader.GetString("full_name"),
                                .Email = If(reader.IsDBNull(reader.GetOrdinal("email")), "", reader.GetString("email")),
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
        ''' Membuat user baru dan mengembalikan ID (Compatible with MVP1 schema)
        ''' </summary>
        Public Function Create(user As User) As Integer
            ' MVP1 schema: uses 'password' and 'full_name' columns
            Dim query As String = "INSERT INTO users (username, password, full_name, email, role) VALUES (@username, @password, @nama, @email, 'student'); SELECT LAST_INSERT_ID();"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", user.Username)
                    cmd.Parameters.AddWithValue("@password", user.PasswordHash) ' Already hashed by AuthService
                    cmd.Parameters.AddWithValue("@nama", user.NamaLengkap)
                    cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(user.Email), DBNull.Value, CObj(user.Email)))

                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Update data user (Compatible with MVP1 schema)
        ''' </summary>
        Public Sub Update(user As User)
            ' MVP1 schema: uses 'full_name' column and 'id' not 'id_user'
            Dim query As String = "UPDATE users SET full_name = @nama, email = @email WHERE id = @id"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", user.Id)
                    cmd.Parameters.AddWithValue("@nama", user.NamaLengkap)
                    cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(user.Email), DBNull.Value, CObj(user.Email)))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub
    End Class
End Namespace
