Imports System.IO

Public Class FitsKeyCollection
    Private fitsKeys = New List(Of FitsKeyValues)
    Private fitsKeysForLightFrames = New List(Of FitsKeyValues)
    Public fitsKeySummaryForFlats = New List(Of FitsKeyValues)
    Public fitsKeySummaryForDarks = New List(Of FitsKeyValues)
    Public numberOfImagesToTake As String = "1"
    Private rootFolderValue As String

    Public Property rootFolder() As String
        Get
            Return rootFolderValue
        End Get
        Set(value As String)
            rootFolderValue = value
        End Set
    End Property

    Public Sub populateKeysAndGenerateSequence(folder As String)
        populateFitsKeysFromFilesInfolder(folder)
        TheSkyXController.imageFileSequence.PopulateSequenceUsingFitsKeyCollection(Me)
    End Sub

    Private Sub populateFitsKeysFromFilesInfolder(folder As String)
        Dim fileList As New ArrayList
        fileList = getFilesInFolder(folder)
        populateFitsKeysFromFileList(fileList)
        Me.fitsKeys = Me.summariseFitsKeys(Me.fitsKeys)

        populateLightFramesFromFitsKeys()
        blankFilterFieldForLightFrames()
        blankFocusPositionForLightFrames()

        Me.fitsKeySummaryForDarks = Me.summariseFitsKeys(Me.fitsKeysForLightFrames)

        populateLightFramesFromFitsKeys()
        blankFocusPositionForLightFrames()
        blankExposureTimeForLightFrames()

        Me.fitsKeySummaryForFlats = Me.summariseFitsKeys(Me.fitsKeysForLightFrames)

    End Sub

    Private Sub populateLightFramesFromFitsKeys()

        fitsKeysForLightFrames = New List(Of FitsKeyValues)
        For Each fkv As FitsKeyValues In fitsKeys
            If fkv.isLightFrame Then
                fitsKeysForLightFrames.Add(fkv.clone())
            End If
        Next

    End Sub

    Private Function summariseFitsKeys(fkvIn As List(Of FitsKeyValues)) As List(Of FitsKeyValues)
        Dim fkvs As New List(Of FitsKeyValues)
        Dim lastSortKey As String = ""

        fkvIn.Sort()

        For Each fkv As FitsKeyValues In fkvIn
            If fkv.SortKey <> lastSortKey Then
                fkvs.Add(fkv)
                lastSortKey = fkv.SortKey
            End If
        Next

        Return fkvs
    End Function

    Private Sub blankFilterFieldForLightFrames()
        For Each fkv As FitsKeyValues In fitsKeysForLightFrames
            fkv.Filter = ""
        Next
    End Sub

    Private Sub blankFocusPositionForLightFrames()
        For Each fkv As FitsKeyValues In fitsKeysForLightFrames
            fkv.FocusPosition = ""
        Next
    End Sub
    Private Sub blankExposureTimeForLightFrames()
        For Each fkv As FitsKeyValues In fitsKeysForLightFrames
            fkv.ExposureTime = "0"
        Next
    End Sub

    Private Function getFilesInFolder(selectedFolder As String) As ArrayList
        Dim di As DirectoryInfo = New DirectoryInfo(selectedFolder)
        Dim directories() As DirectoryInfo = di.GetDirectories("*", SearchOption.AllDirectories)

        Dim files() As FileInfo = di.GetFiles("*", SearchOption.AllDirectories)

        Dim fileList As New ArrayList

        For Each file In files
            If file.Extension.ToUpper = ".FIT" Or file.Extension.ToUpper = ".FITS" Then
                fileList.Add(file.FullName)
            End If
        Next

        Return fileList
    End Function

    Private Sub populateFitsKeysFromFileList(filelist As ArrayList)

        For Each file In filelist
            Dim fkv As New FitsKeyValues()
            fkv.populateKeyDataFromFile(file)
            If fkv.isPopulated Then
                fitsKeys.add(fkv)
            End If
        Next

    End Sub

    Private Function buildImageSequenceFromFitsSummary(fitsSummary As String) As ImageSequence
        Dim imgSeq As New ImageSequence
        Dim tempString As String
        Dim pos As Integer
        Dim counter As Integer = 1
        pos = fitsSummary.IndexOf("_")

        ' Get Image Type 1 (Light), 2 (Bias), 3 (Dark), 4 (Flat)
        tempString = fitsSummary.Substring(0, pos)
        Return imgSeq
    End Function

    Private Function buildImageSequenceFromFitsString(fitsString As String) As ImageSequence
        Dim imgSeq As New ImageSequence
        'PICTYPE_XBINNING_YBINNING_FOCPOS_FILTER_EXPTIME
        'need to parse the string using '_'
        Return imgSeq
    End Function

End Class
