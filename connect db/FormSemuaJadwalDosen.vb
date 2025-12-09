Imports Newtonsoft.Json
Imports System.Net

Public Class FormSemuaJadwalDosen


    Private Sub FormSemuaJadwalDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'intinya pada bagian ini di gunakan untuk memanggil subroutein utama untuk mengambil dan menampilkan data jadwal
        Me.Text = "jadwal mengajar lengkap "
        TampilkanSemuaJadwal()
    End Sub

    Private Sub TampilkanSemuaJadwal() 'pada bagian ini berisi logika-logika untuk berkomunikasi dengan server dan menampilkan hasilnya di data grid view
        Dim usernameDosen As String = Koneksi.LoggedInUsername
        'mengambil username dosen yang sedang login dari modul koneksi untuk di lakukan validasi
        If String.IsNullOrWhiteSpace(usernameDosen) Then
            MsgBox("Error: data dosen tidak ditemukan.", MsgBoxStyle.Critical)
            Return
        End If

        Try

            'memanggil(post data ke server) API untuk keperluan mengambil data (menggunakan aksei READ di sisi server ) 
            Dim postData As String = "action=read_all_by_dosen" &
                                     "&username=" & HttpUtility.UrlEncode(usernameDosen)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, postData) 'mengirim data ke server lewat modul koneksi
            'di bawah merupakan tempat untuk melakukan validasi jika respon kosong atau berisi json kosong maka tandanya tidak ada jadwal
            If String.IsNullOrEmpty(responseJson) OrElse responseJson.Trim() = "[]" Then
                DgvSemuaJadwal.DataSource = Nothing
                MsgBox(" belum memiliki jadwal mengajar", MsgBoxStyle.Information)
                Return
            End If
            'sedangkan di bawah ini jika balasan dari server ada isinya maka balasan berupa JSON tersebut akan di rubah menjadi string untuk di jadikan objek data tabel yang bisa di gunakan aplikasi ini
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(responseJson)

            DgvSemuaJadwal.DataSource = dt 'bagian ini untuk mendeklarasikan atau menetapkan data tabel yang baru di buat sebagai sumber data untuk mengisi data grid view

            'sedangkan di bawah ini di gunakan untuk memastikan bahwa nama_nama kolom  yang di terima dari server di ubah menjadi nama yang lebih mudahh di baca
            If DgvSemuaJadwal.Columns.Contains("hari") Then DgvSemuaJadwal.Columns("hari").HeaderText = "Hari"
            If DgvSemuaJadwal.Columns.Contains("kelas") Then DgvSemuaJadwal.Columns("kelas").HeaderText = "Kelas"
            If DgvSemuaJadwal.Columns.Contains("nama_matkul") Then DgvSemuaJadwal.Columns("nama_matkul").HeaderText = "Mata Kuliah"
            If DgvSemuaJadwal.Columns.Contains("nama_ruangan") Then DgvSemuaJadwal.Columns("nama_ruangan").HeaderText = "Ruangan"
            If DgvSemuaJadwal.Columns.Contains("jam_mulai") Then DgvSemuaJadwal.Columns("jam_mulai").HeaderText = "Mulai"
            If DgvSemuaJadwal.Columns.Contains("jam_selesai") Then DgvSemuaJadwal.Columns("jam_selesai").HeaderText = "Selesai"

            DgvSemuaJadwal.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("Error saat memuat seluruh jadwal mengajar: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class
