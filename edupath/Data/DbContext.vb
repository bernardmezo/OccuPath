' ============================================
' Data Access Layer: DbContext
' Mengelola koneksi database MySQL
' ============================================

Imports MySql.Data.MySqlClient

Namespace Data
    ''' <summary>
    ''' Database context untuk mengelola koneksi MySQL
    ''' </summary>
    Public Class DbContext
        ' ==========================================
        ' KONFIGURASI KONEKSI DATABASE
        ' ==========================================
        Private Shared ReadOnly DB_SERVER As String = "localhost"
        Private Shared ReadOnly DB_NAME As String = "db_occupath"
        Private Shared ReadOnly DB_USER As String = "root"
        Private Shared ReadOnly DB_PASS As String = ""

        ''' <summary>
        ''' Mendapatkan connection string
        ''' </summary>
        Public Shared ReadOnly Property ConnectionString As String
            Get
                Return $"Server={DB_SERVER};Database={DB_NAME};Uid={DB_USER};Pwd={DB_PASS};SslMode=none;"
            End Get
        End Property

        ''' <summary>
        ''' Membuat koneksi baru ke database
        ''' </summary>
        Public Shared Function CreateConnection() As MySqlConnection
            Return New MySqlConnection(ConnectionString)
        End Function

        ''' <summary>
        ''' Test koneksi database
        ''' </summary>
        Public Shared Function TestConnection() As Boolean
            Try
                Using conn = CreateConnection()
                    conn.Open()
                    Return True
                End Using
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Test koneksi dengan pesan error
        ''' </summary>
        Public Shared Function TestConnectionWithMessage() As (Success As Boolean, Message As String)
            Try
                Using conn = CreateConnection()
                    conn.Open()
                    Return (True, "Koneksi database berhasil!")
                End Using
            Catch ex As Exception
                Return (False, $"Koneksi database gagal: {ex.Message}")
            End Try
        End Function
    End Class
End Namespace
