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
        Me.LblDelay = New System.Windows.Forms.Label()
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
        Me.BtnStopImaging = New System.Windows.Forms.Button()
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
        Me.ToolTipStart = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnTargetSearch = New System.Windows.Forms.Button()
        Me.BtnSlewLimits = New System.Windows.Forms.Button()
        Me.BtnSelectImage = New System.Windows.Forms.Button()
        Me.BtnRemoveTarget = New System.Windows.Forms.Button()
        Me.LblImageFolder = New System.Windows.Forms.Label()
        Me.TxtImageFolder = New System.Windows.Forms.TextBox()
        Me.LblFocuser = New System.Windows.Forms.Label()
        Me.LblFilterWheel = New System.Windows.Forms.Label()
        Me.LblCameraStatus = New System.Windows.Forms.Label()
        Me.LblTarget = New System.Windows.Forms.Label()
        Me.TxtTarget = New System.Windows.Forms.TextBox()
        Me.LblMount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PnlTxtTargetList = New System.Windows.Forms.Panel()
        Me.LblTargetListItem6 = New System.Windows.Forms.Label()
        Me.LblTargetListItem5 = New System.Windows.Forms.Label()
        Me.LblTargetListItem4 = New System.Windows.Forms.Label()
        Me.LblTargetListItem3 = New System.Windows.Forms.Label()
        Me.LblTargetListItem2 = New System.Windows.Forms.Label()
        Me.LblTargetListItem1 = New System.Windows.Forms.Label()
        Me.PnlImageSeqTitles.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PnlTxtTargetList.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnSkyX
        '
        Me.BtnSkyX.Location = New System.Drawing.Point(16, 19)
        Me.BtnSkyX.Name = "BtnSkyX"
        Me.BtnSkyX.Size = New System.Drawing.Size(75, 23)
        Me.BtnSkyX.TabIndex = 0
        Me.BtnSkyX.Text = "SkyX"
        Me.ToolTipStart.SetToolTip(Me.BtnSkyX, "Connect to TheSkyX")
        Me.BtnSkyX.UseVisualStyleBackColor = True
        '
        'BtnPHD2
        '
        Me.BtnPHD2.Location = New System.Drawing.Point(16, 55)
        Me.BtnPHD2.Name = "BtnPHD2"
        Me.BtnPHD2.Size = New System.Drawing.Size(75, 23)
        Me.BtnPHD2.TabIndex = 1
        Me.BtnPHD2.Text = "PHD2"
        Me.ToolTipStart.SetToolTip(Me.BtnPHD2, "Connect to PHD2")
        Me.BtnPHD2.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(43, 443)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Exit"
        Me.ToolTipStart.SetToolTip(Me.btnExit, "Exit the application")
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'PnlImageSequence
        '
        Me.PnlImageSequence.AutoScroll = True
        Me.PnlImageSequence.Location = New System.Drawing.Point(352, 12)
        Me.PnlImageSequence.Name = "PnlImageSequence"
        Me.PnlImageSequence.Size = New System.Drawing.Size(639, 250)
        Me.PnlImageSequence.TabIndex = 12
        '
        'BtnSequenceOpen
        '
        Me.BtnSequenceOpen.Location = New System.Drawing.Point(352, 282)
        Me.BtnSequenceOpen.Name = "BtnSequenceOpen"
        Me.BtnSequenceOpen.Size = New System.Drawing.Size(75, 23)
        Me.BtnSequenceOpen.TabIndex = 13
        Me.BtnSequenceOpen.Text = "Open"
        Me.ToolTipStart.SetToolTip(Me.BtnSequenceOpen, "Open a file containing an imaging sequence")
        Me.BtnSequenceOpen.UseVisualStyleBackColor = True
        '
        'BtnSeqenceAppend
        '
        Me.BtnSeqenceAppend.Location = New System.Drawing.Point(448, 282)
        Me.BtnSeqenceAppend.Name = "BtnSeqenceAppend"
        Me.BtnSeqenceAppend.Size = New System.Drawing.Size(75, 23)
        Me.BtnSeqenceAppend.TabIndex = 14
        Me.BtnSeqenceAppend.Text = "Append"
        Me.ToolTipStart.SetToolTip(Me.BtnSeqenceAppend, "Open a file containing an imaging sequence and append it to the current sequence")
        Me.BtnSeqenceAppend.UseVisualStyleBackColor = True
        '
        'BtnSequenceSave
        '
        Me.BtnSequenceSave.Location = New System.Drawing.Point(632, 282)
        Me.BtnSequenceSave.Name = "BtnSequenceSave"
        Me.BtnSequenceSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSequenceSave.TabIndex = 15
        Me.BtnSequenceSave.Text = "Save"
        Me.ToolTipStart.SetToolTip(Me.BtnSequenceSave, "Save a file with the current imaging sequence")
        Me.BtnSequenceSave.UseVisualStyleBackColor = True
        '
        'PnlImageSeqTitles
        '
        Me.PnlImageSeqTitles.Controls.Add(Me.LblDelay)
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
        Me.PnlImageSeqTitles.Size = New System.Drawing.Size(146, 250)
        Me.PnlImageSeqTitles.TabIndex = 16
        '
        'LblDelay
        '
        Me.LblDelay.AutoSize = True
        Me.LblDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDelay.Location = New System.Drawing.Point(0, 97)
        Me.LblDelay.Name = "LblDelay"
        Me.LblDelay.Size = New System.Drawing.Size(34, 13)
        Me.LblDelay.TabIndex = 9
        Me.LblDelay.Text = "Delay"
        '
        'LblRunPrevSuccess
        '
        Me.LblRunPrevSuccess.AutoSize = True
        Me.LblRunPrevSuccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRunPrevSuccess.Location = New System.Drawing.Point(0, 110)
        Me.LblRunPrevSuccess.Name = "LblRunPrevSuccess"
        Me.LblRunPrevSuccess.Size = New System.Drawing.Size(129, 13)
        Me.LblRunPrevSuccess.TabIndex = 8
        Me.LblRunPrevSuccess.Text = "Run on previous Success"
        '
        'LblRunPrevError
        '
        Me.LblRunPrevError.AutoSize = True
        Me.LblRunPrevError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRunPrevError.Location = New System.Drawing.Point(0, 123)
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
        'BtnStopImaging
        '
        Me.BtnStopImaging.Location = New System.Drawing.Point(31, 106)
        Me.BtnStopImaging.Name = "BtnStopImaging"
        Me.BtnStopImaging.Size = New System.Drawing.Size(75, 23)
        Me.BtnStopImaging.TabIndex = 20
        Me.BtnStopImaging.Text = "Stop"
        Me.ToolTipStart.SetToolTip(Me.BtnStopImaging, "Stop the imaging process, the current image will be completed")
        Me.BtnStopImaging.UseVisualStyleBackColor = True
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
        Me.ToolTipStart.SetToolTip(Me.BtnPauseImaging, "Pause the imaging process, The curent image will complete")
        Me.BtnPauseImaging.UseVisualStyleBackColor = True
        '
        'BtnAbortImaging
        '
        Me.BtnAbortImaging.Location = New System.Drawing.Point(31, 77)
        Me.BtnAbortImaging.Name = "BtnAbortImaging"
        Me.BtnAbortImaging.Size = New System.Drawing.Size(75, 23)
        Me.BtnAbortImaging.TabIndex = 4
        Me.BtnAbortImaging.Text = "Abort"
        Me.ToolTipStart.SetToolTip(Me.BtnAbortImaging, "Abort the imaging process, the current image will be abandoned")
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
        Me.BtnLoadGroup.Location = New System.Drawing.Point(541, 282)
        Me.BtnLoadGroup.Name = "BtnLoadGroup"
        Me.BtnLoadGroup.Size = New System.Drawing.Size(75, 23)
        Me.BtnLoadGroup.TabIndex = 19
        Me.BtnLoadGroup.Text = "Load Group"
        Me.ToolTipStart.SetToolTip(Me.BtnLoadGroup, "Open a file containing a group of imaging sequences")
        Me.BtnLoadGroup.UseVisualStyleBackColor = True
        '
        'TmrImagingLoop
        '
        Me.TmrImagingLoop.Interval = 5000
        '
        'BtnTargetSearch
        '
        Me.BtnTargetSearch.Location = New System.Drawing.Point(508, 408)
        Me.BtnTargetSearch.Name = "BtnTargetSearch"
        Me.BtnTargetSearch.Size = New System.Drawing.Size(75, 23)
        Me.BtnTargetSearch.TabIndex = 28
        Me.BtnTargetSearch.Text = "Search"
        Me.ToolTipStart.SetToolTip(Me.BtnTargetSearch, "Search the SkyX database for the target")
        Me.BtnTargetSearch.UseVisualStyleBackColor = True
        '
        'BtnSlewLimits
        '
        Me.BtnSlewLimits.Location = New System.Drawing.Point(508, 510)
        Me.BtnSlewLimits.Name = "BtnSlewLimits"
        Me.BtnSlewLimits.Size = New System.Drawing.Size(75, 23)
        Me.BtnSlewLimits.TabIndex = 21
        Me.BtnSlewLimits.Text = "Slew Limits"
        Me.ToolTipStart.SetToolTip(Me.BtnSlewLimits, "Start the Imaging Process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.BtnSlewLimits.UseVisualStyleBackColor = True
        '
        'BtnSelectImage
        '
        Me.BtnSelectImage.Enabled = False
        Me.BtnSelectImage.Location = New System.Drawing.Point(508, 443)
        Me.BtnSelectImage.Name = "BtnSelectImage"
        Me.BtnSelectImage.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelectImage.TabIndex = 32
        Me.BtnSelectImage.Text = "Image"
        Me.ToolTipStart.SetToolTip(Me.BtnSelectImage, "Search the SkyX database for the target")
        Me.BtnSelectImage.UseVisualStyleBackColor = True
        '
        'BtnRemoveTarget
        '
        Me.BtnRemoveTarget.Location = New System.Drawing.Point(508, 472)
        Me.BtnRemoveTarget.Name = "BtnRemoveTarget"
        Me.BtnRemoveTarget.Size = New System.Drawing.Size(75, 23)
        Me.BtnRemoveTarget.TabIndex = 34
        Me.BtnRemoveTarget.Text = "Remove"
        Me.ToolTipStart.SetToolTip(Me.BtnRemoveTarget, "Start the Imaging Process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.BtnRemoveTarget.UseVisualStyleBackColor = True
        '
        'LblImageFolder
        '
        Me.LblImageFolder.AutoSize = True
        Me.LblImageFolder.Location = New System.Drawing.Point(350, 326)
        Me.LblImageFolder.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblImageFolder.Name = "LblImageFolder"
        Me.LblImageFolder.Size = New System.Drawing.Size(68, 13)
        Me.LblImageFolder.TabIndex = 21
        Me.LblImageFolder.Text = "Image Folder"
        '
        'TxtImageFolder
        '
        Me.TxtImageFolder.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtImageFolder.Location = New System.Drawing.Point(422, 326)
        Me.TxtImageFolder.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtImageFolder.Name = "TxtImageFolder"
        Me.TxtImageFolder.ReadOnly = True
        Me.TxtImageFolder.Size = New System.Drawing.Size(390, 20)
        Me.TxtImageFolder.TabIndex = 22
        '
        'LblFocuser
        '
        Me.LblFocuser.AutoSize = True
        Me.LblFocuser.ForeColor = System.Drawing.Color.Red
        Me.LblFocuser.Location = New System.Drawing.Point(538, 361)
        Me.LblFocuser.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblFocuser.Name = "LblFocuser"
        Me.LblFocuser.Size = New System.Drawing.Size(45, 13)
        Me.LblFocuser.TabIndex = 23
        Me.LblFocuser.Text = "Focuser"
        '
        'LblFilterWheel
        '
        Me.LblFilterWheel.AutoSize = True
        Me.LblFilterWheel.ForeColor = System.Drawing.Color.Red
        Me.LblFilterWheel.Location = New System.Drawing.Point(446, 361)
        Me.LblFilterWheel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblFilterWheel.Name = "LblFilterWheel"
        Me.LblFilterWheel.Size = New System.Drawing.Size(63, 13)
        Me.LblFilterWheel.TabIndex = 24
        Me.LblFilterWheel.Text = "Filter Wheel"
        '
        'LblCameraStatus
        '
        Me.LblCameraStatus.AutoSize = True
        Me.LblCameraStatus.ForeColor = System.Drawing.Color.Red
        Me.LblCameraStatus.Location = New System.Drawing.Point(350, 361)
        Me.LblCameraStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblCameraStatus.Name = "LblCameraStatus"
        Me.LblCameraStatus.Size = New System.Drawing.Size(43, 13)
        Me.LblCameraStatus.TabIndex = 25
        Me.LblCameraStatus.Text = "Camera"
        '
        'LblTarget
        '
        Me.LblTarget.AutoSize = True
        Me.LblTarget.Location = New System.Drawing.Point(354, 411)
        Me.LblTarget.Name = "LblTarget"
        Me.LblTarget.Size = New System.Drawing.Size(38, 13)
        Me.LblTarget.TabIndex = 26
        Me.LblTarget.Text = "Target"
        '
        'TxtTarget
        '
        Me.TxtTarget.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtTarget.Location = New System.Drawing.Point(397, 408)
        Me.TxtTarget.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtTarget.Name = "TxtTarget"
        Me.TxtTarget.Size = New System.Drawing.Size(96, 20)
        Me.TxtTarget.TabIndex = 27
        '
        'LblMount
        '
        Me.LblMount.AutoSize = True
        Me.LblMount.ForeColor = System.Drawing.Color.Red
        Me.LblMount.Location = New System.Drawing.Point(599, 361)
        Me.LblMount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblMount.Name = "LblMount"
        Me.LblMount.Size = New System.Drawing.Size(37, 13)
        Me.LblMount.TabIndex = 30
        Me.LblMount.Text = "Mount"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(355, 443)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Get Ra and Dec from Image"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(777, 284)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(121, 20)
        Me.TextBox1.TabIndex = 33
        Me.TextBox1.Text = "Add a progress bar"
        '
        'PnlTxtTargetList
        '
        Me.PnlTxtTargetList.AutoScroll = True
        Me.PnlTxtTargetList.BackColor = System.Drawing.SystemColors.Window
        Me.PnlTxtTargetList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlTxtTargetList.Controls.Add(Me.LblTargetListItem6)
        Me.PnlTxtTargetList.Controls.Add(Me.LblTargetListItem5)
        Me.PnlTxtTargetList.Controls.Add(Me.LblTargetListItem4)
        Me.PnlTxtTargetList.Controls.Add(Me.LblTargetListItem3)
        Me.PnlTxtTargetList.Controls.Add(Me.LblTargetListItem2)
        Me.PnlTxtTargetList.Controls.Add(Me.LblTargetListItem1)
        Me.PnlTxtTargetList.Location = New System.Drawing.Point(589, 408)
        Me.PnlTxtTargetList.Name = "PnlTxtTargetList"
        Me.PnlTxtTargetList.Size = New System.Drawing.Size(463, 125)
        Me.PnlTxtTargetList.TabIndex = 13
        '
        'LblTargetListItem6
        '
        Me.LblTargetListItem6.AutoSize = True
        Me.LblTargetListItem6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem6.Location = New System.Drawing.Point(3, 105)
        Me.LblTargetListItem6.Name = "LblTargetListItem6"
        Me.LblTargetListItem6.Size = New System.Drawing.Size(36, 13)
        Me.LblTargetListItem6.TabIndex = 13
        Me.LblTargetListItem6.Text = "Empty"
        '
        'LblTargetListItem5
        '
        Me.LblTargetListItem5.AutoSize = True
        Me.LblTargetListItem5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem5.Location = New System.Drawing.Point(3, 85)
        Me.LblTargetListItem5.Name = "LblTargetListItem5"
        Me.LblTargetListItem5.Size = New System.Drawing.Size(36, 13)
        Me.LblTargetListItem5.TabIndex = 12
        Me.LblTargetListItem5.Text = "Empty"
        '
        'LblTargetListItem4
        '
        Me.LblTargetListItem4.AutoSize = True
        Me.LblTargetListItem4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem4.Location = New System.Drawing.Point(3, 65)
        Me.LblTargetListItem4.Name = "LblTargetListItem4"
        Me.LblTargetListItem4.Size = New System.Drawing.Size(36, 13)
        Me.LblTargetListItem4.TabIndex = 11
        Me.LblTargetListItem4.Text = "Empty"
        '
        'LblTargetListItem3
        '
        Me.LblTargetListItem3.AutoSize = True
        Me.LblTargetListItem3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem3.Location = New System.Drawing.Point(3, 45)
        Me.LblTargetListItem3.Name = "LblTargetListItem3"
        Me.LblTargetListItem3.Size = New System.Drawing.Size(36, 13)
        Me.LblTargetListItem3.TabIndex = 10
        Me.LblTargetListItem3.Text = "Empty"
        '
        'LblTargetListItem2
        '
        Me.LblTargetListItem2.AutoSize = True
        Me.LblTargetListItem2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem2.Location = New System.Drawing.Point(3, 25)
        Me.LblTargetListItem2.Name = "LblTargetListItem2"
        Me.LblTargetListItem2.Size = New System.Drawing.Size(36, 13)
        Me.LblTargetListItem2.TabIndex = 9
        Me.LblTargetListItem2.Text = "Empty"
        '
        'LblTargetListItem1
        '
        Me.LblTargetListItem1.AutoSize = True
        Me.LblTargetListItem1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem1.Location = New System.Drawing.Point(3, 5)
        Me.LblTargetListItem1.Name = "LblTargetListItem1"
        Me.LblTargetListItem1.Size = New System.Drawing.Size(36, 13)
        Me.LblTargetListItem1.TabIndex = 8
        Me.LblTargetListItem1.Text = "Empty"
        '
        'TheSkyXController
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 545)
        Me.Controls.Add(Me.PnlTxtTargetList)
        Me.Controls.Add(Me.BtnRemoveTarget)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnSelectImage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblMount)
        Me.Controls.Add(Me.BtnSlewLimits)
        Me.Controls.Add(Me.BtnTargetSearch)
        Me.Controls.Add(Me.TxtTarget)
        Me.Controls.Add(Me.LblTarget)
        Me.Controls.Add(Me.LblCameraStatus)
        Me.Controls.Add(Me.LblFilterWheel)
        Me.Controls.Add(Me.LblFocuser)
        Me.Controls.Add(Me.LblImageFolder)
        Me.Controls.Add(Me.TxtImageFolder)
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
        Me.PnlTxtTargetList.ResumeLayout(False)
        Me.PnlTxtTargetList.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents LblDelay As Label
    Friend WithEvents LblImageFolder As Label
    Friend WithEvents TxtImageFolder As TextBox
    Friend WithEvents LblFocuser As Label
    Friend WithEvents LblFilterWheel As Label
    Friend WithEvents LblCameraStatus As Label
    Friend WithEvents LblTarget As Label
    Friend WithEvents TxtTarget As TextBox
    Friend WithEvents BtnTargetSearch As Button
    Friend WithEvents BtnSlewLimits As Button
    Friend WithEvents LblMount As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnSelectImage As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BtnRemoveTarget As Button
    Friend WithEvents PnlTxtTargetList As Panel
    Friend WithEvents LblTargetListItem1 As Label
    Friend WithEvents LblTargetListItem6 As Label
    Friend WithEvents LblTargetListItem5 As Label
    Friend WithEvents LblTargetListItem4 As Label
    Friend WithEvents LblTargetListItem3 As Label
    Friend WithEvents LblTargetListItem2 As Label
End Class
