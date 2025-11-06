Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class FormKelolaAkun
    Private Sub TampilkanDataAkun()
        Try
            ' 1. Panggil API dengan action=read
            Dim apiUrlRead As String = Koneksi.ApiUrl_Kelola_Akun & "?action=read"
            Dim jsonProfileData As String = Koneksi.GetJsonFromAPI(apiUrlRead)

            If String.IsNullOrEmpty(jsonProfileData) Then
                DgvAkun.DataSource = Nothing
                Return
            End If

            ' 2. Deserialisasi JSON ke DataTable
            ' Error 'Expected StartArray, got StartObject' terjadi di baris ini 
            ' jika PHP mengembalikan pesan error BUKAN array data
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonProfileData)

            ' 3. Bind data ke DataGridView
            DgvAkun.DataSource = dt
            DgvAkun.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("Error saat memuat data akun: " & ex.Message &
                   vbCrLf & "Pastikan API READ Akun sudah benar (tidak ada Error 500/StartObject).", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub FormKelolaAkun_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilkanDataAkun()
        ' Isi ComboBox Role
        CmbRole.Items.AddRange(New Object() {"mahasiswa", "dosen"})
    End Sub

    Private Sub DgvAkun_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAkun.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DgvAkun.Rows(e.RowIndex)
            TxtUsername.Text = row.Cells("username").Value.ToString()
            CmbRole.Text = row.Cells("role").Value.ToString()
            TxtUsername.Enabled = False ' Kunci Username saat mode Edit/Hapus
        End If
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If TxtUsername.Text = "" Or CmbRole.Text = "" Then
            MsgBox("Pilih Username dan tentukan Role baru.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            Dim postData As String = "action=update_role" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                     "&role=" & HttpUtility.UrlEncode(CmbRole.Text)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Akun, postData)
            If String.IsNullOrEmpty(responseJson) Then Return

            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataAkun()
            Else
                ' Menggunakan sintaks VB.NET yang benar (If())
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "Server merespons error tanpa pesan spesifik.")
                MsgBox("Gagal mengubah Role: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses edit Role: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        If TxtUsername.Text = "" Then
            MsgBox("Pilih akun yang akan dihapus dari tabel.", MsgBoxStyle.Exclamation)
            Return
        End If

        If MsgBox("Yakin ingin menghapus akun '" & TxtUsername.Text & "'?", MsgBoxStyle.YesNo, "Konfirmasi Hapus") = MsgBoxResult.No Then
            Return
        End If

        Try
            Dim postData As String = "action=delete" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text)

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Akun, postData)

            If String.IsNullOrEmpty(responseJson) Then Return

            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataAkun()
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "Server merespons error tanpa pesan spesifik.")
                MsgBox("Gagal menghapus akun: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses hapus akun: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        If TxtUsername.Text = "" Or TxtPassword.Text = "" Then
            MsgBox("Username dan Password wajib diisi.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            ' Siapkan data POST
            Dim postData As String = "action=create" &
                                     "&username=" & HttpUtility.UrlEncode(TxtUsername.Text) &
                                     "&password=" & HttpUtility.UrlEncode(TxtPassword.Text) &
                                     "&role=" & HttpUtility.UrlEncode(CmbRole.Text) ' Ambil Role dari ComboBox

            Dim responseJson As String = Koneksi.KirimDataKeAPI(Koneksi.ApiUrl_Kelola_Akun, postData)
            If String.IsNullOrEmpty(responseJson) Then Return

            Dim result As JObject = JObject.Parse(responseJson.Trim())

            If result IsNot Nothing AndAlso result("status")?.ToString() = "success" Then
                MsgBox(result("message").ToString(), MsgBoxStyle.Information, "Sukses")
                TampilkanDataAkun() ' Refresh DGV
                ResetForm() ' Tambahkan prosedur ResetForm untuk membersihkan form
            Else
                Dim pesanError As String = If(result("message") IsNot Nothing, result("message").ToString(), "Server merespons error tanpa pesan spesifik.")
                MsgBox("Gagal menambahkan akun: " & pesanError, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Error saat proses tambah akun: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ResetForm()
        TxtUsername.Text = ""
        TxtPassword.Text = ""
        CmbRole.SelectedIndex = -1 ' Bersihkan pilihan
        TxtUsername.Enabled = True ' Aktifkan kembali input Username
    End Sub
End Class