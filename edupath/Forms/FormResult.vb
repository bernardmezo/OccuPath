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
        SetupButtonHoverEffects()
    End Sub

    Private Sub SetupButtonHoverEffects()
        ' Dashboard button hover
        AddHandler btnDashboard.MouseEnter, Sub(s, e)
            btnDashboard.BackColor = Color.FromArgb(52, 152, 219)
        End Sub
        AddHandler btnDashboard.MouseLeave, Sub(s, e)
            btnDashboard.BackColor = Color.FromArgb(41, 128, 185)
        End Sub

        ' New Test button hover
        AddHandler btnNewTest.MouseEnter, Sub(s, e)
            btnNewTest.BackColor = Color.FromArgb(236, 240, 241)
        End Sub
        AddHandler btnNewTest.MouseLeave, Sub(s, e)
            btnNewTest.BackColor = Color.White
        End Sub
    End Sub

    Private Sub LoadResults()
        ' Clear existing controls
        panelResults.Controls.Clear()

        If _results Is Nothing OrElse _results.Count = 0 Then
            Dim lblNoResult As New Label() With {
                .Text = "Tidak ada hasil rekomendasi yang ditemukan." & vbCrLf & "Silakan coba tes lagi.",
                .Font = New Font("Segoe UI", 12, FontStyle.Regular),
                .ForeColor = Color.FromArgb(127, 140, 141),
                .TextAlign = ContentAlignment.MiddleCenter,
                .AutoSize = False,
                .Size = New Size(700, 100),
                .Location = New Point(20, 100)
            }
            panelResults.Controls.Add(lblNoResult)
            Return
        End If

        ' Display top 3 results
        Dim topResults = _results.Take(3).ToList()
        For i = 0 To topResults.Count - 1
            Dim resultCard = CreateResultCard(topResults(i), i)
            panelResults.Controls.Add(resultCard)
        Next
    End Sub

    Private Function CreateResultCard(result As InferenceService.InferenceResult, index As Integer) As Panel
        Dim card As New Panel() With {
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle,
            .Size = New Size(700, 180),
            .Padding = New Padding(20),
            .Margin = New Padding(0, 0, 0, 15)
        }

        ' Left accent bar based on ranking
        Dim accentBar As New Panel() With {
            .BackColor = GetRankingAccentColor(result.Ranking),
            .Size = New Size(5, 180),
            .Location = New Point(0, 0),
            .Dock = DockStyle.Left
        }
        card.Controls.Add(accentBar)

        ' Ranking badge
        Dim badge As New Label() With {
            .Text = GetRankingEmoji(result.Ranking),
            .Font = New Font("Segoe UI", 32.0F),
            .AutoSize = True,
            .Location = New Point(25, 15)
        }
        card.Controls.Add(badge)

        ' Profile name
        Dim lblName As New Label() With {
            .Text = result.ProfilLulusan.Nama.ToUpper(),
            .Font = New Font("Segoe UI", 16.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(44, 62, 80),
            .AutoSize = True,
            .Location = New Point(90, 20)
        }
        card.Controls.Add(lblName)

        ' CF percentage (big number)
        Dim cfPercent = result.CertaintyFactor * 100
        Dim lblCF As New Label() With {
            .Text = $"{cfPercent:F1}%",
            .Font = New Font("Segoe UI", 28.0F, FontStyle.Bold),
            .ForeColor = GetCFColor(cfPercent),
            .AutoSize = True,
            .Location = New Point(90, 55)
        }
        card.Controls.Add(lblCF)

        Dim lblCFLabel As New Label() With {
            .Text = "Tingkat Kesesuaian",
            .Font = New Font("Segoe UI", 9.0F),
            .ForeColor = Color.FromArgb(127, 140, 141),
            .AutoSize = True,
            .Location = New Point(90, 95)
        }
        card.Controls.Add(lblCFLabel)

        ' Progress bar
        Dim progressBg As New Panel() With {
            .BackColor = Color.FromArgb(236, 240, 241),
            .Size = New Size(450, 8),
            .Location = New Point(220, 85)
        }
        card.Controls.Add(progressBg)

        Dim progressFill As New Panel() With {
            .BackColor = GetCFColor(cfPercent),
            .Size = New Size(CInt(450 * (cfPercent / 100)), 8),
            .Location = New Point(0, 0)
        }
        progressBg.Controls.Add(progressFill)

        ' Description
        Dim lblDesc As New Label() With {
            .Text = If(String.IsNullOrEmpty(result.ProfilLulusan.Deskripsi),
                      "Profil lulusan yang cocok untuk Anda",
                      result.ProfilLulusan.Deskripsi),
            .Font = New Font("Segoe UI", 9.5F),
            .ForeColor = Color.FromArgb(52, 73, 94),
            .AutoSize = False,
            .Size = New Size(580, 40),
            .Location = New Point(90, 115)
        }
        card.Controls.Add(lblDesc)

        ' Skills tag
        If Not String.IsNullOrEmpty(result.ProfilLulusan.KompetensiUtama) Then
            Dim lblSkills As New Label() With {
                .Text = $"?? Skills: {result.ProfilLulusan.KompetensiUtama}",
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(41, 128, 185),
                .AutoSize = False,
                .Size = New Size(580, 20),
                .Location = New Point(90, 150)
            }
            card.Controls.Add(lblSkills)
        End If

        Return card
    End Function

    Private Function GetRankingEmoji(ranking As Integer) As String
        Select Case ranking
            Case 1
                Return "??"
            Case 2
                Return "??"
            Case 3
                Return "??"
            Case Else
                Return "?"
        End Select
    End Function

    Private Function GetRankingAccentColor(ranking As Integer) As Color
        Select Case ranking
            Case 1
                Return Color.FromArgb(241, 196, 15) ' Gold
            Case 2
                Return Color.FromArgb(149, 165, 166) ' Silver
            Case 3
                Return Color.FromArgb(205, 127, 50) ' Bronze
            Case Else
                Return Color.FromArgb(189, 195, 199)
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
            Return Color.FromArgb(231, 76, 60) ' Red
        End If
    End Function

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ' Navigate back to dashboard/main menu
        Me.Close()
        ' TODO: Show Form5 or Dashboard
        ' Dim dashboardForm As New Form5(_userId, "Username")
        ' dashboardForm.Show()
    End Sub

    Private Sub btnNewTest_Click(sender As Object, e As EventArgs) Handles btnNewTest.Click
        ' Start new assessment
        Dim result = MessageBox.Show("Mulai tes baru? Data ini akan disimpan ke riwayat.",
                                     "Konfirmasi",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
            ' TODO: Navigate to assessment start
            ' Dim assessmentForm As New FormKategoriA()
            ' assessmentForm.Show()
        End If
    End Sub
End Class
