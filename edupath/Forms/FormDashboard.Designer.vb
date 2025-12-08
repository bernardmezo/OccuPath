<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDashboard
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
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.panelStats = New System.Windows.Forms.Panel()
        Me.lblTotalAssessments = New System.Windows.Forms.Label()
        Me.lblLastAssessment = New System.Windows.Forms.Label()
        Me.panelActions = New System.Windows.Forms.Panel()
        Me.btnStartAssessment = New System.Windows.Forms.Button()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.panelHeader.SuspendLayout()
        Me.panelMain.SuspendLayout()
        Me.panelStats.SuspendLayout()
        Me.panelActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.btnLogout)
        Me.panelHeader.Controls.Add(Me.lblWelcome)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Padding = New System.Windows.Forms.Padding(20)
        Me.panelHeader.Size = New System.Drawing.Size(800, 80)
        Me.panelHeader.TabIndex = 0
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblWelcome.ForeColor = System.Drawing.Color.White
        Me.lblWelcome.Location = New System.Drawing.Point(20, 25)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(200, 32)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "Selamat Datang!"
        '
        'btnLogout
        '
        Me.btnLogout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(680, 20)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(100, 40)
        Me.btnLogout.TabIndex = 1
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'panelMain
        '
        Me.panelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.panelMain.Controls.Add(Me.panelActions)
        Me.panelMain.Controls.Add(Me.panelStats)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(0, 80)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Padding = New System.Windows.Forms.Padding(20)
        Me.panelMain.Size = New System.Drawing.Size(800, 470)
        Me.panelMain.TabIndex = 1
        '
        'panelStats
        '
        Me.panelStats.BackColor = System.Drawing.Color.White
        Me.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelStats.Controls.Add(Me.lblLastAssessment)
        Me.panelStats.Controls.Add(Me.lblTotalAssessments)
        Me.panelStats.Location = New System.Drawing.Point(20, 20)
        Me.panelStats.Name = "panelStats"
        Me.panelStats.Padding = New System.Windows.Forms.Padding(20)
        Me.panelStats.Size = New System.Drawing.Size(760, 100)
        Me.panelStats.TabIndex = 0
        '
        'lblTotalAssessments
        '
        Me.lblTotalAssessments.AutoSize = True
        Me.lblTotalAssessments.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAssessments.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblTotalAssessments.Location = New System.Drawing.Point(20, 20)
        Me.lblTotalAssessments.Name = "lblTotalAssessments"
        Me.lblTotalAssessments.Size = New System.Drawing.Size(100, 21)
        Me.lblTotalAssessments.TabIndex = 0
        Me.lblTotalAssessments.Text = "Total Tes: 0"
        '
        'lblLastAssessment
        '
        Me.lblLastAssessment.AutoSize = True
        Me.lblLastAssessment.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblLastAssessment.ForeColor = System.Drawing.Color.Gray
        Me.lblLastAssessment.Location = New System.Drawing.Point(20, 50)
        Me.lblLastAssessment.Name = "lblLastAssessment"
        Me.lblLastAssessment.Size = New System.Drawing.Size(150, 19)
        Me.lblLastAssessment.TabIndex = 1
        Me.lblLastAssessment.Text = "Tes Terakhir: Belum ada"
        '
        'panelActions
        '
        Me.panelActions.BackColor = System.Drawing.Color.White
        Me.panelActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelActions.Controls.Add(Me.btnAbout)
        Me.panelActions.Controls.Add(Me.btnProfile)
        Me.panelActions.Controls.Add(Me.btnHistory)
        Me.panelActions.Controls.Add(Me.btnStartAssessment)
        Me.panelActions.Location = New System.Drawing.Point(20, 140)
        Me.panelActions.Name = "panelActions"
        Me.panelActions.Padding = New System.Windows.Forms.Padding(20)
        Me.panelActions.Size = New System.Drawing.Size(760, 310)
        Me.panelActions.TabIndex = 1
        '
        'btnStartAssessment
        '
        Me.btnStartAssessment.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnStartAssessment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStartAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartAssessment.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnStartAssessment.ForeColor = System.Drawing.Color.White
        Me.btnStartAssessment.Location = New System.Drawing.Point(20, 20)
        Me.btnStartAssessment.Name = "btnStartAssessment"
        Me.btnStartAssessment.Size = New System.Drawing.Size(720, 80)
        Me.btnStartAssessment.TabIndex = 0
        Me.btnStartAssessment.Text = "🎯 Mulai Tes Profil Lulusan"
        Me.btnStartAssessment.UseVisualStyleBackColor = False
        '
        'btnHistory
        '
        Me.btnHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistory.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnHistory.ForeColor = System.Drawing.Color.White
        Me.btnHistory.Location = New System.Drawing.Point(20, 120)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(350, 60)
        Me.btnHistory.TabIndex = 1
        Me.btnHistory.Text = "📊 Lihat Riwayat Tes"
        Me.btnHistory.UseVisualStyleBackColor = False
        '
        'btnProfile
        '
        Me.btnProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProfile.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnProfile.ForeColor = System.Drawing.Color.White
        Me.btnProfile.Location = New System.Drawing.Point(390, 120)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Size = New System.Drawing.Size(350, 60)
        Me.btnProfile.TabIndex = 2
        Me.btnProfile.Text = "👤 Profil Saya"
        Me.btnProfile.UseVisualStyleBackColor = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnAbout.ForeColor = System.Drawing.Color.White
        Me.btnAbout.Location = New System.Drawing.Point(20, 200)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(720, 60)
        Me.btnAbout.TabIndex = 3
        Me.btnAbout.Text = "ℹ️ Tentang OccuPath"
        Me.btnAbout.UseVisualStyleBackColor = False
        '
        'FormDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 550)
        Me.Controls.Add(Me.panelMain)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard - OccuPath"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.panelMain.ResumeLayout(False)
        Me.panelStats.ResumeLayout(False)
        Me.panelStats.PerformLayout()
        Me.panelActions.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents panelMain As Panel
    Friend WithEvents panelStats As Panel
    Friend WithEvents lblTotalAssessments As Label
    Friend WithEvents lblLastAssessment As Label
    Friend WithEvents panelActions As Panel
    Friend WithEvents btnStartAssessment As Button
    Friend WithEvents btnHistory As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents btnAbout As Button
End Class
