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
        Dim skyX As Boolean

        skyX = False

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
End Class
