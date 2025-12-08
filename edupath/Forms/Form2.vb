Public Class Form2
    Private currentQuestionIndex As Integer = 0
    Private totalQuestions As Integer = 10
    Private answers As New Dictionary(Of Integer, String)

    ' TODO: Backend will fill this with actual questions
    Private questions As New List(Of QuestionData)

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO: Backend will load questions here
        LoadQuestions()
        DisplayQuestion()
    End Sub

    Private Sub LoadQuestions()
        ' TODO: Backend akan populate method ini dengan data real
        ' Contoh implementasi untuk backend:
        '
        ' questions.Add(New QuestionData With {
        '     .QuestionText = "Apa warna favorit Anda?",
        '     .Options = New List(Of String) From {"Merah", "Biru", "Hijau", "Kuning"}
        ' })
        '
        ' Backend: isi questions list di sini
    End Sub

    Private Sub DisplayQuestion()
        If currentQuestionIndex >= 0 AndAlso currentQuestionIndex < questions.Count Then
            ' Update progress
            lblProgress.Text = $"Pertanyaan {currentQuestionIndex + 1} / {totalQuestions}"

            ' Display question
            Dim currentQ = questions(currentQuestionIndex)
            lblQuestion.Text = currentQ.QuestionText

            ' Load options to combobox
            cboAnswer.Items.Clear()
            For Each opt In currentQ.Options
                cboAnswer.Items.Add(opt)
            Next

            ' Restore previous answer if exists
            If answers.ContainsKey(currentQuestionIndex) Then
                Dim savedAnswer = answers(currentQuestionIndex)
                Dim index = cboAnswer.Items.IndexOf(savedAnswer)
                If index >= 0 Then
                    cboAnswer.SelectedIndex = index
                End If
            Else
                cboAnswer.SelectedIndex = -1
            End If

            ' Update button states
            btnPrevious.Enabled = (currentQuestionIndex > 0)
            btnNext.Text = If(currentQuestionIndex = totalQuestions - 1, "Selesai", "Selanjutnya →")
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Validate answer selected
        If cboAnswer.SelectedIndex = -1 Then
            MessageBox.Show("Silakan pilih jawaban terlebih dahulu!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Save answer
        answers(currentQuestionIndex) = cboAnswer.SelectedItem.ToString()

        ' Check if last question
        If currentQuestionIndex = totalQuestions - 1 Then
            ' TODO: Backend will process answers here
            MessageBox.Show("Survey selesai! Data akan diproses.", "Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            ' Go to next question
            currentQuestionIndex += 1
            DisplayQuestion()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentQuestionIndex > 0 Then
            currentQuestionIndex -= 1
            DisplayQuestion()
        End If
    End Sub

    ' Data structure for backend
    Public Class QuestionData
        Public Property QuestionText As String
        Public Property Options As List(Of String)
    End Class
End Class