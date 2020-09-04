<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TheSkyXController
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.BtnClearTargets = New System.Windows.Forms.Button()
        Me.BtnSelectImage = New System.Windows.Forms.Button()
        Me.BtnRemoveTarget = New System.Windows.Forms.Button()
        Me.BtnEnterRAAndDec = New System.Windows.Forms.Button()
        Me.LblImageFolder = New System.Windows.Forms.Label()
        Me.TxtImageFolder = New System.Windows.Forms.TextBox()
        Me.LblFocuser = New System.Windows.Forms.Label()
        Me.LblFilterWheel = New System.Windows.Forms.Label()
        Me.LblCameraStatus = New System.Windows.Forms.Label()
        Me.LblTarget = New System.Windows.Forms.Label()
        Me.TxtTarget = New System.Windows.Forms.TextBox()
        Me.LblMount = New System.Windows.Forms.Label()
        Me.TextBoxStatus = New System.Windows.Forms.TextBox()
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
        Me.BtnSkyX.Location = New System.Drawing.Point(21, 23)
        Me.BtnSkyX.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSkyX.Name = "BtnSkyX"
        Me.BtnSkyX.Size = New System.Drawing.Size(100, 28)
        Me.BtnSkyX.TabIndex = 0
        Me.BtnSkyX.Text = "SkyX"
        Me.ToolTipStart.SetToolTip(Me.BtnSkyX, "Connect to TheSkyX")
        Me.BtnSkyX.UseVisualStyleBackColor = True
        '
        'BtnPHD2
        '
        Me.BtnPHD2.Location = New System.Drawing.Point(21, 68)
        Me.BtnPHD2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPHD2.Name = "BtnPHD2"
        Me.BtnPHD2.Size = New System.Drawing.Size(100, 28)
        Me.BtnPHD2.TabIndex = 1
        Me.BtnPHD2.Text = "PHD2"
        Me.ToolTipStart.SetToolTip(Me.BtnPHD2, "Connect to PHD2")
        Me.BtnPHD2.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(57, 545)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(100, 28)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Exit"
        Me.ToolTipStart.SetToolTip(Me.btnExit, "Exit the application")
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'PnlImageSequence
        '
        Me.PnlImageSequence.AutoScroll = True
        Me.PnlImageSequence.Location = New System.Drawing.Point(469, 15)
        Me.PnlImageSequence.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PnlImageSequence.Name = "PnlImageSequence"
        Me.PnlImageSequence.Size = New System.Drawing.Size(852, 308)
        Me.PnlImageSequence.TabIndex = 12
        '
        'BtnSequenceOpen
        '
        Me.BtnSequenceOpen.Location = New System.Drawing.Point(469, 347)
        Me.BtnSequenceOpen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSequenceOpen.Name = "BtnSequenceOpen"
        Me.BtnSequenceOpen.Size = New System.Drawing.Size(100, 28)
        Me.BtnSequenceOpen.TabIndex = 13
        Me.BtnSequenceOpen.Text = "Open"
        Me.ToolTipStart.SetToolTip(Me.BtnSequenceOpen, "Open a file containing an imaging sequence")
        Me.BtnSequenceOpen.UseVisualStyleBackColor = True
        '
        'BtnSeqenceAppend
        '
        Me.BtnSeqenceAppend.Location = New System.Drawing.Point(597, 347)
        Me.BtnSeqenceAppend.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSeqenceAppend.Name = "BtnSeqenceAppend"
        Me.BtnSeqenceAppend.Size = New System.Drawing.Size(100, 28)
        Me.BtnSeqenceAppend.TabIndex = 14
        Me.BtnSeqenceAppend.Text = "Append"
        Me.ToolTipStart.SetToolTip(Me.BtnSeqenceAppend, "Open a file containing an imaging sequence and append it to the current sequence")
        Me.BtnSeqenceAppend.UseVisualStyleBackColor = True
        '
        'BtnSequenceSave
        '
        Me.BtnSequenceSave.Location = New System.Drawing.Point(843, 347)
        Me.BtnSequenceSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSequenceSave.Name = "BtnSequenceSave"
        Me.BtnSequenceSave.Size = New System.Drawing.Size(100, 28)
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
        Me.PnlImageSeqTitles.Location = New System.Drawing.Point(247, 15)
        Me.PnlImageSeqTitles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PnlImageSeqTitles.Name = "PnlImageSeqTitles"
        Me.PnlImageSeqTitles.Size = New System.Drawing.Size(195, 308)
        Me.PnlImageSeqTitles.TabIndex = 16
        '
        'LblDelay
        '
        Me.LblDelay.AutoSize = True
        Me.LblDelay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDelay.Location = New System.Drawing.Point(0, 119)
        Me.LblDelay.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDelay.Name = "LblDelay"
        Me.LblDelay.Size = New System.Drawing.Size(44, 17)
        Me.LblDelay.TabIndex = 9
        Me.LblDelay.Text = "Delay"
        '
        'LblRunPrevSuccess
        '
        Me.LblRunPrevSuccess.AutoSize = True
        Me.LblRunPrevSuccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRunPrevSuccess.Location = New System.Drawing.Point(0, 135)
        Me.LblRunPrevSuccess.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRunPrevSuccess.Name = "LblRunPrevSuccess"
        Me.LblRunPrevSuccess.Size = New System.Drawing.Size(169, 17)
        Me.LblRunPrevSuccess.TabIndex = 8
        Me.LblRunPrevSuccess.Text = "Run on previous Success"
        '
        'LblRunPrevError
        '
        Me.LblRunPrevError.AutoSize = True
        Me.LblRunPrevError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRunPrevError.Location = New System.Drawing.Point(0, 151)
        Me.LblRunPrevError.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRunPrevError.Name = "LblRunPrevError"
        Me.LblRunPrevError.Size = New System.Drawing.Size(148, 17)
        Me.LblRunPrevError.TabIndex = 7
        Me.LblRunPrevError.Text = "Run on previous Error"
        '
        'LblDitherEveryNImages
        '
        Me.LblDitherEveryNImages.AutoSize = True
        Me.LblDitherEveryNImages.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDitherEveryNImages.Location = New System.Drawing.Point(0, 103)
        Me.LblDitherEveryNImages.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDitherEveryNImages.Name = "LblDitherEveryNImages"
        Me.LblDitherEveryNImages.Size = New System.Drawing.Size(149, 17)
        Me.LblDitherEveryNImages.TabIndex = 6
        Me.LblDitherEveryNImages.Text = "Dither Every N Images"
        '
        'LblRepeats
        '
        Me.LblRepeats.AutoSize = True
        Me.LblRepeats.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRepeats.Location = New System.Drawing.Point(0, 86)
        Me.LblRepeats.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRepeats.Name = "LblRepeats"
        Me.LblRepeats.Size = New System.Drawing.Size(61, 17)
        Me.LblRepeats.TabIndex = 5
        Me.LblRepeats.Text = "Repeats"
        '
        'LblBinY
        '
        Me.LblBinY.AutoSize = True
        Me.LblBinY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBinY.Location = New System.Drawing.Point(0, 69)
        Me.LblBinY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBinY.Name = "LblBinY"
        Me.LblBinY.Size = New System.Drawing.Size(41, 17)
        Me.LblBinY.TabIndex = 4
        Me.LblBinY.Text = "Bin Y"
        '
        'LblBinX
        '
        Me.LblBinX.AutoSize = True
        Me.LblBinX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBinX.Location = New System.Drawing.Point(0, 52)
        Me.LblBinX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBinX.Name = "LblBinX"
        Me.LblBinX.Size = New System.Drawing.Size(41, 17)
        Me.LblBinX.TabIndex = 3
        Me.LblBinX.Text = "Bin X"
        '
        'LblExposureLength
        '
        Me.LblExposureLength.AutoSize = True
        Me.LblExposureLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblExposureLength.Location = New System.Drawing.Point(0, 34)
        Me.LblExposureLength.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblExposureLength.Name = "LblExposureLength"
        Me.LblExposureLength.Size = New System.Drawing.Size(115, 17)
        Me.LblExposureLength.TabIndex = 2
        Me.LblExposureLength.Text = "Exposure Length"
        '
        'LblFilter
        '
        Me.LblFilter.AutoSize = True
        Me.LblFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilter.Location = New System.Drawing.Point(0, 17)
        Me.LblFilter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFilter.Name = "LblFilter"
        Me.LblFilter.Size = New System.Drawing.Size(39, 17)
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
        Me.LblExposureType.Size = New System.Drawing.Size(103, 17)
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
        Me.GroupBox2.Location = New System.Drawing.Point(16, 193)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(192, 249)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Imaging"
        '
        'BtnStopImaging
        '
        Me.BtnStopImaging.Location = New System.Drawing.Point(41, 130)
        Me.BtnStopImaging.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnStopImaging.Name = "BtnStopImaging"
        Me.BtnStopImaging.Size = New System.Drawing.Size(100, 28)
        Me.BtnStopImaging.TabIndex = 20
        Me.BtnStopImaging.Text = "Stop"
        Me.ToolTipStart.SetToolTip(Me.BtnStopImaging, "Stop the imaging process, the current image will be completed")
        Me.BtnStopImaging.UseVisualStyleBackColor = True
        '
        'BtnCalibrationFrames
        '
        Me.BtnCalibrationFrames.Location = New System.Drawing.Point(21, 202)
        Me.BtnCalibrationFrames.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnCalibrationFrames.Name = "BtnCalibrationFrames"
        Me.BtnCalibrationFrames.Size = New System.Drawing.Size(156, 28)
        Me.BtnCalibrationFrames.TabIndex = 9
        Me.BtnCalibrationFrames.Text = "Calibration Frames"
        Me.BtnCalibrationFrames.UseVisualStyleBackColor = True
        '
        'BtnStartImaging
        '
        Me.BtnStartImaging.Location = New System.Drawing.Point(41, 23)
        Me.BtnStartImaging.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnStartImaging.Name = "BtnStartImaging"
        Me.BtnStartImaging.Size = New System.Drawing.Size(100, 28)
        Me.BtnStartImaging.TabIndex = 2
        Me.BtnStartImaging.Text = "Start"
        Me.ToolTipStart.SetToolTip(Me.BtnStartImaging, "Start the Imaging Process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.BtnStartImaging.UseVisualStyleBackColor = True
        '
        'BtnPauseImaging
        '
        Me.BtnPauseImaging.Location = New System.Drawing.Point(41, 59)
        Me.BtnPauseImaging.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnPauseImaging.Name = "BtnPauseImaging"
        Me.BtnPauseImaging.Size = New System.Drawing.Size(100, 28)
        Me.BtnPauseImaging.TabIndex = 3
        Me.BtnPauseImaging.Text = "Pause"
        Me.ToolTipStart.SetToolTip(Me.BtnPauseImaging, "Pause the imaging process, The curent image will complete")
        Me.BtnPauseImaging.UseVisualStyleBackColor = True
        '
        'BtnAbortImaging
        '
        Me.BtnAbortImaging.Location = New System.Drawing.Point(41, 95)
        Me.BtnAbortImaging.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAbortImaging.Name = "BtnAbortImaging"
        Me.BtnAbortImaging.Size = New System.Drawing.Size(100, 28)
        Me.BtnAbortImaging.TabIndex = 4
        Me.BtnAbortImaging.Text = "Abort"
        Me.ToolTipStart.SetToolTip(Me.BtnAbortImaging, "Abort the imaging process, the current image will be abandoned")
        Me.BtnAbortImaging.UseVisualStyleBackColor = True
        '
        'BtnSettingsImaging
        '
        Me.BtnSettingsImaging.Location = New System.Drawing.Point(41, 166)
        Me.BtnSettingsImaging.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSettingsImaging.Name = "BtnSettingsImaging"
        Me.BtnSettingsImaging.Size = New System.Drawing.Size(100, 28)
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
        Me.GroupBox1.Location = New System.Drawing.Point(16, 9)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(192, 123)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connect"
        '
        'PnlPhd2Status
        '
        Me.PnlPhd2Status.BackColor = System.Drawing.Color.Red
        Me.PnlPhd2Status.Location = New System.Drawing.Point(137, 68)
        Me.PnlPhd2Status.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PnlPhd2Status.Name = "PnlPhd2Status"
        Me.PnlPhd2Status.Size = New System.Drawing.Size(33, 28)
        Me.PnlPhd2Status.TabIndex = 10
        '
        'PnlSkyXStatus
        '
        Me.PnlSkyXStatus.BackColor = System.Drawing.Color.Red
        Me.PnlSkyXStatus.Location = New System.Drawing.Point(137, 23)
        Me.PnlSkyXStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PnlSkyXStatus.Name = "PnlSkyXStatus"
        Me.PnlSkyXStatus.Size = New System.Drawing.Size(33, 28)
        Me.PnlSkyXStatus.TabIndex = 9
        '
        'BtnTest
        '
        Me.BtnTest.Location = New System.Drawing.Point(57, 610)
        Me.BtnTest.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.Size = New System.Drawing.Size(100, 28)
        Me.BtnTest.TabIndex = 11
        Me.BtnTest.Text = "Test"
        Me.BtnTest.UseVisualStyleBackColor = True
        '
        'BtnLoadGroup
        '
        Me.BtnLoadGroup.Location = New System.Drawing.Point(721, 347)
        Me.BtnLoadGroup.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnLoadGroup.Name = "BtnLoadGroup"
        Me.BtnLoadGroup.Size = New System.Drawing.Size(100, 28)
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
        Me.BtnTargetSearch.Location = New System.Drawing.Point(677, 502)
        Me.BtnTargetSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnTargetSearch.Name = "BtnTargetSearch"
        Me.BtnTargetSearch.Size = New System.Drawing.Size(100, 28)
        Me.BtnTargetSearch.TabIndex = 28
        Me.BtnTargetSearch.Text = "Search"
        Me.ToolTipStart.SetToolTip(Me.BtnTargetSearch, "Search the SkyX database for the target")
        Me.BtnTargetSearch.UseVisualStyleBackColor = True
        '
        'BtnClearTargets
        '
        Me.BtnClearTargets.Location = New System.Drawing.Point(677, 640)
        Me.BtnClearTargets.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnClearTargets.Name = "BtnClearTargets"
        Me.BtnClearTargets.Size = New System.Drawing.Size(100, 28)
        Me.BtnClearTargets.TabIndex = 21
        Me.BtnClearTargets.Text = "Clear"
        Me.ToolTipStart.SetToolTip(Me.BtnClearTargets, "Start the Imaging Process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.BtnClearTargets.UseVisualStyleBackColor = True
        '
        'BtnSelectImage
        '
        Me.BtnSelectImage.Enabled = False
        Me.BtnSelectImage.Location = New System.Drawing.Point(677, 534)
        Me.BtnSelectImage.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSelectImage.Name = "BtnSelectImage"
        Me.BtnSelectImage.Size = New System.Drawing.Size(100, 28)
        Me.BtnSelectImage.TabIndex = 32
        Me.BtnSelectImage.Text = "Image"
        Me.ToolTipStart.SetToolTip(Me.BtnSelectImage, "Search the SkyX database for the target")
        Me.BtnSelectImage.UseVisualStyleBackColor = True
        '
        'BtnRemoveTarget
        '
        Me.BtnRemoveTarget.Location = New System.Drawing.Point(677, 608)
        Me.BtnRemoveTarget.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnRemoveTarget.Name = "BtnRemoveTarget"
        Me.BtnRemoveTarget.Size = New System.Drawing.Size(100, 28)
        Me.BtnRemoveTarget.TabIndex = 34
        Me.BtnRemoveTarget.Text = "Remove"
        Me.ToolTipStart.SetToolTip(Me.BtnRemoveTarget, "Start the Imaging Process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.BtnRemoveTarget.UseVisualStyleBackColor = True
        '
        'BtnEnterRAAndDec
        '
        Me.BtnEnterRAAndDec.Location = New System.Drawing.Point(677, 570)
        Me.BtnEnterRAAndDec.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnEnterRAAndDec.Name = "BtnEnterRAAndDec"
        Me.BtnEnterRAAndDec.Size = New System.Drawing.Size(100, 28)
        Me.BtnEnterRAAndDec.TabIndex = 35
        Me.BtnEnterRAAndDec.Text = "Ra Dec"
        Me.ToolTipStart.SetToolTip(Me.BtnEnterRAAndDec, "Search the SkyX database for the target")
        Me.BtnEnterRAAndDec.UseVisualStyleBackColor = True
        '
        'LblImageFolder
        '
        Me.LblImageFolder.AutoSize = True
        Me.LblImageFolder.Location = New System.Drawing.Point(467, 401)
        Me.LblImageFolder.Name = "LblImageFolder"
        Me.LblImageFolder.Size = New System.Drawing.Size(90, 17)
        Me.LblImageFolder.TabIndex = 21
        Me.LblImageFolder.Text = "Image Folder"
        '
        'TxtImageFolder
        '
        Me.TxtImageFolder.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtImageFolder.Location = New System.Drawing.Point(563, 401)
        Me.TxtImageFolder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtImageFolder.Name = "TxtImageFolder"
        Me.TxtImageFolder.ReadOnly = True
        Me.TxtImageFolder.Size = New System.Drawing.Size(519, 22)
        Me.TxtImageFolder.TabIndex = 22
        '
        'LblFocuser
        '
        Me.LblFocuser.AutoSize = True
        Me.LblFocuser.ForeColor = System.Drawing.Color.Red
        Me.LblFocuser.Location = New System.Drawing.Point(717, 444)
        Me.LblFocuser.Name = "LblFocuser"
        Me.LblFocuser.Size = New System.Drawing.Size(59, 17)
        Me.LblFocuser.TabIndex = 23
        Me.LblFocuser.Text = "Focuser"
        '
        'LblFilterWheel
        '
        Me.LblFilterWheel.AutoSize = True
        Me.LblFilterWheel.ForeColor = System.Drawing.Color.Red
        Me.LblFilterWheel.Location = New System.Drawing.Point(595, 444)
        Me.LblFilterWheel.Name = "LblFilterWheel"
        Me.LblFilterWheel.Size = New System.Drawing.Size(83, 17)
        Me.LblFilterWheel.TabIndex = 24
        Me.LblFilterWheel.Text = "Filter Wheel"
        '
        'LblCameraStatus
        '
        Me.LblCameraStatus.AutoSize = True
        Me.LblCameraStatus.ForeColor = System.Drawing.Color.Red
        Me.LblCameraStatus.Location = New System.Drawing.Point(467, 444)
        Me.LblCameraStatus.Name = "LblCameraStatus"
        Me.LblCameraStatus.Size = New System.Drawing.Size(57, 17)
        Me.LblCameraStatus.TabIndex = 25
        Me.LblCameraStatus.Text = "Camera"
        '
        'LblTarget
        '
        Me.LblTarget.AutoSize = True
        Me.LblTarget.Location = New System.Drawing.Point(472, 506)
        Me.LblTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTarget.Name = "LblTarget"
        Me.LblTarget.Size = New System.Drawing.Size(50, 17)
        Me.LblTarget.TabIndex = 26
        Me.LblTarget.Text = "Target"
        '
        'TxtTarget
        '
        Me.TxtTarget.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtTarget.Location = New System.Drawing.Point(529, 502)
        Me.TxtTarget.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtTarget.Name = "TxtTarget"
        Me.TxtTarget.Size = New System.Drawing.Size(127, 22)
        Me.TxtTarget.TabIndex = 27
        '
        'LblMount
        '
        Me.LblMount.AutoSize = True
        Me.LblMount.ForeColor = System.Drawing.Color.Red
        Me.LblMount.Location = New System.Drawing.Point(799, 444)
        Me.LblMount.Name = "LblMount"
        Me.LblMount.Size = New System.Drawing.Size(47, 17)
        Me.LblMount.TabIndex = 30
        Me.LblMount.Text = "Mount"
        '
        'TextBoxStatus
        '
        Me.TextBoxStatus.Location = New System.Drawing.Point(1036, 350)
        Me.TextBoxStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBoxStatus.Name = "TextBoxStatus"
        Me.TextBoxStatus.Size = New System.Drawing.Size(160, 22)
        Me.TextBoxStatus.TabIndex = 33
        Me.TextBoxStatus.Text = "Add a progress bar"
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
        Me.PnlTxtTargetList.Location = New System.Drawing.Point(785, 502)
        Me.PnlTxtTargetList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PnlTxtTargetList.Name = "PnlTxtTargetList"
        Me.PnlTxtTargetList.Size = New System.Drawing.Size(617, 166)
        Me.PnlTxtTargetList.TabIndex = 13
        '
        'LblTargetListItem6
        '
        Me.LblTargetListItem6.AutoSize = True
        Me.LblTargetListItem6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem6.Location = New System.Drawing.Point(4, 129)
        Me.LblTargetListItem6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTargetListItem6.Name = "LblTargetListItem6"
        Me.LblTargetListItem6.Size = New System.Drawing.Size(47, 17)
        Me.LblTargetListItem6.TabIndex = 13
        Me.LblTargetListItem6.Text = "Empty"
        '
        'LblTargetListItem5
        '
        Me.LblTargetListItem5.AutoSize = True
        Me.LblTargetListItem5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem5.Location = New System.Drawing.Point(4, 105)
        Me.LblTargetListItem5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTargetListItem5.Name = "LblTargetListItem5"
        Me.LblTargetListItem5.Size = New System.Drawing.Size(47, 17)
        Me.LblTargetListItem5.TabIndex = 12
        Me.LblTargetListItem5.Text = "Empty"
        '
        'LblTargetListItem4
        '
        Me.LblTargetListItem4.AutoSize = True
        Me.LblTargetListItem4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem4.Location = New System.Drawing.Point(4, 80)
        Me.LblTargetListItem4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTargetListItem4.Name = "LblTargetListItem4"
        Me.LblTargetListItem4.Size = New System.Drawing.Size(47, 17)
        Me.LblTargetListItem4.TabIndex = 11
        Me.LblTargetListItem4.Text = "Empty"
        '
        'LblTargetListItem3
        '
        Me.LblTargetListItem3.AutoSize = True
        Me.LblTargetListItem3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem3.Location = New System.Drawing.Point(4, 55)
        Me.LblTargetListItem3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTargetListItem3.Name = "LblTargetListItem3"
        Me.LblTargetListItem3.Size = New System.Drawing.Size(47, 17)
        Me.LblTargetListItem3.TabIndex = 10
        Me.LblTargetListItem3.Text = "Empty"
        '
        'LblTargetListItem2
        '
        Me.LblTargetListItem2.AutoSize = True
        Me.LblTargetListItem2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem2.Location = New System.Drawing.Point(4, 31)
        Me.LblTargetListItem2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTargetListItem2.Name = "LblTargetListItem2"
        Me.LblTargetListItem2.Size = New System.Drawing.Size(47, 17)
        Me.LblTargetListItem2.TabIndex = 9
        Me.LblTargetListItem2.Text = "Empty"
        '
        'LblTargetListItem1
        '
        Me.LblTargetListItem1.AutoSize = True
        Me.LblTargetListItem1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetListItem1.Location = New System.Drawing.Point(4, 6)
        Me.LblTargetListItem1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTargetListItem1.Name = "LblTargetListItem1"
        Me.LblTargetListItem1.Size = New System.Drawing.Size(47, 17)
        Me.LblTargetListItem1.TabIndex = 8
        Me.LblTargetListItem1.Text = "Empty"
        '
        'TheSkyXController
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1419, 683)
        Me.Controls.Add(Me.BtnEnterRAAndDec)
        Me.Controls.Add(Me.PnlTxtTargetList)
        Me.Controls.Add(Me.BtnRemoveTarget)
        Me.Controls.Add(Me.TextBoxStatus)
        Me.Controls.Add(Me.BtnSelectImage)
        Me.Controls.Add(Me.LblMount)
        Me.Controls.Add(Me.BtnClearTargets)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
    Friend WithEvents BtnClearTargets As Button
    Friend WithEvents LblMount As Label
    Friend WithEvents BtnSelectImage As Button
    Friend WithEvents TextBoxStatus As TextBox
    Friend WithEvents BtnRemoveTarget As Button
    Friend WithEvents PnlTxtTargetList As Panel
    Friend WithEvents LblTargetListItem1 As Label
    Friend WithEvents LblTargetListItem6 As Label
    Friend WithEvents LblTargetListItem5 As Label
    Friend WithEvents LblTargetListItem4 As Label
    Friend WithEvents LblTargetListItem3 As Label
    Friend WithEvents LblTargetListItem2 As Label
    Friend WithEvents BtnEnterRAAndDec As Button
End Class
