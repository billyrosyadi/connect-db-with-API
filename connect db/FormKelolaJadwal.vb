Imports Newtonsoft.Json.Linq
Imports System.Net
Imports Newtonsoft.Json
Public Class FormKelolaJadwal

    Private MatkulList As DataTable
    Private DosenList As DataTable
    Private Sub FormKelolaJadwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Inisialisasi ComboBox statis
        CmbHari.Items.AddRange(New Object() {"Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu"})

        ' 2. Muat data lookup dari API
        LoadLookupData()

        ' 3. Tampilkan data jadwal utama
        TampilkanDataJadwal()
    End Sub

    ' Tambahkan prosedur untuk mereset form
    Private Sub ResetForm()
        ' TxtIDJadwal.Text = "" ' Jika ada ID Jadwal
        TxtKelas.Text = ""
        CmbHari.SelectedIndex = -1
        TxtJamMulai.Text = ""
        TxtJamSelesai.Text = ""
        TxtPengumuman.Text = ""
        CmbMatkul.SelectedIndex = -1
        CmbDosen.SelectedIndex = -1

        ' Aktifkan kembali tombol yang mungkin dinonaktifkan
        ' BtnTambah.Enabled = True
        ' BtnEdit.Enabled = False
        ' BtnHapus.Enabled = False
    End Sub
    Private Sub LoadLookupData()
        ' --- Load Mata Kuliah ---
        Try
            Dim jsonMatkul As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, "action=read_matkul")
            MatkulList = JsonConvert.DeserializeObject(Of DataTable)(jsonMatkul)

            If MatkulList IsNot Nothing Then ' <-- PENTING: Cek Data
                CmbMatkul.DataSource = MatkulList
                CmbMatkul.DisplayMember = "nama_matkul"
                CmbMatkul.ValueMember = "id_matkul"
                CmbMatkul.SelectedIndex = -1
            Else
                MsgBox("API Matkul mengembalikan data kosong atau error JSON.", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Gagal memuat daftar Mata Kuliah: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        ' --- Load Dosen ---
        Try
            Dim jsonDosen As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, "action=read_dosen")
            DosenList = JsonConvert.DeserializeObject(Of DataTable)(jsonDosen)

            If DosenList IsNot Nothing Then ' <-- PENTING: Cek Data
                CmbDosen.DataSource = DosenList
                CmbDosen.DisplayMember = "nama_dosen" ' Sesuai alias AS nama_dosen di PHP
                CmbDosen.ValueMember = "username"
                CmbDosen.SelectedIndex = -1
            Else
                MsgBox("API Dosen mengembalikan data kosong atau error JSON.", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Gagal memuat daftar Dosen: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TampilkanDataJadwal()
        Try
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, "action=read")

            If String.IsNullOrEmpty(responseJson) Then
                ' Error: API kosong (Mungkin error 23acc9)
                MsgBox("API mengembalikan respons kosong atau error PHP. Cek API Anda.", MsgBoxStyle.Critical)
                Return
            End If

            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(responseJson)

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                ' Jika tabel kosong, tidak perlu bind atau hide kolom
                DgvJadwal.DataSource = Nothing
                MsgBox("Data Jadwal Kosong. Harap tambahkan data terlebih dahulu.", MsgBoxStyle.Information)
                Return
            End If

            DgvJadwal.DataSource = dt

            ' --- KOREKSI KRITIS DI SINI ---
            ' Cek apakah kolom "id_jadwal" ada sebelum menyembunyikannya
            If DgvJadwal.Columns.Contains("id_jadwal") Then
                DgvJadwal.Columns("id_jadwal").Visible = False ' Kolom ID disembunyikan
            End If

            ' Cek kolom lookup lainnya (jika ingin)
            If DgvJadwal.Columns.Contains("username_dosen") Then
                DgvJadwal.Columns("username_dosen").Visible = False
            End If

            DgvJadwal.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("Error saat memuat data jadwal: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        If CmbMatkul.SelectedIndex = -1 Or CmbDosen.SelectedIndex = -1 Or CmbHari.SelectedIndex = -1 Or String.IsNullOrWhiteSpace(TxtJamMulai.Text) Then
            MsgBox("Lengkapi data Mata Kuliah, Dosen, Hari, dan Jam Mulai.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            ' Ambil Value dari ComboBox (ID Matkul dan Username Dosen)
            Dim idMatkul As String = CmbMatkul.SelectedValue.ToString()
            Dim usernameDosen As String = CmbDosen.SelectedValue.ToString()

            Dim postData As String = "action=create" &
                                     "&id_matkul=" & HttpUtility.UrlEncode(idMatkul) &
                                     "&username_dosen=" & HttpUtility.UrlEncode(usernameDosen) &
                                     "&kelas=" & HttpUtility.UrlEncode(TxtKelas.Text) &
                                     "&hari=" & HttpUtility.UrlEncode(CmbHari.Text) &
                                     "&jam_mulai=" & HttpUtility.UrlEncode(TxtJamMulai.Text) &
                                     "&jam_selesai=" & HttpUtility.UrlEncode(TxtJamSelesai.Text) &
                                     "&pengumuman=" & HttpUtility.UrlEncode(TxtPengumuman.Text)

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

                ' Simpan ID Jadwal ke Tag form untuk operasi Edit/Hapus
                Me.Tag = row.Cells("id_jadwal").Value.ToString()

                ' Muat data ke kontrol
                TxtKelas.Text = row.Cells("kelas").Value.ToString()
                CmbHari.Text = row.Cells("hari").Value.ToString()
                TxtJamMulai.Text = row.Cells("jam_mulai").Value.ToString()
                TxtJamSelesai.Text = row.Cells("jam_selesai").Value.ToString()
                TxtPengumuman.Text = row.Cells("pengumuman").Value.ToString()

                ' Muat ComboBox berdasarkan DISPLAY MEMBER
                CmbMatkul.Text = row.Cells("nama_matkul").Value.ToString()
                CmbDosen.Text = row.Cells("nama_dosen").Value.ToString()

                ' Aktifkan tombol Edit/Hapus
                ' BtnTambah.Enabled = False
                ' BtnEdit.Enabled = True
                ' BtnHapus.Enabled = True

            Catch ex As Exception
                MsgBox("Error saat memuat data dari tabel: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If Me.Tag Is Nothing OrElse String.IsNullOrWhiteSpace(Me.Tag.ToString()) Then
            MsgBox("Pilih jadwal yang akan diedit dari tabel.", MsgBoxStyle.Exclamation)
            Return
        End If

        ' Ambil Value dari ComboBox
        Dim idMatkul As String = CmbMatkul.SelectedValue.ToString()
        Dim usernameDosen As String = CmbDosen.SelectedValue.ToString()
        Dim idJadwal As String = Me.Tag.ToString()

        Try
            Dim postData As String = "action=update" &
                                     "&id_jadwal=" & HttpUtility.UrlEncode(idJadwal) & ' Kunci
                                     "&id_matkul=" & HttpUtility.UrlEncode(idMatkul) &
                                     "&username_dosen=" & HttpUtility.UrlEncode(usernameDosen) &
                                     "&kelas=" & HttpUtility.UrlEncode(TxtKelas.Text) &
                                     "&hari=" & HttpUtility.UrlEncode(CmbHari.Text) &
                                     "&jam_mulai=" & HttpUtility.UrlEncode(TxtJamMulai.Text) &
                                     "&jam_selesai=" & HttpUtility.UrlEncode(TxtJamSelesai.Text) &
                                     "&pengumuman=" & HttpUtility.UrlEncode(TxtPengumuman.Text)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, postData)
            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataJadwal()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "Server merespons error tanpa pesan spesifik.")
                MsgBox("Gagal mengedit jadwal: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses edit jadwal: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        If Me.Tag Is Nothing OrElse String.IsNullOrWhiteSpace(Me.Tag.ToString()) Then
            MsgBox("Pilih jadwal yang akan dihapus dari tabel.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim idJadwal As String = Me.Tag.ToString()

        If MsgBox("Yakin ingin menghapus jadwal ini?", MsgBoxStyle.YesNo, "Konfirmasi Hapus") = MsgBoxResult.No Then
            Return
        End If

        Try
            Dim postData As String = "action=delete" & "&id_jadwal=" & HttpUtility.UrlEncode(idJadwal)
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Jadwal, postData)
            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataJadwal()
                ResetForm()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "Server merespons error tanpa pesan spesifik.")
                MsgBox("Gagal menghapus jadwal: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses hapus jadwal: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class