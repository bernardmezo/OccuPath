Public Class FormKategoriB
    Private userName As String
    Private currentQuestionIndex As Integer = 0
    Private totalQuestions As Integer = 10
    Private answers As New Dictionary(Of Integer, String)
    Private questions As New List(Of QuestionData)

    Public Sub New(username As String)
        InitializeComponent()
        Me.userName = username
    End Sub

    Private Sub FormKategoriB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Backend will load questions here
        LoadQuestions()
        DisplayQuestion()
    End Sub

    Private Sub LoadQuestions()
        ' TODO: Backend populate method ini dengan pertanyaan real
        ' Contoh:
        '
        ' questions.Add(New QuestionData With {
        '     .QuestionText = "IPK terakhir Anda?",
        '     .Options = New List(Of String) From {"< 2.50", "2.50 – 2.99", "3.00 – 3.49", "3.50 – 4.00"}
        ' })
        '
        ' questions.Add(New QuestionData With {
        '     .QuestionText = "Tren IPK Anda?",
        '     .Options = New List(Of String) From {"Meningkat", "Stabil", "Menurun"}
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
            Try
                ' Save data to Database (MySQL)
                DatabaseConnection.SaveUserProfile(UserProfile.Current)

                MessageBox.Show("Data berhasil disimpan ke database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Gagal menyimpan data: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
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

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim result = MessageBox.Show("Kembali ke Kategori A? Data yang sudah diisi tidak akan disimpan.", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.DialogResult = DialogResult.Retry
            Me.Close()
        End If
    End Sub

    ' Data structure for backend
    Public Class QuestionData
        Public Property QuestionText As String
        Public Property Options As List(Of String)
    End Class
End Class
