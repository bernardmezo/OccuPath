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
        ' Initialization code if needed
    End Sub
End Class
