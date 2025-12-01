# OccuPath - Notes

## Forms

### Main Flow
- Form1: landing page
- Form4: login/register (tab control)
- Form5: menu utama

### Survey Forms (semua dynamic, backend isi pertanyaan)
- FormKategoriA: data diri - single Q display (10 total)
- FormKategoriB: data akademis - single Q display (10 total)
- Form2: combobox survey
- Form3: radiobutton survey

## Design
- blue accent #2980B9
- accent bar 5px kiri
- semua form 700x500-550 fixed

## Backend Integration

### Semua Form Survey Sama:
backend isi di `LoadQuestions()`:
```vb
questions.Add(New QuestionData With {
    .QuestionText = "Pertanyaan?",
    .Options = New List(Of String) From {"Opsi1", "Opsi2"}
})
```

struktur:
```vb
Public Class QuestionData
    Public Property QuestionText As String
    Public Property Options As List(Of String)
End Class
```

### Navigation
- Form2/3: independent
- KategoriA: last Q → auto open KategoriB
- KategoriB: ada tombol "Kategori A" untuk balik

## Status
- UI done
- semua form dynamic (1 Q per page)
- no hardcoded questions
- validasi jalan
- build ok
