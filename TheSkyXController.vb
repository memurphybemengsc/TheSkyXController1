Imports System.IO
Imports TheSkyXLib

Public Class TheSkyXController
    Public imageFileSequence As New ImageSequence()
    Private defaultFilterWheelNames As List(Of String)
    Dim imagingSequenceInProgress As Boolean
    Dim isPhd2Connected As Boolean = False
    Public fitsKeyCollection As FitsKeyCollection
    Public phd2guiding As PHD2Guiding = Nothing
    Public skyXFunctions As SkyXFunctions = Nothing
    Public myAscomUtilities As AscomUtilities = Nothing
    Dim isSkyXConnected As Boolean = False
    Private imagingRunPaused As Boolean
    Private imagingRunAborted As Boolean
    Private currentImagingStatus As Integer = ImagingStatus.notImaging
    Private overrideImagingStatus As Integer = ImagingStatus.empty
    Private isTmrImagingLoopTicking As Boolean = False
    Private guidingStoppedStopwatch As Stopwatch = New Stopwatch()
    Private imageSelectionForTargets As OpenFileDialog = Nothing
    Private imageSelectionForTargets_init_folder As String = ""
    Private targetLabels As List(Of Label) = Nothing
    Private currentTargetFromList As Integer = 0

    Private Enum ImagingStatus
        empty
        start
        notImaging
        acqireTarget
        gotoTarget
        startGuiding
        guidingHasStopped
        preTakeImage
        takeImage
        imageInProgress
        imageComplete
        postImageComplete
        setupNextImage
        dither
        ditheringInProgress
        ditherComplete
        changeFilter
        filterChangeInProgress
        preClosedLoopSlew
        runClosedLoopSlew
        postClosedLoopSlew
        runAtFocus3
        postRunAtFocus3
        meridianFlip
        abort
        halt
    End Enum


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        populateDefaultFilterWheelNames(Nothing)
        imagingSequenceInProgress = False

        fitsKeyCollection = New FitsKeyCollection

        BtnStartImaging.Enabled = False
        BtnAbortImaging.Enabled = False
        BtnPauseImaging.Enabled = False
        BtnStopImaging.Enabled = False
        BtnSettingsImaging.Enabled = False
        BtnSelectImage.Enabled = True
        BtnTargetSearch.Enabled = False
        BtnSelectImage.Enabled = False

        myAscomUtilities = New AscomUtilities

        clearTargetListText()

        My.Settings.Reload()

        TxtImageFolder.Text = My.Settings.ImageFolder

    End Sub

    Public Sub populateDefaultFilterWheelNames(fwNames As List(Of String))
        defaultFilterWheelNames = New List(Of String)
        If fwNames Is Nothing Then
            defaultFilterWheelNames.Add("Lum")
            defaultFilterWheelNames.Add("Red")
            defaultFilterWheelNames.Add("Green")
            defaultFilterWheelNames.Add("Blue")
            defaultFilterWheelNames.Add("Ha")
            defaultFilterWheelNames.Add("O3")
            defaultFilterWheelNames.Add("S2")
            defaultFilterWheelNames.Add("Dark")
        Else
            For Each name As String In fwNames
                defaultFilterWheelNames.Add(name)
            Next
        End If
    End Sub

    Public Function getFilterWheelNames() As List(Of String)
        Return defaultFilterWheelNames
    End Function

    Private Sub BtnSkyX_Click(sender As Object, e As EventArgs) Handles BtnSkyX.Click
        If skyXFunctions Is Nothing Then
            ' We have not connected to SkyX
            Try
                skyXFunctions = New SkyXFunctions()
                Me.PnlSkyXStatus.BackColor = Color.Green
                isSkyXConnected = True
                BtnStartImaging.Enabled = True
                BtnSettingsImaging.Enabled = True
                BtnTargetSearch.Enabled = True
                BtnSelectImage.Enabled = True
                LblCameraStatus.ForeColor = Color.Green

                If skyXFunctions.isFilterWheelConnected Then
                    LblFilterWheel.ForeColor = Color.Green
                    populateDefaultFilterWheelNames(skyXFunctions.getFilterNames)
                    imageFileSequence.buildPanel()
                End If

                If skyXFunctions.isFocuserConnected Then
                    LblFocuser.ForeColor = Color.Green
                End If

                If skyXFunctions.isMountpresentAndConnected Then
                    LblMount.ForeColor = Color.Green
                End If
            Catch ex As Exception
                If ex.Source = "TheSkyX.ccdsoftCamera" Then
                    MsgBox("There was an error connecting to the camera")
                Else
                    MsgBox("SkyX is not present")
                End If
            End Try

        Else
            ' We are disconnecting from SkyX, check are we guiding or imaging
            Dim res = MsgBox("Imaging is in progress, do you wish to disconnect?", MsgBoxStyle.YesNo)
            If (res = MsgBoxResult.Yes) Then
                Me.PnlSkyXStatus.BackColor = Color.Red
                skyXFunctions.disconnect()
                skyXFunctions = Nothing
                isSkyXConnected = False
                BtnStartImaging.Enabled = False
                BtnSettingsImaging.Enabled = False
                BtnTargetSearch.Enabled = False
                BtnSelectImage.Enabled = False
                LblCameraStatus.ForeColor = Color.Red
                LblFilterWheel.ForeColor = Color.Red
                LblFocuser.ForeColor = Color.Red
                LblMount.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub BtnPHD2_Click(sender As Object, e As EventArgs) Handles BtnPHD2.Click
        If Not isPhd2Connected Then
            Try
                phd2guiding = New PHD2Guiding()
                phd2guiding.connectToPHD()
                isPhd2Connected = True
                Me.PnlPhd2Status.BackColor = Color.Green
            Catch ex As Exception
                MsgBox("PHD2 is not running")
            End Try
        Else
            ' We are disconnecting, check are we guiding or imaging
            Dim res = MsgBox("PHD2 is running, do you wish to disconnect?", MsgBoxStyle.YesNo)
            If (res = MsgBoxResult.Yes) Then
                'dispose of phd object
                Me.PnlPhd2Status.BackColor = Color.Red
                phd2guiding.Dispose()
                phd2guiding = New PHD2Guiding() ' Create a fresh object
                isPhd2Connected = False
            End If
        End If
    End Sub

    Private Sub BtnCalibrationFrames_Click(sender As Object, e As EventArgs) Handles BtnCalibrationFrames.Click
        ' Add code to generate a sequence to generate calibration frames
        ' 1) Specify folder
        ' 2) List Files
        ' 3) Generate sequence
        ' 4) Remove existing sequence and replace with new - Add message box to warn user
        GenerateCalibrationSequence.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim exitApplication As Boolean = True

        If imagingSequenceInProgress Then
            Dim result = MessageBox.Show("Image run is in progress, Are you sure you want to quit", "Exit Application", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                exitApplication = False
            End If
        End If

        If exitApplication Then
            Me.Close()
        End If

    End Sub

    Private Sub PnlImageSequence_Paint(sender As Object, e As PaintEventArgs) Handles PnlImageSequence.Paint
        If imageFileSequence.componentPanel Is Nothing Then
            Me.PnlImageSequence.AutoScroll = False
            Me.PnlImageSequence.VerticalScroll.Enabled = False
            Me.PnlImageSequence.AutoScroll = True
            imageFileSequence.componentPanel = Me.PnlImageSequence
            imageFileSequence.createInitialPanel()
        End If
    End Sub

    Private Sub BtnSequenceOpen_Click(sender As Object, e As EventArgs) Handles BtnSequenceOpen.Click
        imageFileSequence.openFileAndBuildComponents()
    End Sub
    Private Sub BtnSequenceSave_Click(sender As Object, e As EventArgs) Handles BtnSequenceSave.Click
        imageFileSequence.refreshComponentsAndSaveFile()
    End Sub

    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click

        TxtImageFolder.Text = "the image folder"

        'myAscomUtilities.chooseAndConnectToMount()
        'If myAscomUtilities.shouldWeFlipMount() Then
        '    MsgBox("Flip Mount")
        'Else
        '    MsgBox("Don't Flip Mount")
        'End If

        'skyXFunctions.testFunction()

        'If phd2guiding IsNot Nothing Then
        '    phd2guiding.startGuiding()
        '    MsgBox("phd status is " + Me.phd2guiding.checkStatus.ToString)
        'Else
        '    MsgBox("phd is not connected")
        'End If

        'MsgBox("Cick to stop guiding")

        'phd2guiding.stopGuiding()

    End Sub

    Private Sub BtnSeqenceAppend_Click(sender As Object, e As EventArgs) Handles BtnSeqenceAppend.Click
        MsgBox("Feature to be added")
    End Sub

    Private Sub BtnLoadGroup_Click(sender As Object, e As EventArgs) Handles BtnLoadGroup.Click
        MsgBox("Feature to be added")
    End Sub

    Private Sub BtnStartImaging_Click(sender As Object, e As EventArgs) Handles BtnStartImaging.Click
        ' Are we connected to SkyX?
        ' we need to validate the image sequence against the camera filters/binning etc.
        If isSkyXConnected AndAlso skyXFunctions IsNot Nothing AndAlso skyXFunctions.isCameraConnected Then
            If skyXFunctions.getImageFolder = "" Then
                MsgBox("Please set the imaging folder")
                Return
            End If
            BtnAbortImaging.Enabled = True
            BtnPauseImaging.Enabled = True
            BtnStopImaging.Enabled = True
            BtnStartImaging.Enabled = False
            BtnSettingsImaging.Enabled = False
            currentImagingStatus = ImagingStatus.start

            ' Make sure any changes to the controls are reflected in the sequence elements
            imageFileSequence.refreshElementsfromControls()

            clearCurrentTargetFromList()

            ' Start the imaging timer
            TmrImagingLoop.Start()
        Else
            MsgBox("SkyX is not connected")
        End If
    End Sub

    Private Sub BtnPauseImaging_Click(sender As Object, e As EventArgs) Handles BtnPauseImaging.Click
        ' Set the pause flag, the imaging loop still runs
        MsgBox("Pausing the imaging, the current image will complete")
        TmrImagingLoop.Stop()
    End Sub

    Private Sub BtnAbortImaging_Click(sender As Object, e As EventArgs) Handles BtnAbortImaging.Click
        ' Abort the imaging run
        Dim result = MessageBox.Show("Image run is in progress, Are you sure you want to abort", "Abort Imaging Run", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            ' abort current image and then stop timer.
            ' The timer function will need to abort and then stop itself
            currentImagingStatus = ImagingStatus.abort
        End If
    End Sub

    Private Sub TmrImagingLoop_Tick(sender As Object, e As EventArgs) Handles TmrImagingLoop.Tick
        If imageFileSequence Is Nothing Or phd2guiding Is Nothing Or skyXFunctions Is Nothing Then
            'We have an error state
            currentImagingStatus = ImagingStatus.abort
        ElseIf Not isTmrImagingLoopTicking Then
            ' We have this boolean as the tick will be called even if the previous tick has not finished
            isTmrImagingLoopTicking = True
            If currentImagingStatus = ImagingStatus.start Then
                TextBoxStatus.Text = "Start"

                imageFileSequence.initialiseImageRun()

                If isTargetListPopulated() Then
                    clearCurrentTargetFromList()
                    currentImagingStatus = ImagingStatus.acqireTarget
                Else
                    currentImagingStatus = ImagingStatus.notImaging
                End If
            ElseIf currentImagingStatus = ImagingStatus.acqireTarget Then
                TextBoxStatus.Text = "Acquire Image"
                Dim tgt As String = getNextTargetFromList()
                Dim tgt_type = ""
                Dim tgt_name = ""

                phd2guiding.stopGuiding()

                If tgt = "" Then
                    ' We have reached the end of the loop (Possibly replace with an exception)
                    tgt_type = "HALT"
                Else
                    tgt_type = tgt.Substring(0, 1)
                    tgt_name = tgt.Substring(2)
                End If

                ' Remember to add the Ra/Dec element
                If tgt_type = "N" Then
                    If skyXFunctions.findObject(tgt_name) = False Then
                        ' Target object is not valid so abort
                        currentImagingStatus = ImagingStatus.abort
                    Else
                        If skyXFunctions.isCurrentdObjectVisible = True Then
                            skyXFunctions.setRaAndDecFromObject()
                            skyXFunctions.setImagePrefix(tgt_name)
                            currentImagingStatus = ImagingStatus.gotoTarget
                        Else
                            ' Object is not visible so go to the next one
                            currentImagingStatus = ImagingStatus.acqireTarget
                        End If
                    End If
                ElseIf tgt_type = "I" Then
                    ' Get the RA & Dec from the fits data
                    Dim fkv As New FitsKeyValues()
                    fkv.populateKeyDataFromFile(tgt_name)
                    If Not fkv.isRAandDECPresent Then
                        ' no coordinates present so abort
                        currentImagingStatus = ImagingStatus.abort
                    Else
                        If skyXFunctions.isRaAndDecVisible(fkv.imageRA, fkv.imageDEC) Then
                            skyXFunctions.setRaAndDec(fkv.imageRA, fkv.imageDEC)
                            skyXFunctions.setImagePrefix(Path.GetFileNameWithoutExtension(tgt_name))
                            currentImagingStatus = ImagingStatus.gotoTarget
                        Else
                            ' Object is not visible so go to the next one
                            currentImagingStatus = ImagingStatus.acqireTarget
                        End If
                    End If
                ElseIf tgt_type = "HALT" Then
                    currentImagingStatus = ImagingStatus.halt
                Else
                    ' Something odd happened, abort
                    currentImagingStatus = ImagingStatus.abort
                End If
            ElseIf currentImagingStatus = ImagingStatus.gotoTarget Then
                TextBoxStatus.Text = "Goto Target"
                Dim image_prefix As String = skyXFunctions.getImagePrefix
                skyXFunctions.setImagePrefix("CLS_" + image_prefix)
                ' For future, set the CLS to be asynch
                If skyXFunctions.closedLoopSlewToTarget() = False Then
                    ' Something odd happened, abort
                    currentImagingStatus = ImagingStatus.abort
                Else
                    currentImagingStatus = ImagingStatus.notImaging
                End If
                skyXFunctions.setImagePrefix(image_prefix)
                skyXFunctions.setMountPointingPosition()
            ElseIf currentImagingStatus = ImagingStatus.notImaging Then
                TextBoxStatus.Text = "Not Imaging"
                ' initialise the various counters
                imageFileSequence.initialiseImageRun()
                If isPhd2Connected AndAlso Not phd2guiding.isPHDGuidingAndLockedOnStar Then
                    ' PHD is not guiding so start guiding
                    phd2guiding.startGuiding()
                    currentImagingStatus = ImagingStatus.startGuiding
                Else
                    ' No PHD connection so start imaging
                    currentImagingStatus = ImagingStatus.preTakeImage
                End If
            ElseIf currentImagingStatus = ImagingStatus.startGuiding Then
                TextBoxStatus.Text = "Start Guiding"
                If phd2guiding.isPHDGuidingAndLockedOnStar Then
                    ' PHD is now guiding so take an image
                    currentImagingStatus = ImagingStatus.preTakeImage
                Else
                    ' We should add a timeout, possibly reuse the stop watch
                End If
            ElseIf currentImagingStatus = ImagingStatus.meridianFlip Then
                TextBoxStatus.Text = "Meridian Flip"
                ' We assume that the mount has gone past the meredian and a simple goto will make the mount goto the same Ra & Dec
                ' but with the correct mount orientation
                If Not skyXFunctions.closedLoopSlewToMountPosition() Then
                    ' Slew failed.  What now???
                End If
                ' As the mount has slewed re-focus in case the camera has shifted
                currentImagingStatus = ImagingStatus.runAtFocus3
                overrideImagingStatus = ImagingStatus.setupNextImage
            ElseIf currentImagingStatus = ImagingStatus.dither Then
                TextBoxStatus.Text = "Dither"
                If phd2guiding.isPHDGuidingAndLockedOnStar Then
                    ' PHD is now guiding so take an image
                    phd2guiding.ditherMount()
                    currentImagingStatus = ImagingStatus.ditheringInProgress
                End If
            ElseIf currentImagingStatus = ImagingStatus.ditheringInProgress Then
                TextBoxStatus.Text = "Dither in progress"
                If phd2guiding.isDitherComplete Then
                    currentImagingStatus = ImagingStatus.ditherComplete
                End If
            ElseIf currentImagingStatus = ImagingStatus.ditherComplete Then
                TextBoxStatus.Text = "Dither Complete"
                currentImagingStatus = ImagingStatus.preTakeImage
            ElseIf currentImagingStatus = ImagingStatus.preTakeImage Then
                TextBoxStatus.Text = "Pre Take Image"
                ' Still have to figure out how to determine if mount needs to be flipped.
                ' Do we keep the last few positions just in case we have an odd situation where the mount flips in the middle of doing stuff?
                ' Get the next image sequence
                If Not skyXFunctions.refreshCameraImageSettingsFromCurrentImageSequence() Then
                    'we have an error, now what?  @Focus3???
                End If
                currentImagingStatus = ImagingStatus.takeImage
            ElseIf currentImagingStatus = ImagingStatus.takeImage Then
                TextBoxStatus.Text = "Take Image"
                If Not skyXFunctions.takeAnImageAsynchronously() Then
                    'we have an error, now what?
                End If

                currentImagingStatus = ImagingStatus.imageInProgress
            ElseIf currentImagingStatus = ImagingStatus.imageInProgress Then
                TextBoxStatus.Text = "Image in progress"
                If Not phd2guiding.isPHDGuidingAndLockedOnStar Then
                    If guidingStoppedStopwatch.IsRunning Then
                        If phd2guiding.hasTimeoutBeenExceeded(guidingStoppedStopwatch.ElapsedMilliseconds) Then
                            ' Guiding has stopped for longer then we would like so abort image
                            currentImagingStatus = ImagingStatus.guidingHasStopped
                            guidingStoppedStopwatch.Stop()
                        End If
                    Else
                        'We have stopped guiding, start stopwatch
                        guidingStoppedStopwatch.Reset()
                        guidingStoppedStopwatch.Start()
                    End If
                End If
                If Not skyXFunctions.isImagingInProgress Then
                    currentImagingStatus = ImagingStatus.imageComplete
                End If
            ElseIf currentImagingStatus = ImagingStatus.guidingHasStopped Then
                TextBoxStatus.Text = "Guiding has stopped"
                If skyXFunctions.abortImage Then
                    ' Imaging has aborted.  What to do now? Wait for a bit and re-try???
                    ' We might need to CLS back to target.
                    currentImagingStatus = ImagingStatus.halt ' halt for now
                Else
                    'imaging has not aborted.  What to do now?  Give up?
                    currentImagingStatus = ImagingStatus.halt ' halt for now
                End If
            ElseIf currentImagingStatus = ImagingStatus.imageComplete Then
                TextBoxStatus.Text = "Image Complete"
                ' We have the image. Save it.  Possibly check for focus.......

                skyXFunctions.saveCurrentImageToImageFolder()

                currentImagingStatus = ImagingStatus.postImageComplete
            ElseIf currentImagingStatus = ImagingStatus.postImageComplete Then
                TextBoxStatus.Text = "Post Image Complete"
                imageFileSequence.incrementSequenceImageCount()
                currentImagingStatus = ImagingStatus.setupNextImage
            ElseIf currentImagingStatus = ImagingStatus.setupNextImage Then
                ' Are we finished?
                If imageFileSequence.isImageRunComplete Then
                    currentImagingStatus = ImagingStatus.acqireTarget
                ElseIf imageFileSequence.isCurrentExposureTypeAtFocus3 Then
                    currentImagingStatus = ImagingStatus.runAtFocus3
                ElseIf skyXFunctions.updateMountPointingPositionAndReturnMeridianFlip() Then
                    ' We need to perform a meridian flip
                    ' It is possible that the mount could pass through the meridian after imaging complete but before take image !!!!!!!
                    currentImagingStatus = ImagingStatus.meridianFlip
                ElseIf imageFileSequence.isExecuteDitherSet Then
                    If Not phd2guiding.isPHDGuidingAndLockedOnStar Then
                        currentImagingStatus = ImagingStatus.dither
                    Else
                        currentImagingStatus = ImagingStatus.preTakeImage
                    End If
                Else
                    currentImagingStatus = ImagingStatus.preTakeImage
                End If
            ElseIf currentImagingStatus = ImagingStatus.runAtFocus3 Then
                If skyXFunctions.runAtFocus3FullyAutomatically() Then
                    If overrideImagingStatus = ImagingStatus.empty Then
                        currentImagingStatus = ImagingStatus.postImageComplete
                    Else
                        currentImagingStatus = overrideImagingStatus
                        overrideImagingStatus = ImagingStatus.empty
                    End If
                Else
                    ' Focus Failed, abort
                    currentImagingStatus = ImagingStatus.abort
                End If
            ElseIf currentImagingStatus = ImagingStatus.halt Then
                TextBoxStatus.Text = "Halt"
                BtnStartImaging.Enabled = True
                BtnAbortImaging.Enabled = False
                BtnPauseImaging.Enabled = False
                BtnStopImaging.Enabled = False
                BtnSettingsImaging.Enabled = True
                TmrImagingLoop.Stop()

            ElseIf currentImagingStatus = ImagingStatus.abort Then
                TextBoxStatus.Text = "Abort"
                BtnStartImaging.Enabled = True
                BtnAbortImaging.Enabled = False
                BtnPauseImaging.Enabled = False
                BtnStopImaging.Enabled = False
                BtnSettingsImaging.Enabled = True
                TmrImagingLoop.Stop()
            End If

            isTmrImagingLoopTicking = False
        End If
    End Sub

    Private Sub BtnStopImaging_Click(sender As Object, e As EventArgs) Handles BtnStopImaging.Click
        currentImagingStatus = ImagingStatus.halt
    End Sub

    Private Sub BtnSettingsImaging_Click(sender As Object, e As EventArgs) Handles BtnSettingsImaging.Click
        ImagingSettings.Show()
    End Sub

    Private Sub BtnTargetSearch_Click(sender As Object, e As EventArgs) Handles BtnTargetSearch.Click
        searchForTargetAndAddToListIfVisible()
    End Sub

    Private Sub TxtTarget_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTarget.KeyDown
        If e.KeyCode = Keys.Enter Then
            searchForTargetAndAddToListIfVisible()
        End If
    End Sub

    Private Sub searchForTargetAndAddToListIfVisible()
        Dim targetFound As Boolean = False

        If isSkyXConnected AndAlso skyXFunctions IsNot Nothing Then
            targetFound = skyXFunctions.findObject(TxtTarget.Text)
        Else
            targetFound = False
        End If

        If TxtTarget.Text = "" Then
            targetFound = False
        End If
        ' If search target is found add to targets panel and clear search box
        If targetFound Then
            If skyXFunctions.isCurrentdObjectVisible Then
                addToNextTarget("N " & TxtTarget.Text.ToUpper)
                TxtTarget.Text = ""
            Else
                targetFound = False
            End If
        End If
    End Sub

    Private Sub BtnSlewLimits_Click(sender As Object, e As EventArgs) Handles BtnClearTargets.Click
        clearTargetListText()
    End Sub

    Private Sub BtnSelectImage_Click(sender As Object, e As EventArgs) Handles BtnSelectImage.Click
        If imageSelectionForTargets Is Nothing Then
            imageSelectionForTargets = New OpenFileDialog()
            imageSelectionForTargets.Title = "Select Image to Solve"
            imageSelectionForTargets.InitialDirectory = "C:\"
            imageSelectionForTargets.Filter = "Fits (*.fit*)|*.fit*|All files (*.*)|*.*"
            imageSelectionForTargets.FilterIndex = 1
            imageSelectionForTargets.RestoreDirectory = True
        Else
            imageSelectionForTargets.FileName = ""
            imageSelectionForTargets.InitialDirectory = imageSelectionForTargets_init_folder
        End If

        If imageSelectionForTargets.ShowDialog() = DialogResult.OK Then
            imageSelectionForTargets_init_folder = imageSelectionForTargets.InitialDirectory
            ' Get RA + Dec from Image
            Dim fkv As New FitsKeyValues()
            fkv.populateKeyDataFromFile(imageSelectionForTargets.FileName)
            If fkv.isRAandDECPresent Then
                ' put image in box
                addToNextTarget("I " & imageSelectionForTargets.FileName)
            Else
                MsgBox("Coordinates are not present in image")
            End If
        End If
    End Sub

    Private Sub BtnRemoveTarget_Click(sender As Object, e As EventArgs) Handles BtnRemoveTarget.Click
        removeHighlightedTarget()
        reorderTargetList()
    End Sub

    Private Sub LblTargetListItem1_Click(sender As Object, e As EventArgs) Handles LblTargetListItem1.Click
        clearBordersOnAllTargets()
        If LblTargetListItem1.BorderStyle = BorderStyle.None Then
            LblTargetListItem1.BorderStyle = BorderStyle.FixedSingle
        Else
            LblTargetListItem1.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Sub LblTargetListItem2_Click(sender As Object, e As EventArgs) Handles LblTargetListItem2.Click
        clearBordersOnAllTargets()
        If LblTargetListItem2.BorderStyle = BorderStyle.None Then
            LblTargetListItem2.BorderStyle = BorderStyle.FixedSingle
        Else
            LblTargetListItem2.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Sub LblTargetListItem3_Click(sender As Object, e As EventArgs) Handles LblTargetListItem3.Click
        clearBordersOnAllTargets()
        If LblTargetListItem3.BorderStyle = BorderStyle.None Then
            LblTargetListItem3.BorderStyle = BorderStyle.FixedSingle
        Else
            LblTargetListItem3.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Sub LblTargetListItem4_Click(sender As Object, e As EventArgs) Handles LblTargetListItem4.Click
        clearBordersOnAllTargets()
        If LblTargetListItem4.BorderStyle = BorderStyle.None Then
            LblTargetListItem4.BorderStyle = BorderStyle.FixedSingle
        Else
            LblTargetListItem4.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Sub LblTargetListItem5_Click(sender As Object, e As EventArgs) Handles LblTargetListItem5.Click
        clearBordersOnAllTargets()
        If LblTargetListItem5.BorderStyle = BorderStyle.None Then
            LblTargetListItem5.BorderStyle = BorderStyle.FixedSingle
        Else
            LblTargetListItem5.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Sub LblTargetListItem6_Click(sender As Object, e As EventArgs) Handles LblTargetListItem6.Click
        clearBordersOnAllTargets()
        If LblTargetListItem6.BorderStyle = BorderStyle.None Then
            LblTargetListItem6.BorderStyle = BorderStyle.FixedSingle
        Else
            LblTargetListItem6.BorderStyle = BorderStyle.None
        End If
    End Sub

    Private Sub clearBordersOnAllTargets()
        LblTargetListItem1.BorderStyle = BorderStyle.None
        LblTargetListItem2.BorderStyle = BorderStyle.None
        LblTargetListItem3.BorderStyle = BorderStyle.None
        LblTargetListItem4.BorderStyle = BorderStyle.None
        LblTargetListItem5.BorderStyle = BorderStyle.None
        LblTargetListItem6.BorderStyle = BorderStyle.None
    End Sub

    Private Function addToNextTarget(nextTarget As String) As Boolean
        If isTargetAlreadyPresent(nextTarget) = True Then
            Return True
        End If

        For Each targetLabel As Label In getListOfTargets()
            If targetLabel.Text = "" Then
                targetLabel.Text = nextTarget
                Exit For
            End If
        Next
        Return True
    End Function

    Private Function isTargetAlreadyPresent(newTarget As String) As Boolean
        Dim targetIsPresent As Boolean = False
        For Each tgt As Label In getListOfTargets()
            If tgt.Text = newTarget Then
                targetIsPresent = True
                Exit For
            End If
        Next
        Return targetIsPresent
    End Function

    Private Function removeHighlightedTarget() As Boolean
        If LblTargetListItem1.BorderStyle = BorderStyle.FixedSingle Then
            LblTargetListItem1.BorderStyle = BorderStyle.None
            LblTargetListItem1.Text = ""
        End If
        If LblTargetListItem2.BorderStyle = BorderStyle.FixedSingle Then
            LblTargetListItem2.BorderStyle = BorderStyle.None
            LblTargetListItem2.Text = ""
        End If
        If LblTargetListItem3.BorderStyle = BorderStyle.FixedSingle Then
            LblTargetListItem3.BorderStyle = BorderStyle.None
            LblTargetListItem3.Text = ""
        End If
        If LblTargetListItem4.BorderStyle = BorderStyle.FixedSingle Then
            LblTargetListItem4.BorderStyle = BorderStyle.None
            LblTargetListItem4.Text = ""
        End If
        If LblTargetListItem5.BorderStyle = BorderStyle.FixedSingle Then
            LblTargetListItem5.BorderStyle = BorderStyle.None
            LblTargetListItem5.Text = ""
        End If
        If LblTargetListItem6.BorderStyle = BorderStyle.FixedSingle Then
            LblTargetListItem6.BorderStyle = BorderStyle.None
            LblTargetListItem6.Text = ""
        End If
        Return True
    End Function

    Private Function reorderTargetList() As Boolean
        Dim targetLabelsText As New List(Of String)
        Dim targetLabels As List(Of Label) = getListOfTargets()

        For Each targetLabel As Label In targetLabels
            If targetLabel.Text <> "" Then
                targetLabelsText.Add(targetLabel.Text)
            End If
        Next

        clearTargetListText()

        Dim index As Integer = 0
        For Each targetText As String In targetLabelsText
            If targetText <> "" Then
                targetLabels.ElementAt(index).Text = targetText
            End If
            index += 1
        Next

        Return True
    End Function

    Private Function clearTargetListText() As Boolean
        Dim targetLabelsText As New List(Of String)

        For Each targetLabel As Label In getListOfTargets()
            targetLabel.Text = ""
        Next

        Return True
    End Function

    Private Function getListOfTargets() As List(Of Label)
        If targetLabels Is Nothing Then
            targetLabels = New List(Of Label)
            targetLabels.Add(LblTargetListItem1)
            targetLabels.Add(LblTargetListItem2)
            targetLabels.Add(LblTargetListItem3)
            targetLabels.Add(LblTargetListItem4)
            targetLabels.Add(LblTargetListItem5)
            targetLabels.Add(LblTargetListItem6)
        End If
        Return targetLabels
    End Function

    Private Function getNextTargetFromList() As String
        Dim currentTarget As String = getCurrrentTargetFromList()
        Dim nextTarget As String = ""
        Dim useNextTarget As Boolean = False

        If currentTarget = "" Then
            useNextTarget = True
        End If

        For Each tgt As Label In getListOfTargets()
            If useNextTarget = True Then
                nextTarget = tgt.Text
                tgt.ForeColor = Color.Red
                Exit For
            End If
            If currentTarget = tgt.Text Then
                tgt.ForeColor = Color.Black
                useNextTarget = True
            End If
        Next
        Return nextTarget
    End Function

    Private Function getCurrrentTargetFromList() As String
        Dim currentTarget As String = ""

        For Each tgt As Label In getListOfTargets()
            If tgt.ForeColor = Color.Red Then
                currentTarget = tgt.Text
                Exit For
            End If
        Next

        Return currentTarget
    End Function

    Private Sub clearCurrentTargetFromList()
        For Each tgt As Label In getListOfTargets()
            tgt.ForeColor = Color.Black
        Next
    End Sub

    Private Function isTargetListPopulated() As Boolean
        Dim isListPopulated As Boolean = False

        For Each targetLabel As Label In getListOfTargets()
            If targetLabel.Text <> "" Then
                isListPopulated = True
                Exit For
            End If
        Next

        Return isListPopulated
    End Function

    Private Sub BtnEnterRAAndDec_Click(sender As Object, e As EventArgs) Handles BtnEnterRAAndDec.Click
        My.Settings.LastSequenceFile = ""
        EnterRaAndDec.Show()
    End Sub

    Private Sub TxtImageFolder_TextChanged(sender As Object, e As EventArgs) Handles TxtImageFolder.TextChanged
        My.Settings.ImageFolder = TxtImageFolder.Text
        My.Settings.Save()
    End Sub
End Class
