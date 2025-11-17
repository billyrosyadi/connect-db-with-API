Imports Newtonsoft.Json 'import library external yang sudah di install via nuget , libarary ini berfungsi untuk mengelola data json
Imports Newtonsoft.Json.Linq 'merupakan bagian dari library newtonsoft.json yang berfungsi untuk mengelola data json yang dinamis

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'memanggil fungsi LoginKeAPI dari Module Koneksi menggunakan permintaan HTTP POST ke server
        Dim jsonResponse As String = Koneksi.LoginKeAPI(txtUser.Text, txtPass.Text)

        If String.IsNullOrEmpty(jsonResponse) Then Exit Sub

        Try
            'mengraikan JSON respons menggunakan Newtonsoft.Json JObject
            'hal ini akan secara langsung memuat JSON ke dalam objek yang dapat kita navigasi
            Dim result As JObject = JObject.Parse(jsonResponse)

            'mengecek status login ke server
            If result("status").ToString() = "success" Then

                Dim userRole As String = result("role").ToString() 'pendeklarasian variabel userRole untuk menyimpan peran pengguna dari respons API

                'memastikan userbane di isi
                Dim username As String = Nothing
                'bagaian pengaman ganda untuk memastikan bahawa username memiliki nilai yang valid dari server
                If result.ContainsKey("username") AndAlso result("username") IsNot Nothing Then
                    username = result("username").ToString() 'merubah nilai username menjadi string dan menyimpannya dalam variabel username untuk keperluan lanjut dalam inisiali sesi
                End If

                'jika bagian sebelumnya gagal mka akan lanjut ke bagian ini 
                If String.IsNullOrWhiteSpace(username) Then
                    MsgBox("anda berhasil login, tetapi API gagal mengembalikan ID Username. jadi periksa API Login PHP Anda.", MsgBoxStyle.Critical)
                    Exit Sub 'pada abagaian ini akan menghentikan proses jika username tidak memiliki nilai yang valid daris server
                End If

                'jika nilai yang sudah di validasi berhasil maka informasi sesi akan di simpan di module koneksi(properti global) yang nantinya akan berguna untuk mempertahankna status login pengguna pada seluruh form
                Koneksi.UserRole = userRole 'simpan nilai yang sudah divalidasi userRole sebagai koneksi.userRole
                Koneksi.LoggedInUsername = username 'simpan nilai yang sudah divalidasi username sebagai koneksi.loggedInUsername
                'bagian di bawah untuk menampilkan pesan sukses
                MsgBox("wuihh!.... berhasil login nih sebagai: " & userRole & ". Username: " & username, MsgBoxStyle.Information, "sukses")

                'jika sudah maka pada bagian ini akan melakukan pengecekan role pengguna dan mengarahkan ke dashboard yang sesuai
                Select Case userRole.ToLower()
                    Case "admin"
                        Dim adminDash As New DashboardAdmin()
                        adminDash.Show()
                    Case "dosen"
                        Dim dosenDash As New DashboardDosen()
                        dosenDash.Show()
                    Case "mahasiswa" 'khusus untuk role mahasiswa dan role lain akan diarahkan ke portal web
                        'membuat url lengkap yang akan membuka portal web mahasiswa dengan menyertakan parameter username
                        Dim url As String = Koneksi.PortalUrl_Mahasiswa & "?username=" & HttpUtility.UrlEncode(Koneksi.LoggedInUsername)

                        Try
                            'bagian ini untuk meluncurkan proses external baru yaitu membuka browser web default dengang url yang sudah di buat
                            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(url) With {.UseShellExecute = True})

                            MsgBox("anda akan di arahakan ke tempat seharusnya anda berada.", MsgBoxStyle.Information)
                        Catch ex As Exception
                            MsgBox($"waduh maaf ya sepertinya ada sedikit kesalahan ketika membuka jalan ke masa depan anda: {ex.Message}", MsgBoxStyle.Critical)
                        End Try

                        'setelah browser terbuka maka form login akan di tutup
                        Me.Close()

                    Case Else

                        Dim url As String = Koneksi.PortalUrl_Lain & "?username=" & HttpUtility.UrlEncode(Koneksi.LoggedInUsername)

                        MsgBox("anda? (" & userRole & ") kok saya timdak kenal.", MsgBoxStyle.Exclamation)

                        Try
                            System.Diagnostics.Process.Start(url) ' Buka browser
                        Catch ex As Exception
                            MsgBox($"gagal membuka gerbang waktu: {ex.Message}", MsgBoxStyle.Critical)
                        End Try


                        Me.Close()
                End Select

                Me.Hide()

            Else
                'jika login gagal maka pesan eror akan di tampilkan dari server API
                MsgBox(result("message").ToString(), MsgBoxStyle.Exclamation, "sayang sekali anda gagal dan timdak bisa lomgin. silahkan hubungi penyedia layanan untuk mengatasi msalah ini")
            End If

        Catch ex As Exception
            MsgBox("error pemrosesan data di aplikasi: " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
End Class