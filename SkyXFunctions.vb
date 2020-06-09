Imports System.Runtime.CompilerServices
Imports System.Runtime.ExceptionServices
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Serialization
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
    Private filterNames As List(Of String) = Nothing

    Public Sub New()
        'Create the SkyX object and check that Skyx is present and initialised
        connectToSkyXTest()
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
    End Sub

    Public Sub testFunction()
        If isFocuserConnected() Then
            MsgBox("Focuser is connected")
        Else
            MsgBox("Focuser is not  connected")
        End If

        If isFocuserPresent() Then
            MsgBox("Focuser is present")
        Else
            MsgBox("focuser is Not present")
        End If

        '        MsgBox("camera.focIsConnected " + camera.focIsConnected.ToString)

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
                Exit For
                filterNotFound = False
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

    Public Sub setImageFolder(imgFldr As String)
        imageFolder = imgFldr
    End Sub

    Public Function getImageFolder() As String
        Return imageFolder
    End Function

    Public Sub disconnect()
        disconnectFromCamera()
    End Sub

    Public Function setImageSettings(imageType As Integer, filter As String, exposure As Double, bx As Integer, by As Integer) As Boolean
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

    Public Function findObject(obj As String) As Boolean
        Dim objectFound As Boolean

        objectFound = False

        Return objectFound
    End Function

    Public Function slewTocurrentObject() As Boolean
        Dim success As Boolean = False
        Return success
    End Function
    Sub TakeImage()
        Dim tsxo = CreateObject(“TheSkyX.ccdsoftCamera”)
        Dim status = tsxo.Connect()

        Console.WriteLine("Status is " & status.ToString)
        tsxo.ExposureTime = 10
        ' takes two photos for some reason
        tsxo.Frame = 1 ' 1 = light, 2 = bias, 3 = dark, 4 = flat
        tsxo.ImageReduction = 0 ' enum  	ccdsoftImageReduction { cdNone, cdAutoDark, cdBiasDarkFlat }
        tsxo.AutoSaveOn = 1
        status = tsxo.TakeImage()
        tsxo.Disconnect()
        MsgBox(“Image Done”)
    End Sub

    Sub TakeImage1()
        Dim tsxo = New TheSkyXLib.ccdsoftCamera
        Dim status = tsxo.Connect()

        Console.WriteLine("Status is " & status.ToString)
        tsxo.ExposureTime = 10
        ' takes two photos for some reason
        tsxo.Frame = 1 ' 1 = light, 2 = bias, 3 = dark, 4 = flat
        tsxo.ImageReduction = 0 ' enum  	ccdsoftImageReduction { cdNone, cdAutoDark, cdBiasDarkFlat }
        tsxo.AutoSaveOn = 1
        status = tsxo.TakeImage()
        Dim focPos As Integer = tsxo.focPosition
        Dim fwPos As Integer = tsxo.FilterIndexZeroBased

        tsxo.Disconnect()
        MsgBox(“Image Done”)
    End Sub

    Sub FindTarget(target As String)
        Dim tsxs = CreateObject("TheSkyX.sky6StarChart")
        Dim status = tsxs.Find(target)
        Dim tsxo = CreateObject("TheSkyX.sky6ObjectInformation")
        'Console.WriteLine("enum is " & tsxo.Sk6ObjectInformationProperty.sk6ObjInfoProp_NAME1)
        tsxo.Index = 0
        Console.WriteLine("Number of objects found " & tsxo.Count)
        status = tsxo.Property(54)
        Dim tgtRA = tsxo.ObjInfoPropOut
        status = tsxo.Property(55)
        Dim tgtDec = tsxo.ObjInfoPropOut
        status = tsxo.Property(58)
        Dim tgtAZ = tsxo.ObjInfoPropOut
        status = tsxo.Property(59)
        Dim tgtALT = tsxo.ObjInfoPropOut
        Console.WriteLine("RA is " & tgtRA.ToString & " Dec is " & tgtDec.ToString)
        Console.WriteLine("ALT is " & tgtALT.ToString & " AZ is " & tgtAZ.ToString)
    End Sub

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

        If TheSkyXController.imageFileSequence.isCurrentImageALightFrame Then
            exposureType = ccdsoftImageFrame.cdLight
        End If

        setImageSettings(exposureType, filter, exposure, bx, by)

        Return retval
    End Function

    Public Function takeAnImageAsynchronously() As Boolean
        Dim retval As Boolean = True

        ' Set the camera to be asynchronous
        camera.Asynchronous = 1
        Try
            camera.TakeImage()
        Catch e As Exception
            retval = False
        End Try

        Return retval
    End Function

    Public Function isImagingInProgress() As Boolean
        Dim retval As Boolean = False

        ' Set the camera to be asynchronous
        If camera.IsExposureComplete = 1 Then
            retval = True
        End If

        Return retval
    End Function

End Class
