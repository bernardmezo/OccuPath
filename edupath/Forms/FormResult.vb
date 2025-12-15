Imports System.Drawing
Imports System.Drawing.Printing
Imports OccuPath.Services
Imports OccuPath.Models

''' <summary>
''' Form untuk menampilkan hasil inferensi sistem pakar
''' </summary>
Public Class FormResult
    Private _results As List(Of InferenceService.InferenceResult)
    Private _userId As Integer
    Private printDoc As New PrintDocument()
    Private printPreviewDialog As New PrintPreviewDialog()

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

        ' Print button hover
        AddHandler btnPrint.MouseEnter, Sub(s, e)
            btnPrint.BackColor = Color.FromArgb(56, 214, 123)
        End Sub
        AddHandler btnPrint.MouseLeave, Sub(s, e)
            btnPrint.BackColor = Color.FromArgb(46, 204, 113)
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
                .Text = $"Skills: {result.ProfilLulusan.KompetensiUtama}",
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
                Return "1"
            Case 2
                Return "2"
            Case 3
                Return "3"
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            ' Setup print document
            AddHandler printDoc.PrintPage, AddressOf PrintDocument_PrintPage
            
            ' Setup print preview
            printPreviewDialog.Document = printDoc
            printPreviewDialog.Width = 800
            printPreviewDialog.Height = 600
            printPreviewDialog.Text = "Pratinjau Cetak - Hasil Asesmen"
            
            ' Show print preview dialog
            If printPreviewDialog.ShowDialog() = DialogResult.OK Then
                printDoc.Print()
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mencetak: " & ex.Message,
                          "Error Cetak",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim fontTitle As New Font("Segoe UI", 18, FontStyle.Bold)
        Dim fontHeader As New Font("Segoe UI", 14, FontStyle.Bold)
        Dim fontBody As New Font("Segoe UI", 11, FontStyle.Regular)
        Dim fontSmall As New Font("Segoe UI", 9, FontStyle.Regular)
        
        Dim yPos As Single = e.MarginBounds.Top
        Dim xPos As Single = e.MarginBounds.Left
        Dim lineHeight As Single = fontBody.GetHeight(e.Graphics)
        
        ' Print title
        Dim title As String = "HASIL ASESMEN OKUPATH"
        Dim titleSize = e.Graphics.MeasureString(title, fontTitle)
        e.Graphics.DrawString(title, fontTitle, Brushes.Black,
                            e.MarginBounds.Left + (e.MarginBounds.Width - titleSize.Width) / 2,
                            yPos)
        yPos += titleSize.Height + 10
        
        ' Print date
        Dim dateText As String = "Tanggal: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm")
        e.Graphics.DrawString(dateText, fontSmall, Brushes.Gray,
                            e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(dateText, fontSmall).Width) / 2,
                            yPos)
        yPos += lineHeight + 20
        
        ' Draw separator line
        e.Graphics.DrawLine(Pens.Black, xPos, yPos, xPos + e.MarginBounds.Width, yPos)
        yPos += 20
        
        ' Print results
        If _results IsNot Nothing AndAlso _results.Count > 0 Then
            Dim topResults = _results.Take(3).ToList()
            
            For i = 0 To topResults.Count - 1
                Dim result = topResults(i)
                
                ' Ranking header
                Dim rankingText As String = ""
                Select Case result.Ranking
                    Case 1 : rankingText = "REKOMENDASI UTAMA"
                    Case 2 : rankingText = "REKOMENDASI KEDUA"
                    Case 3 : rankingText = "REKOMENDASI KETIGA"
                End Select
                
                e.Graphics.DrawString(rankingText, fontHeader, Brushes.Black, xPos, yPos)
                yPos += fontHeader.GetHeight(e.Graphics) + 5
                
                ' Profile name
                e.Graphics.DrawString(result.ProfilLulusan.Nama.ToUpper(), fontHeader,
                                    Brushes.DarkBlue, xPos, yPos)
                yPos += fontHeader.GetHeight(e.Graphics) + 5
                
                ' CF Percentage
                Dim cfText As String = String.Format("Tingkat Kesesuaian: {0:F1}%", result.CertaintyFactor)
                e.Graphics.DrawString(cfText, fontBody, Brushes.DarkGreen, xPos, yPos)
                yPos += lineHeight + 10
                
                ' Description
                e.Graphics.DrawString("Deskripsi:", fontBody, Brushes.Black, xPos, yPos)
                yPos += lineHeight
                
                ' Word wrap description
                Dim descWords = result.ProfilLulusan.Deskripsi.Split(" "c)
                Dim currentLine As String = ""
                For Each word In descWords
                    Dim testLine = If(String.IsNullOrEmpty(currentLine), word, currentLine & " " & word)
                    Dim testSize = e.Graphics.MeasureString(testLine, fontBody)
                    
                    If testSize.Width > e.MarginBounds.Width - 20 Then
                        e.Graphics.DrawString(currentLine, fontBody, Brushes.Black, xPos + 10, yPos)
                        yPos += lineHeight
                        currentLine = word
                    Else
                        currentLine = testLine
                    End If
                Next
                If Not String.IsNullOrEmpty(currentLine) Then
                    e.Graphics.DrawString(currentLine, fontBody, Brushes.Black, xPos + 10, yPos)
                    yPos += lineHeight
                End If
                
                ' Skills
                If Not String.IsNullOrEmpty(result.ProfilLulusan.KompetensiUtama) Then
                    yPos += 5
                    e.Graphics.DrawString("Kompetensi Utama:", fontBody, Brushes.Black, xPos, yPos)
                    yPos += lineHeight
                    
                    ' Word wrap skills
                    Dim skillWords = result.ProfilLulusan.KompetensiUtama.Split(" "c)
                    currentLine = ""
                    For Each word In skillWords
                        Dim testLine = If(String.IsNullOrEmpty(currentLine), word, currentLine & " " & word)
                        Dim testSize = e.Graphics.MeasureString(testLine, fontBody)
                        
                        If testSize.Width > e.MarginBounds.Width - 20 Then
                            e.Graphics.DrawString(currentLine, fontBody, Brushes.Black, xPos + 10, yPos)
                            yPos += lineHeight
                            currentLine = word
                        Else
                            currentLine = testLine
                        End If
                    Next
                    If Not String.IsNullOrEmpty(currentLine) Then
                        e.Graphics.DrawString(currentLine, fontBody, Brushes.Black, xPos + 10, yPos)
                        yPos += lineHeight
                    End If
                End If
                
                ' Separator between results
                yPos += 15
                e.Graphics.DrawLine(Pens.LightGray, xPos, yPos, xPos + e.MarginBounds.Width, yPos)
                yPos += 15
                
                ' Check if we need a new page
                If yPos > e.MarginBounds.Bottom - 100 AndAlso i < topResults.Count - 1 Then
                    e.HasMorePages = True
                    Return
                End If
            Next
        Else
            e.Graphics.DrawString("Tidak ada hasil rekomendasi yang ditemukan.",
                                fontBody, Brushes.Gray, xPos, yPos)
        End If
        
        ' Footer
        yPos = e.MarginBounds.Bottom
        Dim footerText As String = "OccuPath - Sistem Rekomendasi Profil Lulusan"
        Dim footerSize = e.Graphics.MeasureString(footerText, fontSmall)
        e.Graphics.DrawString(footerText, fontSmall, Brushes.Gray,
                            e.MarginBounds.Left + (e.MarginBounds.Width - footerSize.Width) / 2,
                            yPos)
        
        e.HasMorePages = False
    End Sub
End Class
