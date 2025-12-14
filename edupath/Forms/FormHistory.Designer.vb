<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormHistory
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
        lblTotalAssessments = New Label()
        panelMain = New Panel()
        dgvHistory = New DataGridView()
        colAssessmentId = New DataGridViewTextBoxColumn()
        colDate = New DataGridViewTextBoxColumn()
        colRank = New DataGridViewTextBoxColumn()
        colProfile = New DataGridViewTextBoxColumn()
        colCF = New DataGridViewTextBoxColumn()
        lblNoData = New Label()
        panelActions = New Panel()
        btnClose = New Button()
        btnRefresh = New Button()
        btnViewDetail = New Button()
        panelHeader.SuspendLayout()
        panelMain.SuspendLayout()
        CType(dgvHistory, ComponentModel.ISupportInitialize).BeginInit()
        panelActions.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelHeader
        ' 
        panelHeader.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        panelHeader.Controls.Add(lblTitle)
        panelHeader.Controls.Add(lblSubtitle)
        panelHeader.Controls.Add(lblTotalAssessments)
        panelHeader.Dock = DockStyle.Top
        panelHeader.Location = New Point(0, 0)
        panelHeader.Name = "panelHeader"
        panelHeader.Size = New Size(900, 90)
        panelHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(20, 15)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(210, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Riwayat Tes"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 10.0F)
        lblSubtitle.ForeColor = Color.White
        lblSubtitle.Location = New Point(20, 50)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(280, 19)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Lihat hasil assessment yang pernah Anda ikuti"
        ' 
        ' lblTotalAssessments
        ' 
        lblTotalAssessments.AutoSize = True
        lblTotalAssessments.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblTotalAssessments.ForeColor = Color.White
        lblTotalAssessments.Location = New Point(750, 35)
        lblTotalAssessments.Name = "lblTotalAssessments"
        lblTotalAssessments.Size = New Size(130, 21)
        lblTotalAssessments.TabIndex = 2
        lblTotalAssessments.Text = "Total Assessment: 0"
        ' 
        ' panelMain
        ' 
        panelMain.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(247))
        panelMain.Controls.Add(dgvHistory)
        panelMain.Controls.Add(lblNoData)
        panelMain.Controls.Add(panelActions)
        panelMain.Dock = DockStyle.Fill
        panelMain.Location = New Point(0, 90)
        panelMain.Name = "panelMain"
        panelMain.Padding = New Padding(20)
        panelMain.Size = New Size(900, 510)
        panelMain.TabIndex = 1
        ' 
        ' dgvHistory
        ' 
        dgvHistory.AllowUserToAddRows = False
        dgvHistory.AllowUserToDeleteRows = False
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvHistory.BackgroundColor = Color.White
        dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvHistory.Columns.AddRange(New DataGridViewColumn() {colAssessmentId, colDate, colRank, colProfile, colCF})
        dgvHistory.Dock = DockStyle.Fill
        dgvHistory.Location = New Point(20, 20)
        dgvHistory.MultiSelect = False
        dgvHistory.Name = "dgvHistory"
        dgvHistory.ReadOnly = True
        dgvHistory.RowHeadersVisible = False
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHistory.Size = New Size(860, 410)
        dgvHistory.TabIndex = 0
        ' 
        ' colAssessmentId
        ' 
        colAssessmentId.HeaderText = "ID"
        colAssessmentId.Name = "colAssessmentId"
        colAssessmentId.ReadOnly = True
        colAssessmentId.Visible = False
        ' 
        ' colDate
        ' 
        colDate.FillWeight = 30.0F
        colDate.HeaderText = "Tanggal"
        colDate.Name = "colDate"
        colDate.ReadOnly = True
        ' 
        ' colRank
        ' 
        colRank.FillWeight = 10.0F
        colRank.HeaderText = "Rank"
        colRank.Name = "colRank"
        colRank.ReadOnly = True
        ' 
        ' colProfile
        ' 
        colProfile.FillWeight = 40.0F
        colProfile.HeaderText = "Profil Lulusan"
        colProfile.Name = "colProfile"
        colProfile.ReadOnly = True
        ' 
        ' colCF
        ' 
        colCF.FillWeight = 20.0F
        colCF.HeaderText = "CF Percentage"
        colCF.Name = "colCF"
        colCF.ReadOnly = True
        ' 
        ' lblNoData
        ' 
        lblNoData.AutoSize = True
        lblNoData.Font = New Font("Segoe UI", 12.0F, FontStyle.Italic)
        lblNoData.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblNoData.Location = New Point(300, 200)
        lblNoData.Name = "lblNoData"
        lblNoData.Size = New Size(300, 21)
        lblNoData.TabIndex = 1
        lblNoData.Text = "Belum ada riwayat assessment"
        lblNoData.Visible = False
        ' 
        ' panelActions
        ' 
        panelActions.Controls.Add(btnClose)
        panelActions.Controls.Add(btnRefresh)
        panelActions.Controls.Add(btnViewDetail)
        panelActions.Dock = DockStyle.Bottom
        panelActions.Location = New Point(20, 430)
        panelActions.Name = "panelActions"
        panelActions.Size = New Size(860, 60)
        panelActions.TabIndex = 2
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnClose.BackColor = Color.White
        btnClose.FlatAppearance.BorderColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 10.0F)
        btnClose.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        btnClose.Location = New Point(750, 10)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 40)
        btnClose.TabIndex = 2
        btnClose.Text = "Tutup"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnRefresh.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(630, 10)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(110, 40)
        btnRefresh.TabIndex = 1
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnViewDetail
        ' 
        btnViewDetail.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnViewDetail.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnViewDetail.FlatAppearance.BorderSize = 0
        btnViewDetail.FlatStyle = FlatStyle.Flat
        btnViewDetail.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnViewDetail.ForeColor = Color.White
        btnViewDetail.Location = New Point(10, 10)
        btnViewDetail.Name = "btnViewDetail"
        btnViewDetail.Size = New Size(150, 40)
        btnViewDetail.TabIndex = 0
        btnViewDetail.Text = "Lihat Detail"
        btnViewDetail.UseVisualStyleBackColor = False
        ' 
        ' FormHistory
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(900, 600)
        Controls.Add(panelMain)
        Controls.Add(panelHeader)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "FormHistory"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OccuPath - Riwayat Assessment"
        panelHeader.ResumeLayout(False)
        panelHeader.PerformLayout()
        panelMain.ResumeLayout(False)
        panelMain.PerformLayout()
        CType(dgvHistory, ComponentModel.ISupportInitialize).EndInit()
        panelActions.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblTotalAssessments As Label
    Friend WithEvents panelMain As Panel
    Friend WithEvents dgvHistory As DataGridView
    Friend WithEvents lblNoData As Label
    Friend WithEvents panelActions As Panel
    Friend WithEvents btnViewDetail As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents colAssessmentId As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colRank As DataGridViewTextBoxColumn
    Friend WithEvents colProfile As DataGridViewTextBoxColumn
    Friend WithEvents colCF As DataGridViewTextBoxColumn
End Class
