Imports Newtonsoft.Json 'di gunakan untuk pekerjaan yang menggunakna data yang berformatjson yang biasanya ada kaitannya dengan API (Aplication Programming Interface)
Imports System.Net 'menyediakan kelas untuk berbagai protokol jaringan
Imports System.Globalization 'saya lupa
Imports System.Diagnostics 'di gunakan untuk memulai proses dari sistem contohnya membuka web browser
Imports System.Text
'bagian di atas di gunakan untuk meng import library yang di perlukan

Public Class DashboardDosen

    Private Sub BtnLihatJadwalLengkap_Click(sender As Object, e As EventArgs) Handles BtnLihatJadwalLengkap.Click
        'membuka form yang menampilkan semua jadwal (FormSemuaJadwalDosen)

        Dim frmJadwalLengkap As New FormSemuaJadwalDosen()
        frmJadwalLengkap.Show()
    End Sub

    'bagian untuk mengambil sesi (username dosen yang sedang login)
    Private ReadOnly Property CurrentUsername As String 'intinya di sini di guanakan untuk mendefinisikan properti yang hanya bisa di baca, tujuannya untuk menyimpan username
        Get
            Return Koneksi.LoggedInUsername 'mengambil username dari modul koneksi
        End Get
    End Property

    'tempat untuk tombol yang di perlukan ya manteman

    Private Sub BtnNilaiWeb_Click(sender As Object, e As EventArgs) Handles BtnNilaiWeb.Click

        Dim targetPage As String = "tugas_dosen.php" 'ini target/ halaman yang spesifik di tuju
        Dim baseUrl As String = "https://8ed8233ea798.ngrok-free.app/dp/" 'ini adalah base url untuk setiap API saya pada projrct ini (tunnelling gratisan)

        'alihkan ke receiver.php hanya dengan username (u) dan tujuan (p), intinya di sini kita mengirim sesi yang ada di aplikasi desktop yang di gunakan untuk membuka web yang sesui tanpa melakukan login ulang (membuat sesi login di web)
        Dim urlFinal As String = baseUrl & "receiver.php" & 'bisa di bilang hanya untuk mengarahkan ke script perantara untuk memuat sesi 
                             "?u=" & HttpUtility.UrlEncode(CurrentUsername) & 'seperti namanya ya teman-teman urlencode di gunakana untuk mengkodekan atau menyandikan username dan nama 
                             "&p=" & HttpUtility.UrlEncode(targetPage)

        Try
            Process.Start(New ProcessStartInfo(urlFinal) With {.UseShellExecute = True})
            MsgBox("anda diarahkan ke portal web untuk mengelola tugas.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("gagal membuka browser: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub BtnAbsensi_Click(sender As Object, e As EventArgs) Handles BtnAbsensi.Click

        Dim targetPage As String = "absensi_mahasiswa.php"
        Dim baseUrl As String = "https://8ed8233ea798.ngrok-free.app/dp/"

        'alihkan ke receiver.php hanya dengan username (u) dan tujuan (p), intinya di sini kita mengirim sesi yang ada di aplikasi desktop yang di gunakan untuk membuka web yang sesui tanpa melakukan login ulang
        Dim urlFinal As String = baseUrl & "receiver.php" &
                             "?u=" & HttpUtility.UrlEncode(CurrentUsername) &
                             "&p=" & HttpUtility.UrlEncode(targetPage)

        Try
            Process.Start(New ProcessStartInfo(urlFinal) With {.UseShellExecute = True})
            MsgBox("anda diarahkan ke portal web untuk mengelola absensi.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("gagal membuka browser: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class
