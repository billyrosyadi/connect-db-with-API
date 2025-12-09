<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKelolaDosen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKelolaDosen))
        DgvDosen = New DataGridView()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        TxtUsername = New TextBox()
        TxtNama = New TextBox()
        TxtTempatLahir = New TextBox()
        TxtEmail = New TextBox()
        DtTanggalLahir = New DateTimePicker()
        CmbKelamin = New ComboBox()
        BtnTambah = New Button()
        BtnRefresh = New Button()
        BtnKembali = New Button()
        BtnEdit = New Button()
        BtnHapus = New Button()
        Label7 = New Label()
        CType(DgvDosen, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvDosen
        ' 
        DgvDosen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDosen.Location = New Point(730, 117)
        DgvDosen.Margin = New Padding(3, 2, 3, 2)
        DgvDosen.Name = "DgvDosen"
        DgvDosen.RowHeadersWidth = 51
        DgvDosen.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvDosen.Size = New Size(453, 431)
        DgvDosen.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Tahoma", 11.25F, FontStyle.Bold)
        Label1.ForeColor = Color.DarkGoldenrod
        Label1.Location = New Point(95, 161)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 18)
        Label1.TabIndex = 1
        Label1.Text = "Username"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Tahoma", 11.25F, FontStyle.Bold)
        Label2.ForeColor = Color.DarkGoldenrod
        Label2.Location = New Point(95, 213)
        Label2.Name = "Label2"
        Label2.Size = New Size(51, 18)
        Label2.TabIndex = 2
        Label2.Text = "Nama"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Tahoma", 11.25F, FontStyle.Bold)
        Label3.ForeColor = Color.DarkGoldenrod
        Label3.Location = New Point(95, 267)
        Label3.Name = "Label3"
        Label3.Size = New Size(106, 18)
        Label3.TabIndex = 3
        Label3.Text = "Tempat Lahir"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Tahoma", 11.25F, FontStyle.Bold)
        Label4.ForeColor = Color.DarkGoldenrod
        Label4.Location = New Point(95, 367)
        Label4.Name = "Label4"
        Label4.Size = New Size(110, 18)
        Label4.TabIndex = 4
        Label4.Text = "Tanggal Lahir"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Tahoma", 11.25F, FontStyle.Bold)
        Label5.ForeColor = Color.DarkGoldenrod
        Label5.Location = New Point(95, 415)
        Label5.Name = "Label5"
        Label5.Size = New Size(49, 18)
        Label5.TabIndex = 5
        Label5.Text = "Email"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Tahoma", 11.25F, FontStyle.Bold)
        Label6.ForeColor = Color.DarkGoldenrod
        Label6.Location = New Point(95, 319)
        Label6.Name = "Label6"
        Label6.Size = New Size(68, 18)
        Label6.TabIndex = 6
        Label6.Text = "Kelamin"
        ' 
        ' TxtUsername
        ' 
        TxtUsername.Location = New Point(301, 159)
        TxtUsername.Margin = New Padding(3, 2, 3, 2)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(352, 23)
        TxtUsername.TabIndex = 7
        ' 
        ' TxtNama
        ' 
        TxtNama.Location = New Point(301, 211)
        TxtNama.Margin = New Padding(3, 2, 3, 2)
        TxtNama.Name = "TxtNama"
        TxtNama.Size = New Size(352, 23)
        TxtNama.TabIndex = 8
        ' 
        ' TxtTempatLahir
        ' 
        TxtTempatLahir.Location = New Point(301, 265)
        TxtTempatLahir.Margin = New Padding(3, 2, 3, 2)
        TxtTempatLahir.Name = "TxtTempatLahir"
        TxtTempatLahir.Size = New Size(352, 23)
        TxtTempatLahir.TabIndex = 9
        ' 
        ' TxtEmail
        ' 
        TxtEmail.Location = New Point(301, 408)
        TxtEmail.Margin = New Padding(3, 2, 3, 2)
        TxtEmail.Name = "TxtEmail"
        TxtEmail.Size = New Size(352, 23)
        TxtEmail.TabIndex = 10
        ' 
        ' DtTanggalLahir
        ' 
        DtTanggalLahir.Location = New Point(301, 360)
        DtTanggalLahir.Margin = New Padding(3, 2, 3, 2)
        DtTanggalLahir.Name = "DtTanggalLahir"
        DtTanggalLahir.Size = New Size(352, 23)
        DtTanggalLahir.TabIndex = 11
        ' 
        ' CmbKelamin
        ' 
        CmbKelamin.FormattingEnabled = True
        CmbKelamin.Items.AddRange(New Object() {"Laki-laki", "Perempuan"})
        CmbKelamin.Location = New Point(301, 312)
        CmbKelamin.Margin = New Padding(3, 2, 3, 2)
        CmbKelamin.Name = "CmbKelamin"
        CmbKelamin.Size = New Size(352, 23)
        CmbKelamin.TabIndex = 12
        ' 
        ' BtnTambah
        ' 
        BtnTambah.Cursor = Cursors.Hand
        BtnTambah.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        BtnTambah.ForeColor = Color.DarkGoldenrod
        BtnTambah.Location = New Point(301, 461)
        BtnTambah.Margin = New Padding(3, 2, 3, 2)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(82, 22)
        BtnTambah.TabIndex = 13
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = True
        ' 
        ' BtnRefresh
        ' 
        BtnRefresh.Location = New Point(65, 613)
        BtnRefresh.Margin = New Padding(3, 2, 3, 2)
        BtnRefresh.Name = "BtnRefresh"
        BtnRefresh.Size = New Size(82, 22)
        BtnRefresh.TabIndex = 14
        BtnRefresh.Text = "Refresh"
        BtnRefresh.UseVisualStyleBackColor = True
        ' 
        ' BtnKembali
        ' 
        BtnKembali.Location = New Point(384, 613)
        BtnKembali.Margin = New Padding(3, 2, 3, 2)
        BtnKembali.Name = "BtnKembali"
        BtnKembali.Size = New Size(82, 22)
        BtnKembali.TabIndex = 15
        BtnKembali.Text = "Kembali"
        BtnKembali.UseVisualStyleBackColor = True
        ' 
        ' BtnEdit
        ' 
        BtnEdit.Cursor = Cursors.Hand
        BtnEdit.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        BtnEdit.ForeColor = Color.DarkGoldenrod
        BtnEdit.Location = New Point(440, 461)
        BtnEdit.Margin = New Padding(3, 2, 3, 2)
        BtnEdit.Name = "BtnEdit"
        BtnEdit.Size = New Size(82, 22)
        BtnEdit.TabIndex = 16
        BtnEdit.Text = "Edit"
        BtnEdit.UseVisualStyleBackColor = True
        ' 
        ' BtnHapus
        ' 
        BtnHapus.Cursor = Cursors.Hand
        BtnHapus.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        BtnHapus.ForeColor = Color.DarkGoldenrod
        BtnHapus.Location = New Point(571, 461)
        BtnHapus.Margin = New Padding(3, 2, 3, 2)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(82, 22)
        BtnHapus.TabIndex = 17
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(673, 35)
        Label7.Name = "Label7"
        Label7.Size = New Size(145, 25)
        Label7.TabIndex = 18
        Label7.Text = "Kelola dosen"
        ' 
        ' FormKelolaDosen
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1195, 559)
        ControlBox = False
        Controls.Add(Label7)
        Controls.Add(BtnHapus)
        Controls.Add(BtnEdit)
        Controls.Add(BtnKembali)
        Controls.Add(BtnRefresh)
        Controls.Add(BtnTambah)
        Controls.Add(CmbKelamin)
        Controls.Add(DtTanggalLahir)
        Controls.Add(TxtEmail)
        Controls.Add(TxtTempatLahir)
        Controls.Add(TxtNama)
        Controls.Add(TxtUsername)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(DgvDosen)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MaximumSize = New Size(1215, 602)
        MdiChildrenMinimizedAnchorBottom = False
        MinimumSize = New Size(1196, 549)
        Name = "FormKelolaDosen"
        Text = "FormKelolaDosen"
        WindowState = FormWindowState.Maximized
        CType(DgvDosen, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DgvDosen As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents TxtNama As TextBox
    Friend WithEvents TxtTempatLahir As TextBox
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents DtTanggalLahir As DateTimePicker
    Friend WithEvents CmbKelamin As ComboBox
    Friend WithEvents BtnTambah As Button
    Friend WithEvents BtnRefresh As Button
    Friend WithEvents BtnKembali As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents Label7 As Label
End Class
