<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProfile
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
        panelHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        panelMain = New Panel()
        groupProfile = New GroupBox()
        lblJoinDate = New Label()
        btnUpdateProfile = New Button()
        txtEmail = New TextBox()
        lblEmail = New Label()
        txtFullName = New TextBox()
        lblFullName = New Label()
        txtUsername = New TextBox()
        lblUsername = New Label()
        groupSecurity = New GroupBox()
        btnChangePassword = New Button()
        lblPasswordInfo = New Label()
        panelProfileData = New Panel()
        lblSemester = New Label()
        lblProgramStudi = New Label()
        lblNoProfile = New Label()
        btnClose = New Button()
        panelHeader.SuspendLayout()
        panelMain.SuspendLayout()
        groupProfile.SuspendLayout()
        groupSecurity.SuspendLayout()
        panelProfileData.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelHeader
        ' 
        panelHeader.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        panelHeader.Controls.Add(lblTitle)
        panelHeader.Controls.Add(lblSubtitle)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Location = New Point(0, 0)
        panelHeader.Name = "panelHeader"
        panelHeader.Size = New Size(700, 80)
        panelHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(20, 15)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(150, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Profil Saya"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 10.0F)
        lblSubtitle.ForeColor = Color.White
        lblSubtitle.Location = New Point(20, 50)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(250, 19)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Kelola informasi akun Anda"
        ' 
        ' panelMain
        ' 
        panelMain.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(247))
        panelMain.Controls.Add(groupProfile)
        panelMain.Controls.Add(groupSecurity)
        panelMain.Controls.Add(panelProfileData)
        panelMain.Controls.Add(lblNoProfile)
        panelMain.Controls.Add(btnClose)
        panelMain.Dock = DockStyle.Fill
        panelMain.Location = New Point(0, 80)
        panelMain.Name = "panelMain"
        panelMain.Padding = New Padding(30)
        panelMain.Size = New Size(700, 470)
        panelMain.TabIndex = 1
        ' 
        ' groupProfile
        ' 
        groupProfile.BackColor = Color.White
        groupProfile.Controls.Add(lblJoinDate)
        groupProfile.Controls.Add(btnUpdateProfile)
        groupProfile.Controls.Add(txtEmail)
        groupProfile.Controls.Add(lblEmail)
        groupProfile.Controls.Add(txtFullName)
        groupProfile.Controls.Add(lblFullName)
        groupProfile.Controls.Add(txtUsername)
        groupProfile.Controls.Add(lblUsername)
        groupProfile.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        groupProfile.Location = New Point(30, 20)
        groupProfile.Name = "groupProfile"
        groupProfile.Padding = New Padding(15)
        groupProfile.Size = New Size(640, 200)
        groupProfile.TabIndex = 0
        groupProfile.TabStop = False
        groupProfile.Text = "Informasi Akun"
        ' 
        ' lblJoinDate
        ' 
        lblJoinDate.AutoSize = True
        lblJoinDate.Font = New Font("Segoe UI", 9.0F, FontStyle.Italic)
        lblJoinDate.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblJoinDate.Location = New Point(20, 165)
        lblJoinDate.Name = "lblJoinDate"
        lblJoinDate.Size = New Size(150, 15)
        lblJoinDate.TabIndex = 7
        lblJoinDate.Text = "Bergabung sejak: -"
        ' 
        ' btnUpdateProfile
        ' 
        btnUpdateProfile.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnUpdateProfile.FlatAppearance.BorderSize = 0
        btnUpdateProfile.FlatStyle = FlatStyle.Flat
        btnUpdateProfile.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnUpdateProfile.ForeColor = Color.White
        btnUpdateProfile.Location = New Point(480, 150)
        btnUpdateProfile.Name = "btnUpdateProfile"
        btnUpdateProfile.Size = New Size(140, 35)
        btnUpdateProfile.TabIndex = 6
        btnUpdateProfile.Text = "Simpan"
        btnUpdateProfile.UseVisualStyleBackColor = False
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Segoe UI", 10.0F)
        txtEmail.Location = New Point(350, 115)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(270, 25)
        txtEmail.TabIndex = 5
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 10.0F)
        lblEmail.Location = New Point(350, 90)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(41, 19)
        lblEmail.TabIndex = 4
        lblEmail.Text = "Email"
        ' 
        ' txtFullName
        ' 
        txtFullName.Font = New Font("Segoe UI", 10.0F)
        txtFullName.Location = New Point(350, 50)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(270, 25)
        txtFullName.TabIndex = 3
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.Font = New Font("Segoe UI", 10.0F)
        lblFullName.Location = New Point(350, 25)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(97, 19)
        lblFullName.TabIndex = 2
        lblFullName.Text = "Nama Lengkap"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 10.0F)
        txtUsername.Location = New Point(20, 50)
        txtUsername.Name = "txtUsername"
        txtUsername.ReadOnly = True
        txtUsername.Size = New Size(270, 25)
        txtUsername.TabIndex = 1
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 10.0F)
        lblUsername.Location = New Point(20, 25)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(71, 19)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Username"
        ' 
        ' groupSecurity
        ' 
        groupSecurity.BackColor = Color.White
        groupSecurity.Controls.Add(btnChangePassword)
        groupSecurity.Controls.Add(lblPasswordInfo)
        groupSecurity.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        groupSecurity.Location = New Point(30, 235)
        groupSecurity.Name = "groupSecurity"
        groupSecurity.Padding = New Padding(15)
        groupSecurity.Size = New Size(640, 100)
        groupSecurity.TabIndex = 1
        groupSecurity.TabStop = False
        groupSecurity.Text = "Keamanan"
        ' 
        ' btnChangePassword
        ' 
        btnChangePassword.BackColor = Color.FromArgb(CByte(230), CByte(126), CByte(34))
        btnChangePassword.FlatAppearance.BorderSize = 0
        btnChangePassword.FlatStyle = FlatStyle.Flat
        btnChangePassword.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnChangePassword.ForeColor = Color.White
        btnChangePassword.Location = New Point(440, 35)
        btnChangePassword.Name = "btnChangePassword"
        btnChangePassword.Size = New Size(180, 40)
        btnChangePassword.TabIndex = 1
        btnChangePassword.Text = "Ganti Password"
        btnChangePassword.UseVisualStyleBackColor = False
        ' 
        ' lblPasswordInfo
        ' 
        lblPasswordInfo.AutoSize = True
        lblPasswordInfo.Font = New Font("Segoe UI", 10.0F)
        lblPasswordInfo.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblPasswordInfo.Location = New Point(20, 45)
        lblPasswordInfo.Name = "lblPasswordInfo"
        lblPasswordInfo.Size = New Size(350, 19)
        lblPasswordInfo.TabIndex = 0
        lblPasswordInfo.Text = "Password: ��������  (Klik tombol untuk mengganti)"
        ' 
        ' panelProfileData
        ' 
        panelProfileData.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        panelProfileData.BorderStyle = BorderStyle.FixedSingle
        panelProfileData.Controls.Add(lblSemester)
        panelProfileData.Controls.Add(lblProgramStudi)
        panelProfileData.Location = New Point(30, 350)
        panelProfileData.Name = "panelProfileData"
        panelProfileData.Padding = New Padding(15)
        panelProfileData.Size = New Size(640, 60)
        panelProfileData.TabIndex = 2
        panelProfileData.Visible = False
        ' 
        ' lblSemester
        ' 
        lblSemester.AutoSize = True
        lblSemester.Font = New Font("Segoe UI", 10.0F)
        lblSemester.Location = New Point(20, 30)
        lblSemester.Name = "lblSemester"
        lblSemester.Size = New Size(100, 19)
        lblSemester.TabIndex = 1
        lblSemester.Text = "Semester: -"
        ' 
        ' lblProgramStudi
        ' 
        lblProgramStudi.AutoSize = True
        lblProgramStudi.Font = New Font("Segoe UI", 10.0F)
        lblProgramStudi.Location = New Point(20, 5)
        lblProgramStudi.Name = "lblProgramStudi"
        lblProgramStudi.Size = New Size(120, 19)
        lblProgramStudi.TabIndex = 0
        lblProgramStudi.Text = "Program Studi: -"
        ' 
        ' lblNoProfile
        ' 
        lblNoProfile.AutoSize = True
        lblNoProfile.Font = New Font("Segoe UI", 10.0F, FontStyle.Italic)
        lblNoProfile.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblNoProfile.Location = New Point(35, 365)
        lblNoProfile.Name = "lblNoProfile"
        lblNoProfile.Size = New Size(380, 19)
        lblNoProfile.TabIndex = 3
        lblNoProfile.Text = "Data akademis akan muncul setelah mengisi assessment"
        lblNoProfile.Visible = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.White
        btnClose.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 10.0F)
        btnClose.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        btnClose.Location = New Point(570, 420)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 35)
        btnClose.TabIndex = 4
        btnClose.Text = "Tutup"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' FormProfile
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(700, 550)
        Controls.Add(panelMain)
        Controls.Add(panelHeader)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "FormProfile"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Profil Saya"
        panelHeader.ResumeLayout(False)
        panelHeader.PerformLayout()
        panelMain.ResumeLayout(False)
        panelMain.PerformLayout()
        groupProfile.ResumeLayout(False)
        groupProfile.PerformLayout()
        groupSecurity.ResumeLayout(False)
        groupSecurity.PerformLayout()
        panelProfileData.ResumeLayout(False)
        panelProfileData.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents panelMain As Panel
    Friend WithEvents groupProfile As GroupBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblFullName As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnUpdateProfile As Button
    Friend WithEvents lblJoinDate As Label
    Friend WithEvents groupSecurity As GroupBox
    Friend WithEvents lblPasswordInfo As Label
    Friend WithEvents btnChangePassword As Button
    Friend WithEvents panelProfileData As Panel
    Friend WithEvents lblProgramStudi As Label
    Friend WithEvents lblSemester As Label
    Friend WithEvents lblNoProfile As Label
    Friend WithEvents btnClose As Button
End Class
