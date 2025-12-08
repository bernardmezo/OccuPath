Public Class Form3
    Private currentQuestionIndex As Integer = 0
    Private totalQuestions As Integer = 20
    Private answers As New Dictionary(Of Integer, String)

    ' TODO: Backend will fill this with actual questions
    Private questions As New List(Of QuestionData)

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO: Backend will load questions here
        LoadQuestions()
        DisplayQuestion()
    End Sub

    Private Sub LoadQuestions()
        ' TODO: Backend akan populate method ini dengan data real
        ' Contoh implementasi untuk backend:
        '
        ' questions.Add(New QuestionData With {
        '     .QuestionText = "Saya suka bekerja dalam tim",
        '     .Options = New List(Of String) From {
        '         "Sangat Tidak Setuju",
        '         "Tidak Setuju",
        '         "Netral",
        '         "Setuju",
        '         "Sangat Setuju"
        '     }
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

            ' Load options to radio buttons
            Dim radioButtons = {rbOption1, rbOption2, rbOption3, rbOption4, rbOption5}

            For i As Integer = 0 To Math.Min(currentQ.Options.Count - 1, radioButtons.Length - 1)
                radioButtons(i).Text = currentQ.Options(i)
                radioButtons(i).Visible = True
            Next

            ' Hide unused radio buttons
            For i As Integer = currentQ.Options.Count To radioButtons.Length - 1
                radioButtons(i).Visible = False
            Next

            ' Restore previous answer if exists
            If answers.ContainsKey(currentQuestionIndex) Then
                Dim savedAnswer = answers(currentQuestionIndex)
                For Each rb In radioButtons
                    If rb.Text = savedAnswer Then
                        rb.Checked = True
                        Exit For
                    End If
                Next
            Else
                ' Clear all selections
                For Each rb In radioButtons
                    rb.Checked = False
                Next
            End If

            ' Update button states
            btnPrevious.Enabled = (currentQuestionIndex > 0)
            btnNext.Text = If(currentQuestionIndex = totalQuestions - 1, "Selesai", "Selanjutnya →")
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Validate answer selected
        Dim radioButtons = {rbOption1, rbOption2, rbOption3, rbOption4, rbOption5}
        Dim selectedOption As String = Nothing

        For Each rb In radioButtons
            If rb.Checked Then
                selectedOption = rb.Text
                Exit For
            End If
        Next

        If selectedOption Is Nothing Then
            MessageBox.Show("Silakan pilih salah satu jawaban!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Save answer
        answers(currentQuestionIndex) = selectedOption

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