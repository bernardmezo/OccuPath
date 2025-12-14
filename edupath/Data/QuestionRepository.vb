' ============================================
' Repository: QuestionRepository
' Data Access Layer untuk tabel pertanyaan
' ============================================

Imports MySql.Data.MySqlClient
Imports OccuPath.Models
Imports QuestionOpt = OccuPath.Models.QuestionOption

Namespace Data
    Public Class QuestionRepository
        Private ReadOnly _dbContext As New DbContext()
        
        ''' <summary>
        ''' Mengambil semua pertanyaan berdasarkan kategori
        ''' </summary>
        Public Function GetByKategori(kategori As String) As List(Of Question)
            Dim result As New List(Of Question)
            Dim query As String = "SELECT q.id, q.code, q.text, q.display_order, " &
                                  "o.id, o.option_text, o.option_value, o.display_order " &
                                  "FROM questions q " &
                                  "JOIN question_options o ON q.code = o.question_code " &
                                  "WHERE q.kategori = @kategori AND q.is_active = TRUE " &
                                  "ORDER BY q.display_order ASC, o.display_order ASC"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@kategori", kategori)

                    Using reader = cmd.ExecuteReader()
                        Dim currentCode As String = ""
                        Dim currentQuestion As Question = Nothing

                        While reader.Read()
                            Dim code As String = reader.GetString("code")

                            ' Jika kode pertanyaan baru, buat objek Question baru
                            If code <> currentCode Then
                                currentQuestion = New Question() With {
                                    .Id = reader.GetInt32(0),
                                    .Code = code,
                                    .Kategori = kategori,
                                    .Text = reader.GetString("text"),
                                    .Order = reader.GetInt32(3),
                                    .DisplayOrder = reader.GetInt32(3),
                                    .Options = New List(Of Models.QuestionOption)()
                                }
                                result.Add(currentQuestion)
                                currentCode = code
                            End If

                            ' Tambahkan opsi ke pertanyaan saat ini
                            currentQuestion.Options.Add(New Models.QuestionOption() With {
                                .Id = reader.GetInt32(4),
                                .QuestionCode = code,
                                .Text = reader.GetString("option_text"),
                                .Value = reader.GetInt32("option_value"),
                                .Order = reader.GetInt32(7),
                                .DisplayOrder = reader.GetInt32(7)
                            })
                        End While
                    End Using
                End Using
            End Using

            Return result
        End Function

        ''' <summary>
        ''' Mengambil pertanyaan Kategori A (Data Diri)
        ''' </summary>
        Public Function GetKategoriA() As List(Of Question)
            Return GetByKategori("A")
        End Function

        ''' <summary>
        ''' Mengambil pertanyaan Kategori B (Data Akademis)
        ''' </summary>
        Public Function GetKategoriB() As List(Of Question)
            Return GetByKategori("B")
        End Function

        ''' <summary>
        ''' Mengambil pertanyaan Kategori C (Data Karakter)
        ''' </summary>
        Public Function GetKategoriC() As List(Of Question)
            Return GetByKategori("C")
        End Function

        ''' <summary>
        ''' Menghitung jumlah pertanyaan per kategori
        ''' </summary>
        Public Function CountByKategori(kategori As String) As Integer
            Dim query As String = "SELECT COUNT(*) FROM questions WHERE kategori = @kategori AND is_active = TRUE"

            Using conn = Data.DbContext.CreateConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@kategori", kategori)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        End Function
    End Class
End Namespace
