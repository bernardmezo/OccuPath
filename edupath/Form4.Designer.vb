<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents panelMain As Panel
    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabLogin As TabPage
    Friend WithEvents tabRegister As TabPage

    ' Login controls
    Friend WithEvents lblLoginUser As Label
    Friend WithEvents txtLoginUsername As TextBox
    Friend WithEvents lblLoginPass As Label
    Friend WithEvents txtLoginPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents linkForgotPassword As LinkLabel

    ' Register controls
    Friend WithEvents lblRegName As Label
    Friend WithEvents txtRegName As TextBox
    Friend WithEvents lblRegUser As Label
    Friend WithEvents txtRegUsername As TextBox
    Friend WithEvents lblRegEmail As Label
    Friend WithEvents txtRegEmail As TextBox
    Friend WithEvents lblRegPass As Label
    Friend WithEvents txtRegPassword As TextBox
    Friend WithEvents lblRegConfirm As Label
    Friend WithEvents txtRegConfirmPassword As TextBox
    Friend WithEvents btnRegister As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        panelMain = New Panel()
        panelHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        tabControl = New TabControl()
        tabLogin = New TabPage()
        lblLoginUser = New Label()
        txtLoginUsername = New TextBox()
        lblLoginPass = New Label()
        txtLoginPassword = New TextBox()
        btnLogin = New Button()
        linkForgotPassword = New LinkLabel()
        tabRegister = New TabPage()
        lblRegName = New Label()
        txtRegName = New TextBox()
        lblRegUser = New Label()
        txtRegUsername = New TextBox()
        lblRegEmail = New Label()
        txtRegEmail = New TextBox()
        lblRegPass = New Label()
        txtRegPassword = New TextBox()
        lblRegConfirm = New Label()
        txtRegConfirmPassword = New TextBox()
        btnRegister = New Button()

        panelMain.SuspendLayout()
        panelHeader.SuspendLayout()
        tabControl.SuspendLayout()
        tabLogin.SuspendLayout()
        tabRegister.SuspendLayout()
        SuspendLayout()

        ' 
        ' panelMain
        ' 
        panelMain.BackColor = Color.White
        panelMain.Controls.Add(tabControl)
        panelMain.Controls.Add(panelHeader)
        panelMain.Location = New Point(30, 20)
        panelMain.Name = "panelMain"
        panelMain.Size = New Size(540, 610)
        panelMain.TabIndex = 0

        ' 
        ' panelHeader
        ' 
        panelHeader.BackColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        panelHeader.Controls.Add(lblTitle)
        panelHeader.Controls.Add(lblSubtitle)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Location = New Point(0, 0)
        panelHeader.Name = "panelHeader"
        panelHeader.Size = New Size(540, 100)
        panelHeader.TabIndex = 0

        ' 
        ' lblTitle
        ' 
        lblTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(0, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(540, 45)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Selamat Datang!"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter

        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 11.0F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(230), CByte(240), CByte(255))
        lblSubtitle.Location = New Point(0, 65)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(540, 25)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Masuk atau Daftar untuk memulai tes"
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter

        ' 
        ' tabControl
        ' 
        tabControl.Controls.Add(tabLogin)
        tabControl.Controls.Add(tabRegister)
        tabControl.Font = New Font("Segoe UI", 11.0F)
        tabControl.Location = New Point(30, 120)
        tabControl.Name = "tabControl"
        tabControl.SelectedIndex = 0
        tabControl.Size = New Size(480, 460)
        tabControl.TabIndex = 1

        ' 
        ' tabLogin
        ' 
        tabLogin.BackColor = Color.White
        tabLogin.Controls.Add(lblLoginUser)
        tabLogin.Controls.Add(txtLoginUsername)
        tabLogin.Controls.Add(lblLoginPass)
        tabLogin.Controls.Add(txtLoginPassword)
        tabLogin.Controls.Add(btnLogin)
        tabLogin.Controls.Add(linkForgotPassword)
        tabLogin.Location = New Point(4, 29)
        tabLogin.Name = "tabLogin"
        tabLogin.Padding = New Padding(3)
        tabLogin.Size = New Size(472, 427)
        tabLogin.TabIndex = 0
        tabLogin.Text = "Login"

        ' 
        ' lblLoginUser
        ' 
        lblLoginUser.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblLoginUser.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblLoginUser.Location = New Point(60, 50)
        lblLoginUser.Name = "lblLoginUser"
        lblLoginUser.Size = New Size(350, 25)
        lblLoginUser.TabIndex = 0
        lblLoginUser.Text = "Username"

        ' 
        ' txtLoginUsername
        ' 
        txtLoginUsername.BorderStyle = BorderStyle.FixedSingle
        txtLoginUsername.Font = New Font("Segoe UI", 12.0F)
        txtLoginUsername.Location = New Point(60, 80)
        txtLoginUsername.Name = "txtLoginUsername"
        txtLoginUsername.Size = New Size(350, 29)
        txtLoginUsername.TabIndex = 1

        ' 
        ' lblLoginPass
        ' 
        lblLoginPass.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblLoginPass.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblLoginPass.Location = New Point(60, 135)
        lblLoginPass.Name = "lblLoginPass"
        lblLoginPass.Size = New Size(350, 25)
        lblLoginPass.TabIndex = 2
        lblLoginPass.Text = "Password"

        ' 
        ' txtLoginPassword
        ' 
        txtLoginPassword.BorderStyle = BorderStyle.FixedSingle
        txtLoginPassword.Font = New Font("Segoe UI", 12.0F)
        txtLoginPassword.Location = New Point(60, 165)
        txtLoginPassword.Name = "txtLoginPassword"
        txtLoginPassword.PasswordChar = "●"c
        txtLoginPassword.Size = New Size(350, 29)
        txtLoginPassword.TabIndex = 3

        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(35), CByte(105), CByte(190))
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(60, 240)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(350, 50)
        btnLogin.TabIndex = 4
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False

        ' 
        ' linkForgotPassword
        ' 
        linkForgotPassword.Font = New Font("Segoe UI", 9.5F)
        linkForgotPassword.LinkColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        linkForgotPassword.Location = New Point(60, 310)
        linkForgotPassword.Name = "linkForgotPassword"
        linkForgotPassword.Size = New Size(350, 25)
        linkForgotPassword.TabIndex = 5
        linkForgotPassword.TabStop = True
        linkForgotPassword.Text = "Lupa Password?"
        linkForgotPassword.TextAlign = ContentAlignment.MiddleCenter

        ' 
        ' tabRegister
        ' 
        tabRegister.BackColor = Color.White
        tabRegister.Controls.Add(lblRegName)
        tabRegister.Controls.Add(txtRegName)
        tabRegister.Controls.Add(lblRegUser)
        tabRegister.Controls.Add(txtRegUsername)
        tabRegister.Controls.Add(lblRegEmail)
        tabRegister.Controls.Add(txtRegEmail)
        tabRegister.Controls.Add(lblRegPass)
        tabRegister.Controls.Add(txtRegPassword)
        tabRegister.Controls.Add(lblRegConfirm)
        tabRegister.Controls.Add(txtRegConfirmPassword)
        tabRegister.Controls.Add(btnRegister)
        tabRegister.Location = New Point(4, 29)
        tabRegister.Name = "tabRegister"
        tabRegister.Padding = New Padding(3)
        tabRegister.Size = New Size(472, 427)
        tabRegister.TabIndex = 1
        tabRegister.Text = "Register"

        ' 
        ' lblRegName
        ' 
        lblRegName.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblRegName.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblRegName.Location = New Point(60, 20)
        lblRegName.Name = "lblRegName"
        lblRegName.Size = New Size(350, 22)
        lblRegName.TabIndex = 0
        lblRegName.Text = "Nama Lengkap"

        ' 
        ' txtRegName
        ' 
        txtRegName.BorderStyle = BorderStyle.FixedSingle
        txtRegName.Font = New Font("Segoe UI", 11.0F)
        txtRegName.Location = New Point(60, 45)
        txtRegName.Name = "txtRegName"
        txtRegName.Size = New Size(350, 27)
        txtRegName.TabIndex = 1

        ' 
        ' lblRegUser
        ' 
        lblRegUser.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblRegUser.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblRegUser.Location = New Point(60, 85)
        lblRegUser.Name = "lblRegUser"
        lblRegUser.Size = New Size(350, 22)
        lblRegUser.TabIndex = 2
        lblRegUser.Text = "Username"

        ' 
        ' txtRegUsername
        ' 
        txtRegUsername.BorderStyle = BorderStyle.FixedSingle
        txtRegUsername.Font = New Font("Segoe UI", 11.0F)
        txtRegUsername.Location = New Point(60, 110)
        txtRegUsername.Name = "txtRegUsername"
        txtRegUsername.Size = New Size(350, 27)
        txtRegUsername.TabIndex = 3

        ' 
        ' lblRegEmail
        ' 
        lblRegEmail.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblRegEmail.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblRegEmail.Location = New Point(60, 150)
        lblRegEmail.Name = "lblRegEmail"
        lblRegEmail.Size = New Size(350, 22)
        lblRegEmail.TabIndex = 4
        lblRegEmail.Text = "Email"

        ' 
        ' txtRegEmail
        ' 
        txtRegEmail.BorderStyle = BorderStyle.FixedSingle
        txtRegEmail.Font = New Font("Segoe UI", 11.0F)
        txtRegEmail.Location = New Point(60, 175)
        txtRegEmail.Name = "txtRegEmail"
        txtRegEmail.Size = New Size(350, 27)
        txtRegEmail.TabIndex = 5

        ' 
        ' lblRegPass
        ' 
        lblRegPass.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblRegPass.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblRegPass.Location = New Point(60, 215)
        lblRegPass.Name = "lblRegPass"
        lblRegPass.Size = New Size(350, 22)
        lblRegPass.TabIndex = 6
        lblRegPass.Text = "Password"

        ' 
        ' txtRegPassword
        ' 
        txtRegPassword.BorderStyle = BorderStyle.FixedSingle
        txtRegPassword.Font = New Font("Segoe UI", 11.0F)
        txtRegPassword.Location = New Point(60, 240)
        txtRegPassword.Name = "txtRegPassword"
        txtRegPassword.PasswordChar = "●"c
        txtRegPassword.Size = New Size(350, 27)
        txtRegPassword.TabIndex = 7

        ' 
        ' lblRegConfirm
        ' 
        lblRegConfirm.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblRegConfirm.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        lblRegConfirm.Location = New Point(60, 280)
        lblRegConfirm.Name = "lblRegConfirm"
        lblRegConfirm.Size = New Size(350, 22)
        lblRegConfirm.TabIndex = 8
        lblRegConfirm.Text = "Konfirmasi Password"

        ' 
        ' txtRegConfirmPassword
        ' 
        txtRegConfirmPassword.BorderStyle = BorderStyle.FixedSingle
        txtRegConfirmPassword.Font = New Font("Segoe UI", 11.0F)
        txtRegConfirmPassword.Location = New Point(60, 305)
        txtRegConfirmPassword.Name = "txtRegConfirmPassword"
        txtRegConfirmPassword.PasswordChar = "●"c
        txtRegConfirmPassword.Size = New Size(350, 27)
        txtRegConfirmPassword.TabIndex = 9

        ' 
        ' btnRegister
        ' 
        btnRegister.BackColor = Color.FromArgb(CByte(45), CByte(125), CByte(210))
        btnRegister.FlatAppearance.BorderSize = 0
        btnRegister.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(35), CByte(105), CByte(190))
        btnRegister.FlatStyle = FlatStyle.Flat
        btnRegister.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        btnRegister.ForeColor = Color.White
        btnRegister.Location = New Point(60, 355)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(350, 50)
        btnRegister.TabIndex = 10
        btnRegister.Text = "Daftar"
        btnRegister.UseVisualStyleBackColor = False

        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(248), CByte(252))
        ClientSize = New Size(600, 660)
        Controls.Add(panelMain)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form4"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Login/Register"
        panelMain.ResumeLayout(False)
        panelHeader.ResumeLayout(False)
        tabControl.ResumeLayout(False)
        tabLogin.ResumeLayout(False)
        tabLogin.PerformLayout()
        tabRegister.ResumeLayout(False)
        tabRegister.PerformLayout()
        ResumeLayout(False)
    End Sub

End Class
