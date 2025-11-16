<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSemuaJadwalDosen
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
        DgvSemuaJadwal = New DataGridView()
        CType(DgvSemuaJadwal, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvSemuaJadwal
        ' 
        DgvSemuaJadwal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvSemuaJadwal.Location = New Point(0, 0)
        DgvSemuaJadwal.Name = "DgvSemuaJadwal"
        DgvSemuaJadwal.RowHeadersWidth = 51
        DgvSemuaJadwal.Size = New Size(1899, 971)
        DgvSemuaJadwal.TabIndex = 0
        ' 
        ' FormSemuaJadwalDosen
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1898, 971)
        Controls.Add(DgvSemuaJadwal)
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MinimumSize = New Size(1918, 1018)
        Name = "FormSemuaJadwalDosen"
        Text = "FormSemuaJadwalDosen"
        CType(DgvSemuaJadwal, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DgvSemuaJadwal As DataGridView
End Class
