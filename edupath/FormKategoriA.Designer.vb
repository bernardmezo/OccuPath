<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormKategoriA
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        lblProgress = New Label()
        lblTitle = New Label()
        lblQuestion = New Label()
        panelAnswer = New Panel()
        lblInstruction = New Label()
        cboAnswer = New ComboBox()
        btnPrevious = New Button()
        btnNext = New Button()
        btnCancel = New Button()
        panelAnswer.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelAccent
        ' 
        panelAccent.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        panelAccent.Location = New Point(0, 0)
        panelAccent.Name = "panelAccent"
        panelAccent.Size = New Size(5, 600)
        panelAccent.TabIndex = 0
        ' 
        ' lblProgress
        ' 
        lblProgress.AutoSize = True
        lblProgress.Font = New Font("Segoe UI", 11F)
        lblProgress.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblProgress.Location = New Point(40, 30)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(123, 20)
        lblProgress.TabIndex = 1
        lblProgress.Text = "Pertanyaan 1 / 10"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblTitle.Location = New Point(40, 60)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(242, 25)
        lblTitle.TabIndex = 2
        lblTitle.Text = "KATEGORI A — DATA DIRI"
        ' 
        ' lblQuestion
        ' 
        lblQuestion.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblQuestion.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblQuestion.Location = New Point(40, 110)
        lblQuestion.Name = "lblQuestion"
        lblQuestion.Size = New Size(620, 120)
        lblQuestion.TabIndex = 3
        lblQuestion.Text = "[Pertanyaan]"
        ' 
        ' panelAnswer
        ' 
        panelAnswer.BackColor = Color.White
        panelAnswer.BorderStyle = BorderStyle.FixedSingle
        panelAnswer.Controls.Add(lblInstruction)
        panelAnswer.Controls.Add(cboAnswer)
        panelAnswer.Location = New Point(40, 260)
        panelAnswer.Name = "panelAnswer"
        panelAnswer.Size = New Size(620, 130)
        panelAnswer.TabIndex = 4
        ' 
        ' lblInstruction
        ' 
        lblInstruction.AutoSize = True
        lblInstruction.Font = New Font("Segoe UI", 10F)
        lblInstruction.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblInstruction.Location = New Point(25, 25)
        lblInstruction.Name = "lblInstruction"
        lblInstruction.Size = New Size(127, 19)
        lblInstruction.TabIndex = 0
        lblInstruction.Text = "Pilih jawaban Anda:"
        ' 
        ' cboAnswer
        ' 
        cboAnswer.DropDownStyle = ComboBoxStyle.DropDownList
        cboAnswer.Font = New Font("Segoe UI", 11F)
        cboAnswer.FormattingEnabled = True
        cboAnswer.Location = New Point(25, 55)
        cboAnswer.Name = "cboAnswer"
        cboAnswer.Size = New Size(565, 28)
        cboAnswer.TabIndex = 1
        ' 
        ' btnPrevious
        ' 
        btnPrevious.BackColor = Color.White
        btnPrevious.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        btnPrevious.FlatStyle = FlatStyle.Flat
        btnPrevious.Font = New Font("Segoe UI", 11F)
        btnPrevious.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        btnPrevious.Location = New Point(40, 430)
        btnPrevious.Name = "btnPrevious"
        btnPrevious.Size = New Size(150, 45)
        btnPrevious.TabIndex = 5
        btnPrevious.Text = "? Sebelumnya"
        btnPrevious.UseVisualStyleBackColor = False
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnNext.FlatAppearance.BorderSize = 0
        btnNext.FlatStyle = FlatStyle.Flat
        btnNext.Font = New Font("Segoe UI", 11F)
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(510, 430)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(150, 45)
        btnNext.TabIndex = 6
        btnNext.Text = "Selanjutnya ?"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.White
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 10F)
        btnCancel.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        btnCancel.Location = New Point(275, 430)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(150, 45)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Batal"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' FormKategoriA
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(247))
        ClientSize = New Size(700, 520)
        Controls.Add(btnCancel)
        Controls.Add(btnNext)
        Controls.Add(btnPrevious)
        Controls.Add(panelAnswer)
        Controls.Add(lblQuestion)
        Controls.Add(lblTitle)
        Controls.Add(lblProgress)
        Controls.Add(panelAccent)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FormKategoriA"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Data Diri"
        panelAnswer.ResumeLayout(False)
        panelAnswer.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents panelAccent As Panel
    Friend WithEvents lblProgress As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblQuestion As Label
    Friend WithEvents panelAnswer As Panel
    Friend WithEvents lblInstruction As Label
    Friend WithEvents cboAnswer As ComboBox
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnCancel As Button
End Class
