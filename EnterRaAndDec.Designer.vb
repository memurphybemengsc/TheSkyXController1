﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnterRaAndDec
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnEnter = New System.Windows.Forms.Button()
        Me.NumUdRaHour = New System.Windows.Forms.NumericUpDown()
        Me.NumUdRaMin = New System.Windows.Forms.NumericUpDown()
        Me.NumUdRaSec = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumUdRaDecimal = New System.Windows.Forms.NumericUpDown()
        Me.NumUdDecDecimal = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumUdDecSec = New System.Windows.Forms.NumericUpDown()
        Me.NumUdDecMin = New System.Windows.Forms.NumericUpDown()
        Me.NumUdDecDeg = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtName = New System.Windows.Forms.TextBox()
        CType(Me.NumUdRaHour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUdRaMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUdRaSec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUdRaDecimal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUdDecDecimal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUdDecSec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUdDecMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUdDecDeg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnEnter
        '
        Me.BtnEnter.Location = New System.Drawing.Point(405, 199)
        Me.BtnEnter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnEnter.Name = "BtnEnter"
        Me.BtnEnter.Size = New System.Drawing.Size(100, 28)
        Me.BtnEnter.TabIndex = 0
        Me.BtnEnter.Text = "Enter"
        Me.BtnEnter.UseVisualStyleBackColor = True
        '
        'NumUdRaHour
        '
        Me.NumUdRaHour.Location = New System.Drawing.Point(199, 53)
        Me.NumUdRaHour.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumUdRaHour.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.NumUdRaHour.Name = "NumUdRaHour"
        Me.NumUdRaHour.Size = New System.Drawing.Size(55, 22)
        Me.NumUdRaHour.TabIndex = 1
        '
        'NumUdRaMin
        '
        Me.NumUdRaMin.Location = New System.Drawing.Point(277, 53)
        Me.NumUdRaMin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumUdRaMin.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.NumUdRaMin.Name = "NumUdRaMin"
        Me.NumUdRaMin.Size = New System.Drawing.Size(48, 22)
        Me.NumUdRaMin.TabIndex = 2
        '
        'NumUdRaSec
        '
        Me.NumUdRaSec.DecimalPlaces = 3
        Me.NumUdRaSec.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NumUdRaSec.Location = New System.Drawing.Point(345, 53)
        Me.NumUdRaSec.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumUdRaSec.Maximum = New Decimal(New Integer() {59999, 0, 0, 196608})
        Me.NumUdRaSec.Name = "NumUdRaSec"
        Me.NumUdRaSec.Size = New System.Drawing.Size(160, 22)
        Me.NumUdRaSec.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "RA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hour/Min/Sec"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 101)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Decimal"
        '
        'NumUdRaDecimal
        '
        Me.NumUdRaDecimal.DecimalPlaces = 6
        Me.NumUdRaDecimal.Increment = New Decimal(New Integer() {1, 0, 0, 393216})
        Me.NumUdRaDecimal.Location = New System.Drawing.Point(199, 98)
        Me.NumUdRaDecimal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumUdRaDecimal.Maximum = New Decimal(New Integer() {23999999, 0, 0, 393216})
        Me.NumUdRaDecimal.Name = "NumUdRaDecimal"
        Me.NumUdRaDecimal.Size = New System.Drawing.Size(160, 22)
        Me.NumUdRaDecimal.TabIndex = 8
        '
        'NumUdDecDecimal
        '
        Me.NumUdDecDecimal.DecimalPlaces = 6
        Me.NumUdDecDecimal.Increment = New Decimal(New Integer() {1, 0, 0, 393216})
        Me.NumUdDecDecimal.Location = New System.Drawing.Point(559, 98)
        Me.NumUdDecDecimal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumUdDecDecimal.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.NumUdDecDecimal.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.NumUdDecDecimal.Name = "NumUdDecDecimal"
        Me.NumUdDecDecimal.Size = New System.Drawing.Size(160, 22)
        Me.NumUdDecDecimal.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(555, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Declination"
        '
        'NumUdDecSec
        '
        Me.NumUdDecSec.DecimalPlaces = 3
        Me.NumUdDecSec.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NumUdDecSec.Location = New System.Drawing.Point(705, 53)
        Me.NumUdDecSec.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumUdDecSec.Maximum = New Decimal(New Integer() {59999, 0, 0, 196608})
        Me.NumUdDecSec.Name = "NumUdDecSec"
        Me.NumUdDecSec.Size = New System.Drawing.Size(160, 22)
        Me.NumUdDecSec.TabIndex = 13
        '
        'NumUdDecMin
        '
        Me.NumUdDecMin.Location = New System.Drawing.Point(637, 53)
        Me.NumUdDecMin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumUdDecMin.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.NumUdDecMin.Name = "NumUdDecMin"
        Me.NumUdDecMin.Size = New System.Drawing.Size(48, 22)
        Me.NumUdDecMin.TabIndex = 12
        '
        'NumUdDecDeg
        '
        Me.NumUdDecDeg.Location = New System.Drawing.Point(559, 53)
        Me.NumUdDecDeg.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumUdDecDeg.Maximum = New Decimal(New Integer() {89, 0, 0, 0})
        Me.NumUdDecDeg.Minimum = New Decimal(New Integer() {89, 0, 0, -2147483648})
        Me.NumUdDecDeg.Name = "NumUdDecDeg"
        Me.NumUdDecDeg.Size = New System.Drawing.Size(55, 22)
        Me.NumUdDecDeg.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 151)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Name"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(199, 151)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(665, 22)
        Me.TxtName.TabIndex = 17
        '
        'EnterRaAndDec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 242)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NumUdDecDecimal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumUdDecSec)
        Me.Controls.Add(Me.NumUdDecMin)
        Me.Controls.Add(Me.NumUdDecDeg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumUdRaDecimal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumUdRaSec)
        Me.Controls.Add(Me.NumUdRaMin)
        Me.Controls.Add(Me.NumUdRaHour)
        Me.Controls.Add(Me.BtnEnter)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "EnterRaAndDec"
        Me.Text = "EnterRaAndDec"
        CType(Me.NumUdRaHour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUdRaMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUdRaSec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUdRaDecimal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUdDecDecimal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUdDecSec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUdDecMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUdDecDeg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnEnter As Button
    Friend WithEvents NumUdRaHour As NumericUpDown
    Friend WithEvents NumUdRaMin As NumericUpDown
    Friend WithEvents NumUdRaSec As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents NumUdRaDecimal As NumericUpDown
    Friend WithEvents NumUdDecDecimal As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents NumUdDecSec As NumericUpDown
    Friend WithEvents NumUdDecMin As NumericUpDown
    Friend WithEvents NumUdDecDeg As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtName As TextBox
End Class
