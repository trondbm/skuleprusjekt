<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class leggtilkurs
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
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(111, 234)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(147, 20)
        Me.TextBox6.TabIndex = 42
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(111, 199)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(147, 20)
        Me.TextBox5.TabIndex = 41
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(49, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Postnr:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Maxantall:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Dato:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Navn:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(111, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(147, 20)
        Me.TextBox1.TabIndex = 34
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(89, 281)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(147, 50)
        Me.Button2.TabIndex = 33
        Me.Button2.Text = "Legg til"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(111, 73)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(147, 20)
        Me.DateTimePicker1.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Tidslengde:"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DecimalPlaces = 1
        Me.NumericUpDown1.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.NumericUpDown1.Location = New System.Drawing.Point(117, 115)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(52, 20)
        Me.NumericUpDown1.TabIndex = 46
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(49, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Ansatt:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(111, 157)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(146, 21)
        Me.ComboBox1.TabIndex = 48
        '
        'leggtilkurs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 347)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Name = "leggtilkurs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "leggtilkurs"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
