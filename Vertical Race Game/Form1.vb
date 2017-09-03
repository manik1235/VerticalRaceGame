Imports Vertical_Race_Game

Public Class MainForm
    Structure PlayerInfoClass
        Dim P1 As PlayerControls
        Dim P2 As PlayerControls

        Structure PlayerControls
            Dim keyMoveLeft As PlayerKeys
            Dim keyMoveRight As PlayerKeys
            Dim keyAccel As PlayerKeys
            Dim keyBrake As PlayerKeys
            Private _maxA As Double ' Max Acceleration allowed, same units as above
            Private _v As Double ' Current Velocity (probably in pixels/tick ?)
            Private _a As Double ' Current Acceleration (probably in pixels/tick^2 ?)
            Private _x As Double ' Current x (horz) position of the player vehicle
            Private _rx As Double ' Current x (horz) position of the player vehicle relative to the track segment
            Private _y As Double ' Current y (vert) position of the player vehicle relative to the track segment
            Private _ry As Double ' Current y (vert) position of the player vehicle relative to the track segment
            Private _maxV As Double ' Max Velocity allowed, same units as above
            Structure PlayerKeys
                Private _isDown As Boolean
                Private _defaultValue As Integer
                Private _curValue As Integer

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

                Public Property CurValue As Integer
                    Get
                        Return _curValue
                    End Get
                    Set(value As Integer)
                        _curValue = value
                    End Set
                End Property
            End Structure
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

        End Structure


    End Structure

    Dim TickCounter As Integer

    Dim PreviewKeyDownCounter As Integer
    Dim KeyDownCounter As Integer
    Dim KeyPressCounter As Integer
    Dim KeyUpCounter As Integer

    Dim MyPlayers As PlayerInfoClass


    Private Sub MyPlayersTest()
        MyPlayers.P1.KeyAccel.CurValue = 8


    End Sub


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
            .keyAccel.CurValue = Keys.W
            .KeyAccel.IsDown = False
            .KeyBrake.DefaultValue = Keys.S
            .KeyBrake.CurValue = Keys.S
            .KeyBrake.IsDown = False
            .KeyMoveLeft.DefaultValue = Keys.A
            .KeyMoveLeft.CurValue = Keys.A
            .KeyMoveLeft.IsDown = False
            .KeyMoveRight.DefaultValue = Keys.D
            .KeyMoveRight.CurValue = Keys.D
            .KeyMoveRight.IsDown = False
        End With

        ' Player 2 default controls
        With MyPlayers.P2
            .KeyAccel.DefaultValue = Keys.Up
            .KeyAccel.CurValue = Keys.Up
            .KeyAccel.IsDown = False
            .KeyBrake.DefaultValue = Keys.Down
            .KeyBrake.CurValue = Keys.Down
            .KeyBrake.IsDown = False
            .KeyMoveLeft.DefaultValue = Keys.Left
            .KeyMoveLeft.CurValue = Keys.Left
            .KeyMoveLeft.IsDown = False
            .KeyMoveRight.DefaultValue = Keys.Right
            .KeyMoveRight.CurValue = Keys.Right
            .KeyMoveRight.IsDown = False
        End With

    End Sub

    Private Sub InitializePlayerSettings()
        ' Set the initial values for the player's properties

        ' Player 1 
        With MyPlayers.P1
            .keyAccel.DefaultValue = Keys.W
            .keyAccel.CurValue = Keys.W
            .keyAccel.IsDown = False
            .keyBrake.DefaultValue = Keys.S
            .keyBrake.CurValue = Keys.S
            .keyBrake.IsDown = False
            .keyMoveLeft.DefaultValue = Keys.A
            .keyMoveLeft.CurValue = Keys.A
            .keyMoveLeft.IsDown = False
            .keyMoveRight.DefaultValue = Keys.D
            .keyMoveRight.CurValue = Keys.D
            .keyMoveRight.IsDown = False
        End With


        ' Player 2 
        With MyPlayers.P2
            .KeyAccel.DefaultValue = Keys.Up
            .keyAccel.CurValue = Keys.Up
            .KeyAccel.IsDown = False
            .KeyBrake.DefaultValue = Keys.Down
            .keyBrake.CurValue = Keys.Down
            .KeyBrake.IsDown = False
            .KeyMoveLeft.DefaultValue = Keys.Left
            .keyMoveLeft.CurValue = Keys.Left
            .KeyMoveLeft.IsDown = False
            .KeyMoveRight.DefaultValue = Keys.Right
            .keyMoveRight.CurValue = Keys.Right
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
        If e.KeyCode = MyPlayers.P1.keyAccel.CurValue Then MyPlayers.P1.keyAccel.IsDown = True
        If e.KeyCode = MyPlayers.P1.keyBrake.CurValue Then MyPlayers.P1.keyBrake.IsDown = True
        If e.KeyCode = MyPlayers.P1.keyMoveLeft.CurValue Then MyPlayers.P1.keyMoveLeft.IsDown = True
        If e.KeyCode = MyPlayers.P1.keyMoveRight.CurValue Then MyPlayers.P1.keyMoveRight.IsDown = True
        ' Player 2
        If e.KeyCode = MyPlayers.P2.keyAccel.CurValue Then MyPlayers.P2.keyAccel.IsDown = True
        If e.KeyCode = MyPlayers.P2.keyBrake.CurValue Then MyPlayers.P2.keyBrake.IsDown = True
        If e.KeyCode = MyPlayers.P2.keyMoveLeft.CurValue Then MyPlayers.P2.keyMoveLeft.IsDown = True
        If e.KeyCode = MyPlayers.P2.keyMoveRight.CurValue Then MyPlayers.P2.keyMoveRight.IsDown = True





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
        If e.KeyCode = MyPlayers.P1.keyAccel.CurValue Then MyPlayers.P1.keyAccel.IsDown = False
        If e.KeyCode = MyPlayers.P1.keyBrake.CurValue Then MyPlayers.P1.keyBrake.IsDown = False
        If e.KeyCode = MyPlayers.P1.keyMoveLeft.CurValue Then MyPlayers.P1.keyMoveLeft.IsDown = False
        If e.KeyCode = MyPlayers.P1.keyMoveRight.CurValue Then MyPlayers.P1.keyMoveRight.IsDown = False
        ' Player 2
        If e.KeyCode = MyPlayers.P2.keyAccel.CurValue Then MyPlayers.P2.keyAccel.IsDown = False
        If e.KeyCode = MyPlayers.P2.keyBrake.CurValue Then MyPlayers.P2.keyBrake.IsDown = False
        If e.KeyCode = MyPlayers.P2.keyMoveLeft.CurValue Then MyPlayers.P2.keyMoveLeft.IsDown = False
        If e.KeyCode = MyPlayers.P2.keyMoveRight.CurValue Then MyPlayers.P2.keyMoveRight.IsDown = False

    End Sub

    Private Sub KeyBoardTesting()
        'My.Computer.Keyboard.
    End Sub

End Class
