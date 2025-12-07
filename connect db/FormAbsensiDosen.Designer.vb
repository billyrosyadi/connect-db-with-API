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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAbsensiDosen))
        CmbJadwal = New ComboBox()
        Label1 = New Label()
        BtnSimpan = New Button()
        SuspendLayout()
        ' 
        ' CmbJadwal
        ' 
        CmbJadwal.FormattingEnabled = True
        CmbJadwal.Location = New Point(360, 240)
        CmbJadwal.Margin = New Padding(3, 2, 3, 2)
        CmbJadwal.Name = "CmbJadwal"
        CmbJadwal.Size = New Size(498, 23)
        CmbJadwal.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(255, 240)
        Label1.Name = "Label1"
        Label1.Size = New Size(99, 18)
        Label1.TabIndex = 1
        Label1.Text = "Pilih Jadwal"
        ' 
        ' BtnSimpan
        ' 
        BtnSimpan.BackColor = Color.DarkGoldenrod
        BtnSimpan.BackgroundImageLayout = ImageLayout.Stretch
        BtnSimpan.Font = New Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnSimpan.Location = New Point(543, 288)
        BtnSimpan.Margin = New Padding(3, 2, 3, 2)
        BtnSimpan.Name = "BtnSimpan"
        BtnSimpan.Size = New Size(104, 32)
        BtnSimpan.TabIndex = 3
        BtnSimpan.Text = "Simpan"
        BtnSimpan.UseVisualStyleBackColor = False
        ' 
        ' FormAbsensiDosen
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1195, 559)
        Controls.Add(BtnSimpan)
        Controls.Add(Label1)
        Controls.Add(CmbJadwal)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MaximumSize = New Size(1682, 821)
        MinimumSize = New Size(1196, 549)
        Name = "FormAbsensiDosen"
        Text = "FormAbsensiDosen"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CmbJadwal As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnSimpan As Button
End Class
