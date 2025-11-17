'intinya pada bagian ini sama seperti bagian bagian sebelumnya untuk menambahak library yang di perlukan
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class FormKelolaAkun
    Private Sub TampilkanDataAkun() 'fungsi ini di gunakan untuk menampilkan data akun pada tabel data grid view
        Try
            'dengan cara memanggil API dengan action=read melalui Koneksi.ApiUrl_Dosen_Profile yang sudah di deklarasikan pada module koneksi.vb
            Dim apiUrlRead As String = Koneksi.ApiUrl_Kelola_Akun & "?action=read"
            Dim jsonProfileData As String = Koneksi.GetJsonFromAPI(apiUrlRead)
            'jika respons json kosong atau null maka tabel data grid view akan di kosongkan
            If String.IsNullOrEmpty(jsonProfileData) Then
                DgvAkun.DataSource = Nothing
                Return
            End If

            'pada bagian ini akan menguraikan data json yang di dapat dari API menjadi DataTable agar bisa di tampilkan pada data grid view
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonProfileData)

            'mengaitkan data table ke data grid view untuk di tampilkan
            DgvAkun.DataSource = dt
            DgvAkun.AutoResizeColumns()

        Catch ex As Exception 'bagian ini di gunakan untuk menangani eror yang mungkinterjadi saat memuat data 
            MsgBox("error saat memuat data akun: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub FormKelolaAkun_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'bagian ini berfungsi untuk memuat data yang sudah ada dan menyiapkan opsi role baru saat form di buka
        TampilkanDataAkun()
        CmbRole.Items.AddRange(New Object() {"mahasiswa", "dosen"}) 'menambahkan opsi role ke ComboBox, alasan hanya tersedia role dosen dan mahasiswa adalah untuk keamanan, sedangkan untuk role admin hanya bisa di atur langsung di database
    End Sub
    'pada bagian di bawah ini adalah fungsi yang akan di jalankan ketika user mengklik salah satu baris data pada data grid view DgvDosen, dengan fungsi utamanya mengambil data dari baris yang di klik dan mengisi setiap form input dengan data yang sesuai dari kolom
    Private Sub DgvAkun_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAkun.CellContentClick
        If e.RowIndex >= 0 Then 'pada bagian ini akan memastikan bahwa baris yang di klik valid, dengan cara memeriksa apakah RowIndex lebih besar atau sama dengan 0
            Try
                'mendapatkan seluruh objek baris dari tabel berdasarkan RowIndex yang di klik dan menyimpannya dalam variabel row
                Dim row As DataGridViewRow = DgvAkun.Rows(e.RowIndex)
                TxtUsername.Text = row.Cells("username").Value.ToString()
                CmbRole.Text = row.Cells("role").Value.ToString()
                'setelah data diisi, kita kunci TxtUsername agar tidak bisa diubah untuk alasan keamanan (Username adalah kunci unik/Primary Key)
                TxtUsername.Enabled = False
            Catch ex As Exception
                MsgBox("error saat mengisi data dari tabel: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    'untuk button edit bekerja dengan cara mengirim data yang sudah di ubah pada form ke API dengan action=update
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        'bagian ini akan memastikan bahwa user telah memilih username dan role baru sebelum melanjutkan proses edit
        If TxtUsername.Text = "" Or CmbRole.Text = "" Then
            MsgBox("pilih Username dan tentukan role baru.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            'proses mempersiapkan data POST untuk action=update
            Dim postData As String = "action=update" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                     "&role=" & HttpUtility.UrlEncode(CmbRole.Text) &
                                     "&new_password=" & HttpUtility.UrlEncode(TxtPassword.Text)
            'bagian di bawah ini mengirim data ke API dan menerima respons JSON
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Akun, postData)
            If String.IsNullOrEmpty(responseJson) Then Return
            'respons dari server akan di uraikan menjadi objek json untuk di proses lebih lanjut
            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataAkun()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "serper merespons error tanpa pesan spesifik.")
                MsgBox("sayang sekali anada gagal mengubah role: " & pesanError, MsgBoxStyle.Exclamation)
            End If
            'jika pada bagian try terjadi error maka akan di tangkap pada bagian catch dan menampilkan pesan error
        Catch ex As Exception
            MsgBox("Error saat proses edit Role: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click 'fungsi ini di gunakan untuk menghapus data dosen dari database melalui API dengan action=delete
        If TxtUsername.Text = "" Then 'sama seperti edit, jika username masih aktif berarti user belum memilih data dari tabel, jadi prosesnya di batalkan
            MsgBox("pilih dulu akun yang mau dihapus dari tabel.", MsgBoxStyle.Exclamation)
            Return
        End If
        'pengecekan sekali lagi sebelum menghapus data, dengan menampilkan pesan konfirmasi
        If MsgBox("yakin nih mau hapus akun ini '" & TxtUsername.Text & "'?", MsgBoxStyle.YesNo, "konfirmasi hapus dulu dong") = MsgBoxResult.No Then
            Return
        End If

        Try
            'persiapkan data POST untuk action=delete. hanya butuh username sebagai kunci unik
            Dim postData As String = "action=delete" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text)
            'mengirim data ke serper melalui modull koneksi.vb 
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Akun, postData)
            'jika respons json kosong maka proses di batalkan
            If String.IsNullOrEmpty(responseJson) Then Return
            'uraikan respons json menjadi objek json
            Dim result As JObject = JObject.Parse(responseJson.Trim())
            'yah intinya pada bagian ini jika proses hapus sukses maka data di refresh dan form di reset
            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataAkun()
                ResetForm()
            Else
                'jika gagal maka tampilkan pesan error dari server
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "serpernya eror gaes!!!!.....")
                MsgBox("duh gagal deh menghapus akun: " & pesanError, MsgBoxStyle.Exclamation)
            End If

            'jika terjadi error saat proses hapus maka akan di tangkap pada bagian catch
        Catch ex As Exception
            MsgBox("error saat proses hapus akun: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'bagian ini di gunakan untuk menambah data akun baru ke database melalui API, fungsi yang akan di jalankan ketika tombol Tambah di klik
    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        'pada bagian bawah ini akan melakukan validasi inputan username dan password, jika kosong maka akan menampilkan pesan peringatan berupa data yang wajib dii isi dan menghentikan proses
        If TxtUsername.Text = "" Or TxtPassword.Text = "" Then
            MsgBox("Username dan Password wajib diisi.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            'persiapan data POST menggunakan HttpUtility.UrlEncode untuk keamanan, dengan cara membuat string data dari setiap inputan pada form yang akan di kirimkan ke server
            Dim postData As String = "action=create" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                     "&password=" & HttpUtility.UrlEncode(TxtPassword.Text) &
                                     "&role=" & HttpUtility.UrlEncode(CmbRole.Text)

            'proses di bawah bertugas memanggil fungsi KirimDataKeAPI dari module koneksi.vb untuk mengirim data ke API dengan metode POST
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Akun, postData)
            If String.IsNullOrEmpty(responseJson) Then Return

            Dim result As JObject = JObject.Parse(responseJson.Trim())
            'bagian di bawah ini untuk menangani respons dari server setelah mengirim data
            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataAkun() 'refresh DGV
                ResetForm() 'untuk membersihkan form
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "serpernya eror gaes!!!!.....")
                MsgBox("duh gagal deh menambahkan akun: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("error saat proses tambah akun: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ResetForm() 'fungsi ini di gunakan untuk membersihkan form input setelah proses tambah/edit/hapus selesai
        TxtUsername.Text = ""
        TxtPassword.Text = ""
        CmbRole.SelectedIndex = -1
        TxtUsername.Enabled = True
    End Sub
End Class