<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form5
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents PanelMain As Panel
    Friend WithEvents btnStartTest As Button
    Friend WithEvents btnHistory As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents PanelStats As Panel
    Friend WithEvents lblStatsTitle As Label
    Friend WithEvents lblTestCount As Label
    Friend WithEvents lblLastTest As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        PanelHeader = New Panel()
        lblWelcome = New Label()
        lblSubtitle = New Label()
        PanelMain = New Panel()
        btnStartTest = New Button()
        btnHistory = New Button()
        btnProfile = New Button()
        btnLogout = New Button()
        PanelStats = New Panel()
        lblStatsTitle = New Label()
        lblTestCount = New Label()
        lblLastTest = New Label()
        PanelHeader.SuspendLayout()
        PanelMain.SuspendLayout()
        PanelStats.SuspendLayout()
        SuspendLayout()

        ' 
        ' PanelHeader
        ' 
        PanelHeader.BackColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        PanelHeader.Controls.Add(lblWelcome)
        PanelHeader.Controls.Add(lblSubtitle)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Location = New Point(0, 0)
        PanelHeader.Name = "PanelHeader"
        PanelHeader.Size = New Size(900, 120)
        PanelHeader.TabIndex = 0

        ' 
        ' lblWelcome
        ' 
        lblWelcome.Font = New Font("Segoe UI", 28.0F, FontStyle.Bold)
        lblWelcome.ForeColor = Color.White
        lblWelcome.Location = New Point(0, 30)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(900, 50)
        lblWelcome.TabIndex = 0
        lblWelcome.Text = "Selamat datang!"
        lblWelcome.TextAlign = ContentAlignment.MiddleCenter

        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 12.0F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(230), CByte(240), CByte(255))
        lblSubtitle.Location = New Point(0, 80)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(900, 30)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Pilih menu untuk melanjutkan"
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter

        ' 
        ' PanelMain
        ' 
        PanelMain.BackColor = Color.White
        PanelMain.Controls.Add(btnStartTest)
        PanelMain.Controls.Add(btnHistory)
        PanelMain.Controls.Add(btnProfile)
        PanelMain.Controls.Add(btnLogout)
        PanelMain.Controls.Add(PanelStats)
        PanelMain.Dock = DockStyle.Fill
        PanelMain.Location = New Point(0, 120)
        PanelMain.Name = "PanelMain"
        PanelMain.Padding = New Padding(50, 30, 50, 30)
        PanelMain.Size = New Size(900, 530)
        PanelMain.TabIndex = 1

        ' 
        ' btnStartTest
        ' 
        btnStartTest.BackColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        btnStartTest.FlatAppearance.BorderSize = 0
        btnStartTest.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(35), CByte(105), CByte(190))
        btnStartTest.FlatStyle = FlatStyle.Flat
        btnStartTest.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        btnStartTest.ForeColor = Color.White
        btnStartTest.Location = New Point(100, 200)
        btnStartTest.Name = "btnStartTest"
        btnStartTest.Size = New Size(320, 80)
        btnStartTest.TabIndex = 0
        btnStartTest.Text = "🎯 Mulai Tes Baru"
        btnStartTest.UseVisualStyleBackColor = False

        ' 
        ' btnHistory
        ' 
        btnHistory.BackColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnHistory.FlatAppearance.BorderSize = 0
        btnHistory.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(56), CByte(142), CByte(60))
        btnHistory.FlatStyle = FlatStyle.Flat
        btnHistory.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        btnHistory.ForeColor = Color.White
        btnHistory.Location = New Point(480, 200)
        btnHistory.Name = "btnHistory"
        btnHistory.Size = New Size(320, 80)
        btnHistory.TabIndex = 1
        btnHistory.Text = "📋 Riwayat Tes"
        btnHistory.UseVisualStyleBackColor = False

        ' 
        ' btnProfile
        ' 
        btnProfile.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnProfile.FlatAppearance.BorderSize = 0
        btnProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(255), CByte(160), CByte(0))
        btnProfile.FlatStyle = FlatStyle.Flat
        btnProfile.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        btnProfile.ForeColor = Color.White
        btnProfile.Location = New Point(100, 310)
        btnProfile.Name = "btnProfile"
        btnProfile.Size = New Size(320, 80)
        btnProfile.TabIndex = 2
        btnProfile.Text = "👤 Profil Saya"
        btnProfile.UseVisualStyleBackColor = False

        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(CByte(239), CByte(83), CByte(80))
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(198), CByte(40), CByte(40))
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(480, 310)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(320, 80)
        btnLogout.TabIndex = 3
        btnLogout.Text = "🚪 Keluar"
        btnLogout.UseVisualStyleBackColor = False

        ' 
        ' PanelStats
        ' 
        PanelStats.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        PanelStats.BorderStyle = BorderStyle.FixedSingle
        PanelStats.Controls.Add(lblStatsTitle)
        PanelStats.Controls.Add(lblTestCount)
        PanelStats.Controls.Add(lblLastTest)
        PanelStats.Location = New Point(100, 50)
        PanelStats.Name = "PanelStats"
        PanelStats.Size = New Size(700, 120)
        PanelStats.TabIndex = 4

        ' 
        ' lblStatsTitle
        ' 
        lblStatsTitle.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblStatsTitle.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblStatsTitle.Location = New Point(20, 15)
        lblStatsTitle.Name = "lblStatsTitle"
        lblStatsTitle.Size = New Size(660, 30)
        lblStatsTitle.TabIndex = 0
        lblStatsTitle.Text = "📊 Statistik Anda"
        lblStatsTitle.TextAlign = ContentAlignment.MiddleLeft

        ' 
        ' lblTestCount
        ' 
        lblTestCount.Font = New Font("Segoe UI", 11.0F)
        lblTestCount.ForeColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        lblTestCount.Location = New Point(40, 50)
        lblTestCount.Name = "lblTestCount"
        lblTestCount.Size = New Size(640, 25)
        lblTestCount.TabIndex = 1
        lblTestCount.Text = "Total Tes: 0"
        lblTestCount.TextAlign = ContentAlignment.MiddleLeft

        ' 
        ' lblLastTest
        ' 
        lblLastTest.Font = New Font("Segoe UI", 11.0F)
        lblLastTest.ForeColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        lblLastTest.Location = New Point(40, 75)
        lblLastTest.Name = "lblLastTest"
        lblLastTest.Size = New Size(640, 25)
        lblLastTest.TabIndex = 2
        lblLastTest.Text = "Tes Terakhir: Belum ada"
        lblLastTest.TextAlign = ContentAlignment.MiddleLeft

        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(248), CByte(252))
        ClientSize = New Size(900, 650)
        Controls.Add(PanelMain)
        Controls.Add(PanelHeader)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form5"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Menu Utama"
        PanelHeader.ResumeLayout(False)
        PanelMain.ResumeLayout(False)
        PanelStats.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

End Class
