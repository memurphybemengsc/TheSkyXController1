Public Class TheSkyXController
    Public imageFileSequence As New ImageSequence()
    Public defaultFilterWheelNames As New List(Of String)
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
        notImaging
        startGuiding
        takeImage
        imageInProgress
        imageComplete
        dither
        ditheringInProgress
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
        defaultFilterWheelNames.Add("Lum")
        defaultFilterWheelNames.Add("Red")
        defaultFilterWheelNames.Add("Green")
        defaultFilterWheelNames.Add("Blue")
        defaultFilterWheelNames.Add("Ha")
        defaultFilterWheelNames.Add("O3")
        defaultFilterWheelNames.Add("S2")
        defaultFilterWheelNames.Add("Dark")

        imagingSequenceInProgress = False

        fitsKeyCollection = New FitsKeyCollection

        BtnStartImaging.Enabled = False
        BtnAbortImaging.Enabled = False
        BtnPauseImaging.Enabled = False
        BtnStopImaging.Enabled = False

    End Sub
    Private Sub BtnSkyX_Click(sender As Object, e As EventArgs) Handles BtnSkyX.Click
        If skyXFunctions Is Nothing Then
            ' We have not connected to SkyX
            Try
                skyXFunctions = New SkyXFunctions()
                Me.PnlSkyXStatus.BackColor = Color.Green
                isSkyXConnected = True
                BtnStartImaging.Enabled = True
            Catch ex As Exception
                MsgBox("SkyX is not running")
            End Try
        Else
            ' We are disconnecting from SkyX, check are we guiding or imaging
            Dim res = MsgBox("Imaging is in progress, do you wish to disconnect?", MsgBoxStyle.YesNo)
            If (res = MsgBoxResult.Yes) Then
                Me.PnlSkyXStatus.BackColor = Color.Red
                skyXFunctions = Nothing
                isSkyXConnected = False
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
        If phd2guiding IsNot Nothing Then
            phd2guiding.startGuiding()
            MsgBox("phd status is " + Me.phd2guiding.checkStatus.ToString)
        Else
            MsgBox("phd is not connected")
        End If

        MsgBox("Cick to stop guiding")

        phd2guiding.stopGuiding()

    End Sub

    Private Sub BtnSeqenceAppend_Click(sender As Object, e As EventArgs) Handles BtnSeqenceAppend.Click
        MsgBox("Feature to be added")
    End Sub

    Private Sub BtnLoadGroup_Click(sender As Object, e As EventArgs) Handles BtnLoadGroup.Click
        MsgBox("Feature to be added")
    End Sub

    Private Sub BtnStartImaging_Click(sender As Object, e As EventArgs) Handles BtnStartImaging.Click
        ' Are we connected to SkyX?
        If isSkyXConnected AndAlso skyXFunctions IsNot Nothing AndAlso skyXFunctions.isCameraConnected Then
            BtnAbortImaging.Enabled = True
            BtnPauseImaging.Enabled = True
            BtnStopImaging.Enabled = True

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
            MsgBox("Start of tick")
            If currentImagingStatus = ImagingStatus.halt Then
                TmrImagingLoop.Stop()
            ElseIf currentImagingStatus = ImagingStatus.abort Then
                TmrImagingLoop.Stop()
            End If
            MsgBox("End of tick")
            isTmrImagingLoopTicking = False
        End If
    End Sub

    Private Sub BtnStopImaging_Click(sender As Object, e As EventArgs) Handles BtnStopImaging.Click
        currentImagingStatus = ImagingStatus.halt
    End Sub
End Class
