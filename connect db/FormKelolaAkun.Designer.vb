<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKelolaAkun
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
        Username = New Label()
        Role = New Label()
        Label3 = New Label()
        TxtUsername = New TextBox()
        TxtPassword = New TextBox()
        CmbRole = New ComboBox()
        BtnTambah = New Button()
        BtnEdit = New Button()
        BtnHapus = New Button()
        DgvAkun = New DataGridView()
        CType(DgvAkun, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Username
        ' 
        Username.AutoSize = True
        Username.Location = New Point(58, 33)
        Username.Name = "Username"
        Username.Size = New Size(60, 15)
        Username.TabIndex = 0
        Username.Text = "Username"
        ' 
        ' Role
        ' 
        Role.AutoSize = True
        Role.Location = New Point(58, 62)
        Role.Name = "Role"
        Role.Size = New Size(30, 15)
        Role.TabIndex = 1
        Role.Text = "Role"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(58, 89)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 15)
        Label3.TabIndex = 2
        Label3.Text = "Password"
        ' 
        ' TxtUsername
        ' 
        TxtUsername.Location = New Point(191, 33)
        TxtUsername.Margin = New Padding(3, 2, 3, 2)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(417, 23)
        TxtUsername.TabIndex = 3
        ' 
        ' TxtPassword
        ' 
        TxtPassword.Location = New Point(191, 84)
        TxtPassword.Margin = New Padding(3, 2, 3, 2)
        TxtPassword.Name = "TxtPassword"
        TxtPassword.Size = New Size(417, 23)
        TxtPassword.TabIndex = 4
        ' 
        ' CmbRole
        ' 
        CmbRole.FormattingEnabled = True
        CmbRole.Location = New Point(191, 56)
        CmbRole.Margin = New Padding(3, 2, 3, 2)
        CmbRole.Name = "CmbRole"
        CmbRole.Size = New Size(417, 23)
        CmbRole.TabIndex = 5
        ' 
        ' BtnTambah
        ' 
        BtnTambah.Location = New Point(191, 160)
        BtnTambah.Margin = New Padding(3, 2, 3, 2)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(82, 22)
        BtnTambah.TabIndex = 6
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = True
        ' 
        ' BtnEdit
        ' 
        BtnEdit.Location = New Point(339, 160)
        BtnEdit.Margin = New Padding(3, 2, 3, 2)
        BtnEdit.Name = "BtnEdit"
        BtnEdit.Size = New Size(82, 22)
        BtnEdit.TabIndex = 7
        BtnEdit.Text = "Edit"
        BtnEdit.UseVisualStyleBackColor = True
        ' 
        ' BtnHapus
        ' 
        BtnHapus.Location = New Point(479, 160)
        BtnHapus.Margin = New Padding(3, 2, 3, 2)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(82, 22)
        BtnHapus.TabIndex = 8
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = True
        ' 
        ' DgvAkun
        ' 
        DgvAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvAkun.Location = New Point(-2, 198)
        DgvAkun.Margin = New Padding(3, 2, 3, 2)
        DgvAkun.Name = "DgvAkun"
        DgvAkun.RowHeadersWidth = 51
        DgvAkun.Size = New Size(1662, 531)
        DgvAkun.TabIndex = 9
        ' 
        ' FormKelolaAkun
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1195, 559)
        Controls.Add(DgvAkun)
        Controls.Add(BtnHapus)
        Controls.Add(BtnEdit)
        Controls.Add(BtnTambah)
        Controls.Add(CmbRole)
        Controls.Add(TxtPassword)
        Controls.Add(TxtUsername)
        Controls.Add(Label3)
        Controls.Add(Role)
        Controls.Add(Username)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MaximumSize = New Size(1682, 821)
        MinimumSize = New Size(1196, 549)
        Name = "FormKelolaAkun"
        Text = "FormKelolaAkun"
        WindowState = FormWindowState.Maximized
        CType(DgvAkun, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Username As Label
    Friend WithEvents Role As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents CmbRole As ComboBox
    Friend WithEvents BtnTambah As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents DgvAkun As DataGridView
End Class
