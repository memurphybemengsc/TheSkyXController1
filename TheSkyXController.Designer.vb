<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TheSkyXController
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
        Me.components = New System.ComponentModel.Container()
        Me.BtnSkyX = New System.Windows.Forms.Button()
        Me.BtnPHD2 = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.PnlImageSequence = New System.Windows.Forms.Panel()
        Me.BtnSequenceOpen = New System.Windows.Forms.Button()
        Me.BtnSeqenceAppend = New System.Windows.Forms.Button()
        Me.BtnSequenceSave = New System.Windows.Forms.Button()
        Me.PnlImageSeqTitles = New System.Windows.Forms.Panel()
        Me.LblRunPrevSuccess = New System.Windows.Forms.Label()
        Me.LblRunPrevError = New System.Windows.Forms.Label()
        Me.LblDitherEveryNImages = New System.Windows.Forms.Label()
        Me.LblRepeats = New System.Windows.Forms.Label()
        Me.LblBinY = New System.Windows.Forms.Label()
        Me.LblBinX = New System.Windows.Forms.Label()
        Me.LblExposureLength = New System.Windows.Forms.Label()
        Me.LblFilter = New System.Windows.Forms.Label()
        Me.LblExposureType = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnCalibrationFrames = New System.Windows.Forms.Button()
        Me.BtnStartImaging = New System.Windows.Forms.Button()
        Me.BtnPauseImaging = New System.Windows.Forms.Button()
        Me.BtnAbortImaging = New System.Windows.Forms.Button()
        Me.BtnSettingsImaging = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PnlPhd2Status = New System.Windows.Forms.Panel()
        Me.PnlSkyXStatus = New System.Windows.Forms.Panel()
        Me.BtnTest = New System.Windows.Forms.Button()
        Me.BtnLoadGroup = New System.Windows.Forms.Button()
        Me.TmrImagingLoop = New System.Windows.Forms.Timer(Me.components)
        Me.BtnStopImaging = New System.Windows.Forms.Button()
        Me.ToolTipStart = New System.Windows.Forms.ToolTip(Me.components)
        Me.PnlImageSeqTitles.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnSkyX
        '
        Me.BtnSkyX.Location = New System.Drawing.Point(16, 19)
        Me.BtnSkyX.Name = "BtnSkyX"
        Me.BtnSkyX.Size = New System.Drawing.Size(75, 23)
        Me.BtnSkyX.TabIndex = 0
        Me.BtnSkyX.Text = "SkyX"
        Me.BtnSkyX.UseVisualStyleBackColor = True
        '
        'BtnPHD2
        '
        Me.BtnPHD2.Location = New System.Drawing.Point(16, 55)
        Me.BtnPHD2.Name = "BtnPHD2"
        Me.BtnPHD2.Size = New System.Drawing.Size(75, 23)
        Me.BtnPHD2.TabIndex = 1
        Me.BtnPHD2.Text = "PHD2"
        Me.BtnPHD2.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(43, 443)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'PnlImageSequence
        '
        Me.PnlImageSequence.AutoScroll = True
        Me.PnlImageSequence.Location = New System.Drawing.Point(352, 12)
        Me.PnlImageSequence.Name = "PnlImageSequence"
        Me.PnlImageSequence.Size = New System.Drawing.Size(639, 236)
        Me.PnlImageSequence.TabIndex = 12
        '
        'BtnSequenceOpen
        '
        Me.BtnSequenceOpen.Location = New System.Drawing.Point(352, 262)
        Me.BtnSequenceOpen.Name = "BtnSequenceOpen"
        Me.BtnSequenceOpen.Size = New System.Drawing.Size(75, 23)
        Me.BtnSequenceOpen.TabIndex = 13
        Me.BtnSequenceOpen.Text = "Open"
        Me.BtnSequenceOpen.UseVisualStyleBackColor = True
        '
        'BtnSeqenceAppend
        '
        Me.BtnSeqenceAppend.Location = New System.Drawing.Point(448, 262)
        Me.BtnSeqenceAppend.Name = "BtnSeqenceAppend"
        Me.BtnSeqenceAppend.Size = New System.Drawing.Size(75, 23)
        Me.BtnSeqenceAppend.TabIndex = 14
        Me.BtnSeqenceAppend.Text = "Append"
        Me.BtnSeqenceAppend.UseVisualStyleBackColor = True
        '
        'BtnSequenceSave
        '
        Me.BtnSequenceSave.Location = New System.Drawing.Point(632, 262)
        Me.BtnSequenceSave.Name = "BtnSequenceSave"
        Me.BtnSequenceSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSequenceSave.TabIndex = 15
        Me.BtnSequenceSave.Text = "Save"
        Me.BtnSequenceSave.UseVisualStyleBackColor = True
        '
        'PnlImageSeqTitles
        '
        Me.PnlImageSeqTitles.Controls.Add(Me.LblRunPrevSuccess)
        Me.PnlImageSeqTitles.Controls.Add(Me.LblRunPrevError)
        Me.PnlImageSeqTitles.Controls.Add(Me.LblDitherEveryNImages)
        Me.PnlImageSeqTitles.Controls.Add(Me.LblRepeats)
        Me.PnlImageSeqTitles.Controls.Add(Me.LblBinY)
        Me.PnlImageSeqTitles.Controls.Add(Me.LblBinX)
        Me.PnlImageSeqTitles.Controls.Add(Me.LblExposureLength)
        Me.PnlImageSeqTitles.Controls.Add(Me.LblFilter)
        Me.PnlImageSeqTitles.Controls.Add(Me.LblExposureType)
        Me.PnlImageSeqTitles.Location = New System.Drawing.Point(185, 12)
        Me.PnlImageSeqTitles.Name = "PnlImageSeqTitles"
        Me.PnlImageSeqTitles.Size = New System.Drawing.Size(146, 236)
        Me.PnlImageSeqTitles.TabIndex = 16
        '
        'LblRunPrevSuccess
        '
        Me.LblRunPrevSuccess.AutoSize = True
        Me.LblRunPrevSuccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRunPrevSuccess.Location = New System.Drawing.Point(0, 98)
        Me.LblRunPrevSuccess.Name = "LblRunPrevSuccess"
        Me.LblRunPrevSuccess.Size = New System.Drawing.Size(129, 13)
        Me.LblRunPrevSuccess.TabIndex = 8
        Me.LblRunPrevSuccess.Text = "Run on previous Success"
        '
        'LblRunPrevError
        '
        Me.LblRunPrevError.AutoSize = True
        Me.LblRunPrevError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRunPrevError.Location = New System.Drawing.Point(0, 111)
        Me.LblRunPrevError.Name = "LblRunPrevError"
        Me.LblRunPrevError.Size = New System.Drawing.Size(110, 13)
        Me.LblRunPrevError.TabIndex = 7
        Me.LblRunPrevError.Text = "Run on previous Error"
        '
        'LblDitherEveryNImages
        '
        Me.LblDitherEveryNImages.AutoSize = True
        Me.LblDitherEveryNImages.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDitherEveryNImages.Location = New System.Drawing.Point(0, 84)
        Me.LblDitherEveryNImages.Name = "LblDitherEveryNImages"
        Me.LblDitherEveryNImages.Size = New System.Drawing.Size(113, 13)
        Me.LblDitherEveryNImages.TabIndex = 6
        Me.LblDitherEveryNImages.Text = "Dither Every N Images"
        '
        'LblRepeats
        '
        Me.LblRepeats.AutoSize = True
        Me.LblRepeats.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRepeats.Location = New System.Drawing.Point(0, 70)
        Me.LblRepeats.Name = "LblRepeats"
        Me.LblRepeats.Size = New System.Drawing.Size(47, 13)
        Me.LblRepeats.TabIndex = 5
        Me.LblRepeats.Text = "Repeats"
        '
        'LblBinY
        '
        Me.LblBinY.AutoSize = True
        Me.LblBinY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBinY.Location = New System.Drawing.Point(0, 56)
        Me.LblBinY.Name = "LblBinY"
        Me.LblBinY.Size = New System.Drawing.Size(32, 13)
        Me.LblBinY.TabIndex = 4
        Me.LblBinY.Text = "Bin Y"
        '
        'LblBinX
        '
        Me.LblBinX.AutoSize = True
        Me.LblBinX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBinX.Location = New System.Drawing.Point(0, 42)
        Me.LblBinX.Name = "LblBinX"
        Me.LblBinX.Size = New System.Drawing.Size(32, 13)
        Me.LblBinX.TabIndex = 3
        Me.LblBinX.Text = "Bin X"
        '
        'LblExposureLength
        '
        Me.LblExposureLength.AutoSize = True
        Me.LblExposureLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblExposureLength.Location = New System.Drawing.Point(0, 28)
        Me.LblExposureLength.Name = "LblExposureLength"
        Me.LblExposureLength.Size = New System.Drawing.Size(87, 13)
        Me.LblExposureLength.TabIndex = 2
        Me.LblExposureLength.Text = "Exposure Length"
        '
        'LblFilter
        '
        Me.LblFilter.AutoSize = True
        Me.LblFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilter.Location = New System.Drawing.Point(0, 14)
        Me.LblFilter.Name = "LblFilter"
        Me.LblFilter.Size = New System.Drawing.Size(29, 13)
        Me.LblFilter.TabIndex = 1
        Me.LblFilter.Text = "Filter"
        '
        'LblExposureType
        '
        Me.LblExposureType.AutoSize = True
        Me.LblExposureType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblExposureType.Location = New System.Drawing.Point(0, 0)
        Me.LblExposureType.Margin = New System.Windows.Forms.Padding(0)
        Me.LblExposureType.Name = "LblExposureType"
        Me.LblExposureType.Size = New System.Drawing.Size(78, 13)
        Me.LblExposureType.TabIndex = 0
        Me.LblExposureType.Text = "Exposure Type"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnStopImaging)
        Me.GroupBox2.Controls.Add(Me.BtnCalibrationFrames)
        Me.GroupBox2.Controls.Add(Me.BtnStartImaging)
        Me.GroupBox2.Controls.Add(Me.BtnPauseImaging)
        Me.GroupBox2.Controls.Add(Me.BtnAbortImaging)
        Me.GroupBox2.Controls.Add(Me.BtnSettingsImaging)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(144, 202)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Imaging"
        '
        'BtnCalibrationFrames
        '
        Me.BtnCalibrationFrames.Location = New System.Drawing.Point(16, 164)
        Me.BtnCalibrationFrames.Name = "BtnCalibrationFrames"
        Me.BtnCalibrationFrames.Size = New System.Drawing.Size(117, 23)
        Me.BtnCalibrationFrames.TabIndex = 9
        Me.BtnCalibrationFrames.Text = "Calibration Frames"
        Me.BtnCalibrationFrames.UseVisualStyleBackColor = True
        '
        'BtnStartImaging
        '
        Me.BtnStartImaging.Location = New System.Drawing.Point(31, 19)
        Me.BtnStartImaging.Name = "BtnStartImaging"
        Me.BtnStartImaging.Size = New System.Drawing.Size(75, 23)
        Me.BtnStartImaging.TabIndex = 2
        Me.BtnStartImaging.Text = "Start"
        Me.ToolTipStart.SetToolTip(Me.BtnStartImaging, "Start the Imaging Process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.BtnStartImaging.UseVisualStyleBackColor = True
        '
        'BtnPauseImaging
        '
        Me.BtnPauseImaging.Location = New System.Drawing.Point(31, 48)
        Me.BtnPauseImaging.Name = "BtnPauseImaging"
        Me.BtnPauseImaging.Size = New System.Drawing.Size(75, 23)
        Me.BtnPauseImaging.TabIndex = 3
        Me.BtnPauseImaging.Text = "Pause"
        Me.BtnPauseImaging.UseVisualStyleBackColor = True
        '
        'BtnAbortImaging
        '
        Me.BtnAbortImaging.Location = New System.Drawing.Point(31, 77)
        Me.BtnAbortImaging.Name = "BtnAbortImaging"
        Me.BtnAbortImaging.Size = New System.Drawing.Size(75, 23)
        Me.BtnAbortImaging.TabIndex = 4
        Me.BtnAbortImaging.Text = "Abort"
        Me.BtnAbortImaging.UseVisualStyleBackColor = True
        '
        'BtnSettingsImaging
        '
        Me.BtnSettingsImaging.Location = New System.Drawing.Point(31, 135)
        Me.BtnSettingsImaging.Name = "BtnSettingsImaging"
        Me.BtnSettingsImaging.Size = New System.Drawing.Size(75, 23)
        Me.BtnSettingsImaging.TabIndex = 5
        Me.BtnSettingsImaging.Text = "Settings"
        Me.BtnSettingsImaging.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PnlPhd2Status)
        Me.GroupBox1.Controls.Add(Me.PnlSkyXStatus)
        Me.GroupBox1.Controls.Add(Me.BtnPHD2)
        Me.GroupBox1.Controls.Add(Me.BtnSkyX)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(144, 100)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connect"
        '
        'PnlPhd2Status
        '
        Me.PnlPhd2Status.BackColor = System.Drawing.Color.Red
        Me.PnlPhd2Status.Location = New System.Drawing.Point(103, 55)
        Me.PnlPhd2Status.Name = "PnlPhd2Status"
        Me.PnlPhd2Status.Size = New System.Drawing.Size(25, 23)
        Me.PnlPhd2Status.TabIndex = 10
        '
        'PnlSkyXStatus
        '
        Me.PnlSkyXStatus.BackColor = System.Drawing.Color.Red
        Me.PnlSkyXStatus.Location = New System.Drawing.Point(103, 19)
        Me.PnlSkyXStatus.Name = "PnlSkyXStatus"
        Me.PnlSkyXStatus.Size = New System.Drawing.Size(25, 23)
        Me.PnlSkyXStatus.TabIndex = 9
        '
        'BtnTest
        '
        Me.BtnTest.Location = New System.Drawing.Point(43, 496)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.Size = New System.Drawing.Size(75, 23)
        Me.BtnTest.TabIndex = 11
        Me.BtnTest.Text = "Test"
        Me.BtnTest.UseVisualStyleBackColor = True
        '
        'BtnLoadGroup
        '
        Me.BtnLoadGroup.Location = New System.Drawing.Point(541, 262)
        Me.BtnLoadGroup.Name = "BtnLoadGroup"
        Me.BtnLoadGroup.Size = New System.Drawing.Size(75, 23)
        Me.BtnLoadGroup.TabIndex = 19
        Me.BtnLoadGroup.Text = "Load Group"
        Me.BtnLoadGroup.UseVisualStyleBackColor = True
        '
        'TmrImagingLoop
        '
        '
        'BtnStopImaging
        '
        Me.BtnStopImaging.Location = New System.Drawing.Point(31, 106)
        Me.BtnStopImaging.Name = "BtnStopImaging"
        Me.BtnStopImaging.Size = New System.Drawing.Size(75, 23)
        Me.BtnStopImaging.TabIndex = 20
        Me.BtnStopImaging.Text = "Stop"
        Me.BtnStopImaging.UseVisualStyleBackColor = True
        '
        'TheSkyXController
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 545)
        Me.Controls.Add(Me.BtnLoadGroup)
        Me.Controls.Add(Me.BtnTest)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PnlImageSeqTitles)
        Me.Controls.Add(Me.BtnSequenceSave)
        Me.Controls.Add(Me.BtnSeqenceAppend)
        Me.Controls.Add(Me.BtnSequenceOpen)
        Me.Controls.Add(Me.PnlImageSequence)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "TheSkyXController"
        Me.Text = "TheSkyXController"
        Me.PnlImageSeqTitles.ResumeLayout(False)
        Me.PnlImageSeqTitles.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnSkyX As Button
    Friend WithEvents BtnPHD2 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents PnlImageSequence As Panel
    Friend WithEvents BtnSequenceOpen As Button
    Friend WithEvents BtnSeqenceAppend As Button
    Friend WithEvents BtnSequenceSave As Button
    Friend WithEvents PnlImageSeqTitles As Panel
    Friend WithEvents LblDitherEveryNImages As Label
    Friend WithEvents LblRepeats As Label
    Friend WithEvents LblBinY As Label
    Friend WithEvents LblBinX As Label
    Friend WithEvents LblExposureLength As Label
    Friend WithEvents LblFilter As Label
    Friend WithEvents LblExposureType As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnCalibrationFrames As Button
    Friend WithEvents BtnStartImaging As Button
    Friend WithEvents BtnPauseImaging As Button
    Friend WithEvents BtnAbortImaging As Button
    Friend WithEvents BtnSettingsImaging As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PnlPhd2Status As Panel
    Friend WithEvents PnlSkyXStatus As Panel
    Friend WithEvents BtnTest As Button
    Friend WithEvents LblRunPrevSuccess As Label
    Friend WithEvents LblRunPrevError As Label
    Friend WithEvents BtnLoadGroup As Button
    Friend WithEvents TmrImagingLoop As Timer
    Friend WithEvents BtnStopImaging As Button
    Friend WithEvents ToolTipStart As ToolTip
End Class
