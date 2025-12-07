Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq ' Digunakan untuk parsing respons API
Imports System.Net

Public Class FormAbsensiDosen

    ' Helper class untuk menyimpan ID jadwal (nilai) dan menampilkan nama (teks) di ComboBox
    Public Class ComboBoxItem
        Public Property ID As String
        Public Property Nama As String

        Public Overrides Function ToString() As String
            Return Nama
        End Function
    End Class

    ' ===============================================
    ' 1. LOAD DAN MUAT JADWAL AKTIF
    ' ===============================================

    Private Sub FormAbsensiDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Form Input Absensi"
        MuatJadwalAktif()
    End Sub

    ' Fungsi untuk memuat jadwal yang aktif hari ini untuk dosen ini
    Private Sub MuatJadwalAktif()
        Dim usernameDosen As String = Koneksi.LoggedInUsername

        CmbJadwal.Items.Clear()
        DgvMahasiswa.DataSource = Nothing
        BtnSimpan.Enabled = False

        If String.IsNullOrWhiteSpace(usernameDosen) Then
            MsgBox("Error sesi. Silakan login ulang.", MsgBoxStyle.Critical)
            Me.Close()
            Return
        End If

        Try
            ' Panggil API action=read_active_schedule_for_dosen
            Dim postData As String = "action=read_by_dosen_by_day" &
                                     "&username=" & HttpUtility.UrlEncode(usernameDosen)

            ' Asumsi API Jadwal digunakan untuk mengambil daftar kelas
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, postData)

            If String.IsNullOrEmpty(responseJson) OrElse responseJson.Trim() = "[]" Then
                MsgBox("Tidak ada jadwal mengajar yang aktif hari ini untuk diinput absensi.", MsgBoxStyle.Information)
                Return
            End If

            Dim dataJadwal As JArray = JsonConvert.DeserializeObject(Of JArray)(responseJson)

            For Each item In dataJadwal
                Dim displayNama As String = $"{item("nama_matkul").ToString()} - Kelas {item("kelas").ToString()}"
                ' Asumsi kolom ID jadwal dari API adalah 'id'
                Dim jadwalId As String = item("id").ToString()

                Dim cbItem As New ComboBoxItem With {.ID = jadwalId, .Nama = displayNama}
                CmbJadwal.Items.Add(cbItem)
            Next

            If CmbJadwal.Items.Count > 0 Then
                CmbJadwal.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox("Error saat memuat daftar jadwal: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' ===============================================
    ' 2. MUAT DAFTAR MAHASISWA
    ' ===============================================

    ' Event saat Jadwal dipilih (ComboBox berubah)
    Private Sub CmbJadwal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbJadwal.SelectedIndexChanged
        If CmbJadwal.SelectedItem Is Nothing Then Return

        Dim selectedItem As ComboBoxItem = CmbJadwal.SelectedItem
        MuatDaftarMahasiswa(selectedItem.ID)
    End Sub

    ' Fungsi untuk memuat daftar mahasiswa berdasarkan jadwal yang dipilih
    Private Sub MuatDaftarMahasiswa(jadwalId As String)
        DgvMahasiswa.DataSource = Nothing

        Try
            ' Panggil API action=read_mahasiswa_by_jadwal
            Dim postData As String = "action=read_list_absensi" &
                                     "&jadwal_id=" & HttpUtility.UrlEncode(jadwalId)

            ' Asumsi API Jadwal digunakan untuk mengambil daftar mahasiswa
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Absensi, postData)

            If String.IsNullOrEmpty(responseJson) OrElse responseJson.Trim() = "[]" Then
                DgvMahasiswa.DataSource = Nothing
                MsgBox("Tidak ada mahasiswa terdaftar di kelas ini.", MsgBoxStyle.Information)
                BtnSimpan.Enabled = False
                Return
            End If

            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(responseJson)
            DgvMahasiswa.DataSource = dt

            ' Penyesuaian Kolom
            ' 1. Tambahkan Kolom Status Absensi (ComboBox Column)
            If Not DgvMahasiswa.Columns.Contains("StatusAbsensi") Then
                Dim colAbsensi As New DataGridViewComboBoxColumn()
                colAbsensi.Name = "StatusAbsensi"
                colAbsensi.HeaderText = "Status Absensi"
                colAbsensi.Items.AddRange("Hadir", "Izin", "Sakit", "Alpa")
                DgvMahasiswa.Columns.Add(colAbsensi)

                ' Atur Display Index agar kolom Absensi diletakkan setelah Nama
                colAbsensi.DisplayIndex = DgvMahasiswa.Columns("nama").DisplayIndex + 1
            End If

            ' 2. Atur Header dan ReadOnly
            If DgvMahasiswa.Columns.Contains("username") Then DgvMahasiswa.Columns("username").HeaderText = "Username"
            If DgvMahasiswa.Columns.Contains("nama") Then DgvMahasiswa.Columns("nama").HeaderText = "Nama Mahasiswa"

            For Each col As DataGridViewColumn In DgvMahasiswa.Columns
                col.ReadOnly = (col.Name <> "StatusAbsensi") ' Hanya kolom StatusAbsensi yang boleh diedit
            Next

            DgvMahasiswa.AutoResizeColumns()
            BtnSimpan.Enabled = True

        Catch ex As Exception
            MsgBox("Error saat memuat daftar mahasiswa: " & ex.Message, MsgBoxStyle.Critical)
            BtnSimpan.Enabled = False
        End Try
    End Sub

    ' ===============================================
    ' 3. SIMPAN ABSENSI
    ' ===============================================

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        SimpanAbsensi()
    End Sub

    Private Sub SimpanAbsensi()
        If DgvMahasiswa.Rows.Count = 0 Then
            MsgBox("Tidak ada data mahasiswa untuk disimpan.", MsgBoxStyle.Exclamation)
            Return
        End If

        If CmbJadwal.SelectedItem Is Nothing Then
            MsgBox("Pilih jadwal terlebih dahulu.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim selectedJadwal As ComboBoxItem = CmbJadwal.SelectedItem
        Dim jadwalId As String = selectedJadwal.ID

        Dim absensiData As New List(Of String)
        Dim tanggalAbsensi As String = DateTime.Now.ToString("yyyy-MM-dd") ' Format tanggal untuk API

        ' Kumpulkan data absensi dari setiap baris
        For Each row As DataGridViewRow In DgvMahasiswa.Rows
            If row.IsNewRow Then Continue For

            Dim username As String = row.Cells("username").Value.ToString()
            Dim statusCell As DataGridViewComboBoxCell = TryCast(row.Cells("StatusAbsensi"), DataGridViewComboBoxCell)

            If statusCell Is Nothing OrElse statusCell.Value Is Nothing Then
                MsgBox($"Status absensi untuk Username {username} belum diisi. Mohon lengkapi data.", MsgBoxStyle.Exclamation)
                Return ' Batalkan penyimpanan
            End If

            Dim statusAbsensi As String = statusCell.Value.ToString()

            ' Format data: jadwal_id|tanggal|username|status. Ini akan di-parsing di sisi PHP.
            absensiData.Add($"{jadwalId}|{tanggalAbsensi}|{username}|{statusAbsensi}")
        Next

        Try
            ' Konversi List data menjadi JSON string untuk API
            Dim dataUntukAPI As String = JsonConvert.SerializeObject(absensiData)

            Dim postData As String = "action=save_absensi" &
                                     "&absensi_data_json=" & HttpUtility.UrlEncode(dataUntukAPI)

            ' Asumsi: API untuk mengelola absensi berada di endpoint lain
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Absensi, postData)

            Dim apiResponse As JObject = JObject.Parse(responseJson)

            If apiResponse("status").ToString() = "success" Then
                MsgBox("Absensi berhasil disimpan untuk semua mahasiswa.", MsgBoxStyle.Information)
                ' Refresh data mahasiswa (opsional, jika perlu menampilkan status absensi yang baru disimpan)
                MuatDaftarMahasiswa(jadwalId)
            Else
                MsgBox($"Gagal menyimpan absensi: {apiResponse("message")}", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            MsgBox("Error saat menyimpan absensi: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class