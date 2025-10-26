Imports Newtonsoft.Json ' Wajib untuk parsing JSON
Imports System.Data    ' Digunakan untuk DataTable (memproses hasil API)

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' 1. Ambil data JSON dari API
        ' *** PERBAIKAN: Menggunakan URL READ User yang spesifik dari Koneksi.vb ***
        Dim jsonUserData As String = Koneksi.GetJsonFromAPI(Koneksi.ApiUrl_User_Read)

        ' 2. Jika jsonUserData kosong, berarti ada error koneksi API
        If String.IsNullOrEmpty(jsonUserData) Then
            Exit Sub ' Keluar dari sub karena koneksi API gagal (error sudah ditangani di Koneksi.vb)
        End If

        Try
            Dim inputUser As String = txtUser.Text
            Dim inputPass As String = txtPass.Text

            ' 3. Deserialisasi JSON menjadi DataTable
            ' Ini adalah cara yang lebih aman dan terstruktur daripada hanya mencari string.
            Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonUserData)

            Dim loggedIn As Boolean = False

            ' 4. Cari kecocokan username dan password di dalam DataTable
            For Each row As DataRow In dt.Rows
                ' Asumsi kolom di tbl_user adalah 'username' dan 'password'
                If row("username").ToString() = inputUser AndAlso row("password").ToString() = inputPass Then
                    loggedIn = True
                    Exit For ' Keluar dari loop setelah user ditemukan
                End If
            Next

            If loggedIn Then
                ' LOGIKA LOGIN BERHASIL
                MsgBox("Login Berhasil", MsgBoxStyle.Information, "Sukses")

                ' Memastikan form muncul sebelum form ini disembunyikan
                Application.DoEvents()

                dashboard.Show()
                Me.Hide()
            Else
                MsgBox("Username atau Password salah.", MsgBoxStyle.Exclamation, "Gagal Login")
            End If

        Catch ex As Exception
            MsgBox("Terjadi Kesalahan saat memproses data. Detail: " & ex.Message, MsgBoxStyle.Critical, "Error Validasi")
        End Try

    End Sub
End Class
