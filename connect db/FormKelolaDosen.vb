Imports System.Web
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data
Public Class FormKelolaDosen
    Private Sub FormKelolaDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Inisialisasi ComboBox Jenis Kelamin
        CmbKelamin.Items.Add("Laki-laki")
        CmbKelamin.Items.Add("Perempuan")
        CmbKelamin.SelectedIndex = 0 ' Pilih default

        ' 2. Tampilkan Data Dosen
        TampilkanDataDosen()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        TampilkanDataDosen()
    End Sub

    Public Sub TampilkanDataDosen()
        Try
            ' 1. Panggil API dengan action=read (Asumsi Koneksi.ApiUrl_Dosen_Profile sudah ada)
            Dim apiUrlRead As String = Koneksi.ApiUrl_Dosen_Profile & "?action=read"
            Dim jsonProfileData As String = Koneksi.GetJsonFromAPI(apiUrlRead)

            If String.IsNullOrEmpty(jsonProfileData) Then
                DgvDosen.DataSource = Nothing
                Return
            End If

            ' 2. Deserialisasi JSON ke DataTable
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonProfileData)

            ' 3. Bind data ke DataGridView
            DgvDosen.DataSource = dt
            DgvDosen.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("Error saat memuat data dosen: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        If TxtUsername.Text = "" Or TxtNama.Text = "" Then
            MsgBox("Username/ID dan Nama wajib diisi.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            ' 1. Siapkan data POST (Menggunakan HttpUtility.UrlEncode untuk keamanan)
            Dim postData As String = "action=create" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                     "&nama_lengkap=" & HttpUtility.UrlEncode(TxtNama.Text) &
                                     "&tempat_lahir=" & HttpUtility.UrlEncode(TxtTempatLahir.Text) &
                                     "&tanggal_lahir=" & DtTanggalLahir.Value.ToString("yyyy-MM-dd") &
                                     "&email=" & HttpUtility.UrlEncode(TxtEmail.Text) &
                                     "&jenis_kelamin=" & HttpUtility.UrlEncode(CmbKelamin.Text)

            ' 2. Kirim data ke API
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Dosen_Profile, postData)

            ' 3. Uraikan respons JSON
            Dim result As JObject = JObject.Parse(responseJson)

            If result("status").ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataDosen() ' Muat ulang data

                ' Bersihkan input
                TxtUsername.Clear()
                TxtNama.Clear()
                TxtTempatLahir.Clear()
                TxtEmail.Clear()

            Else
                MsgBox("Gagal menambah profil: " & result("message").ToString(), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses tambah data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnKembali_Click(sender As Object, e As EventArgs) Handles BtnKembali.Click
        Me.Close()
    End Sub

    Private Sub DgvDosen_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDosen.CellContentClick
        If e.RowIndex >= 0 Then
            Try
                ' Ambil baris data yang diklik
                Dim row As DataGridViewRow = DgvDosen.Rows(e.RowIndex)

                ' Isi setiap control input dengan data dari kolom yang sesuai
                ' Catatan: Pastikan nama kolom di API (misal: 'username') cocok dengan DataGridView
                TxtUsername.Text = row.Cells("username").Value.ToString()
                TxtNama.Text = row.Cells("nama_lengkap").Value.ToString()
                TxtTempatLahir.Text = row.Cells("tempat_lahir").Value.ToString()

                ' Mengisi DateTimePicker
                DtTanggalLahir.Value = CDate(row.Cells("tanggal_lahir").Value) ' Gunakan CDate untuk konversi tanggal

                TxtEmail.Text = row.Cells("email").Value.ToString()
                CmbKelamin.Text = row.Cells("jenis_kelamin").Value.ToString()

                ' Setelah data diisi, kita kunci TxtUsername agar tidak bisa diubah (Username adalah kunci unik/Primary Key)
                TxtUsername.Enabled = False

            Catch ex As Exception
                MsgBox("Error saat memilih data: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If TxtUsername.Enabled = True Then
            MsgBox("Pilih data dosen dari tabel di bawah terlebih dahulu.", MsgBoxStyle.Information)
            Return
        End If

        If TxtNama.Text = "" Then
            MsgBox("Nama wajib diisi.", MsgBoxStyle.Exclamation)
            Return
        End If

        ' Konfirmasi sebelum update
        If MsgBox("Apakah Anda yakin ingin MENGEDIT data " & TxtNama.Text & "?", MsgBoxStyle.YesNo, "Konfirmasi Edit") = MsgBoxResult.No Then
            Return
        End If

        Try
            ' Siapkan data POST untuk action=update
            Dim postData As String = "action=update" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                     "&nama_lengkap=" & HttpUtility.UrlEncode(TxtNama.Text) &
                                     "&tempat_lahir=" & HttpUtility.UrlEncode(TxtTempatLahir.Text) &
                                     "&tanggal_lahir=" & DtTanggalLahir.Value.ToString("yyyy-MM-dd") &
                                     "&email=" & HttpUtility.UrlEncode(TxtEmail.Text) &
                                     "&jenis_kelamin=" & HttpUtility.UrlEncode(CmbKelamin.Text)

            ' Kirim data ke API
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Dosen_Profile, postData)

            Dim result As JObject = JObject.Parse(responseJson)

            If result("status").ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses Edit")
                TampilkanDataDosen() ' Muat ulang data

                ' Kembalikan Form ke mode Tambah/Create
                ResetForm()

            Else
                MsgBox("Gagal mengedit profil: " & result("message").ToString(), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses edit data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        If TxtUsername.Enabled = True Then
            MsgBox("Pilih data dosen dari tabel di bawah terlebih dahulu untuk dihapus.", MsgBoxStyle.Information)
            Return
        End If

        ' Konfirmasi sebelum hapus
        If MsgBox("Apakah Anda yakin ingin MENGHAPUS data " & TxtNama.Text & " (" & TxtUsername.Text & ")?", MsgBoxStyle.YesNo, "Konfirmasi Hapus") = MsgBoxResult.No Then
            Return
        End If

        Try
            ' Siapkan data POST untuk action=delete
            ' Hanya butuh username sebagai kunci
            Dim postData As String = "action=delete" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text)

            ' Kirim data ke API
            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Dosen_Profile, postData)

            Dim result As JObject = JObject.Parse(responseJson)

            If result("status").ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses Hapus")
                TampilkanDataDosen() ' Muat ulang data

                ' Kembalikan Form ke mode Tambah/Create
                ResetForm()

            Else
                MsgBox("Gagal menghapus profil: " & result("message").ToString(), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses hapus data: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub ResetForm()
        ' Bersihkan semua input
        TxtUsername.Clear()
        TxtNama.Clear()
        TxtTempatLahir.Clear()
        TxtEmail.Clear()
        CmbKelamin.SelectedIndex = 0 ' Reset ke Laki-laki
        DtTanggalLahir.Value = DateTime.Now ' Reset Tanggal

        ' Aktifkan kembali input Username (kembali ke mode Create/Tambah)
        TxtUsername.Enabled = True
    End Sub
End Class