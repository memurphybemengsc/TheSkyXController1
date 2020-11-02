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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumUpDnHaltIfMountBelow = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumUpDnHaltIfSunAboveDeg = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumUpDnPaugeImagingIfGuidingStopped = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NumUpDnPaugeImagingIfGuidingResumed = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CheckBoxEnablePauseImagingIfGuidingStops = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEnableResumeImagingIfGuidingStarts = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRunCLSOnImagingResume = New System.Windows.Forms.CheckBox()
        CType(Me.NumUpDownCLSTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDnHaltIfMountBelow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDnHaltIfSunAboveDeg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDnPaugeImagingIfGuidingStopped, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDnPaugeImagingIfGuidingResumed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSelectFolder
        '
        Me.BtnSelectFolder.Location = New System.Drawing.Point(25, 21)
        Me.BtnSelectFolder.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnSelectFolder.Name = "BtnSelectFolder"
        Me.BtnSelectFolder.Size = New System.Drawing.Size(98, 19)
        Me.BtnSelectFolder.TabIndex = 0
        Me.BtnSelectFolder.Text = "Image Folder"
        Me.BtnSelectFolder.UseVisualStyleBackColor = True
        '
        'TxtImageFolder
        '
        Me.TxtImageFolder.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtImageFolder.Location = New System.Drawing.Point(157, 22)
        Me.TxtImageFolder.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtImageFolder.Name = "TxtImageFolder"
        Me.TxtImageFolder.ReadOnly = True
        Me.TxtImageFolder.Size = New System.Drawing.Size(388, 20)
        Me.TxtImageFolder.TabIndex = 1
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(246, 236)
        Me.BtnExit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(56, 19)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "CLS to"
        '
        'NumUpDownCLSTo
        '
        Me.NumUpDownCLSTo.DecimalPlaces = 1
        Me.NumUpDownCLSTo.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumUpDownCLSTo.Location = New System.Drawing.Point(157, 64)
        Me.NumUpDownCLSTo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.NumUpDownCLSTo.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumUpDownCLSTo.Name = "NumUpDownCLSTo"
        Me.NumUpDownCLSTo.Size = New System.Drawing.Size(90, 20)
        Me.NumUpDownCLSTo.TabIndex = 5
        Me.NumUpDownCLSTo.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(284, 68)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Arcseconds"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 104)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Halt if mount is below"
        '
        'NumUpDnHaltIfMountBelow
        '
        Me.NumUpDnHaltIfMountBelow.Location = New System.Drawing.Point(157, 97)
        Me.NumUpDnHaltIfMountBelow.Margin = New System.Windows.Forms.Padding(2)
        Me.NumUpDnHaltIfMountBelow.Maximum = New Decimal(New Integer() {80, 0, 0, 0})
        Me.NumUpDnHaltIfMountBelow.Name = "NumUpDnHaltIfMountBelow"
        Me.NumUpDnHaltIfMountBelow.Size = New System.Drawing.Size(90, 20)
        Me.NumUpDnHaltIfMountBelow.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(261, 104)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Degrees Altitude"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(261, 137)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Degrees Altitude"
        '
        'NumUpDnHaltIfSunAboveDeg
        '
        Me.NumUpDnHaltIfSunAboveDeg.Location = New System.Drawing.Point(157, 130)
        Me.NumUpDnHaltIfSunAboveDeg.Margin = New System.Windows.Forms.Padding(2)
        Me.NumUpDnHaltIfSunAboveDeg.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumUpDnHaltIfSunAboveDeg.Minimum = New Decimal(New Integer() {80, 0, 0, -2147483648})
        Me.NumUpDnHaltIfSunAboveDeg.Name = "NumUpDnHaltIfSunAboveDeg"
        Me.NumUpDnHaltIfSunAboveDeg.Size = New System.Drawing.Size(90, 20)
        Me.NumUpDnHaltIfSunAboveDeg.TabIndex = 11
        Me.NumUpDnHaltIfSunAboveDeg.Value = New Decimal(New Integer() {18, 0, 0, -2147483648})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 137)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Halt if Sun is above"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(298, 174)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "minutes"
        '
        'NumUpDnPaugeImagingIfGuidingStopped
        '
        Me.NumUpDnPaugeImagingIfGuidingStopped.Location = New System.Drawing.Point(194, 167)
        Me.NumUpDnPaugeImagingIfGuidingStopped.Margin = New System.Windows.Forms.Padding(2)
        Me.NumUpDnPaugeImagingIfGuidingStopped.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumUpDnPaugeImagingIfGuidingStopped.Name = "NumUpDnPaugeImagingIfGuidingStopped"
        Me.NumUpDnPaugeImagingIfGuidingStopped.Size = New System.Drawing.Size(90, 20)
        Me.NumUpDnPaugeImagingIfGuidingStopped.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 174)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(164, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Pause imaging if guiding stops for"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(298, 209)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "minutes"
        '
        'NumUpDnPaugeImagingIfGuidingResumed
        '
        Me.NumUpDnPaugeImagingIfGuidingResumed.Location = New System.Drawing.Point(194, 202)
        Me.NumUpDnPaugeImagingIfGuidingResumed.Margin = New System.Windows.Forms.Padding(2)
        Me.NumUpDnPaugeImagingIfGuidingResumed.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumUpDnPaugeImagingIfGuidingResumed.Name = "NumUpDnPaugeImagingIfGuidingResumed"
        Me.NumUpDnPaugeImagingIfGuidingResumed.Size = New System.Drawing.Size(90, 20)
        Me.NumUpDnPaugeImagingIfGuidingResumed.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 209)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(164, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Resume Imaging after Guiding for"
        '
        'CheckBoxEnablePauseImagingIfGuidingStops
        '
        Me.CheckBoxEnablePauseImagingIfGuidingStops.AutoSize = True
        Me.CheckBoxEnablePauseImagingIfGuidingStops.Location = New System.Drawing.Point(361, 174)
        Me.CheckBoxEnablePauseImagingIfGuidingStops.Name = "CheckBoxEnablePauseImagingIfGuidingStops"
        Me.CheckBoxEnablePauseImagingIfGuidingStops.Size = New System.Drawing.Size(59, 17)
        Me.CheckBoxEnablePauseImagingIfGuidingStops.TabIndex = 19
        Me.CheckBoxEnablePauseImagingIfGuidingStops.Text = "Enable"
        Me.CheckBoxEnablePauseImagingIfGuidingStops.UseVisualStyleBackColor = True
        '
        'CheckBoxEnableResumeImagingIfGuidingStarts
        '
        Me.CheckBoxEnableResumeImagingIfGuidingStarts.AutoSize = True
        Me.CheckBoxEnableResumeImagingIfGuidingStarts.Location = New System.Drawing.Point(362, 209)
        Me.CheckBoxEnableResumeImagingIfGuidingStarts.Name = "CheckBoxEnableResumeImagingIfGuidingStarts"
        Me.CheckBoxEnableResumeImagingIfGuidingStarts.Size = New System.Drawing.Size(59, 17)
        Me.CheckBoxEnableResumeImagingIfGuidingStarts.TabIndex = 20
        Me.CheckBoxEnableResumeImagingIfGuidingStarts.Text = "Enable"
        Me.CheckBoxEnableResumeImagingIfGuidingStarts.UseVisualStyleBackColor = True
        '
        'CheckBoxRunCLSOnImagingResume
        '
        Me.CheckBoxRunCLSOnImagingResume.AutoSize = True
        Me.CheckBoxRunCLSOnImagingResume.Location = New System.Drawing.Point(427, 208)
        Me.CheckBoxRunCLSOnImagingResume.Name = "CheckBoxRunCLSOnImagingResume"
        Me.CheckBoxRunCLSOnImagingResume.Size = New System.Drawing.Size(126, 17)
        Me.CheckBoxRunCLSOnImagingResume.TabIndex = 21
        Me.CheckBoxRunCLSOnImagingResume.Text = "Run CLS on Resume"
        Me.CheckBoxRunCLSOnImagingResume.UseVisualStyleBackColor = True
        '
        'ImagingSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(600, 266)
        Me.Controls.Add(Me.CheckBoxRunCLSOnImagingResume)
        Me.Controls.Add(Me.CheckBoxEnableResumeImagingIfGuidingStarts)
        Me.Controls.Add(Me.CheckBoxEnablePauseImagingIfGuidingStops)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.NumUpDnPaugeImagingIfGuidingResumed)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.NumUpDnPaugeImagingIfGuidingStopped)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NumUpDnHaltIfSunAboveDeg)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumUpDnHaltIfMountBelow)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumUpDownCLSTo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.TxtImageFolder)
        Me.Controls.Add(Me.BtnSelectFolder)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "ImagingSettings"
        Me.Text = "ImagingSettings"
        CType(Me.NumUpDownCLSTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDnHaltIfMountBelow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDnHaltIfSunAboveDeg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDnPaugeImagingIfGuidingStopped, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDnPaugeImagingIfGuidingResumed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSelectFolder As Button
    Friend WithEvents TxtImageFolder As TextBox
    Friend WithEvents BtnExit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents NumUpDownCLSTo As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents NumUpDnHaltIfMountBelow As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents NumUpDnHaltIfSunAboveDeg As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents NumUpDnPaugeImagingIfGuidingStopped As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents NumUpDnPaugeImagingIfGuidingResumed As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents CheckBoxEnablePauseImagingIfGuidingStops As CheckBox
    Friend WithEvents CheckBoxEnableResumeImagingIfGuidingStarts As CheckBox
    Friend WithEvents CheckBoxRunCLSOnImagingResume As CheckBox
End Class
