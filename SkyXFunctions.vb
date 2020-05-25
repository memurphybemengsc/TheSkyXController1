Public Class SkyXFunctions
    ' This class holds the functions to interact with TheSkyX
    Dim skyXVersion As String = ""
    Dim skyXObject As Object = vbNull
    Dim currentSkyObject As Object = vbNull

    Public Sub New()
        'Create the SkyX object and check that Skyx is present and initialised
    End Sub


    ' Add a method to check for image saturation

    Public Function isSkyXPresent() As Boolean
        Dim skyX As Boolean = False

        Dim tsxo As Object = Nothing

        Try
            tsxo = New TheSkyXLib.Application
        Catch ex As Exception

        End Try

        If tsxo IsNot Nothing Then
            skyXVersion = tsxo.version
            skyX = True
            MsgBox(“TSX Version: “ & skyXVersion)
        Else
            MsgBox(“SkyX is not present“)
        End If

        Return skyX
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


End Class
