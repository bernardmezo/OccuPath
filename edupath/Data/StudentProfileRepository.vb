' ============================================
' Repository: StudentProfileRepository
' Data Access Layer untuk tabel 'student_profiles'
' ============================================

Imports MySql.Data.MySqlClient
Imports OccuPath.Models

Namespace Data
    Public Class StudentProfileRepository
        ''' <summary>
        ''' Mencari profil berdasarkan User ID
        ''' </summary>
        Public Function FindByUserId(userId As Integer) As StudentProfile
            Dim query As String = "SELECT * FROM student_profiles WHERE id_user = @userId"

            Using conn = DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return MapFromReader(reader)
                        End If
                    End Using
                End Using
            End Using

            Return Nothing
        End Function

        ''' <summary>
        ''' Cek apakah profil sudah ada untuk user
        ''' </summary>
        Public Function ExistsByUserId(userId As Integer) As Boolean
            Dim query As String = "SELECT COUNT(*) FROM student_profiles WHERE id_user = @userId"

            Using conn = DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)
                    Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Simpan atau update profil (UPSERT)
        ''' </summary>
        Public Sub SaveOrUpdate(profile As StudentProfile)
            Dim query As String = "INSERT INTO student_profiles (" &
                                  "id_user, jenis_kelamin, status_pendidikan, program_studi, semester, " &
                                  "status_mahasiswa, latar_belakang, alasan_memilih_prodi, tujuan_kuliah, " &
                                  "metode_belajar, motivasi_belajar) " &
                                  "VALUES (@userId, @jk, @statusPend, @prodi, @semester, @statusMhs, " &
                                  "@latarBelakang, @alasan, @tujuan, @metode, @motivasi) " &
                                  "ON DUPLICATE KEY UPDATE " &
                                  "jenis_kelamin = VALUES(jenis_kelamin), " &
                                  "status_pendidikan = VALUES(status_pendidikan), " &
                                  "program_studi = VALUES(program_studi), " &
                                  "semester = VALUES(semester), " &
                                  "status_mahasiswa = VALUES(status_mahasiswa), " &
                                  "latar_belakang = VALUES(latar_belakang), " &
                                  "alasan_memilih_prodi = VALUES(alasan_memilih_prodi), " &
                                  "tujuan_kuliah = VALUES(tujuan_kuliah), " &
                                  "metode_belajar = VALUES(metode_belajar), " &
                                  "motivasi_belajar = VALUES(motivasi_belajar)"

            Using conn = DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", profile.UserId)
                    cmd.Parameters.AddWithValue("@jk", profile.JenisKelamin)
                    cmd.Parameters.AddWithValue("@statusPend", profile.StatusPendidikan)
                    cmd.Parameters.AddWithValue("@prodi", profile.ProgramStudi)
                    cmd.Parameters.AddWithValue("@semester", profile.GetSemesterDbValue())
                    cmd.Parameters.AddWithValue("@statusMhs", profile.StatusMahasiswa)
                    cmd.Parameters.AddWithValue("@latarBelakang", profile.LatarBelakang)
                    cmd.Parameters.AddWithValue("@alasan", profile.AlasanMemilihProdi)
                    cmd.Parameters.AddWithValue("@tujuan", profile.TujuanKuliah)
                    cmd.Parameters.AddWithValue("@metode", profile.MetodeBelajar)
                    cmd.Parameters.AddWithValue("@motivasi", profile.MotivasiBelajar)

                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Map data dari reader ke object
        ''' </summary>
        Private Function MapFromReader(reader As MySqlDataReader) As StudentProfile
            Dim profile As New StudentProfile() With {
                .Id = reader.GetInt32("id_profile"),
                .UserId = reader.GetInt32("id_user"),
                .JenisKelamin = reader.GetString("jenis_kelamin"),
                .StatusPendidikan = reader.GetString("status_pendidikan"),
                .ProgramStudi = reader.GetString("program_studi"),
                .StatusMahasiswa = reader.GetString("status_mahasiswa"),
                .LatarBelakang = reader.GetString("latar_belakang"),
                .AlasanMemilihProdi = reader.GetString("alasan_memilih_prodi"),
                .TujuanKuliah = reader.GetString("tujuan_kuliah"),
                .MetodeBelajar = reader.GetString("metode_belajar"),
                .MotivasiBelajar = reader.GetInt32("motivasi_belajar")
            }

            ' Parse semester
            Dim semStr As String = reader.GetString("semester")
            If semStr = "6+" Then
                profile.Semester = 7
            Else
                profile.Semester = Integer.Parse(semStr)
            End If

            Return profile
        End Function
    End Class
End Namespace
