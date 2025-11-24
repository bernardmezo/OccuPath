<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents PanelHero As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblTagline As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents btnGetStarted As Button
    Friend WithEvents PanelFeatures As Panel
    Friend WithEvents lblFeature1 As Label
    Friend WithEvents lblFeature2 As Label
    Friend WithEvents lblFeature3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        PanelHero = New Panel()
        lblTitle = New Label()
        lblTagline = New Label()
        lblDescription = New Label()
        btnGetStarted = New Button()
        PanelFeatures = New Panel()
        PictureBox1 = New PictureBox()
        lblFeature1 = New Label()
        PictureBox2 = New PictureBox()
        lblFeature2 = New Label()
        PictureBox3 = New PictureBox()
        lblFeature3 = New Label()
        PanelHero.SuspendLayout()
        PanelFeatures.SuspendLayout()
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PanelHero
        ' 
        PanelHero.BackColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        PanelHero.Controls.Add(lblTitle)
        PanelHero.Controls.Add(lblTagline)
        PanelHero.Controls.Add(lblDescription)
        PanelHero.Controls.Add(btnGetStarted)
        PanelHero.Dock = DockStyle.Top
        PanelHero.Location = New Point(0, 0)
        PanelHero.Name = "PanelHero"
        PanelHero.Size = New Size(1000, 380)
        PanelHero.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.Font = New Font("Segoe UI", 48.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(0, 50)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(1000, 90)
        lblTitle.TabIndex = 0
        lblTitle.Text = "OccuPath"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTagline
        ' 
        lblTagline.Font = New Font("Segoe UI", 20.0F, FontStyle.Regular)
        lblTagline.ForeColor = Color.FromArgb(CByte(230), CByte(240), CByte(255))
        lblTagline.Location = New Point(0, 140)
        lblTagline.Name = "lblTagline"
        lblTagline.Size = New Size(1000, 40)
        lblTagline.TabIndex = 1
        lblTagline.Text = "Temukan Jalur Karir Impian Anda"
        lblTagline.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDescription
        ' 
        lblDescription.Font = New Font("Segoe UI", 13.0F)
        lblDescription.ForeColor = Color.FromArgb(CByte(220), CByte(235), CByte(255))
        lblDescription.Location = New Point(200, 190)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(600, 60)
        lblDescription.TabIndex = 2
        lblDescription.Text = "Sistem pakar untuk membantu Anda menemukan jalur karir yang sesuai dengan kepribadian, minat, dan kemampuan Anda."
        lblDescription.TextAlign = ContentAlignment.TopCenter
        ' 
        ' btnGetStarted
        ' 
        btnGetStarted.BackColor = Color.White
        btnGetStarted.FlatAppearance.BorderSize = 0
        btnGetStarted.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        btnGetStarted.FlatStyle = FlatStyle.Flat
        btnGetStarted.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        btnGetStarted.ForeColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        btnGetStarted.Location = New Point(375, 280)
        btnGetStarted.Name = "btnGetStarted"
        btnGetStarted.Size = New Size(250, 60)
        btnGetStarted.TabIndex = 3
        btnGetStarted.Text = "Mulai Sekarang →"
        btnGetStarted.UseVisualStyleBackColor = False
        ' 
        ' PanelFeatures
        ' 
        PanelFeatures.BackColor = Color.White
        PanelFeatures.Controls.Add(PictureBox1)
        PanelFeatures.Controls.Add(lblFeature1)
        PanelFeatures.Controls.Add(PictureBox2)
        PanelFeatures.Controls.Add(lblFeature2)
        PanelFeatures.Controls.Add(PictureBox3)
        PanelFeatures.Controls.Add(lblFeature3)
        PanelFeatures.Dock = DockStyle.Fill
        PanelFeatures.Location = New Point(0, 380)
        PanelFeatures.Name = "PanelFeatures"
        PanelFeatures.Size = New Size(1000, 270)
        PanelFeatures.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        PictureBox1.Location = New Point(120, 40)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(80, 80)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' lblFeature1
        ' 
        lblFeature1.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblFeature1.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblFeature1.Location = New Point(40, 135)
        lblFeature1.Name = "lblFeature1"
        lblFeature1.Size = New Size(240, 80)
        lblFeature1.TabIndex = 1
        lblFeature1.Text = "🎯 Tes Kepribadian" & vbCrLf & vbCrLf & "Analisis mendalam tentang kepribadian Anda"
        lblFeature1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        PictureBox2.Location = New Point(460, 40)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(80, 80)
        PictureBox2.TabIndex = 2
        PictureBox2.TabStop = False
        ' 
        ' lblFeature2
        ' 
        lblFeature2.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblFeature2.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblFeature2.Location = New Point(380, 135)
        lblFeature2.Name="lblFeature2"
        lblFeature2.Size = New Size(240, 80)
        lblFeature2.TabIndex = 3
        lblFeature2.Text = "💡 Rekomendasi Karir" & vbCrLf & vbCrLf & "Saran karir berdasarkan hasil tes"
        lblFeature2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.FromArgb(CByte(239), CByte(83), CByte(80))
        PictureBox3.Location = New Point(800, 40)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(80, 80)
        PictureBox3.TabIndex = 4
        PictureBox3.TabStop = False
        ' 
        ' lblFeature3
        ' 
        lblFeature3.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblFeature3.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblFeature3.Location = New Point(720, 135)
        lblFeature3.Name = "lblFeature3"
        lblFeature3.Size = New Size(240, 80)
        lblFeature3.TabIndex = 5
        lblFeature3.Text = "📊 Riwayat & Tracking" & vbCrLf & vbCrLf & "Lacak perkembangan Anda"
        lblFeature3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1000, 650)
        Controls.Add(PanelFeatures)
        Controls.Add(PanelHero)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Sistem Pakar Profil Karir"
        PanelHero.ResumeLayout(False)
        PanelFeatures.ResumeLayout(False)
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

End Class
