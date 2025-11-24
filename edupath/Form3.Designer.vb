<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblQuestion As Label
    Friend WithEvents panelOptions As Panel
    Friend WithEvents rb1 As RadioButton
    Friend WithEvents rb2 As RadioButton
    Friend WithEvents rb3 As RadioButton
    Friend WithEvents rb4 As RadioButton
    Friend WithEvents rb5 As RadioButton
    Friend WithEvents lblProgress As Label
    Friend WithEvents lblAgree As Label
    Friend WithEvents lblDisagree As Label
    Friend WithEvents btnNext As Button
    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelMain As Panel

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblQuestion = New Label()
        panelOptions = New Panel()
        rb1 = New RadioButton()
        rb2 = New RadioButton()
        rb3 = New RadioButton()
        rb4 = New RadioButton()
        rb5 = New RadioButton()
        lblProgress = New Label()
        lblAgree = New Label()
        lblDisagree = New Label()
        btnNext = New Button()
        panelHeader = New Panel()
        panelMain = New Panel()
        panelOptions.SuspendLayout()
        panelHeader.SuspendLayout()
        panelMain.SuspendLayout()
        SuspendLayout()
        
        ' 
        ' panelMain
        ' 
        panelMain.BackColor = Color.White
        panelMain.Controls.Add(btnNext)
        panelMain.Controls.Add(lblDisagree)
        panelMain.Controls.Add(lblAgree)
        panelMain.Controls.Add(lblProgress)
        panelMain.Controls.Add(panelOptions)
        panelMain.Controls.Add(lblQuestion)
        panelMain.Location = New Point(30, 20)
        panelMain.Name = "panelMain"
        panelMain.Size = New Size(840, 500)
        panelMain.TabIndex = 0
        
        ' 
        ' panelHeader
        ' 
        panelHeader.BackColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        panelHeader.Controls.Add(lblProgress)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Location = New Point(0, 0)
        panelHeader.Name = "panelHeader"
        panelHeader.Size = New Size(840, 70)
        panelHeader.TabIndex = 0
        
        ' 
        ' lblProgress
        ' 
        lblProgress.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblProgress.ForeColor = Color.White
        lblProgress.Location = New Point(0, 0)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(840, 70)
        lblProgress.TabIndex = 3
        lblProgress.Text = "Pertanyaan 1 / 10"
        lblProgress.TextAlign = ContentAlignment.MiddleCenter
        
        ' 
        ' lblQuestion
        ' 
        lblQuestion.Font = New Font("Segoe UI", 15.0F, FontStyle.Bold)
        lblQuestion.ForeColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        lblQuestion.Location = New Point(40, 90)
        lblQuestion.Name = "lblQuestion"
        lblQuestion.Size = New Size(760, 80)
        lblQuestion.TabIndex = 5
        lblQuestion.Text = "Pertanyaan"
        lblQuestion.TextAlign = ContentAlignment.MiddleCenter
        
        ' 
        ' panelOptions
        ' 
        panelOptions.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        panelOptions.BorderStyle = BorderStyle.None
        panelOptions.Controls.Add(rb1)
        panelOptions.Controls.Add(rb2)
        panelOptions.Controls.Add(rb3)
        panelOptions.Controls.Add(rb4)
        panelOptions.Controls.Add(rb5)
        panelOptions.Location = New Point(70, 210)
        panelOptions.Name = "panelOptions"
        panelOptions.Size = New Size(700, 100)
        panelOptions.TabIndex = 4
        
        ' 
        ' rb1
        ' 
        rb1.Appearance = Appearance.Button
        rb1.BackColor = Color.FromArgb(CByte(239), CByte(83), CByte(80))
        rb1.FlatAppearance.BorderColor = Color.FromArgb(CByte(239), CByte(83), CByte(80))
        rb1.FlatAppearance.BorderSize = 0
        rb1.FlatAppearance.CheckedBackColor = Color.FromArgb(CByte(198), CByte(40), CByte(40))
        rb1.FlatStyle = FlatStyle.Flat
        rb1.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        rb1.ForeColor = Color.White
        rb1.Location = New Point(20, 20)
        rb1.Name = "rb1"
        rb1.Size = New Size(70, 70)
        rb1.TabIndex = 0
        rb1.Text = "1"
        rb1.TextAlign = ContentAlignment.MiddleCenter
        rb1.UseVisualStyleBackColor = False
        
        ' 
        ' rb2
        ' 
        rb2.Appearance = Appearance.Button
        rb2.BackColor = Color.FromArgb(CByte(255), CByte(138), CByte(101))
        rb2.FlatAppearance.BorderColor = Color.FromArgb(CByte(255), CByte(138), CByte(101))
        rb2.FlatAppearance.BorderSize = 0
        rb2.FlatAppearance.CheckedBackColor = Color.FromArgb(CByte(255), CByte(87), CByte(34))
        rb2.FlatStyle = FlatStyle.Flat
        rb2.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        rb2.ForeColor = Color.White
        rb2.Location = New Point(150, 25)
        rb2.Name = "rb2"
        rb2.Size = New Size(60, 60)
        rb2.TabIndex = 1
        rb2.Text = "2"
        rb2.TextAlign = ContentAlignment.MiddleCenter
        rb2.UseVisualStyleBackColor = False
        
        ' 
        ' rb3
        ' 
        rb3.Appearance = Appearance.Button
        rb3.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        rb3.FlatAppearance.BorderColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        rb3.FlatAppearance.BorderSize = 0
        rb3.FlatAppearance.CheckedBackColor = Color.FromArgb(CByte(255), CByte(160), CByte(0))
        rb3.FlatStyle = FlatStyle.Flat
        rb3.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        rb3.ForeColor = Color.White
        rb3.Location = New Point(290, 30)
        rb3.Name = "rb3"
        rb3.Size = New Size(50, 50)
        rb3.TabIndex = 2
        rb3.Text = "3"
        rb3.TextAlign = ContentAlignment.MiddleCenter
        rb3.UseVisualStyleBackColor = False
        
        ' 
        ' rb4
        ' 
        rb4.Appearance = Appearance.Button
        rb4.BackColor = Color.FromArgb(CByte(102), CByte(187), CByte(106))
        rb4.FlatAppearance.BorderColor = Color.FromArgb(CByte(102), CByte(187), CByte(106))
        rb4.FlatAppearance.BorderSize = 0
        rb4.FlatAppearance.CheckedBackColor = Color.FromArgb(CByte(67), CByte(160), CByte(71))
        rb4.FlatStyle = FlatStyle.Flat
        rb4.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        rb4.ForeColor = Color.White
        rb4.Location = New Point(420, 25)
        rb4.Name = "rb4"
        rb4.Size = New Size(60, 60)
        rb4.TabIndex = 3
        rb4.Text = "4"
        rb4.TextAlign = ContentAlignment.MiddleCenter
        rb4.UseVisualStyleBackColor = False
        
        ' 
        ' rb5
        ' 
        rb5.Appearance = Appearance.Button
        rb5.BackColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        rb5.FlatAppearance.BorderColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        rb5.FlatAppearance.BorderSize = 0
        rb5.FlatAppearance.CheckedBackColor = Color.FromArgb(CByte(46), CByte(125), CByte(50))
        rb5.FlatStyle = FlatStyle.Flat
        rb5.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        rb5.ForeColor = Color.White
        rb5.Location = New Point(560, 20)
        rb5.Name = "rb5"
        rb5.Size = New Size(70, 70)
        rb5.TabIndex = 4
        rb5.Text = "5"
        rb5.TextAlign = ContentAlignment.MiddleCenter
        rb5.UseVisualStyleBackColor = False
        
        ' 
        ' lblAgree
        ' 
        lblAgree.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblAgree.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblAgree.Location = New Point(70, 320)
        lblAgree.Name = "lblAgree"
        lblAgree.Size = New Size(150, 25)
        lblAgree.TabIndex = 2
        lblAgree.Text = "Sangat Tidak Setuju"
        lblAgree.TextAlign = ContentAlignment.MiddleLeft
        
        ' 
        ' lblDisagree
        ' 
        lblDisagree.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblDisagree.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblDisagree.Location = New Point(620, 320)
        lblDisagree.Name = "lblDisagree"
        lblDisagree.Size = New Size(150, 25)
        lblDisagree.TabIndex = 1
        lblDisagree.Text = "Sangat Setuju"
        lblDisagree.TextAlign = ContentAlignment.MiddleRight
        
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        btnNext.FlatAppearance.BorderSize = 0
        btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(35), CByte(105), CByte(190))
        btnNext.FlatStyle = FlatStyle.Flat
        btnNext.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(320, 390)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(200, 50)
        btnNext.TabIndex = 0
        btnNext.Text = "Lanjut ▶"
        btnNext.UseVisualStyleBackColor = False
        
        ' 
        ' Add header to main panel
        '
        panelMain.Controls.Add(panelHeader)
        
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(248), CByte(252))
        ClientSize = New Size(900, 560)
        Controls.Add(panelMain)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form3"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Tes Kepribadian"
        panelOptions.ResumeLayout(False)
        panelHeader.ResumeLayout(False)
        panelMain.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

End Class
