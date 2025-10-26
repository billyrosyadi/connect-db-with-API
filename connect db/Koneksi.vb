Imports System.Net
Imports System.Text
Imports System.Collections.Specialized ' Diperlukan untuk NameValueCollection

Module Koneksi

    ' 1. KONFIGURASI API (Ganti dengan URL Server Anda)
    ' Ganti alamat ini dengan alamat ngrok/server Anda yang aktif
    Public Const Url As String = "https://8ed8233ea798.ngrok-free.app"

    ' URL untuk endpoint Login yang sudah kita buat
    Public Const ApiUrl_User_Login As String = Url & "/API/login.php"

    ' Contoh URL untuk CRUD data mahasiswa (hanya sebagai referensi)
    Public Const ApiUrl_Mahasiswa_Read As String = Url & "/API/get_mahasiswa_data.php"

    ' API baru untuk mengelola Profil Dosen
    Public Const ApiUrl_Dosen_Profile As String = Url & "/API/manage_dosen_profile.php"

    ' ####################################################################
    ' #                     FUNGSI KHUSUS LOGIN API                      #
    ' ####################################################################

    ''' <summary>
    ''' Mengirim username dan password ke endpoint login menggunakan metode POST (UploadValues).
    ''' </summary>
    ''' <returns>String JSON respons dari API (status, message, role).</returns>
    Public Function LoginKeAPI(ByVal username As String, ByVal password As String) As String
        Dim responseResult As String = ""
        Try
            Using webClient As New WebClient()
                ' Siapkan data yang akan dikirim (key-value pair)
                Dim postData As New NameValueCollection()
                postData.Add("username", username)
                postData.Add("password", password)

                ' Kirim data ke API Login dan terima respons
                Dim responseBytes As Byte() = webClient.UploadValues(ApiUrl_User_Login, "POST", postData)

                ' Menggunakan UTF8 karena JSON umumnya menggunakan encoding ini
                responseResult = Encoding.UTF8.GetString(responseBytes)

            End Using
        Catch ex As Exception
            ' Tangani kesalahan koneksi (API offline, alamat salah, dll.)
            MessageBox.Show("Gagal Koneksi ke API Login: " & ApiUrl_User_Login & vbCrLf & "Pesan Error: " & ex.Message, "Error Login API", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return responseResult
    End Function

    ' --- DI DALAM MODULE KONEKSI ---

    ' ####################################################################
    ' #                     FUNGSI KHUSUS CRUD API                       #
    ' ####################################################################

    ''' <summary>
    ''' Mengambil data JSON dari API menggunakan metode GET (Digunakan untuk READ data).
    ''' </summary>
    ''' <param name="apiUrl">URL API lengkap, termasuk parameter GET.</param>
    ''' <returns>String JSON respons dari API.</returns>
    Public Function GetJsonFromAPI(ByVal apiUrl As String) As String
        Dim responseResult As String = ""
        Try
            Using webClient As New WebClient()
                ' Set encoding UTF8
                webClient.Encoding = Encoding.UTF8

                ' Unduh string JSON dari URL
                responseResult = webClient.DownloadString(apiUrl)
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal Koneksi ke API READ (" & apiUrl & "): " & vbCrLf & "Pesan Error: " & ex.Message, "Error API READ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return responseResult
    End Function


    ''' <summary>
    ''' Mengirim data ke API menggunakan metode POST (Digunakan untuk CREATE, UPDATE, DELETE).
    ''' </summary>
    ''' <param name="apiUrl">URL API lengkap.</param>
    ''' <param name="postData">String data yang akan dikirim, format: key1=value1&key2=value2</param>
    ''' <returns>String JSON respons dari API.</returns>
    Public Function KirimDataKeAPI(ByVal apiUrl As String, ByVal postData As String) As String
        Dim responseResult As String = ""
        Try
            Using webClient As New WebClient()
                ' Siapkan header untuk POST data
                webClient.Headers(HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"
                webClient.Encoding = Encoding.UTF8

                ' Konversi string POST data menjadi Byte array
                Dim postBytes As Byte() = Encoding.UTF8.GetBytes(postData)

                ' Kirim data ke API dan terima respons
                Dim responseBytes As Byte() = webClient.UploadData(apiUrl, "POST", postBytes)

                responseResult = Encoding.UTF8.GetString(responseBytes)
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal Koneksi ke API POST (" & apiUrl & "): " & vbCrLf & "Pesan Error: " & ex.Message, "Error API POST", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return responseResult
    End Function

    ' --- End Module diletakkan di bagian akhir file ---

End Module