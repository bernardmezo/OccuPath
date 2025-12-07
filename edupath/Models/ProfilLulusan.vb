' ============================================
' Model: ProfilLulusan & Rule
' Representasi profil lulusan dan rules sistem pakar
' ============================================

Namespace Models
    ''' <summary>
    ''' Representasi profil lulusan yang bisa direkomendasikan
    ''' </summary>
    Public Class ProfilLulusan
        Public Property Id As Integer
        Public Property Nama As String              ' nama profil
        Public Property Deskripsi As String
        Public Property ProgramStudi As String
        Public Property KompetensiUtama As String
        Public Property ProspekKarir As String
        Public Property IsActive As Boolean = True
        Public Property CreatedAt As DateTime

        Public Sub New()
        End Sub

        Public Sub New(nama As String, deskripsi As String)
            Me.Nama = nama
            Me.Deskripsi = deskripsi
        End Sub
    End Class

    ''' <summary>
    ''' Representasi rule untuk Forward Chaining
    ''' </summary>
    Public Class Rule
        Public Property Id As Integer
        Public Property RuleCode As String          ' R1, R2, etc.
        Public Property Condition As String         ' Format kondisi: "F_B1>=3.5 AND F_C1>=0.7"
        Public Property ProfilLulusanId As Integer  ' FK ke profil_lulusan
        Public Property CertaintyFactor As Double   ' Certainty Factor rule (0.00 - 1.00)
        Public Property Deskripsi As String
        Public Property IsActive As Boolean = True
        Public Property CreatedAt As DateTime

        Public Sub New()
        End Sub
    End Class

    ''' <summary>
    ''' Hasil rekomendasi untuk user
    ''' </summary>
    Public Class Recommendation
        Public Property Id As Integer
        Public Property UserId As Integer
        Public Property ProfilRekomendasi As String
        Public Property CfTotal As Decimal          ' Total Certainty Factor
        Public Property Ranking As Integer
        Public Property DetailPerhitungan As String
        Public Property Tanggal As DateTime

        Public Sub New()
        End Sub

        Public Sub New(profil As String, cf As Decimal, ranking As Integer)
            Me.ProfilRekomendasi = profil
            Me.CfTotal = cf
            Me.Ranking = ranking
            Me.Tanggal = DateTime.Now
        End Sub
    End Class
End Namespace
