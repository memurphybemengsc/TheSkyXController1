<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImagingSettings
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
        Me.BtnSelectFolder = New System.Windows.Forms.Button()
        Me.TxtImageFolder = New System.Windows.Forms.TextBox()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumUpDownCLSTo = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.NumUpDownCLSTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSelectFolder
        '
        Me.BtnSelectFolder.Location = New System.Drawing.Point(33, 26)
        Me.BtnSelectFolder.Name = "BtnSelectFolder"
        Me.BtnSelectFolder.Size = New System.Drawing.Size(130, 23)
        Me.BtnSelectFolder.TabIndex = 0
        Me.BtnSelectFolder.Text = "Image Folder"
        Me.BtnSelectFolder.UseVisualStyleBackColor = True
        '
        'TxtImageFolder
        '
        Me.TxtImageFolder.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtImageFolder.Location = New System.Drawing.Point(209, 27)
        Me.TxtImageFolder.Name = "TxtImageFolder"
        Me.TxtImageFolder.ReadOnly = True
        Me.TxtImageFolder.Size = New System.Drawing.Size(516, 22)
        Me.TxtImageFolder.TabIndex = 1
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(351, 141)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "CLS to"
        '
        'NumUpDownCLSTo
        '
        Me.NumUpDownCLSTo.Location = New System.Drawing.Point(209, 79)
        Me.NumUpDownCLSTo.Name = "NumUpDownCLSTo"
        Me.NumUpDownCLSTo.Size = New System.Drawing.Size(120, 22)
        Me.NumUpDownCLSTo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(378, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Arcseconds"
        '
        'ImagingSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(800, 195)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumUpDownCLSTo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.TxtImageFolder)
        Me.Controls.Add(Me.BtnSelectFolder)
        Me.Name = "ImagingSettings"
        Me.Text = "ImagingSettings"
        CType(Me.NumUpDownCLSTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSelectFolder As Button
    Friend WithEvents TxtImageFolder As TextBox
    Friend WithEvents BtnExit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents NumUpDownCLSTo As NumericUpDown
    Friend WithEvents Label2 As Label
End Class
