Public Class Form3
    Private currentQuestionIndex As Integer = 0
    Private totalQuestions As Integer = 20
    Private answers As New Dictionary(Of Integer, String)

    ' TODO: Backend will fill this with actual questions
    Private questions As New List(Of QuestionData)

    ' Fixed scale labels for MBTI-style picker
    Private scaleLabels As String() = {
        "Sangat Tidak Setuju",
        "Tidak Setuju",
        "Netral",
        "Setuju",
        "Sangat Setuju"
    }

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO: Backend will load questions here
        LoadQuestions()

        ' Set up fixed labels for the scale
        SetupScaleLabels()

        DisplayQuestion()
    End Sub

    Private Sub SetupScaleLabels()
        ' Set fixed labels for the MBTI-style scale
        lblOption1.Text = scaleLabels(0)
        lblOption2.Text = scaleLabels(1)
        lblOption3.Text = scaleLabels(2)
        lblOption4.Text = scaleLabels(3)
        lblOption5.Text = scaleLabels(4)

        ' Add hover effects for radio buttons
        AddHandler rbOption1.MouseEnter, AddressOf RadioButton_MouseEnter
        AddHandler rbOption1.MouseLeave, AddressOf RadioButton_MouseLeave
        AddHandler rbOption2.MouseEnter, AddressOf RadioButton_MouseEnter
        AddHandler rbOption2.MouseLeave, AddressOf RadioButton_MouseLeave
        AddHandler rbOption3.MouseEnter, AddressOf RadioButton_MouseEnter
        AddHandler rbOption3.MouseLeave, AddressOf RadioButton_MouseLeave
        AddHandler rbOption4.MouseEnter, AddressOf RadioButton_MouseEnter
        AddHandler rbOption4.MouseLeave, AddressOf RadioButton_MouseLeave
        AddHandler rbOption5.MouseEnter, AddressOf RadioButton_MouseEnter
        AddHandler rbOption5.MouseLeave, AddressOf RadioButton_MouseLeave

        ' Add click handlers for better UX
        AddHandler rbOption1.CheckedChanged, AddressOf RadioButton_CheckedChanged
        AddHandler rbOption2.CheckedChanged, AddressOf RadioButton_CheckedChanged
        AddHandler rbOption3.CheckedChanged, AddressOf RadioButton_CheckedChanged
        AddHandler rbOption4.CheckedChanged, AddressOf RadioButton_CheckedChanged
        AddHandler rbOption5.CheckedChanged, AddressOf RadioButton_CheckedChanged
    End Sub

    Private Sub RadioButton_MouseEnter(sender As Object, e As EventArgs)
        Dim rb As RadioButton = CType(sender, RadioButton)
        If Not rb.Checked Then
            rb.BackColor = Color.FromArgb(220, 225, 230)
        End If
    End Sub

    Private Sub RadioButton_MouseLeave(sender As Object, e As EventArgs)
        Dim rb As RadioButton = CType(sender, RadioButton)
        If Not rb.Checked Then
            rb.BackColor = Color.FromArgb(236, 240, 241)
        End If
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs)
        Dim rb As RadioButton = CType(sender, RadioButton)
        If rb.Checked Then
            rb.ForeColor = Color.White
        Else
            rb.ForeColor = Color.FromArgb(127, 140, 141)
            rb.BackColor = Color.FromArgb(236, 240, 241)
        End If
    End Sub

    Private Sub LoadQuestions()
        ' TODO: Backend akan populate method ini dengan data real
        ' Note: Options tidak perlu disediakan karena skala fixed
        ' Backend hanya perlu isi QuestionText
        '
        ' Contoh implementasi untuk backend:
        '
        ' questions.Add(New QuestionData With {
        '     .QuestionText = "Saya suka bekerja dalam tim"
        ' })
        '
        ' questions.Add(New QuestionData With {
        '     .QuestionText = "Saya lebih suka bekerja sendiri"
        ' })
        '
        ' Backend: isi questions list di sini dengan hanya QuestionText
    End Sub

    Private Sub DisplayQuestion()
        If currentQuestionIndex >= 0 AndAlso currentQuestionIndex < questions.Count Then
            ' Update Progress Label (Form3 only has label, no progress bar)
            lblProgress.Text = $"Pertanyaan {currentQuestionIndex + 1} / {totalQuestions}"

            ' Display question
            Dim currentQ = questions(currentQuestionIndex)
            lblQuestion.Text = currentQ.QuestionText

            ' Restore previous answer if exists
            Dim radioButtons = {rbOption1, rbOption2, rbOption3, rbOption4, rbOption5}

            If answers.ContainsKey(currentQuestionIndex) Then
                Dim savedAnswer = answers(currentQuestionIndex)
                Dim answerIndex = Array.IndexOf(scaleLabels, savedAnswer)
                If answerIndex >= 0 AndAlso answerIndex < radioButtons.Length Then
                    radioButtons(answerIndex).Checked = True
                End If
            Else
                ' Clear all selections
                For Each rb In radioButtons
                    rb.Checked = False
                Next
            End If

            ' Update button states
            btnPrevious.Enabled = (currentQuestionIndex > 0)
            If currentQuestionIndex = totalQuestions - 1 Then
                btnNext.Text = "Selesai"
            Else
                btnNext.Text = "Selanjutnya >"
            End If
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Validate answer selected
        Dim radioButtons = {rbOption1, rbOption2, rbOption3, rbOption4, rbOption5}
        Dim selectedOption As String = Nothing
        Dim selectedIndex As Integer = -1

        For i As Integer = 0 To radioButtons.Length - 1
            If radioButtons(i).Checked Then
                selectedIndex = i
                selectedOption = scaleLabels(i)
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
            ' answers dictionary contains all responses with question index as key
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
        ' Options property is no longer needed since scale is fixed
        ' But keeping it for backward compatibility
        Public Property Options As List(Of String)
    End Class
End Class