Imports MySql.Data.MySqlClient

''' <summary>
''' Form to add a new user (Admin only)
''' </summary>
Public Class FormUserAdd
    Private Sub FormUserAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup Prodi ComboBox
        cmbProdi.Items.Clear()
        cmbProdi.Items.AddRange(New String() {"TI", "TMD", "TMJ"})
        cmbProdi.SelectedIndex = 0

        ' Setup Role ComboBox
        cmbRole.Items.Clear()
        cmbRole.Items.AddRange(New String() {"student", "admin"})
        cmbRole.SelectedIndex = 0

        ' Setup Semester NumericUpDown
        nudSemester.Minimum = 1
        nudSemester.Maximum = 14
        nudSemester.Value = 1
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Username harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If txtUsername.Text.Length < 3 Then
            MessageBox.Show("Username minimal 3 karakter!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Password harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        If txtPassword.Text.Length < 6 Then
            MessageBox.Show("Password minimal 6 karakter!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Nama Lengkap harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If

        Try
            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                ' Check if username already exists
                Dim checkSql = "SELECT COUNT(*) FROM users WHERE username = @username"
                Using checkCmd As New MySqlCommand(checkSql, conn)
                    checkCmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                    Dim count = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Username sudah digunakan!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtUsername.Focus()
                        Return
                    End If
                End Using

                ' Insert new user
                Dim sql = "INSERT INTO users (username, password, full_name, email, nim, prodi, semester, role) " &
                          "VALUES (@username, @password, @fullName, @email, @nim, @prodi, @semester, @role)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", DatabaseConnection.HashPassword(txtPassword.Text))
                    cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim()))
                    cmd.Parameters.AddWithValue("@nim", If(String.IsNullOrWhiteSpace(txtNIM.Text), DBNull.Value, txtNIM.Text.Trim()))
                    cmd.Parameters.AddWithValue("@prodi", cmbProdi.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@semester", nudSemester.Value)
                    cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString())

                    cmd.ExecuteNonQuery()
                End Using

                Me.DialogResult = DialogResult.OK
                Me.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Kesalahan menambahkan user: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
