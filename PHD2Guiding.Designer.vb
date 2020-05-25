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
        CType(Me.NumUDTcpPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TCP Port"
        '
        'NumUDTcpPort
        '
        Me.NumUDTcpPort.Location = New System.Drawing.Point(123, 22)
        Me.NumUDTcpPort.Maximum = New Decimal(New Integer() {4399, 0, 0, 0})
        Me.NumUDTcpPort.Minimum = New Decimal(New Integer() {4300, 0, 0, 0})
        Me.NumUDTcpPort.Name = "NumUDTcpPort"
        Me.NumUDTcpPort.Size = New System.Drawing.Size(120, 20)
        Me.NumUDTcpPort.TabIndex = 1
        Me.NumUDTcpPort.Value = New Decimal(New Integer() {4300, 0, 0, 0})
        '
        'BtnConnect
        '
        Me.BtnConnect.Location = New System.Drawing.Point(89, 77)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Size = New System.Drawing.Size(75, 23)
        Me.BtnConnect.TabIndex = 2
        Me.BtnConnect.Text = "Connect"
        Me.BtnConnect.UseVisualStyleBackColor = True
        '
        'PHD2Guiding1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 125)
        Me.Controls.Add(Me.BtnConnect)
        Me.Controls.Add(Me.NumUDTcpPort)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PHD2Guiding1"
        Me.Text = "PHD2 Connection Setup"
        CType(Me.NumUDTcpPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents NumUDTcpPort As NumericUpDown
    Friend WithEvents BtnConnect As Button
End Class
