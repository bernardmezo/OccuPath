' ============================================
' Core: AppConstants
' Konstanta aplikasi
' ============================================

Namespace Core
    ''' <summary>
    ''' Konstanta yang digunakan di seluruh aplikasi
    ''' </summary>
    Public NotInheritable Class AppConstants
        ' Nama aplikasi
        Public Const APP_NAME As String = "OccuPath"
        Public Const APP_FULL_NAME As String = "OccuPath - Sistem Pakar Profil Lulusan"
        Public Const APP_VERSION As String = "1.0.0"

        ' Kategori pertanyaan
        Public Const KATEGORI_A As String = "A"     ' Data Diri
        Public Const KATEGORI_B As String = "B"     ' Data Akademis
        Public Const KATEGORI_C As String = "C"     ' Data Karakter

        ' Jumlah pertanyaan per kategori
        Public Const KATEGORI_A_COUNT As Integer = 10
        Public Const KATEGORI_B_COUNT As Integer = 10
        Public Const KATEGORI_C_COUNT As Integer = 45

        ' Validasi
        Public Const MIN_PASSWORD_LENGTH As Integer = 6
        Public Const MIN_USERNAME_LENGTH As Integer = 3
        Public Const MAX_USERNAME_LENGTH As Integer = 50

        ' Pesan
        Public NotInheritable Class Messages
            Public Const LOGIN_SUCCESS As String = "Login berhasil!"
            Public Const LOGIN_FAILED As String = "Login gagal. Periksa username dan password Anda."
            Public Const REGISTER_SUCCESS As String = "Registrasi berhasil! Silakan login."
            Public Const DB_CONNECTION_ERROR As String = "Tidak dapat terhubung ke database. Pastikan MySQL sudah berjalan."
            Public Const VALIDATION_REQUIRED As String = "Harap lengkapi semua field yang diperlukan."
            Public Const SAVE_SUCCESS As String = "Data berhasil disimpan!"
            Public Const SAVE_FAILED As String = "Gagal menyimpan data."
        End Class

        ' Warna UI
        Public NotInheritable Class Colors
            Public Shared ReadOnly PRIMARY_BLUE As Color = Color.FromArgb(45, 125, 210)
            Public Shared ReadOnly SUCCESS_GREEN As Color = Color.FromArgb(76, 175, 80)
            Public Shared ReadOnly WARNING_YELLOW As Color = Color.FromArgb(255, 193, 7)
            Public Shared ReadOnly DANGER_RED As Color = Color.FromArgb(239, 83, 80)
            Public Shared ReadOnly BACKGROUND As Color = Color.FromArgb(245, 248, 252)
            Public Shared ReadOnly TEXT_DARK As Color = Color.FromArgb(60, 60, 60)
            Public Shared ReadOnly TEXT_LIGHT As Color = Color.FromArgb(100, 100, 100)
        End Class
    End Class
End Namespace
