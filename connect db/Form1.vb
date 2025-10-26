Imports Newtonsoft.Json ' Pastikan ini ada!
Imports Newtonsoft.Json.Linq ' Diperlukan untuk JObject (Parsing JSON)

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' 1. Panggil fungsi LoginKeAPI dari Module Koneksi
        Dim jsonResponse As String = Koneksi.LoginKeAPI(txtUser.Text, txtPass.Text)

        If String.IsNullOrEmpty(jsonResponse) Then Exit Sub

        Try
            ' 2. Uraikan (Parse) JSON Response menggunakan Newtonsoft.Json JObject
            ' Ini akan secara langsung memuat JSON ke dalam objek yang dapat kita navigasi
            Dim result As JObject = JObject.Parse(jsonResponse)

            ' 3. Cek Status Login dari Server
            If result("status").ToString() = "success" Then
                ' Ambil nilai role dari server
                Dim userRole As String = result("role").ToString()

                MsgBox("Login Berhasil! Sebagai: " & userRole, MsgBoxStyle.Information, "Sukses")

                ' 4. Arahkan ke Dashboard berdasarkan Peran (ROLE)
                Select Case userRole.ToLower()
                    Case "admin"
                        Dim adminDash As New DashboardAdmin()
                        adminDash.Show()
                    Case "dosen"
                        Dim dosenDash As New DashboardDosen()
                        dosenDash.Show()
                    Case "mahasiswa"
                        Dim mhsDash As New DashboardMahasiswa()
                        mhsDash.Show()
                    Case Else
                        MsgBox("Peran pengguna (" & userRole & ") tidak dikenali.", MsgBoxStyle.Exclamation)
                        Exit Sub
                End Select

                Me.Hide()

            Else
                ' Login Gagal, pesan error diambil dari server
                MsgBox(result("message").ToString(), MsgBoxStyle.Exclamation, "Gagal Login")
            End If

        Catch ex As Exception
            MsgBox("Error Pemrosesan Data di Aplikasi: " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
End Class