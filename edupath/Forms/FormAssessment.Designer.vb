<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAssessment
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
        panelHeader = New Panel()
        lblPageTitle = New Label()
        lblPageDescription = New Label()
        lblProgress = New Label()
        progressBar = New ProgressBar()
        panelProgressContainer = New Panel()
        lblProgressPercent = New Label()
        panelQuestions = New Panel()
        panelFooter = New Panel()
        btnPrevious = New Button()
        btnNext = New Button()
        panelHeader.SuspendLayout()
        panelProgressContainer.SuspendLayout()
        panelFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelAccent
        ' 
        panelAccent.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        panelAccent.Dock = DockStyle.Left
        panelAccent.Location = New Point(0, 0)
        panelAccent.Name = "panelAccent"
        panelAccent.Size = New Size(5, 700)
        panelAccent.TabIndex = 0
        ' 
        ' panelHeader
        ' 
        panelHeader.BackColor = Color.White
        panelHeader.Controls.Add(lblPageTitle)
        panelHeader.Controls.Add(lblPageDescription)
        panelHeader.Controls.Add(panelProgressContainer)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Location = New Point(5, 0)
        panelHeader.Name = "panelHeader"
        panelHeader.Padding = New Padding(30, 25, 30, 20)
        panelHeader.Size = New Size(995, 140)
        panelHeader.TabIndex = 1
        ' 
        ' lblPageTitle
        ' 
        lblPageTitle.AutoSize = True
        lblPageTitle.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold)
        lblPageTitle.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblPageTitle.Location = New Point(30, 25)
        lblPageTitle.Name = "lblPageTitle"
        lblPageTitle.Size = New Size(350, 37)
        lblPageTitle.TabIndex = 0
        lblPageTitle.Text = "?? Kategori A: Data Diri"
        ' 
        ' lblPageDescription
        ' 
        lblPageDescription.AutoSize = True
        lblPageDescription.Font = New Font("Segoe UI", 11.0F)
        lblPageDescription.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblPageDescription.Location = New Point(30, 70)
        lblPageDescription.Name = "lblPageDescription"
        lblPageDescription.Size = New Size(400, 20)
        lblPageDescription.TabIndex = 1
        lblPageDescription.Text = "Silakan isi data diri Anda dengan lengkap"
        ' 
        ' panelProgressContainer
        ' 
        panelProgressContainer.Controls.Add(lblProgress)
        panelProgressContainer.Controls.Add(progressBar)
        panelProgressContainer.Controls.Add(lblProgressPercent)
        panelProgressContainer.Location = New Point(30, 105)
        panelProgressContainer.Name = "panelProgressContainer"
        panelProgressContainer.Size = New Size(920, 25)
        panelProgressContainer.TabIndex = 2
        ' 
        ' lblProgress
        ' 
        lblProgress.AutoSize = True
        lblProgress.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblProgress.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblProgress.Location = New Point(0, 5)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(110, 15)
        lblProgress.TabIndex = 0
        lblProgress.Text = "Halaman 1 dari 3"
        ' 
        ' progressBar
        ' 
        progressBar.Location = New Point(130, 5)
        progressBar.Name = "progressBar"
        progressBar.Size = New Size(720, 15)
        progressBar.Style = ProgressBarStyle.Continuous
        progressBar.TabIndex = 1
        progressBar.Value = 33
        ' 
        ' lblProgressPercent
        ' 
        lblProgressPercent.AutoSize = True
        lblProgressPercent.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblProgressPercent.ForeColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lblProgressPercent.Location = New Point(865, 5)
        lblProgressPercent.Name = "lblProgressPercent"
        lblProgressPercent.Size = New Size(35, 15)
        lblProgressPercent.TabIndex = 2
        lblProgressPercent.Text = "33%"
        lblProgressPercent.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' panelQuestions
        ' 
        panelQuestions.AutoScroll = True
        panelQuestions.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(247))
        panelQuestions.Dock = DockStyle.Fill
        panelQuestions.Location = New Point(5, 140)
        panelQuestions.Name = "panelQuestions"
        panelQuestions.Padding = New Padding(30, 20, 30, 20)
        panelQuestions.Size = New Size(995, 480)
        panelQuestions.TabIndex = 2
        ' 
        ' panelFooter
        ' 
        panelFooter.BackColor = Color.White
        panelFooter.BorderStyle = BorderStyle.FixedSingle
        panelFooter.Controls.Add(btnPrevious)
        panelFooter.Controls.Add(btnNext)
        panelFooter.Dock = DockStyle.Bottom
        panelFooter.Location = New Point(5, 620)
        panelFooter.Name = "panelFooter"
        panelFooter.Padding = New Padding(30, 15, 30, 15)
        panelFooter.Size = New Size(995, 80)
        panelFooter.TabIndex = 3
        ' 
        ' btnPrevious
        ' 
        btnPrevious.BackColor = Color.White
        btnPrevious.Cursor = Cursors.Hand
        btnPrevious.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        btnPrevious.FlatStyle = FlatStyle.Flat
        btnPrevious.Font = New Font("Segoe UI", 11.0F)
        btnPrevious.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        btnPrevious.Location = New Point(30, 15)
        btnPrevious.Name = "btnPrevious"
        btnPrevious.Size = New Size(150, 48)
        btnPrevious.TabIndex = 0
        btnPrevious.Text = "< Sebelumnya"
        btnPrevious.UseVisualStyleBackColor = False
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnNext.Cursor = Cursors.Hand
        btnNext.FlatAppearance.BorderSize = 0
        btnNext.FlatStyle = FlatStyle.Flat
        btnNext.Font = New Font("Segoe UI Semibold", 11.0F, FontStyle.Bold)
        btnNext.ForeColor = Color.White
        btnNext.Location = New Point(795, 15)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(150, 48)
        btnNext.TabIndex = 1
        btnNext.Text = "Lanjut >"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' FormAssessment
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1000, 700)
        Controls.Add(panelQuestions)
        Controls.Add(panelFooter)
        Controls.Add(panelHeader)
        Controls.Add(panelAccent)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FormAssessment"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Assessment"
        panelHeader.ResumeLayout(False)
        panelHeader.PerformLayout()
        panelProgressContainer.ResumeLayout(False)
        panelProgressContainer.PerformLayout()
        panelFooter.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelAccent As Panel
    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblPageTitle As Label
    Friend WithEvents lblPageDescription As Label
    Friend WithEvents panelProgressContainer As Panel
    Friend WithEvents lblProgress As Label
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents lblProgressPercent As Label
    Friend WithEvents panelQuestions As Panel
    Friend WithEvents panelFooter As Panel
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
End Class
