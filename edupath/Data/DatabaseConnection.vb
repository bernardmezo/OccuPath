Imports MySql.Data.MySqlClient

Public Module DatabaseConnection
    ' ==========================================
    ' KONFIGURASI KONEKSI DATABASE
    ' ==========================================
    ' Sesuaikan nilai-nilai ini dengan konfigurasi MySQL Anda (misal: XAMPP)
    Private Const DB_SERVER As String = "localhost"
    Private Const DB_NAME As String = "db_occupath"
    Private Const DB_USER As String = "root"
    Private Const DB_PASS As String = ""

    ' ==========================================
    ' Helper Classes untuk backward compatibility
    ' ==========================================
    Public Class QuestionData
        Public Property QuestionCode As String
        Public Property QuestionText As String
        Public Property Options As List(Of QuestionOption)
    End Class

    Public Class QuestionOption
        Public Property Id As Integer
        Public Property QuestionCode As String
        Public Property Text As String
        Public Property Value As Integer
        Public Property DisplayOrder As Integer
        Public Property Order As Integer

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    ''' <summary>
    ''' Membentuk Connection String untuk MySQL.
    ''' </summary>
    Private Function GetConnectionString() As String
        ' Connection string dengan konfigurasi lengkap untuk compatibility
        ' Updated for better XAMPP/MySQL compatibility
        Return $"Server={DB_SERVER};Port=3306;Database={DB_NAME};Uid={DB_USER};Pwd={DB_PASS};CharSet=utf8mb4;SslMode=None;AllowPublicKeyRetrieval=True;ConnectionTimeout=30;"
    End Function

    ''' <summary>
    ''' Mengembalikan objek MySqlConnection baru.
    ''' Jangan lupa gunakan 'Using' atau panggil .Close() setelah selesai.
    ''' </summary>
    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(GetConnectionString())
    End Function

    ''' <summary>
    ''' Tes koneksi sederhana untuk memastikan database bisa diakses.
    ''' </summary>
    Public Function TestConnection() As Boolean
        Try
            Using conn As New MySqlConnection(GetConnectionString())
                conn.Open()
                Console.WriteLine("? Database connected successfully!")
                Console.WriteLine($"Server: {DB_SERVER}")
                Console.WriteLine($"Database: {DB_NAME}")
                Return True
            End Using
        Catch ex As MySqlException
            Dim errorMsg As String = "Koneksi database gagal!" & vbCrLf & vbCrLf
            
            Select Case ex.Number
                Case 0
                    errorMsg &= "? MySQL service tidak berjalan!" & vbCrLf & vbCrLf &
                               "SOLUSI:" & vbCrLf &
                               "1. Buka XAMPP Control Panel" & vbCrLf &
                               "2. Klik tombol 'Start' di MySQL" & vbCrLf &
                               "3. Tunggu sampai status jadi hijau"
                               
                Case 1042
                    errorMsg &= "? Tidak bisa connect ke server MySQL!" & vbCrLf & vbCrLf &
                               "SOLUSI:" & vbCrLf &
                               "1. Cek XAMPP MySQL sudah running" & vbCrLf &
                               "2. Cek port 3306 tidak dipakai aplikasi lain"
                               
                Case 1044
                    errorMsg &= "? User 'root' tidak punya akses!" & vbCrLf & vbCrLf &
                               "SOLUSI:" & vbCrLf &
                               "Ganti DB_USER di DatabaseConnection.vb"
                               
                Case 1045
                    errorMsg &= "? Username atau password salah!" & vbCrLf & vbCrLf &
                               "SOLUSI:" & vbCrLf &
                               "Cek DB_USER dan DB_PASS di DatabaseConnection.vb" & vbCrLf &
                               $"Current: username='{DB_USER}', password='{If(String.IsNullOrEmpty(DB_PASS), "(kosong)", "***")}'"
                               
                Case 1049
                    errorMsg &= "? Database 'db_occupath' BELUM DIBUAT!" & vbCrLf & vbCrLf &
                               "SOLUSI:" & vbCrLf &
                               "1. Buka phpMyAdmin (http://localhost/phpmyadmin)" & vbCrLf &
                               "2. Klik tab 'Databases' atau 'New'" & vbCrLf &
                               "3. Database name: db_occupath" & vbCrLf &
                               "4. Collation: utf8_general_ci" & vbCrLf &
                               "5. Klik 'Create'" & vbCrLf &
                               "6. Import file Database_Setup_MVP1.sql" & vbCrLf & vbCrLf &
                               "ATAU jalankan query ini di SQL tab:" & vbCrLf &
                               "CREATE DATABASE db_occupath;"
                               
                Case Else
                    errorMsg &= $"? MySQL Error #{ex.Number}" & vbCrLf & vbCrLf &
                               $"Detail: {ex.Message}"
            End Select
            
            MessageBox.Show(errorMsg, "Error Koneksi Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(errorMsg)
            Return False
            
        Catch ex As Exception
            Dim errorMsg As String = "Error koneksi database!" & vbCrLf & vbCrLf &
                                    $"Type: {ex.GetType().Name}" & vbCrLf &
                                    $"Message: {ex.Message}" & vbCrLf & vbCrLf &
                                    "KEMUNGKINAN:" & vbCrLf &
                                    "1. MySQL Connector belum terinstall" & vbCrLf &
                                    "   Install: MySql.Data via NuGet" & vbCrLf &
                                    "2. XAMPP/MySQL belum jalan"
            
            MessageBox.Show(errorMsg, "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(errorMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Mengambil data pertanyaan dan opsi jawaban untuk Level 1 (Kategori A) dari database.
    ''' Menggunakan satu query JOIN untuk efisiensi.
    ''' </summary>
    Public Function GetQuestionsLevel1() As List(Of QuestionData)
        Dim result As New List(Of QuestionData)
        ' Query to fetch questions and their options for Kategori A only
        Dim query As String = "SELECT q.question_code, q.question_text, o.option_text, o.option_value " &
                              "FROM ref_questions q " &
                              "JOIN ref_question_options o ON q.question_code = o.question_code " &
                              "WHERE q.kategori = 'A' AND q.is_active = TRUE " &
                              "ORDER BY q.question_order ASC, o.option_order ASC"

        Using conn As MySqlConnection = GetConnection()
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim currentCode As String = ""
                        Dim currentQ As QuestionData = Nothing

                        While reader.Read()
                            Dim code As String = reader("question_code").ToString()
                            Dim text As String = reader("question_text").ToString()
                            Dim optText As String = reader("option_text").ToString()
                            Dim optVal As Integer = Convert.ToInt32(reader("option_value"))

                            ' If new question code encountered, create new Question object
                            If code <> currentCode Then
                                currentQ = New QuestionData With {
                                    .QuestionCode = code,
                                    .QuestionText = text,
                                    .Options = New List(Of QuestionOption)()
                                }
                                result.Add(currentQ)
                                currentCode = code
                            End If

                            ' Add option to current question
                            currentQ.Options.Add(New QuestionOption With {
                                .Text = optText,
                                .Value = optVal
                            })
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception("Gagal memuat pertanyaan dari database: " & ex.Message)
            End Try
        End Using

        Return result
    End Function

    ''' <summary>
    ''' Menyimpan data UserProfile (Level 1 / Kategori A) ke tabel 'student_profiles'.
    ''' Melakukan mapping nilai UI string ke ENUM database jika diperlukan.
    ''' Menggunakan INSERT ... ON DUPLICATE KEY UPDATE untuk menghindari duplikasi.
    ''' </summary>
    Public Sub SaveStudentProfile(profile As UserProfile)
        ' Gunakan UPSERT: Insert baru atau update jika sudah ada untuk user yang sama
        Dim query As String = "INSERT INTO student_profiles (" &
                              "id_user, jenis_kelamin, status_pendidikan, program_studi, semester, " &
                              "status_mahasiswa, latar_belakang, alasan_memilih_prodi, tujuan_kuliah, " &
                              "metode_belajar, motivasi_belajar) " &
                              "VALUES " &
                              "(@uid, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10) " &
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

        Using conn As MySqlConnection = GetConnection()
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    ' 0. User ID (Default to 1 if not set for testing, replace with real Login ID later)
                    Dim uid As Integer = If(profile.UserID = 0, 1, profile.UserID)
                    cmd.Parameters.AddWithValue("@uid", uid)

                    ' 1. Jenis Kelamin (Map: Laki-laki->L, Perempuan->P)
                    Dim jk As String = If(profile.F_A1_JenisKelamin = "Laki-laki", "L", "P")
                    cmd.Parameters.AddWithValue("@p1", jk)

                    ' 2. Status Pendidikan (Map: Mahasiswa Aktif -> Aktif)
                    Dim statusPend As String = profile.F_A2_StatusPendidikan
                    If statusPend.Contains("Aktif") AndAlso Not statusPend.Contains("Non") Then
                        statusPend = "Aktif"
                    ElseIf statusPend.Contains("Non-Aktif") OrElse statusPend.Contains("Drop") Then
                        statusPend = "Non-aktif"
                    ElseIf statusPend.Contains("Cuti") Then
                        statusPend = "Cuti"
                    End If
                    cmd.Parameters.AddWithValue("@p2", statusPend)

                    ' 3. Program Studi (Direct Map)
                    cmd.Parameters.AddWithValue("@p3", profile.F_A3_ProgramStudi)

                    ' 4. Semester (Map int to ENUM string '1', '2', ... '6+')
                    Dim semVal As String = profile.F_A4_Semester.ToString()
                    If profile.F_A4_Semester > 6 Then semVal = "6+"
                    cmd.Parameters.AddWithValue("@p4", semVal)

                    ' 5. Status Mahasiswa (Direct Map)
                    Dim statMhs As String = profile.F_A5_StatusMahasiswa
                    cmd.Parameters.AddWithValue("@p5", statMhs)

                    ' 6. Latar Belakang (Direct Map)
                    cmd.Parameters.AddWithValue("@p6", profile.F_A6_LatarBelakang)

                    ' 7. Alasan Masuk (Map to ENUM values in database)
                    Dim alasan As String = profile.F_A7_AlasanMasuk
                    If alasan.Contains("Minat") Then
                        alasan = "Minat pribadi"
                    ElseIf alasan.Contains("Prospek") Then
                        alasan = "Peluang kerja"
                    ElseIf alasan.Contains("Orang Tua") OrElse alasan.Contains("Keluarga") Then
                        alasan = "Saran keluarga"
                    ElseIf alasan.Contains("Teman") Then
                        alasan = "Mengikuti teman"
                    Else
                        alasan = "Lainnya"
                    End If
                    cmd.Parameters.AddWithValue("@p7", alasan)

                    ' 8. Tujuan Kuliah (Map to ENUM values in database)
                    Dim tujuan As String = profile.F_A8_TujuanKuliah
                    If tujuan.Contains("Karir") Then
                        tujuan = "Meningkatkan karir"
                    ElseIf tujuan.Contains("Ilmu") OrElse tujuan.Contains("Skill") Then
                        tujuan = "Mendapatkan skill teknis"
                    ElseIf tujuan.Contains("Gelar") OrElse tujuan.Contains("Prestasi") Then
                        tujuan = "Mencari prestasi"
                    Else
                        tujuan = "Tidak yakin"
                    End If
                    cmd.Parameters.AddWithValue("@p8", tujuan)

                    ' 9. Metode Belajar (Direct Map)
                    cmd.Parameters.AddWithValue("@p9", profile.F_A9_MetodeBelajar)

                    ' 10. Motivasi Belajar (TINYINT 1-5)
                    cmd.Parameters.AddWithValue("@p10", profile.F_A10_MotivasiBelajar)

                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Throw New Exception("Gagal menyimpan profil ke 'student_profiles': " & ex.Message)
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Menyimpan data UserProfile lama (untuk backward compatibility)
    ''' </summary>
    Public Sub SaveUserProfile(profile As UserProfile)
        SaveStudentProfile(profile)
    End Sub

    ' ==========================================
    ' AUTHENTICATION FUNCTIONS
    ' ==========================================

    ''' <summary>
    ''' Hash password menggunakan SHA256
    ''' </summary>
    Public Function HashPassword(password As String) As String
        Using sha256 As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
            Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Dim builder As New System.Text.StringBuilder()
            For Each b As Byte In hash
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ''' <summary>
    ''' Registrasi user baru ke database (Compatible with MVP1 schema)
    ''' </summary>
    Public Function RegisterUser(username As String, password As String, namaLengkap As String, email As String) As (Success As Boolean, Message As String, UserId As Integer)
        ' Cek apakah username sudah ada
        Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE username = @username"
        Dim checkEmailQuery As String = "SELECT COUNT(*) FROM users WHERE email = @email"
        ' MVP1 uses 'password' (hashed) and 'full_name', 'id' columns
        Dim insertQuery As String = "INSERT INTO users (username, password, full_name, email, role) VALUES (@username, @password, @nama, @email, 'student'); SELECT LAST_INSERT_ID();"

        Using conn As MySqlConnection = GetConnection()
            Try
                conn.Open()

                ' Cek username
                Using cmd As New MySqlCommand(checkQuery, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        Return (False, "Username sudah digunakan. Silakan pilih username lain.", 0)
                    End If
                End Using

                ' Cek email
                If Not String.IsNullOrEmpty(email) Then
                    Using cmd As New MySqlCommand(checkEmailQuery, conn)
                        cmd.Parameters.AddWithValue("@email", email)
                        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        If count > 0 Then
                            Return (False, "Email sudah terdaftar. Silakan gunakan email lain.", 0)
                        End If
                    End Using
                End If

                ' Insert user baru - password di-hash untuk keamanan
                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", HashPassword(password))
                    cmd.Parameters.AddWithValue("@nama", namaLengkap)
                    cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(email), DBNull.Value, CObj(email)))

                    Dim userId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return (True, "Registrasi berhasil!", userId)
                End Using

            Catch ex As Exception
                Return (False, "Gagal registrasi: " & ex.Message, 0)
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Login user dengan username dan password (Compatible with MVP1 schema)
    ''' Supports both hashed and plain text passwords for backward compatibility
    ''' </summary>
    Public Function LoginUser(username As String, password As String) As (Success As Boolean, Message As String, UserId As Integer, NamaLengkap As String)
        ' MVP1 uses 'id' and 'full_name' columns, 'password' (plain or hashed)
        Dim query As String = "SELECT id, full_name, password FROM users WHERE username = @username"

        Using conn As MySqlConnection = GetConnection()
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim storedPassword As String = reader("password").ToString()
                            Dim inputHash As String = HashPassword(password)

                            ' Support both plain text (legacy) and hashed password
                            Dim passwordMatch As Boolean = False
                            If storedPassword = password Then
                                ' Plain text match (legacy data)
                                passwordMatch = True
                            ElseIf storedPassword = inputHash Then
                                ' Hashed password match
                                passwordMatch = True
                            End If

                            If passwordMatch Then
                                Dim userId As Integer = Convert.ToInt32(reader("id"))
                                Dim namaLengkap As String = reader("full_name").ToString()
                                Return (True, "Login berhasil!", userId, namaLengkap)
                            Else
                                Return (False, "Password salah!", 0, "")
                            End If
                        Else
                            Return (False, "Username tidak ditemukan!", 0, "")
                        End If
                    End Using
                End Using

            Catch ex As Exception
                Return (False, "Gagal login: " & ex.Message, 0, "")
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Mendapatkan data user berdasarkan ID (Compatible with MVP1 schema)
    ''' </summary>
    Public Function GetUserById(userId As Integer) As (Found As Boolean, Username As String, NamaLengkap As String, Email As String)
        ' MVP1 uses 'id' and 'full_name' columns
        Dim query As String = "SELECT username, full_name, email FROM users WHERE id = @id"

        Using conn As MySqlConnection = GetConnection()
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", userId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim fullName As String = reader("full_name").ToString()
                            Dim emailVal As String = If(reader.IsDBNull(reader.GetOrdinal("email")), "", reader("email").ToString())
                            Return (True, reader("username").ToString(), fullName, emailVal)
                        Else
                            Return (False, "", "", "")
                        End If
                    End Using
                End Using

            Catch ex As Exception
                Return (False, "", "", "")
            End Try
        End Using
    End Function
End Module
