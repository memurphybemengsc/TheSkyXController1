﻿Public Class ImageSequence
    Dim sequenceFileValue As String = ""
    Public componentPanel As Panel = Nothing

    Enum ReadSequenceFileContext
        firstLineOfFile
        inSequenceElementHeader
        inSequenceElementData
        inSequenceElementFooter
    End Enum

    Class ImageSequenceElement
        Public filter As String
        Public exposureLength As String
        Public binX As String
        Public binY As String
        Public exposureType As String
        'Public ditherYn As String
        Public repeats As String
        Public ditherEveryNImages As String

        Public Sub New()
            filter = ""
            exposureLength = "1"
            binY = "1"
            binY = "1"
            exposureType = "Light"
            'ditherYn = "N"
            repeats = "1"
            ditherEveryNImages = "0"
        End Sub
    End Class

    Public imageSequenceElements As New List(Of ImageSequenceElement)

    Public ReadOnly Property SequenceFile
        Get
            Return sequenceFileValue
        End Get
    End Property

    Public Sub OpenSequenceFile()

        Dim openFileDialog As New OpenFileDialog()
        Dim rootFolder As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

        openFileDialog.InitialDirectory = rootFolder
        openFileDialog.Filter = "Sqeuence Files|*.seq;"
        openFileDialog.FilterIndex = 1
        openFileDialog.RestoreDirectory = False

        If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            sequenceFileValue = openFileDialog.FileName
        Else
            sequenceFileValue = ""
        End If

        openFileDialog.Dispose()

        If sequenceFileValue IsNot "" Then
            imageSequenceElements.Clear()
            ReadSequenceFile(sequenceFileValue)
        End If

    End Sub

    Public Sub SaveSequenceFileAs()
        Dim saveFileDialog As New SaveFileDialog
        Dim rootFolder As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

        saveFileDialog.InitialDirectory = rootFolder
        saveFileDialog.Filter = "Sequence Files|*.seq;"
        saveFileDialog.FilterIndex = 1
        saveFileDialog.RestoreDirectory = False

        If saveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            WriteSequenceFile(saveFileDialog.FileName)
        End If
    End Sub

    Public Sub ReadSequenceFile(fileName As String)
        Dim imageSequenceElement As New ImageSequenceElement()
        Dim readSequenceFileContext As ReadSequenceFileContext
        readSequenceFileContext = ReadSequenceFileContext.firstLineOfFile

        Dim file = My.Computer.FileSystem.OpenTextFileReader(fileName)
        Do Until file.EndOfStream
            Dim sequenceLine = file.ReadLine
            Dim temp As String
            If sequenceLine.Length - 25 >= 0 Then
                temp = sequenceLine.Substring(24, sequenceLine.Length - 24)
            Else
                temp = ""
            End If

            If sequenceLine.CompareTo("; Sequence File") = 0 And readSequenceFileContext = ReadSequenceFileContext.firstLineOfFile Then
                readSequenceFileContext = ReadSequenceFileContext.inSequenceElementHeader
            ElseIf sequenceLine.CompareTo("; Sequence Header") = 0 And readSequenceFileContext = ReadSequenceFileContext.inSequenceElementHeader Then
                imageSequenceElement = New ImageSequenceElement()
                readSequenceFileContext = ReadSequenceFileContext.inSequenceElementData
            ElseIf readSequenceFileContext = ReadSequenceFileContext.inSequenceElementData Then
                readSequenceFileContext = ReadSequenceFileContext.inSequenceElementData

                If sequenceLine.CompareTo("; Sequence Footer") = 0 Then
                    readSequenceFileContext = ReadSequenceFileContext.inSequenceElementHeader
                    imageSequenceElements.Add(imageSequenceElement)
                ElseIf sequenceLine.Substring(0, 24).CompareTo("Filter                = ") = 0 Then
                    imageSequenceElement.filter = sequenceLine.Substring(24, sequenceLine.Length - 24)
                ElseIf sequenceLine.Substring(0, 24).CompareTo("Exposure Time         = ") = 0 Then
                    imageSequenceElement.exposureLength = sequenceLine.Substring(24, sequenceLine.Length - 24)
                ElseIf sequenceLine.Substring(0, 24).CompareTo("Exposure Type         = ") = 0 Then
                    imageSequenceElement.exposureType = sequenceLine.Substring(24, sequenceLine.Length - 24)
                ElseIf sequenceLine.Substring(0, 24).CompareTo("BinX                  = ") = 0 Then
                    imageSequenceElement.binX = sequenceLine.Substring(24, sequenceLine.Length - 24)
                ElseIf sequenceLine.Substring(0, 24).CompareTo("BinY                  = ") = 0 Then
                    imageSequenceElement.binY = sequenceLine.Substring(24, sequenceLine.Length - 24)
                ElseIf sequenceLine.Substring(0, 24).CompareTo("Repeats               = ") = 0 Then
                    imageSequenceElement.repeats = sequenceLine.Substring(24, sequenceLine.Length - 24)
                    'ElseIf sequenceLine.Substring(0, 24).CompareTo("DitherYN              = ") = 0 Then
                    '    imageSequenceElement.ditherYn = sequenceLine.Substring(24, sequenceLine.Length - 24)
                ElseIf sequenceLine.Substring(0, 24).CompareTo("Dither Every N Images = ") = 0 Then
                    imageSequenceElement.repeats = sequenceLine.Substring(24, sequenceLine.Length - 24)
                Else
                    'corrupt file format
                End If

            Else
                'corrupt file format
            End If

        Loop

        file.Close()
    End Sub

    Public Sub WriteSequenceFile(fileName As String)
        Dim file = My.Computer.FileSystem.OpenTextFileWriter(fileName, False)
        file.WriteLine("; Sequence File")
        For Each imageSequenceElement In imageSequenceElements
            file.WriteLine("; Sequence Header")
            file.WriteLine("Filter                = " & imageSequenceElement.filter)
            file.WriteLine("Exposure Time         = " & imageSequenceElement.exposureLength)
            file.WriteLine("Exposure Type         = " & imageSequenceElement.exposureType)
            file.WriteLine("BinX                  = " & imageSequenceElement.binX)
            file.WriteLine("BinY                  = " & imageSequenceElement.binY)
            file.WriteLine("Repeats               = " & imageSequenceElement.repeats)
            'file.WriteLine("DitherYN              = " & imageSequenceElement.ditherYn)
            file.WriteLine("Dither Every N Images = " & imageSequenceElement.ditherEveryNImages)

            file.WriteLine("; Sequence Footer")
        Next
        file.Close()
    End Sub

    Function BuildPanelAndAddLabels()
        Dim panelFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Dim panelComponentSize = New System.Drawing.Size(100, panelFont.Height)

        Dim pnlComponents As New Panel()
        Dim componentY As Integer = 0
        Dim componentYIncrement As Integer = 21

        Dim exposureType As New Label()
        exposureType.Font = panelFont
        exposureType.Location = New System.Drawing.Point(0, componentY)
        exposureType.Name = "labFilter"
        exposureType.Size = panelComponentSize
        exposureType.Text = "Exposure Type"
        exposureType.TabIndex = 1
        pnlComponents.Controls.Add(exposureType)
        componentY += componentYIncrement

        Dim labFilter As New Label()
        labFilter.Font = panelFont
        labFilter.Location = New System.Drawing.Point(0, componentY)
        labFilter.Name = "labFilter"
        labFilter.Size = panelComponentSize
        labFilter.Text = "Filter"
        labFilter.TabIndex = 2
        pnlComponents.Controls.Add(labFilter)
        componentY += componentYIncrement

        Dim labExposureLength As New Label()
        labExposureLength.Font = panelFont
        labExposureLength.Location = New System.Drawing.Point(0, componentY)
        labExposureLength.Name = "labExposureLength"
        labExposureLength.Text = "Exposure Length"
        labExposureLength.Size = panelComponentSize
        labExposureLength.TabIndex = 3
        pnlComponents.Controls.Add(labExposureLength)
        componentY += componentYIncrement

        Dim binX As New Label()
        binX.Font = panelFont
        binX.Location = New System.Drawing.Point(0, componentY)
        binX.Name = "BinX"
        binX.Size = panelComponentSize
        binX.Text = "Bin X"
        binX.TabIndex = 4
        pnlComponents.Controls.Add(binX)
        componentY += componentYIncrement

        Dim binY As New Label()
        binY.Font = panelFont
        binY.Location = New System.Drawing.Point(0, componentY)
        binY.Name = "BinY"
        binY.Size = panelComponentSize
        binY.Text = "Bin Y"
        binY.TabIndex = 5
        pnlComponents.Controls.Add(binY)
        componentY += componentYIncrement

        Dim repeats As New Label()
        repeats.Font = panelFont
        repeats.Location = New System.Drawing.Point(0, componentY)
        repeats.Name = "repeats"
        repeats.Size = panelComponentSize
        repeats.Text = "Repeats"
        repeats.TabIndex = 6
        pnlComponents.Controls.Add(repeats)
        componentY += componentYIncrement

        'Dim ditherYn As New ComboBox()
        'ditherYn.Items.Add("Y")
        'ditherYn.Items.Add("N")
        'ditherYn.ItemHeight = 10
        'ditherYn.SelectedItem = imgSeqEl.ditherYn
        'ditherYn.Name = "ditherYn"
        'ditherYn.Font = panelFont
        'ditherYn.TabIndex = 7
        'ditherYn.Location = New System.Drawing.Point(0, componentY)
        'pnlComponents.Controls.Add(ditherYn)
        'componentY += ditherYn.Size.Height

        Dim ditherEveryNImages As New Label()
        ditherEveryNImages.Font = panelFont
        ditherEveryNImages.Name = "ditherEveryNImages"
        ditherEveryNImages.Text = "Dither Every N Images"
        ditherEveryNImages.TabIndex = 8
        ditherEveryNImages.Location = New System.Drawing.Point(0, componentY)
        pnlComponents.Controls.Add(ditherEveryNImages)
        componentY += componentYIncrement

        Return pnlComponents
    End Function


    Function BuildPanelAndAddComponents(counter As Integer, imgSeqEl As ImageSequenceElement) As Panel
        Dim panelFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Dim panelComponentSize = New System.Drawing.Size(100, 1)

        Dim pnlComponents As New Panel()
        Dim componentY As Integer = 0

        Dim exposureType As New ComboBox()
        exposureType.Items.Add("Light")
        exposureType.Items.Add("Dark")
        exposureType.Items.Add("Flat (s)")
        exposureType.Items.Add("Flat (%)")
        exposureType.Items.Add("Bias")
        exposureType.Items.Add("@Focus3")
        exposureType.Items.Add("Prompt")
        exposureType.Name = "exposureType"
        exposureType.Text = imgSeqEl.exposureType
        exposureType.ItemHeight = 10
        exposureType.Font = panelFont
        exposureType.TabIndex = 1
        exposureType.Location = New System.Drawing.Point(0, componentY)
        pnlComponents.Controls.Add(exposureType)
        componentY += exposureType.Size.Height

        Dim labFilter As New ComboBox()
        For Each filter As String In TheSkyXController.defaultFilterWheelNames
            labFilter.Items.Add(filter)
        Next
        labFilter.Font = panelFont
        labFilter.Location = New System.Drawing.Point(0, componentY)
        labFilter.Name = "labFilter"
        labFilter.Size = panelComponentSize
        labFilter.Text = imgSeqEl.filter
        labFilter.TabIndex = 2
        pnlComponents.Controls.Add(labFilter)
        componentY += labFilter.Size.Height

        Dim labExposureLength As New NumericUpDown()
        labExposureLength.Font = panelFont
        labExposureLength.Location = New System.Drawing.Point(0, componentY)
        labExposureLength.Name = "labExposureLength"
        labExposureLength.Size = panelComponentSize
        labExposureLength.Maximum = 1000
        labExposureLength.DecimalPlaces = 6
        labExposureLength.Value = imgSeqEl.exposureLength
        labExposureLength.TabIndex = 3
        pnlComponents.Controls.Add(labExposureLength)
        componentY += labExposureLength.Size.Height

        Dim binX As New NumericUpDown()
        binX.Font = panelFont
        binX.Location = New System.Drawing.Point(0, componentY)
        binX.Name = "BinX"
        binX.Size = panelComponentSize
        binX.Value = imgSeqEl.binX
        binX.DecimalPlaces = 0
        binX.TabIndex = 4
        pnlComponents.Controls.Add(binX)
        componentY += binX.Size.Height

        Dim binY As New NumericUpDown()
        binY.Font = panelFont
        binY.Location = New System.Drawing.Point(0, componentY)
        binY.Name = "BinY"
        binY.Size = panelComponentSize
        binY.Value = imgSeqEl.binY
        binY.DecimalPlaces = 0
        binY.TabIndex = 5
        pnlComponents.Controls.Add(binY)
        componentY += binY.Size.Height

        Dim repeats As New NumericUpDown()
        repeats.Font = panelFont
        repeats.Location = New System.Drawing.Point(0, componentY)
        repeats.Name = "repeats"
        repeats.Size = panelComponentSize
        repeats.Value = imgSeqEl.repeats
        repeats.DecimalPlaces = 0
        repeats.TabIndex = 6
        pnlComponents.Controls.Add(repeats)
        componentY += repeats.Size.Height

        'Dim ditherYn As New ComboBox()
        'ditherYn.Items.Add("Y")
        'ditherYn.Items.Add("N")
        'ditherYn.ItemHeight = 10
        'ditherYn.SelectedItem = imgSeqEl.ditherYn
        'ditherYn.Name = "ditherYn"
        'ditherYn.Font = panelFont
        'ditherYn.TabIndex = 7
        'ditherYn.Location = New System.Drawing.Point(0, componentY)
        'pnlComponents.Controls.Add(ditherYn)
        'componentY += ditherYn.Size.Height

        Dim ditherEveryNImages As New NumericUpDown()
        ditherEveryNImages.Value = imgSeqEl.ditherEveryNImages
        ditherEveryNImages.Font = panelFont
        ditherEveryNImages.Name = "ditherEveryNImages"
        ditherEveryNImages.TabIndex = 8
        ditherEveryNImages.Location = New System.Drawing.Point(0, componentY)
        pnlComponents.Controls.Add(ditherEveryNImages)
        componentY += ditherEveryNImages.Size.Height

        Dim btnX As Integer = 0
        Dim btnY As Integer = componentY
        Dim btnWidth As Integer = 30
        Dim btnHeight As Integer = 30

        Dim btnFarLeft As New Button()
        btnFarLeft.Text = "<<"
        btnFarLeft.Size = New System.Drawing.Size(btnWidth, btnHeight)
        btnFarLeft.Name = "btnFarLeft_" & counter
        btnFarLeft.Location = New System.Drawing.Point(btnX, btnY)
        AddHandler btnFarLeft.Click, AddressOf Me.button_click
        pnlComponents.Controls.Add(btnFarLeft)

        btnX += btnWidth

        Dim btnLeft As New Button()
        btnLeft.Text = "<"
        btnLeft.Size = New System.Drawing.Size(btnWidth, btnHeight)
        btnLeft.Name = "btnLeft_" & counter
        btnLeft.Location = New System.Drawing.Point(btnX, btnY)
        AddHandler btnLeft.Click, AddressOf Me.button_click
        pnlComponents.Controls.Add(btnLeft)

        btnX += btnWidth

        Dim btnCopy As New Button()
        btnCopy.Text = "C"
        btnCopy.Size = New System.Drawing.Size(btnWidth, btnHeight)
        btnCopy.Name = "btnCopy_" & counter
        btnCopy.Location = New System.Drawing.Point(btnX, btnY)
        AddHandler btnCopy.Click, AddressOf Me.button_click
        pnlComponents.Controls.Add(btnCopy)

        btnX += btnWidth

        Dim btnDelete As New Button()
        btnDelete.Text = "X"
        btnDelete.Size = New System.Drawing.Size(btnWidth, btnHeight)
        btnDelete.Name = "btnDelete_" & counter
        btnDelete.Location = New System.Drawing.Point(btnX, btnY)
        AddHandler btnDelete.Click, AddressOf Me.button_click
        pnlComponents.Controls.Add(btnDelete)

        btnX += btnWidth
        Dim btnRight As New Button()
        btnRight.Text = ">"
        btnRight.Size = New System.Drawing.Size(btnWidth, btnHeight)
        btnRight.Name = "btnRight_" & counter
        btnRight.Location = New System.Drawing.Point(btnX, btnY)
        AddHandler btnRight.Click, AddressOf Me.button_click
        pnlComponents.Controls.Add(btnRight)

        btnX += btnWidth

        Dim btnFarRight As New Button()
        btnFarRight.Text = ">>"
        btnFarRight.Size = New System.Drawing.Size(btnWidth, btnHeight)
        btnFarRight.Name = "btnFarRight_" & counter
        btnFarRight.Location = New System.Drawing.Point(btnX, btnY)
        AddHandler btnFarRight.Click, AddressOf Me.button_click
        pnlComponents.Controls.Add(btnFarRight)

        Return pnlComponents
    End Function


    Private Sub button_click(sender As Object, e As System.EventArgs)
        'MsgBox("Name is " & sender.name & " Text is " & sender.text)
        Dim buttonName As String = sender.name
        Dim panelNumber As Integer = Convert.ToInt32(buttonName.Substring(buttonName.IndexOf("_") + 1, buttonName.Length - (buttonName.IndexOf("_") + 1)))
        If buttonName.Substring(0, buttonName.IndexOf("_")) = "btnFarLeft" And panelNumber > 1 Then
            moveSequenceElementToFarLeft(panelNumber)
        ElseIf buttonName.Substring(0, buttonName.IndexOf("_")) = "btnLeft" And panelNumber > 1 Then
            moveSequenceElementToLeft(panelNumber)
        ElseIf buttonName.Substring(0, buttonName.IndexOf("_")) = "btnCopy" Then
            copySequenceElement(panelNumber)
        ElseIf buttonName.Substring(0, buttonName.IndexOf("_")) = "btnDelete" And imageSequenceElements.Count > 1 Then
            removeSequenceElement(panelNumber)
        ElseIf buttonName.Substring(0, buttonName.IndexOf("_")) = "btnRight" And panelNumber < imageSequenceElements.Count Then
            moveSequenceElementToRight(panelNumber)
        ElseIf buttonName.Substring(0, buttonName.IndexOf("_")) = "btnFarRight" And panelNumber < imageSequenceElements.Count Then
            moveSequenceElementToFarRight(panelNumber)
        End If
    End Sub

    Private Sub moveSequenceElementToFarLeft(sequenceElementToCopy As Integer)
        Dim counter As Integer = 1
        Dim newSequenceElements As New List(Of ImageSequenceElement)
        Dim tmpSequenceElements As New List(Of ImageSequenceElement)
        Dim selectedSeqEl As New ImageSequenceElement
        refreshElementsfromControls()
        For Each seqEl In imageSequenceElements
            If counter = sequenceElementToCopy Then
                selectedSeqEl = seqEl
            Else
                tmpSequenceElements.Add(seqEl)
            End If
            counter += 1
        Next
        newSequenceElements.Add(selectedSeqEl)
        newSequenceElements.AddRange(tmpSequenceElements)
        imageSequenceElements = newSequenceElements
        buildPanel()
    End Sub

    Private Sub moveSequenceElementToLeft(sequenceElementToCopy As Integer)
        Dim counter As Integer = 1
        Dim preSequenceElements As New List(Of ImageSequenceElement)
        Dim postSequenceElements As New List(Of ImageSequenceElement)
        Dim selectedSeqEl As New ImageSequenceElement
        refreshElementsfromControls()
        For Each seqEl In imageSequenceElements
            If counter < sequenceElementToCopy - 1 Then
                preSequenceElements.Add(seqEl)
            ElseIf counter = sequenceElementToCopy Then
                selectedSeqEl = seqEl
            Else
                postSequenceElements.Add(seqEl)
            End If
            counter += 1
        Next
        preSequenceElements.Add(selectedSeqEl)
        preSequenceElements.AddRange(postSequenceElements)
        imageSequenceElements = preSequenceElements
        buildPanel()
    End Sub

    Private Sub copySequenceElement(sequenceElementToCopy As Integer)
        Dim counter As Integer = 1
        Dim newSequenceElements As New List(Of ImageSequenceElement)
        refreshElementsfromControls()
        For Each seqEl In imageSequenceElements
            If counter <> sequenceElementToCopy Then
                newSequenceElements.Add(seqEl)
            Else
                newSequenceElements.Add(seqEl)
                newSequenceElements.Add(seqEl)
            End If
            counter += 1
        Next
        imageSequenceElements = newSequenceElements
        buildPanel()
    End Sub

    Private Sub removeSequenceElement(sequenceElementToCopy As Integer)
        Dim counter As Integer = 1
        Dim newSequenceElements As New List(Of ImageSequenceElement)
        refreshElementsfromControls()
        For Each seqEl In imageSequenceElements
            If counter <> sequenceElementToCopy Then
                newSequenceElements.Add(seqEl)
            End If
            counter += 1
        Next
        imageSequenceElements = newSequenceElements
        buildPanel()
    End Sub

    Private Sub moveSequenceElementToRight(sequenceElementToCopy As Integer)
        Dim counter As Integer = 1
        Dim preSequenceElements As New List(Of ImageSequenceElement)
        Dim postSequenceElements As New List(Of ImageSequenceElement)
        Dim selectedSeqEl As New ImageSequenceElement
        refreshElementsfromControls()
        For Each seqEl In imageSequenceElements
            If counter <= sequenceElementToCopy - 1 Then
                preSequenceElements.Add(seqEl)
            ElseIf counter = sequenceElementToCopy Then
                selectedSeqEl = seqEl
            ElseIf counter = sequenceElementToCopy + 1 Then
                preSequenceElements.Add(seqEl)
            Else
                postSequenceElements.Add(seqEl)
            End If
            counter += 1
        Next
        preSequenceElements.Add(selectedSeqEl)
        preSequenceElements.AddRange(postSequenceElements)
        imageSequenceElements = preSequenceElements
        buildPanel()
    End Sub
    Private Sub moveSequenceElementToFarRight(sequenceElementToCopy As Integer)
        Dim counter As Integer = 1
        Dim newSequenceElements As New List(Of ImageSequenceElement)
        Dim tmpSequenceElements As New List(Of ImageSequenceElement)
        Dim selectedSeqEl As New ImageSequenceElement
        refreshElementsfromControls()
        For Each seqEl In imageSequenceElements
            If counter = sequenceElementToCopy Then
                selectedSeqEl = seqEl
            Else
                tmpSequenceElements.Add(seqEl)
            End If
            counter += 1
        Next
        newSequenceElements.AddRange(tmpSequenceElements)
        newSequenceElements.Add(selectedSeqEl)
        imageSequenceElements = newSequenceElements
        buildPanel()
    End Sub

    Public Sub buildPanel()
        componentPanel.Controls.Clear()
        Dim xPos As Integer = 0
        Dim counter As Integer = 1

        'Dim labelPanel As Panel = BuildPanelAndAddLabels()
        'labelPanel.Location = New System.Drawing.Point(xPos, 0)
        'labelPanel.Size = New Size(labelPanel.Size.Width, componentPanel.Size.Height)
        'componentPanel.Controls.Add(labelPanel)
        'xPos = xPos + labelPanel.Size.Width
        'counter = counter + 1

        For Each imgSeqEl In imageSequenceElements
            Dim newPanel As Panel = BuildPanelAndAddComponents(counter, imgSeqEl)
            newPanel.Location = New System.Drawing.Point(xPos, 0)
            newPanel.Size = New Size(newPanel.Size.Width, componentPanel.Size.Height)
            componentPanel.Controls.Add(newPanel)
            xPos = xPos + newPanel.Size.Width
            counter = counter + 1
        Next
    End Sub

    Public Sub refreshElementsfromControls()
        imageSequenceElements.Clear()
        Dim hasChilderen As Boolean = componentPanel.HasChildren

        For Each childPanel As Control In componentPanel.Controls
            Dim imgSeqEl As New ImageSequenceElement
            For Each child As Control In childPanel.Controls
                Dim name As String = child.Name 'component name
                Dim text As String = child.Text 'component value
                If name = "labFilter" Then
                    imgSeqEl.filter = text
                ElseIf name = "labExposureLength" Then
                    imgSeqEl.exposureLength = text
                ElseIf name = "exposureType" Then
                    imgSeqEl.exposureType = text
                ElseIf name = "BinX" Then
                    imgSeqEl.binX = text
                ElseIf name = "BinY" Then
                    imgSeqEl.binY = text
                ElseIf name = "repeats" Then
                    imgSeqEl.repeats = text
                    'ElseIf name = "ditherYn" Then
                    '    imgSeqEl.ditherYn = text
                ElseIf name = "ditherEveryNImages" Then
                    imgSeqEl.ditherEveryNImages = text
                End If
            Next
            imageSequenceElements.Add(imgSeqEl)
        Next

    End Sub

    Public Sub openFileAndBuildComponents()
        OpenSequenceFile()
        buildPanel()
    End Sub

    Public Sub refreshComponentsAndSaveFile()
        refreshElementsfromControls()
        SaveSequenceFileAs()
    End Sub

    Public Sub createInitialPanel()
        imageSequenceElements.Add(New ImageSequenceElement)
        buildPanel()
    End Sub

    Public Sub populateSequenceUsingFitsKeyCollection(fkc As FitsKeyCollection)
        imageSequenceElements.Clear()
        For Each fkv As FitsKeyValues In fkc.fitsKeySummaryForFlats
            Dim ise As New ImageSequenceElement
            ise.binX = fkv.XBinning
            ise.binY = fkv.YBinning
            ise.ditherEveryNImages = "0"
            ise.exposureLength = 40
            ise.exposureType = "Flat (%)"
            ise.filter = fkv.Filter
            ise.repeats = fkc.numberOfImagesToTake
            imageSequenceElements.Add(ise)
        Next

        For Each fkv As FitsKeyValues In fkc.fitsKeySummaryForDarks
            Dim ise As New ImageSequenceElement
            ise.binX = fkv.XBinning
            ise.binY = fkv.YBinning
            ise.ditherEveryNImages = "0"
            ise.exposureLength = fkv.ExposureTime
            ise.exposureType = "Dark"
            ise.filter = "Dark"
            ise.repeats = fkc.numberOfImagesToTake
            imageSequenceElements.Add(ise)
        Next
    End Sub

End Class
