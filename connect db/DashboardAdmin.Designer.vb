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
        ToolStrip1 = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        CType(KelolaDosen, ComponentModel.ISupportInitialize).BeginInit()
        CType(KelolaMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        CType(KelolaAkun, ComponentModel.ISupportInitialize).BeginInit()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' KelolaDosen
        ' 
        KelolaDosen.Image = CType(resources.GetObject("KelolaDosen.Image"), Image)
        KelolaDosen.Location = New Point(12, 12)
        KelolaDosen.Name = "KelolaDosen"
        KelolaDosen.Size = New Size(125, 131)
        KelolaDosen.SizeMode = PictureBoxSizeMode.StretchImage
        KelolaDosen.TabIndex = 1
        KelolaDosen.TabStop = False
        ' 
        ' KelolaMahasiswa
        ' 
        KelolaMahasiswa.Image = CType(resources.GetObject("KelolaMahasiswa.Image"), Image)
        KelolaMahasiswa.Location = New Point(159, 12)
        KelolaMahasiswa.Name = "KelolaMahasiswa"
        KelolaMahasiswa.Size = New Size(125, 131)
        KelolaMahasiswa.SizeMode = PictureBoxSizeMode.StretchImage
        KelolaMahasiswa.TabIndex = 2
        KelolaMahasiswa.TabStop = False
        ' 
        ' KelolaAkun
        ' 
        KelolaAkun.Image = CType(resources.GetObject("KelolaAkun.Image"), Image)
        KelolaAkun.Location = New Point(314, 12)
        KelolaAkun.Name = "KelolaAkun"
        KelolaAkun.Size = New Size(125, 131)
        KelolaAkun.SizeMode = PictureBoxSizeMode.StretchImage
        KelolaAkun.TabIndex = 3
        KelolaAkun.TabStop = False
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.ImageScalingSize = New Size(20, 20)
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton1, ToolStripButton2})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(956, 27)
        ToolStrip1.TabIndex = 4
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(29, 24)
        ToolStripButton1.Text = "ToolStripButton1"
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), Image)
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(29, 24)
        ToolStripButton2.Text = "ToolStripButton2"
        ' 
        ' DashboardAdmin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(956, 464)
        Controls.Add(ToolStrip1)
        Controls.Add(KelolaAkun)
        Controls.Add(KelolaMahasiswa)
        Controls.Add(KelolaDosen)
        Name = "DashboardAdmin"
        Text = "DashboardAdmin"
        CType(KelolaDosen, ComponentModel.ISupportInitialize).EndInit()
        CType(KelolaMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        CType(KelolaAkun, ComponentModel.ISupportInitialize).EndInit()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents KelolaDosen As PictureBox
    Friend WithEvents KelolaMahasiswa As PictureBox
    Friend WithEvents KelolaAkun As PictureBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
End Class
