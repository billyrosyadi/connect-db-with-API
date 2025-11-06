Imports Newtonsoft.Json.Linq
Imports System.Net
Imports Newtonsoft.Json

Public Class FormKelolaRuangan

    Private Sub FormKelolaRuangan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilkanDataRuangan()
    End Sub

    ' --- Prosedur untuk Memuat Data Ruangan (READ) ---
    Private Sub TampilkanDataRuangan()
        Try
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Ruangan, "action=read")

            If String.IsNullOrEmpty(responseJson) Then Return

            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(responseJson)

            DgvRuangan.DataSource = dt

            ' Sembunyikan ID Ruangan
            If DgvRuangan.Columns.Contains("id_ruangan") Then
                DgvRuangan.Columns("id_ruangan").Visible = False
            End If

            DgvRuangan.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("Error saat memuat data ruangan: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' --- Prosedur Reset Form ---
    Private Sub ResetForm()
        TxtNamaRuangan.Text = ""
        TxtKapasitas.Text = ""
        TxtDeskripsi.Text = ""
        Me.Tag = Nothing ' Bersihkan ID yang disimpan
    End Sub

    ' --- FUNGSI CREATE (Tambah Ruangan) ---
    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        If String.IsNullOrWhiteSpace(TxtNamaRuangan.Text) Then
            MsgBox("Nama Ruangan wajib diisi.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            ' Konversi Kapasitas ke Integer, default 0 jika gagal/kosong
            Dim kapasitas As Integer = If(Integer.TryParse(TxtKapasitas.Text, New Integer), New Integer, 0)

            Dim postData As String = "action=create" &
                                     "&nama_ruangan=" & HttpUtility.UrlEncode(TxtNamaRuangan.Text) &
                                     "&kapasitas=" & HttpUtility.UrlEncode(kapasitas.ToString()) &
                                     "&deskripsi=" & HttpUtility.UrlEncode(TxtDeskripsi.Text)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Ruangan, postData)
            If String.IsNullOrEmpty(responseJson) Then Return

            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataRuangan()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "Server merespons error tanpa pesan spesifik.")
                MsgBox("Gagal menambah ruangan: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses tambah ruangan: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' --- FUNGSI Memuat Data dari DGV ke Form ---
    Private Sub DgvRuangan_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRuangan.CellContentClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = DgvRuangan.Rows(e.RowIndex)

                ' Simpan ID Ruangan ke Tag form untuk operasi Edit/Hapus
                Me.Tag = row.Cells("id_ruangan").Value.ToString()

                ' Muat data ke kontrol
                TxtNamaRuangan.Text = row.Cells("nama_ruangan").Value.ToString()
                TxtKapasitas.Text = row.Cells("kapasitas").Value.ToString()
                TxtDeskripsi.Text = row.Cells("deskripsi").Value.ToString()

            Catch ex As Exception
                MsgBox("Error saat memuat data dari tabel: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    ' --- FUNGSI UPDATE dan DELETE (Logika serupa dengan form lain) ---
    ' ... (Tambahkan kode untuk BtnEdit_Click dan BtnHapus_Click) ...
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        ' --- VALIDASI AWAL ---
        If Me.Tag Is Nothing OrElse String.IsNullOrWhiteSpace(Me.Tag.ToString()) Then
            MsgBox("Pilih ruangan dari tabel yang akan diedit.", MsgBoxStyle.Exclamation)
            Return
        End If
        If String.IsNullOrWhiteSpace(TxtNamaRuangan.Text) Then
            MsgBox("Nama Ruangan tidak boleh kosong.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim idRuangan As String = Me.Tag.ToString()
        Dim kapasitas As Integer = If(Integer.TryParse(TxtKapasitas.Text, New Integer), New Integer, 0)

        Try
            ' Siapkan data POST untuk action=update
            Dim postData As String = "action=update" &
                                 "&id_ruangan=" & HttpUtility.UrlEncode(idRuangan) & ' WAJIB: Kunci Ruangan
                                 "&nama_ruangan=" & HttpUtility.UrlEncode(TxtNamaRuangan.Text) &
                                 "&kapasitas=" & HttpUtility.UrlEncode(kapasitas.ToString()) &
                                 "&deskripsi=" & HttpUtility.UrlEncode(TxtDeskripsi.Text)

            ' Kirim data ke API
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Ruangan, postData)
            If String.IsNullOrEmpty(responseJson) Then Return

            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses Edit")
                TampilkanDataRuangan()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "Server merespons error tanpa pesan spesifik.")
                MsgBox("Gagal mengedit ruangan: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses edit data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        ' --- VALIDASI AWAL ---
        If Me.Tag Is Nothing OrElse String.IsNullOrWhiteSpace(Me.Tag.ToString()) Then
            MsgBox("Pilih ruangan dari tabel yang akan dihapus.", MsgBoxStyle.Exclamation)
            Return
        End If

        If MsgBox("Yakin ingin menghapus Ruangan: " & TxtNamaRuangan.Text & "?", MsgBoxStyle.YesNo, "Konfirmasi Hapus") = MsgBoxResult.No Then
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
End Class