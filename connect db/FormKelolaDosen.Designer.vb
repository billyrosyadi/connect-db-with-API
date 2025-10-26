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
        CType(DgvDosen, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvDosen
        ' 
        DgvDosen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDosen.Location = New Point(-2, 284)
        DgvDosen.Name = "DgvDosen"
        DgvDosen.RowHeadersWidth = 51
        DgvDosen.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvDosen.Size = New Size(954, 247)
        DgvDosen.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(75, 20)
        Label1.TabIndex = 1
        Label1.Text = "Username"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 40)
        Label2.Name = "Label2"
        Label2.Size = New Size(49, 20)
        Label2.TabIndex = 2
        Label2.Text = "Nama"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 73)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 20)
        Label3.TabIndex = 3
        Label3.Text = "Tempat Lahir"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 105)
        Label4.Name = "Label4"
        Label4.Size = New Size(97, 20)
        Label4.TabIndex = 4
        Label4.Text = "Tanggal Lahir"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 135)
        Label5.Name = "Label5"
        Label5.Size = New Size(46, 20)
        Label5.TabIndex = 5
        Label5.Text = "Email"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(12, 166)
        Label6.Name = "Label6"
        Label6.Size = New Size(63, 20)
        Label6.TabIndex = 6
        Label6.Text = "Kelamin"
        ' 
        ' TxtUsername
        ' 
        TxtUsername.Location = New Point(165, 6)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(250, 27)
        TxtUsername.TabIndex = 7
        ' 
        ' TxtNama
        ' 
        TxtNama.Location = New Point(165, 40)
        TxtNama.Name = "TxtNama"
        TxtNama.Size = New Size(250, 27)
        TxtNama.TabIndex = 8
        ' 
        ' TxtTempatLahir
        ' 
        TxtTempatLahir.Location = New Point(165, 70)
        TxtTempatLahir.Name = "TxtTempatLahir"
        TxtTempatLahir.Size = New Size(250, 27)
        TxtTempatLahir.TabIndex = 9
        ' 
        ' TxtEmail
        ' 
        TxtEmail.Location = New Point(165, 132)
        TxtEmail.Name = "TxtEmail"
        TxtEmail.Size = New Size(250, 27)
        TxtEmail.TabIndex = 10
        ' 
        ' DtTanggalLahir
        ' 
        DtTanggalLahir.Location = New Point(165, 103)
        DtTanggalLahir.Name = "DtTanggalLahir"
        DtTanggalLahir.Size = New Size(250, 27)
        DtTanggalLahir.TabIndex = 11
        ' 
        ' CmbKelamin
        ' 
        CmbKelamin.FormattingEnabled = True
        CmbKelamin.Items.AddRange(New Object() {"Laki-laki", "Perempuan"})
        CmbKelamin.Location = New Point(165, 163)
        CmbKelamin.Name = "CmbKelamin"
        CmbKelamin.Size = New Size(250, 28)
        CmbKelamin.TabIndex = 12
        ' 
        ' BtnTambah
        ' 
        BtnTambah.Location = New Point(12, 205)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(94, 29)
        BtnTambah.TabIndex = 13
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = True
        ' 
        ' BtnRefresh
        ' 
        BtnRefresh.Location = New Point(165, 205)
        BtnRefresh.Name = "BtnRefresh"
        BtnRefresh.Size = New Size(94, 29)
        BtnRefresh.TabIndex = 14
        BtnRefresh.Text = "Refresh"
        BtnRefresh.UseVisualStyleBackColor = True
        ' 
        ' BtnKembali
        ' 
        BtnKembali.Location = New Point(321, 205)
        BtnKembali.Name = "BtnKembali"
        BtnKembali.Size = New Size(94, 29)
        BtnKembali.TabIndex = 15
        BtnKembali.Text = "Kembali"
        BtnKembali.UseVisualStyleBackColor = True
        ' 
        ' BtnEdit
        ' 
        BtnEdit.Location = New Point(15, 249)
        BtnEdit.Name = "BtnEdit"
        BtnEdit.Size = New Size(94, 29)
        BtnEdit.TabIndex = 16
        BtnEdit.Text = "Edit"
        BtnEdit.UseVisualStyleBackColor = True
        ' 
        ' BtnHapus
        ' 
        BtnHapus.Location = New Point(165, 249)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(94, 29)
        BtnHapus.TabIndex = 17
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = True
        ' 
        ' FormKelolaDosen
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(953, 532)
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
        Name = "FormKelolaDosen"
        Text = "FormKelolaDosen"
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
End Class
