<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dashboard
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
        GroupBox1 = New GroupBox()
        Button3 = New Button()
        Button2 = New Button()
        txtJurusan = New ComboBox()
        Button1 = New Button()
        txtEmail = New TextBox()
        txtAlamat = New TextBox()
        txtNama = New TextBox()
        txtDate = New DateTimePicker()
        txtJK = New ComboBox()
        txtNIM = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        dgvMahasiswa = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(204, 20)
        Label1.TabIndex = 0
        Label1.Text = "selamat datang di dashboard"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button3)
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(txtJurusan)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(txtEmail)
        GroupBox1.Controls.Add(txtAlamat)
        GroupBox1.Controls.Add(txtNama)
        GroupBox1.Controls.Add(txtDate)
        GroupBox1.Controls.Add(txtJK)
        GroupBox1.Controls.Add(txtNIM)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Location = New Point(23, 47)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(741, 205)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "tambah data mahasiswa"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(584, 133)
        Button3.Name = "Button3"
        Button3.Size = New Size(94, 29)
        Button3.TabIndex = 17
        Button3.Text = "Delete"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(484, 133)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 16
        Button2.Text = "Update"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' txtJurusan
        ' 
        txtJurusan.FormattingEnabled = True
        txtJurusan.Items.AddRange(New Object() {"Teknik Informatika", "Teknik Pengelasan", "Sistem Informasi", "Teknik Mesin", "Teknik Pemesinan", "Teknik Kedokteran", "Sastra Mesin", "Sastra Pengelasan"})
        txtJurusan.Location = New Point(484, 99)
        txtJurusan.Name = "txtJurusan"
        txtJurusan.Size = New Size(151, 28)
        txtJurusan.TabIndex = 15
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(375, 132)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 14
        Button1.Text = "tambah"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(105, 132)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(216, 27)
        txtEmail.TabIndex = 12
        ' 
        ' txtAlamat
        ' 
        txtAlamat.Location = New Point(105, 96)
        txtAlamat.Name = "txtAlamat"
        txtAlamat.Size = New Size(216, 27)
        txtAlamat.TabIndex = 11
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(105, 66)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(216, 27)
        txtNama.TabIndex = 10
        ' 
        ' txtDate
        ' 
        txtDate.Location = New Point(443, 66)
        txtDate.Name = "txtDate"
        txtDate.Size = New Size(250, 27)
        txtDate.TabIndex = 2
        ' 
        ' txtJK
        ' 
        txtJK.FormattingEnabled = True
        txtJK.Items.AddRange(New Object() {"laki-laki", "perempuan"})
        txtJK.Location = New Point(484, 34)
        txtJK.Name = "txtJK"
        txtJK.Size = New Size(151, 28)
        txtJK.TabIndex = 9
        ' 
        ' txtNIM
        ' 
        txtNIM.Location = New Point(105, 34)
        txtNIM.Name = "txtNIM"
        txtNIM.Size = New Size(216, 27)
        txtNIM.TabIndex = 8
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(374, 99)
        Label8.Name = "Label8"
        Label8.Size = New Size(56, 20)
        Label8.TabIndex = 6
        Label8.Text = "jurusan"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(374, 66)
        Label7.Name = "Label7"
        Label7.Size = New Size(60, 20)
        Label7.TabIndex = 5
        Label7.Text = "tgl lahir"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(374, 34)
        Label6.Name = "Label6"
        Label6.Size = New Size(95, 20)
        Label6.TabIndex = 4
        Label6.Text = "jenis kelamin"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(29, 132)
        Label5.Name = "Label5"
        Label5.Size = New Size(46, 20)
        Label5.TabIndex = 3
        Label5.Text = "Email"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(29, 99)
        Label4.Name = "Label4"
        Label4.Size = New Size(57, 20)
        Label4.TabIndex = 2
        Label4.Text = "Alamat"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(29, 66)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 20)
        Label3.TabIndex = 1
        Label3.Text = "Nama"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(29, 34)
        Label2.Name = "Label2"
        Label2.Size = New Size(37, 20)
        Label2.TabIndex = 0
        Label2.Text = "NIM"
        ' 
        ' dgvMahasiswa
        ' 
        dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMahasiswa.Location = New Point(23, 257)
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.RowHeadersWidth = 51
        dgvMahasiswa.Size = New Size(739, 172)
        dgvMahasiswa.TabIndex = 2
        ' 
        ' dashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(dgvMahasiswa)
        Controls.Add(GroupBox1)
        Controls.Add(Label1)
        Name = "dashboard"
        Text = "dashboard"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtAlamat As TextBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtDate As DateTimePicker
    Friend WithEvents txtJK As ComboBox
    Friend WithEvents txtJurusan As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents dgvMahasiswa As DataGridView
End Class
