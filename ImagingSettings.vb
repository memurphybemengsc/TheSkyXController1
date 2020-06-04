Public Class ImagingSettings
    Private Sub BtnSelectFolder_Click(sender As Object, e As EventArgs) Handles BtnSelectFolder.Click
        Dim folderBrowserDialog1 As New FolderBrowserDialog()
        folderBrowserDialog1.ShowNewFolderButton = False
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
        Close()
    End Sub
End Class