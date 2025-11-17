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
        txtUser.Font = New Font("Unispace", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtUser.Location = New Point(724, 422)
        txtUser.Multiline = True
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(712, 40)
        txtUser.TabIndex = 2
        ' 
        ' txtPass
        ' 
        txtPass.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtPass.BorderStyle = BorderStyle.None
        txtPass.Font = New Font("Unispace", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtPass.Location = New Point(724, 486)
        txtPass.Multiline = True
        txtPass.Name = "txtPass"
        txtPass.PasswordChar = "x"c
        txtPass.Size = New Size(712, 40)
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
        Button1.Font = New Font("Sharpy Shadow", 23.9999981F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(802, 584)
        Button1.Name = "Button1"
        Button1.Size = New Size(243, 46)
        Button1.TabIndex = 4
        Button1.Text = "Login"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1896, 967)
        Controls.Add(Button1)
        Controls.Add(txtPass)
        Controls.Add(txtUser)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        MaximumSize = New Size(1920, 1080)
        MdiChildrenMinimizedAnchorBottom = False
        MinimumSize = New Size(1918, 1018)
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
