Imports Newtonsoft.Json ' Wajib untuk memproses JSON
Imports System.Data    ' Digunakan untuk DataTable

Public Class dashboard

    ' ####################################################################
    ' #                       1. HELPER & UTILITY                        #
    ' ####################################################################

    ''' <summary>
    ''' Membersihkan semua kontrol input pada formulir.
    ''' </summary>
    Private Sub ClearForm()
        txtNIM.Clear()
        txtNama.Clear()
        txtAlamat.Clear()
        txtEmail.Clear()
        txtJK.Text = "" ' Asumsi txtJK adalah ComboBox atau TextBox
        txtJurusan.Text = "" ' Asumsi txtJurusan adalah ComboBox atau TextBox
        txtDate.Value = DateTime.Now ' Mengatur DateTimePicker ke tanggal hari ini
    End Sub

    ''' <summary>
    ''' Mempersiapkan dan mengirim data ke API, kemudian menampilkan hasilnya.
    ''' Fungsi ini menggantikan semua logika CRUD MySql.
    ''' </summary>
    ''' <param name="nim">Nomor Induk Mahasiswa (kunci utama).</param>
    ''' <param name="nama">Nama Mahasiswa.</param>
    ''' <param name="alamat">Alamat Mahasiswa.</param>
    ''' <param name="email">Email Mahasiswa.</param>
    ''' <param name="jenis_kelamin">Jenis Kelamin Mahasiswa.</param>
    ''' <param name="tgl_lahir">Tanggal Lahir Mahasiswa (format yyyy-MM-dd).</param>
    ''' <param name="jurusan">Jurusan Mahasiswa.</param>
    ''' <param name="operasi">Jenis operasi yang dilakukan (Simpan/Update/Hapus).</param>
    ''' <returns>String URL-encoded data untuk POST request.</returns>
    Private Function BuatDataPost(ByVal operasi As String) As String
        Dim data As String = ""

        ' Data ini digunakan untuk semua operasi (Simpan, Update, Hapus)
        data &= $"nim={txtNIM.Text}"

        ' Untuk Simpan dan Update, sertakan semua field
        If operasi = "Simpan" OrElse operasi = "Update" Then
            data &= $"&nama={txtNama.Text}"
            data &= $"&alamat={txtAlamat.Text}"
            data &= $"&email={txtEmail.Text}"
            data &= $"&jenis_kelamin={txtJK.Text}"
            data &= $"&tgl_lahir={txtDate.Value.ToString("yyyy-MM-dd")}"
            data &= $"&jurusan={txtJurusan.Text}"
        End If

        Return data
    End Function

    ' ####################################################################
    ' #                       2. FUNGSI READ DATA                        #
    ' ####################################################################

    ''' <summary>
    ''' Mengambil data Mahasiswa dari API dan memuatnya ke DataGridView.
    ''' </summary>
    Private Sub tampilData()
        Try
            ' *** PERBAIKAN: Memanggil GetJsonFromAPI() dengan parameter URL Mahasiswa yang benar ***
            Dim jsonResult As String = Koneksi.GetJsonFromAPI(Koneksi.ApiUrl_Mahasiswa_Read)

            If String.IsNullOrEmpty(jsonResult) Then
                dgvMahasiswa.DataSource = Nothing
                Exit Sub
            End If

            ' 2. Parsing JSON menjadi DataTable
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonResult)

            ' 3. Menampilkan data
            dgvMahasiswa.DataSource = dt

        Catch ex As Exception
            MsgBox("Data gagal ditampilkan dari API. Pesan: " & ex.Message, MsgBoxStyle.Information, "Error Tampil Data")
        End Try
    End Sub


    ' ####################################################################
    ' #                   3. EVENT HANDLER & CRUD API                    #
    ' ####################################################################

    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilData() ' Memuat data saat Form Dashboard dimuat
    End Sub

    ' --- FUNGSI INSERT (SIMPAN) ---
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' *** PERBAIKAN: Menggunakan URL CREATE Mahasiswa yang spesifik ***
        Dim url As String = Koneksi.ApiUrl_Mahasiswa_Create
        Dim postData As String = BuatDataPost("Simpan")

        ' Jika ada validasi, letakkan di sini.
        If txtNIM.Text = "" Then
            MsgBox("NIM tidak boleh kosong.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Try
            Dim apiResponse As String = Koneksi.KirimDataKeAPI(url, postData)

            ' Cek respons API dari PHP (Asumsi PHP mengembalikan JSON {"status": "sukses"})
            If apiResponse.Contains("sukses") Or apiResponse.Contains("Success") Then
                MsgBox("Data Berhasil Disimpan via API", MsgBoxStyle.Information, "Sukses")
            Else
                MsgBox("Data Gagal Disimpan. Respons API: " & apiResponse, MsgBoxStyle.Critical, "Gagal")
            End If

            tampilData()
            ClearForm()

        Catch ex As Exception
            MsgBox("Error saat menjalankan operasi Simpan: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' --- FUNGSI UPDATE (UBAH) ---
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ' *** PERBAIKAN: Menggunakan URL UPDATE Mahasiswa yang spesifik ***
        Dim url As String = Koneksi.ApiUrl_Mahasiswa_Update
        Dim postData As String = BuatDataPost("Update")

        If txtNIM.Text = "" Then
            MsgBox("Pilih data yang akan diupdate terlebih dahulu.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Try
            Dim apiResponse As String = Koneksi.KirimDataKeAPI(url, postData)

            If apiResponse.Contains("sukses") Or apiResponse.Contains("Success") Then
                MsgBox("Data Berhasil Diupdate via API", MsgBoxStyle.Information)
            Else
                MsgBox("Data Gagal Diupdate. Respons API: " & apiResponse, MsgBoxStyle.Critical)
            End If

            tampilData()
            ClearForm()

        Catch ex As Exception
            MsgBox("Error saat menjalankan operasi Update: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' --- FUNGSI DELETE (HAPUS) ---
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ' *** PERBAIKAN: Menggunakan URL DELETE Mahasiswa yang spesifik ***
        Dim url As String = Koneksi.ApiUrl_Mahasiswa_Delete
        Dim postData As String = BuatDataPost("Hapus")

        If txtNIM.Text = "" Then
            MsgBox("Pilih data yang akan dihapus terlebih dahulu.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Yakin ingin menghapus data NIM: " & txtNIM.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Konfirmasi Hapus") = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            Dim apiResponse As String = Koneksi.KirimDataKeAPI(url, postData)

            If apiResponse.Contains("sukses") Or apiResponse.Contains("Success") Then
                MsgBox("Data Berhasil Dihapus via API", MsgBoxStyle.Information)
            Else
                MsgBox("Data Gagal Dihapus. Respons API: " & apiResponse, MsgBoxStyle.Critical)
            End If

            tampilData()
            ClearForm()

        Catch ex As Exception
            MsgBox("Error saat menjalankan operasi Hapus: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' --- MEMUAT DATA KE FORM DARI GRID ---
    Private Sub dgvMahasiswa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMahasiswa.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvMahasiswa.Rows(e.RowIndex)

            ' Pastikan Cells tidak Null sebelum konversi
            If row.Cells("nim").Value IsNot Nothing Then
                txtNIM.Text = row.Cells("nim").Value.ToString()
                txtNama.Text = row.Cells("nama").Value.ToString()
                txtAlamat.Text = row.Cells("alamat").Value.ToString()
                txtEmail.Text = row.Cells("email").Value.ToString()
                txtJK.Text = row.Cells("jenis_kelamin").Value.ToString()

                ' Konversi tanggal dengan aman
                If row.Cells("tgl_lahir").Value IsNot Nothing Then
                    txtDate.Value = Convert.ToDateTime(row.Cells("tgl_lahir").Value)
                Else
                    txtDate.Value = DateTime.Now
                End If

                txtJurusan.Text = row.Cells("jurusan").Value.ToString()
            End If
        End If
    End Sub

End Class
