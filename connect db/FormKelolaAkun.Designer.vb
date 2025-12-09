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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKelolaAkun))
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
        Username.BackColor = Color.Transparent
        Username.Font = New Font("Tahoma", 9.75F, FontStyle.Bold)
        Username.ForeColor = Color.DarkGoldenrod
        Username.Location = New Point(295, 105)
        Username.Name = "Username"
        Username.Size = New Size(71, 16)
        Username.TabIndex = 0
        Username.Text = "Username"
        ' 
        ' Role
        ' 
        Role.AutoSize = True
        Role.BackColor = Color.Transparent
        Role.Font = New Font("Tahoma", 9.75F, FontStyle.Bold)
        Role.ForeColor = Color.DarkGoldenrod
        Role.Location = New Point(295, 134)
        Role.Name = "Role"
        Role.Size = New Size(35, 16)
        Role.TabIndex = 1
        Role.Text = "Role"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Tahoma", 9.75F, FontStyle.Bold)
        Label3.ForeColor = Color.DarkGoldenrod
        Label3.Location = New Point(295, 161)
        Label3.Name = "Label3"
        Label3.Size = New Size(70, 16)
        Label3.TabIndex = 2
        Label3.Text = "Password"
        ' 
        ' TxtUsername
        ' 
        TxtUsername.Location = New Point(428, 105)
        TxtUsername.Margin = New Padding(3, 2, 3, 2)
        TxtUsername.Name = "TxtUsername"
        TxtUsername.Size = New Size(417, 23)
        TxtUsername.TabIndex = 3
        ' 
        ' TxtPassword
        ' 
        TxtPassword.Location = New Point(428, 156)
        TxtPassword.Margin = New Padding(3, 2, 3, 2)
        TxtPassword.Name = "TxtPassword"
        TxtPassword.Size = New Size(417, 23)
        TxtPassword.TabIndex = 4
        ' 
        ' CmbRole
        ' 
        CmbRole.FormattingEnabled = True
        CmbRole.Location = New Point(428, 128)
        CmbRole.Margin = New Padding(3, 2, 3, 2)
        CmbRole.Name = "CmbRole"
        CmbRole.Size = New Size(417, 23)
        CmbRole.TabIndex = 5
        ' 
        ' BtnTambah
        ' 
        BtnTambah.BackColor = Color.Bisque
        BtnTambah.Font = New Font("Tahoma", 9.75F)
        BtnTambah.ForeColor = Color.DarkGoldenrod
        BtnTambah.Location = New Point(393, 230)
        BtnTambah.Margin = New Padding(3, 2, 3, 2)
        BtnTambah.Name = "BtnTambah"
        BtnTambah.Size = New Size(82, 22)
        BtnTambah.TabIndex = 6
        BtnTambah.Text = "Tambah"
        BtnTambah.UseVisualStyleBackColor = False
        ' 
        ' BtnEdit
        ' 
        BtnEdit.BackColor = Color.Bisque
        BtnEdit.Font = New Font("Tahoma", 9.75F)
        BtnEdit.ForeColor = Color.DarkGoldenrod
        BtnEdit.Location = New Point(541, 230)
        BtnEdit.Margin = New Padding(3, 2, 3, 2)
        BtnEdit.Name = "BtnEdit"
        BtnEdit.Size = New Size(82, 22)
        BtnEdit.TabIndex = 7
        BtnEdit.Text = "Edit"
        BtnEdit.UseVisualStyleBackColor = False
        ' 
        ' BtnHapus
        ' 
        BtnHapus.BackColor = Color.Bisque
        BtnHapus.Font = New Font("Tahoma", 9.75F)
        BtnHapus.ForeColor = Color.DarkGoldenrod
        BtnHapus.Location = New Point(681, 230)
        BtnHapus.Margin = New Padding(3, 2, 3, 2)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(82, 22)
        BtnHapus.TabIndex = 8
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = False
        ' 
        ' DgvAkun
        ' 
        DgvAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvAkun.Location = New Point(-2, 298)
        DgvAkun.Margin = New Padding(3, 2, 3, 2)
        DgvAkun.Name = "DgvAkun"
        DgvAkun.RowHeadersWidth = 51
        DgvAkun.Size = New Size(1662, 431)
        DgvAkun.TabIndex = 9
        ' 
        ' FormKelolaAkun
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
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
        MaximumSize = New Size(1215, 602)
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
