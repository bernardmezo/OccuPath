' ============================================
' Model: StudentProfile
' Representasi data profil mahasiswa (Kategori A)
' ============================================

Namespace Models
    Public Class StudentProfile
        ' Primary Key
        Public Property Id As Integer
        Public Property UserId As Integer

        ' Kategori A - Data Diri
        Public Property JenisKelamin As String          ' F_A1: L/P
        Public Property StatusPendidikan As String      ' F_A2: Aktif/Non-aktif/Cuti
        Public Property ProgramStudi As String          ' F_A3: TI/TMD/TMJ
        Public Property Semester As Integer             ' F_A4: 1-6, 7=6+
        Public Property StatusMahasiswa As String       ' F_A5: Reguler/Paralel/Eksekutif
        Public Property LatarBelakang As String         ' F_A6: SMA IPA/IPS/SMK
        Public Property AlasanMemilihProdi As String    ' F_A7
        Public Property TujuanKuliah As String          ' F_A8
        Public Property MetodeBelajar As String         ' F_A9: Diskusi/Membaca/Praktik/Online
        Public Property MotivasiBelajar As Integer      ' F_A10: 1-5

        Public Property CreatedAt As DateTime
        Public Property UpdatedAt As DateTime

        Public Sub New()
        End Sub

        ' Convert semester integer to display string
        Public Function GetSemesterDisplay() As String
            If Semester > 6 Then Return "Semester 6+"
            Return $"Semester {Semester}"
        End Function

        ' Convert semester to database ENUM value
        Public Function GetSemesterDbValue() As String
            If Semester > 6 Then Return "6+"
            Return Semester.ToString()
        End Function
    End Class
End Namespace
