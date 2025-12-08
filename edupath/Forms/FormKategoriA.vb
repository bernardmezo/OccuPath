' ============================================
' FormKategoriA: Form Kategori A - Data Diri
' Menggunakan 3-Layer Architecture
' ============================================

Imports OccuPath.Services
Imports OccuPath.Core
Imports OccuPath.Models

Public Class FormKategoriA
    Private userName As String
    Private currentQuestionIndex As Integer = 0
    Private answers As New Dictionary(Of Integer, QuestionOptionItem) ' Stores full option object
    Private questions As New List(Of QuestionItem)

    ' Service layer instance
    Private ReadOnly _questionService As New QuestionService()

    Public Sub New(username As String)
        InitializeComponent()
        Me.userName = username
    End Sub

    Private Sub FormKategoriA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = $"{AppConstants.APP_NAME} - Kategori A: Data Diri"
            LoadQuestionsFromDB()
            If questions.Count > 0 Then
                DisplayQuestion()
            Else
                MessageBox.Show("Data pertanyaan tidak ditemukan di database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Koneksi Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub LoadQuestionsFromDB()
        ' Fetch dynamic questions from QuestionService
        Dim dbQuestions = _questionService.GetKategoriAQuestions()
        
        ' Convert to local QuestionItem format
        questions.Clear()
        For Each q In dbQuestions
            Dim item As New QuestionItem() With {
                .QuestionCode = q.Code,
                .QuestionText = q.Text
            }
            item.Options = New List(Of QuestionOptionItem)()
            For Each opt In q.Options
                item.Options.Add(New QuestionOptionItem() With {
                    .Text = opt.Text,
                    .Value = opt.Value
                })
            Next
            questions.Add(item)
        Next
    End Sub

    Private Sub DisplayQuestion()
        If currentQuestionIndex >= 0 AndAlso currentQuestionIndex < questions.Count Then
            Dim currentQ = questions(currentQuestionIndex)
            
            ' Update UI
            lblProgress.Text = $"Pertanyaan {currentQuestionIndex + 1} / {questions.Count}"
            lblQuestion.Text = currentQ.QuestionText

            ' Setup ComboBox Data Binding
            cboAnswer.DataSource = Nothing ' Reset
            cboAnswer.DataSource = currentQ.Options
            cboAnswer.DisplayMember = "Text"
            cboAnswer.ValueMember = "Value"
            cboAnswer.SelectedIndex = -1

            ' Restore previous answer
            If answers.ContainsKey(currentQuestionIndex) Then
                Dim savedOption = answers(currentQuestionIndex)
                ' Find index by matching text
                For i As Integer = 0 To cboAnswer.Items.Count - 1
                    Dim item = CType(cboAnswer.Items(i), QuestionOptionItem)
                    If item.Text = savedOption.Text Then
                        cboAnswer.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If

            ' Update buttons
            btnPrevious.Enabled = (currentQuestionIndex > 0)
            btnNext.Text = If(currentQuestionIndex = questions.Count - 1, "Selesai & Lanjut", "Selanjutnya ?")
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Validation
        If cboAnswer.SelectedIndex = -1 Then
            MessageBox.Show(AppConstants.Messages.VALIDATION_REQUIRED, "Validasi Diperlukan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Save selected Option object (Text + Value)
        Dim selectedOpt = CType(cboAnswer.SelectedItem, QuestionOptionItem)
        answers(currentQuestionIndex) = selectedOpt

        ' Navigation
        If currentQuestionIndex = questions.Count - 1 Then
            ProcessAndSaveData()
        Else
            currentQuestionIndex += 1
            DisplayQuestion()
        End If
    End Sub

    Private Sub ProcessAndSaveData()
        Try
            ' Build answer dictionary dengan question code sebagai key
            Dim answersWithCode As New Dictionary(Of String, OccuPath.Models.QuestionOption)()
            
            For i = 0 To questions.Count - 1
                If answers.ContainsKey(i) Then
                    Dim code = questions(i).QuestionCode
                    Dim ans = answers(i)
                    answersWithCode(code) = New OccuPath.Models.QuestionOption() With {
                        .Text = ans.Text,
                        .Value = ans.Value
                    }
                End If
            Next

            ' Save using QuestionService
            Dim userId = If(SessionManager.IsLoggedIn, SessionManager.UserId, UserProfile.Current.UserID)
            _questionService.SaveKategoriAAnswers(userId, answersWithCode)

            ' Update legacy UserProfile untuk backward compatibility
            Dim profile = UserProfile.Current
            profile.Reset()

            If answers.ContainsKey(0) Then profile.F_A1_JenisKelamin = answers(0).Text
            If answers.ContainsKey(1) Then profile.F_A2_StatusPendidikan = answers(1).Text
            If answers.ContainsKey(2) Then profile.F_A3_ProgramStudi = answers(2).Text
            If answers.ContainsKey(3) Then profile.F_A4_Semester = answers(3).Value
            If answers.ContainsKey(4) Then profile.F_A5_StatusMahasiswa = answers(4).Text
            If answers.ContainsKey(5) Then profile.F_A6_LatarBelakang = answers(5).Text
            If answers.ContainsKey(6) Then profile.F_A7_AlasanMasuk = answers(6).Text
            If answers.ContainsKey(7) Then profile.F_A8_TujuanKuliah = answers(7).Text
            If answers.ContainsKey(8) Then profile.F_A9_MetodeBelajar = answers(8).Text
            If answers.ContainsKey(9) Then profile.F_A10_MotivasiBelajar = answers(9).Value

            MessageBox.Show(AppConstants.Messages.SAVE_SUCCESS & vbCrLf & 
                          "Lanjutkan ke Kategori B - Data Akademis.", 
                          "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim frmB As New FormKategoriB(userName)
            Me.Hide()
            frmB.ShowDialog()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentQuestionIndex > 0 Then
            currentQuestionIndex -= 1
            DisplayQuestion()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("Batalkan pengisian?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    ' ==========================================
    ' Helper Classes for Form Data Binding
    ' (Local classes untuk UI binding)
    ' ==========================================
    Public Class QuestionItem
        Public Property QuestionCode As String
        Public Property QuestionText As String
        Public Property Options As List(Of QuestionOptionItem)
    End Class

    Public Class QuestionOptionItem
        Public Property Text As String
        Public Property Value As Integer
    End Class
End Class
