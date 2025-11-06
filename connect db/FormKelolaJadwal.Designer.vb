<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKelolaJadwal
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        BtnTambah = New Button()
        BtnEdit = New Button()
        BtnHapus = New Button()
        DgvJadwal = New DataGridView()
        CmbMatkul = New ComboBox()
        CmbDosen = New ComboBox()
        CmbHari = New ComboBox()
        TxtKelas = New TextBox()
        TxtPengumuman = New TextBox()
        TxtJamSelesai = New TextBox()
        TxtJamMulai = New TextBox()
        Label8 = New Label()
        CmbRuangan = New ComboBox()
        CType(DgvJadwal, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(46, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 20)
        Label1.TabIndex = 0
        Label1.Text = "matkul"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(46, 68)
        Label2.Name = "Label2"
        Label2.Size = New Size(51, 20)
        Label2.TabIndex = 1
        Label2.Text = "Dosen"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(46, 112)
        Label3.Name = "Label3"
        Label3.Size = New Size(42, 20)
        Label3.TabIndex = 2
        Label3.Text = "kelas"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(787, 31)
        Label4.Name = "Label4"
        Label4.Size = New Size(37, 20)
        Label4.TabIndex = 3
        Label4.Text = "Hari"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(787, 68)
        Label5.Name = "Label5"
        Label5.Size = New Size(76, 20)
        Label5.TabIndex = 4
        Label5.Text = "Jam Mulai"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(787, 112)
        Label6.Name = "Label6"
        Label6.Size = New Size(99, 20)
        Label6.TabIndex = 5
        Label6.Text = "Pengumuman"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(1181, 68)
        Label7.Name = "Label7"
        Label7.Size = New Size(85, 20)
        Label7.TabIndex = 6
        Label7.Text = "Jam Selesai"
        ' 
        ' BtnTambah
        ' 
        BtnTambah.Location = New Point(107, 180)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(94, 29)
        BtnTambah.TabIndex = 7
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = True
        ' 
        ' BtnEdit
        ' 
        BtnEdit.Location = New Point(343, 180)
        BtnEdit.Name = "BtnEdit"
        BtnEdit.Size = New Size(94, 29)
        BtnEdit.TabIndex = 8
        BtnEdit.Text = "Edit"
        BtnEdit.UseVisualStyleBackColor = True
        ' 
        ' BtnHapus
        ' 
        BtnHapus.Location = New Point(597, 180)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(94, 29)
        BtnHapus.TabIndex = 9
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = True
        ' 
        ' DgvJadwal
        ' 
        DgvJadwal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvJadwal.Location = New Point(1, 269)
        DgvJadwal.Name = "DgvJadwal"
        DgvJadwal.RowHeadersWidth = 51
        DgvJadwal.Size = New Size(1896, 699)
        DgvJadwal.TabIndex = 10
        ' 
        ' CmbMatkul
        ' 
        CmbMatkul.FormattingEnabled = True
        CmbMatkul.Location = New Point(127, 31)
        CmbMatkul.Name = "CmbMatkul"
        CmbMatkul.Size = New Size(564, 28)
        CmbMatkul.TabIndex = 11
        ' 
        ' CmbDosen
        ' 
        CmbDosen.FormattingEnabled = True
        CmbDosen.Location = New Point(127, 68)
        CmbDosen.Name = "CmbDosen"
        CmbDosen.Size = New Size(564, 28)
        CmbDosen.TabIndex = 12
        ' 
        ' CmbHari
        ' 
        CmbHari.FormattingEnabled = True
        CmbHari.Location = New Point(907, 31)
        CmbHari.Name = "CmbHari"
        CmbHari.Size = New Size(564, 28)
        CmbHari.TabIndex = 13
        ' 
        ' TxtKelas
        ' 
        TxtKelas.Location = New Point(127, 109)
        TxtKelas.Name = "TxtKelas"
        TxtKelas.Size = New Size(564, 27)
        TxtKelas.TabIndex = 14
        ' 
        ' TxtPengumuman
        ' 
        TxtPengumuman.Location = New Point(907, 109)
        TxtPengumuman.Name = "TxtPengumuman"
        TxtPengumuman.Size = New Size(564, 27)
        TxtPengumuman.TabIndex = 15
        ' 
        ' TxtJamSelesai
        ' 
        TxtJamSelesai.Location = New Point(1269, 69)
        TxtJamSelesai.Name = "TxtJamSelesai"
        TxtJamSelesai.Size = New Size(202, 27)
        TxtJamSelesai.TabIndex = 16
        ' 
        ' TxtJamMulai
        ' 
        TxtJamMulai.Location = New Point(907, 69)
        TxtJamMulai.Name = "TxtJamMulai"
        TxtJamMulai.Size = New Size(268, 27)
        TxtJamMulai.TabIndex = 17
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(787, 152)
        Label8.Name = "Label8"
        Label8.Size = New Size(67, 20)
        Label8.TabIndex = 18
        Label8.Text = "Ruangan"
        ' 
        ' CmbRuangan
        ' 
        CmbRuangan.FormattingEnabled = True
        CmbRuangan.Location = New Point(907, 152)
        CmbRuangan.Name = "CmbRuangan"
        CmbRuangan.Size = New Size(564, 28)
        CmbRuangan.TabIndex = 19
        ' 
        ' FormKelolaJadwal
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1898, 971)
        Controls.Add(CmbRuangan)
        Controls.Add(Label8)
        Controls.Add(TxtJamMulai)
        Controls.Add(TxtJamSelesai)
        Controls.Add(TxtPengumuman)
        Controls.Add(TxtKelas)
        Controls.Add(CmbHari)
        Controls.Add(CmbDosen)
        Controls.Add(CmbMatkul)
        Controls.Add(DgvJadwal)
        Controls.Add(BtnHapus)
        Controls.Add(BtnEdit)
        Controls.Add(BtnTambah)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MinimumSize = New Size(1918, 1018)
        Name = "FormKelolaJadwal"
        Text = "FormKelolaJadwal"
        CType(DgvJadwal, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BtnTambah As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents DgvJadwal As DataGridView
    Friend WithEvents CmbMatkul As ComboBox
    Friend WithEvents CmbDosen As ComboBox
    Friend WithEvents CmbHari As ComboBox
    Friend WithEvents TxtKelas As TextBox
    Friend WithEvents TxtPengumuman As TextBox
    Friend WithEvents TxtJamSelesai As TextBox
    Friend WithEvents TxtJamMulai As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CmbRuangan As ComboBox
End Class
