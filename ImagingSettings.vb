Public Class ImagingSettings

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.TxtImageFolder.Text = My.Settings.ImageFolder
    End Sub

    Private Sub BtnSelectFolder_Click(sender As Object, e As EventArgs) Handles BtnSelectFolder.Click
        Dim folderBrowserDialog1 As New FolderBrowserDialog()
        folderBrowserDialog1.ShowNewFolderButton = True
        folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer

        If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TxtImageFolder.Text = folderBrowserDialog1.SelectedPath
            TheSkyXController.skyXFunctions.setImageFolder(TxtImageFolder.Text)
            TheSkyXController.TxtImageFolder.Text = TxtImageFolder.Text
        Else
            Me.Close()
        End If
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        TheSkyXController.skyXFunctions.setCLSUntilArcSecs(NumUpDownCLSTo.Value)
        Close()
    End Sub
End Class