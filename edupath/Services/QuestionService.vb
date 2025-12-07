' ============================================
' Service: QuestionService
' Business Logic untuk pertanyaan kuesioner
' ============================================

Imports OccuPath.Data
Imports OccuPath.Models
Imports OccuPath.Core

Namespace Services
    ''' <summary>
    ''' Service untuk mengelola pertanyaan dan jawaban
    ''' </summary>
    Public Class QuestionService
        Private ReadOnly _questionRepository As New QuestionRepository()
        Private ReadOnly _profileRepository As New StudentProfileRepository()

        ''' <summary>
        ''' Mengambil semua pertanyaan Kategori A
        ''' </summary>
        Public Function GetKategoriAQuestions() As List(Of Question)
            Return _questionRepository.GetKategoriA()
        End Function

        ''' <summary>
        ''' Mengambil semua pertanyaan Kategori B
        ''' </summary>
        Public Function GetKategoriBQuestions() As List(Of Question)
            Return _questionRepository.GetKategoriB()
        End Function

        ''' <summary>
        ''' Mengambil semua pertanyaan Kategori C
        ''' </summary>
        Public Function GetKategoriCQuestions() As List(Of Question)
            Return _questionRepository.GetKategoriC()
        End Function

        ''' <summary>
        ''' Menyimpan jawaban Kategori A ke StudentProfile
        ''' </summary>
        Public Sub SaveKategoriAAnswers(userId As Integer, answers As Dictionary(Of String, QuestionOption))
            Dim profile As New StudentProfile() With {
                .UserId = userId
            }

            ' Map answers ke profile berdasarkan question code
            For Each kvp In answers
                Dim code = kvp.Key
                Dim answer = kvp.Value

                Select Case code
                    Case "F_A1"
                        profile.JenisKelamin = MapJenisKelamin(answer.Text)
                    Case "F_A2"
                        profile.StatusPendidikan = MapStatusPendidikan(answer.Text)
                    Case "F_A3"
                        profile.ProgramStudi = answer.Text
                    Case "F_A4"
                        profile.Semester = answer.Value
                    Case "F_A5"
                        profile.StatusMahasiswa = answer.Text
                    Case "F_A6"
                        profile.LatarBelakang = answer.Text
                    Case "F_A7"
                        profile.AlasanMemilihProdi = MapAlasanProdi(answer.Text)
                    Case "F_A8"
                        profile.TujuanKuliah = MapTujuanKuliah(answer.Text)
                    Case "F_A9"
                        profile.MetodeBelajar = answer.Text
                    Case "F_A10"
                        profile.MotivasiBelajar = answer.Value
                End Select
            Next

            ' Simpan ke database
            _profileRepository.SaveOrUpdate(profile)
        End Sub

        ''' <summary>
        ''' Mengambil profil mahasiswa yang sudah tersimpan
        ''' </summary>
        Public Function GetStudentProfile(userId As Integer) As StudentProfile
            Return _profileRepository.FindByUserId(userId)
        End Function

        ' ==========================================
        ' Mapping functions untuk ENUM database
        ' ==========================================

        Private Function MapJenisKelamin(text As String) As String
            If text.Contains("Laki") Then Return "L"
            Return "P"
        End Function

        Private Function MapStatusPendidikan(text As String) As String
            If text.Contains("Aktif") AndAlso Not text.Contains("Non") Then Return "Aktif"
            If text.Contains("Non") OrElse text.Contains("Drop") Then Return "Non-aktif"
            If text.Contains("Cuti") Then Return "Cuti"
            Return "Aktif"
        End Function

        Private Function MapAlasanProdi(text As String) As String
            If text.Contains("Minat") Then Return "Minat pribadi"
            If text.Contains("Prospek") Then Return "Peluang kerja"
            If text.Contains("Orang Tua") OrElse text.Contains("Keluarga") Then Return "Saran keluarga"
            If text.Contains("Teman") Then Return "Mengikuti teman"
            Return "Lainnya"
        End Function

        Private Function MapTujuanKuliah(text As String) As String
            If text.Contains("Karir") Then Return "Meningkatkan karir"
            If text.Contains("Ilmu") OrElse text.Contains("Skill") Then Return "Mendapatkan skill teknis"
            If text.Contains("Gelar") Then Return "Mencari prestasi"
            Return "Tidak yakin"
        End Function
    End Class
End Namespace
