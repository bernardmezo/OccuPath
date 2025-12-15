Imports MySql.Data.MySqlClient
Imports OccuPath.Core

''' <summary>
''' Form Profile - Halaman profil pengguna
''' </summary>
Public Class FormProfile
    Private _userId As Integer
    Private _username As String

    Public Sub New(userId As Integer, username As String)
        InitializeComponent()
        _userId = userId
        _username = username
    End Sub

    Private Sub FormProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserProfile()
    End Sub

    Private Sub LoadUserProfile()
        Try
            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                ' Load user data from users table
                Dim sqlUser = "SELECT username, full_name, email, created_at FROM users WHERE id = @userId"
                Using cmd As New MySqlCommand(sqlUser, conn)
                    cmd.Parameters.AddWithValue("@userId", _userId)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtUsername.Text = reader.GetString("username")
                            txtFullName.Text = reader.GetString("full_name")
                            txtEmail.Text = If(reader.IsDBNull(reader.GetOrdinal("email")), "", reader.GetString("email"))
                            lblJoinDate.Text = $"Bergabung sejak: {CDate(reader("created_at")):dd MMMM yyyy}"
                            
                            ' Display student info from users table
                            Dim nim = If(reader.IsDBNull(reader.GetOrdinal("nim")), "Belum diisi", reader.GetString("nim"))
                            Dim prodi = If(reader.IsDBNull(reader.GetOrdinal("prodi")), "Belum diisi", reader.GetString("prodi"))
                            Dim semester = If(reader.IsDBNull(reader.GetOrdinal("semester")), "Belum diisi", reader.GetInt32("semester").ToString())
                            
                            lblProgramStudi.Text = $"Program Studi: {prodi}"
                            lblSemester.Text = $"Semester: {semester}"
                            panelProfileData.Visible = True
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        ' Show change password dialog
        Dim oldPassword = InputBox("Masukkan password lama:", "Ganti Password")
        If String.IsNullOrEmpty(oldPassword) Then Return

        Dim newPassword = InputBox("Masukkan password baru (min 6 karakter):", "Ganti Password")
        If String.IsNullOrEmpty(newPassword) OrElse newPassword.Length < 6 Then
            MessageBox.Show("Password baru harus minimal 6 karakter!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmPassword = InputBox("Konfirmasi password baru:", "Ganti Password")
        If newPassword <> confirmPassword Then
            MessageBox.Show("Password konfirmasi tidak cocok!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                ' Verify old password
                Dim sqlVerify = "SELECT password FROM users WHERE id = @userId"
                Using cmd As New MySqlCommand(sqlVerify, conn)
                    cmd.Parameters.AddWithValue("@userId", _userId)
                    Dim storedPassword = cmd.ExecuteScalar()?.ToString()

                    Dim oldPasswordHash = DatabaseConnection.HashPassword(oldPassword)
                    If storedPassword <> oldPassword AndAlso storedPassword <> oldPasswordHash Then
                        MessageBox.Show("Password lama salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                ' Update password
                Dim sqlUpdate = "UPDATE users SET password = @newPassword WHERE id = @userId"
                Using cmd As New MySqlCommand(sqlUpdate, conn)
                    cmd.Parameters.AddWithValue("@newPassword", DatabaseConnection.HashPassword(newPassword))
                    cmd.Parameters.AddWithValue("@userId", _userId)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Password berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateProfile.Click
        Try
            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                ' Update user data
                Dim sqlUpdate = "UPDATE users SET full_name = @fullName, email = @email WHERE id = @userId"
                Using cmd As New MySqlCommand(sqlUpdate, conn)
                    cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@userId", _userId)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Profil berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadUserProfile()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error updating profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
