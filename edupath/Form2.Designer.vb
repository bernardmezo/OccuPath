<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents LabelQuestion As Label
    Friend WithEvents LabelSelect As Label
    Friend WithEvents ButtonBack As Button
    Friend WithEvents ButtonNext As Button
    Friend WithEvents LabelProgress As Label
    Friend WithEvents PanelBox As Panel
    Friend WithEvents PanelHeader As Panel
    Friend WithEvents PanelMain As Panel

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ComboBox1 = New ComboBox()
        Me.LabelQuestion = New Label()
        Me.LabelSelect = New Label()
        Me.ButtonBack = New Button()
        Me.ButtonNext = New Button()
        Me.LabelProgress = New Label()
        Me.PanelBox = New Panel()
        Me.PanelHeader = New Panel()
        Me.PanelMain = New Panel()
        Me.PanelBox.SuspendLayout()
        Me.PanelHeader.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()

        '
        ' PanelMain
        '
        Me.PanelMain.BackColor = Color.White
        Me.PanelMain.Controls.Add(Me.ButtonNext)
        Me.PanelMain.Controls.Add(Me.ButtonBack)
        Me.PanelMain.Controls.Add(Me.PanelBox)
        Me.PanelMain.Controls.Add(Me.LabelQuestion)
        Me.PanelMain.Location = New Point(30, 20)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New Size(640, 420)
        Me.PanelMain.TabIndex = 0

        '
        ' PanelHeader
        '
        Me.PanelHeader.BackColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        Me.PanelHeader.Controls.Add(Me.LabelProgress)
        Me.PanelHeader.Dock = DockStyle.Top
        Me.PanelHeader.Location = New Point(0, 0)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New Size(640, 60)
        Me.PanelHeader.TabIndex = 0

        '
        ' LabelProgress
        '
        Me.LabelProgress.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        Me.LabelProgress.ForeColor = Color.White
        Me.LabelProgress.Location = New Point(0, 0)
        Me.LabelProgress.Name = "LabelProgress"
        Me.LabelProgress.Size = New Size(640, 60)
        Me.LabelProgress.Text = "Pertanyaan 1 / 10"
        Me.LabelProgress.TextAlign = ContentAlignment.MiddleCenter

        '
        ' LabelQuestion
        '
        Me.LabelQuestion.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        Me.LabelQuestion.ForeColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Me.LabelQuestion.Location = New Point(40, 85)
        Me.LabelQuestion.Name = "LabelQuestion"
        Me.LabelQuestion.Size = New Size(560, 70)
        Me.LabelQuestion.Text = "Lorem Ipsum dolor, Lorem Ipsum dolor, Lorem Ipsum dolor."
        Me.LabelQuestion.TextAlign = ContentAlignment.MiddleCenter

        '
        ' PanelBox
        '
        Me.PanelBox.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        Me.PanelBox.BorderStyle = BorderStyle.FixedSingle
        Me.PanelBox.Location = New Point(120, 190)
        Me.PanelBox.Name = "PanelBox"
        Me.PanelBox.Size = New Size(400, 90)

        '
        ' LabelSelect
        '
        Me.LabelSelect.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Me.LabelSelect.ForeColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        Me.LabelSelect.Location = New Point(15, 12)
        Me.LabelSelect.Name = "LabelSelect"
        Me.LabelSelect.Size = New Size(370, 22)
        Me.LabelSelect.Text = "Pilih jawaban Anda:"

        '
        ' ComboBox1
        '
        Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New Font("Segoe UI", 11.0F)
        Me.ComboBox1.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        Me.ComboBox1.Location = New Point(15, 42)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New Size(370, 28)

        '
        ' Add ComboBox & text into panel
        '
        Me.PanelBox.Controls.Add(Me.LabelSelect)
        Me.PanelBox.Controls.Add(Me.ComboBox1)

        '
        ' ButtonBack
        '
        Me.ButtonBack.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        Me.ButtonBack.FlatAppearance.BorderSize = 0
        Me.ButtonBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        Me.ButtonBack.FlatStyle = FlatStyle.Flat
        Me.ButtonBack.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Me.ButtonBack.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        Me.ButtonBack.Location = New Point(120, 330)
        Me.ButtonBack.Name = "ButtonBack"
        Me.ButtonBack.Size = New Size(140, 45)
        Me.ButtonBack.Text = "◀ Kembali"
        Me.ButtonBack.UseVisualStyleBackColor = False

        '
        ' ButtonNext
        '
        Me.ButtonNext.BackColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        Me.ButtonNext.FlatAppearance.BorderSize = 0
        Me.ButtonNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(35), CByte(105), CByte(190))
        Me.ButtonNext.FlatStyle = FlatStyle.Flat
        Me.ButtonNext.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Me.ButtonNext.ForeColor = Color.White
        Me.ButtonNext.Location = New Point(380, 330)
        Me.ButtonNext.Name = "ButtonNext"
        Me.ButtonNext.Size = New Size(140, 45)
        Me.ButtonNext.TabIndex = 4
        Me.ButtonNext.Text = "Lanjut ▶"
        Me.ButtonNext.UseVisualStyleBackColor = False

        '
        ' Add header to main panel
        '
        Me.PanelMain.Controls.Add(Me.PanelHeader)

        '
        ' Form2
        '
        Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.FromArgb(CByte(245), CByte(248), CByte(252))
        Me.ClientSize = New Size(700, 480)
        Me.Controls.Add(Me.PanelMain)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "OccuPath - Pertanyaan"
        Me.PanelBox.ResumeLayout(False)
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelMain.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

End Class
