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
        panelAccent = New Panel()
        tabControl = New TabControl()
        tabLogin = New TabPage()
        btnLogin = New Button()
        linkForgotPassword = New LinkLabel()
        txtLoginPassword = New TextBox()
        lblPassword = New Label()
        txtLoginUsername = New TextBox()
        lblUsername = New Label()
        lblLoginTitle = New Label()
        tabRegister = New TabPage()
        btnRegister = New Button()
        txtRegConfirmPassword = New TextBox()
        lblRegConfirmPassword = New Label()
        txtRegPassword = New TextBox()
        lblRegPassword = New Label()
        txtRegEmail = New TextBox()
        lblRegEmail = New Label()
        txtRegUsername = New TextBox()
        lblRegUsername = New Label()
        txtRegName = New TextBox()
        lblRegName = New Label()
        lblRegisterTitle = New Label()
        tabControl.SuspendLayout()
        tabLogin.SuspendLayout()
        tabRegister.SuspendLayout()
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
        ' tabControl
        ' 
        tabControl.Controls.Add(tabLogin)
        tabControl.Controls.Add(tabRegister)
        tabControl.Font = New Font("Segoe UI", 10F)
        tabControl.Location = New Point(40, 40)
        tabControl.Name = "tabControl"
        tabControl.SelectedIndex = 0
        tabControl.Size = New Size(620, 520)
        tabControl.TabIndex = 1
        ' 
        ' tabLogin
        ' 
        tabLogin.BackColor = Color.White
        tabLogin.Controls.Add(btnLogin)
        tabLogin.Controls.Add(linkForgotPassword)
        tabLogin.Controls.Add(txtLoginPassword)
        tabLogin.Controls.Add(lblPassword)
        tabLogin.Controls.Add(txtLoginUsername)
        tabLogin.Controls.Add(lblUsername)
        tabLogin.Controls.Add(lblLoginTitle)
        tabLogin.Location = New Point(4, 26)
        tabLogin.Name = "tabLogin"
        tabLogin.Padding = New Padding(3)
        tabLogin.Size = New Size(612, 490)
        tabLogin.TabIndex = 0
        tabLogin.Text = "Login"
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 11F)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(40, 300)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(530, 45)
        btnLogin.TabIndex = 6
        btnLogin.Text = "Masuk"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' linkForgotPassword
        ' 
        linkForgotPassword.AutoSize = True
        linkForgotPassword.Font = New Font("Segoe UI", 9F)
        linkForgotPassword.LinkColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        linkForgotPassword.Location = New Point(40, 250)
        linkForgotPassword.Name = "linkForgotPassword"
        linkForgotPassword.Size = New Size(91, 15)
        linkForgotPassword.TabIndex = 5
        linkForgotPassword.TabStop = True
        linkForgotPassword.Text = "Lupa password?"
        ' 
        ' txtLoginPassword
        ' 
        txtLoginPassword.BorderStyle = BorderStyle.FixedSingle
        txtLoginPassword.Font = New Font("Segoe UI", 11F)
        txtLoginPassword.Location = New Point(40, 210)
        txtLoginPassword.Name = "txtLoginPassword"
        txtLoginPassword.PasswordChar = "•"c
        txtLoginPassword.Size = New Size(530, 27)
        txtLoginPassword.TabIndex = 4
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 10F)
        lblPassword.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblPassword.Location = New Point(40, 185)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(67, 19)
        lblPassword.TabIndex = 3
        lblPassword.Text = "Password"
        ' 
        ' txtLoginUsername
        ' 
        txtLoginUsername.BorderStyle = BorderStyle.FixedSingle
        txtLoginUsername.Font = New Font("Segoe UI", 11F)
        txtLoginUsername.Location = New Point(40, 135)
        txtLoginUsername.Name = "txtLoginUsername"
        txtLoginUsername.Size = New Size(530, 27)
        txtLoginUsername.TabIndex = 2
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 10F)
        lblUsername.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblUsername.Location = New Point(40, 110)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(71, 19)
        lblUsername.TabIndex = 1
        lblUsername.Text = "Username"
        ' 
        ' lblLoginTitle
        ' 
        lblLoginTitle.AutoSize = True
        lblLoginTitle.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        lblLoginTitle.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblLoginTitle.Location = New Point(40, 40)
        lblLoginTitle.Name = "lblLoginTitle"
        lblLoginTitle.Size = New Size(101, 37)
        lblLoginTitle.TabIndex = 0
        lblLoginTitle.Text = "Masuk"
        ' 
        ' tabRegister
        ' 
        tabRegister.BackColor = Color.White
        tabRegister.Controls.Add(btnRegister)
        tabRegister.Controls.Add(txtRegConfirmPassword)
        tabRegister.Controls.Add(lblRegConfirmPassword)
        tabRegister.Controls.Add(txtRegPassword)
        tabRegister.Controls.Add(lblRegPassword)
        tabRegister.Controls.Add(txtRegEmail)
        tabRegister.Controls.Add(lblRegEmail)
        tabRegister.Controls.Add(txtRegUsername)
        tabRegister.Controls.Add(lblRegUsername)
        tabRegister.Controls.Add(txtRegName)
        tabRegister.Controls.Add(lblRegName)
        tabRegister.Controls.Add(lblRegisterTitle)
        tabRegister.Location = New Point(4, 26)
        tabRegister.Name = "tabRegister"
        tabRegister.Padding = New Padding(3)
        tabRegister.Size = New Size(612, 490)
        tabRegister.TabIndex = 1
        tabRegister.Text = "Daftar"
        ' 
        ' btnRegister
        ' 
        btnRegister.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnRegister.FlatAppearance.BorderSize = 0
        btnRegister.FlatStyle = FlatStyle.Flat
        btnRegister.Font = New Font("Segoe UI", 11F)
        btnRegister.ForeColor = Color.White
        btnRegister.Location = New Point(40, 395)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(530, 45)
        btnRegister.TabIndex = 11
        btnRegister.Text = "Daftar"
        btnRegister.UseVisualStyleBackColor = False
        ' 
        ' txtRegConfirmPassword
        ' 
        txtRegConfirmPassword.BorderStyle = BorderStyle.FixedSingle
        txtRegConfirmPassword.Font = New Font("Segoe UI", 10F)
        txtRegConfirmPassword.Location = New Point(40, 345)
        txtRegConfirmPassword.Name = "txtRegConfirmPassword"
        txtRegConfirmPassword.PasswordChar = "•"c
        txtRegConfirmPassword.Size = New Size(530, 25)
        txtRegConfirmPassword.TabIndex = 10
        ' 
        ' lblRegConfirmPassword
        ' 
        lblRegConfirmPassword.AutoSize = True
        lblRegConfirmPassword.Font = New Font("Segoe UI", 9F)
        lblRegConfirmPassword.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblRegConfirmPassword.Location = New Point(40, 325)
        lblRegConfirmPassword.Name = "lblRegConfirmPassword"
        lblRegConfirmPassword.Size = New Size(117, 15)
        lblRegConfirmPassword.TabIndex = 9
        lblRegConfirmPassword.Text = "Konfirmasi Password"
        ' 
        ' txtRegPassword
        ' 
        txtRegPassword.BorderStyle = BorderStyle.FixedSingle
        txtRegPassword.Font = New Font("Segoe UI", 10F)
        txtRegPassword.Location = New Point(40, 285)
        txtRegPassword.Name = "txtRegPassword"
        txtRegPassword.PasswordChar = "•"c
        txtRegPassword.Size = New Size(530, 25)
        txtRegPassword.TabIndex = 8
        ' 
        ' lblRegPassword
        ' 
        lblRegPassword.AutoSize = True
        lblRegPassword.Font = New Font("Segoe UI", 9F)
        lblRegPassword.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblRegPassword.Location = New Point(40, 265)
        lblRegPassword.Name = "lblRegPassword"
        lblRegPassword.Size = New Size(57, 15)
        lblRegPassword.TabIndex = 7
        lblRegPassword.Text = "Password"
        ' 
        ' txtRegEmail
        ' 
        txtRegEmail.BorderStyle = BorderStyle.FixedSingle
        txtRegEmail.Font = New Font("Segoe UI", 10F)
        txtRegEmail.Location = New Point(40, 225)
        txtRegEmail.Name = "txtRegEmail"
        txtRegEmail.Size = New Size(530, 25)
        txtRegEmail.TabIndex = 6
        ' 
        ' lblRegEmail
        ' 
        lblRegEmail.AutoSize = True
        lblRegEmail.Font = New Font("Segoe UI", 9F)
        lblRegEmail.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblRegEmail.Location = New Point(40, 205)
        lblRegEmail.Name = "lblRegEmail"
        lblRegEmail.Size = New Size(36, 15)
        lblRegEmail.TabIndex = 5
        lblRegEmail.Text = "Email"
        ' 
        ' txtRegUsername
        ' 
        txtRegUsername.BorderStyle = BorderStyle.FixedSingle
        txtRegUsername.Font = New Font("Segoe UI", 10F)
        txtRegUsername.Location = New Point(40, 165)
        txtRegUsername.Name = "txtRegUsername"
        txtRegUsername.Size = New Size(530, 25)
        txtRegUsername.TabIndex = 4
        ' 
        ' lblRegUsername
        ' 
        lblRegUsername.AutoSize = True
        lblRegUsername.Font = New Font("Segoe UI", 9F)
        lblRegUsername.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblRegUsername.Location = New Point(40, 145)
        lblRegUsername.Name = "lblRegUsername"
        lblRegUsername.Size = New Size(60, 15)
        lblRegUsername.TabIndex = 3
        lblRegUsername.Text = "Username"
        ' 
        ' txtRegName
        ' 
        txtRegName.BorderStyle = BorderStyle.FixedSingle
        txtRegName.Font = New Font("Segoe UI", 10F)
        txtRegName.Location = New Point(40, 105)
        txtRegName.Name = "txtRegName"
        txtRegName.Size = New Size(530, 25)
        txtRegName.TabIndex = 2
        ' 
        ' lblRegName
        ' 
        lblRegName.AutoSize = True
        lblRegName.Font = New Font("Segoe UI", 9F)
        lblRegName.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblRegName.Location = New Point(40, 85)
        lblRegName.Name = "lblRegName"
        lblRegName.Size = New Size(87, 15)
        lblRegName.TabIndex = 1
        lblRegName.Text = "Nama Lengkap"
        ' 
        ' lblRegisterTitle
        ' 
        lblRegisterTitle.AutoSize = True
        lblRegisterTitle.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        lblRegisterTitle.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblRegisterTitle.Location = New Point(40, 30)
        lblRegisterTitle.Name = "lblRegisterTitle"
        lblRegisterTitle.Size = New Size(149, 37)
        lblRegisterTitle.TabIndex = 0
        lblRegisterTitle.Text = "Buat Akun"
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(247))
        ClientSize = New Size(700, 600)
        Controls.Add(tabControl)
        Controls.Add(panelAccent)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form4"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Login"
        tabControl.ResumeLayout(False)
        tabLogin.ResumeLayout(False)
        tabLogin.PerformLayout()
        tabRegister.ResumeLayout(False)
        tabRegister.PerformLayout()
        ResumeLayout(False)

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
