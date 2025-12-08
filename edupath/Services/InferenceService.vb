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
        ''' Representasi satu rule dari database
        ''' </summary>
        Public Class Rule
            Public Property Id As Integer
            Public Property RuleCode As String
            Public Property ProfilLulusanId As Integer
            Public Property CfRule As Double
            Public Property Description As String
            Public Property Conditions As List(Of RuleCondition)

            Public Sub New()
                Conditions = New List(Of RuleCondition)()
            End Sub
        End Class

        ''' <summary>
        ''' Representasi kondisi dalam rule
        ''' </summary>
        Public Class RuleCondition
            Public Property QuestionCode As String
            Public Property OperatorType As String
            Public Property ThresholdValue As Double
        End Class

        ''' <summary>
        ''' Hasil rekomendasi dari sistem pakar
        ''' </summary>
        Public Class InferenceResult
            Public Property ProfilLulusan As ProfilLulusan
            Public Property CertaintyFactor As Double
            Public Property MatchedRules As List(Of String)
            Public Property Ranking As Integer
            Public Property Explanation As String

            Public Sub New()
                MatchedRules = New List(Of String)()
            End Sub
        End Class

        ''' <summary>
        ''' Menjalankan Forward Chaining untuk menentukan profil lulusan
        ''' </summary>
        ''' <param name="personalData">Data diri (Kategori A)</param>
        ''' <param name="akademisData">Data akademis (Kategori B)</param>
        ''' <param name="karakterData">Data karakter (Kategori C)</param>
        ''' <returns>List hasil inferensi dengan ranking</returns>
        Public Function RunInference(personalData As Dictionary(Of String, Double),
                                      akademisData As Dictionary(Of String, Double),
                                      karakterData As Dictionary(Of String, Double)) As List(Of InferenceResult)
            Dim results As New List(Of InferenceResult)()

            Try
                ' 1. Gabungkan semua fakta
                Dim facts As New Dictionary(Of String, Double)()
                For Each kvp In personalData
                    facts(kvp.Key) = kvp.Value
                Next
                For Each kvp In akademisData
                    facts(kvp.Key) = kvp.Value
                Next
                For Each kvp In karakterData
                    facts(kvp.Key) = kvp.Value
                Next

                ' 2. Ambil semua profil lulusan
                Dim profilList = GetAllProfilLulusan()

                ' 3. Ambil semua rules dengan kondisi
                Dim rules = GetAllRulesWithConditions()

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
                        Dim cfRuleInstance = EvaluateRule(rule, facts)
                        If cfRuleInstance > 0 Then
                            result.MatchedRules.Add(rule.RuleCode)
                            ' Kombinasi CF: CF_combined = CF1 + CF2 * (1 - CF1)
                            cfCombined = CombineCF(cfCombined, cfRuleInstance)
                        End If
                    Next

                    result.CertaintyFactor = Math.Round(cfCombined, 4)
                    result.Explanation = GenerateExplanation(result, facts)

                    ' Hanya simpan hasil yang memiliki CF > 0
                    If result.CertaintyFactor > 0 Then
                        results.Add(result)
                    End If
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
                Throw
            End Try

            Return results
        End Function

        ''' <summary>
        ''' Evaluasi satu rule berdasarkan fakta (dengan kondisi dari database)
        ''' </summary>
        Private Function EvaluateRule(rule As Rule, facts As Dictionary(Of String, Double)) As Double
            ' CF premis untuk AND = minimum dari semua CF kondisi
            Dim cfPremis As Double = 1.0

            For Each condition In rule.Conditions
                ' Cek apakah fakta ada
                If Not facts.ContainsKey(condition.QuestionCode) Then
                    Return 0 ' Fakta tidak ditemukan, rule tidak dapat dievaluasi
                End If

                Dim factValue = facts(condition.QuestionCode)
                Dim conditionMet As Boolean = False

                ' Evaluasi kondisi berdasarkan operator
                Select Case condition.OperatorType
                    Case ">="
                        conditionMet = factValue >= condition.ThresholdValue
                    Case ">"
                        conditionMet = factValue > condition.ThresholdValue
                    Case "<="
                        conditionMet = factValue <= condition.ThresholdValue
                    Case "<"
                        conditionMet = factValue < condition.ThresholdValue
                    Case "="
                        conditionMet = Math.Abs(factValue - condition.ThresholdValue) < 0.001
                    Case "!="
                        conditionMet = Math.Abs(factValue - condition.ThresholdValue) >= 0.001
                End Select

                If Not conditionMet Then
                    Return 0 ' Kondisi tidak terpenuhi, rule tidak fire
                End If

                ' Hitung CF user untuk kondisi ini (asumsi CF = 1.0 untuk input valid)
                ' Untuk AND: ambil minimum
                Dim cfCondition As Double = 1.0
                cfPremis = Math.Min(cfPremis, cfCondition)
            Next

            ' CF Rule Instance = CF Premis * CF Rule
            Return cfPremis * rule.CfRule
        End Function

        ''' <summary>
        ''' Kombinasi CF menggunakan rumus: CF_combined = CF1 + CF2 * (1 - CF1)
        ''' </summary>
        Private Function CombineCF(cf1 As Double, cf2 As Double) As Double
            Return cf1 + cf2 * (1 - cf1)
        End Function

        ''' <summary>
        ''' Generate penjelasan hasil inferensi
        ''' </summary>
        Private Function GenerateExplanation(result As InferenceResult, facts As Dictionary(Of String, Double)) As String
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine($"Profil Lulusan: {result.ProfilLulusan.Nama}")
            sb.AppendLine($"Tingkat Kesesuaian: {result.CertaintyFactor * 100:F1}%")
            sb.AppendLine($"Rules yang Cocok: {String.Join(", ", result.MatchedRules)}")
            sb.AppendLine()
            sb.AppendLine($"Deskripsi: {result.ProfilLulusan.Deskripsi}")
            Return sb.ToString()
        End Function

        ''' <summary>
        ''' Mengambil semua profil lulusan dari database
        ''' </summary>
        Private Function GetAllProfilLulusan() As List(Of ProfilLulusan)
            Dim result As New List(Of ProfilLulusan)()

            Using conn = DatabaseConnection.GetConnection()
                conn.Open()
                Dim sql = "SELECT id, nama_profil, deskripsi, skills_required FROM profil_lulusan"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            result.Add(New ProfilLulusan() With {
                                .Id = reader.GetInt32("id"),
                                .Nama = reader.GetString("nama_profil"),
                                .Deskripsi = If(reader.IsDBNull(reader.GetOrdinal("deskripsi")), "", reader.GetString("deskripsi")),
                                .KompetensiUtama = If(reader.IsDBNull(reader.GetOrdinal("skills_required")), "", reader.GetString("skills_required"))
                            })
                        End While
                    End Using
                End Using
            End Using

            Return result
        End Function

        ''' <summary>
        ''' Mengambil semua rules dengan kondisi dari database
        ''' </summary>
        Private Function GetAllRulesWithConditions() As List(Of Rule)
            Dim result As New List(Of Rule)()

            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                ' Ambil semua rules
                Dim sqlRules = "SELECT id, rule_code, profil_lulusan_id, cf_rule, description FROM rules WHERE is_active = TRUE"
                Using cmdRules As New MySqlCommand(sqlRules, conn)
                    Using readerRules = cmdRules.ExecuteReader()
                        While readerRules.Read()
                            Dim rule As New Rule() With {
                                .Id = readerRules.GetInt32("id"),
                                .RuleCode = readerRules.GetString("rule_code"),
                                .ProfilLulusanId = readerRules.GetInt32("profil_lulusan_id"),
                                .CfRule = readerRules.GetDouble("cf_rule"),
                                .Description = If(readerRules.IsDBNull(readerRules.GetOrdinal("description")), "", readerRules.GetString("description"))
                            }
                            result.Add(rule)
                        End While
                    End Using
                End Using

                ' Ambil kondisi untuk setiap rule
                For Each rule In result
                    Dim sqlConditions = "SELECT question_code, operator, threshold_value FROM rule_conditions WHERE rule_id = @ruleId"
                    Using cmdConditions As New MySqlCommand(sqlConditions, conn)
                        cmdConditions.Parameters.AddWithValue("@ruleId", rule.Id)
                        Using readerConditions = cmdConditions.ExecuteReader()
                            While readerConditions.Read()
                                rule.Conditions.Add(New RuleCondition() With {
                                    .QuestionCode = readerConditions.GetString("question_code"),
                                    .OperatorType = readerConditions.GetString("operator"),
                                    .ThresholdValue = readerConditions.GetDouble("threshold_value")
                                })
                            End While
                        End Using
                    End Using
                Next
            End Using

            Return result
        End Function

        ''' <summary>
        ''' Simpan hasil assessment dan results ke database
        ''' </summary>
        Public Function SaveAssessmentResults(userId As Integer,
                                               responses As Dictionary(Of String, Double),
                                               results As List(Of InferenceResult)) As Integer
            Dim assessmentId As Integer = 0

            Using conn = DatabaseConnection.GetConnection()
                conn.Open()
                Using transaction = conn.BeginTransaction()
                    Try
                        ' 1. Insert assessment
                        Dim sqlAssessment = "INSERT INTO assessments (user_id, date_taken, status, completed_at) " &
                                            "VALUES (@userId, NOW(), 'completed', NOW()); SELECT LAST_INSERT_ID();"
                        Using cmd As New MySqlCommand(sqlAssessment, conn, transaction)
                            cmd.Parameters.AddWithValue("@userId", userId)
                            assessmentId = Convert.ToInt32(cmd.ExecuteScalar())
                        End Using

                        ' 2. Insert responses
                        For Each kvp In responses
                            Dim sqlResponse = "INSERT INTO responses (assessment_id, question_code, value_input) " &
                                              "VALUES (@assessmentId, @questionCode, @value)"
                            Using cmd As New MySqlCommand(sqlResponse, conn, transaction)
                                cmd.Parameters.AddWithValue("@assessmentId", assessmentId)
                                cmd.Parameters.AddWithValue("@questionCode", kvp.Key)
                                cmd.Parameters.AddWithValue("@value", kvp.Value)
                                cmd.ExecuteNonQuery()
                            End Using
                        Next

                        ' 3. Insert results
                        For Each result In results
                            Dim sqlResult = "INSERT INTO results (assessment_id, profil_lulusan_id, cf_percentage, ranking, matched_rules, explanation) " &
                                            "VALUES (@assessmentId, @profilId, @cf, @ranking, @matchedRules, @explanation)"
                            Using cmd As New MySqlCommand(sqlResult, conn, transaction)
                                cmd.Parameters.AddWithValue("@assessmentId", assessmentId)
                                cmd.Parameters.AddWithValue("@profilId", result.ProfilLulusan.Id)
                                cmd.Parameters.AddWithValue("@cf", result.CertaintyFactor * 100)
                                cmd.Parameters.AddWithValue("@ranking", result.Ranking)
                                cmd.Parameters.AddWithValue("@matchedRules", String.Join(",", result.MatchedRules))
                                cmd.Parameters.AddWithValue("@explanation", result.Explanation)
                                cmd.ExecuteNonQuery()
                            End Using
                        Next

                        transaction.Commit()
                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            Return assessmentId
        End Function
    End Class
End Namespace
