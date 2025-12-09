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
        CType(BtnLihatJadwalLengkap, ComponentModel.ISupportInitialize).BeginInit()
        CType(BtnNilaiWeb, ComponentModel.ISupportInitialize).BeginInit()
        CType(BtnAbsensi, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtnLihatJadwalLengkap
        ' 
        BtnLihatJadwalLengkap.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        BtnLihatJadwalLengkap.BackColor = Color.Transparent
        BtnLihatJadwalLengkap.BackgroundImageLayout = ImageLayout.None
        BtnLihatJadwalLengkap.Image = CType(resources.GetObject("BtnLihatJadwalLengkap.Image"), Image)
        BtnLihatJadwalLengkap.Location = New Point(304, 223)
        BtnLihatJadwalLengkap.Margin = New Padding(3, 2, 3, 2)
        BtnLihatJadwalLengkap.MaximumSize = New Size(175, 150)
        BtnLihatJadwalLengkap.Name = "BtnLihatJadwalLengkap"
        BtnLihatJadwalLengkap.Size = New Size(175, 131)
        BtnLihatJadwalLengkap.SizeMode = PictureBoxSizeMode.Zoom
        BtnLihatJadwalLengkap.TabIndex = 0
        BtnLihatJadwalLengkap.TabStop = False
        ' 
        ' BtnNilaiWeb
        ' 
        BtnNilaiWeb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        BtnNilaiWeb.BackColor = Color.Transparent
        BtnNilaiWeb.BackgroundImageLayout = ImageLayout.None
        BtnNilaiWeb.Image = CType(resources.GetObject("BtnNilaiWeb.Image"), Image)
        BtnNilaiWeb.Location = New Point(562, 223)
        BtnNilaiWeb.Margin = New Padding(3, 2, 3, 2)
        BtnNilaiWeb.MaximumSize = New Size(175, 150)
        BtnNilaiWeb.Name = "BtnNilaiWeb"
        BtnNilaiWeb.Size = New Size(171, 131)
        BtnNilaiWeb.SizeMode = PictureBoxSizeMode.Zoom
        BtnNilaiWeb.TabIndex = 2
        BtnNilaiWeb.TabStop = False
        ' 
        ' BtnAbsensi
        ' 
        BtnAbsensi.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        BtnAbsensi.BackColor = Color.Transparent
        BtnAbsensi.BackgroundImageLayout = ImageLayout.None
        BtnAbsensi.Image = CType(resources.GetObject("BtnAbsensi.Image"), Image)
        BtnAbsensi.Location = New Point(815, 223)
        BtnAbsensi.Margin = New Padding(3, 2, 3, 2)
        BtnAbsensi.Name = "BtnAbsensi"
        BtnAbsensi.Size = New Size(172, 131)
        BtnAbsensi.SizeMode = PictureBoxSizeMode.Zoom
        BtnAbsensi.TabIndex = 3
        BtnAbsensi.TabStop = False
        ' 
        ' DashboardDosen
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1195, 559)
        Controls.Add(BtnAbsensi)
        Controls.Add(BtnNilaiWeb)
        Controls.Add(BtnLihatJadwalLengkap)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MaximumSize = New Size(1215, 602)
        MdiChildrenMinimizedAnchorBottom = False
        MinimumSize = New Size(1196, 549)
        Name = "DashboardDosen"
        SizeGripStyle = SizeGripStyle.Hide
        Text = "DashboardDosen"
        WindowState = FormWindowState.Maximized
        CType(BtnLihatJadwalLengkap, ComponentModel.ISupportInitialize).EndInit()
        CType(BtnNilaiWeb, ComponentModel.ISupportInitialize).EndInit()
        CType(BtnAbsensi, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents BtnLihatJadwalLengkap As PictureBox
    Friend WithEvents BtnNilaiWeb As PictureBox
    Friend WithEvents BtnAbsensi As PictureBox
End Class
