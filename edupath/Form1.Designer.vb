<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        lblAppName = New Label()
        lblTagline = New Label()
        lblDescription = New Label()
        btnGetStarted = New Button()
        lblFooter = New Label()
        panelLine = New Panel()
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
        ' lblAppName
        ' 
        lblAppName.AutoSize = True
        lblAppName.Font = New Font("Segoe UI", 42F, FontStyle.Bold)
        lblAppName.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblAppName.Location = New Point(70, 80)
        lblAppName.Name = "lblAppName"
        lblAppName.Size = New Size(281, 74)
        lblAppName.TabIndex = 1
        lblAppName.Text = "OccuPath"
        ' 
        ' lblTagline
        ' 
        lblTagline.AutoSize = True
        lblTagline.Font = New Font("Segoe UI", 16F)
        lblTagline.ForeColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lblTagline.Location = New Point(75, 165)
        lblTagline.Name = "lblTagline"
        lblTagline.Size = New Size(396, 30)
        lblTagline.TabIndex = 2
        lblTagline.Text = "Temukan jalur karir yang tepat untukmu"
        ' 
        ' lblDescription
        ' 
        lblDescription.Font = New Font("Segoe UI", 11F)
        lblDescription.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblDescription.Location = New Point(75, 235)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(550, 100)
        lblDescription.TabIndex = 4
        lblDescription.Text = "Sistem rekomendasi profil lulusan untuk membantu " & vbCrLf & "mahasiswa menemukan jalur karir yang sesuai dengan " & vbCrLf & "minat, bakat, dan kemampuan akademis."
        ' 
        ' btnGetStarted
        ' 
        btnGetStarted.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnGetStarted.FlatAppearance.BorderSize = 0
        btnGetStarted.FlatStyle = FlatStyle.Flat
        btnGetStarted.Font = New Font("Segoe UI", 12F)
        btnGetStarted.ForeColor = Color.White
        btnGetStarted.Location = New Point(75, 370)
        btnGetStarted.Name = "btnGetStarted"
        btnGetStarted.Size = New Size(180, 50)
        btnGetStarted.TabIndex = 5
        btnGetStarted.Text = "Mulai"
        btnGetStarted.UseVisualStyleBackColor = False
        ' 
        ' lblFooter
        ' 
        lblFooter.AutoSize = True
        lblFooter.Font = New Font("Segoe UI", 9F)
        lblFooter.ForeColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        lblFooter.Location = New Point(75, 540)
        lblFooter.Name = "lblFooter"
        lblFooter.Size = New Size(73, 15)
        lblFooter.TabIndex = 6
        lblFooter.Text = "© OccuPath"
        ' 
        ' panelLine
        ' 
        panelLine.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        panelLine.Location = New Point(75, 210)
        panelLine.Name = "panelLine"
        panelLine.Size = New Size(60, 3)
        panelLine.TabIndex = 3
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(700, 600)
        Controls.Add(lblFooter)
        Controls.Add(btnGetStarted)
        Controls.Add(lblDescription)
        Controls.Add(panelLine)
        Controls.Add(lblTagline)
        Controls.Add(lblAppName)
        Controls.Add(panelAccent)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents panelAccent As Panel
    Friend WithEvents lblAppName As Label
    Friend WithEvents lblTagline As Label
    Friend WithEvents panelLine As Panel
    Friend WithEvents lblDescription As Label
    Friend WithEvents btnGetStarted As Button
    Friend WithEvents lblFooter As Label
End Class
