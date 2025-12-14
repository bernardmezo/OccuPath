Imports MySql.Data.MySqlClient

''' <summary>
''' Form untuk edit user (Admin only)
''' </summary>
Public Class FormUserEdit
    Private _userId As Integer

    Public Sub New(userId As Integer, username As String, fullName As String, email As String,
                   nim As String, prodi As String, semester As Integer, role As String)
        InitializeComponent()
        _userId = userId
        
        ' Set data
        txtUsername.Text = username
        txtUsername.ReadOnly = True ' Username tidak bisa diubah
        txtFullName.Text = fullName
        txtEmail.Text = email
        txtNIM.Text = nim
        
        ' Setup Prodi ComboBox
        cmbProdi.Items.Clear()
        cmbProdi.Items.AddRange(New String() {"TI", "TMD", "TMJ"})
        cmbProdi.SelectedItem = prodi
        
        ' Setup Semester
        nudSemester.Minimum = 1
        nudSemester.Maximum = 14
        nudSemester.Value = semester
        
        ' Setup Role ComboBox
        cmbRole.Items.Clear()
        cmbRole.Items.AddRange(New String() {"student", "admin"})
        cmbRole.SelectedItem = role
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Nama Lengkap harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If

        Try
            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                ' Update user (password optional)
                Dim sql As String
                If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                    ' Update tanpa password
                    sql = "UPDATE users SET full_name = @fullName, email = @email, nim = @nim, " &
                          "prodi = @prodi, semester = @semester, role = @role WHERE id = @userId"
                Else
                    ' Update dengan password
                    If txtPassword.Text.Length < 6 Then
                        MessageBox.Show("Password minimal 6 karakter!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtPassword.Focus()
                        Return
                    End If
                    sql = "UPDATE users SET full_name = @fullName, email = @email, nim = @nim, " &
                          "prodi = @prodi, semester = @semester, role = @role, password = @password WHERE id = @userId"
                End If

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@userId", _userId)
                    cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim()))
                    cmd.Parameters.AddWithValue("@nim", If(String.IsNullOrWhiteSpace(txtNIM.Text), DBNull.Value, txtNIM.Text.Trim()))
                    cmd.Parameters.AddWithValue("@prodi", cmbProdi.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@semester", nudSemester.Value)
                    cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString())
                    
                    If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                        cmd.Parameters.AddWithValue("@password", DatabaseConnection.HashPassword(txtPassword.Text))
                    End If

                    cmd.ExecuteNonQuery()
                End Using

                Me.DialogResult = DialogResult.OK
                Me.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Kesalahan mengupdate user: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
