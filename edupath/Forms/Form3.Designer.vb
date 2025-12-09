<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        panelAccent = New Panel()
        lblProgress = New Label()
        lblQuestion = New Label()
        panelOptions = New Panel()
        lblOption1 = New Label()
        lblOption2 = New Label()
        lblOption3 = New Label()
        lblOption4 = New Label()
        lblOption5 = New Label()
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
        panelAccent.Dock = DockStyle.Left
        panelAccent.Location = New Point(0, 0)
        panelAccent.Name = "panelAccent"
        panelAccent.Size = New Size(5, 550)
        panelAccent.TabIndex = 0
        ' 
        ' lblProgress
        ' 
        lblProgress.AutoSize = True
        lblProgress.Font = New Font("Segoe UI", 10.0F)
        lblProgress.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblProgress.Location = New Point(25, 25)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(150, 19)
        lblProgress.TabIndex = 1
        lblProgress.Text = "Pertanyaan 1 / 20"
        ' 
        ' lblQuestion
        ' 
        lblQuestion.Font = New Font("Segoe UI Semibold", 14.0F, FontStyle.Bold)
        lblQuestion.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblQuestion.Location = New Point(25, 60)
        lblQuestion.Name = "lblQuestion"
        lblQuestion.Size = New Size(650, 100)
        lblQuestion.TabIndex = 2
        lblQuestion.Text = "Pertanyaan akan ditampilkan di sini"
        ' 
        ' panelOptions
        ' 
        panelOptions.BackColor = Color.White
        panelOptions.BorderStyle = BorderStyle.FixedSingle
        panelOptions.Controls.Add(lblOption1)
        panelOptions.Controls.Add(lblOption2)
        panelOptions.Controls.Add(lblOption3)
        panelOptions.Controls.Add(lblOption4)
        panelOptions.Controls.Add(lblOption5)
        panelOptions.Controls.Add(rbOption1)
        panelOptions.Controls.Add(rbOption2)
        panelOptions.Controls.Add(rbOption3)
        panelOptions.Controls.Add(rbOption4)
        panelOptions.Controls.Add(rbOption5)
        panelOptions.Location = New Point(25, 180)
        panelOptions.Name = "panelOptions"
        panelOptions.Size = New Size(650, 240)
        panelOptions.TabIndex = 3
        ' 
        ' lblOption1
        ' 
        lblOption1.Font = New Font("Segoe UI", 9.5F)
        lblOption1.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblOption1.Location = New Point(15, 130)
        lblOption1.Name = "lblOption1"
        lblOption1.Size = New Size(100, 90)
        lblOption1.TabIndex = 5
        lblOption1.Text = "Sangat Tidak Setuju"
        lblOption1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblOption2
        ' 
        lblOption2.Font = New Font("Segoe UI", 9.5F)
        lblOption2.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblOption2.Location = New Point(145, 130)
        lblOption2.Name = "lblOption2"
        lblOption2.Size = New Size(100, 90)
        lblOption2.TabIndex = 6
        lblOption2.Text = "Tidak Setuju"
        lblOption2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblOption3
        ' 
        lblOption3.Font = New Font("Segoe UI", 9.5F)
        lblOption3.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblOption3.Location = New Point(275, 130)
        lblOption3.Name = "lblOption3"
        lblOption3.Size = New Size(100, 90)
        lblOption3.TabIndex = 7
        lblOption3.Text = "Netral"
        lblOption3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblOption4
        ' 
        lblOption4.Font = New Font("Segoe UI", 9.5F)
        lblOption4.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblOption4.Location = New Point(405, 130)
        lblOption4.Name = "lblOption4"
        lblOption4.Size = New Size(100, 90)
        lblOption4.TabIndex = 8
        lblOption4.Text = "Setuju"
        lblOption4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblOption5
        ' 
        lblOption5.Font = New Font("Segoe UI", 9.5F)
        lblOption5.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblOption5.Location = New Point(535, 130)
        lblOption5.Name = "lblOption5"
        lblOption5.Size = New Size(100, 90)
        lblOption5.TabIndex = 9
        lblOption5.Text = "Sangat Setuju"
        lblOption5.TextAlign = ContentAlignment.TopCenter
        ' 
        ' rbOption1
        ' 
        rbOption1.Appearance = Appearance.Button
        rbOption1.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        rbOption1.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        rbOption1.FlatAppearance.BorderSize = 2
        rbOption1.FlatAppearance.CheckedBackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        rbOption1.FlatStyle = FlatStyle.Flat
        rbOption1.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        rbOption1.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        rbOption1.Location = New Point(35, 40)
        rbOption1.Name = "rbOption1"
        rbOption1.Size = New Size(60, 60)
        rbOption1.TabIndex = 0
        rbOption1.TabStop = True
        rbOption1.Text = "1"
        rbOption1.TextAlign = ContentAlignment.MiddleCenter
        rbOption1.UseVisualStyleBackColor = False
        ' 
        ' rbOption2
        ' 
        rbOption2.Appearance = Appearance.Button
        rbOption2.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        rbOption2.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        rbOption2.FlatAppearance.BorderSize = 2
        rbOption2.FlatAppearance.CheckedBackColor = Color.FromArgb(CByte(230), CByte(126), CByte(34))
        rbOption2.FlatStyle = FlatStyle.Flat
        rbOption2.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        rbOption2.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        rbOption2.Location = New Point(165, 40)
        rbOption2.Name = "rbOption2"
        rbOption2.Size = New Size(60, 60)
        rbOption2.TabIndex = 1
        rbOption2.TabStop = True
        rbOption2.Text = "2"
        rbOption2.TextAlign = ContentAlignment.MiddleCenter
        rbOption2.UseVisualStyleBackColor = False
        ' 
        ' rbOption3
        ' 
        rbOption3.Appearance = Appearance.Button
        rbOption3.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        rbOption3.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        rbOption3.FlatAppearance.BorderSize = 2
        rbOption3.FlatAppearance.CheckedBackColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        rbOption3.FlatStyle = FlatStyle.Flat
        rbOption3.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        rbOption3.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        rbOption3.Location = New Point(295, 40)
        rbOption3.Name = "rbOption3"
        rbOption3.Size = New Size(60, 60)
        rbOption3.TabIndex = 2
        rbOption3.TabStop = True
        rbOption3.Text = "3"
        rbOption3.TextAlign = ContentAlignment.MiddleCenter
        rbOption3.UseVisualStyleBackColor = False
        ' 
        ' rbOption4
        ' 
        rbOption4.Appearance = Appearance.Button
        rbOption4.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        rbOption4.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        rbOption4.FlatAppearance.BorderSize = 2
        rbOption4.FlatAppearance.CheckedBackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        rbOption4.FlatStyle = FlatStyle.Flat
        rbOption4.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        rbOption4.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        rbOption4.Location = New Point(425, 40)
        rbOption4.Name = "rbOption4"
        rbOption4.Size = New Size(60, 60)
        rbOption4.TabIndex = 3
        rbOption4.TabStop = True
        rbOption4.Text = "4"
        rbOption4.TextAlign = ContentAlignment.MiddleCenter
        rbOption4.UseVisualStyleBackColor = False
        ' 
        ' rbOption5
        ' 
        rbOption5.Appearance = Appearance.Button
        rbOption5.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        rbOption5.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        rbOption5.FlatAppearance.BorderSize = 2
        rbOption5.FlatAppearance.CheckedBackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        rbOption5.FlatStyle = FlatStyle.Flat
        rbOption5.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        rbOption5.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        rbOption5.Location = New Point(555, 40)
        rbOption5.Name = "rbOption5"
        rbOption5.Size = New Size(60, 60)
        rbOption5.TabIndex = 4
        rbOption5.TabStop = True
        rbOption5.Text = "5"
        rbOption5.TextAlign = ContentAlignment.MiddleCenter
        rbOption5.UseVisualStyleBackColor = False
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
    Friend WithEvents lblOption1 As Label
    Friend WithEvents lblOption2 As Label
    Friend WithEvents lblOption3 As Label
    Friend WithEvents lblOption4 As Label
    Friend WithEvents lblOption5 As Label
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
End Class
