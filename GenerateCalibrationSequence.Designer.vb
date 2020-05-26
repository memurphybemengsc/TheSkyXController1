<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerateCalibrationSequence
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
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnGenSeq = New System.Windows.Forms.Button()
        Me.NumUDNoOfSubs = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtBoxImageFolder = New System.Windows.Forms.TextBox()
        Me.BtnSelectImageFolder = New System.Windows.Forms.Button()
        CType(Me.NumUDNoOfSubs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(447, 85)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(134, 23)
        Me.BtnExit.TabIndex = 11
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'BtnGenSeq
        '
        Me.BtnGenSeq.Location = New System.Drawing.Point(298, 83)
        Me.BtnGenSeq.Name = "BtnGenSeq"
        Me.BtnGenSeq.Size = New System.Drawing.Size(134, 23)
        Me.BtnGenSeq.TabIndex = 10
        Me.BtnGenSeq.Text = "Generate Sequence"
        Me.BtnGenSeq.UseVisualStyleBackColor = True
        '
        'NumUDNoOfSubs
        '
        Me.NumUDNoOfSubs.Location = New System.Drawing.Point(174, 83)
        Me.NumUDNoOfSubs.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumUDNoOfSubs.Name = "NumUDNoOfSubs"
        Me.NumUDNoOfSubs.Size = New System.Drawing.Size(56, 20)
        Me.NumUDNoOfSubs.TabIndex = 9
        Me.NumUDNoOfSubs.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Number of Subs"
        '
        'TxtBoxImageFolder
        '
        Me.TxtBoxImageFolder.BackColor = System.Drawing.Color.White
        Me.TxtBoxImageFolder.Location = New System.Drawing.Point(174, 25)
        Me.TxtBoxImageFolder.Name = "TxtBoxImageFolder"
        Me.TxtBoxImageFolder.ReadOnly = True
        Me.TxtBoxImageFolder.Size = New System.Drawing.Size(373, 20)
        Me.TxtBoxImageFolder.TabIndex = 7
        '
        'BtnSelectImageFolder
        '
        Me.BtnSelectImageFolder.Location = New System.Drawing.Point(20, 23)
        Me.BtnSelectImageFolder.Name = "BtnSelectImageFolder"
        Me.BtnSelectImageFolder.Size = New System.Drawing.Size(127, 23)
        Me.BtnSelectImageFolder.TabIndex = 6
        Me.BtnSelectImageFolder.Text = "Select Image Folder"
        Me.BtnSelectImageFolder.UseVisualStyleBackColor = True
        '
        'GenerateCalibrationSequence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 139)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnGenSeq)
        Me.Controls.Add(Me.NumUDNoOfSubs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtBoxImageFolder)
        Me.Controls.Add(Me.BtnSelectImageFolder)
        Me.Name = "GenerateCalibrationSequence"
        Me.Text = "Generate Calibration Sequence"
        CType(Me.NumUDNoOfSubs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnExit As Button
    Friend WithEvents BtnGenSeq As Button
    Friend WithEvents NumUDNoOfSubs As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtBoxImageFolder As TextBox
    Friend WithEvents BtnSelectImageFolder As Button
End Class
