Imports System.Collections
Imports System.IO
Imports System.Text

Public Class FitsKeyValues
    Implements IComparable(Of FitsKeyValues)

    Private Const imageTypeKeyName As String = "PICTTYPE" ' 1 (Light), 2 (Bias), 3 (Dark), 4 (Flat)
    Private Const xBinningKeyName As String = "XBINNING"
    Private Const yBinningKeyName As String = "YBINNING"
    Private Const focusPositionKeyName As String = "FOCPOS"
    Private Const filterKeyName As String = "FILTER"
    Private Const exposureKeyName As String = "EXPTIME"
    Private Const imageRAKeyName As String = "OBJCTRA"
    Private Const imageDECKeyName As String = "OBJCTDEC"
    Private Const imageObjectNameKeyName As String = "OBJECT"

    Private imageTypeValue As String
    Private xBinningValue As String
    Private yBinningValue As String
    Private focusPositionValue As String
    Private filterValue As String
    Private exposureTimeValue As String
    Private imageRAValueString As String
    Private imageDECValueString As String
    Private imageRAValue As Double
    Private imageDECValue As Double
    Private imageObjectNameValue As String

    Public Sub New()
        imageTypeValue = ""
        xBinningValue = ""
        yBinningValue = ""
        focusPositionValue = ""
        filterValue = ""
        exposureTimeValue = ""
        imageRAValue = Double.NaN
        imageDECValue = Double.NaN
        imageObjectNameValue = ""
    End Sub

    Public Property ImageType() As String
        Get
            Return imageTypeValue
        End Get
        Set(value As String)
            imageTypeValue = value
        End Set
    End Property

    Public Property XBinning() As String
        Get
            Return xBinningValue
        End Get
        Set(value As String)
            xBinningValue = value
        End Set
    End Property

    Public Property YBinning() As String
        Get
            Return yBinningValue
        End Get
        Set(value As String)
            yBinningValue = value
        End Set
    End Property

    Public Property FocusPosition() As String
        Get
            Return focusPositionValue
        End Get
        Set(value As String)
            focusPositionValue = value
        End Set
    End Property

    Public Property Filter() As String
        Get
            Return filterValue
        End Get
        Set(value As String)
            filterValue = value
        End Set
    End Property

    Public Property ExposureTime() As String
        Get
            Return exposureTimeValue
        End Get
        Set(value As String)
            exposureTimeValue = value
        End Set
    End Property

    Public Property imageRA() As Double
        Get
            Return imageRAValue
        End Get
        Set(value As Double)
            imageRAValue = value
        End Set
    End Property

    Public Property imageDEC() As Double
        Get
            Return imageDECValue
        End Get
        Set(value As Double)
            imageDECValue = value
        End Set
    End Property

    Public Property imageObjectName() As String
        Get
            Return imageObjectNameValue
        End Get
        Set(value As String)
            imageObjectNameValue = value
        End Set
    End Property

    Public ReadOnly Property isLightFrame() As Boolean
        Get
            If imageTypeValue = "1" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property isPopulated() As Boolean
        Get
            If imageTypeValue <> "" And exposureTimeValue <> "" And filterValue <> "" And focusPositionValue <> "" And xBinningValue <> "" And YBinning <> "" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property



    Public ReadOnly Property SortKey() As String
        Get
            Return imageTypeValue & "_" & xBinningValue & "_" & yBinningValue & "_" & focusPositionValue & "_" & exposureTimeValue & "_" & filterValue
        End Get
    End Property

    Public Function CompareTo(other As FitsKeyValues) As Integer Implements IComparable(Of FitsKeyValues).CompareTo
        Return Me.SortKey().CompareTo(other.SortKey())
    End Function

    Public Sub Copy(otherFitsSummary As FitsKeyValues)
        Me.ExposureTime = otherFitsSummary.ExposureTime
        Me.Filter = otherFitsSummary.Filter
        Me.FocusPosition = otherFitsSummary.FocusPosition
        Me.ImageType = otherFitsSummary.ImageType
        Me.XBinning = otherFitsSummary.XBinning
        Me.YBinning = otherFitsSummary.YBinning
    End Sub

    Public Function clone() As FitsKeyValues
        Dim newFkv As New FitsKeyValues()
        newFkv.Copy(Me)
        Return newFkv
    End Function

    Public Function OutputReadableText() As String
        Dim readableText As String

        readableText = "Image Type = " & Me.ImageType & " xb = " & Me.XBinning & " yb = " & Me.YBinning & " filter = " & Me.Filter _
        & " focus position = " & Me.FocusPosition & " Exposure = " & Me.ExposureTime

        Return readableText
    End Function

    Public Sub populateKeyDataFromFile(file As String)
        Dim fitsHeadersInFile As New List(Of String)
        fitsHeadersInFile = getFITSHeadersForFile(file)

        For Each fitsHeader In fitsHeadersInFile
            Dim key As String = getKeyForFitsHeader(fitsHeader)
            Dim data As String = getDataForFitsHeaderAsString(fitsHeader)
            Dim dataDouble As String = getDataForFitsHeaderAsDouble(fitsHeader)

            If key = imageTypeKeyName Then
                imageTypeValue = data
            ElseIf key = xBinningKeyName Then
                xBinningValue = data
            ElseIf key = yBinningKeyName Then
                yBinningValue = data
            ElseIf key = focusPositionKeyName Then
                focusPositionValue = data
            ElseIf key = filterKeyName Then
                filterValue = data
            ElseIf key = exposureKeyName Then
                ExposureTime = data
            ElseIf key = imageRAKeyName Then
                imageRAValue = TheSkyXController.skyXFunctions.convertRA(data)
                imageRAValueString = data
            ElseIf key = imageDECKeyName Then
                imageDECValue = TheSkyXController.skyXFunctions.convertDec(data)
                imageDECValueString = data
            End If
        Next

    End Sub

    Private Function getFITSHeadersForFile(fileName As String) As List(Of String)
        Dim filestream As FileStream = Nothing
        Dim buffer(81) As Char
        Dim FITSList As New List(Of String)
        Dim alphabet As String
        Dim firstLine As Boolean = True

        Try
            filestream = New FileStream(fileName, FileMode.Open)
        Catch fnfex As FileNotFoundException
            FITSList = Nothing
        Catch ex As Exception
            FITSList = Nothing
        End Try

        If filestream IsNot Nothing Then
            Dim streamreader As New StreamReader(filestream)

            Do
                streamreader.ReadBlock(buffer, 0, 80)
                alphabet = New String(buffer)
                If firstLine Then
                    If alphabet.Substring(0, 6).ToUpper <> "SIMPLE" Then
                        Exit Do
                    End If
                    firstLine = False
                End If
                FITSList.Add(alphabet)
            Loop Until alphabet.Substring(0, 3) = "END"
            'Loop Until buffer(0) = "E" And buffer(1) = "N" And buffer(2) = "D"

            streamreader.Close()
            filestream.Close()
        End If

        Return FITSList
    End Function

    'Private Function buildFitsString(fitsHeaders As List(Of String)) As String

    '    Dim stringBuilder As New StringBuilder()

    '    stringBuilder.Append("PICTTYPE=")
    '    stringBuilder.Append(getDataForFitsHeader(getFITSHeader("PICTTYPE", fitsHeaders)))
    '    stringBuilder.Append("_")
    '    stringBuilder.Append("XBINNING=")
    '    stringBuilder.Append(getDataForFitsHeader(getFITSHeader("XBINNING", fitsHeaders)))
    '    stringBuilder.Append("_")
    '    stringBuilder.Append("YBINNING=")
    '    stringBuilder.Append(getDataForFitsHeader(getFITSHeader("YBINNING", fitsHeaders)))
    '    stringBuilder.Append("_")
    '    stringBuilder.Append("FOCPOS=")
    '    stringBuilder.Append(getDataForFitsHeader(getFITSHeader("FOCPOS", fitsHeaders)))
    '    stringBuilder.Append("_")
    '    stringBuilder.Append("FILTER=")
    '    stringBuilder.Append(getDataForFitsHeader(getFITSHeader("FILTER", fitsHeaders)))
    '    stringBuilder.Append("_")
    '    stringBuilder.Append("EXPTIME=")
    '    stringBuilder.Append(getDataForFitsHeader(getFITSHeader("EXPTIME", fitsHeaders)))

    '    Return stringBuilder.ToString

    'End Function

    'Private Function getFITSHeader(fitsHeader As String, fitsHeaders As List(Of String)) As String
    '    Dim retval As String = ""

    '    For Each header In fitsHeaders
    '        If header.ToString.StartsWith(fitsHeader) Then
    '            retval = header.ToString
    '            Exit For
    '        End If
    '    Next

    '    Return retval
    'End Function

    Private Function getKeyForFitsHeader(fitsHeader As String) As String
        Dim fitsKey As String = ""

        Try
            fitsKey = fitsHeader.Substring(0, fitsHeader.IndexOf("=")).Trim()
        Catch ex As Exception

        End Try

        Return fitsKey
    End Function

    Private Function getDataForFitsHeaderAsString(fitsHeader As String) As String
        Dim fitsData As String = ""
        If fitsHeader.Length >= 30 Then

            Try
                fitsData = fitsHeader.Substring(10, 20).Trim()
                fitsData = fitsData.Replace("'", "")
            Catch ex As Exception

            End Try
        End If

        Return fitsData
    End Function

    ''' <summary>
    ''' Return the fits vslue as a double. Will return Double.NAN if conversion fails.
    ''' </summary>
    ''' <remarks></remarks>

    Private Function getDataForFitsHeaderAsDouble(fitsheader As String) As Double
        Dim fitsDataString As String
        Dim fitsDataDouble As Double

        fitsDataString = getDataForFitsHeaderAsString(fitsheader)

        If Not Double.TryParse(fitsDataString, fitsDataDouble) Then
            fitsDataDouble = Double.NaN ' Set an invalid value
        End If

        Return fitsDataDouble
    End Function

    Public Function isRAandDECPresent() As Boolean
        Dim retval As Boolean = False

        If Double.IsNaN(imageRAValue) Or Double.IsNaN(imageDECValue) Then
            retval = False
        Else
            retval = True
        End If

        Return retval
    End Function
End Class
