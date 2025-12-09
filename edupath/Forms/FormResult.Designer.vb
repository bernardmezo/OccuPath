<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormResult
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
        lblTitle = New Label()
        lblSubtitle = New Label()
        panelResults = New FlowLayoutPanel()
        panelButtons = New Panel()
        btnDashboard = New Button()
        btnNewTest = New Button()
        SuspendLayout()
        ' 
        ' panelAccent
        ' 
        panelAccent.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        panelAccent.Dock = DockStyle.Left
        panelAccent.Location = New Point(0, 0)
        panelAccent.Name = "panelAccent"
        panelAccent.Size = New Size(5, 600)
        panelAccent.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblTitle.Location = New Point(30, 30)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(388, 45)
        lblTitle.TabIndex = 1
        lblTitle.Text = "?? Hasil Analisis Karir Anda"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 11.0F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblSubtitle.Location = New Point(30, 85)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(740, 50)
        lblSubtitle.TabIndex = 2
        lblSubtitle.Text = "Berdasarkan analisis Forward Chaining & Certainty Factor, berikut adalah rekomendasi profil lulusan yang paling sesuai dengan Anda:"
        ' 
        ' panelResults
        ' 
        panelResults.AutoScroll = True
        panelResults.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(247))
        panelResults.FlowDirection = FlowDirection.TopDown
        panelResults.Location = New Point(30, 150)
        panelResults.Name = "panelResults"
        panelResults.Padding = New Padding(10)
        panelResults.Size = New Size(740, 340)
        panelResults.TabIndex = 3
        panelResults.WrapContents = False
        ' 
        ' panelButtons
        ' 
        panelButtons.BackColor = Color.White
        panelButtons.Location = New Point(30, 500)
        panelButtons.Name = "panelButtons"
        panelButtons.Size = New Size(740, 70)
        panelButtons.TabIndex = 4
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(30, 510)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(200, 45)
        btnDashboard.TabIndex = 5
        btnDashboard.Text = "?? Kembali ke Dashboard"
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' btnNewTest
        ' 
        btnNewTest.BackColor = Color.White
        btnNewTest.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        btnNewTest.FlatStyle = FlatStyle.Flat
        btnNewTest.Font = New Font("Segoe UI", 11.0F)
        btnNewTest.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        btnNewTest.Location = New Point(250, 510)
        btnNewTest.Name = "btnNewTest"
        btnNewTest.Size = New Size(150, 45)
        btnNewTest.TabIndex = 6
        btnNewTest.Text = "?? Tes Baru"
        btnNewTest.UseVisualStyleBackColor = False
        ' 
        ' FormResult
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(800, 600)
        Controls.Add(btnNewTest)
        Controls.Add(btnDashboard)
        Controls.Add(panelResults)
        Controls.Add(lblSubtitle)
        Controls.Add(lblTitle)
        Controls.Add(panelAccent)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FormResult"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Hasil Analisis"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents panelAccent As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents panelResults As FlowLayoutPanel
    Friend WithEvents panelButtons As Panel
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnNewTest As Button
End Class
