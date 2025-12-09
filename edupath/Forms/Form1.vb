Public Class Form1
    Private Sub btnGetStarted_Click(sender As Object, e As EventArgs) Handles btnGetStarted.Click
        ' Navigate to login/register page
        Dim loginForm As New Form4()
        Dim result = loginForm.ShowDialog()

        ' If login successful, close landing page
        If result = DialogResult.OK Then
            Me.Hide()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Test Database Connection with detailed error reporting
        Try
            Console.WriteLine("Testing database connection...")

            If DatabaseConnection.TestConnection() Then
                Console.WriteLine("✅ Database connected successfully.")
                ' Optional: Show success in status bar or label
            Else
                ' Error message already shown by TestConnection()
                Console.WriteLine("❌ Database connection failed.")
            End If

        Catch ex As Exception
            MessageBox.Show($"Unexpected error: {ex.Message}",
                          "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lblFooter_Click(sender As Object, e As EventArgs) Handles lblFooter.Click

    End Sub
End Class
