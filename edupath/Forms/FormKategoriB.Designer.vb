<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormKategoriB
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        panelAccent = New Panel()
        lblTitle = New Label()
        lblProgress = New Label()
        progressBar = New ProgressBar()
        lblQuestion = New Label()
        panelAnswer = New Panel()
        lblInstruction = New Label()
        cboAnswer = New ComboBox()
        btnPrevious = New Button()
        btnNext = New Button()
        btnBack = New Button()
        panelAnswer.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelAccent
        ' 
        panelAccent.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        panelAccent.Dock = DockStyle.Left
        panelAccent.Location = New Point(0, 0)
        panelAccent.Name = "panelAccent"
        panelAccent.Size = New Size(5, 550)
        panelAccent.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblTitle.Location = New Point(30, 25)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(320, 30)
        lblTitle.TabIndex = 1
        lblTitle.Text = "🎓 KATEGORI B — AKADEMIS"
        ' 
        ' lblProgress
        ' 
        lblProgress.AutoSize = True
        lblProgress.Font = New Font("Segoe UI", 10.0F)
        lblProgress.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblProgress.Location = New Point(30, 65)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(120, 19)
        lblProgress.TabIndex = 2
        lblProgress.Text = "Pertanyaan 1 / 10"
        ' 
        ' progressBar
        ' 
        progressBar.Location = New Point(30, 95)
        progressBar.Name = "progressBar"
        progressBar.Size = New Size(640, 8)
        progressBar.TabIndex = 3
        progressBar.Style = ProgressBarStyle.Continuous
        progressBar.ForeColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        ' 
        ' lblQuestion
        ' 
        lblQuestion.Font = New Font("Segoe UI Semibold", 14.0F, FontStyle.Bold)
        lblQuestion.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblQuestion.Location = New Point(30, 125)
        lblQuestion.Name = "lblQuestion"
        lblQuestion.Size = New Size(640, 80)
        lblQuestion.TabIndex = 4
        lblQuestion.Text = "Pertanyaan akan ditampilkan di sini"
        ' 
        ' panelAnswer
        ' 
        panelAnswer.BackColor = Color.White
        panelAnswer.BorderStyle = BorderStyle.FixedSingle
        panelAnswer.Controls.Add(lblInstruction)
        panelAnswer.Controls.Add(cboAnswer)
        panelAnswer.Location = New Point(30, 225)
        panelAnswer.Name = "panelAnswer"
        panelAnswer.Padding = New Padding(20)
        panelAnswer.Size = New Size(640, 150)
        panelAnswer.TabIndex = 5
        ' 
        ' lblInstruction
        ' 
        lblInstruction.AutoSize = True
        lblInstruction.Font = New Font("Segoe UI", 10.0F)
        lblInstruction.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblInstruction.Location = New Point(20, 20)
        lblInstruction.Name = "lblInstruction"
        lblInstruction.Size = New Size(160, 19)
        lblInstruction.TabIndex = 0
        lblInstruction.Text = "💡 Pilih jawaban Anda:"
        ' 
        ' cboAnswer
        ' 
        cboAnswer.DropDownStyle = ComboBoxStyle.DropDownList
        cboAnswer.Font = New Font("Segoe UI", 12.0F)
        cboAnswer.FormattingEnabled = True
        cboAnswer.Location = New Point(20, 55)
        cboAnswer.Name = "cboAnswer"
        cboAnswer.Size = New Size(580, 29)
        cboAnswer.TabIndex = 1
        ' 
        ' btnPrevious
        ' 
        btnPrevious.BackColor = Color.White
        btnPrevious.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        btnPrevious.FlatStyle = FlatStyle.Flat
        btnPrevious.Font = New Font("Segoe UI", 11.0F)
        btnPrevious.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        btnPrevious.Location = New Point(30, 465)
        btnPrevious.Name = "btnPrevious"
        btnPrevious.Size = New Size(150, 45)
        btnPrevious.TabIndex = 6
        btnPrevious.Text = "< Sebelumnya"
        btnPrevious.UseVisualStyleBackColor = False
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnNext.FlatAppearance.BorderSize = 0
        btnNext.FlatStyle = FlatStyle.Flat
        btnNext.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(520, 465)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(150, 45)
        btnNext.TabIndex = 7
        btnNext.Text = "Selanjutnya >"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.White
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 10.0F)
        btnBack.ForeColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        btnBack.Location = New Point(260, 465)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(180, 45)
        btnBack.TabIndex = 8
        btnBack.Text = "↩ Kembali ke Kategori A"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' FormKategoriB
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(247))
        ClientSize = New Size(700, 550)
        Controls.Add(btnBack)
        Controls.Add(btnNext)
        Controls.Add(btnPrevious)
        Controls.Add(panelAnswer)
        Controls.Add(lblQuestion)
        Controls.Add(progressBar)
        Controls.Add(lblProgress)
        Controls.Add(lblTitle)
        Controls.Add(panelAccent)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FormKategoriB"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Kategori B"
        panelAnswer.ResumeLayout(False)
        panelAnswer.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents panelAccent As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblProgress As Label
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents lblQuestion As Label
    Friend WithEvents panelAnswer As Panel
    Friend WithEvents lblInstruction As Label
    Friend WithEvents cboAnswer As ComboBox
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnCancel As Button
End Class
