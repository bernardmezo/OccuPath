<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form5
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
        Me.panelAccent = New System.Windows.Forms.Panel()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.panelMenu = New System.Windows.Forms.Panel()
        Me.btnStartTest = New System.Windows.Forms.Button()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.panelMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelAccent
        '
        Me.panelAccent.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.panelAccent.Location = New System.Drawing.Point(0, 0)
        Me.panelAccent.Name = "panelAccent"
        Me.panelAccent.Size = New System.Drawing.Size(5, 600)
        Me.panelAccent.TabIndex = 0
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblWelcome.Location = New System.Drawing.Point(30, 35)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(312, 47)
        Me.lblWelcome.TabIndex = 1
        Me.lblWelcome.Text = "Selamat datang, "
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(35, 92)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(275, 20)
        Me.lblSubtitle.TabIndex = 2
        Me.lblSubtitle.Text = "Pilih menu di bawah untuk memulai"
        '
        'panelMenu
        '
        Me.panelMenu.BackColor = System.Drawing.Color.White
        Me.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelMenu.Controls.Add(Me.btnStartTest)
        Me.panelMenu.Controls.Add(Me.btnHistory)
        Me.panelMenu.Controls.Add(Me.btnProfile)
        Me.panelMenu.Location = New System.Drawing.Point(30, 135)
        Me.panelMenu.Name = "panelMenu"
        Me.panelMenu.Size = New System.Drawing.Size(640, 350)
        Me.panelMenu.TabIndex = 3
        '
        'btnStartTest
        '
        Me.btnStartTest.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnStartTest.FlatAppearance.BorderSize = 0
        Me.btnStartTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartTest.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnStartTest.ForeColor = System.Drawing.Color.White
        Me.btnStartTest.Location = New System.Drawing.Point(25, 25)
        Me.btnStartTest.Name = "btnStartTest"
        Me.btnStartTest.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.btnStartTest.Size = New System.Drawing.Size(585, 85)
        Me.btnStartTest.TabIndex = 0
        Me.btnStartTest.Text = "Mulai Tes"
        Me.btnStartTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStartTest.UseVisualStyleBackColor = False
        '
        'btnHistory
        '
        Me.btnHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnHistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistory.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnHistory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnHistory.Location = New System.Drawing.Point(25, 130)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.btnHistory.Size = New System.Drawing.Size(585, 65)
        Me.btnHistory.TabIndex = 1
        Me.btnHistory.Text = "Riwayat Tes"
        Me.btnHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHistory.UseVisualStyleBackColor = False
        '
        'btnProfile
        '
        Me.btnProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProfile.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnProfile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnProfile.Location = New System.Drawing.Point(25, 215)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.btnProfile.Size = New System.Drawing.Size(585, 65)
        Me.btnProfile.TabIndex = 2
        Me.btnProfile.Text = "Profil"
        Me.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProfile.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.White
        Me.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnLogout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnLogout.Location = New System.Drawing.Point(30, 510)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(120, 40)
        Me.btnLogout.TabIndex = 4
        Me.btnLogout.Text = "Keluar"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(700, 600)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.panelMenu)
        Me.Controls.Add(Me.lblSubtitle)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.panelAccent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OccuPath - Menu"
        Me.panelMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelAccent As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents panelMenu As Panel
    Friend WithEvents btnStartTest As Button
    Friend WithEvents btnHistory As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents btnLogout As Button
End Class
