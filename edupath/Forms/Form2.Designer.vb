<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        lblProgress = New Label()
        lblQuestion = New Label()
        panelAnswer = New Panel()
        lblInstruction = New Label()
        cboAnswer = New ComboBox()
        btnPrevious = New Button()
        btnNext = New Button()
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
        lblProgress.Location = New Point(40, 40)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(114, 20)
        lblProgress.TabIndex = 1
        lblProgress.Text = "Pertanyaan 1 / ?"
        ' 
        ' lblQuestion
        ' 
        lblQuestion.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblQuestion.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblQuestion.Location = New Point(40, 80)
        lblQuestion.Name = "lblQuestion"
        lblQuestion.Size = New Size(620, 120)
        lblQuestion.TabIndex = 2
        lblQuestion.Text = "[Pertanyaan]"
        ' 
        ' panelAnswer
        ' 
        panelAnswer.BackColor = Color.White
        panelAnswer.BorderStyle = BorderStyle.FixedSingle
        panelAnswer.Controls.Add(lblInstruction)
        panelAnswer.Controls.Add(cboAnswer)
        panelAnswer.Location = New Point(40, 230)
        panelAnswer.Name = "panelAnswer"
        panelAnswer.Size = New Size(620, 130)
        panelAnswer.TabIndex = 3
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
        btnPrevious.Location = New Point(40, 400)
        btnPrevious.Name = "btnPrevious"
        btnPrevious.Size = New Size(150, 45)
        btnPrevious.TabIndex = 4
        btnPrevious.Text = "← Sebelumnya"
        btnPrevious.UseVisualStyleBackColor = False
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnNext.FlatAppearance.BorderSize = 0
        btnNext.FlatStyle = FlatStyle.Flat
        btnNext.Font = New Font("Segoe UI", 11F)
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(510, 400)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(150, 45)
        btnNext.TabIndex = 5
        btnNext.Text = "Selanjutnya →"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(247))
        ClientSize = New Size(700, 500)
        Controls.Add(btnNext)
        Controls.Add(btnPrevious)
        Controls.Add(panelAnswer)
        Controls.Add(lblQuestion)
        Controls.Add(lblProgress)
        Controls.Add(panelAccent)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Survey"
        panelAnswer.ResumeLayout(False)
        panelAnswer.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents panelAccent As Panel
    Friend WithEvents lblProgress As Label
    Friend WithEvents lblQuestion As Label
    Friend WithEvents panelAnswer As Panel
    Friend WithEvents lblInstruction As Label
    Friend WithEvents cboAnswer As ComboBox
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
End Class
