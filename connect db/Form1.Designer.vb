<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        txtUser = New TextBox()
        txtPass = New TextBox()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' txtUser
        ' 
        txtUser.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtUser.BorderStyle = BorderStyle.None
        txtUser.Font = New Font("Microsoft Sans Serif", 16.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtUser.Location = New Point(456, 242)
        txtUser.Margin = New Padding(3, 2, 3, 2)
        txtUser.Multiline = True
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(452, 24)
        txtUser.TabIndex = 2
        ' 
        ' txtPass
        ' 
        txtPass.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtPass.BorderStyle = BorderStyle.None
        txtPass.Font = New Font("Microsoft Sans Serif", 16.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPass.Location = New Point(456, 280)
        txtPass.Margin = New Padding(3, 2, 3, 2)
        txtPass.Multiline = True
        txtPass.Name = "txtPass"
        txtPass.PasswordChar = "x"c
        txtPass.Size = New Size(452, 25)
        txtPass.TabIndex = 3
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Button1.BackColor = Color.Transparent
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatAppearance.MouseDownBackColor = Color.Transparent
        Button1.FlatAppearance.MouseOverBackColor = Color.Transparent
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.Sienna
        Button1.Location = New Point(483, 329)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(202, 43)
        Button1.TabIndex = 4
        Button1.Text = "Login"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1195, 559)
        Controls.Add(Button1)
        Controls.Add(txtPass)
        Controls.Add(txtUser)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MaximumSize = New Size(1682, 821)
        MdiChildrenMinimizedAnchorBottom = False
        MinimumSize = New Size(1196, 549)
        Name = "Form1"
        SizeGripStyle = SizeGripStyle.Hide
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents Button1 As Button

End Class
