Imports System.Drawing
Imports OccuPath.Core

''' <summary>
''' Form Dashboard - Halaman utama setelah login
''' </summary>
Public Class FormDashboard
    Private _userId As Integer
    Private _username As String

    Public Sub New(userId As Integer, username As String)
        InitializeComponent()
        _userId = userId
        _username = username
    End Sub

    Private Sub FormDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = $"Selamat Datang, {_username}!"
        LoadUserStatistics()
    End Sub

    Private Sub LoadUserStatistics()
        Try
            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                ' Count total assessments
                Dim sqlCount = "SELECT COUNT(*) FROM assessments WHERE user_id = @userId"
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand(sqlCount, conn)
                    cmd.Parameters.AddWithValue("@userId", _userId)
                    Dim totalAssessments = Convert.ToInt32(cmd.ExecuteScalar())
                    lblTotalAssessments.Text = $"Total Tes: {totalAssessments}"
                End Using

                ' Get last assessment date
                Dim sqlLast = "SELECT MAX(date_taken) FROM assessments WHERE user_id = @userId"
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand(sqlLast, conn)
                    cmd.Parameters.AddWithValue("@userId", _userId)
                    Dim lastDate = cmd.ExecuteScalar()
                    If lastDate IsNot DBNull.Value Then
                        lblLastAssessment.Text = $"Tes Terakhir: {CDate(lastDate):dd MMM yyyy}"
                    Else
                        lblLastAssessment.Text = "Belum ada tes"
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error loading statistics: {ex.Message}")
        End Try
    End Sub

    Private Sub btnStartAssessment_Click(sender As Object, e As EventArgs) Handles btnStartAssessment.Click
        Dim assessmentForm As New FormAssessment(_userId)
        assessmentForm.ShowDialog()
        LoadUserStatistics() ' Refresh statistics after assessment
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        MessageBox.Show("Fitur History akan segera ditambahkan dalam update berikutnya.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        MessageBox.Show("Fitur Profile Management akan segera ditambahkan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            SessionManager.ClearSession()
            Me.Hide()
            Dim loginForm As New Form4()
            loginForm.ShowDialog()
            Me.Close()
        End If
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Dim aboutMsg = "OccuPath - Sistem Pakar Profil Lulusan" & vbCrLf &
                       "Version: 1.0 MVP" & vbCrLf & vbCrLf &
                       "Menggunakan metode:" & vbCrLf &
                       "- Forward Chaining" & vbCrLf &
                       "- Certainty Factor (CF)" & vbCrLf & vbCrLf &
                       "© 2025 OccuPath Team"

        MessageBox.Show(aboutMsg, "Tentang OccuPath", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
