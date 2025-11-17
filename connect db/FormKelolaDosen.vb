'di bagian ini adlah library yang di perlukan untuk keperluan pengelolaan data json dan komunikasi web pada form kelola dosen ini
Imports System.Web
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data
Public Class FormKelolaDosen
    'pada bagian bawah di gunakan untuk mengisi variabel pada combo box dengan opsi default laki-laki serta memanggil fungsi TampilkanDataDosen agara tabel data langsung terisi saat form ini di buka
    Private Sub FormKelolaDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'pada bagian ini akan mengisi combo box jenis kelamin dengan opsi default laki-laki
        CmbKelamin.Items.Add("Laki-laki")
        CmbKelamin.Items.Add("Perempuan")
        CmbKelamin.SelectedIndex = 0 'kenapa di isi 0, karena index pada combo box di mulai dari 0 bukan 1

        'pada bagian ini akan memanggil fungsi TampilkanDataDosen agar tabel data langsung terisi saat form ini di buka
        TampilkanDataDosen()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        TampilkanDataDosen() 'pada bagian ini akan memanggil fungsi TampilkanDataDosen untuk merefresh atau memuat ulang data dosen pada tabel
    End Sub

    Public Sub TampilkanDataDosen() 'fungsi ini di gunakan untuk menampilkan data dosen pada tabel data grid view
        Try
            'dengan cara memanggil API dengan action=read melalui Koneksi.ApiUrl_Dosen_Profile yang sudah di deklarasikan pada module koneksi.vb
            Dim apiUrlRead As String = Koneksi.ApiUrl_Dosen_Profile & "?action=read"
            Dim jsonProfileData As String = Koneksi.GetJsonFromAPI(apiUrlRead)

            If String.IsNullOrEmpty(jsonProfileData) Then 'jika respons json kosong atau null maka tabel data grid view akan di kosongkan
                DgvDosen.DataSource = Nothing
                Return
            End If

            'pada bagian ini akan menguraikan data json yang di dapat dari API menjadi DataTable agar bisa di tampilkan pada data grid view
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonProfileData)

            'mengaitkan data table ke data grid view untuk di tampilkan
            DgvDosen.DataSource = dt
            DgvDosen.AutoResizeColumns()

        Catch ex As Exception 'sperti sebelum-sebelumnya , bagian ini di gunakan untuk menangani eror yang mungkinterjadi saat memuat data dosen
            MsgBox("eror saat memuat data dosen: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click 'bagian ini di gunakan untuk menambah data dosen baru ke database melalui API, fungsi yang akan di jalankan ketika tombol Tambah di klik
        'pada bagian bawah ini akan melakukan validasi inputan username dan nama, jika kosong maka akan menampilkan pesan peringatan berupa data yang wajib dii isi dan menghentikan proses
        If TxtUsername.Text = "" Or TxtNama.Text = "" Then
            MsgBox("Username/ID dan Nama wajib di isi ya gaes!!..", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            'persiapan data POST menggunakan HttpUtility.UrlEncode untuk keamanan, dengan cara membuat string data dari setiap inputan pada form yang akan di kirimkan ke server
            Dim postData As String = "action=create" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) & 'contohnya pada bagian ini akan mengirimkan data username dari form TxtUsername
                                     "&nama_lengkap=" & HttpUtility.UrlEncode(TxtNama.Text) &
                                     "&tempat_lahir=" & HttpUtility.UrlEncode(TxtTempatLahir.Text) &
                                     "&tanggal_lahir=" & DtTanggalLahir.Value.ToString("yyyy-MM-dd") &
                                     "&email=" & HttpUtility.UrlEncode(TxtEmail.Text) &
                                     "&jenis_kelamin=" & HttpUtility.UrlEncode(CmbKelamin.Text)

            'proses di bawah bertugas memanggil fungsi KirimDataKeAPI dari module koneksi.vb untuk mengirim data ke API dengan metode POST
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Dosen_Profile, postData)

            'pada bagian ini akan menguraikan respons json yang di terima dari server setelah mengirim data
            Dim result As JObject = JObject.Parse(responseJson)
            'pada bagian ini akan mengecek status dari respons json, jika sukses maka data dosen baru berhasil di tambahkan
            If result("status").ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "sukses")
                TampilkanDataDosen() 'bagian ini akan memanggil fungsi TampilkanDataDosen untuk memuat ulang data dosen pada tabel

                'bagian di bawah ini akan membersihkan semua inputan pada form setelah data berhasil di tambahkan
                TxtUsername.Clear()
                TxtNama.Clear()
                TxtTempatLahir.Clear()
                TxtEmail.Clear()

            Else 'jika status gagal maka akan menampilkan pesan gagal menambah profil beserta pesan dari server
                MsgBox("sayang sekali anda gagal menambah profil: " & result("message").ToString(), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("error saat proses tambah data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click 'fungsi ini di gunakan untuk kembali ke dashboard admin ketika tombol kembali di klik dengan cara menutup form kelola dosen
        Me.Close()
    End Sub
    'pada bagian di bawah ini adalah fungsi yang akan di jalankan ketika user mengklik salah satu baris data pada data grid view DgvDosen, dengan fungsi utamanya mengambil data dari baris yang di klik dan mengisi setiap form input dengan data yang sesuai dari kolom
    Private Sub DgvDosen_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDosen.CellContentClick
        If e.RowIndex >= 0 Then 'pada bagian ini akan memastikan bahwa baris yang di klik valid, dengan cara memeriksa apakah RowIndex lebih besar atau sama dengan 0
            Try
                'mengambil seluruh objek baris dari tabel berdasarkan RowIndex yang di klik dan menyimpannya dalam variabel row
                Dim row As DataGridViewRow = DgvDosen.Rows(e.RowIndex)
                'data dari setiap sel di tabel akan di ambil dan di salin ke dalam form input yang sesuai
                TxtUsername.Text = row.Cells("username").Value.ToString()
                TxtNama.Text = row.Cells("nama_lengkap").Value.ToString()
                TxtTempatLahir.Text = row.Cells("tempat_lahir").Value.ToString()
                DtTanggalLahir.Value = CDate(row.Cells("tanggal_lahir").Value) 'gunakan CDate untuk konversi tanggal
                TxtEmail.Text = row.Cells("email").Value.ToString()
                CmbKelamin.Text = row.Cells("jenis_kelamin").Value.ToString()
                'setelah data diisi, kita kunci TxtUsername agar tidak bisa diubah (Username adalah kunci unik/Primary Key)
                TxtUsername.Enabled = False

            Catch ex As Exception
                MsgBox("error saat memilih data: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    'untuk button edit bekerja dengan cara mengirim data yang sudah di ubah pada form ke API dengan action=update
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If TxtUsername.Enabled = True Then 'karena pada mode edit username di kunci, maka jika masih aktif berarti user belum memilih data dari tabel
            MsgBox("pilih data dosen dari tabel di bawah terlebih dahulu.", MsgBoxStyle.Information)
            Return
        End If

        If TxtNama.Text = "" Then 'bagian ini akan memvalidasi inputan nama, jika kosong maka akan menampilkan pesan peringatan dan menghentikan proses
            MsgBox("Nama wajib diisi.", MsgBoxStyle.Exclamation)
            Return
        End If

        'hanya bagian untuk mengkonfirmasi sebelum update
        If MsgBox("yakin gak nih mau ngedit datanya " & TxtNama.Text & "?", MsgBoxStyle.YesNo, "konfirmasi edit") = MsgBoxResult.No Then
            Return
        End If

        Try
            'proses mempersiapkan data POST untuk action=update
            Dim postData As String = "action=update" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                     "&nama_lengkap=" & HttpUtility.UrlEncode(TxtNama.Text) &
                                     "&tempat_lahir=" & HttpUtility.UrlEncode(TxtTempatLahir.Text) &
                                     "&tanggal_lahir=" & DtTanggalLahir.Value.ToString("yyyy-MM-dd") &
                                     "&email=" & HttpUtility.UrlEncode(TxtEmail.Text) &
                                     "&jenis_kelamin=" & HttpUtility.UrlEncode(CmbKelamin.Text)

            'bagian yang berfungsi untuk mengirim post data ke API
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Dosen_Profile, postData)
            'respons dari server akan di uraikan menjadi objek json untuk di proses lebih lanjut
            Dim result As JObject = JObject.Parse(responseJson)

            If result("status").ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "sukses edit")
                TampilkanDataDosen() 'muat ulang data
                ResetForm()

            Else
                MsgBox("aduh sayang sekali gagal mengedit profil: " & result("message").ToString(), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("error saat proses edit data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click 'fungsi ini di gunakan untuk menghapus data dosen dari database melalui API dengan action=delete
        If TxtUsername.Enabled = True Then 'sama seperti edit, jika username masih aktif berarti user belum memilih data dari tabel, jadi prosesnya di batalkan
            MsgBox("pilih data dosen dari tabel di bawah terlebih dahulu untuk dihapus.", MsgBoxStyle.Information)
            Return
        End If

        'konfirmasi sebelum hapus
        If MsgBox("wait, yakin nih mau di hapus datanya " & TxtNama.Text & " (" & TxtUsername.Text & ")?", MsgBoxStyle.YesNo, "konfirmasi dulu sebelum di hapus, tapi jangan nyesel") = MsgBoxResult.No Then
            Return
        End If

        Try
            'persiapkan data POST untuk action=delete. hanya butuh username sebagai kunci unik
            Dim postData As String = "action=delete" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text)

            'kirim data ke API
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Dosen_Profile, postData)

            Dim result As JObject = JObject.Parse(responseJson)

            If result("status").ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "sukses hapus")
                TampilkanDataDosen() 'muat ulang data

                'kembalikan Form ke mode Tambah/Create
                ResetForm()

            Else
                MsgBox("gagal menghapus profil: " & result("message").ToString(), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("error saat proses hapus data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub ResetForm() 'bagian ini di gunakan untuk mereset atau membersihkan semua inputan pada form serta mengembalikan form ke mode Create/Tambah
        TxtUsername.Clear()
        TxtNama.Clear()
        TxtTempatLahir.Clear()
        TxtEmail.Clear()
        CmbKelamin.SelectedIndex = 0 'reset ke Laki-laki
        DtTanggalLahir.Value = DateTime.Now 'reset Tanggal
        'aktifkan kembali input Username (kembali ke mode Create/Tambah)
        TxtUsername.Enabled = True
    End Sub


End Class