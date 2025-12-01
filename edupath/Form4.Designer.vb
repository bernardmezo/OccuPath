<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
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
        Me.panelAccent = New System.Windows.Forms.Panel()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabLogin = New System.Windows.Forms.TabPage()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.linkForgotPassword = New System.Windows.Forms.LinkLabel()
        Me.txtLoginPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtLoginUsername = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblLoginTitle = New System.Windows.Forms.Label()
        Me.tabRegister = New System.Windows.Forms.TabPage()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.txtRegConfirmPassword = New System.Windows.Forms.TextBox()
        Me.lblRegConfirmPassword = New System.Windows.Forms.Label()
        Me.txtRegPassword = New System.Windows.Forms.TextBox()
        Me.lblRegPassword = New System.Windows.Forms.Label()
        Me.txtRegEmail = New System.Windows.Forms.TextBox()
        Me.lblRegEmail = New System.Windows.Forms.Label()
        Me.txtRegUsername = New System.Windows.Forms.TextBox()
        Me.lblRegUsername = New System.Windows.Forms.Label()
        Me.txtRegName = New System.Windows.Forms.TextBox()
        Me.lblRegName = New System.Windows.Forms.Label()
        Me.lblRegisterTitle = New System.Windows.Forms.Label()
        Me.tabControl.SuspendLayout()
        Me.tabLogin.SuspendLayout()
        Me.tabRegister.SuspendLayout()
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
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tabLogin)
        Me.tabControl.Controls.Add(Me.tabRegister)
        Me.tabControl.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.tabControl.Location = New System.Drawing.Point(40, 40)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(620, 520)
        Me.tabControl.TabIndex = 1
        '
        'tabLogin
        '
        Me.tabLogin.BackColor = System.Drawing.Color.White
        Me.tabLogin.Controls.Add(Me.btnLogin)
        Me.tabLogin.Controls.Add(Me.linkForgotPassword)
        Me.tabLogin.Controls.Add(Me.txtLoginPassword)
        Me.tabLogin.Controls.Add(Me.lblPassword)
        Me.tabLogin.Controls.Add(Me.txtLoginUsername)
        Me.tabLogin.Controls.Add(Me.lblUsername)
        Me.tabLogin.Controls.Add(Me.lblLoginTitle)
        Me.tabLogin.Location = New System.Drawing.Point(4, 26)
        Me.tabLogin.Name = "tabLogin"
        Me.tabLogin.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLogin.Size = New System.Drawing.Size(612, 490)
        Me.tabLogin.TabIndex = 0
        Me.tabLogin.Text = "Login"
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(40, 300)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(530, 45)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "Masuk"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'linkForgotPassword
        '
        Me.linkForgotPassword.AutoSize = True
        Me.linkForgotPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.linkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.linkForgotPassword.Location = New System.Drawing.Point(40, 250)
        Me.linkForgotPassword.Name = "linkForgotPassword"
        Me.linkForgotPassword.Size = New System.Drawing.Size(101, 15)
        Me.linkForgotPassword.TabIndex = 5
        Me.linkForgotPassword.TabStop = True
        Me.linkForgotPassword.Text = "Lupa password?"
        '
        'txtLoginPassword
        '
        Me.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoginPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtLoginPassword.Location = New System.Drawing.Point(40, 210)
        Me.txtLoginPassword.Name = "txtLoginPassword"
        Me.txtLoginPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtLoginPassword.Size = New System.Drawing.Size(530, 27)
        Me.txtLoginPassword.TabIndex = 4
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblPassword.Location = New System.Drawing.Point(40, 185)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(67, 19)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Password"
        '
        'txtLoginUsername
        '
        Me.txtLoginUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoginUsername.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtLoginUsername.Location = New System.Drawing.Point(40, 135)
        Me.txtLoginUsername.Name = "txtLoginUsername"
        Me.txtLoginUsername.Size = New System.Drawing.Size(530, 27)
        Me.txtLoginUsername.TabIndex = 2
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblUsername.Location = New System.Drawing.Point(40, 110)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(71, 19)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username"
        '
        'lblLoginTitle
        '
        Me.lblLoginTitle.AutoSize = True
        Me.lblLoginTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblLoginTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblLoginTitle.Location = New System.Drawing.Point(40, 40)
        Me.lblLoginTitle.Name = "lblLoginTitle"
        Me.lblLoginTitle.Size = New System.Drawing.Size(87, 37)
        Me.lblLoginTitle.TabIndex = 0
        Me.lblLoginTitle.Text = "Masuk"
        '
        'tabRegister
        '
        Me.tabRegister.BackColor = System.Drawing.Color.White
        Me.tabRegister.Controls.Add(Me.btnRegister)
        Me.tabRegister.Controls.Add(Me.txtRegConfirmPassword)
        Me.tabRegister.Controls.Add(Me.lblRegConfirmPassword)
        Me.tabRegister.Controls.Add(Me.txtRegPassword)
        Me.tabRegister.Controls.Add(Me.lblRegPassword)
        Me.tabRegister.Controls.Add(Me.txtRegEmail)
        Me.tabRegister.Controls.Add(Me.lblRegEmail)
        Me.tabRegister.Controls.Add(Me.txtRegUsername)
        Me.tabRegister.Controls.Add(Me.lblRegUsername)
        Me.tabRegister.Controls.Add(Me.txtRegName)
        Me.tabRegister.Controls.Add(Me.lblRegName)
        Me.tabRegister.Controls.Add(Me.lblRegisterTitle)
        Me.tabRegister.Location = New System.Drawing.Point(4, 26)
        Me.tabRegister.Name = "tabRegister"
        Me.tabRegister.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRegister.Size = New System.Drawing.Size(612, 490)
        Me.tabRegister.TabIndex = 1
        Me.tabRegister.Text = "Daftar"
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnRegister.FlatAppearance.BorderSize = 0
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegister.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnRegister.ForeColor = System.Drawing.Color.White
        Me.btnRegister.Location = New System.Drawing.Point(40, 395)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(530, 45)
        Me.btnRegister.TabIndex = 11
        Me.btnRegister.Text = "Daftar"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'txtRegConfirmPassword
        '
        Me.txtRegConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegConfirmPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRegConfirmPassword.Location = New System.Drawing.Point(40, 345)
        Me.txtRegConfirmPassword.Name = "txtRegConfirmPassword"
        Me.txtRegConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtRegConfirmPassword.Size = New System.Drawing.Size(530, 25)
        Me.txtRegConfirmPassword.TabIndex = 10
        '
        'lblRegConfirmPassword
        '
        Me.lblRegConfirmPassword.AutoSize = True
        Me.lblRegConfirmPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblRegConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblRegConfirmPassword.Location = New System.Drawing.Point(40, 325)
        Me.lblRegConfirmPassword.Name = "lblRegConfirmPassword"
        Me.lblRegConfirmPassword.Size = New System.Drawing.Size(116, 15)
        Me.lblRegConfirmPassword.TabIndex = 9
        Me.lblRegConfirmPassword.Text = "Konfirmasi Password"
        '
        'txtRegPassword
        '
        Me.txtRegPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRegPassword.Location = New System.Drawing.Point(40, 285)
        Me.txtRegPassword.Name = "txtRegPassword"
        Me.txtRegPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtRegPassword.Size = New System.Drawing.Size(530, 25)
        Me.txtRegPassword.TabIndex = 8
        '
        'lblRegPassword
        '
        Me.lblRegPassword.AutoSize = True
        Me.lblRegPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblRegPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblRegPassword.Location = New System.Drawing.Point(40, 265)
        Me.lblRegPassword.Name = "lblRegPassword"
        Me.lblRegPassword.Size = New System.Drawing.Size(57, 15)
        Me.lblRegPassword.TabIndex = 7
        Me.lblRegPassword.Text = "Password"
        '
        'txtRegEmail
        '
        Me.txtRegEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegEmail.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRegEmail.Location = New System.Drawing.Point(40, 225)
        Me.txtRegEmail.Name = "txtRegEmail"
        Me.txtRegEmail.Size = New System.Drawing.Size(530, 25)
        Me.txtRegEmail.TabIndex = 6
        '
        'lblRegEmail
        '
        Me.lblRegEmail.AutoSize = True
        Me.lblRegEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblRegEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblRegEmail.Location = New System.Drawing.Point(40, 205)
        Me.lblRegEmail.Name = "lblRegEmail"
        Me.lblRegEmail.Size = New System.Drawing.Size(36, 15)
        Me.lblRegEmail.TabIndex = 5
        Me.lblRegEmail.Text = "Email"
        '
        'txtRegUsername
        '
        Me.txtRegUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRegUsername.Location = New System.Drawing.Point(40, 165)
        Me.txtRegUsername.Name = "txtRegUsername"
        Me.txtRegUsername.Size = New System.Drawing.Size(530, 25)
        Me.txtRegUsername.TabIndex = 4
        '
        'lblRegUsername
        '
        Me.lblRegUsername.AutoSize = True
        Me.lblRegUsername.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblRegUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblRegUsername.Location = New System.Drawing.Point(40, 145)
        Me.lblRegUsername.Name = "lblRegUsername"
        Me.lblRegUsername.Size = New System.Drawing.Size(60, 15)
        Me.lblRegUsername.TabIndex = 3
        Me.lblRegUsername.Text = "Username"
        '
        'txtRegName
        '
        Me.txtRegName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtRegName.Location = New System.Drawing.Point(40, 105)
        Me.txtRegName.Name = "txtRegName"
        Me.txtRegName.Size = New System.Drawing.Size(530, 25)
        Me.txtRegName.TabIndex = 2
        '
        'lblRegName
        '
        Me.lblRegName.AutoSize = True
        Me.lblRegName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblRegName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblRegName.Location = New System.Drawing.Point(40, 85)
        Me.lblRegName.Name = "lblRegName"
        Me.lblRegName.Size = New System.Drawing.Size(85, 15)
        Me.lblRegName.TabIndex = 1
        Me.lblRegName.Text = "Nama Lengkap"
        '
        'lblRegisterTitle
        '
        Me.lblRegisterTitle.AutoSize = True
        Me.lblRegisterTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblRegisterTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblRegisterTitle.Location = New System.Drawing.Point(40, 30)
        Me.lblRegisterTitle.Name = "lblRegisterTitle"
        Me.lblRegisterTitle.Size = New System.Drawing.Size(123, 37)
        Me.lblRegisterTitle.TabIndex = 0
        Me.lblRegisterTitle.Text = "Buat Akun"
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(700, 600)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.panelAccent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OccuPath - Login"
        Me.tabControl.ResumeLayout(False)
        Me.tabLogin.ResumeLayout(False)
        Me.tabLogin.PerformLayout()
        Me.tabRegister.ResumeLayout(False)
        Me.tabRegister.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelAccent As Panel
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabLogin As TabPage
    Friend WithEvents tabRegister As TabPage
    Friend WithEvents lblLoginTitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtLoginUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtLoginPassword As TextBox
    Friend WithEvents linkForgotPassword As LinkLabel
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblRegisterTitle As Label
    Friend WithEvents lblRegName As Label
    Friend WithEvents txtRegName As TextBox
    Friend WithEvents lblRegUsername As Label
    Friend WithEvents txtRegUsername As TextBox
    Friend WithEvents lblRegEmail As Label
    Friend WithEvents txtRegEmail As TextBox
    Friend WithEvents lblRegPassword As Label
    Friend WithEvents txtRegPassword As TextBox
    Friend WithEvents lblRegConfirmPassword As Label
    Friend WithEvents txtRegConfirmPassword As TextBox
    Friend WithEvents btnRegister As Button
End Class
