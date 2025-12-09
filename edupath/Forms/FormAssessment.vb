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
            ' Add button hover effects
            AddHandler btnNext.MouseEnter, Sub(s, ev)
                                               btnNext.BackColor = Color.FromArgb(52, 152, 219)
                                           End Sub
            AddHandler btnNext.MouseLeave, Sub(s, ev)
                                               btnNext.BackColor = Color.FromArgb(41, 128, 185)
                                           End Sub

            AddHandler btnPrevious.MouseEnter, Sub(s, ev)
                                                   If btnPrevious.Enabled Then
                                                       btnPrevious.BackColor = Color.FromArgb(236, 240, 241)
                                                   End If
                                               End Sub
            AddHandler btnPrevious.MouseLeave, Sub(s, ev)
                                                   btnPrevious.BackColor = Color.White
                                               End Sub

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

        ' Update page title and description with icons
        Select Case pageNumber
            Case 1
                lblPageTitle.Text = "?? Kategori A: Data Diri"
                lblPageDescription.Text = "Silakan isi data diri Anda dengan lengkap dan akurat"
                RenderQuestions(_questionsKategoriA, _personalData)
            Case 2
                lblPageTitle.Text = "?? Kategori B: Data Akademis"
                lblPageDescription.Text = "Informasi tentang prestasi akademik dan kemampuan teknis Anda"
                RenderQuestions(_questionsKategoriB, _akademisData)
            Case 3
                lblPageTitle.Text = "?? Kategori C: Karakter & Minat"
                lblPageDescription.Text = "Penilaian karakter pribadi dan minat karir Anda (Skala 1-5)"
                RenderQuestions(_questionsKategoriC, _karakterData)
        End Select

        ' Update navigation buttons with hover effects
        btnPrevious.Enabled = (pageNumber > 1)
        If pageNumber = _totalPages Then
            btnNext.Text = "Selesai & Lihat Hasil >"
        Else
            btnNext.Text = "Lanjut >"
        End If

        ' Update progress bar and labels
        Dim progressPercent = CInt((pageNumber / _totalPages) * 100)
        progressBar.Value = progressPercent
        lblProgress.Text = $"Halaman {pageNumber} dari {_totalPages}"
        lblProgressPercent.Text = $"{progressPercent}%"
    End Sub

    Private Sub RenderQuestions(questions As List(Of Question), dataStore As Dictionary(Of String, Double))
        Dim yPosition As Integer = 0

        For questionIndex As Integer = 0 To questions.Count - 1
            Dim question = questions(questionIndex)

            ' Create question card
            Dim cardPanel As New Panel() With {
                .BackColor = Color.White,
                .BorderStyle = BorderStyle.FixedSingle,
                .Location = New Point(0, yPosition),
                .Width = panelQuestions.Width - 60,
                .Padding = New Padding(25, 20, 25, 20),
                .Margin = New Padding(0, 0, 0, 15)
            }

            ' Question number badge
            Dim lblNumber As New Label() With {
                .Text = $"{questionIndex + 1}",
                .Font = New Font("Segoe UI", 11, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.FromArgb(41, 128, 185),
                .Size = New Size(35, 35),
                .Location = New Point(25, 20),
                .TextAlign = ContentAlignment.MiddleCenter
            }
            cardPanel.Controls.Add(lblNumber)

            ' Question text
            Dim lblQuestion As New Label() With {
                .Text = question.Text,
                .Font = New Font("Segoe UI", 11, FontStyle.Regular),
                .ForeColor = Color.FromArgb(52, 73, 94),
                .AutoSize = False,
                .Size = New Size(cardPanel.Width - 100, 60),
                .Location = New Point(75, 20)
            }
            cardPanel.Controls.Add(lblQuestion)

            Dim inputYPosition = 90

            ' Render input based on question type
            Select Case question.QuestionType
                Case "choice"
                    Dim comboBox As New ComboBox() With {
                        .Name = "input_" & question.Code,
                        .Font = New Font("Segoe UI", 10),
                        .Width = cardPanel.Width - 120,
                        .Location = New Point(75, inputYPosition),
                        .DropDownStyle = ComboBoxStyle.DropDownList,
                        .FlatStyle = FlatStyle.Flat
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

                    cardPanel.Controls.Add(comboBox)
                    cardPanel.Height = 160

                Case "numeric"
                    Dim numericBox As New NumericUpDown() With {
                        .Name = "input_" & question.Code,
                        .Font = New Font("Segoe UI", 11),
                        .Width = 200,
                        .Height = 30,
                        .Location = New Point(75, inputYPosition),
                        .DecimalPlaces = 2,
                        .BorderStyle = BorderStyle.FixedSingle
                    }

                    ' Set different ranges based on question type
                    ' Assume IPK-related questions have "IPK" in their code or text
                    ' Semester questions have "semester" in their code or text
                    Dim isIPKQuestion As Boolean = question.Code.ToUpper().Contains("IPK") OrElse question.Text.ToUpper().Contains("IPK")
                    Dim isSemesterQuestion As Boolean = question.Code.ToUpper().Contains("SEMESTER") OrElse question.Text.ToUpper().Contains("SEMESTER")

                    Dim rangeText As String = ""
                    If isIPKQuestion Then
                        ' IPK range: 0.00 - 4.00
                        numericBox.Minimum = 0
                        numericBox.Maximum = 4
                        rangeText = "(0.00 - 4.00)"
                    ElseIf isSemesterQuestion Then
                        ' Semester range: 1 - 14 (or higher for some programs)
                        numericBox.Minimum = 1
                        numericBox.Maximum = 14
                        numericBox.DecimalPlaces = 0
                        rangeText = "(1 - 14)"
                    Else
                        ' Default numeric range
                        numericBox.Minimum = 0
                        numericBox.Maximum = 100
                        rangeText = "(0 - 100)"
                    End If

                    If dataStore.ContainsKey(question.Code) Then
                        numericBox.Value = CDec(dataStore(question.Code))
                    End If

                    Dim lblUnit As New Label() With {
                        .Text = rangeText,
                        .Font = New Font("Segoe UI", 9, FontStyle.Italic),
                        .ForeColor = Color.FromArgb(127, 140, 141),
                        .AutoSize = True,
                        .Location = New Point(290, inputYPosition + 5)
                    }

                    cardPanel.Controls.Add(numericBox)
                    cardPanel.Controls.Add(lblUnit)
                    cardPanel.Height = 150

                Case "scale"
                    ' Create modern radio button group with visual scale
                    Dim scalePanel As New FlowLayoutPanel() With {
                        .Name = "input_" & question.Code,
                        .FlowDirection = FlowDirection.LeftToRight,
                        .AutoSize = False,
                        .Size = New Size(cardPanel.Width - 100, 70),
                        .Location = New Point(75, inputYPosition),
                        .WrapContents = False
                    }

                    ' Scale labels
                    Dim scaleLabels = {"Sangat Tidak Setuju", "Tidak Setuju", "Netral", "Setuju", "Sangat Setuju"}
                    Dim scaleColors = {
                        Color.FromArgb(231, 76, 60),   ' Red
                        Color.FromArgb(230, 126, 34),  ' Orange
                        Color.FromArgb(241, 196, 15),  ' Yellow
                        Color.FromArgb(46, 204, 113),  ' Green
                        Color.FromArgb(52, 152, 219)   ' Blue
                    }

                    For i = 0 To 4
                        ' Create local copy for lambda closure
                        Dim localIndex As Integer = i
                        Dim localColor As Color = scaleColors(i)

                        Dim optionPanel As New Panel() With {
                            .Size = New Size(120, 70),
                            .Margin = New Padding(0, 0, 10, 0)
                        }

                        Dim radioButton As New RadioButton() With {
                            .Text = (i + 1).ToString(),
                            .Tag = i + 1,
                            .Font = New Font("Segoe UI", 14, FontStyle.Bold),
                            .ForeColor = localColor,
                            .Size = New Size(50, 30),
                            .Location = New Point(35, 0),
                            .Appearance = Appearance.Button,
                            .FlatStyle = FlatStyle.Flat,
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .BackColor = Color.FromArgb(236, 240, 241)
                        }

                        radioButton.FlatAppearance.BorderColor = localColor
                        radioButton.FlatAppearance.BorderSize = 2
                        radioButton.FlatAppearance.CheckedBackColor = localColor

                        ' Add checked changed handler for color (using local copy)
                        AddHandler radioButton.CheckedChanged, Sub(s, ev)
                                                                   If radioButton.Checked Then
                                                                       radioButton.ForeColor = Color.White
                                                                   Else
                                                                       radioButton.ForeColor = localColor
                                                                   End If
                                                               End Sub

                        If dataStore.ContainsKey(question.Code) AndAlso dataStore(question.Code) = i + 1 Then
                            radioButton.Checked = True
                        End If

                        Dim lblScale As New Label() With {
                            .Text = scaleLabels(i),
                            .Font = New Font("Segoe UI", 8, FontStyle.Regular),
                            .ForeColor = Color.FromArgb(127, 140, 141),
                            .AutoSize = False,
                            .Size = New Size(120, 35),
                            .Location = New Point(0, 35),
                            .TextAlign = ContentAlignment.TopCenter
                        }

                        optionPanel.Controls.Add(radioButton)
                        optionPanel.Controls.Add(lblScale)
                        scalePanel.Controls.Add(optionPanel)
                    Next

                    cardPanel.Controls.Add(scalePanel)
                    cardPanel.Height = 200
            End Select

            panelQuestions.Controls.Add(cardPanel)
            yPosition += cardPanel.Height + 15
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
            ' Find the control - it's nested inside a card panel
            Dim control As Control = FindControlByName(panelQuestions, "input_" & question.Code)

            If control Is Nothing Then
                MessageBox.Show($"Control tidak ditemukan untuk pertanyaan: {question.Text}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Select Case question.QuestionType
                Case "choice"
                    Dim combo = TryCast(control, ComboBox)
                    If combo Is Nothing OrElse combo.SelectedItem Is Nothing Then
                        Return False
                    End If
                    Dim selectedItem = CType(combo.SelectedItem, QuestionOptionItem)
                    dataStore(question.Code) = selectedItem.Value

                Case "numeric"
                    Dim numeric = TryCast(control, NumericUpDown)
                    If numeric Is Nothing Then
                        Return False
                    End If
                    dataStore(question.Code) = CDbl(numeric.Value)

                Case "scale"
                    Dim flowPanel = TryCast(control, FlowLayoutPanel)
                    If flowPanel Is Nothing Then
                        Return False
                    End If

                    Dim selectedValue As Integer = 0
                    For Each optionPanel As Control In flowPanel.Controls
                        If TypeOf optionPanel Is Panel Then
                            For Each ctrl As Control In optionPanel.Controls
                                If TypeOf ctrl Is RadioButton Then
                                    Dim radio = CType(ctrl, RadioButton)
                                    If radio.Checked Then
                                        selectedValue = CInt(radio.Tag)
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                        If selectedValue > 0 Then Exit For
                    Next

                    If selectedValue = 0 Then
                        Return False
                    End If

                    dataStore(question.Code) = selectedValue
            End Select
        Next

        Return True
    End Function

    ''' <summary>
    ''' Helper function to recursively find a control by name
    ''' </summary>
    Private Function FindControlByName(parent As Control, name As String) As Control
        ' Check direct children first
        For Each ctrl As Control In parent.Controls
            If ctrl.Name = name Then
                Return ctrl
            End If
        Next

        ' Recursively search in nested controls
        For Each ctrl As Control In parent.Controls
            Dim found = FindControlByName(ctrl, name)
            If found IsNot Nothing Then
                Return found
            End If
        Next

        Return Nothing
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
