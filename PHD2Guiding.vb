Imports System.IO
Imports System.Net.Sockets

Public Class PHD2Guiding
    Private tcpConnection As TcpClient
    Private networkStream As NetworkStream
    Private binReader As BinaryReader
    Private binWriter As BinaryWriter

    Private tcpPort = 4300
    Private ditherAmount As Byte

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ShowDialog() ' Show the form as a modal dialog so we pause until the dialog closes

        ' We have now set the port, Check PHD is running
        If createPHDConnection() Then
            'OK, we will have set the tcpConnection
        Else
            'PHD is not running so throw exception
            Throw New System.Exception("PHD is not running")
        End If

    End Sub


    ''' <summary>
    ''' Pause guiding. Camera exposures continue to loop if they are already looping. <br/><b>Response</b> 0.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_PAUSE() As Byte
        Get
            Return 1
        End Get
    End Property

    ''' <summary>
    ''' Resume guiding if it was paused, otherwise no effect. <br/><b>Response</b> 0.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_RESUME() As Byte
        Get
            Return 2
        End Get
    End Property

    ''' <summary>
    ''' Dither a random amount, up to +/- 0.5 x dither_scale. <br/><b>Response</b> Camera exposure time in seconds, but not less than 1.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_MOVE1() As Byte
        Get
            Return 3
        End Get
    End Property

    ''' <summary>
    ''' Dither a random amount, up to +/- 1.0 x dither_scale. <br/><b>Response</b> Camera exposure time in seconds, but not less than 1.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_MOVE2() As Byte
        Get
            Return 4
        End Get
    End Property

    ''' <summary>
    ''' Dither a random amount, up to +/- 2.0 x dither_scale. <br/><b>Response</b> Camera exposure time in seconds, but not less than 1.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_MOVE3() As Byte
        Get
            Return 5
        End Get
    End Property

    ''' <summary>
    ''' not currently implemented in PHD2. <br/><b>Response</b> 1.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_IMAGE() As Byte
        Get
            Return 6
        End Get
    End Property

    ''' <summary>
    ''' not currently implemented in PHD2. <br/><b>Response</b> 1.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_GUIDE() As Byte
        Get
            Return 7
        End Get
    End Property

    ''' <summary>
    ''' not currently implemented in PHD2. <br/><b>Response</b> 1.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_CAMCONNECT() As Byte
        Get
            Return 8
        End Get
    End Property

    ''' <summary>
    ''' not currently implemented in PHD2. <br/><b>Response</b> 1.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_CAMDISCONNECT() As Byte
        Get
            Return 9
        End Get
    End Property

    ''' <summary>
    ''' Request guide error distance. <br/><b>Response</b> The current guide error distance in units of 1/100 pixel. Values > 255 are reported as 255.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_REQDIST() As Byte
        Get
            Return 10
        End Get
    End Property


    ''' <summary>
    ''' not currently implemented in PHD2. <br/><b>Response</b> 1.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_REQFRAME() As Byte
        Get
            Return 11
        End Get
    End Property

    ''' <summary>
    ''' Dither a random amount, up to +/- 3.0 x dither_scale. <br/><b>Response</b> Camera exposure time in seconds, but not less than 1.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_MOVE4() As Byte
        Get
            Return 12
        End Get
    End Property

    ''' <summary>
    ''' Dither a random amount, up to +/- 4.0 x dither_scale. <br/><b>Response</b> Camera exposure time in seconds, but not less than 1.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_MOVE5() As Byte
        Get
            Return 13
        End Get
    End Property

    ''' <summary>
    ''' Auto-select a guide star. <br/><b>Response</b> 1 if a star was selected, 0 if not.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_AUTOFINDSTAR() As Byte
        Get
            Return 14
        End Get
    End Property

    ''' <summary>
    ''' Read 2 16-bit integers, x and y,from the socket and set the lock position to (x,y). <br/><b>Response</b> 0.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_SETLOCKPOSITION() As Byte
        Get
            Return 15
        End Get
    End Property

    ''' <summary>
    ''' Flip RA calibration data. <br/><b>Response</b> 1 if RA calibration data was flipped, 0 otherwise.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_FLIPRACAL() As Byte
        Get
            Return 16
        End Get
    End Property

    ''' <summary>
    ''' Get a value describing the state of PHD. <br/><b>Response</b> <br/>
    ''' 0: not paused, looping, or guiding<br/>
    ''' 1: capture active And star selected<br/>
    ''' 2: calibrating<br/>
    ''' 3: guiding And locked on star<br/>
    ''' 4: guiding but star lost<br/>
    ''' 100: paused<br/>
    ''' 101: looping but no star selected.<br/>
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_GETSTATUS() As Byte
        Get
            Return 17
        End Get
    End Property

    ''' <summary>
    ''' Stop looping exposures or guiding. <br/><b>Response</b> 0. Client should poll with MSG_GETSTATUS to check that looping/guiding has actually stopped.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_STOP() As Byte
        Get
            Return 18
        End Get
    End Property

    ''' <summary>
    ''' Start looping exposures. <br/><b>Response</b> 0 if request to start looping was accepted, non-zero otherwise (like when looping was already active). Client should poll with MSG_GETSTATUS to see if looping actually started.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_LOOP() As Byte
        Get
            Return 19
        End Get
    End Property

    ''' <summary>
    ''' Start guiding. <br/><b>Response</b> 0. Client should poll with MSG_GETSTATUS to see if guiding has actually started.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_STARTGUIDING() As Byte
        Get
            Return 20
        End Get
    End Property

    ''' <summary>
    ''' Get the current frame counter value. <br/><b>Response</b> 0 if not looping or guiding. Otherwise, the current frame counter value (capped at 255). The frame counter is incremented for each camera exposure when looping or guiding.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_LOOPFRAMECOUNT() As Byte
        Get
            Return 21
        End Get
    End Property

    ''' <summary>
    ''' Clear calibration data (force re-calibration). <br/><b>Response</b> 0.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_CLEARCAL() As Byte
        Get
            Return 22
        End Get
    End Property

    ''' <summary>
    ''' When the camera simulator is active, simulate a scope meridian flip. <br/><b>Response</b> 0.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_FLIP_SIM_CAMERA() As Byte
        Get
            Return 23
        End Get
    End Property

    ''' <summary>
    ''' De-select the currently selected guide star. If subframes are enabled, switch to full frames. This command should be sent before sending MSG_AUTOFINDSTAR to ensure a full frame is captured. For example, the following sequence could be used to select a guide star: MSG_STOP, MSG_DESELECT, MSG_LOOP, MSG_LOOPFRAMECOUNT, MSG_AUTOFINDSTAR. <br/><b>Response</b> 0.
    ''' </summary>
    ''' <remarks></remarks>
    Private ReadOnly Property MSG_DESELECT() As Byte
        Get
            Return 24
        End Get
    End Property

    Public Function SendMessage(message As Byte) As Byte
        Dim retval As Byte
        'Dim tc As TcpClient = New TcpClient()
        'Dim ns As NetworkStream
        'Dim br As BinaryReader
        'Dim bw As BinaryWriter
        '' Connect to server - Add IP address and port to the PHD form
        'tc.Connect(“127.0.0.1”, 4300)
        'ns = tc.GetStream
        'br = New BinaryReader(ns)
        'bw = New BinaryWriter(ns)

        ' Write a value to server 
        binWriter.Write(message)
        ' Read a value from server with message box 
        retval = binReader.ReadByte()
        'MsgBox("Read String " + retval.ToString)

        Return retval

    End Function

    ''' <summary>
    ''' Get a value describing the state of PHD. <br/><b>Response</b> <br/>
    ''' 0: not paused, looping, or guiding<br/>
    ''' 1: capture active And star selected<br/>
    ''' 2: calibrating<br/>
    ''' 3: guiding And locked on star<br/>
    ''' 4: guiding but star lost<br/>
    ''' 100: paused<br/>
    ''' 101: looping but no star selected.<br/>
    ''' </summary>
    ''' <remarks></remarks>
    Public Function getPHDStatus() As Byte
        Dim retval As Byte
        retval = SendMessage(Me.MSG_GETSTATUS)
        Return retval
    End Function

    ''' <summary>
    ''' Start looping exposures. <br/>
    ''' Will poll for 500ms to cehck looping has started.<br/>
    ''' <b>Response</b> True if looping started and false otherwise.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function startPHDLooping() As Boolean
        Dim retval As Boolean = False
        If SendMessage(Me.MSG_LOOP) <> 0 Then
            retval = False
        Else
            retval = isPHDLoopingButNoStarSelected()
        End If
        Return retval
    End Function

    ''' <summary>
    ''' Check PHD status for a certain number of milliseconds and return.<br/>
    ''' </summary>
    ''' <remarks></remarks>
    Private Function checkStatus(milliSecondTimeout As Integer) As Byte
        Dim status As Byte
        Dim startTime As Date = TimeOfDay()
        Dim sw As New Stopwatch
        sw.Start()
        Do
            status = SendMessage(Me.MSG_GETSTATUS)
        Loop Until sw.ElapsedMilliseconds > milliSecondTimeout

        sw.Stop()

        Return status
    End Function

    ''' <summary>
    ''' Check PHD status for a 100 milliseconds and return.<br/>
    ''' </summary>
    Public Function checkStatus() As Byte
        Return checkStatus(100)
    End Function

    ''' <summary>
    ''' Returns true if PHD is neither Paused, Looping or Guiding i.e. status 0.
    ''' </summary>
    Public Function isPHDNotPausedLoopingOrGuiding() As Boolean
        Dim retval As Boolean = False

        If checkStatus() = 0 Then
            retval = True
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Returns true if PHD is looping and a guide star has been selected i.e. status 1.
    ''' </summary>
    Public Function isPHDLoopingAndStarSelected() As Boolean
        Dim retval As Boolean = False

        If checkStatus() = 1 Then
            retval = True
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Returns true if PHD is calibrating i.e. status 2.
    ''' </summary>
    Public Function isPHDCalibrating() As Boolean
        Dim retval As Boolean = False

        If checkStatus() = 2 Then
            retval = True
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Returns true if PHD is guiding and locked on a star i.e. status 3.
    ''' </summary>
    Public Function isPHDGuidingAndLockedOnStar() As Boolean
        Dim retval As Boolean = False

        If checkStatus() = 3 Then
            retval = True
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Returns true if PHD is guiding but star lost i.e. status 4.
    ''' </summary>
    Public Function isPHDGuidingButStarLost() As Boolean
        Dim retval As Boolean = False

        If checkStatus() = 4 Then
            retval = True
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Returns true if PHD has paused guiding  i.e. status 100.
    ''' </summary>
    Public Function isPHDGuidingPaused() As Boolean
        Dim retval As Boolean = False

        If checkStatus() = 4 Then
            retval = True
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Returns true if PHD is looping but no star selected i.e. status 101.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function isPHDLoopingButNoStarSelected() As Boolean
        Dim retval As Boolean = False
        Dim status As Byte

        status = checkStatus()

        If status = 101 Then
            retval = True
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Auto-select a guide star. <br/>
    ''' <b>Response</b> true if a star was selected, false if not.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function selectGuideStar() As Boolean
        Dim retval As Boolean = False

        If SendMessage(Me.MSG_AUTOFINDSTAR) <> 1 Then
            retval = False
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Start PHD guiding.<br/>
    ''' Check if looping, start if not.<br/>
    ''' Check if Guide star selected, select if not.<br/>
    ''' Start guiding, return false if guiding does not start.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function startGuiding() As Boolean
        Dim retval As Boolean = False

        If isPHDNotPausedLoopingOrGuiding() Then
            startPHDLooping()
        End If

        If isPHDLoopingButNoStarSelected() Then
            selectGuideStar()
        End If

        SendMessage(Me.MSG_STARTGUIDING)
        If isPHDGuidingAndLockedOnStar() Then
            retval = True
        Else
            retval = False
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Stop looping exposures or guiding. <br/><b>Response</b> 0. Client should poll with MSG_GETSTATUS to check that looping/guiding has actually stopped.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function stopGuiding() As Byte
        Dim retval As Byte
        retval = SendMessage(Me.MSG_STOP)
        Return retval
    End Function

    ''' <summary>
    ''' Dither the mount.<br/>
    ''' 1 is 0.5 dither scale.<br/>
    ''' 2 is 1 by dither scale.<br/>
    ''' 3 is 2 by dither scale.<br/>
    ''' 4 is 3 by dither scale.<br/>
    ''' 5 is 4 by dither scale.<br/>
    ''' </summary>
    ''' <remarks></remarks>
    Public Function dither(amount As Byte) As Byte
        Dim retval As Byte
        If amount = 1 Then
            retval = SendMessage(Me.MSG_MOVE1)
        ElseIf amount = 2 Then
            retval = SendMessage(Me.MSG_MOVE2)
        ElseIf amount = 3 Then
            retval = SendMessage(Me.MSG_MOVE3)
        ElseIf amount = 4 Then
            retval = SendMessage(Me.MSG_MOVE4)
        ElseIf amount = 5 Then
            retval = SendMessage(Me.MSG_MOVE5)
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Check that we can connect to PHD and create the tcp connection, readers and writers<br/>
    ''' <b>Response</b>True is connection suceeded and false if not.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function createPHDConnection() As Boolean
        Dim isPHD2Running As Boolean = True

        'Dim tc As TcpClient = New TcpClient()
        tcpConnection = New TcpClient()
        Try
            tcpConnection.Connect(“127.0.0.1”, tcpPort)
            ' We have a connection so now setup readers and writers
            Me.networkStream = Me.tcpConnection.GetStream
            Me.binReader = New BinaryReader(networkStream)
            Me.binWriter = New BinaryWriter(networkStream)
        Catch ex As Exception
            isPHD2Running = False
        End Try

        Return isPHD2Running
    End Function

    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles BtnConnect.Click
        tcpPort = Me.NumUDTcpPort.Value
        Me.Hide()
    End Sub

    Public Sub ditherMount()
        dither(ditherAmount)
    End Sub

    ''' <summary>
    ''' Check dither is complete<br/>
    ''' Needs to be implemented
    ''' </summary>
    Public Function isDitherComplete() As Boolean
        Return True
    End Function
End Class