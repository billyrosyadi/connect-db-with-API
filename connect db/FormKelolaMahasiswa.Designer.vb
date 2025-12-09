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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKelolaMahasiswa))
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
        DgvMahasiswa.Location = New Point(0, 222)
        DgvMahasiswa.Margin = New Padding(3, 2, 3, 2)
        DgvMahasiswa.Name = "DgvMahasiswa"
        DgvMahasiswa.RowHeadersWidth = 51
        DgvMahasiswa.Size = New Size(1198, 339)
        DgvMahasiswa.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.White
        Label1.BorderStyle = BorderStyle.Fixed3D
        Label1.Font = New Font("Tahoma", 9.75F)
        Label1.ForeColor = Color.DarkGoldenrod
        Label1.Location = New Point(10, 14)
        Label1.Name = "Label1"
        Label1.Size = New Size(31, 18)
        Label1.TabIndex = 1
        Label1.Text = "NIM"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.White
        Label2.BorderStyle = BorderStyle.Fixed3D
        Label2.Font = New Font("Tahoma", 9.75F)
        Label2.ForeColor = Color.DarkGoldenrod
        Label2.Location = New Point(10, 68)
        Label2.Name = "Label2"
        Label2.Size = New Size(49, 18)
        Label2.TabIndex = 2
        Label2.Text = "Alamat"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.White
        Label3.BorderStyle = BorderStyle.Fixed3D
        Label3.Font = New Font("Tahoma", 9.75F)
        Label3.ForeColor = Color.DarkGoldenrod
        Label3.Location = New Point(10, 41)
        Label3.Name = "Label3"
        Label3.Size = New Size(42, 18)
        Label3.TabIndex = 2
        Label3.Text = "Nama"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.White
        Label4.BorderStyle = BorderStyle.Fixed3D
        Label4.Font = New Font("Tahoma", 9.75F)
        Label4.ForeColor = Color.DarkGoldenrod
        Label4.Location = New Point(10, 95)
        Label4.Name = "Label4"
        Label4.Size = New Size(54, 18)
        Label4.TabIndex = 3
        Label4.Text = "Kelamin"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Tahoma", 9.75F)
        Label5.ForeColor = Color.DarkGoldenrod
        Label5.Location = New Point(689, 16)
        Label5.Name = "Label5"
        Label5.Size = New Size(83, 16)
        Label5.TabIndex = 4
        Label5.Text = "Tempat Lahir"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Tahoma", 9.75F)
        Label7.ForeColor = Color.DarkGoldenrod
        Label7.Location = New Point(689, 72)
        Label7.Name = "Label7"
        Label7.Size = New Size(89, 16)
        Label7.TabIndex = 6
        Label7.Text = "Program Studi"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Tahoma", 9.75F)
        Label9.ForeColor = Color.DarkGoldenrod
        Label9.Location = New Point(689, 48)
        Label9.Name = "Label9"
        Label9.Size = New Size(85, 16)
        Label9.TabIndex = 5
        Label9.Text = "Tanggal Lahir"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.White
        Label10.BorderStyle = BorderStyle.Fixed3D
        Label10.Font = New Font("Tahoma", 9.75F)
        Label10.ForeColor = Color.DarkGoldenrod
        Label10.Location = New Point(10, 122)
        Label10.Name = "Label10"
        Label10.Size = New Size(40, 18)
        Label10.TabIndex = 9
        Label10.Text = "Email"
        ' 
        ' TxtUsername
        ' 
        TxtUsername.Location = New Point(100, 12)
        TxtUsername.Margin = New Padding(3, 2, 3, 2)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(542, 23)
        TxtUsername.TabIndex = 10
        ' 
        ' TxtNama
        ' 
        TxtNama.Location = New Point(100, 41)
        TxtNama.Margin = New Padding(3, 2, 3, 2)
        TxtNama.Name = "TxtNama"
        TxtNama.Size = New Size(542, 23)
        TxtNama.TabIndex = 11
        ' 
        ' TxtAlamat
        ' 
        TxtAlamat.Location = New Point(100, 68)
        TxtAlamat.Margin = New Padding(3, 2, 3, 2)
        TxtAlamat.Name = "TxtAlamat"
        TxtAlamat.Size = New Size(542, 23)
        TxtAlamat.TabIndex = 12
        ' 
        ' TxtEmailMahasiswa
        ' 
        TxtEmailMahasiswa.Location = New Point(100, 122)
        TxtEmailMahasiswa.Margin = New Padding(3, 2, 3, 2)
        TxtEmailMahasiswa.Name = "TxtEmailMahasiswa"
        TxtEmailMahasiswa.Size = New Size(542, 23)
        TxtEmailMahasiswa.TabIndex = 13
        ' 
        ' TxtTempatLahir
        ' 
        TxtTempatLahir.Location = New Point(787, 14)
        TxtTempatLahir.Margin = New Padding(3, 2, 3, 2)
        TxtTempatLahir.Name = "TxtTempatLahir"
        TxtTempatLahir.Size = New Size(402, 23)
        TxtTempatLahir.TabIndex = 14
        ' 
        ' CmbKelamin
        ' 
        CmbKelamin.FormattingEnabled = True
        CmbKelamin.Location = New Point(100, 95)
        CmbKelamin.Margin = New Padding(3, 2, 3, 2)
        CmbKelamin.Name = "CmbKelamin"
        CmbKelamin.Size = New Size(542, 23)
        CmbKelamin.TabIndex = 15
        ' 
        ' CmbJurusan
        ' 
        CmbJurusan.FormattingEnabled = True
        CmbJurusan.Items.AddRange(New Object() {"S3 Teknik Keperawatan", "S2 Sastra Informatika", "S1 Pendidikan Agama Islam", "S2 Arsitektur lanskap", "S1 Teknik Biologi Tumbuhan", "D3 Sistem Kelautan Tropika", "S1 Entomologi", "S2 Entomologi", "S3 Entomologi", "S1 Ilmu Aquakultur", "S2 Ilmu Aquakultur", "S1 Ilmu Biomedis Hewan", "S3 Teknik Perhutanan", "S3 Sastra Kelautan", "S1 Ilmu Tanah", "S1 Mikrobiologi", "S1 Krimatologi Terapan", "S2 Primatologi", "S1 Statistika Terapan", "S2 Teknologi Kelautan", "S3 Teknologi Pangan", "S1 Astronomi", "S2 Astronomi", "S3 Astronomi", "S1 Farmasi", "S2 Farmasi ", "S3 Farmasi", "S1 Biologi Reproduksi", "S2 Ilmu Forensik", "S3 Ilmu Bio Medis"})
        CmbJurusan.Location = New Point(787, 70)
        CmbJurusan.Margin = New Padding(3, 2, 3, 2)
        CmbJurusan.Name = "CmbJurusan"
        CmbJurusan.Size = New Size(402, 23)
        CmbJurusan.TabIndex = 16
        ' 
        ' DtTanggalLahir
        ' 
        DtTanggalLahir.Cursor = Cursors.Hand
        DtTanggalLahir.Location = New Point(787, 43)
        DtTanggalLahir.Margin = New Padding(3, 2, 3, 2)
        DtTanggalLahir.Name = "DtTanggalLahir"
        DtTanggalLahir.Size = New Size(206, 23)
        DtTanggalLahir.TabIndex = 17
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Tahoma", 9.75F)
        Label6.ForeColor = Color.DarkGoldenrod
        Label6.Location = New Point(689, 99)
        Label6.Name = "Label6"
        Label6.Size = New Size(83, 16)
        Label6.TabIndex = 18
        Label6.Text = "Tahun Masuk"
        ' 
        ' TxtTahunMasuk
        ' 
        TxtTahunMasuk.Location = New Point(787, 97)
        TxtTahunMasuk.Margin = New Padding(3, 2, 3, 2)
        TxtTahunMasuk.Name = "TxtTahunMasuk"
        TxtTahunMasuk.Size = New Size(396, 23)
        TxtTahunMasuk.TabIndex = 19
        ' 
        ' BtnTambah
        ' 
        BtnTambah.BackColor = Color.LemonChiffon
        BtnTambah.Cursor = Cursors.Hand
        BtnTambah.Font = New Font("Tahoma", 9F)
        BtnTambah.ForeColor = Color.DarkGoldenrod
        BtnTambah.Location = New Point(100, 165)
        BtnTambah.Margin = New Padding(3, 2, 3, 2)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(82, 22)
        BtnTambah.TabIndex = 20
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = False
        ' 
        ' BtnEdit
        ' 
        BtnEdit.BackColor = Color.LemonChiffon
        BtnEdit.Cursor = Cursors.Hand
        BtnEdit.Font = New Font("Tahoma", 9F)
        BtnEdit.ForeColor = Color.DarkGoldenrod
        BtnEdit.Location = New Point(214, 165)
        BtnEdit.Margin = New Padding(3, 2, 3, 2)
        BtnEdit.Name = "BtnEdit"
        BtnEdit.Size = New Size(82, 22)
        BtnEdit.TabIndex = 21
        BtnEdit.Text = "Edit"
        BtnEdit.UseVisualStyleBackColor = False
        ' 
        ' BtnHapus
        ' 
        BtnHapus.BackColor = Color.LemonChiffon
        BtnHapus.Cursor = Cursors.Hand
        BtnHapus.Font = New Font("Tahoma", 9F)
        BtnHapus.ForeColor = Color.DarkGoldenrod
        BtnHapus.Location = New Point(322, 165)
        BtnHapus.Margin = New Padding(3, 2, 3, 2)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(82, 22)
        BtnHapus.TabIndex = 22
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = False
        ' 
        ' BtnRefresh
        ' 
        BtnRefresh.BackColor = Color.LemonChiffon
        BtnRefresh.Cursor = Cursors.Hand
        BtnRefresh.Font = New Font("Tahoma", 9F)
        BtnRefresh.ForeColor = Color.DarkGoldenrod
        BtnRefresh.Location = New Point(442, 165)
        BtnRefresh.Margin = New Padding(3, 2, 3, 2)
        BtnRefresh.Name = "BtnRefresh"
        BtnRefresh.Size = New Size(82, 22)
        BtnRefresh.TabIndex = 23
        BtnRefresh.Text = "Refresh"
        BtnRefresh.UseVisualStyleBackColor = False
        ' 
        ' BtnKembali
        ' 
        BtnKembali.BackColor = Color.LemonChiffon
        BtnKembali.Cursor = Cursors.Hand
        BtnKembali.Font = New Font("Tahoma", 9F)
        BtnKembali.ForeColor = Color.DarkGoldenrod
        BtnKembali.Location = New Point(560, 165)
        BtnKembali.Margin = New Padding(3, 2, 3, 2)
        BtnKembali.Name = "BtnKembali"
        BtnKembali.Size = New Size(82, 22)
        BtnKembali.TabIndex = 24
        BtnKembali.Text = "Kembali"
        BtnKembali.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Tahoma", 9.75F)
        Label8.ForeColor = Color.DarkGoldenrod
        Label8.Location = New Point(693, 127)
        Label8.Name = "Label8"
        Label8.Size = New Size(37, 16)
        Label8.TabIndex = 25
        Label8.Text = "Kelas"
        ' 
        ' CmbKelas
        ' 
        CmbKelas.FormattingEnabled = True
        CmbKelas.Items.AddRange(New Object() {"1a", "1b", "1c", "1d"})
        CmbKelas.Location = New Point(787, 125)
        CmbKelas.Margin = New Padding(3, 2, 3, 2)
        CmbKelas.Name = "CmbKelas"
        CmbKelas.Size = New Size(402, 23)
        CmbKelas.TabIndex = 26
        ' 
        ' FormKelolaMahasiswa
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1195, 559)
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
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MaximumSize = New Size(1682, 821)
        MdiChildrenMinimizedAnchorBottom = False
        MinimumSize = New Size(1196, 549)
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
