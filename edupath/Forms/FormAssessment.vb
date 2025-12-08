Imports MySql.Data.MySqlClient
Imports OccuPath.Services
Imports OccuPath.Models
Imports QuestionOpt = OccuPath.Models.QuestionOption

''' <summary>
''' Form Assessment - Mengumpulkan data dari pengguna untuk inferensi
''' </summary>
Public Class FormAssessment
    Private _userId As Integer
    Private _currentPage As Integer = 1
    Private _totalPages As Integer = 3

    ' Data responses
    Private _personalData As New Dictionary(Of String, Double)()
    Private _akademisData As New Dictionary(Of String, Double)()
    Private _karakterData As New Dictionary(Of String, Double)()

    ' Questions from database
    Private _questionsKategoriA As List(Of Question)
    Private _questionsKategoriB As List(Of Question)
    Private _questionsKategoriC As List(Of Question)

    Public Sub New(userId As Integer)
        InitializeComponent()
        _userId = userId
    End Sub

    Private Sub FormAssessment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadQuestions()
            ShowPage(_currentPage)
        Catch ex As Exception
            MessageBox.Show($"Error loading assessment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub LoadQuestions()
        Using conn = DatabaseConnection.GetConnection()
            conn.Open()

            ' Load Kategori A
            _questionsKategoriA = LoadQuestionsByCategory(conn, "A")

            ' Load Kategori B
            _questionsKategoriB = LoadQuestionsByCategory(conn, "B")

            ' Load Kategori C
            _questionsKategoriC = LoadQuestionsByCategory(conn, "C")
        End Using
    End Sub

    Private Function LoadQuestionsByCategory(conn As MySqlConnection, kategori As String) As List(Of Question)
        Dim questions As New List(Of Question)()

        Dim sql = "SELECT code, text, question_type, display_order FROM questions " &
                  "WHERE kategori = @kategori AND is_active = TRUE ORDER BY display_order"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@kategori", kategori)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    Dim question As New Question() With {
                        .Code = reader.GetString("code"),
                        .Text = reader.GetString("text"),
                        .QuestionType = reader.GetString("question_type"),
                        .DisplayOrder = reader.GetInt32("display_order")
                    }
                    questions.Add(question)
                End While
            End Using
        End Using

        ' Load options for each question
        For Each question In questions
            question.Options = LoadQuestionOptions(conn, question.Code)
        Next

        Return questions
    End Function

    Private Function LoadQuestionOptions(conn As MySqlConnection, questionCode As String) As List(Of Models.QuestionOption)
        Dim options As New List(Of Models.QuestionOption)()

        Dim sql = "SELECT option_text, option_value, display_order FROM question_options " &
                  "WHERE question_code = @code ORDER BY display_order"

        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@code", questionCode)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    options.Add(New Models.QuestionOption() With {
                        .Text = reader.GetString("option_text"),
                        .Value = reader.GetInt32("option_value"),
                        .DisplayOrder = reader.GetInt32("display_order")
                    })
                End While
            End Using
        End Using

        Return options
    End Function

    Private Sub ShowPage(pageNumber As Integer)
        panelQuestions.Controls.Clear()

        Select Case pageNumber
            Case 1
                lblPageTitle.Text = "Kategori A: Data Diri"
                lblPageDescription.Text = "Silakan isi data diri Anda dengan lengkap"
                RenderQuestions(_questionsKategoriA, _personalData)
            Case 2
                lblPageTitle.Text = "Kategori B: Data Akademis"
                lblPageDescription.Text = "Informasi tentang prestasi akademik dan kemampuan teknis Anda"
                RenderQuestions(_questionsKategoriB, _akademisData)
            Case 3
                lblPageTitle.Text = "Kategori C: Karakter & Minat"
                lblPageDescription.Text = "Penilaian karakter pribadi dan minat karir Anda (Skala 1-5)"
                RenderQuestions(_questionsKategoriC, _karakterData)
        End Select

        ' Update navigation buttons
        btnPrevious.Enabled = (pageNumber > 1)
        btnNext.Text = If(pageNumber = _totalPages, "Selesai", "Lanjut")

        ' Update progress
        lblProgress.Text = $"Halaman {pageNumber} dari {_totalPages}"
        progressBar.Value = CInt((pageNumber / _totalPages) * 100)
    End Sub

    Private Sub RenderQuestions(questions As List(Of Question), dataStore As Dictionary(Of String, Double))
        Dim yPosition As Integer = 10

        For Each question In questions
            ' Question label
            Dim lblQuestion As New Label() With {
                .Text = question.Text,
                .Font = New Font("Segoe UI", 10, FontStyle.Regular),
                .AutoSize = True,
                .MaximumSize = New Size(panelQuestions.Width - 40, 0),
                .Location = New Point(20, yPosition)
            }
            panelQuestions.Controls.Add(lblQuestion)
            yPosition += lblQuestion.Height + 10

            ' Render input based on question type
            Select Case question.QuestionType
                Case "choice"
                    Dim comboBox As New ComboBox() With {
                        .Name = "input_" & question.Code,
                        .Font = New Font("Segoe UI", 9),
                        .Width = 300,
                        .Location = New Point(20, yPosition),
                        .DropDownStyle = ComboBoxStyle.DropDownList
                    }

                    For Each opt In question.Options
                        comboBox.Items.Add(New QuestionOptionItem() With {
                            .Text = opt.Text,
                            .Value = opt.Value
                        })
                    Next

                    If dataStore.ContainsKey(question.Code) Then
                        For i = 0 To comboBox.Items.Count - 1
                            Dim item = CType(comboBox.Items(i), QuestionOptionItem)
                            If item.Value = dataStore(question.Code) Then
                                comboBox.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If

                    panelQuestions.Controls.Add(comboBox)
                    yPosition += 40

                Case "numeric"
                    Dim numericBox As New NumericUpDown() With {
                        .Name = "input_" & question.Code,
                        .Font = New Font("Segoe UI", 9),
                        .Width = 150,
                        .Location = New Point(20, yPosition),
                        .DecimalPlaces = 2,
                        .Minimum = 0,
                        .Maximum = 10
                    }

                    If dataStore.ContainsKey(question.Code) Then
                        numericBox.Value = CDec(dataStore(question.Code))
                    End If

                    panelQuestions.Controls.Add(numericBox)
                    yPosition += 40

                Case "scale"
                    ' Create radio button group for Likert scale 1-5
                    Dim flowPanel As New FlowLayoutPanel() With {
                        .Name = "input_" & question.Code,
                        .FlowDirection = FlowDirection.LeftToRight,
                        .AutoSize = True,
                        .Location = New Point(20, yPosition)
                    }

                    For i = 1 To 5
                        Dim radioButton As New RadioButton() With {
                            .Text = i.ToString(),
                            .Tag = i,
                            .Font = New Font("Segoe UI", 9),
                            .AutoSize = True,
                            .Margin = New Padding(0, 0, 15, 0)
                        }

                        If dataStore.ContainsKey(question.Code) AndAlso dataStore(question.Code) = i Then
                            radioButton.Checked = True
                        End If

                        flowPanel.Controls.Add(radioButton)
                    Next

                    ' Add labels
                    Dim lblLow As New Label() With {
                        .Text = "(1: Sangat Tidak Setuju)",
                        .Font = New Font("Segoe UI", 8, FontStyle.Italic),
                        .ForeColor = Color.Gray,
                        .AutoSize = True,
                        .Location = New Point(20, yPosition + 30)
                    }
                    Dim lblHigh As New Label() With {
                        .Text = "(5: Sangat Setuju)",
                        .Font = New Font("Segoe UI", 8, FontStyle.Italic),
                        .ForeColor = Color.Gray,
                        .AutoSize = True,
                        .Location = New Point(250, yPosition + 30)
                    }

                    panelQuestions.Controls.Add(flowPanel)
                    panelQuestions.Controls.Add(lblLow)
                    panelQuestions.Controls.Add(lblHigh)
                    yPosition += 70
            End Select

            yPosition += 20 ' Spacing between questions
        Next
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Save current page data
        If Not SaveCurrentPageData() Then
            MessageBox.Show("Mohon lengkapi semua pertanyaan sebelum melanjutkan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If _currentPage < _totalPages Then
            _currentPage += 1
            ShowPage(_currentPage)
        Else
            ' Process inference
            ProcessInference()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If _currentPage > 1 Then
            SaveCurrentPageData() ' Save without validation
            _currentPage -= 1
            ShowPage(_currentPage)
        End If
    End Sub

    Private Function SaveCurrentPageData() As Boolean
        Dim dataStore As Dictionary(Of String, Double) = Nothing
        Dim questions As List(Of Question) = Nothing

        Select Case _currentPage
            Case 1
                dataStore = _personalData
                questions = _questionsKategoriA
            Case 2
                dataStore = _akademisData
                questions = _questionsKategoriB
            Case 3
                dataStore = _karakterData
                questions = _questionsKategoriC
        End Select

        For Each question In questions
            Dim control = panelQuestions.Controls($"input_{question.Code}")

            If control Is Nothing Then
                Return False
            End If

            Select Case question.QuestionType
                Case "choice"
                    Dim combo = CType(control, ComboBox)
                    If combo.SelectedItem Is Nothing Then
                        Return False
                    End If
                    Dim selectedItem = CType(combo.SelectedItem, QuestionOptionItem)
                    dataStore(question.Code) = selectedItem.Value

                Case "numeric"
                    Dim numeric = CType(control, NumericUpDown)
                    dataStore(question.Code) = CDbl(numeric.Value)

                Case "scale"
                    Dim flowPanel = CType(control, FlowLayoutPanel)
                    Dim selectedValue As Integer = 0
                    For Each ctrl In flowPanel.Controls
                        If TypeOf ctrl Is RadioButton Then
                            Dim radio = CType(ctrl, RadioButton)
                            If radio.Checked Then
                                selectedValue = CInt(radio.Tag)
                                Exit For
                            End If
                        End If
                    Next

                    If selectedValue = 0 Then
                        Return False
                    End If

                    dataStore(question.Code) = selectedValue
            End Select
        Next

        Return True
    End Function

    Private Sub ProcessInference()
        Try
            Me.Cursor = Cursors.WaitCursor

            ' Run inference engine
            Dim inferenceService As New InferenceService()
            Dim results = inferenceService.RunInference(_personalData, _akademisData, _karakterData)

            If results Is Nothing OrElse results.Count = 0 Then
                MessageBox.Show("Tidak dapat menentukan profil lulusan berdasarkan data yang diberikan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Save to database
            Dim allResponses As New Dictionary(Of String, Double)()
            For Each kvp In _personalData
                allResponses(kvp.Key) = kvp.Value
            Next
            For Each kvp In _akademisData
                allResponses(kvp.Key) = kvp.Value
            Next
            For Each kvp In _karakterData
                allResponses(kvp.Key) = kvp.Value
            Next

            inferenceService.SaveAssessmentResults(_userId, allResponses, results)

            ' Show results
            Dim resultForm As New FormResult(results, _userId)
            resultForm.ShowDialog()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show($"Error processing inference: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' Helper class for ComboBox items
    Private Class QuestionOptionItem
        Public Property Text As String
        Public Property Value As Integer

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class
End Class
