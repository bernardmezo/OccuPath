' ============================================
' Model: Question & QuestionOption
' Representasi pertanyaan dan opsi jawaban
' ============================================

Namespace Models
    ''' <summary>
    ''' Representasi satu pertanyaan dalam kuesioner
    ''' </summary>
    Public Class Question
        Public Property Id As Integer
        Public Property Code As String              ' F_A1, F_B1, F_C56, etc.
        Public Property Kategori As String          ' A, B, C
        Public Property Text As String              ' Teks pertanyaan
        Public Property Order As Integer            ' Urutan tampil
        Public Property IsActive As Boolean = True
        Public Property Options As List(Of QuestionOption)

        Public Sub New()
            Options = New List(Of QuestionOption)()
        End Sub

        Public Sub New(code As String, text As String, kategori As String, order As Integer)
            Me.Code = code
            Me.Text = text
            Me.Kategori = kategori
            Me.Order = order
            Me.Options = New List(Of QuestionOption)()
        End Sub
    End Class

    ''' <summary>
    ''' Representasi satu opsi jawaban
    ''' </summary>
    Public Class QuestionOption
        Public Property Id As Integer
        Public Property QuestionCode As String
        Public Property Text As String              ' Teks yang ditampilkan
        Public Property Value As Integer            ' Nilai untuk perhitungan
        Public Property Order As Integer            ' Urutan tampil

        Public Sub New()
        End Sub

        Public Sub New(text As String, value As Integer)
            Me.Text = text
            Me.Value = value
        End Sub

        ' Override ToString untuk ComboBox display
        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class
End Namespace
