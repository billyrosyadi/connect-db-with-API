Imports System.Net ' Digunakan untuk WebClient (akses web/API)
Imports System.Text ' Digunakan untuk Encoding data
Imports System.Data ' Dipertahankan (Jika nanti perlu DataTable untuk parsing JSON)

Module Koneksi

    ' ####################################################################
    ' #                       1. KONFIGURASI API                         #
    ' ####################################################################

    ' URL Dasar Ngrok/Server API (Ganti dengan URL yang AKTIF)
    Public Const NgrokBaseUrl As String = "https://8ed8233ea798.ngrok-free.app"

    ' Catatan: Path /API/ dipertahankan sesuai konfigurasi Anda.

    ' --------------------------------------------------------------------
    ' FORM DASHBOARD (TBL_MAHASISWA)
    ' --------------------------------------------------------------------
    Public Const ApiUrl_Mahasiswa_Read As String = NgrokBaseUrl & "/API/get_mahasiswa_data.php"
    Public Const ApiUrl_Mahasiswa_Create As String = NgrokBaseUrl & "/API/simpan_data.php"
    Public Const ApiUrl_Mahasiswa_Update As String = NgrokBaseUrl & "/API/update_data.php"
    Public Const ApiUrl_Mahasiswa_Delete As String = NgrokBaseUrl & "/API/hapus_data.php"

    ' --------------------------------------------------------------------
    ' UNTUK FORM LAIN (FORM1.VB - TBL_USER)
    ' --------------------------------------------------------------------
    Public Const ApiUrl_User_Read As String = NgrokBaseUrl & "/API/get_user_data.php"
    ' Tambahkan konstanta CRUD lain di sini jika dibutuhkan oleh Form1
    ' Public Const ApiUrl_User_Create As String = NgrokBaseUrl & "/API/simpan_user.php"

    ' ####################################################################
    ' #                    2. FUNGSI KONEKSI API (FLEKSIBEL)             #
    ' ####################################################################

    ''' <summary>
    ''' Mengambil data (Biasanya JSON) dari API menggunakan metode GET.
    ''' Fungsi ini Fleksibel karena menerima URL sebagai parameter.
    ''' </summary>
    ''' <param name="apiUrl">URL endpoint API tujuan (Contoh: ApiUrl_Mahasiswa_Read atau ApiUrl_User_Read).</param>
    ''' <returns>String JSON hasil respons dari API. Kosong jika gagal.</returns>
    Public Function GetJsonFromAPI(ByVal apiUrl As String) As String
        Dim jsonResult As String = ""
        Try
            Using webClient As New WebClient()
                ' Menggunakan WebClient untuk mengunduh string dari URL yang diberikan
                jsonResult = webClient.DownloadString(apiUrl)
            End Using
        Catch ex As Exception
            ' Tangani error saat koneksi atau URL bermasalah
            MessageBox.Show("Gagal Akses API/URL: " & apiUrl & vbCrLf & "Pesan Error: " & ex.Message, "Error Koneksi API", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return jsonResult
    End Function


    ''' <summary>
    ''' Mengirim data ke API menggunakan metode POST (untuk CREATE, UPDATE, DELETE).
    ''' </summary>
    ''' <param name="url">URL endpoint API tujuan (Contoh: ApiUrl_Mahasiswa_Create).</param>
    ''' <param name="postData">Data yang akan dikirim dalam format URL-encoded (Contoh: "nim=123&nama=Budi").</param>
    ''' <returns>String respons dari API (Biasanya JSON/pesan status).</returns>
    Public Function KirimDataKeAPI(ByVal url As String, ByVal postData As String) As String
        Dim responseResult As String = ""
        Try
            Using webClient As New WebClient()
                ' Set header untuk memberitahu server bahwa kita mengirimkan form data
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded")

                ' Ubah string data menjadi array byte menggunakan ASCII encoding
                Dim byteArray As Byte() = System.Text.Encoding.ASCII.GetBytes(postData)

                ' Kirim data menggunakan metode POST
                Dim responseArray As Byte() = webClient.UploadData(url, "POST", byteArray)

                ' Ubah respons server kembali menjadi string
                responseResult = System.Text.Encoding.ASCII.GetString(responseArray)
            End Using

        Catch ex As Exception
            ' Tangani error saat pengiriman data
            MessageBox.Show("Gagal Kirim Data ke API URL: " & url & vbCrLf & "Pesan Error: " & ex.Message, "Error Kirim API", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return responseResult
    End Function

End Module
