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
        Me.panelResults = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'panelResults
        '
        Me.panelResults.AutoScroll = True
        Me.panelResults.BackColor = System.Drawing.Color.White
        Me.panelResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelResults.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.panelResults.Location = New System.Drawing.Point(0, 0)
        Me.panelResults.Name = "panelResults"
        Me.panelResults.Padding = New System.Windows.Forms.Padding(20)
        Me.panelResults.Size = New System.Drawing.Size(800, 600)
        Me.panelResults.TabIndex = 0
        Me.panelResults.WrapContents = False
        '
        'FormResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.panelResults)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormResult"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hasil Analisis Profil Lulusan - OccuPath"
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents panelResults As FlowLayoutPanel
End Class
