' ============================================
' Service: InferenceService
' Forward Chaining dengan Certainty Factor
' ============================================

Imports MySql.Data.MySqlClient
Imports OccuPath.Data
Imports OccuPath.Models

Namespace Services
    ''' <summary>
    ''' Service untuk melakukan inferensi menggunakan Forward Chaining dan Certainty Factor
    ''' </summary>
    Public Class InferenceService

        ''' <summary>
        ''' Hasil rekomendasi dari sistem pakar
        ''' </summary>
        Public Class InferenceResult
            Public Property ProfilLulusan As ProfilLulusan
            Public Property CertaintyFactor As Double
            Public Property MatchedRules As List(Of Rule)
            Public Property Ranking As Integer
            Public Property Explanation As String

            Public Sub New()
                MatchedRules = New List(Of Rule)()
            End Sub
        End Class

        ''' <summary>
        ''' Menjalankan Forward Chaining untuk menentukan profil lulusan
        ''' </summary>
        ''' <param name="akademisData">Data akademis (Kategori B)</param>
        ''' <param name="karakterData">Data karakter (Kategori C)</param>
        ''' <returns>List hasil inferensi dengan ranking</returns>
        Public Function RunInference(akademisData As Dictionary(Of String, Double),
                                      karakterData As Dictionary(Of String, Double)) As List(Of InferenceResult)
            Dim results As New List(Of InferenceResult)()

            Try
                ' 1. Ambil semua profil lulusan
                Dim profilList = GetAllProfilLulusan()

                ' 2. Ambil semua rules
                Dim rules = GetAllRules()

                ' 3. Gabungkan semua fakta
                Dim facts As New Dictionary(Of String, Double)()
                For Each kvp In akademisData
                    facts(kvp.Key) = kvp.Value
                Next
                For Each kvp In karakterData
                    facts(kvp.Key) = kvp.Value
                Next

                ' 4. Forward Chaining - evaluasi setiap profil
                For Each profil In profilList
                    Dim result As New InferenceResult() With {
                        .ProfilLulusan = profil
                    }

                    ' Ambil rules untuk profil ini
                    Dim profilRules = rules.Where(Function(r) r.ProfilLulusanId = profil.Id).ToList()

                    ' Evaluasi rules menggunakan Certainty Factor
                    Dim cfCombined As Double = 0
                    For Each rule In profilRules
                        Dim cfRule = EvaluateRule(rule, facts)
                        If cfRule > 0 Then
                            result.MatchedRules.Add(rule)
                            ' Kombinasi CF: CF_combined = CF1 + CF2 * (1 - CF1)
                            cfCombined = cfCombined + cfRule * (1 - cfCombined)
                        End If
                    Next

                    result.CertaintyFactor = Math.Round(cfCombined, 4)
                    result.Explanation = GenerateExplanation(result)

                    results.Add(result)
                Next

                ' 5. Urutkan berdasarkan CF tertinggi
                results = results.OrderByDescending(Function(r) r.CertaintyFactor).ToList()

                ' 6. Set ranking
                For i = 0 To results.Count - 1
                    results(i).Ranking = i + 1
                Next

            Catch ex As Exception
                ' Log error
                Console.WriteLine($"Inference Error: {ex.Message}")
            End Try

            Return results
        End Function

        ''' <summary>
        ''' Evaluasi satu rule berdasarkan fakta
        ''' </summary>
        Private Function EvaluateRule(rule As Rule, facts As Dictionary(Of String, Double)) As Double
            ' Parse kondisi rule (format: "F_B1>3.0 AND F_C1>0.6")
            Dim conditions = rule.Condition.Split(New String() {" AND ", " and "}, StringSplitOptions.RemoveEmptyEntries)

            Dim cfMin As Double = 1.0 ' Untuk AND, gunakan nilai minimum

            For Each cond In conditions
                cond = cond.Trim()

                ' Parse kondisi (misal: F_B1>3.0)
                Dim factCode As String = ""
                Dim comparison As String = ""
                Dim threshold As Double = 0

                If cond.Contains(">=") Then
                    Dim parts = cond.Split(New String() {">="}, StringSplitOptions.None)
                    factCode = parts(0).Trim()
                    comparison = ">="
                    Double.TryParse(parts(1).Trim(), threshold)
                ElseIf cond.Contains("<=") Then
                    Dim parts = cond.Split(New String() {"<="}, StringSplitOptions.None)
                    factCode = parts(0).Trim()
                    comparison = "<="
                    Double.TryParse(parts(1).Trim(), threshold)
                ElseIf cond.Contains(">") Then
                    Dim parts = cond.Split(">"c)
                    factCode = parts(0).Trim()
                    comparison = ">"
                    Double.TryParse(parts(1).Trim(), threshold)
                ElseIf cond.Contains("<") Then
                    Dim parts = cond.Split("<"c)
                    factCode = parts(0).Trim()
                    comparison = "<"
                    Double.TryParse(parts(1).Trim(), threshold)
                ElseIf cond.Contains("=") Then
                    Dim parts = cond.Split("="c)
                    factCode = parts(0).Trim()
                    comparison = "="
                    Double.TryParse(parts(1).Trim(), threshold)
                End If

                ' Cek fakta
                If facts.ContainsKey(factCode) Then
                    Dim factValue = facts(factCode)
                    Dim conditionMet As Boolean = False

                    Select Case comparison
                        Case ">="
                            conditionMet = factValue >= threshold
                        Case "<="
                            conditionMet = factValue <= threshold
                        Case ">"
                            conditionMet = factValue > threshold
                        Case "<"
                            conditionMet = factValue < threshold
                        Case "="
                            conditionMet = Math.Abs(factValue - threshold) < 0.001
                    End Select

                    If Not conditionMet Then
                        Return 0 ' Kondisi tidak terpenuhi
                    End If

                    ' Hitung kontribusi CF berdasarkan seberapa baik fakta memenuhi kondisi
                    Dim cfContribution = CalculateCFContribution(factValue, threshold, comparison)
                    If cfContribution < cfMin Then
                        cfMin = cfContribution
                    End If
                Else
                    Return 0 ' Fakta tidak ditemukan
                End If
            Next

            ' CF akhir = CF rule * CF minimum dari kondisi
            Return rule.CertaintyFactor * cfMin
        End Function

        ''' <summary>
        ''' Menghitung kontribusi CF berdasarkan nilai fakta
        ''' </summary>
        Private Function CalculateCFContribution(factValue As Double, threshold As Double, comparison As String) As Double
            Select Case comparison
                Case ">=", ">"
                    ' Semakin tinggi di atas threshold, semakin tinggi CF
                    If threshold = 0 Then Return 1.0
                    Dim ratio = factValue / threshold
                    Return Math.Min(ratio, 1.0)

                Case "<=", "<"
                    ' Semakin rendah di bawah threshold, semakin tinggi CF
                    If factValue = 0 Then Return 1.0
                    Dim ratio = threshold / factValue
                    Return Math.Min(ratio, 1.0)

                Case "="
                    Return 1.0

                Case Else
                    Return 1.0
            End Select
        End Function

        ''' <summary>
        ''' Generate penjelasan hasil inferensi
        ''' </summary>
        Private Function GenerateExplanation(result As InferenceResult) As String
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine($"Profil: {result.ProfilLulusan.Nama}")
            sb.AppendLine($"Certainty Factor: {result.CertaintyFactor * 100:F1}%")
            sb.AppendLine($"Rules yang cocok: {result.MatchedRules.Count}")
            Return sb.ToString()
        End Function

        ''' <summary>
        ''' Mengambil semua profil lulusan dari database
        ''' </summary>
        Private Function GetAllProfilLulusan() As List(Of ProfilLulusan)
            Dim result As New List(Of ProfilLulusan)()

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Dim sql = "SELECT id, nama, deskripsi, program_studi, kompetensi_utama FROM profil_lulusan WHERE is_active = TRUE"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            result.Add(New ProfilLulusan() With {
                                .Id = reader.GetInt32("id"),
                                .Nama = reader.GetString("nama"),
                                .Deskripsi = If(reader.IsDBNull(reader.GetOrdinal("deskripsi")), "", reader.GetString("deskripsi")),
                                .ProgramStudi = If(reader.IsDBNull(reader.GetOrdinal("program_studi")), "", reader.GetString("program_studi")),
                                .KompetensiUtama = If(reader.IsDBNull(reader.GetOrdinal("kompetensi_utama")), "", reader.GetString("kompetensi_utama"))
                            })
                        End While
                    End Using
                End Using
            End Using

            Return result
        End Function

        ''' <summary>
        ''' Mengambil semua rules dari database
        ''' </summary>
        Private Function GetAllRules() As List(Of Rule)
            Dim result As New List(Of Rule)()

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Dim sql = "SELECT id, rule_code, conditions, profil_lulusan_id, certainty_factor FROM rules WHERE is_active = TRUE"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            result.Add(New Rule() With {
                                .Id = reader.GetInt32("id"),
                                .RuleCode = reader.GetString("rule_code"),
                                .Condition = reader.GetString("conditions"),
                                .ProfilLulusanId = reader.GetInt32("profil_lulusan_id"),
                                .CertaintyFactor = reader.GetDouble("certainty_factor")
                            })
                        End While
                    End Using
                End Using
            End Using

            Return result
        End Function

        ''' <summary>
        ''' Simpan hasil rekomendasi ke database
        ''' </summary>
        Public Sub SaveRecommendation(userId As Integer, result As InferenceResult)
            Using conn = Data.DbContext.CreateConnection()
                conn.Open()

                Dim sql = "INSERT INTO recommendations (user_id, profil_lulusan_id, certainty_factor, ranking, created_at) " &
                          "VALUES (@userId, @profilId, @cf, @ranking, NOW())"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)
                    cmd.Parameters.AddWithValue("@profilId", result.ProfilLulusan.Id)
                    cmd.Parameters.AddWithValue("@cf", result.CertaintyFactor)
                    cmd.Parameters.AddWithValue("@ranking", result.Ranking)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub
    End Class
End Namespace
