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
        Me.BtnExit.Location = New System.Drawing.Point(356, 85)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'ImagingSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(800, 134)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.TxtImageFolder)
        Me.Controls.Add(Me.BtnSelectFolder)
        Me.Name = "ImagingSettings"
        Me.Text = "ImagingSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSelectFolder As Button
    Friend WithEvents TxtImageFolder As TextBox
    Friend WithEvents BtnExit As Button
End Class
