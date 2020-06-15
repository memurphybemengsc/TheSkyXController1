Imports ASCOM.DriverAccess

Public Class AscomUtilities
    Dim ascomChooser As ASCOM.Utilities.Chooser = Nothing
    Public myFilterWheel As ASCOM.DriverAccess.FilterWheel = Nothing
    Public myMount As ASCOM.DriverAccess.Telescope = Nothing

    Sub chooseAndConnectToFilterWheel()
        ascomChooser = New ASCOM.Utilities.Chooser
        ascomChooser.DeviceType = "FilterWheel"
        Dim fwChosen As String = ascomChooser.Choose()
        If fwChosen <> "" Then
            myFilterWheel = New ASCOM.DriverAccess.FilterWheel(fwChosen)
            myFilterWheel.Connected = True
        End If
    End Sub

    Sub chooseAndConnectToMount()
        If myMount Is Nothing Then

            ascomChooser = New ASCOM.Utilities.Chooser
            ascomChooser.DeviceType = "Telescope"
            Dim teleChosen As String = ascomChooser.Choose()
            If teleChosen <> "" Then
                myMount = New ASCOM.DriverAccess.Telescope(teleChosen)
                myMount.Connected = True
            End If

        End If
    End Sub

    Public Function filterWheelNames() As List(Of String)
        Dim filters As New List(Of String)
        For Each filter As String In myFilterWheel.Names
            filters.Add(filter)
        Next
        Return filters
    End Function

    Sub disconnect()
        myFilterWheel.Connected = False
        myFilterWheel.Dispose()
    End Sub

    Sub Ascom()
        ascomChooser = New ASCOM.Utilities.Chooser
        ascomChooser.DeviceType = "FilterWheel"
        Dim fwChosen As String = ascomChooser.Choose()
        myFilterWheel = New ASCOM.DriverAccess.FilterWheel(fwChosen)
        myFilterWheel.SetupDialog()
        myFilterWheel.Connected = True
        For Each filter As String In myFilterWheel.Names
            MsgBox("filter names " + filter)
        Next

        For Each action As Integer In myFilterWheel.FocusOffsets
            MsgBox("focus offsets " + action.ToString)
        Next

        For Each action As String In myFilterWheel.SupportedActions
            MsgBox("supported actions " + action.ToString)
        Next
    End Sub

    Public Function shouldWeFlipMount() As Boolean
        Dim retval As Boolean = False

        Dim sideOfPier As ASCOM.DeviceInterface.PierSide = myMount.SideOfPier

        If sideOfPier = sideOfPier.pierEast Then
            retval = False
        Else
            retval = True
        End If

        Return retval
    End Function

    Public Sub actionsSupportedByMount()

        For Each Action As String In myMount.SupportedActions
            MsgBox("Supported mount action " + Action)
        Next

    End Sub

End Class
