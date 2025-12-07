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
        DgvSemuaJadwal.Location = New Point(-4, -2)
        DgvSemuaJadwal.Margin = New Padding(3, 2, 3, 2)
        DgvSemuaJadwal.Name = "DgvSemuaJadwal"
        DgvSemuaJadwal.RowHeadersWidth = 51
        DgvSemuaJadwal.Size = New Size(1202, 567)
        DgvSemuaJadwal.TabIndex = 0
        ' 
        ' FormSemuaJadwalDosen
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1195, 559)
        Controls.Add(DgvSemuaJadwal)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MaximumSize = New Size(1682, 821)
        MinimumSize = New Size(1196, 549)
        Name = "FormSemuaJadwalDosen"
        Text = "FormSemuaJadwalDosen"
        CType(DgvSemuaJadwal, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DgvSemuaJadwal As DataGridView
End Class
