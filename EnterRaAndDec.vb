Imports System.Windows.Forms.VisualStyles

Public Class EnterRaAndDec
    Private Sub BtnEnter_Click(sender As Object, e As EventArgs) Handles BtnEnter.Click
        If TxtName.Text.Trim = "" Then
            MsgBox("You must supply a name")
        Else
            ' Remove any occurence of Ra or Dec to avoid confusion
            Dim workString As String = TxtName.Text.ToUpper
            workString = workString.Replace(" RA: ", " ")
            workString = workString.Replace(" DEC: ", " ")
            ' Add to the list of targets
            TheSkyXController.AddToNextTarget("C " + workString.Trim + " Ra: " + NumUdRaDecimal.Value.ToString + " Dec: " + NumUdDecDecimal.Value.ToString)

            Close()
        End If
    End Sub

    Private Sub NumUdRaDeg_ValueChanged(sender As Object, e As EventArgs) Handles NumUdRaHour.ValueChanged
        ' Calculate the decimal version of the Hour/Min/Sec
        Dim hourAsDecimal As Double = NumUdRaHour.Value
        Dim minAsDecimal As Double = NumUdRaMin.Value / 60
        Dim secAsDecimal As Double = NumUdRaSec.Value / (60 * 60)

        NumUdRaDecimal.Value = hourAsDecimal + minAsDecimal + secAsDecimal
    End Sub

    Private Sub NumUdRaMin_ValueChanged(sender As Object, e As EventArgs) Handles NumUdRaMin.ValueChanged
        ' Calculate the decimal version of the Hour/Min/Sec
        Dim hourAsDecimal As Double = NumUdRaHour.Value
        Dim minAsDecimal As Double = NumUdRaMin.Value / 60
        Dim secAsDecimal As Double = NumUdRaSec.Value / (60 * 60)

        NumUdRaDecimal.Value = hourAsDecimal + minAsDecimal + secAsDecimal
    End Sub

    Private Sub NumUdRaSec_ValueChanged(sender As Object, e As EventArgs) Handles NumUdRaSec.ValueChanged
        ' Calculate the decimal version of the Hour/Min/Sec
        Dim hourAsDecimal As Double = NumUdRaHour.Value
        Dim minAsDecimal As Double = NumUdRaMin.Value / 60
        Dim secAsDecimal As Double = NumUdRaSec.Value / (60 * 60)

        NumUdRaDecimal.Value = hourAsDecimal + minAsDecimal + secAsDecimal
    End Sub

    Private Sub NumUdRaDecimal_ValueChanged(sender As Object, e As EventArgs) Handles NumUdRaDecimal.ValueChanged
        ' Calculate the Hour/Min/Sec version of the Decimal Ra
        Dim raDecimal As Double = NumUdRaDecimal.Value
        Dim hour As Integer = Math.Floor(raDecimal)
        raDecimal -= hour
        raDecimal *= 60
        Dim min As Integer = Math.Floor(raDecimal)
        raDecimal -= min
        raDecimal *= 60
        Dim second As Decimal = raDecimal

        NumUdRaHour.Value = hour
        NumUdRaMin.Value = min
        If second < NumUdRaSec.Maximum Then
            NumUdRaSec.Value = second
        Else
            NumUdRaSec.Value = NumUdRaSec.Maximum
        End If
    End Sub

    Private Sub NumUdDecDeg_ValueChanged(sender As Object, e As EventArgs) Handles NumUdDecDeg.ValueChanged
        Dim declinationIsPositice As Boolean = True

        Dim degreeAsDecimal As Double = NumUdDecDeg.Value
        If NumUdDecDeg.Value < 0 Then
            declinationIsPositice = False
            degreeAsDecimal *= -1
        End If

        Dim minuteAsDecimal As Double = NumUdDecMin.Value / 60
        Dim secondAsDecimal As Double = NumUdDecSec.Value / (60 * 60)

        If declinationIsPositice Then
            NumUdDecDecimal.Value = degreeAsDecimal + minuteAsDecimal + secondAsDecimal
        Else
            NumUdDecDecimal.Value = (degreeAsDecimal + minuteAsDecimal + secondAsDecimal) * -1
        End If
    End Sub

    Private Sub NumUdDecMin_ValueChanged(sender As Object, e As EventArgs) Handles NumUdDecMin.ValueChanged
        Dim declinationIsPositice As Boolean = True

        Dim degreeAsDecimal As Double = NumUdDecDeg.Value
        If NumUdDecDeg.Value < 0 Then
            declinationIsPositice = False
            degreeAsDecimal *= -1
        End If

        Dim minuteAsDecimal As Double = NumUdDecMin.Value / 60
        Dim secondAsDecimal As Double = NumUdDecSec.Value / (60 * 60)

        If declinationIsPositice Then
            NumUdDecDecimal.Value = degreeAsDecimal + minuteAsDecimal + secondAsDecimal
        Else
            NumUdDecDecimal.Value = (degreeAsDecimal + minuteAsDecimal + secondAsDecimal) * -1
        End If
    End Sub

    Private Sub NumUdDecSec_ValueChanged(sender As Object, e As EventArgs) Handles NumUdDecSec.ValueChanged
        Dim declinationIsPositice As Boolean = True

        Dim degreeAsDecimal As Double = NumUdDecDeg.Value
        If NumUdDecDeg.Value < 0 Then
            declinationIsPositice = False
            degreeAsDecimal *= -1
        End If

        Dim minuteAsDecimal As Double = NumUdDecMin.Value / 60
        Dim secondAsDecimal As Double = NumUdDecSec.Value / (60 * 60)

        If declinationIsPositice Then
            NumUdDecDecimal.Value = degreeAsDecimal + minuteAsDecimal + secondAsDecimal
        Else
            NumUdDecDecimal.Value = (degreeAsDecimal + minuteAsDecimal + secondAsDecimal) * -1
        End If
    End Sub

    Private Sub NumUdDecDecimal_ValueChanged(sender As Object, e As EventArgs) Handles NumUdDecDecimal.ValueChanged
        ' Calculate the Deg/Min/Sec version of the Decimal Dec
        Dim declinationIsPositice As Boolean = True
        Dim decDecimal As Double = NumUdDecDecimal.Value

        If decDecimal < 0 Then
            declinationIsPositice = False
            decDecimal = Math.Abs(decDecimal)
        End If

        Dim degree As Integer = Math.Floor(decDecimal)
        decDecimal -= degree
        decDecimal *= 60

        Dim minute As Integer = Math.Floor(decDecimal)
        decDecimal -= minute
        decDecimal *= 60

        Dim seconds As Decimal = decDecimal

        If Not declinationIsPositice Then
            degree *= -1
        End If

        NumUdDecDeg.Value = degree
        NumUdDecMin.Value = minute
        If seconds < NumUdDecSec.Maximum Then
            NumUdDecSec.Value = seconds
        Else
            NumUdDecSec.Value = NumUdDecSec.Maximum
        End If

    End Sub

    Public Shared Function ExtractRa(target As String) As Double
        Dim ra As Double
        Dim startRa As Double = target.IndexOf("Ra:")
        Dim startDec As Double = target.IndexOf("Dec:")
        Dim length As Double = startDec - (startRa + 3)
        ra = Double.Parse(target.Substring(startRa + 3, length))
        Return ra
    End Function

    Public Shared Function ExtractDec(target As String) As Double
        Dim dec As Double
        Dim startDec As Double = target.IndexOf("Dec:")
        Dim length As Double = target.Length - (startDec + 4)
        dec = Double.Parse(target.Substring(startDec + 4, length))
        Return dec
    End Function

    Public Shared Function ExtractName(target As String) As String
        Dim name As String
        name = target.Substring(0, target.IndexOf("Ra:"))
        Return name
    End Function
End Class