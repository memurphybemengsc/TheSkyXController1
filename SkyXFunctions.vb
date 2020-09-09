Imports System.Runtime.CompilerServices
Imports System.Runtime.ExceptionServices
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Serialization
Imports System.Security.Cryptography
Imports ASCOM.DriverAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports TheSkyXLib

Public Class SkyXFunctions
    ' This class holds the functions to interact with TheSkyX
    Dim skyXVersion As String = ""
    Dim skyXObject As Object = vbNull
    Dim currentSkyObject As Object = vbNull
    Private theSkyXObject As TheSkyXLib.Application = Nothing
    Private camera As TheSkyXLib.ccdsoftCamera = Nothing
    Private imageFolder As String = ""
    Private CLSUntilArcSecs As Double = 10
    Private imagePrefix As String = ""
    Private filterNames As List(Of String) = Nothing
    Private currentImage As TheSkyXLib.ccdsoftImage
    Private mount As TheSkyXLib.sky6RASCOMTele
    Private automatedImageLinkSettings As TheSkyXLib.AutomatedImageLinkSettings
    Private closedLoopSlew As TheSkyXLib.ClosedLoopSlew
    Private imageLink As TheSkyXLib.ImageLink
    Private imageLinkResults As TheSkyXLib.ImageLinkResults
    Private astroTargetInformation As TheSkyXLib.sky6ObjectInformation
    Private starChart As TheSkyXLib.sky6StarChart
    Private skyUtils As TheSkyXLib.Isky6Utils

    Private tgtRa As Double
    Private tgtDec As Double

    Enum MountPointingPosition
        noPosition
        mountEast
        mountWest
    End Enum

    Private mountEastWest As MountPointingPosition

    Enum ccdsoftInventoryIndex
        cdInventoryX
        cdInventoryY
        cdInventoryMagnitude
        cdInventoryClass
        cdInventoryFWHM
        cdInventoryMajorAxis
        cdInventoryMinorAxis
        cdInventoryTheta
        cdInventoryEllipticity
    End Enum

    Public Sub New()
        'Create the SkyX object and check that Skyx is present and initialised
        connectToSkyX()
        If theSkyXObject Is Nothing Then
            'SkyX is not running so throw exception
            Throw New System.Exception("SkyX is not running")
        End If

        ' Connect to the camera
        connectToCamera()
        If camera Is Nothing Then
            Throw New System.Exception("Unable to connect to camera")
        End If

        'Get the filter wheel filters and refresh the filters in the drop downs
        ' Is there a filter wheel? Test connecting to a FW if there is not one connected.
        If isFilterWheelPresent() Then
            camera.filterWheelConnect()
            ' Loop over filters and get names
            populateFilterNames()
        End If

        If isFocuserPresent() Then
            camera.focConnect()
        End If

        mountEastWest = MountPointingPosition.noPosition
    End Sub

    Public Function getFilterNames() As List(Of String)
        Return filterNames
    End Function

    Private Sub populateFilterNames()
        Dim numberOfFilters = camera.lNumberFilters
        Dim thisFilter As Integer = 0
        filterNames = New List(Of String)
        While thisFilter < numberOfFilters
            filterNames.Add(camera.szFilterName(thisFilter))
            thisFilter += 1
        End While
    End Sub

    Private Sub moveToFilter(newFilter As String)
        If camera.filterWheelIsConnected() = 0 Then
            Return
        End If

        If filterNames Is Nothing Then
            populateFilterNames()
        End If

        If getFilterIndexZeroBased(newFilter) <> -1 Then
            camera.FilterIndexZeroBased = getFilterIndexZeroBased(newFilter)
        End If
    End Sub

    Private Function getFilterIndexZeroBased(filterName As String) As Integer
        Dim filterIndexZeroBased As Integer = 0
        Dim filterNotFound As Boolean = True
        For Each locFilterName As String In filterNames
            If locFilterName = filterName Then
                filterNotFound = False
                Exit For
            End If
            filterIndexZeroBased += 1
        Next

        If filterNotFound Then
            filterIndexZeroBased = -1
        End If

        Return filterIndexZeroBased
    End Function

    Public Sub cameraStatus()
        'MsgBox(camera.Status) '"Ready" when camera is idle
        'MsgBox(camera.State) ' '0' when idle ccdsoftCameraState.cdStateNone
        MsgBox("camera.szFilterName(0) " + camera.szFilterName(0))
        If camera.filterWheelIsConnected = 1 Then
            ' We are connected to a filter wheel
            Dim thisFilter = camera.FilterIndexZeroBased

        End If

    End Sub

    Public Sub setCLSUntilArcSecs(arcsec As Double)
        CLSUntilArcSecs = arcsec
    End Sub

    Public Sub setImageFolder(imgFldr As String)
        imageFolder = imgFldr
    End Sub

    Public Function getImageFolder() As String
        Return imageFolder
    End Function

    Public Sub setImagePrefix(imgPfx As String)
        imagePrefix = imgPfx
    End Sub

    Public Function getImagePrefix() As String
        Return imagePrefix
    End Function

    Public Sub disconnect()
        disconnectFromCamera()
    End Sub

    Private Function setImageSettings(imageType As Integer, filter As String, exposure As Double, bx As Integer, by As Integer) As Boolean
        Dim retval As Boolean = True

        moveToFilter(filter)
        camera.ExposureTime = exposure
        camera.BinX = bx
        camera.BinY = by
        camera.ImageReduction = ccdsoftImageReduction.cdNone

        Return retval
    End Function
    ' Add a method to check for image saturation

    Private Sub connectToSkyXTest()
        skyXVersion = "TEST"
        theSkyXObject = New Object()
        camera = New Object()
        MsgBox(“TSX Version: “ & skyXVersion)
    End Sub

    Private Sub connectToSkyX()
        Try
            theSkyXObject = New TheSkyXLib.Application
        Catch ex As Exception
            theSkyXObject = Nothing
        End Try

        If theSkyXObject IsNot Nothing Then
            skyXVersion = theSkyXObject.version
            MsgBox(“TSX Version: “ & skyXVersion)
        End If
    End Sub

    Private Sub connectToCamera()
        Try
            camera = New TheSkyXLib.ccdsoftCamera
        Catch ex As Exception
            camera = Nothing
        End Try
        If camera IsNot Nothing Then
            Try
                camera.Connect()
            Catch ex As Exception
                camera = Nothing
            End Try
        End If
    End Sub

    Private Sub disconnectFromCamera()
        If camera IsNot Nothing Then
            camera.Disconnect()
            camera = Nothing
        End If
    End Sub

    Public Function isCameraConnected() As Boolean
        If theSkyXObject Is Nothing Or camera Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function isFocuserPresentAndConnected() As Boolean
        Dim retval As Boolean = True
        If isFocuserPresent() AndAlso isFocuserConnected() Then
            retval = True
        End If
        Return retval
    End Function

    Public Function isFocuserPresent() As Boolean
        Dim retval As Boolean = True
        If Not isFocuserConnected() Then
            retval = False
            Try
                camera.focConnect()
            Catch ex As Exception
                retval = False
            End Try
        End If
        Return retval
    End Function

    Public Function isFocuserConnected() As Boolean
        If camera IsNot Nothing AndAlso camera.focIsConnected = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function isFilterWheelPresentAndConnected() As Boolean
        Dim retval As Boolean = False
        If isFilterWheelPresent() AndAlso isFilterWheelConnected() Then
            retval = True
        End If
        Return retval
    End Function
    Public Function isFilterWheelPresent() As Boolean
        Dim retval As Boolean = True
        If Not isFilterWheelConnected() Then
            Try
                camera.filterWheelConnect()
            Catch ex As Exception
                ' We treat an exception trying to connect as the filter wheel is not present
                retval = False
            End Try
        End If
        Return retval
    End Function

    Public Function isFilterWheelConnected() As Boolean
        If camera.filterWheelIsConnected = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function isSkyXInitialised() As Boolean
        Dim initialised As Boolean

        isSkyXInitialised = False

        Return initialised
    End Function

    Public Function slewTocurrentObject() As Boolean
        Dim success As Boolean = False
        Return success
    End Function
    'Sub TakeImage()
    '    Dim tsxo = CreateObject(“TheSkyX.ccdsoftCamera”)
    '    Dim status = tsxo.Connect()

    '    Console.WriteLine("Status is " & status.ToString)
    '    tsxo.ExposureTime = 10
    '    ' takes two photos for some reason
    '    tsxo.Frame = 1 ' 1 = light, 2 = bias, 3 = dark, 4 = flat
    '    tsxo.ImageReduction = 0 ' enum  	ccdsoftImageReduction { cdNone, cdAutoDark, cdBiasDarkFlat }
    '    tsxo.AutoSaveOn = 1
    '    status = tsxo.TakeImage()
    '    tsxo.Disconnect()
    '    MsgBox(“Image Done”)
    'End Sub

    'Sub TakeImage1()
    '    Dim tsxo = New TheSkyXLib.ccdsoftCamera
    '    Dim status = tsxo.Connect()

    '    Console.WriteLine("Status is " & status.ToString)
    '    tsxo.ExposureTime = 10
    '    ' takes two photos for some reason
    '    tsxo.Frame = 1 ' 1 = light, 2 = bias, 3 = dark, 4 = flat
    '    tsxo.ImageReduction = 0 ' enum  	ccdsoftImageReduction { cdNone, cdAutoDark, cdBiasDarkFlat }
    '    tsxo.AutoSaveOn = 1
    '    status = tsxo.TakeImage()
    '    Dim focPos As Integer = tsxo.focPosition
    '    Dim fwPos As Integer = tsxo.FilterIndexZeroBased

    '    tsxo.Disconnect()
    '    MsgBox(“Image Done”)
    'End Sub

    Sub AnalyseImage()

        Dim image = New TheSkyXLib.ccdsoftImage


        For Each fitsFile As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.MyPictures)
            Dim fitsInfo = My.Computer.FileSystem.GetFileInfo(fitsFile)
            If fitsInfo.Extension = ".fit" Then
                Console.WriteLine("File is " & fitsInfo.FullName)

                image.Path = fitsInfo.FullName
                image.Open()
                Dim avgPixel As Double = image.averagePixelValue()
                Console.WriteLine("  Average Pixel Value is " & avgPixel.ToString)
                image.ShowInventory()
                Dim invArry() As Object = image.InventoryArray(4)
                'For i As Integer = 0 To 10 'invArry.Length
                '    Console.WriteLine("FWHM is {0}", invArry.GetValue(i))
                'Next
                Dim invArryX() As Object = image.InventoryArray(0)
                Dim invArryY() As Object = image.InventoryArray(1)
                Dim invArryMag() As Object = image.InventoryArray(2)
                For i As Integer = 0 To 10 'invArry.Length
                    Console.WriteLine("X is {0} Y is {1} Mag is {2} FWHM is {3}", invArryX.GetValue(i), invArryY.GetValue(i), invArryMag.GetValue(i), invArry.GetValue(i))
                Next
                'For Each value In invArry
                '    Dim t As Type = value.GetType()
                '    If t.Equals(GetType(Byte)) Then
                '        Console.WriteLine("{0} is an unsigned byte.", value)
                '    ElseIf t.Equals(GetType(SByte)) Then
                '        Console.WriteLine("{0} is a signed byte.", value)
                '    ElseIf t.Equals(GetType(Integer)) Then
                '        Console.WriteLine("{0} is a 32-bit integer.", value)
                '    ElseIf t.Equals(GetType(Long)) Then
                '        Console.WriteLine("{0} is a 32-bit integer.", value)
                '    ElseIf t.Equals(GetType(Double)) Then
                '        Console.WriteLine("{0} is a double-precision floating point.",
                '              value)
                '    Else
                '        Console.WriteLine("'{0}' is another data type.", value)
                '    End If
                'Next
                'For Each magnitude In invArryMag
                '    Console.WriteLine("Magnitude is " & magnitude)
                'Next

                'For i As Integer = 0 To 10 'invArry.Length
                '    Console.WriteLine("FWHM is {0} Mag is {0}", invArry.GetValue(i), invArryMag.GetValue(i))
                'Next

                'Console.WriteLine("Object type is " & invArry.GetType.ToString)
                'Dim invArry1 As List(Of Object) = image.InventoryArray(4)

                'invArry.GetType.GetProperties.
                image.Close()
            End If
        Next

        'ccdsoftInventoryIndex
    End Sub

    Public Function refreshCameraImageSettingsFromCurrentImageSequence() As Boolean
        Dim retval As Boolean = True

        Dim filter As String = TheSkyXController.imageFileSequence.getCurrentImageSequenceElement.filter
        Dim bx As Double = TheSkyXController.imageFileSequence.getCurrentImageSequenceElement.binX
        Dim by As Double = TheSkyXController.imageFileSequence.getCurrentImageSequenceElement.binY
        Dim exposure As Double = TheSkyXController.imageFileSequence.getCurrentImageSequenceElement.exposureLength
        Dim exposureType As Integer

        If TheSkyXController.imageFileSequence.isCurrentExposureTypeALightFrame Then
            exposureType = ccdsoftImageFrame.cdLight
        ElseIf TheSkyXController.imageFileSequence.isCurrentExposureTypeAtFocus3 Then
            ' What?????
            exposureType = ccdsoftImageFrame.cdLight
        End If

        setImageSettings(exposureType, filter, exposure, bx, by)

        Return retval
    End Function

    Public Function runAtFocus3FullyAutomatically() As Boolean
        Dim retval As Boolean = False

        retval = runAtFocus3(0, True)

        Return retval
    End Function

    Public Function runAtFocus3Manually(nAveraging As Integer) As Boolean
        Dim retval As Boolean = False

        retval = runAtFocus3(nAveraging, False)

        Return retval
    End Function

    ''' <summary>
    ''' Run @Focus3.<br/>
    ''' nAveraging is the number of samples acquired at each focus position. Supported values are 1, 2, 3.<br/>
    ''' fullyAutomatic When true means one sample per focus position, automatically determines the exposure time and optimal subframe.
    ''' Will take a full frame and determine what the best subframe is.<br/><br/>
    ''' Returns true if success.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function runAtFocus3(nAveraging As Integer, fullyAutomatic As Boolean) As Boolean
        Dim retval As Boolean = False

        If nAveraging > 3 Then
            nAveraging = 3
        End If

        Try
            camera.AtFocus3(nAveraging, fullyAutomatic)
            retval = True
        Catch ex As Exception
        End Try

        Return retval
    End Function
    Public Function takeAnImageAsynchronously() As Boolean
        Dim retval As Boolean = True

        ' Set the camera to be asynchronous
        camera.Asynchronous = 1
        camera.AutoSavePath = getImageFolder()
        camera.AutoSavePrefix = getImagePrefix()
        If camera.AutoSavePrefix = "" Then
            camera.AutoSavePrefix = "IMAGE"
        End If

        Try
            camera.TakeImage()
        Catch e As Exception
            retval = False
        End Try

        Return retval
    End Function

    Public Function takeAnImageSynchronously() As Boolean
        Dim retval As Boolean = True

        ' Set the camera to be asynchronous
        camera.Asynchronous = 0
        camera.AutoSavePath = getImageFolder()
        camera.AutoSavePrefix = getImagePrefix()
        If camera.AutoSavePrefix = "" Then
            camera.AutoSavePrefix = "IMAGE"
        End If

        Try
            camera.TakeImage()
        Catch e As Exception
            retval = False
        End Try

        Return retval
    End Function

    ''' <summary>
    ''' Abort the image, returns true of successful, false if unsuccessful
    ''' </summary>
    Public Function abortImage() As Boolean
        Dim retval As Boolean = False

        If isImagingInProgress() Then
            Try
                If camera.Abort() = 0 Then
                    retval = True
                Else
                    retval = False
                End If
            Catch e As Exception
                retval = False
            End Try
        End If

        Return retval
    End Function

    Public Function isImagingInProgress() As Boolean
        Dim retval As Boolean = False

        ' Set the camera to be asynchronous
        If camera.IsExposureComplete = 0 Then
            retval = True
        End If

        Return retval
    End Function

    Public Function attachImage(fullPathToImage As String) As Boolean
        Dim retval As Boolean = True

        If currentImage Is Nothing Then
            currentImage = New ccdsoftImage()
        End If
        currentImage.Path = fullPathToImage
        currentImage.Open()
        'AttachToActiveImager()  'This attaches to the most recent image captured

        Return retval
    End Function

    Public Function attachCurrentImage() As Boolean
        Dim retval As Boolean = True

        If currentImage Is Nothing Then
            currentImage = New ccdsoftImage()
        End If
        currentImage.AttachToActiveImager()  'This attaches to the most recent image captured

        Return retval
    End Function

    Public Function attachCurrentImage0() As Boolean
        Dim retval As Boolean = True

        If currentImage Is Nothing Then
            currentImage = New ccdsoftImage()
        End If
        'currentImage.AttachToActive()
        currentImage.AttachToActiveImager()  'This attaches to the most recent image captured
        'currentImage.ccdsoftInventoryIndex.cdinventoryfwhm
        '.currentImage.cdInventoryFWHM
        'ccdsoftInventoryIndex.

        'currentImage.Path = "C:\Users\murph\source\repos\memurphybemengsc\TheSkyXController1\Leo Triplet 20200415.fit"
        'currentImage.Open()

        Dim mypath As String = currentImage.Path
        Dim avpv As Double = currentImage.averagePixelValue()

        currentImage.ShowInventory()

        'Dim obj As List(Of Double) = currentImage.InventoryArray(ccdsoftInventoryIndex.cdInventoryFWHM)
        Dim obj As Object = currentImage.InventoryArray(ccdsoftInventoryIndex.cdInventoryFWHM)

        For Each db As Double In obj
            Console.WriteLine(db)
        Next

        'currentImage.Close()


        'MsgBox("x")

        Return retval
    End Function

    ''' <summary>
    ''' Attaches the current image object to the image most recently captured by the camera.<br/>
    ''' Returns true if OK else false.
    ''' </summary>
    Public Function attachCurrentImageToActiveImager() As Boolean
        Dim retval As Boolean = True

        If currentImage Is Nothing Then
            currentImage.AttachToActiveImager() ' ******  Test this function if no image  ****************
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Attaches the current image object to the image most recently captured by the camera.<br/>
    ''' Returns true if OK else false.
    ''' </summary>
    Public Function attachCurrentImageToActiveImagerAndShowInventory() As Boolean
        Dim retval As Boolean = False

        If attachCurrentImageToActiveImager() Then
            currentImage.ShowInventory()
            retval = True
        Else
            retval = False
        End If

        Return retval
    End Function

    Public Sub setCurrentImagetoNothing()
        currentImage = Nothing
    End Sub

    ''' <summary>
    ''' Return the average FWHM for the image.<br/>
    ''' Will return a -1 if an error.
    ''' </summary>
    Public Function getAverageFWHMForCurrentImage() As Double
        Dim averageFWHM As Double = -1

        If attachCurrentImageToActiveImagerAndShowInventory() Then
            Dim obj As Object = currentImage.InventoryArray(ccdsoftInventoryIndex.cdInventoryFWHM)
            Dim counter As Integer = 0
            Dim totalFWHN As Double = 0
            For Each db As Double In obj
                totalFWHN += db
                counter += 1
            Next
            If counter > 0 Then
                averageFWHM = totalFWHN / counter
            Else
                averageFWHM = -1
            End If
        Else
            averageFWHM = -1 ' Flag error
        End If

        Return averageFWHM
    End Function

    ''' <summary>
    ''' Return the average Ellipticity for the image.<br/>
    ''' Will return a -1 if an error.
    ''' </summary>
    Public Function getAverageEllipticityForCurrentImage() As Double
        Dim averageEllipticity As Double = -1

        If attachCurrentImageToActiveImagerAndShowInventory() Then
            Dim obj As Object = currentImage.InventoryArray(ccdsoftInventoryIndex.cdInventoryEllipticity)
            Dim counter As Integer = 0
            Dim totalEllipticity As Double = 0
            For Each db As Double In obj
                totalEllipticity += db
                counter += 1
            Next
            If counter > 0 Then
                averageEllipticity = totalEllipticity / counter
            Else
                averageEllipticity = -1
            End If
        Else
            averageEllipticity = -1 ' Flag error
        End If

        Return averageEllipticity
    End Function

    Private Sub connectToMount()
        If mount Is Nothing Then
            mount = New TheSkyXLib.sky6RASCOMTele
            Try
                mount.Connect()
            Catch e As Exception
                If e.Message.Contains("Error: Command failed") Then
                    mount = Nothing
                End If
            End Try
        End If
    End Sub

    Public Function slewMount(ra As Double, dec As Double, target As String) As Boolean
        Dim retval As Boolean = True

        If mount IsNot Nothing Then
            mount.SlewToRaDec(ra, dec, target)
        End If

        Return retval
    End Function

    Public Function isMountParked() As Boolean
        If mount Is Nothing Then
            Return True
        Else
            Return mount.IsParked()
        End If
    End Function

    Public Function isMountpresentAndConnected() As Boolean
        Dim retval As Boolean = False

        If isMountPresent() AndAlso isMountConnected() Then
            retval = True
        Else
            retval = False
        End If

        Return retval
    End Function
    Public Function isMountPresent() As Boolean
        Dim retval As Boolean = False

        connectToMount()
        If mount Is Nothing Then
            retval = False
        Else
            retval = True
        End If

        Return retval
    End Function

    Public Function isMountConnected() As Boolean
        Dim retval As Boolean = False

        If mount Is Nothing Then
            retval = False
        Else
            If mount.IsConnected = 0 Then
                retval = False
            Else
                retval = True
            End If
        End If

        Return retval
    End Function

    ''' <summary>
    ''' This function may not work with the EQMOD driver. It does not do so with the simulator.<br/>
    ''' If it doesn't I will need to use the Ascom driver directly.
    ''' </summary>
    ''' <param name="ra"></param>
    ''' <param name="dec"></param>
    ''' <returns></returns>
    Public Function syncMount(ra As Double, dec As Double) As Boolean
        Dim retval As Boolean = False

        If isMountpresentAndConnected() Then
            mount.Sync(ra, dec, "")
            retval = True
        Else
            retval = False
        End If

        Return retval
    End Function

    Public Function imageLinkUsingImage(fullImageLinkImagePath As String) As Boolean
        Dim retval As Boolean = False

        If imageLink Is Nothing Then
            imageLink = New TheSkyXLib.ImageLink
        End If
        If imageLinkResults Is Nothing Then
            imageLinkResults = New ImageLinkResults
        End If

        imageLink.pathToFITS = fullImageLinkImagePath
        imageLink.scale = 2.219 ' We set this to 2.219 as this the setting for my Atik
        imageLink.unknownScale = 1

        setDefaultAutomatedImageLinkSettings()

        Try
            imageLink.execute()
            retval = True
            Dim ra As Double = imageLinkResults.imageCenterRAJ2000
            Dim dec As Double = imageLinkResults.imageCenterDecJ2000

            ' imageLinkResults
        Catch e As Exception
            Dim str1 As String = imageLinkResults.errorCode
            Dim str2 As String = imageLinkResults.errorText
            retval = False
        End Try


        Return retval
    End Function

    Public Function isLastImageLinkVisible() As Boolean
        Return isRaAndDecVisible(getImageLinkResultsRAJ2000, getImageLinkResultsDecJ2000)
    End Function

    Public Function getImageLinkResultsRAJ2000() As Double
        Dim ra As Double

        If imageLinkResults IsNot Nothing Then
            ra = imageLinkResults.imageCenterRAJ2000
        Else
            ra = -1
        End If

        Return ra
    End Function

    Public Function getImageLinkResultsDecJ2000() As Double
        Dim dec As Double

        If imageLinkResults IsNot Nothing Then
            dec = imageLinkResults.imageCenterDecJ2000
        Else
            dec = -1
        End If

        Return dec
    End Function

    Public Function isRaAndDecVisible(ra As Double, dec As Double) As Boolean
        Dim visible As Boolean = False

        If skyUtils Is Nothing Then
            skyUtils = New sky6Utils
        End If

        skyUtils.ConvertRADecToAzAlt(ra, dec)
        Dim az As Double = skyUtils.dOut0
        Dim alt As Double = skyUtils.dOut1

        If alt > 0 Then
            visible = True
        End If

        Return visible
    End Function

    Public Function findObject(obj As String) As Boolean
        Dim objectFound As Boolean = True

        If starChart Is Nothing Then
            starChart = New TheSkyXLib.sky6StarChart()
        End If
        If astroTargetInformation Is Nothing Then
            astroTargetInformation = New sky6ObjectInformation
        End If

        Try
            starChart.Find(obj)
        Catch e As Exception
            objectFound = False
            Dim s As String = e.Message ' is 'Object not found'
            If s.Contains("Object not found") Then
                s = "bob"
            End If
        End Try

        'Sk6ObjectInformationProperty.sk6ObjInfoProp_TRANSIT_TIME
        'astroTargetInformation.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_TRANSIT_TIME) ' h.mmmmmm
        'Dim out As String = astroTargetInformation.ObjInfoPropOut.ToString()

        'astroTargetInformation.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_RISE_TIME) ' h.mmmmmm
        'out = astroTargetInformation.ObjInfoPropOut.ToString()

        'astroTargetInformation.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_SET_TIME) ' h.mmmmmm
        'out = astroTargetInformation.ObjInfoPropOut.ToString()

        'Dim timDbl As Double
        'Double.TryParse(out, timDbl)
        'timDbl = timDbl - 7
        'timDbl = timDbl * 60


        'astroTargetInformation.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_ACTIVE)
        'out = astroTargetInformation.ObjInfoPropOut.ToString()

        'astroTargetInformation.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_ALT)
        'out = astroTargetInformation.ObjInfoPropOut.ToString()

        'astroTargetInformation.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_RISE_SET_INFO)
        'out = astroTargetInformation.ObjInfoPropOut.ToString()

        'objectFound = False

        Return objectFound
    End Function

    Private Function getCurrentObjectRa() As Double
        Dim raString As String
        Dim ra As Double
        astroTargetInformation.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_RA_NOW)
        raString = astroTargetInformation.ObjInfoPropOut.ToString
        Double.TryParse(raString, ra)

        Return ra
    End Function

    Private Function getCurrentObjectDec() As Double
        Dim decString As String
        Dim dec As Double
        astroTargetInformation.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_DEC_NOW)
        decString = astroTargetInformation.ObjInfoPropOut.ToString
        Double.TryParse(decString, dec)

        Return dec
    End Function

    Public Sub setRaAndDec(ra As Double, dec As Double)
        tgtRa = ra
        tgtDec = dec
    End Sub

    Public Sub setRaAndDecFromObject()
        tgtRa = getCurrentObjectRa()
        tgtDec = getCurrentObjectDec()
    End Sub

    Public Sub setRaAndDecFromImageLink()
        tgtRa = getImageLinkResultsRAJ2000()
        tgtDec = getImageLinkResultsDecJ2000()
    End Sub

    Public Function isCurrentdObjectVisible() As Boolean
        Dim isObjectVisible As Boolean = False

        If astroTargetInformation Is Nothing Then
            isObjectVisible = False
        Else
            astroTargetInformation.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_ALT)
            Dim out As String = astroTargetInformation.ObjInfoPropOut.ToString()
            Dim tgtAltitude As Double
            Double.TryParse(out, tgtAltitude)

            If tgtAltitude > 0 Then
                isObjectVisible = True
            End If
        End If

        Return isObjectVisible
    End Function


    Sub setDefaultAutomatedImageLinkSettings()

        If automatedImageLinkSettings Is Nothing Then
            automatedImageLinkSettings = New AutomatedImageLinkSettings
        End If

        automatedImageLinkSettings.exposureTimeAILS = 10
        automatedImageLinkSettings.filterNameAILS = ""
        automatedImageLinkSettings.positionAngle = 0
        automatedImageLinkSettings.fovsToSearch = 300
        automatedImageLinkSettings.imageScale = 2.2
        automatedImageLinkSettings.retries = 2

    End Sub

    Sub clearDefaultAutomatedImageLinkSettings()
        automatedImageLinkSettings = Nothing
    End Sub

    Public Sub setMountPositionToNoPosition()
        mountEastWest = MountPointingPosition.noPosition
    End Sub

    Public Sub setMountPositionToEast()
        mountEastWest = MountPointingPosition.mountEast
    End Sub

    Public Sub setMountPositionToWest()
        mountEastWest = MountPointingPosition.mountWest
    End Sub

    Public Sub setMountPointingPosition()
        mount.GetAzAlt()
        Dim azimuth As Double = mount.dAz
        Dim altitide As Double = mount.dAlt

        If azimuth >= 0 And azimuth <= 180 Then
            setMountPositionToEast()
        Else
            setMountPositionToWest()
        End If

        'mount.GetRaDec()
        'Dim ascension As Double = mount.dRa
        'Dim declination As Double = mount.dDec

    End Sub

    Public Function updateMountPointingPositionAndReturnMeridianFlip() As Boolean
        Dim retval As Boolean = False

        Dim prevMountEastWest As MountPointingPosition = mountEastWest

        setMountPointingPosition()

        If prevMountEastWest = MountPointingPosition.noPosition Then
            prevMountEastWest = mountEastWest
        End If

        If prevMountEastWest = mountEastWest Then
            retval = False
        Else
            retval = True
        End If

        Return retval
    End Function

    Public Function closedLoopSlewToMountPosition() As Boolean
        Dim retval As Boolean = True

        mount.GetRaDec()
        retval = closedLoopSlewToPosition(mount.dRa, mount.dDec)

        Return retval
    End Function

    Public Function closedLoopSlewToPosition(ra As Double, dec As Double) As Boolean
        Dim retval As Boolean = False
        Dim localRa As Double
        Dim localDec As Double
        Dim continueLoop As Boolean = True

        Do
            retval = slewMount(ra, dec, "")

            If retval Then
                retval = takeAnImageSynchronouslyImageLinkAndSyncMount()
            Else
                continueLoop = False
            End If

            If retval Then
                mount.GetRaDec()
                localRa = mount.dRa
                localDec = mount.dDec

                skyUtils.ComputeAngularSeparation(ra, dec, mount.dRa, mount.dDec)
                Dim dSep As Double = skyUtils.dOut0

                If dSep < CLSUntilArcSecs Then
                    continueLoop = False
                End If

            Else
                continueLoop = False
            End If
        Loop While continueLoop

        Return retval
    End Function

    Public Function closedLoopSlewToTarget() As Boolean
        Dim retval As Boolean = True
        Dim retryCLS As Boolean = True
        Dim numberOfTries As Integer = 10
        Dim lastAngularSeperation As Double = 500

        Do
            retryCLS = slewMount(tgtRa, tgtDec, "")

            If retryCLS Then
                retryCLS = takeAnImageSynchronouslyImageLinkAndSyncMount()
            End If

            If retryCLS Then
                mount.GetRaDec()

                skyUtils.ComputeAngularSeparation(tgtRa, tgtDec, mount.dRa, mount.dDec)
                If skyUtils.dOut0 < 1 Then ' we need to define how close we need to be
                    retryCLS = False
                ElseIf skyUtils.dOut0 > lastAngularSeperation Then
                    ' We are further away, abort
                    retryCLS = False
                    retval = False
                ElseIf skyUtils.dOut0 < lastAngularSeperation Then
                    ' We are closer but not close enough, decrement counter
                    numberOfTries -= 1
                    If numberOfTries = 0 Then
                        retryCLS = False
                        retval = False
                    End If
                End If
            End If
        Loop While retryCLS

        Return retval
    End Function

    Public Function takeAnImageSynchronouslyImageLinkAndSyncMount() As Boolean
        Dim retval As Boolean = False

        retval = takeAnImageSynchronously()

        If retval Then
            attachCurrentImage()

            If imageLinkUsingImage(currentImage.Path) Then
                syncMount(imageLinkResults.imageCenterRAJ2000, imageLinkResults.imageCenterDecJ2000)
            Else
                retval = False
            End If
        End If

        Return retval
    End Function
    Public Sub testFunction()
        Dim ra1 As Double
        Dim dec1 As Double
        Dim ra2 As Double
        Dim dec2 As Double

        Dim file1 As String = "C:\Users\murph\source\repos\memurphybemengsc\TheSkyXController1\M1_Ha_1x1_300.000secs_Image_Drift_00002871.fit"

        imageLinkUsingImage(file1)

        attachImage(file1)
        ra1 = getAverageEllipticityForCurrentImage()
        ra2 = getAverageFWHMForCurrentImage()
        setCurrentImagetoNothing()


        'C:\Users\murph\Source\Repos\memurphybemengsc\TheSkyXController1\Leo_Triplet_20200415.fit
        Dim file2 As String = "C:\Users\murph\Source\Repos\memurphybemengsc\TheSkyXController1\Leo_Triplet_20200415.fit"
        attachImage(file2)

        dec1 = getAverageEllipticityForCurrentImage()
        dec2 = getAverageFWHMForCurrentImage()
        setCurrentImagetoNothing()

        'C:\Users\murph\Source\Repos\memurphybemengsc\TheSkyXController1\M 27_OK_1x1_120.000secs_Lum_Light_00000815.fit
        Dim file3 As String = "C:\Users\murph\source\repos\memurphybemengsc\TheSkyXController1\M 27_OK_1x1_120.000secs_Lum_Light_00000815.fit"
        attachImage(file3)

        dec1 = getAverageEllipticityForCurrentImage()
        dec2 = getAverageFWHMForCurrentImage()
        setCurrentImagetoNothing()

        Dim file4 As String = "C:\Users\murph\source\repos\memurphybemengsc\TheSkyXController1\M51_000.fit"
        attachImage(file4)

        dec1 = getAverageEllipticityForCurrentImage()
        dec2 = getAverageFWHMForCurrentImage()
        setCurrentImagetoNothing()

        'findObject("M13")
        'ra1 = getCurrentObjectRa()
        'dec1 = getCurrentObjectDec()
        'slewMount(ra1, dec1, "")

        'findObject("eta her")
        'ra2 = getCurrentObjectRa()
        'dec2 = getCurrentObjectDec()
        'slewMount(ra2, dec2, "")

        'skyUtils = New sky6Utils
        'skyUtils.ComputeAngularSeparation(ra1, dec1, ra2, dec2)
        'Dim dSepInDecimalDegrees As Double = skyUtils.dOut0


        'closedLoopSlewToMountPosition()
        'isMountPresent()
        'isCameraConnected()
        'takeAnImageSynchronously()
        'attachCurrentImage()


        'If imageLinkUsingImage(currentImage.Path) Then
        '    syncMount(imageLinkResults.imageCenterRAJ2000, imageLinkResults.imageCenterDecJ2000)
        'End If

        'currentImage.Close()

        'Dim s As String
    End Sub

    Public Sub saveCurrentImageToImageFolder()
        'currentImage.Path = getImageFolder()
        'currentImage.Save()
    End Sub

    Public Function convertRA(ra As String) As Double
        Dim retval As Double

        If Me.skyUtils Is Nothing Then
            skyUtils = New sky6Utils
        End If

        skyUtils.ConvertStringToRA(ra)
        retval = skyUtils.dOut0

        Return retval
    End Function

    Public Function convertDec(dec As String) As Double
        Dim retval As Double

        If Me.skyUtils Is Nothing Then
            skyUtils = New sky6Utils
        End If

        skyUtils.ConvertStringToDec(dec)
        retval = skyUtils.dOut0

        Return retval
    End Function

End Class
