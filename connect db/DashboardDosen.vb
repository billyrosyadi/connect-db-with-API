Imports Newtonsoft.Json
Imports System.Net
Imports System.Globalization
Imports System.Diagnostics
'bagian di atas di gunakan untuk meng import library yang di perlukan

Public Class DashboardDosen

    Private Sub BtnLihatJadwalLengkap_Click(sender As Object, e As EventArgs) Handles BtnLihatJadwalLengkap.Click
        'membuka form yang menampilkan semua jadwal (FormSemuaJadwalDosen)

        Dim frmJadwalLengkap As New FormSemuaJadwalDosen()
        frmJadwalLengkap.Show()
    End Sub



    'tempat untuk tombol yang di perlukan ya manteman
    Private Sub BtnNilaiWeb_Click(sender As Object, e As EventArgs) Handles BtnNilaiWeb.Click

        Dim urlFinal As String = "https://8ed8233ea798.ngrok-free.app/dp/tugas_dosen.php"

        Try
            'gunakan ProcessStartInfo untuk memastikan URL dibuka sebagai program, bukan file
            Process.Start(New ProcessStartInfo(urlFinal) With {.UseShellExecute = True})
            MsgBox("anda diarahkan ke portal web untuk mengelola tugas.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("gagal membuka browser: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub BtnAbsensi_Click(sender As Object, e As EventArgs) Handles BtnAbsensi.Click

        Dim baseUrl As String = "https://8ed8233ea798.ngrok-free.app/dp/absensi_mahasiswa.php"

        'mengirim username dosen dan role (role=dosen) di URL
        Dim usernameEncoded As String = HttpUtility.UrlEncode(Koneksi.LoggedInUsername)

        'url sekarang berisi username dan role yang diperlukan server untuk mengelola sesi
        Dim urlFinal As String = baseUrl & "?u=" & usernameEncoded & "&r=dosen"

        Try
            Process.Start(New ProcessStartInfo(urlFinal) With {.UseShellExecute = True})
            MsgBox("anda diarahkan ke portal web untuk mengelola absensi.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("gagal membuka browser: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class