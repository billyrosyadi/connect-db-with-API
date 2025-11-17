<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashboardDosen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashboardDosen))
        BtnLihatJadwalLengkap = New PictureBox()
        BtnNilaiWeb = New PictureBox()
        BtnAbsensi = New PictureBox()
        DgvJadwalHariIni = New DataGridView()
        CType(BtnLihatJadwalLengkap, ComponentModel.ISupportInitialize).BeginInit()
        CType(BtnNilaiWeb, ComponentModel.ISupportInitialize).BeginInit()
        CType(BtnAbsensi, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvJadwalHariIni, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtnLihatJadwalLengkap
        ' 
        BtnLihatJadwalLengkap.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        BtnLihatJadwalLengkap.BackgroundImageLayout = ImageLayout.None
        BtnLihatJadwalLengkap.Image = CType(resources.GetObject("BtnLihatJadwalLengkap.Image"), Image)
        BtnLihatJadwalLengkap.Location = New Point(388, 32)
        BtnLihatJadwalLengkap.MaximumSize = New Size(200, 200)
        BtnLihatJadwalLengkap.Name = "BtnLihatJadwalLengkap"
        BtnLihatJadwalLengkap.Size = New Size(200, 200)
        BtnLihatJadwalLengkap.SizeMode = PictureBoxSizeMode.CenterImage
        BtnLihatJadwalLengkap.TabIndex = 0
        BtnLihatJadwalLengkap.TabStop = False
        ' 
        ' BtnNilaiWeb
        ' 
        BtnNilaiWeb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        BtnNilaiWeb.BackgroundImageLayout = ImageLayout.None
        BtnNilaiWeb.Image = CType(resources.GetObject("BtnNilaiWeb.Image"), Image)
        BtnNilaiWeb.Location = New Point(663, 32)
        BtnNilaiWeb.MaximumSize = New Size(200, 200)
        BtnNilaiWeb.Name = "BtnNilaiWeb"
        BtnNilaiWeb.Size = New Size(200, 200)
        BtnNilaiWeb.SizeMode = PictureBoxSizeMode.CenterImage
        BtnNilaiWeb.TabIndex = 2
        BtnNilaiWeb.TabStop = False
        ' 
        ' BtnAbsensi
        ' 
        BtnAbsensi.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        BtnAbsensi.BackgroundImageLayout = ImageLayout.None
        BtnAbsensi.Image = CType(resources.GetObject("BtnAbsensi.Image"), Image)
        BtnAbsensi.Location = New Point(993, 12)
        BtnAbsensi.Name = "BtnAbsensi"
        BtnAbsensi.Size = New Size(200, 276)
        BtnAbsensi.SizeMode = PictureBoxSizeMode.CenterImage
        BtnAbsensi.TabIndex = 3
        BtnAbsensi.TabStop = False
        ' 
        ' DgvJadwalHariIni
        ' 
        DgvJadwalHariIni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvJadwalHariIni.Location = New Point(0, 323)
        DgvJadwalHariIni.Name = "DgvJadwalHariIni"
        DgvJadwalHariIni.RowHeadersWidth = 51
        DgvJadwalHariIni.Size = New Size(1903, 648)
        DgvJadwalHariIni.TabIndex = 5
        ' 
        ' DashboardDosen
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1898, 971)
        Controls.Add(DgvJadwalHariIni)
        Controls.Add(BtnAbsensi)
        Controls.Add(BtnNilaiWeb)
        Controls.Add(BtnLihatJadwalLengkap)
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MdiChildrenMinimizedAnchorBottom = False
        MinimumSize = New Size(1918, 1018)
        Name = "DashboardDosen"
        SizeGripStyle = SizeGripStyle.Hide
        Text = "DashboardDosen"
        WindowState = FormWindowState.Maximized
        CType(BtnLihatJadwalLengkap, ComponentModel.ISupportInitialize).EndInit()
        CType(BtnNilaiWeb, ComponentModel.ISupportInitialize).EndInit()
        CType(BtnAbsensi, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvJadwalHariIni, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents BtnLihatJadwalLengkap As PictureBox
    Friend WithEvents BtnNilaiWeb As PictureBox
    Friend WithEvents BtnAbsensi As PictureBox
    Friend WithEvents DgvJadwalHariIni As DataGridView
End Class
