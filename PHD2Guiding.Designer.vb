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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumUDGeneralTimeoutInSeconds = New System.Windows.Forms.NumericUpDown()
        CType(Me.NumUDTcpPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUDSettleTimeInSecs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUDGeneralTimeoutInSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TCP Port"
        '
        'NumUDTcpPort
        '
        Me.NumUDTcpPort.Location = New System.Drawing.Point(140, 71)
        Me.NumUDTcpPort.Maximum = New Decimal(New Integer() {4399, 0, 0, 0})
        Me.NumUDTcpPort.Minimum = New Decimal(New Integer() {4300, 0, 0, 0})
        Me.NumUDTcpPort.Name = "NumUDTcpPort"
        Me.NumUDTcpPort.Size = New System.Drawing.Size(120, 20)
        Me.NumUDTcpPort.TabIndex = 1
        Me.NumUDTcpPort.Value = New Decimal(New Integer() {4300, 0, 0, 0})
        '
        'BtnConnect
        '
        Me.BtnConnect.Location = New System.Drawing.Point(110, 287)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Size = New System.Drawing.Size(75, 23)
        Me.BtnConnect.TabIndex = 2
        Me.BtnConnect.Text = "Connect"
        Me.BtnConnect.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(244, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "If you are using a second instance of PHD," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "you will need to change the port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Dither by"
        '
        'ListBoxDitherBy
        '
        Me.ListBoxDitherBy.FormattingEnabled = True
        Me.ListBoxDitherBy.Location = New System.Drawing.Point(140, 102)
        Me.ListBoxDitherBy.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ListBoxDitherBy.Name = "ListBoxDitherBy"
        Me.ListBoxDitherBy.Size = New System.Drawing.Size(91, 69)
        Me.ListBoxDitherBy.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Settling Time (s)"
        '
        'NumUDSettleTimeInSecs
        '
        Me.NumUDSettleTimeInSecs.DecimalPlaces = 1
        Me.NumUDSettleTimeInSecs.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.NumUDSettleTimeInSecs.Location = New System.Drawing.Point(140, 180)
        Me.NumUDSettleTimeInSecs.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumUDSettleTimeInSecs.Name = "NumUDSettleTimeInSecs"
        Me.NumUDSettleTimeInSecs.Size = New System.Drawing.Size(120, 20)
        Me.NumUDSettleTimeInSecs.TabIndex = 7
        Me.NumUDSettleTimeInSecs.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'CheckBoxUseJSON
        '
        Me.CheckBoxUseJSON.AutoSize = True
        Me.CheckBoxUseJSON.Location = New System.Drawing.Point(140, 216)
        Me.CheckBoxUseJSON.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CheckBoxUseJSON.Name = "CheckBoxUseJSON"
        Me.CheckBoxUseJSON.Size = New System.Drawing.Size(76, 17)
        Me.CheckBoxUseJSON.TabIndex = 9
        Me.CheckBoxUseJSON.Text = "Use JSON"
        Me.CheckBoxUseJSON.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 250)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "General Timeout (s)"
        '
        'NumUDGeneralTimeoutInSeconds
        '
        Me.NumUDGeneralTimeoutInSeconds.DecimalPlaces = 1
        Me.NumUDGeneralTimeoutInSeconds.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumUDGeneralTimeoutInSeconds.Location = New System.Drawing.Point(140, 243)
        Me.NumUDGeneralTimeoutInSeconds.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumUDGeneralTimeoutInSeconds.Name = "NumUDGeneralTimeoutInSeconds"
        Me.NumUDGeneralTimeoutInSeconds.Size = New System.Drawing.Size(120, 20)
        Me.NumUDGeneralTimeoutInSeconds.TabIndex = 11
        Me.NumUDGeneralTimeoutInSeconds.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'PHD2Guiding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 322)
        Me.Controls.Add(Me.NumUDGeneralTimeoutInSeconds)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CheckBoxUseJSON)
        Me.Controls.Add(Me.NumUDSettleTimeInSecs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ListBoxDitherBy)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnConnect)
        Me.Controls.Add(Me.NumUDTcpPort)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PHD2Guiding"
        Me.Text = "PHD2 Connection Setup"
        CType(Me.NumUDTcpPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUDSettleTimeInSecs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUDGeneralTimeoutInSeconds, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label5 As Label
    Friend WithEvents NumUDGeneralTimeoutInSeconds As NumericUpDown
End Class
