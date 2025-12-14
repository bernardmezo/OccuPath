Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports OccuPath.Core

''' <summary>
''' Form User Management - Admin can manage all users
''' </summary>
Public Class FormUserManagement
    Private _adminUserId As Integer

    Public Sub New(adminUserId As Integer)
        InitializeComponent()
        _adminUserId = adminUserId
    End Sub

    Private Sub FormUserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadUsers()
    End Sub

    Private Sub SetupDataGridView()
        dgvUsers.AutoGenerateColumns = False
        dgvUsers.Columns.Clear()

        ' ID Column
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colId",
            .HeaderText = "ID",
            .DataPropertyName = "Id",
            .Width = 50
        })

        ' Username Column
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colUsername",
            .HeaderText = "Username",
            .DataPropertyName = "Username",
            .Width = 120
        })

        ' Full Name Column
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colFullName",
            .HeaderText = "Nama Lengkap",
            .DataPropertyName = "FullName",
            .Width = 180
        })

        ' Email Column
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colEmail",
            .HeaderText = "Email",
            .DataPropertyName = "Email",
            .Width = 200
        })

        ' NIM Column
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colNIM",
            .HeaderText = "NIM",
            .DataPropertyName = "NIM",
            .Width = 100
        })

        ' Prodi Column
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colProdi",
            .HeaderText = "Prodi",
            .DataPropertyName = "Prodi",
            .Width = 60
        })

        ' Semester Column
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colSemester",
            .HeaderText = "Sem",
            .DataPropertyName = "Semester",
            .Width = 50
        })

        ' Role Column
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colRole",
            .HeaderText = "Peran",
            .DataPropertyName = "Role",
            .Width = 80
        })

        ' Created At Column
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colCreatedAt",
            .HeaderText = "Dibuat Pada",
            .DataPropertyName = "CreatedAt",
            .Width = 150,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "dd MMM yyyy HH:mm"}
        })

        ' Edit Button Column
        Dim btnEdit As New DataGridViewButtonColumn() With {
            .Name = "colEdit",
            .HeaderText = "Ubah",
            .Text = "Ubah",
            .UseColumnTextForButtonValue = True,
            .Width = 60
        }
        dgvUsers.Columns.Add(btnEdit)

        ' Delete Button Column
        Dim btnDelete As New DataGridViewButtonColumn() With {
            .Name = "colDelete",
            .HeaderText = "Hapus",
            .Text = "Hapus",
            .UseColumnTextForButtonValue = True,
            .Width = 70
        }
        dgvUsers.Columns.Add(btnDelete)

        ' Style
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsers.MultiSelect = False
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.AllowUserToDeleteRows = False
        dgvUsers.ReadOnly = False
        dgvUsers.RowHeadersVisible = False
        dgvUsers.BackgroundColor = Color.White
        dgvUsers.BorderStyle = BorderStyle.None
        dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219)
        dgvUsers.DefaultCellStyle.SelectionForeColor = Color.White
        dgvUsers.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        dgvUsers.DefaultCellStyle.Padding = New Padding(5, 3, 5, 3)
        dgvUsers.RowTemplate.Height = 35
        dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 246, 247)
        dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185)
        dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvUsers.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        dgvUsers.ColumnHeadersDefaultCellStyle.Padding = New Padding(5, 8, 5, 8)
        dgvUsers.ColumnHeadersHeight = 45
        dgvUsers.EnableHeadersVisualStyles = False
    End Sub

    Private Sub LoadUsers()
        Try
            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                Dim sql = "SELECT id, username, full_name, email, nim, prodi, semester, role, created_at " &
                          "FROM users ORDER BY created_at DESC"

                Dim dt As New DataTable()
                Using cmd As New MySqlCommand(sql, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using

                ' Map to user objects for better binding
                Dim users As New List(Of UserDisplay)()
                For Each row As DataRow In dt.Rows
                    users.Add(New UserDisplay() With {
                        .Id = Convert.ToInt32(row("id")),
                        .Username = row("username").ToString(),
                        .FullName = row("full_name").ToString(),
                        .Email = If(IsDBNull(row("email")), "", row("email").ToString()),
                        .NIM = If(IsDBNull(row("nim")), "", row("nim").ToString()),
                        .Prodi = If(IsDBNull(row("prodi")), "", row("prodi").ToString()),
                        .Semester = If(IsDBNull(row("semester")), "", row("semester").ToString()),
                        .Role = row("role").ToString(),
                        .CreatedAt = Convert.ToDateTime(row("created_at"))
                    })
                Next

                dgvUsers.DataSource = users
                lblTotalUsers.Text = $"Total User: {users.Count}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Kesalahan memuat user: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim userId = Convert.ToInt32(dgvUsers.Rows(e.RowIndex).Cells("colId").Value)
        Dim username = dgvUsers.Rows(e.RowIndex).Cells("colUsername").Value.ToString()

        ' Edit button clicked
        If e.ColumnIndex = dgvUsers.Columns("colEdit").Index Then
            EditUser(userId)
        End If

        ' Delete button clicked
        If e.ColumnIndex = dgvUsers.Columns("colDelete").Index Then
            ' Prevent deleting current admin
            If userId = _adminUserId Then
                MessageBox.Show("Anda tidak dapat menghapus akun Anda sendiri!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim result = MessageBox.Show($"Apakah Anda yakin ingin menghapus user '{username}'?" & vbCrLf & vbCrLf &
                                         "Ini juga akan menghapus semua assessment dan hasil mereka!",
                                         "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                DeleteUser(userId)
            End If
        End If
    End Sub

    Private Sub EditUser(userId As Integer)
        Try
            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                ' Get user data
                Dim sql = "SELECT username, full_name, email, nim, prodi, semester, role FROM users WHERE id = @userId"
                Dim username, fullName, email, nim, prodi, role As String
                Dim semester As Integer = 1

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            username = reader.GetString("username")
                            fullName = reader.GetString("full_name")
                            email = If(reader.IsDBNull(reader.GetOrdinal("email")), "", reader.GetString("email"))
                            nim = If(reader.IsDBNull(reader.GetOrdinal("nim")), "", reader.GetString("nim"))
                            prodi = If(reader.IsDBNull(reader.GetOrdinal("prodi")), "TI", reader.GetString("prodi"))
                            semester = If(reader.IsDBNull(reader.GetOrdinal("semester")), 1, reader.GetInt32("semester"))
                            role = reader.GetString("role")
                        Else
                            MessageBox.Show("User tidak ditemukan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End Using
                End Using

                ' Show edit dialog
                Dim editForm As New FormUserEdit(userId, username, fullName, email, nim, prodi, semester, role)
                If editForm.ShowDialog() = DialogResult.OK Then
                    LoadUsers()
                    MessageBox.Show("User berhasil diperbarui!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Kesalahan mengubah user: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteUser(userId As Integer)
        Try
            Using conn = DatabaseConnection.GetConnection()
                conn.Open()

                Dim sql = "DELETE FROM users WHERE id = @userId"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("User berhasil dihapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadUsers()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Kesalahan menghapus user: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim addForm As New FormUserAdd()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadUsers()
            MessageBox.Show("User berhasil ditambahkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadUsers()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Keluar",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            SessionManager.Logout()
            Dim loginForm As New Form1()
            loginForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim searchText = txtSearch.Text.Trim().ToLower()
        
        If String.IsNullOrEmpty(searchText) Then
            LoadUsers()
            Return
        End If

        Try
            Dim users = TryCast(dgvUsers.DataSource, List(Of UserDisplay))
            If users IsNot Nothing Then
                Dim filtered = users.Where(Function(u)
                                               Return u.Username.ToLower().Contains(searchText) OrElse
                                                      u.FullName.ToLower().Contains(searchText) OrElse
                                                      u.Email.ToLower().Contains(searchText) OrElse
                                                      u.NIM.ToLower().Contains(searchText)
                                           End Function).ToList()
                dgvUsers.DataSource = filtered
                lblTotalUsers.Text = $"Menampilkan {filtered.Count} dari {users.Count} user"
            End If
        Catch ex As Exception
            ' If filtering fails, just reload
            LoadUsers()
        End Try
    End Sub

    ' Helper class for data binding
    Public Class UserDisplay
        Public Property Id As Integer
        Public Property Username As String
        Public Property FullName As String
        Public Property Email As String
        Public Property NIM As String
        Public Property Prodi As String
        Public Property Semester As String
        Public Property Role As String
        Public Property CreatedAt As DateTime
    End Class
End Class
