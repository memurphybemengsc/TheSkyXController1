Public Class EnterRaAndDec
    Private Sub BtnEnter_Click(sender As Object, e As EventArgs) Handles BtnEnter.Click
        Close()
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
        raDecimal = raDecimal - hour
        raDecimal = raDecimal * 60
        Dim min As Integer = Math.Floor(raDecimal)
        raDecimal = raDecimal - min
        raDecimal = raDecimal * 60
        Dim second As Decimal = raDecimal

        NumUdRaHour.Value = hour
        NumUdRaMin.Value = min
        NumUdRaSec.Value = second
    End Sub

    Private Sub NumUdDecDeg_ValueChanged(sender As Object, e As EventArgs) Handles NumUdDecDeg.ValueChanged
        Dim declinationIsPositice As Boolean = True

        Dim degreeAsDecimal As Double = NumUdDecDeg.Value
        If NumUdDecDeg.Value < 0 Then
            declinationIsPositice = False
            degreeAsDecimal = degreeAsDecimal * -1
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
            degreeAsDecimal = degreeAsDecimal * -1
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
            degreeAsDecimal = degreeAsDecimal * -1
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
        decDecimal = decDecimal - degree
        decDecimal = decDecimal * 60

        Dim minute As Integer = Math.Floor(decDecimal)
        decDecimal = decDecimal - minute
        decDecimal = decDecimal * 60

        Dim seconds As Decimal = decDecimal

        If Not declinationIsPositice Then
            degree = degree * -1
        End If

        NumUdDecDeg.Value = degree
        NumUdDecMin.Value = minute
        NumUdDecSec.Value = seconds

    End Sub
End Class