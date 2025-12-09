<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTestDB
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.panelAccent = New Panel()
        Me.lblTitle = New Label()
        Me.txtResult = New TextBox()
        Me.btnClose = New Button()
        Me.btnRetry = New Button()
        Me.SuspendLayout()
        ' 
        ' panelAccent
        ' 
        Me.panelAccent.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        Me.panelAccent.Dock = DockStyle.Left
        Me.panelAccent.Location = New Point(0, 0)
        Me.panelAccent.Name = "panelAccent"
        Me.panelAccent.Size = New Size(5, 400)
        Me.panelAccent.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        Me.lblTitle.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        Me.lblTitle.Location = New Point(30, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New Size(250, 30)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "?? Database Connection Test"
        ' 
        ' txtResult
        ' 
        Me.txtResult.BackColor = Color.White
        Me.txtResult.BorderStyle = BorderStyle.FixedSingle
        Me.txtResult.Font = New Font("Consolas", 10.0F)
        Me.txtResult.Location = New Point(30, 70)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.ScrollBars = ScrollBars.Vertical
        Me.txtResult.Size = New Size(540, 250)
        Me.txtResult.TabIndex = 2
        ' 
        ' btnRetry
        ' 
        Me.btnRetry.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        Me.btnRetry.FlatAppearance.BorderSize = 0
        Me.btnRetry.FlatStyle = FlatStyle.Flat
        Me.btnRetry.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Me.btnRetry.ForeColor = Color.White
        Me.btnRetry.Location = New Point(30, 340)
        Me.btnRetry.Name = "btnRetry"
        Me.btnRetry.Size = New Size(120, 40)
        Me.btnRetry.TabIndex = 3
        Me.btnRetry.Text = "?? Test Lagi"
        Me.btnRetry.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        Me.btnClose.BackColor = Color.White
        Me.btnClose.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        Me.btnClose.FlatStyle = FlatStyle.Flat
        Me.btnClose.Font = New Font("Segoe UI", 10.0F)
        Me.btnClose.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        Me.btnClose.Location = New Point(170, 340)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New Size(100, 40)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Tutup"
        Me.btnClose.UseVisualStyleBackColor = False
        ' 
        ' FormTestDB
        ' 
        Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.White
        Me.ClientSize = New Size(600, 400)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnRetry)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.panelAccent)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormTestDB"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "OccuPath - DB Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents panelAccent As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtResult As TextBox
    Friend WithEvents btnRetry As Button
    Friend WithEvents btnClose As Button
End Class
