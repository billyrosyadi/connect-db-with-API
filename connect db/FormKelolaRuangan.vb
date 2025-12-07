Imports Newtonsoft.Json.Linq
Imports System.Net
Imports Newtonsoft.Json

Public Class FormKelolaRuangan

    Private Sub FormKelolaRuangan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilkanDataRuangan()
    End Sub

    'di bawah ini merupakan rosedur untuk memuat data ruangan menggunakan action read
    Private Sub TampilkanDataRuangan()
        Try
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Ruangan, "action=read")

            If String.IsNullOrEmpty(responseJson) Then Return

            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(responseJson)

            DgvRuangan.DataSource = dt

            'id ruangan di sembuyikan
            If DgvRuangan.Columns.Contains("id_ruangan") Then
                DgvRuangan.Columns("id_ruangan").Visible = False
            End If

            DgvRuangan.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("Error saat memuat data ruangan: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'jangan di tanya bagian ini untuk reset form
    Private Sub ResetForm()
        TxtNamaRuangan.Text = ""
        TxtKapasitas.Text = ""
        TxtDeskripsi.Text = ""
        Me.Tag = Nothing 'membersihkan id yang disimpan
    End Sub

    'bagian menambah ruangan menggunakan fungsi create
    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        If String.IsNullOrWhiteSpace(TxtNamaRuangan.Text) Then
            MsgBox("nama ruangan wajib diisi!!!!!!!!!!...................", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            'bagian untuk konversi kapasitas ke integer, default 0 jika gagal/kosong
            Dim kapasitas As Integer = If(Integer.TryParse(TxtKapasitas.Text, New Integer), New Integer, 0)

            Dim postData As String = "action=create" &
                                     "&nama_ruangan=" & HttpUtility.UrlEncode(TxtNamaRuangan.Text) &
                                     "&kapasitas=" & HttpUtility.UrlEncode(kapasitas.ToString()) &
                                     "&deskripsi=" & HttpUtility.UrlEncode(TxtDeskripsi.Text)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Ruangan, postData)
            If String.IsNullOrEmpty(responseJson) Then Return

            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "ssukses")
                TampilkanDataRuangan()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "server terlalu capek sehingga merespons error tanpa pesan spesifik. alias ngambek")
                MsgBox("gagal menambah ruangan: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("error saat proses menambahkan ruangan: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'bagian yang memuat data dari dgv ke form, intinya ketika cell di dgv di klik maka data yang berkaitan akan di muat di form
    Private Sub DgvRuangan_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRuangan.CellContentClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = DgvRuangan.Rows(e.RowIndex)

                'simpan id ruangan ke tag form untuk operasi edit/hapus
                Me.Tag = row.Cells("id_ruangan").Value.ToString()

                'bagian untuk memuat data ke kontrol rowss
                TxtNamaRuangan.Text = row.Cells("nama_ruangan").Value.ToString()
                TxtKapasitas.Text = row.Cells("kapasitas").Value.ToString()
                TxtDeskripsi.Text = row.Cells("deskripsi").Value.ToString()

            Catch ex As Exception
                MsgBox("pokoknya error saat memuat data dari tabel: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    'berikut adalah bagian untuk edit yang menggunaakan action update
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        ' --- VALIDASI AWAL ---
        If Me.Tag Is Nothing OrElse String.IsNullOrWhiteSpace(Me.Tag.ToString()) Then
            MsgBox("pilih ruangan dulu dari tabel yang akan diedit.", MsgBoxStyle.Exclamation)
            Return
        End If
        If String.IsNullOrWhiteSpace(TxtNamaRuangan.Text) Then
            MsgBox("kasi nama ruang lah jangan di kosongin", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim idRuangan As String = Me.Tag.ToString()
        Dim kapasitas As Integer = If(Integer.TryParse(TxtKapasitas.Text, New Integer), New Integer, 0)

        Try
            'mempersiapkan data POST untuk action update
            Dim postData As String = "action=update" &
                                 "&id_ruangan=" & HttpUtility.UrlEncode(idRuangan) &
                                 "&nama_ruangan=" & HttpUtility.UrlEncode(TxtNamaRuangan.Text) &
                                 "&kapasitas=" & HttpUtility.UrlEncode(kapasitas.ToString()) &
                                 "&deskripsi=" & HttpUtility.UrlEncode(TxtDeskripsi.Text)

            'prosespengiriman data ke serper
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Ruangan, postData)
            If String.IsNullOrEmpty(responseJson) Then Return

            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "dukses di adit")
                TampilkanDataRuangan()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "server merajuk")
                MsgBox("gagal meng Adit ruangan: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("error saat proses Jarwo data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'bagian ini loh ya yang bagian untuk delete data yang pake action delete
    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        'bagian untuk meng palidasi data 
        If Me.Tag Is Nothing OrElse String.IsNullOrWhiteSpace(Me.Tag.ToString()) Then
            MsgBox("di pilih dulu ruangan dari tabel yang akan dihapus.", MsgBoxStyle.Exclamation)
            Return
        End If

        If MsgBox("yakin ingin menghapus ruangan: " & TxtNamaRuangan.Text & "?", MsgBoxStyle.YesNo, "Konfirmasi Hapus") = MsgBoxResult.No Then
            Return
        End If

        Dim idRuangan As String = Me.Tag.ToString()

        Try
            ' Siapkan data POST untuk action=delete
            ' HANYA butuh id_ruangan sebagai kunci
            Dim postData As String = "action=delete" &
                                 "&id_ruangan=" & HttpUtility.UrlEncode(idRuangan)

            ' Kirim data ke API
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Ruangan, postData)
            If String.IsNullOrEmpty(responseJson) Then Return

            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses Hapus")
                TampilkanDataRuangan()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "Server merespons error tanpa pesan spesifik.")
                MsgBox("Gagal menghapus ruangan: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses hapus data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class