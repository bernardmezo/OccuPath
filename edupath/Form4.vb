Public Class Form4
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

        ' TODO: Add actual authentication logic here
        ' For now, just accept any credentials and proceed to menu

        ' Close this form and open main menu
        Me.DialogResult = DialogResult.OK
        Me.Hide()

        ' Open main menu (Form5) with username
        Dim menuForm As New Form5(txtLoginUsername.Text)
        menuForm.ShowDialog()

        ' Close login form after menu closes
        Me.Close()
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

        If txtRegPassword.Text.Length < 6 Then
            MessageBox.Show("Password minimal 6 karakter!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegPassword.Focus()
            Return
        End If

        If txtRegPassword.Text <> txtRegConfirmPassword.Text Then
            MessageBox.Show("Konfirmasi password tidak cocok!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRegConfirmPassword.Focus()
            Return
        End If

        ' TODO: Add actual registration logic here
        MessageBox.Show("Registrasi berhasil! Silakan login dengan akun Anda.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Copy username to login tab
        txtLoginUsername.Text = txtRegUsername.Text

        ' Clear register fields
        txtRegName.Clear()
        txtRegUsername.Clear()
        txtRegEmail.Clear()
        txtRegPassword.Clear()
        txtRegConfirmPassword.Clear()

        ' Switch to login tab
        tabControl.SelectedTab = tabLogin
        txtLoginPassword.Focus()
    End Sub

    Private Sub linkForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkForgotPassword.LinkClicked
        MessageBox.Show("Fitur reset password akan segera tersedia.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set initial focus
        txtLoginUsername.Focus()
    End Sub
End Class