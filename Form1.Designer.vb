<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.BtnSkyX = New System.Windows.Forms.Button()
        Me.BtnPHD2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnSkyX
        '
        Me.BtnSkyX.Location = New System.Drawing.Point(12, 12)
        Me.BtnSkyX.Name = "BtnSkyX"
        Me.BtnSkyX.Size = New System.Drawing.Size(75, 23)
        Me.BtnSkyX.TabIndex = 0
        Me.BtnSkyX.Text = "SkyX"
        Me.BtnSkyX.UseVisualStyleBackColor = True
        '
        'BtnPHD2
        '
        Me.BtnPHD2.Location = New System.Drawing.Point(12, 41)
        Me.BtnPHD2.Name = "BtnPHD2"
        Me.BtnPHD2.Size = New System.Drawing.Size(75, 23)
        Me.BtnPHD2.TabIndex = 1
        Me.BtnPHD2.Text = "PHD2"
        Me.BtnPHD2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BtnPHD2)
        Me.Controls.Add(Me.BtnSkyX)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnSkyX As Button
    Friend WithEvents BtnPHD2 As Button
End Class
