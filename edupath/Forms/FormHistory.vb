Imports MySql.Data.MySqlClient
Imports OccuPath.Core
Imports OccuPath.Services
Imports OccuPath.Models

''' <summary>
''' Form History - Menampilkan riwayat assessment pengguna
''' </summary>
Public Class FormHistory
    Private _userId As Integer

    Public Sub New(userId As Integer)
        InitializeComponent()
        _userId = userId
    End Sub

    Private Sub FormHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAssessmentHistory()
    End Sub

    Private Sub LoadAssessmentHistory()
        Try
            dgvHistory.Rows.Clear()

            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                ' Load assessment history with results
                ' Fixed: user_id instead of id_user, id for assessment primary key
                Dim sql = "SELECT a.id, a.date_taken, " &
                          "r.profil_lulusan_id, pl.nama_profil, r.cf_percentage, r.ranking " &
                          "FROM assessments a " &
                          "LEFT JOIN results r ON a.id = r.assessment_id " &
                          "LEFT JOIN profil_lulusan pl ON r.profil_lulusan_id = pl.id " &
                          "WHERE a.user_id = @userId " &
                          "ORDER BY a.date_taken DESC, r.ranking ASC"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@userId", _userId)

                    Using reader = cmd.ExecuteReader()
                        Dim currentAssessmentId As Integer = -1
                        Dim assessmentDate As String = ""
                        Dim rowIndex As Integer = 0

                        While reader.Read()
                            Dim assessmentId = reader.GetInt32("id")

                            ' New assessment entry
                            If assessmentId <> currentAssessmentId Then
                                currentAssessmentId = assessmentId
                                assessmentDate = CDate(reader("date_taken")).ToString("dd MMM yyyy HH:mm")
                                rowIndex = 0
                            End If

                            rowIndex += 1
                            Dim medal As String = ""
                            Select Case rowIndex
                                Case 1
                                    medal = "??"
                                Case 2
                                    medal = "??"
                                Case 3
                                    medal = "??"
                            End Select

                            Dim profileName = If(reader.IsDBNull(reader.GetOrdinal("nama_profil")), "N/A", reader.GetString("nama_profil"))
                            Dim cfPercentage = If(reader.IsDBNull(reader.GetOrdinal("cf_percentage")), 0.0, reader.GetDouble("cf_percentage"))

                            dgvHistory.Rows.Add(
                                assessmentId,
                                assessmentDate,
                                medal,
                                profileName,
                                $"{cfPercentage:F2}%"
                            )
                        End While
                    End Using
                End Using

                If dgvHistory.Rows.Count = 0 Then
                    lblNoData.Visible = True
                Else
                    lblNoData.Visible = False
                End If

                ' Update statistics
                Dim totalAssessments = dgvHistory.Rows.Cast(Of DataGridViewRow)().
                    Select(Function(r) r.Cells("colAssessmentId").Value).Distinct().Count()
                lblTotalAssessments.Text = $"Total Assessment: {totalAssessments}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading history: {ex.Message}" & vbCrLf & vbCrLf &
                          $"Stack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewDetail_Click(sender As Object, e As EventArgs) Handles btnViewDetail.Click
        If dgvHistory.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih assessment yang ingin dilihat detailnya.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim selectedRow = dgvHistory.SelectedRows(0)
            Dim assessmentId = CInt(selectedRow.Cells("colAssessmentId").Value)

            ' Load results for this assessment
            Dim results As New List(Of InferenceService.InferenceResult)()

            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                Dim sql = "SELECT r.profil_lulusan_id, pl.nama_profil, pl.deskripsi, pl.skills_required, " &
                          "r.cf_percentage, r.ranking, r.matched_rules " &
                          "FROM results r " &
                          "JOIN profil_lulusan pl ON r.profil_lulusan_id = pl.id " &
                          "WHERE r.assessment_id = @assessmentId " &
                          "ORDER BY r.ranking ASC"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@assessmentId", assessmentId)

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim result As New InferenceService.InferenceResult() With {
                                .ProfilLulusan = New Models.ProfilLulusan() With {
                                    .Id = reader.GetInt32("profil_lulusan_id"),
                                    .Nama = reader.GetString("nama_profil"),
                                    .Deskripsi = If(reader.IsDBNull(reader.GetOrdinal("deskripsi")), "", reader.GetString("deskripsi")),
                                    .KompetensiUtama = If(reader.IsDBNull(reader.GetOrdinal("skills_required")), "", reader.GetString("skills_required"))
                                },
                                .CertaintyFactor = reader.GetDouble("cf_percentage"),
                                .Ranking = reader.GetInt32("ranking"),
                                .MatchedRules = New List(Of String)()
                            }

                            ' Parse matched rules if available
                            If Not reader.IsDBNull(reader.GetOrdinal("matched_rules")) Then
                                Dim rulesStr = reader.GetString("matched_rules")
                                ' Split by comma
                                If Not String.IsNullOrEmpty(rulesStr) Then
                                    result.MatchedRules.AddRange(rulesStr.Split(","c).Select(Function(r) r.Trim()))
                                End If
                            End If

                            results.Add(result)
                        End While
                    End Using
                End Using
            End Using

            ' Show FormResult
            Dim resultForm As New FormResult(results, _userId)
            resultForm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show($"Error viewing detail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAssessmentHistory()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellDoubleClick
        If e.RowIndex >= 0 Then
            btnViewDetail_Click(sender, e)
        End If
    End Sub
End Class
