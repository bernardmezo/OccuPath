Public Class FormKategoriA
    Private userName As String
    Private currentQuestionIndex As Integer = 0
    Private totalQuestions As Integer = 10
    Private answers As New Dictionary(Of Integer, String)
    Private questions As New List(Of QuestionData)

    Public Sub New(username As String)
        InitializeComponent()
        Me.userName = username
    End Sub

    Private Sub FormKategoriA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Backend will load questions here
        LoadQuestions()
        DisplayQuestion()
    End Sub

    Private Sub LoadQuestions()
        ' TODO: Backend populate method ini dengan pertanyaan real
        ' Contoh:
        '
        ' questions.Add(New QuestionData With {
        '     .QuestionText = "Jenis kelamin Anda?",
        '     .Options = New List(Of String) From {"Laki-laki", "Perempuan"}
        ' })
        '
        ' questions.Add(New QuestionData With {
        '     .QuestionText = "Status pendidikan saat ini?",
        '     .Options = New List(Of String) From {"Aktif", "Non-aktif", "Cuti"}
        ' })
        '
        ' ... tambah 10 pertanyaan total
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
            btnNext.Text = If(currentQuestionIndex = totalQuestions - 1, "Lanjut ke Kategori B ?", "Selanjutnya ?")
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
            ' TODO: Backend save answers here
            MessageBox.Show("Data Kategori A berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Open Category B form
            Dim kategoriBForm As New FormKategoriB(userName)
            Me.Hide()
            Dim result = kategoriBForm.ShowDialog()

            If result = DialogResult.Retry Then
                Me.Show()
            Else
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim result = MessageBox.Show("Apakah Anda yakin ingin membatalkan? Data tidak akan disimpan.", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    ' Data structure for backend
    Public Class QuestionData
        Public Property QuestionText As String
        Public Property Options As List(Of String)
    End Class
End Class
