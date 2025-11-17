<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKelolaMahasiswa
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        DgvMahasiswa = New DataGridView()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label7 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        TxtUsername = New TextBox()
        TxtNama = New TextBox()
        TxtAlamat = New TextBox()
        TxtEmailMahasiswa = New TextBox()
        TxtTempatLahir = New TextBox()
        CmbKelamin = New ComboBox()
        CmbJurusan = New ComboBox()
        DtTanggalLahir = New DateTimePicker()
        Label6 = New Label()
        TxtTahunMasuk = New TextBox()
        BtnTambah = New Button()
        BtnEdit = New Button()
        BtnHapus = New Button()
        BtnRefresh = New Button()
        BtnKembali = New Button()
        Label8 = New Label()
        CmbKelas = New ComboBox()
        CType(DgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvMahasiswa
        ' 
        DgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvMahasiswa.Location = New Point(-11, 414)
        DgvMahasiswa.Name = "DgvMahasiswa"
        DgvMahasiswa.RowHeadersWidth = 51
        DgvMahasiswa.Size = New Size(1909, 554)
        DgvMahasiswa.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(37, 20)
        Label1.TabIndex = 1
        Label1.Text = "NIM"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 90)
        Label2.Name = "Label2"
        Label2.Size = New Size(57, 20)
        Label2.TabIndex = 2
        Label2.Text = "Alamat"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 55)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 20)
        Label3.TabIndex = 2
        Label3.Text = "Nama"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 127)
        Label4.Name = "Label4"
        Label4.Size = New Size(63, 20)
        Label4.TabIndex = 3
        Label4.Text = "Kelamin"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(941, 19)
        Label5.Name = "Label5"
        Label5.Size = New Size(95, 20)
        Label5.TabIndex = 4
        Label5.Text = "Tempat Lahir"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(941, 91)
        Label7.Name = "Label7"
        Label7.Size = New Size(104, 20)
        Label7.TabIndex = 6
        Label7.Text = "Program Studi"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(941, 55)
        Label9.Name = "Label9"
        Label9.Size = New Size(97, 20)
        Label9.TabIndex = 5
        Label9.Text = "Tanggal Lahir"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(12, 163)
        Label10.Name = "Label10"
        Label10.Size = New Size(46, 20)
        Label10.TabIndex = 9
        Label10.Text = "Email"
        ' 
        ' TxtUsername
        ' 
        TxtUsername.Location = New Point(114, 16)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(667, 27)
        TxtUsername.TabIndex = 10
        ' 
        ' TxtNama
        ' 
        TxtNama.Location = New Point(114, 55)
        TxtNama.Name = "TxtNama"
        TxtNama.Size = New Size(667, 27)
        TxtNama.TabIndex = 11
        ' 
        ' TxtAlamat
        ' 
        TxtAlamat.Location = New Point(114, 91)
        TxtAlamat.Name = "TxtAlamat"
        TxtAlamat.Size = New Size(667, 27)
        TxtAlamat.TabIndex = 12
        ' 
        ' TxtEmailMahasiswa
        ' 
        TxtEmailMahasiswa.Location = New Point(114, 163)
        TxtEmailMahasiswa.Name = "TxtEmailMahasiswa"
        TxtEmailMahasiswa.Size = New Size(667, 27)
        TxtEmailMahasiswa.TabIndex = 13
        ' 
        ' TxtTempatLahir
        ' 
        TxtTempatLahir.Location = New Point(1083, 19)
        TxtTempatLahir.Name = "TxtTempatLahir"
        TxtTempatLahir.Size = New Size(742, 27)
        TxtTempatLahir.TabIndex = 14
        ' 
        ' CmbKelamin
        ' 
        CmbKelamin.FormattingEnabled = True
        CmbKelamin.Items.AddRange(New Object() {"Laki-laki", "Perempuan"})
        CmbKelamin.Location = New Point(114, 127)
        CmbKelamin.Name = "CmbKelamin"
        CmbKelamin.Size = New Size(667, 28)
        CmbKelamin.TabIndex = 15
        ' 
        ' CmbJurusan
        ' 
        CmbJurusan.FormattingEnabled = True
        CmbJurusan.Items.AddRange(New Object() {"S3 Teknik Keperawatan", "S2 Sastra Informatika", "S1 Pendidikan Agama Islam", "S2 Arsitektur lanskap", "S1 Teknik Biologi Tumbuhan", "D3 Sistem Kelautan Tropika", "S1 Entomologi", "S2 Entomologi", "S3 Entomologi", "S1 Ilmu Aquakultur", "S2 Ilmu Aquakultur", "S1 Ilmu Biomedis Hewan", "S3 Teknik Perhutanan", "S3 Sastra Kelautan", "S1 Ilmu Tanah", "S1 Mikrobiologi", "S1 Krimatologi Terapan", "S2 Primatologi", "S1 Statistika Terapan", "S2 Teknologi Kelautan", "S3 Teknologi Pangan", "S1 Astronomi", "S2 Astronomi", "S3 Astronomi", "S1 Farmasi", "S2 Farmasi ", "S3 Farmasi", "S1 Biologi Reproduksi", "S2 Ilmu Forensik", "S3 Ilmu Bio Medis"})
        CmbJurusan.Location = New Point(1083, 91)
        CmbJurusan.Name = "CmbJurusan"
        CmbJurusan.Size = New Size(742, 28)
        CmbJurusan.TabIndex = 16
        ' 
        ' DtTanggalLahir
        ' 
        DtTanggalLahir.Location = New Point(1083, 55)
        DtTanggalLahir.Name = "DtTanggalLahir"
        DtTanggalLahir.Size = New Size(250, 27)
        DtTanggalLahir.TabIndex = 17
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(941, 127)
        Label6.Name = "Label6"
        Label6.Size = New Size(93, 20)
        Label6.TabIndex = 18
        Label6.Text = "Tahun Masuk"
        ' 
        ' TxtTahunMasuk
        ' 
        TxtTahunMasuk.Location = New Point(1083, 125)
        TxtTahunMasuk.Name = "TxtTahunMasuk"
        TxtTahunMasuk.Size = New Size(742, 27)
        TxtTahunMasuk.TabIndex = 19
        ' 
        ' BtnTambah
        ' 
        BtnTambah.Location = New Point(114, 220)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(94, 29)
        BtnTambah.TabIndex = 20
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = True
        ' 
        ' BtnEdit
        ' 
        BtnEdit.Location = New Point(244, 220)
        BtnEdit.Name = "BtnEdit"
        BtnEdit.Size = New Size(94, 29)
        BtnEdit.TabIndex = 21
        BtnEdit.Text = "Edit"
        BtnEdit.UseVisualStyleBackColor = True
        ' 
        ' BtnHapus
        ' 
        BtnHapus.Location = New Point(368, 220)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(94, 29)
        BtnHapus.TabIndex = 22
        BtnHapus.Text = "hapus"
        BtnHapus.UseVisualStyleBackColor = True
        ' 
        ' BtnRefresh
        ' 
        BtnRefresh.Location = New Point(505, 220)
        BtnRefresh.Name = "BtnRefresh"
        BtnRefresh.Size = New Size(94, 29)
        BtnRefresh.TabIndex = 23
        BtnRefresh.Text = "Refresh"
        BtnRefresh.UseVisualStyleBackColor = True
        ' 
        ' BtnKembali
        ' 
        BtnKembali.Location = New Point(640, 220)
        BtnKembali.Name = "BtnKembali"
        BtnKembali.Size = New Size(94, 29)
        BtnKembali.TabIndex = 24
        BtnKembali.Text = "Kembali"
        BtnKembali.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(941, 170)
        Label8.Name = "Label8"
        Label8.Size = New Size(44, 20)
        Label8.TabIndex = 25
        Label8.Text = "Kelas"
        ' 
        ' CmbKelas
        ' 
        CmbKelas.FormattingEnabled = True
        CmbKelas.Items.AddRange(New Object() {"1a", "1b", "1c", "1d"})
        CmbKelas.Location = New Point(1083, 167)
        CmbKelas.Name = "CmbKelas"
        CmbKelas.Size = New Size(742, 28)
        CmbKelas.TabIndex = 26
        ' 
        ' FormKelolaMahasiswa
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1896, 967)
        Controls.Add(CmbKelas)
        Controls.Add(Label8)
        Controls.Add(BtnKembali)
        Controls.Add(BtnRefresh)
        Controls.Add(BtnHapus)
        Controls.Add(BtnEdit)
        Controls.Add(BtnTambah)
        Controls.Add(TxtTahunMasuk)
        Controls.Add(Label6)
        Controls.Add(DtTanggalLahir)
        Controls.Add(CmbJurusan)
        Controls.Add(CmbKelamin)
        Controls.Add(TxtTempatLahir)
        Controls.Add(TxtEmailMahasiswa)
        Controls.Add(TxtAlamat)
        Controls.Add(TxtNama)
        Controls.Add(TxtUsername)
        Controls.Add(Label10)
        Controls.Add(Label7)
        Controls.Add(Label9)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(DgvMahasiswa)
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MdiChildrenMinimizedAnchorBottom = False
        MinimumSize = New Size(1918, 1018)
        Name = "FormKelolaMahasiswa"
        Text = "FormKelolaMahasiswa"
        WindowState = FormWindowState.Maximized
        CType(DgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DgvMahasiswa As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents TxtNama As TextBox
    Friend WithEvents TxtAlamat As TextBox
    Friend WithEvents TxtEmailMahasiswa As TextBox
    Friend WithEvents TxtTempatLahir As TextBox
    Friend WithEvents CmbKelamin As ComboBox
    Friend WithEvents CmbJurusan As ComboBox
    Friend WithEvents DtTanggalLahir As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtTahunMasuk As TextBox
    Friend WithEvents BtnTambah As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents BtnRefresh As Button
    Friend WithEvents BtnKembali As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents CmbKelas As ComboBox
End Class
