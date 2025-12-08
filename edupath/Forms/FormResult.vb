Imports System.Drawing
Imports OccuPath.Services
Imports OccuPath.Models

''' <summary>
''' Form untuk menampilkan hasil inferensi sistem pakar
''' </summary>
Public Class FormResult
    Private _results As List(Of InferenceService.InferenceResult)
    Private _userId As Integer

    Public Sub New(results As List(Of InferenceService.InferenceResult), userId As Integer)
        InitializeComponent()
        _results = results
        _userId = userId
    End Sub

    Private Sub FormResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadResults()
    End Sub

    Private Sub LoadResults()
        ' Clear existing controls
        panelResults.Controls.Clear()

        If _results Is Nothing OrElse _results.Count = 0 Then
            Dim lblNoResult As New Label() With {
                .Text = "Tidak ada hasil rekomendasi yang ditemukan.",
                .Font = New Font("Segoe UI", 12, FontStyle.Regular),
                .ForeColor = Color.Gray,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Dock = DockStyle.Fill
            }
            panelResults.Controls.Add(lblNoResult)
            Return
        End If

        ' Title
        Dim lblTitle As New Label() With {
            .Text = "Hasil Analisis Profil Lulusan",
            .Font = New Font("Segoe UI", 16, FontStyle.Bold),
            .ForeColor = Color.FromArgb(41, 128, 185),
            .AutoSize = True,
            .Padding = New Padding(0, 0, 0, 20)
        }
        panelResults.Controls.Add(lblTitle)

        ' Subtitle
        Dim lblSubtitle As New Label() With {
            .Text = $"Berdasarkan analisis Forward Chaining & Certainty Factor, berikut adalah {Math.Min(3, _results.Count)} rekomendasi teratas:",
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .ForeColor = Color.Gray,
            .AutoSize = True,
            .MaximumSize = New Size(panelResults.Width - 40, 0),
            .Padding = New Padding(0, 0, 0, 30)
        }
        panelResults.Controls.Add(lblSubtitle)

        ' Display top 3 results
        Dim topResults = _results.Take(3).ToList()
        For i = 0 To topResults.Count - 1
            Dim resultCard = CreateResultCard(topResults(i), i)
            panelResults.Controls.Add(resultCard)
        Next

        ' Buttons
        Dim buttonPanel As New FlowLayoutPanel() With {
            .FlowDirection = FlowDirection.LeftToRight,
            .AutoSize = True,
            .Padding = New Padding(0, 30, 0, 0),
            .WrapContents = False
        }

        Dim btnSave As New Button() With {
            .Text = "Simpan Hasil",
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .BackColor = Color.FromArgb(39, 174, 96),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Size = New Size(150, 40),
            .Cursor = Cursors.Hand
        }
        AddHandler btnSave.Click, AddressOf btnSave_Click

        Dim btnViewHistory As New Button() With {
            .Text = "Lihat History",
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .BackColor = Color.FromArgb(52, 152, 219),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Size = New Size(150, 40),
            .Cursor = Cursors.Hand,
            .Margin = New Padding(10, 0, 0, 0)
        }
        AddHandler btnViewHistory.Click, AddressOf btnViewHistory_Click

        Dim btnNewTest As New Button() With {
            .Text = "Tes Baru",
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .BackColor = Color.FromArgb(149, 165, 166),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Size = New Size(150, 40),
            .Cursor = Cursors.Hand,
            .Margin = New Padding(10, 0, 0, 0)
        }
        AddHandler btnNewTest.Click, AddressOf btnNewTest_Click

        buttonPanel.Controls.Add(btnSave)
        buttonPanel.Controls.Add(btnViewHistory)
        buttonPanel.Controls.Add(btnNewTest)
        panelResults.Controls.Add(buttonPanel)
    End Sub

    Private Function CreateResultCard(result As InferenceService.InferenceResult, index As Integer) As Panel
        Dim card As New Panel() With {
            .BorderStyle = BorderStyle.FixedSingle,
            .Padding = New Padding(20),
            .Margin = New Padding(0, 0, 0, 15),
            .AutoSize = True,
            .Width = panelResults.Width - 40
        }

        ' Ranking badge
        Dim badge As New Label() With {
            .Text = $"#{result.Ranking}",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = GetRankingColor(result.Ranking),
            .AutoSize = True
        }
        card.Controls.Add(badge)

        ' Profile name
        Dim lblName As New Label() With {
            .Text = result.ProfilLulusan.Nama,
            .Font = New Font("Segoe UI", 14, FontStyle.Bold),
            .ForeColor = Color.FromArgb(44, 62, 80),
            .AutoSize = True,
            .Location = New Point(80, 0)
        }
        card.Controls.Add(lblName)

        ' CF percentage
        Dim cfPercent = result.CertaintyFactor * 100
        Dim lblCF As New Label() With {
            .Text = $"{cfPercent:F1}%",
            .Font = New Font("Segoe UI", 24, FontStyle.Bold),
            .ForeColor = GetCFColor(cfPercent),
            .AutoSize = True,
            .Location = New Point(80, 30)
        }
        card.Controls.Add(lblCF)

        ' Progress bar
        Dim progressBar As New ProgressBar() With {
            .Maximum = 100,
            .Value = CInt(cfPercent),
            .Location = New Point(80, 70),
            .Size = New Size(card.Width - 120, 20),
            .Style = ProgressBarStyle.Continuous
        }
        card.Controls.Add(progressBar)

        ' Description
        Dim lblDesc As New Label() With {
            .Text = result.ProfilLulusan.Deskripsi,
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .ForeColor = Color.Gray,
            .AutoSize = True,
            .MaximumSize = New Size(card.Width - 40, 0),
            .Location = New Point(80, 100)
        }
        card.Controls.Add(lblDesc)

        ' Skills required
        Dim lblSkills As New Label() With {
            .Text = $"Skills: {result.ProfilLulusan.KompetensiUtama}",
            .Font = New Font("Segoe UI", 8, FontStyle.Italic),
            .ForeColor = Color.FromArgb(127, 140, 141),
            .AutoSize = True,
            .MaximumSize = New Size(card.Width - 40, 0),
            .Location = New Point(80, lblDesc.Bottom + 10)
        }
        card.Controls.Add(lblSkills)

        ' Matched rules
        Dim lblRules As New Label() With {
            .Text = $"Rules: {String.Join(", ", result.MatchedRules)}",
            .Font = New Font("Segoe UI", 8, FontStyle.Regular),
            .ForeColor = Color.FromArgb(52, 152, 219),
            .AutoSize = True,
            .MaximumSize = New Size(card.Width - 40, 0),
            .Location = New Point(80, lblSkills.Bottom + 5)
        }
        card.Controls.Add(lblRules)

        ' Adjust card height
        card.Height = lblRules.Bottom + 20

        Return card
    End Function

    Private Function GetRankingColor(ranking As Integer) As Color
        Select Case ranking
            Case 1
                Return Color.FromArgb(241, 196, 15) ' Gold
            Case 2
                Return Color.FromArgb(149, 165, 166) ' Silver
            Case 3
                Return Color.FromArgb(205, 127, 50) ' Bronze
            Case Else
                Return Color.Gray
        End Select
    End Function

    Private Function GetCFColor(cfPercent As Double) As Color
        If cfPercent >= 80 Then
            Return Color.FromArgb(39, 174, 96) ' Green
        ElseIf cfPercent >= 60 Then
            Return Color.FromArgb(241, 196, 15) ' Yellow
        ElseIf cfPercent >= 40 Then
            Return Color.FromArgb(230, 126, 34) ' Orange
        Else
            Return Color.FromArgb(192, 57, 43) ' Red
        End If
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        Try
            ' Simpan hasil ke database
            Dim inferenceService As New InferenceService()
            Dim allResponses As New Dictionary(Of String, Double)()
            ' Note: You need to pass actual responses from assessment forms
            ' This is a placeholder - implement proper response collection

            Dim assessmentId = inferenceService.SaveAssessmentResults(_userId, allResponses, _results)

            MessageBox.Show($"Hasil berhasil disimpan dengan ID Assessment: {assessmentId}",
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Gagal menyimpan hasil: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewHistory_Click(sender As Object, e As EventArgs)
        ' TODO: Implement history view
        MessageBox.Show("Fitur History akan segera ditambahkan", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnNewTest_Click(sender As Object, e As EventArgs)
        Me.Close()
        ' Navigate back to main dashboard
        Dim mainForm As New Form2()
        mainForm.Show()
    End Sub
End Class
