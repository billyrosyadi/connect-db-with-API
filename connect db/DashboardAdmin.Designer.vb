<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashboardAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashboardAdmin))
        KelolaDosen = New PictureBox()
        KelolaMahasiswa = New PictureBox()
        KelolaAkun = New PictureBox()
        KelolaJadwal = New PictureBox()
        KelolaRuangan = New PictureBox()
        CType(KelolaDosen, ComponentModel.ISupportInitialize).BeginInit()
        CType(KelolaMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        CType(KelolaAkun, ComponentModel.ISupportInitialize).BeginInit()
        CType(KelolaJadwal, ComponentModel.ISupportInitialize).BeginInit()
        CType(KelolaRuangan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' KelolaDosen
        ' 
        KelolaDosen.BackColor = Color.Transparent
        KelolaDosen.Image = CType(resources.GetObject("KelolaDosen.Image"), Image)
        KelolaDosen.Location = New Point(235, 53)
        KelolaDosen.Margin = New Padding(3, 2, 3, 2)
        KelolaDosen.Name = "KelolaDosen"
        KelolaDosen.Size = New Size(169, 166)
        KelolaDosen.SizeMode = PictureBoxSizeMode.StretchImage
        KelolaDosen.TabIndex = 1
        KelolaDosen.TabStop = False
        ' 
        ' KelolaMahasiswa
        ' 
        KelolaMahasiswa.BackColor = Color.Transparent
        KelolaMahasiswa.Image = CType(resources.GetObject("KelolaMahasiswa.Image"), Image)
        KelolaMahasiswa.Location = New Point(540, 53)
        KelolaMahasiswa.Margin = New Padding(3, 2, 3, 2)
        KelolaMahasiswa.Name = "KelolaMahasiswa"
        KelolaMahasiswa.Size = New Size(150, 166)
        KelolaMahasiswa.SizeMode = PictureBoxSizeMode.StretchImage
        KelolaMahasiswa.TabIndex = 2
        KelolaMahasiswa.TabStop = False
        ' 
        ' KelolaAkun
        ' 
        KelolaAkun.BackColor = Color.Transparent
        KelolaAkun.Image = CType(resources.GetObject("KelolaAkun.Image"), Image)
        KelolaAkun.Location = New Point(820, 53)
        KelolaAkun.Margin = New Padding(3, 2, 3, 2)
        KelolaAkun.Name = "KelolaAkun"
        KelolaAkun.Size = New Size(163, 166)
        KelolaAkun.SizeMode = PictureBoxSizeMode.StretchImage
        KelolaAkun.TabIndex = 3
        KelolaAkun.TabStop = False
        ' 
        ' KelolaJadwal
        ' 
        KelolaJadwal.BackColor = Color.Transparent
        KelolaJadwal.Image = CType(resources.GetObject("KelolaJadwal.Image"), Image)
        KelolaJadwal.Location = New Point(345, 277)
        KelolaJadwal.Margin = New Padding(3, 2, 3, 2)
        KelolaJadwal.Name = "KelolaJadwal"
        KelolaJadwal.Size = New Size(191, 166)
        KelolaJadwal.SizeMode = PictureBoxSizeMode.StretchImage
        KelolaJadwal.TabIndex = 4
        KelolaJadwal.TabStop = False
        ' 
        ' KelolaRuangan
        ' 
        KelolaRuangan.BackColor = Color.Transparent
        KelolaRuangan.Image = CType(resources.GetObject("KelolaRuangan.Image"), Image)
        KelolaRuangan.Location = New Point(641, 277)
        KelolaRuangan.Margin = New Padding(3, 2, 3, 2)
        KelolaRuangan.Name = "KelolaRuangan"
        KelolaRuangan.Size = New Size(200, 166)
        KelolaRuangan.SizeMode = PictureBoxSizeMode.StretchImage
        KelolaRuangan.TabIndex = 5
        KelolaRuangan.TabStop = False
        ' 
        ' DashboardAdmin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1176, 506)
        Controls.Add(KelolaRuangan)
        Controls.Add(KelolaJadwal)
        Controls.Add(KelolaAkun)
        Controls.Add(KelolaMahasiswa)
        Controls.Add(KelolaDosen)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MaximumSize = New Size(1682, 821)
        MdiChildrenMinimizedAnchorBottom = False
        MinimumSize = New Size(1196, 549)
        Name = "DashboardAdmin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "DashboardAdmin"
        CType(KelolaDosen, ComponentModel.ISupportInitialize).EndInit()
        CType(KelolaMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        CType(KelolaAkun, ComponentModel.ISupportInitialize).EndInit()
        CType(KelolaJadwal, ComponentModel.ISupportInitialize).EndInit()
        CType(KelolaRuangan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents KelolaDosen As PictureBox
    Friend WithEvents KelolaMahasiswa As PictureBox
    Friend WithEvents KelolaAkun As PictureBox
    Friend WithEvents KelolaJadwal As PictureBox
    Friend WithEvents KelolaRuangan As PictureBox
End Class
