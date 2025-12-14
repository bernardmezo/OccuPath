<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUserManagement
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
        Panel1 = New Panel()
        lblTitle = New Label()
        btnLogout = New Button()
        Panel2 = New Panel()
        btnAddUser = New Button()
        btnRefresh = New Button()
        txtSearch = New TextBox()
        Label1 = New Label()
        lblTotalUsers = New Label()
        dgvUsers = New DataGridView()
        btnClose = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        Panel1.Controls.Add(lblTitle)
        Panel1.Controls.Add(btnLogout)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4, 3, 4, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1400, 92)
        Panel1.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(23, 23)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(233, 37)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Manajemen User"
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnLogout.Cursor = Cursors.Hand
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(1237, 23)
        btnLogout.Margin = New Padding(4, 3, 4, 3)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(140, 46)
        btnLogout.TabIndex = 1
        btnLogout.Text = "Keluar"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(btnAddUser)
        Panel2.Controls.Add(btnRefresh)
        Panel2.Controls.Add(txtSearch)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(lblTotalUsers)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 92)
        Panel2.Margin = New Padding(4, 3, 4, 3)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(23, 17, 23, 17)
        Panel2.Size = New Size(1400, 92)
        Panel2.TabIndex = 1
        ' 
        ' btnAddUser
        ' 
        btnAddUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddUser.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnAddUser.Cursor = Cursors.Hand
        btnAddUser.FlatAppearance.BorderSize = 0
        btnAddUser.FlatStyle = FlatStyle.Flat
        btnAddUser.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnAddUser.ForeColor = Color.White
        btnAddUser.Location = New Point(1053, 23)
        btnAddUser.Margin = New Padding(4, 3, 4, 3)
        btnAddUser.Name = "btnAddUser"
        btnAddUser.Size = New Size(187, 46)
        btnAddUser.TabIndex = 4
        btnAddUser.Text = "Tambah User"
        btnAddUser.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefresh.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnRefresh.Cursor = Cursors.Hand
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(1248, 23)
        btnRefresh.Margin = New Padding(4, 3, 4, 3)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(128, 46)
        btnRefresh.TabIndex = 3
        btnRefresh.Text = "Muat Ulang"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 11F)
        txtSearch.Location = New Point(128, 29)
        txtSearch.Margin = New Padding(4, 3, 4, 3)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(408, 27)
        txtSearch.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 11F)
        Label1.Location = New Point(23, 32)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(38, 20)
        Label1.TabIndex = 1
        Label1.Text = "Cari:"
        ' 
        ' lblTotalUsers
        ' 
        lblTotalUsers.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblTotalUsers.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblTotalUsers.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTotalUsers.Location = New Point(714, 32)
        lblTotalUsers.Margin = New Padding(4, 0, 4, 0)
        lblTotalUsers.Name = "lblTotalUsers"
        lblTotalUsers.Size = New Size(292, 27)
        lblTotalUsers.TabIndex = 0
        lblTotalUsers.Text = "Total User: 0"
        lblTotalUsers.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' dgvUsers
        ' 
        dgvUsers.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvUsers.BackgroundColor = Color.White
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsers.Location = New Point(23, 208)
        dgvUsers.Margin = New Padding(4, 3, 4, 3)
        dgvUsers.Name = "dgvUsers"
        dgvUsers.Size = New Size(1353, 519)
        dgvUsers.TabIndex = 2
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        btnClose.Cursor = Cursors.Hand
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1237, 750)
        btnClose.Margin = New Padding(4, 3, 4, 3)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(140, 46)
        btnClose.TabIndex = 3
        btnClose.Text = "Tutup"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' FormUserManagement
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        ClientSize = New Size(1400, 808)
        Controls.Add(btnClose)
        Controls.Add(dgvUsers)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Margin = New Padding(4, 3, 4, 3)
        Name = "FormUserManagement"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - User Management"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTotalUsers As Label
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnAddUser As Button
End Class
