Imports Newtonsoft.Json
Imports System.Net

Public Class FormSemuaJadwalDosen

    ' Asumsi Anda memiliki DataGridView bernama DgvSemuaJadwal pada Form ini

    Private Sub FormSemuaJadwalDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Jadwal Mengajar Lengkap Dosen "
        TampilkanSemuaJadwal()
    End Sub

    Private Sub TampilkanSemuaJadwal()
        Dim usernameDosen As String = Koneksi.LoggedInUsername

        If String.IsNullOrWhiteSpace(usernameDosen) Then
            MsgBox("Error: Data sesi dosen tidak ditemukan. Mohon login ulang.", MsgBoxStyle.Critical)
            Return
        End If

        Try
            ' Panggil API action=read_all_by_dosen dari manage_jadwal.php
            Dim postData As String = "action=read_all_by_dosen" &
                                     "&username=" & HttpUtility.UrlEncode(usernameDosen)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, postData)

            If String.IsNullOrEmpty(responseJson) OrElse responseJson.Trim() = "[]" Then
                DgvSemuaJadwal.DataSource = Nothing
                MsgBox("Anda belum memiliki jadwal mengajar lengkap yang terdaftar.", MsgBoxStyle.Information)
                Return
            End If

            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(responseJson)

            DgvSemuaJadwal.DataSource = dt

            ' Penyesuaian tampilan DGV (menggunakan If Contains untuk kompatibilitas)
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