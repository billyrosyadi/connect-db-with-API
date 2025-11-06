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
        CType(DgvRuangan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(60, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(111, 20)
        Label1.TabIndex = 0
        Label1.Text = "Nama Ruangan"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(60, 74)
        Label2.Name = "Label2"
        Label2.Size = New Size(72, 20)
        Label2.TabIndex = 1
        Label2.Text = "Kapasitas"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(60, 117)
        Label3.Name = "Label3"
        Label3.Size = New Size(69, 20)
        Label3.TabIndex = 2
        Label3.Text = "Deskripsi"
        ' 
        ' TxtNamaRuangan
        ' 
        TxtNamaRuangan.Location = New Point(266, 30)
        TxtNamaRuangan.Name = "TxtNamaRuangan"
        TxtNamaRuangan.Size = New Size(713, 27)
        TxtNamaRuangan.TabIndex = 3
        ' 
        ' TxtKapasitas
        ' 
        TxtKapasitas.Location = New Point(266, 74)
        TxtKapasitas.Name = "TxtKapasitas"
        TxtKapasitas.Size = New Size(713, 27)
        TxtKapasitas.TabIndex = 4
        ' 
        ' TxtDeskripsi
        ' 
        TxtDeskripsi.Location = New Point(266, 114)
        TxtDeskripsi.Name = "TxtDeskripsi"
        TxtDeskripsi.Size = New Size(713, 27)
        TxtDeskripsi.TabIndex = 5
        ' 
        ' BtnTambah
        ' 
        BtnTambah.Location = New Point(266, 197)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(94, 29)
        BtnTambah.TabIndex = 6
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = True
        ' 
        ' BtnEdit
        ' 
        BtnEdit.Location = New Point(477, 197)
        BtnEdit.Name = "BtnEdit"
        BtnEdit.Size = New Size(94, 29)
        BtnEdit.TabIndex = 7
        BtnEdit.Text = "Edit"
        BtnEdit.UseVisualStyleBackColor = True
        ' 
        ' BtnHapus
        ' 
        BtnHapus.Location = New Point(705, 197)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(94, 29)
        BtnHapus.TabIndex = 8
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = True
        ' 
        ' DgvRuangan
        ' 
        DgvRuangan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvRuangan.Location = New Point(0, 262)
        DgvRuangan.Name = "DgvRuangan"
        DgvRuangan.RowHeadersWidth = 51
        DgvRuangan.Size = New Size(1899, 708)
        DgvRuangan.TabIndex = 9
        ' 
        ' FormKelolaRuangan
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1896, 967)
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
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MinimumSize = New Size(1918, 1018)
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
End Class
