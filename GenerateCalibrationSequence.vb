Imports System.IO
Imports System.Text

Public Class GenerateCalibrationSequence
    Public fkc As New FitsKeyCollection

    Private Sub BtnSelectImageFolder_Click(sender As Object, e As EventArgs) Handles BtnSelectImageFolder.Click
        Dim folderBrowserDialog1 As New FolderBrowserDialog()
        folderBrowserDialog1.ShowNewFolderButton = False
        folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer

        If folderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TxtBoxImageFolder.Text = folderBrowserDialog1.SelectedPath
            ImagerMainForm.fitsKeyCollection.rootFolder = TxtBoxImageFolder.Text
        Else
            Me.Close()
        End If
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnGenSeq_Click(sender As Object, e As EventArgs) Handles BtnGenSeq.Click
        If TxtBoxImageFolder.Text = "" Then
            MessageBox.Show("Image folder is not specified", "", MessageBoxButtons.OK)
            Return
        End If

        Dim result = MessageBox.Show("WARNING: This will overright the existing image sequence", "WARNING", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Return
        End If

        fkc.populateKeysAndGenerateSequence(TxtBoxImageFolder.Text)
        ImagerMainForm.imageFileSequence.buildPanel()

    End Sub

    Private Sub NumUDNoOfSubs_ValueChanged(sender As Object, e As EventArgs) Handles NumUDNoOfSubs.ValueChanged
        fkc.numberOfImagesToTake = NumUDNoOfSubs.Value
    End Sub
End Class