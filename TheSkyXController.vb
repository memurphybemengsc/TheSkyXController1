Imports TheSkyXLib

Public Class TheSkyXController
    Public imageFileSequence As New ImageSequence()
    Private defaultFilterWheelNames As List(Of String)
    Dim imagingSequenceInProgress As Boolean
    Dim isPhd2Connected As Boolean = False
    Public fitsKeyCollection As FitsKeyCollection
    Public phd2guiding As PHD2Guiding = Nothing
    Public skyXFunctions As SkyXFunctions = Nothing
    Dim isSkyXConnected As Boolean = False
    Private imagingRunPaused As Boolean
    Private imagingRunAborted As Boolean
    Private currentImagingStatus As Integer = ImagingStatus.notImaging
    Private isTmrImagingLoopTicking As Boolean = False

    Private Enum ImagingStatus
        start
        notImaging
        startGuiding
        takeImage
        imageInProgress
        imageComplete
        postImageComplete
        dither
        ditheringInProgress
        ditherComplete
        changeFilter
        filterChangeInProgress
        runClosedLoopSlew
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
                LblCameraStatus.ForeColor = Color.Green

                If skyXFunctions.isFilterWheelConnected Then
                    LblFilterWheel.ForeColor = Color.Green
                    populateDefaultFilterWheelNames(skyXFunctions.getFilterNames)
                    imageFileSequence.buildPanel()
                End If

                If skyXFunctions.isFocuserConnected Then
                    LblFocuser.ForeColor = Color.Green
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
                LblCameraStatus.ForeColor = Color.Red
                LblFilterWheel.ForeColor = Color.Red
                LblFocuser.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub BtnPHD2_Click(sender As Object, e As EventArgs) Handles BtnPHD2.Click
        If phd2guiding Is Nothing Then
            Try
                phd2guiding = New PHD2Guiding()
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
                phd2guiding = Nothing
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
            currentImagingStatus = ImagingStatus.notImaging

            ' Make sure any changes to the controls are reflected in the sequence elements
            imageFileSequence.refreshElementsfromControls()

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
        If Not isTmrImagingLoopTicking Then
            ' We have this boolean as the tick will be called even if the previous tick has not finished
            isTmrImagingLoopTicking = True
            If currentImagingStatus = ImagingStatus.start Then
                ' initialise the various counters
                imageFileSequence.initialiseImageRun()
                currentImagingStatus = ImagingStatus.notImaging
            ElseIf currentImagingStatus = ImagingStatus.notImaging Then
                If phd2guiding IsNot Nothing AndAlso Not phd2guiding.isPHDGuidingAndLockedOnStar Then
                    ' PHD is not guiding so start guiding
                    phd2guiding.startGuiding()
                    currentImagingStatus = ImagingStatus.startGuiding
                Else
                    ' No PHD connection so start imaging
                    currentImagingStatus = ImagingStatus.takeImage
                End If
            ElseIf currentImagingStatus = ImagingStatus.startGuiding Then
                If phd2guiding IsNot Nothing AndAlso phd2guiding.isPHDGuidingAndLockedOnStar Then
                    ' PHD is now guiding so take an image
                    currentImagingStatus = ImagingStatus.takeImage
                Else
                    ' We should add a timeout
                End If
            ElseIf currentImagingStatus = ImagingStatus.dither Then
                If phd2guiding IsNot Nothing AndAlso phd2guiding.isPHDGuidingAndLockedOnStar Then
                    ' PHD is now guiding so take an image
                    phd2guiding.ditherMount()
                    currentImagingStatus = ImagingStatus.ditheringInProgress
                End If
            ElseIf currentImagingStatus = ImagingStatus.ditheringInProgress Then
                If phd2guiding.isDitherComplete Then
                    currentImagingStatus = ImagingStatus.ditherComplete
                End If
            ElseIf currentImagingStatus = ImagingStatus.ditherComplete Then
                currentImagingStatus = ImagingStatus.takeImage
            ElseIf currentImagingStatus = ImagingStatus.takeImage Then
                ' Get the next image sequence
                If Not skyXFunctions.refreshCameraImageSettingsFromCurrentImageSequence() Then
                    'we have an error, now what?
                End If
                If Not skyXFunctions.takeAnImageAsynchronously() Then
                    'we have an error, now what?
                End If

                currentImagingStatus = ImagingStatus.imageInProgress
            ElseIf currentImagingStatus = ImagingStatus.imageInProgress Then
                ' We should check PHD is still guiding, possibly allow guiding failure for a certain amount of time
                If Not skyXFunctions.isImagingInProgress Then
                    currentImagingStatus = ImagingStatus.imageComplete
                End If
            ElseIf currentImagingStatus = ImagingStatus.imageComplete Then
                ' We have the image. Save it.  Possibly check for focus.......
                currentImagingStatus = ImagingStatus.postImageComplete
            ElseIf currentImagingStatus = ImagingStatus.postImageComplete Then
                imageFileSequence.incrementSequenceImageCount()

                ' Are we finished?
                If imageFileSequence.isSequenceComplete Then
                    currentImagingStatus = ImagingStatus.halt
                ElseIf imageFileSequence.isExecuteDitherSet Then
                    currentImagingStatus = ImagingStatus.dither
                End If

            ElseIf currentImagingStatus = ImagingStatus.halt Then
                BtnStartImaging.Enabled = True
                BtnAbortImaging.Enabled = False
                BtnPauseImaging.Enabled = False
                BtnStopImaging.Enabled = False
                TmrImagingLoop.Stop()

            ElseIf currentImagingStatus = ImagingStatus.abort Then
                BtnStartImaging.Enabled = True
                BtnAbortImaging.Enabled = False
                BtnPauseImaging.Enabled = False
                BtnStopImaging.Enabled = False
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
        MsgBox("Functionality to be added")
    End Sub

    Private Sub BtnSlewLimits_Click(sender As Object, e As EventArgs) Handles BtnSlewLimits.Click
        MsgBox("Define slew limits for scope, functionality to be added")
    End Sub
End Class
