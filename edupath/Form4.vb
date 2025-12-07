' ============================================
' Form4: Login & Register Form
' Menggunakan 3-Layer Architecture
' ============================================

Imports OccuPath.Services
Imports OccuPath.Core
Imports OccuPath.Data

Public Class Form4
    ' Service layer instance
    Private ReadOnly _authService As New AuthService()

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Validate login fields
        If String.IsNullOrWhiteSpace(txtLoginUsername.Text) Then
            MessageBox.Show("Username tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLoginUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtLoginPassword.Text) Then
            MessageBox.Show("Password tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLoginPassword.Focus()
            Return
        End If

        ' Authenticate using AuthService
        Dim result = _authService.Login(txtLoginUsername.Text.Trim(), txtLoginPassword.Text)

        If result.Success Then
            ' SessionManager sudah di-set oleh AuthService.Login()
            ' Untuk backward compatibility, set juga UserProfile lama
            UserProfile.Current.UserID = result.User.Id
            UserProfile.Current.Username = result.User.Username
            UserProfile.Current.NamaLengkap = result.User.NamaLengkap

            MessageBox.Show($"Selamat datang, {result.User.NamaLengkap}!", "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Close this form and open main menu
            Me.DialogResult = DialogResult.OK
            Me.Hide()

            ' Open main menu (Form5) with nama lengkap
            Dim menuForm As New Form5(result.User.NamaLengkap)
            menuForm.ShowDialog()

            ' Close login form after menu closes
            Me.Close()
        Else
            MessageBox.Show(result.Message, "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoginPassword.Clear()
            txtLoginPassword.Focus()
        End If
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' Validate register fields
        If String.IsNullOrWhiteSpace(txtRegName.Text) Then
            MessageBox.Show("Nama lengkap tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtRegUsername.Text) Then
            MessageBox.Show("Username tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegUsername.Focus()
            Return
        End If

        ' Validate username length
        If txtRegUsername.Text.Length < AppConstants.MIN_USERNAME_LENGTH Then
            MessageBox.Show($"Username minimal {AppConstants.MIN_USERNAME_LENGTH} karakter!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegUsername.Focus()
            Return
        End If

        ' Validate username (no spaces, alphanumeric only)
        If txtRegUsername.Text.Contains(" ") Then
            MessageBox.Show("Username tidak boleh mengandung spasi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtRegEmail.Text) Then
            MessageBox.Show("Email tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegEmail.Focus()
            Return
        End If

        ' Validate email format
        If Not txtRegEmail.Text.Contains("@") OrElse Not txtRegEmail.Text.Contains(".") Then
            MessageBox.Show("Format email tidak valid!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegEmail.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtRegPassword.Text) Then
            MessageBox.Show("Password tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegPassword.Focus()
            Return
        End If

        If txtRegPassword.Text.Length < AppConstants.MIN_PASSWORD_LENGTH Then
            MessageBox.Show($"Password minimal {AppConstants.MIN_PASSWORD_LENGTH} karakter!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegPassword.Focus()
            Return
        End If

        If txtRegPassword.Text <> txtRegConfirmPassword.Text Then
            MessageBox.Show("Konfirmasi password tidak cocok!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegConfirmPassword.Focus()
            Return
        End If

        ' Register using AuthService
        Dim result = _authService.Register(
            txtRegUsername.Text.Trim(),
            txtRegPassword.Text,
            txtRegName.Text.Trim(),
            txtRegEmail.Text.Trim()
        )

        If result.Success Then
            MessageBox.Show(AppConstants.Messages.REGISTER_SUCCESS, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Copy username to login tab
            txtLoginUsername.Text = txtRegUsername.Text.Trim()

            ' Clear register fields
            txtRegName.Clear()
            txtRegUsername.Clear()
            txtRegEmail.Clear()
            txtRegPassword.Clear()
            txtRegConfirmPassword.Clear()

            ' Switch to login tab
            tabControl.SelectedTab = tabLogin
            txtLoginPassword.Focus()
        Else
            MessageBox.Show(result.Message, "Registrasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub linkForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkForgotPassword.LinkClicked
        MessageBox.Show("Fitur reset password akan segera tersedia.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Test database connection on load using DbContext
        Dim dbContext As New DbContext()
        If Not dbContext.TestConnection() Then
            MessageBox.Show(AppConstants.Messages.DB_CONNECTION_ERROR, "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' Set form title
        Me.Text = $"{AppConstants.APP_NAME} - Login"

        ' Set initial focus
        txtLoginUsername.Focus()
    End Sub
End Class