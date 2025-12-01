Public Class Form5
    Private userName As String

    Public Sub New(username As String)
        InitializeComponent()
        Me.userName = username
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display welcome message with username
        lblWelcome.Text = "Selamat datang, " & userName & "!"
    End Sub

    Private Sub btnStartTest_Click(sender As Object, e As EventArgs) Handles btnStartTest.Click
        ' Open Category A form (Data Diri)
        Dim kategoriAForm As New FormKategoriA(userName)
        Dim result = kategoriAForm.ShowDialog()
        
        If result = DialogResult.OK Then
            ' Continue to next category or test
            MessageBox.Show("Data kategori A berhasil disimpan. Lanjut ke kategori berikutnya...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' TODO: Open next category form
        End If
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        ' Show test history
        MessageBox.Show("Menampilkan riwayat tes...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' TODO: Implement history view
    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        ' Show user profile
        MessageBox.Show("Profil: " & userName, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' TODO: Implement profile view
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Logout and return to landing page
        Dim result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
            Dim landingPage As New Form1()
            landingPage.Show()
        End If
    End Sub
End Class
