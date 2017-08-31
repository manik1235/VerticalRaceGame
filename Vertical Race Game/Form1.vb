Imports Vertical_Race_Game

Public Class MainForm
    Private Structure PlayerInfoClass
        Structure PlayerControls
            Structure PlayerKeys
                Private _isDown As Boolean
                Private _defaultValue As Integer
                Private _value As Integer

                Public Property IsDown As Boolean
                    Get
                        Return _isDown
                    End Get
                    Set(value As Boolean)
                        _isDown = value
                    End Set
                End Property

                Public Property DefaultValue As Integer
                    Get
                        Return _defaultValue
                    End Get
                    Set(value As Integer)
                        _defaultValue = value
                    End Set
                End Property

                Public Property Value As Integer
                    Get
                        Return _value
                    End Get
                    Set(value As Integer)
                        _value = value
                    End Set
                End Property
            End Structure


            Dim _keyMoveLeft As PlayerKeys
            Private _keyMoveRight As PlayerKeys
            Private _keyAccel As PlayerKeys
            Private _keyBrake As PlayerKeys


            Private _v As Double ' Current Velocity (probably in pixels/tick ?)
            Private _a As Double ' Current Acceleration (probably in pixels/tick^2 ?)
            Private _x As Double ' Current x (horz) position of the player vehicle
            Private _rx As Double ' Current x (horz) position of the player vehicle relative to the track segment
            Private _y As Double ' Current y (vert) position of the player vehicle relative to the track segment
            Private _ry As Double ' Current y (vert) position of the player vehicle relative to the track segment
            Private _maxV As Double ' Max Velocity allowed, same units as above
            Private _maxA As Double ' Max Acceleration allowed, same units as above
            Private _propertiesLocked As Boolean ' If true, the other properties will reject changes, probably silently


            Private _Ppx As Double 'Auto generated for the property?

            'Private _Ppx As Double = 0
            'Property Ppx As Double
            ' Get
            'Return Ppx1
            'End Get
            'Set(value As Double)
            '       Ppx1 = value
            'End Set
            'End Property

            Public Property Ppx1 As Double
                Get
                    Return _Ppx
                End Get
                Set(value As Double)
                    _Ppx = value
                End Set
            End Property

            Public Property MaxA As Double
                Get
                    Return _maxA
                End Get
                Set(value As Double)
                    _maxA = value
                End Set
            End Property

            Public Property V As Double
                Get
                    Return _v
                End Get
                Set(value As Double)
                    _v = value
                End Set
            End Property

            Public Property A As Double
                Get
                    Return _a
                End Get
                Set(value As Double)
                    _a = value
                End Set
            End Property

            Public Property X As Double
                Get
                    Return _x
                End Get
                Set(value As Double)
                    _x = value
                End Set
            End Property

            Public Property Rx As Double
                Get
                    Return _rx
                End Get
                Set(value As Double)
                    _rx = value
                End Set
            End Property

            Public Property Y As Double
                Get
                    Return _y
                End Get
                Set(value As Double)
                    _y = value
                End Set
            End Property

            Public Property Ry As Double
                Get
                    Return _ry
                End Get
                Set(value As Double)
                    _ry = value
                End Set
            End Property

            Public Property MaxV As Double
                Get
                    Return _maxV
                End Get
                Set(value As Double)
                    _maxV = value
                End Set
            End Property

            Public Property KeyMoveLeft As PlayerKeys
                Get
                    Return _keyMoveLeft
                End Get
                Set(value As PlayerKeys)
                    _keyMoveLeft = value
                End Set
            End Property

            Public Property KeyMoveRight As PlayerKeys
                Get
                    Return _keyMoveRight
                End Get
                Set(value As PlayerKeys)
                    _keyMoveRight = value
                End Set
            End Property

            Public Property KeyAccel As PlayerKeys
                Get
                    Return _keyAccel
                End Get
                Set(value As PlayerKeys)
                    _keyAccel = value
                End Set
            End Property

            Public Property KeyBrake As PlayerKeys
                Get
                    Return _keyBrake
                End Get
                Set(value As PlayerKeys)
                    _keyBrake = value
                End Set
            End Property

            Public Property PropertiesLocked As Boolean
                Get
                    Return _propertiesLocked
                End Get
                Set(value As Boolean)
                    _propertiesLocked = value
                End Set
            End Property
        End Structure

        Friend P1 As PlayerControls
        Friend P2 As PlayerControls

    End Structure

    Dim TickCounter As Integer

    Dim PreviewKeyDownCounter As Integer
    Dim KeyDownCounter As Integer
    Dim KeyPressCounter As Integer
    Dim KeyUpCounter As Integer

    Dim MyPlayers As PlayerInfoClass



    Private Sub UpdateDebugDisplay()
        ' Player1
        Label8.Text = MyPlayers.P1.KeyAccel.IsDown
        Label7.Text = MyPlayers.P1.KeyBrake.IsDown
        Label6.Text = MyPlayers.P1.KeyMoveLeft.IsDown
        Label5.Text = MyPlayers.P1.KeyMoveRight.IsDown
        ' Player2
        Label12.Text = MyPlayers.P2.KeyAccel.IsDown
        Label11.Text = MyPlayers.P2.KeyBrake.IsDown
        Label10.Text = MyPlayers.P2.KeyMoveLeft.IsDown
        Label9.Text = MyPlayers.P2.KeyMoveRight.IsDown
    End Sub

    Private Sub InitializeKeyboardSettings()
        ' Set the initial values for the player's keyboard controls

        ' Player 1 default controls
        With MyPlayers.P1
            .KeyAccel.DefaultValue = Keys.W
            .KeyAccel.Value = Keys.W
            .KeyAccel.IsDown = False
            .KeyBrake.DefaultValue = Keys.S
            .KeyBrake.Value = Keys.S
            .KeyBrake.IsDown = False
            .KeyMoveLeft.DefaultValue = Keys.A
            .KeyMoveLeft.Value = Keys.A
            .KeyMoveLeft.IsDown = False
            .KeyMoveRight.DefaultValue = Keys.D
            .KeyMoveRight.Value = Keys.D
            .KeyMoveRight.IsDown = False
        End With

        ' Player 2 default controls
        With MyPlayers.P2
            .KeyAccel.DefaultValue = Keys.Up
            .KeyAccel.Value = Keys.Up
            .KeyAccel.IsDown = False
            .KeyBrake.DefaultValue = Keys.Down
            .KeyBrake.Value = Keys.Down
            .KeyBrake.IsDown = False
            .KeyMoveLeft.DefaultValue = Keys.Left
            .KeyMoveLeft.Value = Keys.Left
            .KeyMoveLeft.IsDown = False
            .KeyMoveRight.DefaultValue = Keys.Right
            .KeyMoveRight.Value = Keys.Right
            .KeyMoveRight.IsDown = False
        End With

    End Sub

    Private Sub InitializePlayerSettings()
        ' Set the initial values for the player's properties

        ' Player 1 
        With MyPlayers.P1
            .Ppx1 = 3.01

        End With

        MsgBox(MyPlayers.P1.Ppx1)

        ' Player 2 
        With MyPlayers.P2
            .KeyAccel.DefaultValue = Keys.Up
            .KeyAccel.Value = Keys.Up
            .KeyAccel.IsDown = False
            .KeyBrake.DefaultValue = Keys.Down
            .KeyBrake.Value = Keys.Down
            .KeyBrake.IsDown = False
            .KeyMoveLeft.DefaultValue = Keys.Left
            .KeyMoveLeft.Value = Keys.Left
            .KeyMoveLeft.IsDown = False
            .KeyMoveRight.DefaultValue = Keys.Right
            .KeyMoveRight.Value = Keys.Right
            .KeyMoveRight.IsDown = False
        End With
    End Sub

    Private Sub TrackTimer_Tick(sender As Object, e As EventArgs) Handles TrackTimer.Tick

        ' Display the debug info for player keypresses
        UpdateDebugDisplay()



        ' Increase the tick counter, restart if at 1000. This allows things to happen less finely grained
        If TickCounter < 999 Then
            TickCounter += 1
        Else
            TickCounter = 0
        End If

        ' Move the tracks down every tick, if the car is accelerating
        MoveTrackRoot()


        ' Relocate Tracks A or B if they move below the panel's border
        AdjustTrackSegments()


    End Sub

    Private Sub MoveTrackRoot()
        ' Move the tracks down every tick, if the car is accelerating
        If MyPlayers.P1.KeyAccel.IsDown Then
            If TickCounter Mod 1 = 0 Then
                MoveTrack(LeftTrackPictureBoxA, 1)
                MoveTrack(LeftTrackPictureBoxB, 1)
            End If
        End If

        If MyPlayers.P2.KeyAccel.IsDown Then
            If TickCounter Mod 1 = 0 Then
                MoveTrack(RightTrackPictureBoxA, 1)
                MoveTrack(RightTrackPictureBoxB, 1)
            End If
        End If
    End Sub

    Private Sub AdjustTrackSegments()
        ' Relocate Tracks A or B if they move below the panel's border

        ' Left Track
        If LeftTrackPictureBoxA.Top > LeftRaceBackgroundPanel.Height Then
            LeftTrackPictureBoxA.Top = LeftTrackPictureBoxB.Top - LeftTrackPictureBoxA.Height
        End If
        If LeftTrackPictureBoxB.Top > LeftRaceBackgroundPanel.Height Then
            LeftTrackPictureBoxB.Top = LeftTrackPictureBoxA.Top - LeftTrackPictureBoxB.Height
        End If

        ' Right Track
        If RightTrackPictureBoxA.Top > RightRaceBackgroundPanel.Height Then
            RightTrackPictureBoxA.Top = RightTrackPictureBoxB.Top - RightTrackPictureBoxA.Height
        End If
        If RightTrackPictureBoxB.Top > RightRaceBackgroundPanel.Height Then
            RightTrackPictureBoxB.Top = RightTrackPictureBoxA.Top - RightTrackPictureBoxB.Height
        End If
    End Sub

    Private Sub MoveTrack(Track As PictureBox, VSpeed As Integer)
        ' Move the track based on the car's movement speed
        Track.Location = New Point(Track.Left, Track.Top + VSpeed)
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize everything
        InitializeEverything
    End Sub

    Private Sub InitializeEverything()

        ' Initialize the default keyboard control settings
        InitializeKeyboardSettings()

        ' Initialize the player settings
        InitializePlayerSettings()

        ' Initialize the Counters
        KeyPressCounter = 0
        KeyDownCounter = 0
        KeyUpCounter = 0
        TickCounter = 0

        ' Set Track A and B to the appropriate spots relative to each other
        ' Left Track
        With LeftTrackPictureBoxA
            .Left = 3
            .Top = LeftRaceBackgroundPanel.Height - .Height
        End With
        With LeftTrackPictureBoxB
            .Left = 3
            .Top = LeftTrackPictureBoxA.Top - .Height
        End With

        ' Right Track
        With RightTrackPictureBoxA
            .Left = 3
            .Top = RightRaceBackgroundPanel.Height - .Height
        End With
        With RightTrackPictureBoxB
            .Left = 3
            .Top = RightTrackPictureBoxA.Top - .Height
        End With
    End Sub

    Private Sub LeftP1CarPictureBox_Click(sender As Object, e As EventArgs) Handles LeftP1CarPictureBox.Click

    End Sub



    Private Sub MainForm_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        PreviewKeyDownCounter += 1
        'e.IsInputKey = True
        Label1.Text = "PreviewKeyDown: " & PreviewKeyDownCounter & " IsInputKey: " & e.IsInputKey & " KeyCode: " & e.KeyCode & " KeyData: " & e.KeyData & " KeyValue: " & e.KeyValue

    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        KeyDownCounter += 1
        e.Handled = True
        Label2.Text = "KeyDown: " & KeyDownCounter & " Handled: " & e.Handled & " KeyCode: " & e.KeyCode & " KeyData: " & e.KeyData & " KeyValue: " & e.KeyValue
        ' This module gets much more of the key presses, including arrows. it also gets repeated when a key is held down.

        'KeyCode is the best to use (instead of KeyData or KeyValue) per msdn forums

        ' Set the appropriate property to true when the corresponding key is pressed
        ' Player 1
        If e.KeyCode = MyPlayers.P1.KeyAccel.Value Then MyPlayers.P1.KeyAccel.isDown = True
        If e.KeyCode = MyPlayers.P1.KeyBrake.Value Then MyPlayers.P1.KeyBrake.isDown = True
        If e.KeyCode = MyPlayers.P1.KeyMoveLeft.Value Then MyPlayers.P1.KeyMoveLeft.isDown = True
        If e.KeyCode = MyPlayers.P1.KeyMoveRight.Value Then MyPlayers.P1.KeyMoveRight.isDown = True
        ' Player 2
        If e.KeyCode = MyPlayers.P2.KeyAccel.Value Then MyPlayers.P2.KeyAccel.isDown = True
        If e.KeyCode = MyPlayers.P2.KeyBrake.Value Then MyPlayers.P2.KeyBrake.isDown = True
        If e.KeyCode = MyPlayers.P2.KeyMoveLeft.Value Then MyPlayers.P2.KeyMoveLeft.isDown = True
        If e.KeyCode = MyPlayers.P2.KeyMoveRight.Value Then MyPlayers.P2.KeyMoveRight.isDown = True





    End Sub

    Private Sub MainForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        KeyPressCounter += 1
        Label3.Text = "KeyPress: " & KeyPressCounter & " KeyChar: " & e.KeyChar & " " & " Handled: " & e.Handled

    End Sub

    Private Sub MainForm_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        KeyUpCounter += 1
        Label4.Text = "KeyUp: " & KeyUpCounter & " Handled: " & e.Handled & " KeyCode: " & e.KeyCode & " KeyData: " & e.KeyData & " KeyValue: " & e.KeyValue

        ' Set the appropriate property to false when the corresponding key is released
        ' Player 1
        If e.KeyCode = MyPlayers.P1.KeyAccel.Value Then MyPlayers.P1.KeyAccel.isDown = False
        If e.KeyCode = MyPlayers.P1.KeyBrake.Value Then MyPlayers.P1.KeyBrake.isDown = False
        If e.KeyCode = MyPlayers.P1.KeyMoveLeft.Value Then MyPlayers.P1.KeyMoveLeft.isDown = False
        If e.KeyCode = MyPlayers.P1.KeyMoveRight.Value Then MyPlayers.P1.KeyMoveRight.isDown = False
        ' Player 2
        If e.KeyCode = MyPlayers.P2.KeyAccel.Value Then MyPlayers.P2.KeyAccel.isDown = False
        If e.KeyCode = MyPlayers.P2.KeyBrake.Value Then MyPlayers.P2.KeyBrake.isDown = False
        If e.KeyCode = MyPlayers.P2.KeyMoveLeft.Value Then MyPlayers.P2.KeyMoveLeft.isDown = False
        If e.KeyCode = MyPlayers.P2.KeyMoveRight.Value Then MyPlayers.P2.KeyMoveRight.isDown = False

    End Sub

    Private Sub KeyBoardTesting()
        'My.Computer.Keyboard.
    End Sub

End Class
