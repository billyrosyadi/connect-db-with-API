<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAbsensiDosen
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
        CmbJadwal = New ComboBox()
        Label1 = New Label()
        DgvMahasiswa = New DataGridView()
        BtnSimpan = New Button()
        CType(DgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' CmbJadwal
        ' 
        CmbJadwal.FormattingEnabled = True
        CmbJadwal.Location = New Point(219, 88)
        CmbJadwal.Name = "CmbJadwal"
        CmbJadwal.Size = New Size(421, 28)
        CmbJadwal.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(106, 91)
        Label1.Name = "Label1"
        Label1.Size = New Size(86, 20)
        Label1.TabIndex = 1
        Label1.Text = "pilih jadwal"
        ' 
        ' DgvMahasiswa
        ' 
        DgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvMahasiswa.Location = New Point(1, 196)
        DgvMahasiswa.Name = "DgvMahasiswa"
        DgvMahasiswa.RowHeadersWidth = 51
        DgvMahasiswa.Size = New Size(1900, 838)
        DgvMahasiswa.TabIndex = 2
        ' 
        ' BtnSimpan
        ' 
        BtnSimpan.Location = New Point(219, 138)
        BtnSimpan.Name = "BtnSimpan"
        BtnSimpan.Size = New Size(94, 29)
        BtnSimpan.TabIndex = 3
        BtnSimpan.Text = "Simpan"
        BtnSimpan.UseVisualStyleBackColor = True
        ' 
        ' FormAbsensiDosen
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1898, 1029)
        Controls.Add(BtnSimpan)
        Controls.Add(DgvMahasiswa)
        Controls.Add(Label1)
        Controls.Add(CmbJadwal)
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MinimumSize = New Size(1918, 1018)
        Name = "FormAbsensiDosen"
        Text = "FormAbsensiDosen"
        CType(DgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CmbJadwal As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DgvMahasiswa As DataGridView
    Friend WithEvents BtnSimpan As Button
End Class
