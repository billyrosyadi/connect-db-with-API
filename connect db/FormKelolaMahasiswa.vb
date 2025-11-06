Imports System.Web
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data

Public Class FormKelolaMahasiswa
    ' Asumsi kontrol tambahan untuk Mahasiswa: 
    ' TxtAlamat, TxtJurusan, TxtTahunMasuk (diasumsikan sudah dideklarasikan)

    Private Sub FormKelolaMahasiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Inisialisasi ComboBox Jenis Kelamin
        CmbKelamin.Items.Add("Laki-laki")
        CmbKelamin.Items.Add("Perempuan")
        CmbKelamin.SelectedIndex = 0 ' Pilih default

        ' 2. Tampilkan Data Mahasiswa (DIKOMENTARI SEMENTARA HINGGA API READ BERES)
        TampilkanDataMahasiswa()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        TampilkanDataMahasiswa()
    End Sub

    ' =========================================================================
    ' READ FUNCTION
    ' =========================================================================
    Public Sub TampilkanDataMahasiswa()
        Try
            ' 1. Panggil API dengan action=read
            Dim apiUrlRead As String = Koneksi.ApiUrl_Mahasiswa_Profile & "?action=read"
            Dim jsonProfileData As String = Koneksi.GetJsonFromAPI(apiUrlRead)

            If String.IsNullOrEmpty(jsonProfileData) Then
                DgvMahasiswa.DataSource = Nothing
                Return
            End If

            ' 2. Deserialisasi JSON ke DataTable
            ' Error 'Expected StartArray, got StartObject' terjadi di baris ini 
            ' jika PHP mengembalikan pesan error BUKAN array data
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonProfileData)

            ' 3. Bind data ke DataGridView
            DgvMahasiswa.DataSource = dt
            DgvMahasiswa.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("Error saat memuat data mahasiswa: " & ex.Message &
                   vbCrLf & "Pastikan API READ Mahasiswa sudah benar (tidak ada Error 500/StartObject).", MsgBoxStyle.Critical)
        End Try
    End Sub

    ' =========================================================================
    ' CREATE FUNCTION
    ' =========================================================================
    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        If TxtUsername.Text = "" Or TxtNama.Text = "" Then
            MsgBox("Username/NIM dan Nama wajib diisi.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            ' ... (Siapkan postData untuk action=create, pastikan 9 key dikirim) ...
            Dim postData As String = "action=create" &
                                 "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                 "&nama_lengkap=" & HttpUtility.UrlEncode(TxtNama.Text) &
                                 "&alamat=" & HttpUtility.UrlEncode(TxtAlamat.Text) &
                                 "&jurusan=" & HttpUtility.UrlEncode(CmbJurusan.Text) &
                                 "&kelas=" & HttpUtility.UrlEncode(CmbKelas.Text) &
                                 "&tahun_masuk=" & HttpUtility.UrlEncode(TxtTahunMasuk.Text) &
                                 "&tempat_lahir=" & HttpUtility.UrlEncode(TxtTempatLahir.Text) &
                                 "&tanggal_lahir=" & DtTanggalLahir.Value.ToString("yyyy-MM-dd") &
                                 "&email=" & HttpUtility.UrlEncode(TxtEmailMahasiswa.Text) & ' Gunakan TxtEmailMahasiswa.Text
                                 "&jenis_kelamin=" & HttpUtility.UrlEncode(CmbKelamin.Text)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Mahasiswa_Profile, postData)

            If String.IsNullOrEmpty(responseJson) Then
                MsgBox("API mengembalikan respons kosong. Cek Koneksi.vb Anda.", MsgBoxStyle.Critical)
                Return
            End If

            ' PASTIKAN Respons JSON yang diterima tidak diawali karakter aneh
            Dim jsonStringClean As String = responseJson.Trim()

            ' Uraikan respons JSON dengan pengecekan aman
            Dim result As JObject = JObject.Parse(jsonStringClean)

            ' Cek status (Ini akan menangani respons "success" dan "error")
            If result IsNot Nothing AndAlso result("status") IsNot Nothing Then

                Dim status As String = result("status").ToString()
                Dim message As String = result("message")?.ToString()

                If status = "success" Then
                    MsgBox(message, MsgBoxStyle.Information, "Sukses")
                    ' TampilkanDataMahasiswa() ' Aktifkan jika form sudah bisa di-load
                    ResetForm()
                Else
                    ' Status = "error" (Menangani pesan error dari PHP)
                    MsgBox("Gagal menambah profil: " & message, MsgBoxStyle.Exclamation)
                End If
            Else
                ' Jika respons JSON tidak memiliki key "status"
                MsgBox("Respons API tidak valid.", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            ' Menangkap Error Parsing (e.g., Unexpected character <)
            MsgBox("Error saat proses tambah data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' =========================================================================
    ' HELPER FUNCTION
    ' =========================================================================
    Private Sub ResetForm()
        ' Bersihkan semua input
        TxtUsername.Clear()
        TxtNama.Clear()
        TxtAlamat.Clear()
        CmbJurusan.SelectedIndex = 0
        TxtTahunMasuk.Clear()
        TxtTempatLahir.Clear()
        TxtEmailMahasiswa.Clear()
        CmbKelamin.SelectedIndex = 0
        DtTanggalLahir.Value = DateTime.Now

        ' Aktifkan kembali input Username (kembali ke mode Create/Tambah)
        TxtUsername.Enabled = True
    End Sub

    ' =========================================================================
    ' EVENT LAINNYA
    ' =========================================================================
    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.Close()
    End Sub

    Private Sub DgvMahasiswa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMahasiswa.CellContentClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = DgvMahasiswa.Rows(e.RowIndex)

                ' Muat data ke TextBox dan ComboBox
                ' Asumsi urutan kolom: username, nama_lengkap, alamat, email, jenis_kelamin, tgl_lahir, jurusan, tempat_lahir, tahun_masuk

                TxtUsername.Text = row.Cells("username").Value.ToString()
                TxtNama.Text = row.Cells("nama_lengkap").Value.ToString()
                TxtAlamat.Text = row.Cells("alamat").Value.ToString()
                TxtEmailMahasiswa.Text = row.Cells("email").Value.ToString() ' Menggunakan TxtEmailMahasiswa
                TxtTempatLahir.Text = row.Cells("tempat_lahir").Value.ToString()
                TxtTahunMasuk.Text = row.Cells("tahun_masuk").Value.ToString()

                ' Muat ComboBox dan DateTimePicker
                CmbJurusan.Text = row.Cells("jurusan").Value.ToString() ' Menggunakan CmbJurusan
                CmbKelas.Text = row.Cells("kelas").Value.ToString()
                CmbKelamin.Text = row.Cells("jenis_kelamin").Value.ToString()

                ' Penanganan Tanggal Lahir (Wajib menggunakan TryParse)
                Dim dateValue As DateTime
                If DateTime.TryParse(row.Cells("tgl_lahir").Value.ToString(), dateValue) Then
                    DtTanggalLahir.Value = dateValue
                Else
                    DtTanggalLahir.Value = DateTime.Now ' Default jika parsing gagal
                End If

                ' Kunci Username agar tidak bisa diubah saat mode Edit/Hapus
                TxtUsername.Enabled = False

            Catch ex As Exception
                MsgBox("Error saat memuat data: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If TxtUsername.Text = "" Then
            MsgBox("Pilih data yang akan diedit dari tabel.", MsgBoxStyle.Exclamation)
            Return
        End If
        If MsgBox("Apakah Anda yakin ingin MENGEDIT data " & TxtNama.Text & "?", MsgBoxStyle.YesNo, "Konfirmasi Edit") = MsgBoxResult.No Then
            Return
        End If

        Try
            ' 1. Siapkan data POST (termasuk 9 kolom, dengan action=update)
            Dim postData As String = "action=update" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                     "&nama_lengkap=" & HttpUtility.UrlEncode(TxtNama.Text) &
                                     "&alamat=" & HttpUtility.UrlEncode(TxtAlamat.Text) &
                                     "&jurusan=" & HttpUtility.UrlEncode(CmbJurusan.Text) &
                                     "&kelas=" & HttpUtility.UrlEncode(CmbKelas.Text) &
                                     "&tahun_masuk=" & HttpUtility.UrlEncode(TxtTahunMasuk.Text) &
                                     "&tempat_lahir=" & HttpUtility.UrlEncode(TxtTempatLahir.Text) &
                                     "&tanggal_lahir=" & DtTanggalLahir.Value.ToString("yyyy-MM-dd") & ' Format tanggal yyyy-MM-dd
                                     "&email=" & HttpUtility.UrlEncode(TxtEmailMahasiswa.Text) & ' Menggunakan TxtEmailMahasiswa
                                     "&jenis_kelamin=" & HttpUtility.UrlEncode(CmbKelamin.Text)

            ' 2. Kirim data ke API
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Mahasiswa_Profile, postData)

            Dim result As JObject = JObject.Parse(responseJson)

            If result("status").ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses Edit")
                TampilkanDataMahasiswa() ' Muat ulang data

                ' Kembalikan Form ke mode Tambah/Create
                ResetForm()

            Else
                MsgBox("Gagal mengedit profil: " & result("message").ToString(), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Error saat proses edit data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        If TxtUsername.Text = "" Then
            MsgBox("Pilih data yang akan dihapus dari tabel.", MsgBoxStyle.Exclamation)
            Return
        End If

        If MsgBox("Yakin ingin menghapus data Mahasiswa dengan NIM: " & TxtUsername.Text & "?", MsgBoxStyle.YesNo, "Konfirmasi Hapus") = MsgBoxResult.No Then
            Return
        End If

        Try
            ' 1. Siapkan data POST (Hanya perlu username dan action=delete)
            Dim postData As String = "action=delete" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text)

            ' 2. Kirim data ke API
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Mahasiswa_Profile, postData)

            If String.IsNullOrEmpty(responseJson) Then Return

            ' 3. Uraikan respons JSON
            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataMahasiswa()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "Server merespons error tanpa pesan spesifik.")
                MsgBox("Gagal menghapus profil: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses hapus data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' (Tambahkan kode BtnEdit_Click, BtnHapus_Click, dan DgvMahasiswa_CellContentClick di sini)

End Class