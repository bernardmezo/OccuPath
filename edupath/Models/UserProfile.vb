Public Class UserProfile
    ' Singleton instance
    Public Shared Current As New UserProfile()

    ' User Identity (dari tabel users)
    Public Property UserID As Integer
    Public Property Username As String
    Public Property NamaLengkap As String
    Public Property Email As String

    ' Fact Codes Mapping - Kategori A (Data Diri)
    Public Property F_A1_JenisKelamin As String
    Public Property F_A2_StatusPendidikan As String
    Public Property F_A3_ProgramStudi As String
    Public Property F_A4_Semester As Integer
    Public Property F_A5_StatusMahasiswa As String
    Public Property F_A6_LatarBelakang As String
    Public Property F_A7_AlasanMasuk As String
    Public Property F_A8_TujuanKuliah As String
    Public Property F_A9_MetodeBelajar As String
    Public Property F_A10_MotivasiBelajar As Integer ' 1-5 scale

    ' Helper to reset Kategori A data only
    Public Sub Reset()
        F_A1_JenisKelamin = String.Empty
        F_A2_StatusPendidikan = String.Empty
        F_A3_ProgramStudi = String.Empty
        F_A4_Semester = 0
        F_A5_StatusMahasiswa = String.Empty
        F_A6_LatarBelakang = String.Empty
        F_A7_AlasanMasuk = String.Empty
        F_A8_TujuanKuliah = String.Empty
        F_A9_MetodeBelajar = String.Empty
        F_A10_MotivasiBelajar = 0
    End Sub

    ' Full reset including user identity (untuk logout)
    Public Sub Logout()
        UserID = 0
        Username = String.Empty
        NamaLengkap = String.Empty
        Email = String.Empty
        Reset()
    End Sub

    ' Check if user is logged in
    Public Function IsLoggedIn() As Boolean
        Return UserID > 0 AndAlso Not String.IsNullOrEmpty(Username)
    End Function
End Class
