<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
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
        panelOptions = New Panel()
        rbOption1 = New RadioButton()
        rbOption2 = New RadioButton()
        rbOption3 = New RadioButton()
        rbOption4 = New RadioButton()
        rbOption5 = New RadioButton()
        btnPrevious = New Button()
        btnNext = New Button()
        panelOptions.SuspendLayout()
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
        lblProgress.Font = New Font("Segoe UI", 11.0F)
        lblProgress.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblProgress.Location = New Point(40, 40)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(114, 20)
        lblProgress.TabIndex = 1
        lblProgress.Text = "Pertanyaan 1 / ?"
        ' 
        ' lblQuestion
        ' 
        lblQuestion.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblQuestion.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblQuestion.Location = New Point(40, 80)
        lblQuestion.Name = "lblQuestion"
        lblQuestion.Size = New Size(620, 100)
        lblQuestion.TabIndex = 2
        lblQuestion.Text = "[Pertanyaan]"
        ' 
        ' panelOptions
        ' 
        panelOptions.BackColor = Color.White
        panelOptions.BorderStyle = BorderStyle.FixedSingle
        panelOptions.Controls.Add(rbOption1)
        panelOptions.Controls.Add(rbOption2)
        panelOptions.Controls.Add(rbOption3)
        panelOptions.Controls.Add(rbOption4)
        panelOptions.Controls.Add(rbOption5)
        panelOptions.Location = New Point(40, 200)
        panelOptions.Name = "panelOptions"
        panelOptions.Size = New Size(620, 240)
        panelOptions.TabIndex = 3
        ' 
        ' rbOption1
        ' 
        rbOption1.Font = New Font("Segoe UI", 11.0F)
        rbOption1.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        rbOption1.Location = New Point(25, 20)
        rbOption1.Name = "rbOption1"
        rbOption1.Size = New Size(570, 35)
        rbOption1.TabIndex = 0
        rbOption1.Text = "Opsi 1"
        rbOption1.UseVisualStyleBackColor = True
        ' 
        ' rbOption2
        ' 
        rbOption2.Font = New Font("Segoe UI", 11.0F)
        rbOption2.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        rbOption2.Location = New Point(25, 60)
        rbOption2.Name = "rbOption2"
        rbOption2.Size = New Size(570, 35)
        rbOption2.TabIndex = 1
        rbOption2.Text = "Opsi 2"
        rbOption2.UseVisualStyleBackColor = True
        ' 
        ' rbOption3
        ' 
        rbOption3.Font = New Font("Segoe UI", 11.0F)
        rbOption3.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        rbOption3.Location = New Point(25, 100)
        rbOption3.Name = "rbOption3"
        rbOption3.Size = New Size(570, 35)
        rbOption3.TabIndex = 2
        rbOption3.Text = "Opsi 3"
        rbOption3.UseVisualStyleBackColor = True
        ' 
        ' rbOption4
        ' 
        rbOption4.Font = New Font("Segoe UI", 11.0F)
        rbOption4.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        rbOption4.Location = New Point(25, 140)
        rbOption4.Name = "rbOption4"
        rbOption4.Size = New Size(570, 35)
        rbOption4.TabIndex = 3
        rbOption4.Text = "Opsi 4"
        rbOption4.UseVisualStyleBackColor = True
        ' 
        ' rbOption5
        ' 
        rbOption5.Font = New Font("Segoe UI", 11.0F)
        rbOption5.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        rbOption5.Location = New Point(25, 180)
        rbOption5.Name = "rbOption5"
        rbOption5.Size = New Size(570, 35)
        rbOption5.TabIndex = 4
        rbOption5.Text = "Opsi 5"
        rbOption5.UseVisualStyleBackColor = True
        ' 
        ' btnPrevious
        ' 
        btnPrevious.BackColor = Color.White
        btnPrevious.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        btnPrevious.FlatStyle = FlatStyle.Flat
        btnPrevious.Font = New Font("Segoe UI", 11.0F)
        btnPrevious.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        btnPrevious.Location = New Point(40, 460)
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
        btnNext.Font = New Font("Segoe UI", 11.0F)
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(510, 460)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(150, 45)
        btnNext.TabIndex = 5
        btnNext.Text = "Selanjutnya →"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(247))
        ClientSize = New Size(700, 550)
        Controls.Add(btnNext)
        Controls.Add(btnPrevious)
        Controls.Add(panelOptions)
        Controls.Add(lblQuestion)
        Controls.Add(lblProgress)
        Controls.Add(panelAccent)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form3"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Survey"
        panelOptions.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents panelAccent As Panel
    Friend WithEvents lblProgress As Label
    Friend WithEvents lblQuestion As Label
    Friend WithEvents panelOptions As Panel
    Friend WithEvents rbOption1 As RadioButton
    Friend WithEvents rbOption2 As RadioButton
    Friend WithEvents rbOption3 As RadioButton
    Friend WithEvents rbOption4 As RadioButton
    Friend WithEvents rbOption5 As RadioButton
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
End Class
