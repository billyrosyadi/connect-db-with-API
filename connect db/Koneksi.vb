Imports System.Net 'diperlukan untuk webclient atau httpwebrequest yang intinya untuk melakukan request ke server API
Imports System.Text 'di gunakan untuk memanipulasi string karakter
Imports System.Collections.Specialized 'di gunakan untuk menyiapkan parameter permintaan


Module Koneksi
    'mendeklarasikan variabel untuk keprluan koneksi'.
    Public LoggedInUsername As String = ""
    Public UserRole As String = ""
    'KONFIGURASI API
    'pada bagian ini akan di definisikan url untuk rujukan API yang akan di gunakan
    Public Const Url As String = "https://8ed8233ea798.ngrok-free.app"
    'path lengkap untuk API login
    Public Const ApiUrl_User_Login As String = Url & "/API/login.php"
    'path lengkap untuk API membaca data 
    Public Const ApiUrl_Mahasiswa_Read As String = Url & "/API/get_mahasiswa_data.php"

    'path lengkap untuk API membaca data dosen pada form kelola dosen
    Public Const ApiUrl_Dosen_Profile As String = Url & "/API/manage_dosen_profile.php"
    'path lengkap untuk API membaca data mahasiswa pada form kelola mahasiswa
    Public Const ApiUrl_Mahasiswa_Profile As String = Url & "/API/manage_mahasiswa_profile.php"
    'path lengkap untuk API mengelola akun pengguna pada form kelola akun
    Public Const ApiUrl_Kelola_Akun As String = Url & "/API/manage_user_profile.php"
    'path lengkap untuk API mengelola jadwal pada form kelola jadwal
    Public Const ApiUrl_Kelola_Jadwal As String = Url & "/API/manage_jadwal.php"
    'path lengkap untuk API mengelola ruangan pada form kelola ruangan 
    Public Const ApiUrl_Kelola_Ruangan As String = Url & "/API/manage_ruangan.php"
    'path lengkap untuk API mengelola absensi pada form absensi dosen
    Public Const ApiUrl_Kelola_Absensi As String = Url & "/API/manage_absensi.php"
    'portal web cusus mahasiswa
    Public Const PortalUrl_Mahasiswa As String = Url & "/dp/mahasiswa.php"
    'portal web cusus yang lain
    Public Const PortalUrl_Lain As String = Url & "dp/orang_luar.php"
    'BAGIAN LOGIN
    Public Function LoginKeAPI(ByVal username As String, ByVal password As String) As String
        Dim responseResult As String = ""
        Try
            Using webClient As New WebClient()
                'iapkan data yang akan dikirim ke server berupa username dan password untuk keperluan verifikasi login
                Dim postData As New NameValueCollection()
                postData.Add("username", username)
                postData.Add("password", password)
                'kirim data ke API Login dan terima respons
                Dim responseBytes As Byte() = webClient.UploadValues(ApiUrl_User_Login, "POST", postData)
                responseResult = Encoding.UTF8.GetString(responseBytes)
            End Using
        Catch ex As Exception
            'jika terjadi error saat koneksi ke API login, tampilkan pesan error
            MessageBox.Show("Gagal Koneksi ke API Login: " & ApiUrl_User_Login & vbCrLf & "Pesan Error: " & ex.Message, "Error Login API", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return responseResult
    End Function
    'di dalam module koneksi.vb ini akan di tambahkan fungsi khusus untuk keperluan CRUD API
    'Mengambil data JSON dari API menggunakan metode GET di gunakan untuk READ data URL API lengkap,dan mengembalikannya sebagai string teks
    Public Function GetJsonFromAPI(ByVal apiUrl As String) As String
        'memastikan variabel memiliki nilai yang jelas sebelum digunakan di blok Try
        Dim responseResult As String = ""
        'seluruh operasi pengunduhan data ditempatkan di dalam blok try-catch di bawah ini
        Try
            'membuat objek baru dari kelas webclient untuk melakukan request ke server API
            Using webClient As New WebClient()
                'bagian di bawah ini di mengatur encoding yang akan di gunakan untuk membaca data yang di unduh dari server API
                webClient.Encoding = Encoding.UTF8
                'bagian di gunakan untuk mengunduh string JSON dari URL API
                responseResult = webClient.DownloadString(apiUrl)
            End Using
            'pada bagian bawah jika terjadi error selama proses koneksi ke API READ, tangkap exception dan tampilkan pesan error
        Catch ex As Exception
            MessageBox.Show("Gagal Koneksi ke API READ (" & apiUrl & "): " & vbCrLf & "Pesan Error: " & ex.Message, "Error API READ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return responseResult
    End Function
    'mengirim data ke API menggunakan metode POST digunakan untuk CREATE, UPDATE, DELETE
    Public Function KirimDataKeAPI(ByVal apiUrl As String, ByVal postData As String) As String
        'memastikan variabel memiliki nilai yang jelas sebelum digunakan di blok Try
        Dim responseResult As String = ""
        Try
            'membuat objek baru dari kelas webclient untuk menangani koneksi jaringan 
            Using webClient As New System.Net.WebClient()
                'pada baris di bawah ini memberi tahu server bahawa data yang di kirim berbentuk data formulir web tradisional(untuk jelasnya sillahkan browsing sendiri)
                webClient.Headers(System.Net.HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"
                'mengatur encoding yang akan di gunakan untuk mengirim dan menerima data dari server API
                webClient.Encoding = System.Text.Encoding.UTF8

                Dim postBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(postData)
                'pada baris di bawah ini mengirim data POST ke server API dan menerima respons
                Dim responseBytes As Byte() = webClient.UploadData(apiUrl, "POST", postBytes)

                responseResult = System.Text.Encoding.UTF8.GetString(responseBytes)
            End Using
            Return responseResult

        Catch ex As Exception 'menangkap error yang terjadi selama proses koneksi ke API POST
            MessageBox.Show("Gagal Koneksi ke API POST (" & apiUrl & "): " & vbCrLf & "Pesan Error: " & ex.Message, "Error API POST", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function
End Module