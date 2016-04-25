<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class kurs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(kurs))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 64)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Legg til kurs"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 152)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(130, 64)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Endre kurs"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 292)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(130, 64)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Lukk"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(165, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(863, 344)
        Me.DataGridView1.TabIndex = 4
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 222)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(130, 64)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Slett kurs"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(438, 370)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(146, 23)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "Kurs"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 370)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(152, 29)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(12, 82)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(130, 64)
        Me.Button6.TabIndex = 15
        Me.Button6.Text = "Påmelding"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(680, 370)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(146, 23)
        Me.Button7.TabIndex = 16
        Me.Button7.Text = "Påmeldinger"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'kurs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1040, 411)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "kurs"
        Me.Text = "kurs"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
End Class
