'yah intinya sama pada bagian ini seperti yang ada pada form kelola dosen
Imports System.Web
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data

Public Class FormKelolaMahasiswa
    Private Sub FormKelolaMahasiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'bagian untuk insialisasi form ketika pertama kali di muat
        CmbKelamin.Items.Add("Laki-laki")
        CmbKelamin.Items.Add("Perempuan")
        CmbKelamin.SelectedIndex = 0 'pilih default berupa laki-laki

        'untuk menampilkan data mahasiswa dari API
        TampilkanDataMahasiswa()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        TampilkanDataMahasiswa()
    End Sub

    'berikut adalah bagian yang berfungsi untuk menampilkan data mahasiswa dari API ke dalam datagridview menggunakan metode READ
    Public Sub TampilkanDataMahasiswa()
        Try
            'pemanggil API dengan action=read
            Dim apiUrlRead As String = Koneksi.ApiUrl_Mahasiswa_Profile & "?action=read" 'pada bagian ini memberitahu server bahwa kita ingin melakukan operasi READ data mahasiswa dan mengambil semua data mahasiswa
            Dim jsonProfileData As String = Koneksi.GetJsonFromAPI(apiUrlRead) 'memanggil fungsi GetJsonFromAPI dari module koneksi untuk mendapatkan data JSON dari API

            If String.IsNullOrEmpty(jsonProfileData) Then 'jika data yang di terima kosong maka hentikan proses
                DgvMahasiswa.DataSource = Nothing
                Return
            End If

            'nah pada bagian ini lah Newtonsoft.json berperan untuk menguraikan data JSON menjadi DataTable yang dapat di tampilkan ke DataGridView
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonProfileData)

            'di bagian ini kita mengatur dengan cara mengikat/ binding data tabel sebagai sumber data untuk di tampilkan pada DataGridView
            DgvMahasiswa.DataSource = dt
            DgvMahasiswa.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("error saat memuat data mahasiswa: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'bagian untuk fungsi tambah data mahasiswa menggunakan metode CREATE
    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        If TxtUsername.Text = "" Or TxtNama.Text = "" Then 'sama seperti form kelola dosen, kita wajibkan username dan nama wajib di isi
            MsgBox("Username/NIM dan Nama wajib diisi.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            'persiapan data post untuk di kirim ke server menggunakan metode CREATE
            Dim postData As String = "action=create" &
                                 "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                 "&nama_lengkap=" & HttpUtility.UrlEncode(TxtNama.Text) &
                                 "&alamat=" & HttpUtility.UrlEncode(TxtAlamat.Text) &
                                 "&jurusan=" & HttpUtility.UrlEncode(CmbJurusan.Text) &
                                 "&kelas=" & HttpUtility.UrlEncode(CmbKelas.Text) &
                                 "&tahun_masuk=" & HttpUtility.UrlEncode(TxtTahunMasuk.Text) &
                                 "&tempat_lahir=" & HttpUtility.UrlEncode(TxtTempatLahir.Text) &
                                 "&tanggal_lahir=" & DtTanggalLahir.Value.ToString("yyyy-MM-dd") &
                                 "&email=" & HttpUtility.UrlEncode(TxtEmailMahasiswa.Text) &
                                 "&jenis_kelamin=" & HttpUtility.UrlEncode(CmbKelamin.Text)
            'sama serperti form kelola dosen, kita mengirim data ke API menggunakan fungsi KirimDataKeAPI dari module koneksi
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Mahasiswa_Profile, postData)

            If String.IsNullOrEmpty(responseJson) Then
                MsgBox("serper mengembalikan respons kosong. silahkan hubungi developer untuk memperbaiki bug ini", MsgBoxStyle.Critical)
                Return
            End If

            'bagian yang memastikan respons Json tidak meiliki karakter aneh dan tak terduga yang menyebabkan eror parsing dan debuging ber jam jam :)
            Dim jsonStringClean As String = responseJson.Trim()

            'penguraian respons JSON dengan pengecekan aman
            Dim result As JObject = JObject.Parse(jsonStringClean)

            'bagian yang memastikan proses parsing Json sebelumnya berhasil dan variabel result benar benar berisi data objek, dan memiliki key "status"
            If result IsNot Nothing AndAlso result("status") IsNot Nothing Then

                Dim status As String = result("status").ToString() 'bagian ini di gunakan untuk menyimpan nilai dari key "status" sebagai string
                Dim message As String = result("message")?.ToString() 'memastikan jika tidak ada key "message" tidak akan menyebabkan error

                If status = "success" Then 'pesan suskes akan di tamplikan ke pengguna jika status = success
                    MsgBox(message, MsgBoxStyle.Information, "yes sukses")
                    ResetForm()
                Else
                    'jika gagal maka tampilkan pesan gagal
                    MsgBox("sayang sekali anda gagal menambahkan profil: " & message, MsgBoxStyle.Exclamation)
                End If
            Else
                'jika respons JSON tidak memiliki key "status" 
                MsgBox("respon dari serper tidak valid, silahkan hubungi depeloper", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            'jika eror pada saat prose penambahan data maka akan muncul pesan error
            MsgBox("error saat proses tambah data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub ResetForm()
        'membersihkan semua input
        TxtUsername.Clear()
        TxtNama.Clear()
        TxtAlamat.Clear()
        CmbJurusan.SelectedIndex = 0
        TxtTahunMasuk.Clear()
        TxtTempatLahir.Clear()
        TxtEmailMahasiswa.Clear()
        CmbKelamin.SelectedIndex = 0
        DtTanggalLahir.Value = DateTime.Now
        'aktifkan kembali input Username (kembali ke mode Create/Tambah)
        TxtUsername.Enabled = True
    End Sub
    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.Close()
    End Sub
    'bagian untuk mengisi data ke form ketika baris pada datagridview di klik, yah kurang lebih sama seperti form kelola dosen untuk fungsinya
    Private Sub DgvMahasiswa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMahasiswa.CellContentClick
        If e.RowIndex >= 0 Then 'pada bagian ini akan memastikan bahwa baris yang di klik valid, dengan cara memeriksa apakah RowIndex lebih besar atau sama dengan 0
            Try
                'mengambil seluruh objek baris dari tabel berdasarkan RowIndex yang di klik dan menyimpannya dalam variabel row
                Dim row As DataGridViewRow = DgvMahasiswa.Rows(e.RowIndex)
                'data dari setiap sel di tabel akan di ambil dan di salin ke dalam form input yang sesuai
                TxtUsername.Text = row.Cells("username").Value.ToString()
                TxtNama.Text = row.Cells("nama_lengkap").Value.ToString()
                TxtAlamat.Text = row.Cells("alamat").Value.ToString()
                TxtEmailMahasiswa.Text = row.Cells("email").Value.ToString()
                TxtTempatLahir.Text = row.Cells("tempat_lahir").Value.ToString()
                TxtTahunMasuk.Text = row.Cells("tahun_masuk").Value.ToString()
                CmbJurusan.Text = row.Cells("jurusan").Value.ToString()
                CmbKelas.Text = row.Cells("kelas").Value.ToString()
                CmbKelamin.Text = row.Cells("jenis_kelamin").Value.ToString()
                Dim dateValue As DateTime 'fungsi TryParse untuk mengonversi string tanggal dari sel tabel menjadi objek DateTime
                If DateTime.TryParse(row.Cells("tgl_lahir").Value.ToString(), dateValue) Then
                    DtTanggalLahir.Value = dateValue
                Else
                    DtTanggalLahir.Value = DateTime.Now
                End If

                'kunci Username agar tidak bisa diubah saat mode Edit/Hapus
                TxtUsername.Enabled = False

            Catch ex As Exception
                MsgBox("error saat memuat data: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        'memastikan bahwa ada data yang dipilih untuk diedit
        If TxtUsername.Text = "" Then
            MsgBox("pilih dulu data yang akan diedit dari tabel.", MsgBoxStyle.Exclamation)
            Return
        End If
        If MsgBox("yakin gak nih mau ngedit datanya " & TxtNama.Text & "?", MsgBoxStyle.YesNo, "konfirmasi dulu sebelum di edit") = MsgBoxResult.No Then
            Return
        End If

        Try
            'proses mempersiapkan data POST untuk action=update
            Dim postData As String = "action=update" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                     "&nama_lengkap=" & HttpUtility.UrlEncode(TxtNama.Text) &
                                     "&alamat=" & HttpUtility.UrlEncode(TxtAlamat.Text) &
                                     "&jurusan=" & HttpUtility.UrlEncode(CmbJurusan.Text) &
                                     "&kelas=" & HttpUtility.UrlEncode(CmbKelas.Text) &
                                     "&tahun_masuk=" & HttpUtility.UrlEncode(TxtTahunMasuk.Text) &
                                     "&tempat_lahir=" & HttpUtility.UrlEncode(TxtTempatLahir.Text) &
                                     "&tanggal_lahir=" & DtTanggalLahir.Value.ToString("yyyy-MM-dd") &
                                     "&email=" & HttpUtility.UrlEncode(TxtEmailMahasiswa.Text) &
                                     "&jenis_kelamin=" & HttpUtility.UrlEncode(CmbKelamin.Text)

            'sama seperti form kelola dosen, kita mengirim data ke API menggunakan fungsi KirimDataKeAPI dari module koneksi
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Mahasiswa_Profile, postData)
            'respons dari server akan di uraikan menjadi objek json untuk di proses lebih lanjut
            Dim result As JObject = JObject.Parse(responseJson)
            'jika status pada respons yang sudah di uraikan tadi adalah success maka proses edit berhasil
            If result("status").ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "sukses Edit")
                TampilkanDataMahasiswa() 'muat ulang data
                'membalikan Form ke mode Tambah/Create
                ResetForm()

            Else 'jika gagal maka tampilkan pesan gagal
                MsgBox("sayang sekali anda gagal mengedit profil: " & result("message").ToString(), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("error saat proses edit data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click 'bagian untuk menghapus data mahasiswa menggunakan metode DELETE
        If TxtUsername.Text = "" Then 'pastikan ada data yang dipilih untuk di hapus
            MsgBox("pilih data yang akan dihapus dari tabel.", MsgBoxStyle.Exclamation)
            Return
        End If

        If MsgBox("yakin ingin menghapus data Mahasiswa dengan NIM: " & TxtUsername.Text & "?", MsgBoxStyle.YesNo, "konfirmasi dulu gih") = MsgBoxResult.No Then
            Return
        End If

        Try
            'persiapan data POST untuk action=delete
            Dim postData As String = "action=delete" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text)

            'kirim data ke API
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Mahasiswa_Profile, postData)

            If String.IsNullOrEmpty(responseJson) Then Return

            'penguraian respons JSON
            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "sukses")
                TampilkanDataMahasiswa()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "hehehehe... serper merespons error tanpa pesan spesifik :)")
                MsgBox("sayang sekali anda gagal menghapus profil: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("error saat proses hapus data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TxtTempatLahir_TextChanged(sender As Object, e As EventArgs) Handles TxtTempatLahir.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class