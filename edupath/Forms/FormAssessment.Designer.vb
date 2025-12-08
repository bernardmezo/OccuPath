<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAssessment
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
        Me.lblPageTitle = New System.Windows.Forms.Label()
        Me.lblPageDescription = New System.Windows.Forms.Label()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.panelQuestions = New System.Windows.Forms.Panel()
        Me.panelFooter = New System.Windows.Forms.Panel()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.panelHeader.SuspendLayout()
        Me.panelFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblProgress)
        Me.panelHeader.Controls.Add(Me.progressBar)
        Me.panelHeader.Controls.Add(Me.lblPageDescription)
        Me.panelHeader.Controls.Add(Me.lblPageTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Padding = New System.Windows.Forms.Padding(20)
        Me.panelHeader.Size = New System.Drawing.Size(900, 120)
        Me.panelHeader.TabIndex = 0
        '
        'lblPageTitle
        '
        Me.lblPageTitle.AutoSize = True
        Me.lblPageTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblPageTitle.ForeColor = System.Drawing.Color.White
        Me.lblPageTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblPageTitle.Name = "lblPageTitle"
        Me.lblPageTitle.Size = New System.Drawing.Size(200, 30)
        Me.lblPageTitle.TabIndex = 0
        Me.lblPageTitle.Text = "Kategori A: Data Diri"
        '
        'lblPageDescription
        '
        Me.lblPageDescription.AutoSize = True
        Me.lblPageDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPageDescription.ForeColor = System.Drawing.Color.White
        Me.lblPageDescription.Location = New System.Drawing.Point(20, 55)
        Me.lblPageDescription.Name = "lblPageDescription"
        Me.lblPageDescription.Size = New System.Drawing.Size(250, 15)
        Me.lblPageDescription.TabIndex = 1
        Me.lblPageDescription.Text = "Silakan isi data diri Anda dengan lengkap"
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(20, 85)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(700, 20)
        Me.progressBar.TabIndex = 2
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblProgress.ForeColor = System.Drawing.Color.White
        Me.lblProgress.Location = New System.Drawing.Point(730, 88)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(100, 13)
        Me.lblProgress.TabIndex = 3
        Me.lblProgress.Text = "Halaman 1 dari 3"
        '
        'panelQuestions
        '
        Me.panelQuestions.AutoScroll = True
        Me.panelQuestions.BackColor = System.Drawing.Color.White
        Me.panelQuestions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelQuestions.Location = New System.Drawing.Point(0, 120)
        Me.panelQuestions.Name = "panelQuestions"
        Me.panelQuestions.Padding = New System.Windows.Forms.Padding(20)
        Me.panelQuestions.Size = New System.Drawing.Size(900, 400)
        Me.panelQuestions.TabIndex = 1
        '
        'panelFooter
        '
        Me.panelFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.panelFooter.Controls.Add(Me.btnNext)
        Me.panelFooter.Controls.Add(Me.btnPrevious)
        Me.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelFooter.Location = New System.Drawing.Point(0, 520)
        Me.panelFooter.Name = "panelFooter"
        Me.panelFooter.Padding = New System.Windows.Forms.Padding(20)
        Me.panelFooter.Size = New System.Drawing.Size(900, 80)
        Me.panelFooter.TabIndex = 2
        '
        'btnPrevious
        '
        Me.btnPrevious.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevious.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrevious.ForeColor = System.Drawing.Color.White
        Me.btnPrevious.Location = New System.Drawing.Point(20, 20)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(120, 40)
        Me.btnPrevious.TabIndex = 0
        Me.btnPrevious.Text = "Sebelumnya"
        Me.btnPrevious.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNext.ForeColor = System.Drawing.Color.White
        Me.btnNext.Location = New System.Drawing.Point(760, 20)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(120, 40)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "Lanjut"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'FormAssessment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 600)
        Me.Controls.Add(Me.panelQuestions)
        Me.Controls.Add(Me.panelFooter)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormAssessment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assessment - OccuPath"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.panelFooter.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblPageTitle As Label
    Friend WithEvents lblPageDescription As Label
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents lblProgress As Label
    Friend WithEvents panelQuestions As Panel
    Friend WithEvents panelFooter As Panel
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
End Class
