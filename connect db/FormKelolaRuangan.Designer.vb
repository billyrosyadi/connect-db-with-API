<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKelolaRuangan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKelolaRuangan))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TxtNamaRuangan = New TextBox()
        TxtKapasitas = New TextBox()
        TxtDeskripsi = New TextBox()
        BtnTambah = New Button()
        BtnEdit = New Button()
        BtnHapus = New Button()
        DgvRuangan = New DataGridView()
        Label4 = New Label()
        Label5 = New Label()
        CType(DgvRuangan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Tahoma", 9.75F)
        Label1.ForeColor = Color.DarkGoldenrod
        Label1.Location = New Point(190, 78)
        Label1.Name = "Label1"
        Label1.Size = New Size(94, 16)
        Label1.TabIndex = 0
        Label1.Text = "Nama Ruangan"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Tahoma", 9.75F)
        Label2.ForeColor = Color.DarkGoldenrod
        Label2.Location = New Point(190, 109)
        Label2.Name = "Label2"
        Label2.Size = New Size(61, 16)
        Label2.TabIndex = 1
        Label2.Text = "Kapasitas"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Tahoma", 9.75F)
        Label3.ForeColor = Color.DarkGoldenrod
        Label3.Location = New Point(190, 141)
        Label3.Name = "Label3"
        Label3.Size = New Size(58, 16)
        Label3.TabIndex = 2
        Label3.Text = "Deskripsi"
        ' 
        ' TxtNamaRuangan
        ' 
        TxtNamaRuangan.Location = New Point(325, 76)
        TxtNamaRuangan.Margin = New Padding(3, 2, 3, 2)
        TxtNamaRuangan.Name = "TxtNamaRuangan"
        TxtNamaRuangan.Size = New Size(624, 23)
        TxtNamaRuangan.TabIndex = 3
        ' 
        ' TxtKapasitas
        ' 
        TxtKapasitas.Location = New Point(325, 110)
        TxtKapasitas.Margin = New Padding(3, 2, 3, 2)
        TxtKapasitas.Name = "TxtKapasitas"
        TxtKapasitas.Size = New Size(624, 23)
        TxtKapasitas.TabIndex = 4
        ' 
        ' TxtDeskripsi
        ' 
        TxtDeskripsi.Location = New Point(325, 140)
        TxtDeskripsi.Margin = New Padding(3, 2, 3, 2)
        TxtDeskripsi.Name = "TxtDeskripsi"
        TxtDeskripsi.Size = New Size(624, 23)
        TxtDeskripsi.TabIndex = 5
        ' 
        ' BtnTambah
        ' 
        BtnTambah.BackColor = Color.LemonChiffon
        BtnTambah.Font = New Font("Tahoma", 9F)
        BtnTambah.ForeColor = Color.DarkGoldenrod
        BtnTambah.Location = New Point(325, 202)
        BtnTambah.Margin = New Padding(3, 2, 3, 2)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(82, 22)
        BtnTambah.TabIndex = 6
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = False
        ' 
        ' BtnEdit
        ' 
        BtnEdit.BackColor = Color.LemonChiffon
        BtnEdit.Font = New Font("Tahoma", 9F)
        BtnEdit.ForeColor = Color.DarkGoldenrod
        BtnEdit.Location = New Point(597, 202)
        BtnEdit.Margin = New Padding(3, 2, 3, 2)
        BtnEdit.Name = "BtnEdit"
        BtnEdit.Size = New Size(82, 22)
        BtnEdit.TabIndex = 7
        BtnEdit.Text = "Edit"
        BtnEdit.UseVisualStyleBackColor = False
        ' 
        ' BtnHapus
        ' 
        BtnHapus.BackColor = Color.LemonChiffon
        BtnHapus.Font = New Font("Tahoma", 9F)
        BtnHapus.ForeColor = Color.DarkGoldenrod
        BtnHapus.Location = New Point(867, 202)
        BtnHapus.Margin = New Padding(3, 2, 3, 2)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(82, 22)
        BtnHapus.TabIndex = 8
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = False
        ' 
        ' DgvRuangan
        ' 
        DgvRuangan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvRuangan.Location = New Point(-2, 265)
        DgvRuangan.Margin = New Padding(3, 2, 3, 2)
        DgvRuangan.Name = "DgvRuangan"
        DgvRuangan.RowHeadersWidth = 51
        DgvRuangan.Size = New Size(1202, 297)
        DgvRuangan.TabIndex = 9
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Tahoma", 9.75F)
        Label4.ForeColor = Color.DarkGoldenrod
        Label4.Location = New Point(550, 271)
        Label4.Name = "Label4"
        Label4.Size = New Size(94, 16)
        Label4.TabIndex = 10
        Label4.Text = "Nama Ruangan"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.DarkGoldenrod
        Label5.Location = New Point(513, 18)
        Label5.Name = "Label5"
        Label5.Size = New Size(189, 23)
        Label5.TabIndex = 11
        Label5.Text = "KELOLA RUANGAN"
        ' 
        ' FormKelolaRuangan
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1195, 559)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(DgvRuangan)
        Controls.Add(BtnHapus)
        Controls.Add(BtnEdit)
        Controls.Add(BtnTambah)
        Controls.Add(TxtDeskripsi)
        Controls.Add(TxtKapasitas)
        Controls.Add(TxtNamaRuangan)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MaximumSize = New Size(1682, 821)
        MinimumSize = New Size(1196, 549)
        Name = "FormKelolaRuangan"
        Text = "FormKelolaRuangan"
        CType(DgvRuangan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNamaRuangan As TextBox
    Friend WithEvents TxtKapasitas As TextBox
    Friend WithEvents TxtDeskripsi As TextBox
    Friend WithEvents BtnTambah As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents DgvRuangan As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
