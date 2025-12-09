Imports System.Drawing

Public Class FormTestDB
    Private Sub FormTestDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TestDatabaseConnection()
    End Sub

    Private Sub TestDatabaseConnection()
        Dim resultText As String = ""
        Dim resultColor As Color

        Try
            ' Test basic connection
            resultText &= "📡 Testing MySQL Connection..." & vbCrLf & vbCrLf

            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                resultText &= "✅ CONNECTION SUCCESS!" & vbCrLf & vbCrLf
                resultText &= $"Server: {conn.ServerVersion}" & vbCrLf
                resultText &= $"Database: {conn.Database}" & vbCrLf
                resultText &= $"State: {conn.State}" & vbCrLf & vbCrLf

                ' Test query
                resultText &= "🔍 Testing Query..." & vbCrLf
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM users;", conn)
                    Dim count = cmd.ExecuteScalar()
                    resultText &= $"✅ Users Table: {count} records" & vbCrLf & vbCrLf
                End Using

                resultColor = Color.FromArgb(39, 174, 96) ' Green
                resultText &= "🎉 Database siap digunakan!"
            End Using

        Catch ex As MySql.Data.MySqlClient.MySqlException
            resultColor = Color.FromArgb(231, 76, 60) ' Red
            resultText &= "❌ MYSQL ERROR!" & vbCrLf & vbCrLf
            resultText &= $"Error Code: {ex.Number}" & vbCrLf
            resultText &= $"Message: {ex.Message}" & vbCrLf & vbCrLf

            Select Case ex.Number
                Case 0
                    resultText &= "💡 SOLUSI: MySQL service tidak jalan. Start XAMPP!"
                Case 1042
                    resultText &= "💡 SOLUSI: Tidak bisa connect ke server MySQL."
                Case 1045
                    resultText &= "💡 SOLUSI: Username/password salah!"
                Case 1049
                    resultText &= "💡 SOLUSI: Database 'db_occupath' tidak ditemukan!"
                Case Else
                    resultText &= $"💡 MySQL Error: {ex.Number}"
            End Select

        Catch ex As Exception
            resultColor = Color.FromArgb(231, 76, 60) ' Red
            resultText &= "❌ ERROR!" & vbCrLf & vbCrLf
            resultText &= $"Type: {ex.GetType().Name}" & vbCrLf
            resultText &= $"Message: {ex.Message}" & vbCrLf & vbCrLf
            resultText &= "💡 KEMUNGKINAN:" & vbCrLf
            resultText &= "- MySQL Connector belum terinstall" & vbCrLf
            resultText &= "- XAMPP MySQL belum running"
        End Try

        ' Display result
        txtResult.Text = resultText
        txtResult.ForeColor = resultColor
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRetry_Click(sender As Object, e As EventArgs) Handles btnRetry.Click
        txtResult.Clear()
        TestDatabaseConnection()
    End Sub
End Class
