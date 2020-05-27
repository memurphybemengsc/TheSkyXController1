Public Class TheSkyXController
    Public imageFileSequence As New ImageSequence()
    Public defaultFilterWheelNames As New List(Of String)
    Dim imagingSequenceInProgress As Boolean
    Dim phd2Connected As Boolean = False
    Public fitsKeyCollection As FitsKeyCollection
    Public phd2guiding As PHD2Guiding = Nothing
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

    End Sub
    Private Sub BtnSkyX_Click(sender As Object, e As EventArgs) Handles BtnSkyX.Click
        Dim skyobj As New SkyXFunctions
        skyobj.isSkyXPresent()

    End Sub

    Private Sub BtnPHD2_Click(sender As Object, e As EventArgs) Handles BtnPHD2.Click
        If phd2guiding Is Nothing Then
            Try
                phd2guiding = New PHD2Guiding()
                phd2Connected = True
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
End Class
