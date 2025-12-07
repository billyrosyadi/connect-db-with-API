Imports Newtonsoft.Json
Imports System.Net
Imports System.Globalization
Imports System.Diagnostics
'bagian di atas di gunakan untuk meng import library yang di perlukan

Public Class DashboardDosen

    'pendeklarasian url web untuk keperluan khusus di dalan form ini
    Private Const BaseWebUrl As String = "https://8ed8233ea798.ngrok-free.app/"

    ' ===============================================
    ' 1. EVENT HANDLER UTAMA (LOAD)
    ' ===============================================

    Private Sub DashboardDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Lakukan pengecekan sesi dan muat data saat Form dimuat

        If String.IsNullOrWhiteSpace(Koneksi.LoggedInUsername) Then
            MsgBox("Sesi login tidak valid atau sudah berakhir. Silakan login ulang.", MsgBoxStyle.Critical)
            ' Anda mungkin ingin kembali ke Form Login di sini
            ' Form1.Show() 
            Me.Close()
            Return
        End If

        ' Muat Jadwal Hari Ini
        TampilkanJadwalHariIni()
    End Sub

    ' ===============================================
    ' 2. FUNGSI MUAT DATA
    ' ===============================================

    Private Sub TampilkanJadwalHariIni()
        ' Dapatkan nama hari ini dalam Bahasa Indonesia
        Dim hariIni As String = DateTime.Now.ToString("dddd", New CultureInfo("id-ID"))
        Dim usernameDosen As String = Koneksi.LoggedInUsername

        Try
            ' Panggil API action=read_by_dosen_by_day
            Dim postData As String = "action=read_by_dosen_by_day" &
                                     "&username=" & HttpUtility.UrlEncode(usernameDosen) &
                                     "&hari=" & HttpUtility.UrlEncode(hariIni)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, postData)

            If String.IsNullOrEmpty(responseJson) OrElse responseJson.Trim() = "[]" Then
                DgvJadwalHariIni.DataSource = Nothing
                Return
            End If

            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(responseJson)
            DgvJadwalHariIni.DataSource = dt

            ' Penyesuaian tampilan DGV (pastikan kolom ada di respons API)
            If DgvJadwalHariIni.Columns.Contains("nama_matkul") Then
                DgvJadwalHariIni.Columns("nama_matkul").HeaderText = "Mata Kuliah"
            End If
            If DgvJadwalHariIni.Columns.Contains("nama_ruangan") Then
                DgvJadwalHariIni.Columns("nama_ruangan").HeaderText = "Ruangan"
            End If
            If DgvJadwalHariIni.Columns.Contains("jam_mulai") Then
                DgvJadwalHariIni.Columns("jam_mulai").HeaderText = "Mulai"
            End If
            If DgvJadwalHariIni.Columns.Contains("jam_selesai") Then
                DgvJadwalHariIni.Columns("jam_selesai").HeaderText = "Selesai"
            End If

            ' Kolom yang disembunyikan
            If DgvJadwalHariIni.Columns.Contains("username_dosen") Then
                DgvJadwalHariIni.Columns("username_dosen").Visible = False
            End If
            If DgvJadwalHariIni.Columns.Contains("hari") Then
                DgvJadwalHariIni.Columns("hari").Visible = False
            End If

            DgvJadwalHariIni.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("Error saat memuat jadwal hari ini: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' ===============================================
    ' 3. MENU LAUNCHER (EVENT HANDLER TOMBOL)
    ' ===============================================

    ' --- Lihat Semua Jadwal (Form Internal VB.NET) ---
    Private Sub BtnLihatJadwalLengkap_Click(sender As Object, e As EventArgs) Handles BtnLihatJadwalLengkap.Click
        ' Membuka Form yang menampilkan semua jadwal (FormSemuaJadwalDosen)

        Dim frmJadwalLengkap As New FormSemuaJadwalDosen()
        frmJadwalLengkap.Show()
    End Sub

    ' --- Tugas & Jawaban (Web Portal Eksternal) ---
    Private Sub BtnTugasWeb_Click(sender As Object, e As EventArgs)
        Dim urlPortal = BaseWebUrl & "tugas_portal.php?username=" & HttpUtility.UrlEncode(LoggedInUsername)
        Try
            Process.Start(urlPortal)
            MsgBox("Anda diarahkan ke portal web untuk mengelola Tugas.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Gagal membuka browser: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' --- Input Nilai (Web Portal Eksternal) ---
    Private Sub BtnNilaiWeb_Click(sender As Object, e As EventArgs) Handles BtnNilaiWeb.Click
        ' Asumsi BaseWebUrl adalah URL portal utamanya (tanpa nama file tambahan)
        ' Ganti BaseWebUrl menjadi: Private Const BaseWebUrl As String = "https://8ed8233ea798.ngrok-free.app/"

        ' Jika BaseWebUrl sudah benar (termasuk tugas_nilai_manajemen.php), 
        ' maka seharusnya tidak perlu menambahkan 'tugas_portal.php' lagi.

        ' Pilihan 1: Jika Anda hanya ingin membuka BaseWebUrl (yang sudah lengkap)
        ' Dim urlFinal As String = BaseWebUrl & "?username=" & HttpUtility.UrlEncode(Koneksi.LoggedInUsername)

        ' Pilihan 2 (Paling Benar): Gunakan URL baru yang lebih spesifik
        Dim urlFinal As String = "https://8ed8233ea798.ngrok-free.app/tugas_nilai_manajemen.php"

        Try
            ' Gunakan ProcessStartInfo untuk memastikan URL dibuka sebagai program, bukan file
            Process.Start(New ProcessStartInfo(urlFinal) With {.UseShellExecute = True})
            MsgBox("Anda diarahkan ke portal web untuk mengelola Tugas.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Gagal membuka browser: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' --- Absensi (Form Internal VB.NET) ---
    Private Sub BtnAbsensi_Click(sender As Object, e As EventArgs) Handles BtnAbsensi.Click
        ' 1. Cek Sesi Username Dosen
        If String.IsNullOrWhiteSpace(Koneksi.LoggedInUsername) Then
            MsgBox("Error sesi. Silakan login ulang.", MsgBoxStyle.Critical)
            Return
        End If

        ' 2. Buat dan Tampilkan Form Absensi Dosen
        Dim frmAbsensi As New FormAbsensiDosen()

        ' 3. Tampilkan form sebagai dialog (modal) atau biasa
        ' Disarankan menggunakan ShowDialog agar pengguna fokus mengisi absensi
        frmAbsensi.ShowDialog()
    End Sub

    Private Sub DgvJadwalHariIni_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
End Class