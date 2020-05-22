Public Class TheSkyXController
    Public imageFileSequence As New ImageSequence()
    Public defaultFilterWheelNames As New List(Of String)
    Dim imagingSequenceInProgress As Boolean
    Dim phd2Connected As Boolean = False
    Public fitsKeyCollection As FitsKeyCollection
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

    End Sub

    Private Sub BtnPHD2_Click(sender As Object, e As EventArgs) Handles BtnPHD2.Click

    End Sub

    Private Sub BtnCalibrationFrames_Click(sender As Object, e As EventArgs) Handles BtnCalibrationFrames.Click
        ' Add code to generate a sequence to generate calibration frames
        ' 1) Specify folder
        ' 2) List Files
        ' 3) Generate sequence
        ' 4) Remove existing sequence and replace with new - Add message box to warn user
        GenerateCalibrationSequence.Show()
    End Sub
End Class
