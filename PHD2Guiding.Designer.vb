<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PHD2Guiding
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumUDTcpPort = New System.Windows.Forms.NumericUpDown()
        Me.BtnConnect = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListBoxDitherBy = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumUDSettleTimeInSecs = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxUseJSON = New System.Windows.Forms.CheckBox()
        CType(Me.NumUDTcpPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUDSettleTimeInSecs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 96)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TCP Port"
        '
        'NumUDTcpPort
        '
        Me.NumUDTcpPort.Location = New System.Drawing.Point(163, 87)
        Me.NumUDTcpPort.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumUDTcpPort.Maximum = New Decimal(New Integer() {4399, 0, 0, 0})
        Me.NumUDTcpPort.Minimum = New Decimal(New Integer() {4300, 0, 0, 0})
        Me.NumUDTcpPort.Name = "NumUDTcpPort"
        Me.NumUDTcpPort.Size = New System.Drawing.Size(160, 22)
        Me.NumUDTcpPort.TabIndex = 1
        Me.NumUDTcpPort.Value = New Decimal(New Integer() {4300, 0, 0, 0})
        '
        'BtnConnect
        '
        Me.BtnConnect.Location = New System.Drawing.Point(110, 313)
        Me.BtnConnect.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Size = New System.Drawing.Size(100, 28)
        Me.BtnConnect.TabIndex = 2
        Me.BtnConnect.Text = "Connect"
        Me.BtnConnect.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 30)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(325, 39)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "If you are using a second instance of PHD," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "you will need to change the port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 126)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Dither by"
        '
        'ListBoxDitherBy
        '
        Me.ListBoxDitherBy.FormattingEnabled = True
        Me.ListBoxDitherBy.ItemHeight = 16
        Me.ListBoxDitherBy.Location = New System.Drawing.Point(163, 126)
        Me.ListBoxDitherBy.Name = "ListBoxDitherBy"
        Me.ListBoxDitherBy.Size = New System.Drawing.Size(120, 84)
        Me.ListBoxDitherBy.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 222)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Settling Time (s)"
        '
        'NumUDSettleTimeInSecs
        '
        Me.NumUDSettleTimeInSecs.DecimalPlaces = 1
        Me.NumUDSettleTimeInSecs.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.NumUDSettleTimeInSecs.Location = New System.Drawing.Point(163, 222)
        Me.NumUDSettleTimeInSecs.Margin = New System.Windows.Forms.Padding(4)
        Me.NumUDSettleTimeInSecs.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumUDSettleTimeInSecs.Name = "NumUDSettleTimeInSecs"
        Me.NumUDSettleTimeInSecs.Size = New System.Drawing.Size(160, 22)
        Me.NumUDSettleTimeInSecs.TabIndex = 7
        Me.NumUDSettleTimeInSecs.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'CheckBoxUseJSON
        '
        Me.CheckBoxUseJSON.AutoSize = True
        Me.CheckBoxUseJSON.Location = New System.Drawing.Point(163, 266)
        Me.CheckBoxUseJSON.Name = "CheckBoxUseJSON"
        Me.CheckBoxUseJSON.Size = New System.Drawing.Size(96, 21)
        Me.CheckBoxUseJSON.TabIndex = 9
        Me.CheckBoxUseJSON.Text = "Use JSON"
        Me.CheckBoxUseJSON.UseVisualStyleBackColor = True
        '
        'PHD2Guiding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 396)
        Me.Controls.Add(Me.CheckBoxUseJSON)
        Me.Controls.Add(Me.NumUDSettleTimeInSecs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ListBoxDitherBy)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnConnect)
        Me.Controls.Add(Me.NumUDTcpPort)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "PHD2Guiding"
        Me.Text = "PHD2 Connection Setup"
        CType(Me.NumUDTcpPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUDSettleTimeInSecs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents NumUDTcpPort As NumericUpDown
    Friend WithEvents BtnConnect As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ListBoxDitherBy As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NumUDSettleTimeInSecs As NumericUpDown
    Friend WithEvents CheckBoxUseJSON As CheckBox
End Class
