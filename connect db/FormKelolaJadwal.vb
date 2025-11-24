'ya bagian ini untuk meng import library yang diperlukan
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports Newtonsoft.Json
Public Class FormKelolaJadwal
    'bagian di bawah ini adalah deklarasi variabel untuk menyimpan data daftar mata kuliah dan dosen yang di muat dari serperr, dan nantinya data ini akan di gunakan untuk mengisi combobox
    Private MatkulList As DataTable
    Private DosenList As DataTable
    Private RuanganList As DataTable
    Private Sub FormKelolaJadwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'bagian untuk inisialisasi ComboBox statis, saya coba coba ternyata ada cara sperti ini juga
        CmbHari.Items.AddRange(New Object() {"Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu"})
        'memanggil loadlookupdata untuk memuat data mata kuliah dan dosen dari server
        LoadLookupData()
        'untuk menamilkan semua jadwal yang sudah ada di database
        TampilkanDataJadwal()
    End Sub

    'prosedur untuk mereset form
    Private Sub ResetForm()
        TxtKelas.Text = ""
        CmbHari.SelectedIndex = -1
        TxtJamMulai.Text = ""
        TxtJamSelesai.Text = ""
        TxtPengumuman.Text = ""
        CmbMatkul.SelectedIndex = -1
        CmbDosen.SelectedIndex = -1
    End Sub
    Private Sub LoadLookupData() 'bagian untuk memuat data mata kuliah yang nantinya akan di tampilkan di combobox
        Try
            Dim jsonMatkul As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, "action=read_matkul") 'pad abagian ini memanggil fungsi kirimdatakeapi dari module koneksi untuk meminta daftar mata kuliah dari server menggunakan action read_matkul
            MatkulList = JsonConvert.DeserializeObject(Of DataTable)(jsonMatkul) 'respons json di ubah menjadi objek datatable(matkullist), dan datatable ini akan di gunakan sebagai sumber data combobox 
            'bagian di bawah di guanakan untuk validasi dan binding data ke combobox
            If MatkulList IsNot Nothing Then 'memastikan data tidak kosong
                CmbMatkul.DataSource = MatkulList
                CmbMatkul.DisplayMember = "nama_matkul"
                CmbMatkul.ValueMember = "id_matkul"
                CmbMatkul.SelectedIndex = -1
            Else
                MsgBox("API matkul mengembalikan data kosong atau error JSON.", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("gagal memuat daftar matkul: " & ex.Message, MsgBoxStyle.Critical)
        End Try
        Try
            'pada bagian ini memanggil kirim data ke api untuk meminta daftar dosen dari server menggunakan action read_dosen
            Dim jsonDosen As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, "action=read_dosen")
            DosenList = JsonConvert.DeserializeObject(Of DataTable)(jsonDosen) 'respons json di ubah menjadi objek datatable(dosenlist), dan datatable ini akan di gunakan sebagai sumber data combobox

            If DosenList IsNot Nothing Then 'memastikan data tidak kosong
                CmbDosen.DataSource = DosenList
                CmbDosen.DisplayMember = "nama_dosen"
                CmbDosen.ValueMember = "username"
                CmbDosen.SelectedIndex = -1
            Else
                MsgBox("API dosen mengembalikan data kosong atau error JSON.", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("gagal memuat daftar dosen: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        ' ==========================================================
        ' LOGIKA MEMUAT DAFTAR RUANGAN
        ' ==========================================================
        Try
            ' ApiUrl_Kelola_Ruangan harus didefinisikan di Modul Koneksi
            Dim jsonRuangan As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Ruangan, "action=read")
            Dim dtRuangan As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonRuangan)

            If dtRuangan IsNot Nothing AndAlso dtRuangan.Rows.Count > 0 Then
                CmbRuangan.DataSource = dtRuangan
                ' Nama kolom HARUS SAMA PERSIS dengan manage_ruangan.php
                CmbRuangan.DisplayMember = "nama_ruangan"
                CmbRuangan.ValueMember = "id_ruangan"
                CmbRuangan.SelectedIndex = -1
            Else
                MsgBox("API Ruangan mengembalikan data kosong atau error JSON.", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Gagal memuat daftar Ruangan: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TampilkanDataJadwal() 'bagian untuk menampilkan data jadwal dari server ke datagridview
        Try
            'memanggil kirimdata ke api untuk meminta daftar jadwal dari server menggunakan action read
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, "action=read")
            If String.IsNullOrEmpty(responseJson) Then 'jika respons kosong atau tidak ada data maaka tampilkan pesan error
                MsgBox("API mengembalikan respons kosong atau error. silahkan hubungi developer aplikasi", MsgBoxStyle.Critical)
                Return
            End If
            'mengubah respons json yang berisi array objek jadwal menjadi objek datatable menggunkan library newtonsoft.json
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(responseJson)

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                'jika tabel kosong, tidak perlu bind atau hide kolom
                DgvJadwal.DataSource = Nothing
                MsgBox("data jadwal masih kosong ya, jadi tambahkan data terlebih dahulu.", MsgBoxStyle.Information)
                Return
            End If

            DgvJadwal.DataSource = dt 'bind data ke datagridview
            'mekanisme pengaman ganda untuk memastikan kolom ada sebelum mengaksesnya
            If DgvJadwal.Columns.Contains("id_jadwal") Then
                DgvJadwal.Columns("id_jadwal").Visible = False 'pada bagian ini menyembunyikan kolom id_jadwal dari pengguna dengan mekanisme jika kolom di temukan maka hasil dari pengecekan if adalah true, dan properti visible dari kolom tersebut di atur menjadi false
            End If

            'di bawah ini adalah pengecekan kolom dan penyembunyian kolom sama seperti di atas
            If DgvJadwal.Columns.Contains("username_dosen") Then
                DgvJadwal.Columns("username_dosen").Visible = False
            End If

            If DgvJadwal.Columns.Contains("id_matkul") Then ' <-- Sembunyikan ID Matkul
                DgvJadwal.Columns("id_matkul").Visible = False
            End If

            If DgvJadwal.Columns.Contains("id_ruangan") Then ' <-- Sembunyikan ID Ruangan
                DgvJadwal.Columns("id_ruangan").Visible = False
            End If
            ' Atur Header yang tampil (Opsional, tapi disarankan)
            If DgvJadwal.Columns.Contains("nama_matkul") Then DgvJadwal.Columns("nama_matkul").HeaderText = "mata kuliah"
            If DgvJadwal.Columns.Contains("nama_dosen") Then DgvJadwal.Columns("nama_dosen").HeaderText = "dosen pengampu"
            If DgvJadwal.Columns.Contains("nama_ruangan") Then DgvJadwal.Columns("nama_ruangan").HeaderText = "ruangan" '//<-- Tambahkan ini
            'menyesuaikan kolom agar sesuai dengan kebutuhan tampilan
            DgvJadwal.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("Error saat memuat data jadwal: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        If CmbMatkul.SelectedIndex = -1 Or CmbDosen.SelectedIndex = -1 Or CmbHari.SelectedIndex = -1 Or CmbRuangan.SelectedIndex = -1 Or String.IsNullOrWhiteSpace(TxtJamMulai.Text) Then ' <--- TAMBAH VALIDASI CmbRuangan
            MsgBox("Lengkapi data Mata Kuliah, Dosen, Hari, Jam Mulai, dan Ruangan.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            'ambil value dari ComboBox (ID Matkul dan Username Dosen)
            Dim idMatkul As String = CmbMatkul.SelectedValue.ToString()
            Dim usernameDosen As String = CmbDosen.SelectedValue.ToString()
            Dim idRuangan As String = CmbRuangan.SelectedValue.ToString()
            'intinya pada proses tambah ini kita mengirim data ke server menggunakan action create beserta data data yang di ambil dari form
            Dim postData As String = "action=create" &
                                     "&id_matkul=" & HttpUtility.UrlEncode(idMatkul) &
                                     "&username_dosen=" & HttpUtility.UrlEncode(usernameDosen) &
                                     "&kelas=" & HttpUtility.UrlEncode(TxtKelas.Text) &
                                     "&hari=" & HttpUtility.UrlEncode(CmbHari.Text) &
                                     "&jam_mulai=" & HttpUtility.UrlEncode(TxtJamMulai.Text) &
                                     "&jam_selesai=" & HttpUtility.UrlEncode(TxtJamSelesai.Text) &
                                     "&pengumuman=" & HttpUtility.UrlEncode(TxtPengumuman.Text) &
                                     "&id_ruangan=" & HttpUtility.UrlEncode(idRuangan)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, postData)
            If String.IsNullOrEmpty(responseJson) Then Return

            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataJadwal()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "Server merespons error tanpa pesan spesifik.")
                MsgBox("Gagal menambah jadwal: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses tambah jadwal: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DgvJadwal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvJadwal.CellContentClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = DgvJadwal.Rows(e.RowIndex)

                'simpan id jadwal ke tag form untuk operasi edit/hapus
                Me.Tag = row.Cells("id_jadwal").Value.ToString()

                'muat data ke kontrol
                TxtKelas.Text = row.Cells("kelas").Value.ToString()
                CmbHari.Text = row.Cells("hari").Value.ToString()
                TxtJamMulai.Text = row.Cells("jam_mulai").Value.ToString()
                TxtJamSelesai.Text = row.Cells("jam_selesai").Value.ToString()
                TxtPengumuman.Text = row.Cells("pengumuman").Value.ToString()
                'memuat cmb box berdasarrkan display member
                CmbMatkul.Text = row.Cells("nama_matkul").Value.ToString()
                CmbDosen.Text = row.Cells("nama_dosen").Value.ToString()
                CmbRuangan.Text = row.Cells("nama_ruangan").Value.ToString()
            Catch ex As Exception
                MsgBox("error saat memuat data dari tabel: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If Me.Tag Is Nothing OrElse String.IsNullOrWhiteSpace(Me.Tag.ToString()) Then
            MsgBox("pilih jadwal yang akan diedit dari tabel.", MsgBoxStyle.Exclamation)
            Return
        End If

        'pengambilan value dari cmb box
        Dim idMatkul As String = CmbMatkul.SelectedValue.ToString()
        Dim usernameDosen As String = CmbDosen.SelectedValue.ToString()
        Dim idRuangan As String = CmbRuangan.SelectedValue.ToString()
        Dim idJadwal As String = Me.Tag.ToString()
        'untuk proses edit kita mengirim data ke server menggunakan action update beserta data data yang di ambil dari form
        Try
            Dim postData As String = "action=update" &
                                     "&id_jadwal=" & HttpUtility.UrlEncode(idJadwal) & ' Kunci
                                     "&id_matkul=" & HttpUtility.UrlEncode(idMatkul) &
                                     "&username_dosen=" & HttpUtility.UrlEncode(usernameDosen) &
                                     "&kelas=" & HttpUtility.UrlEncode(TxtKelas.Text) &
                                     "&hari=" & HttpUtility.UrlEncode(CmbHari.Text) &
                                     "&jam_mulai=" & HttpUtility.UrlEncode(TxtJamMulai.Text) &
                                     "&jam_selesai=" & HttpUtility.UrlEncode(TxtJamSelesai.Text) &
                                     "&pengumuman=" & HttpUtility.UrlEncode(TxtPengumuman.Text) &
                                     "&id_ruangan=" & HttpUtility.UrlEncode(idRuangan)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, postData)
            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "pokoknya sukses")
                TampilkanDataJadwal()
                ResetForm()
            Else
                Dim pesanerror As String = If(result("message") IsNot Nothing, result("message").ToString(), "pokoknya eror dari serper")
                MsgBox("gagal mengedit jadwal: " & pesanerror, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("error saat proses edit jadwal: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        'pada bagian ini di gunakan untuk validasi apakah ada data yang di input atau tidak 
        If Me.Tag Is Nothing OrElse String.IsNullOrWhiteSpace(Me.Tag.ToString()) Then
            MsgBox("pilih jadwal yang akan dihapus dari tabel.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim idJadwal As String = Me.Tag.ToString()

        If MsgBox("yakin ingin menghapus jadwal ini?", MsgBoxStyle.YesNo, "konfirmasi dulu sebelum hapus!") = MsgBoxResult.No Then
            Return
        End If

        Try
            'untuk proses hapus kita menggunakan action delete 
            Dim postData As String = "action=delete" & "&id_jadwal=" & HttpUtility.UrlEncode(idJadwal)
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, postData)
            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "sukses")
                TampilkanDataJadwal()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "server capek sehingga merespons error tanpa pesan spesifik.")
                MsgBox("gagal menghapus jadwal: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("error saat proses hapus jadwal: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class