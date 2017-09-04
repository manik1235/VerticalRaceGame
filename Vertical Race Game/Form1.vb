Imports Vertical_Race_Game

Public Class MainForm


    Structure PlayerInfoStructure
        Dim P1 As PlayerControls
        Dim P2 As PlayerControls

        Structure PlayerControls
            Dim keyMoveLeft As PlayerKeys
            Dim keyMoveRight As PlayerKeys
            Dim keyAccel As PlayerKeys
            Dim keyBrake As PlayerKeys
            Dim PrimaryCarPictureBox As PictureBox
            Dim RelativeCarPictureBox As PictureBox
            Dim TrackPictureBox As PictureBox




            Private _primaryCarImage As Image
            Private _maxA As Double ' Max Acceleration allowed, same units as above
            Private _v As Double ' Current Velocity (probably in pixels/tick ?)
            Private _a As Double ' Current Acceleration (probably in pixels/tick^2 ?)
            Private _x As Double ' Current x (horz) position of the player vehicle
            Private _dx As Double ' Amount to change the x position for each tick
            Private _rx As Double ' Current x (horz) position of the player vehicle relative to the track segment
            Private _y As Double ' Current y (vert) position of the player vehicle
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

            Public Property Dx As Double
                Get
                    Return _dx
                End Get
                Set(value As Double)
                    _dx = value
                End Set
            End Property

            Public Property PrimaryCarImage As Image
                Get
                    Return _primaryCarImage
                End Get
                Set(value As Image)
                    _primaryCarImage = value
                End Set
            End Property


        End Structure


    End Structure

    Structure TrackInfoStructure
        ' This structure defines the MyTracks variable
        ' This layer allows for the Left and Right (and more if desired) tracks

        Dim LeftTrack As TrackControls ' Holds data for the Left Track (Player 1)
        Dim RightTrack As TrackControls ' Holds data for the Right Track (Player 2)

        Structure TrackControls
            ' This structure supports the Left and Right track items.
            ' This layer allows for the separation into the different track segment picture boxes.
            ' Used to create smooth, continous track movement.

            Dim A As TrackControlsAB ' Holds the info for Track segment A
            Dim B As TrackControlsAB ' HOlds the info for Track segment B

            ' These variables Hold border layer data
            Dim BorderHeight As Integer ' Holds the height of the container panel for these track sections

            Structure TrackControlsAB
                ' Holds the deepest level data for the track segments
                Dim Top As Integer ' Holds the y value (top) for the Track A/B 
                Dim Height As Integer ' Holds the height of the Picturebox track section


            End Structure

        End Structure
    End Structure

    Dim TickCounter As Integer ' Counts the ticks (right now from 0 to 999)

    ' Various Debug Counters
    Dim DbgPreviewKeyDownCounter As Integer
    Dim DbgKeyDownCounter As Integer
    Dim DbgKeyPressCounter As Integer
    Dim DbgKeyUpCounter As Integer

    Dim MyPlayers As PlayerInfoStructure ' Holds the information for the Player and car structures

    Dim MyTracks As TrackInfoStructure ' Holds the information for the Track structures

    Private Sub TrackTimer_Tick(sender As Object, e As EventArgs) Handles TrackTimer.Tick

        ' Display the debug info for player keypresses
        UpdateDebugDisplay()

        ' Increase the tick counter, restart if at 1000. This allows things to happen less finely grained
        If TickCounter < 999 Then
            TickCounter += 1
        Else
            TickCounter = 0
        End If

        ' Move the tracks down every tick, if the car is accelerating.
        ' Also move the relative car up the same amount.
        MoveMyTracksRoot()

        ' Move the cars left or right as determined by the currently pressed keys
        MoveRaceCarPositions()

        ' Relocate Tracks A or B if they move below the panel's border
        RelocateDisplayedTrackSegments()

        ' Update Display
        ' After all the above calculations are complete, move the display elements to the correct places
        UpdateDisplayedCarPositions()

        ' Update the track display
        UpdateDisplayedTrackPositions()


    End Sub

    Private Sub UpdateDebugDisplay()
        ' Player1

        'Label8.Text = MyPlayers.P1.keyAccel.IsDown
        'Label7.Text = MyPlayers.P1.keyBrake.IsDown
        'Label6.Text = MyPlayers.P1.keyMoveLeft.IsDown
        'Label5.Text = MyPlayers.P1.keyMoveRight.IsDown
        ' Player2
        Label12.Text = MyPlayers.P2.keyAccel.IsDown
        Label11.Text = MyPlayers.P2.keyBrake.IsDown
        Label10.Text = MyPlayers.P2.keyMoveLeft.IsDown
        Label9.Text = MyPlayers.P2.keyMoveRight.IsDown

        ' Car positions
        Label8.Text = "P1.X: " & MyPlayers.P1.X
        Label7.Text = "P1.Y: " & MyPlayers.P1.Y
        Label6.Text = "P1.RY: " & MyPlayers.P1.Ry
        Label5.Text = "A.top: " & (LeftTrackPictureBoxA.Top - MyPlayers.P1.Y)

        ' Where do I want it? To move opposite the velocity of my track.
        ' How fast is my track moving? Add it in there. Add RelativeCarMove

    End Sub

    Private Sub UpdateDisplayedTrackPositions()
        ' move the picture boxes to the positions indicated in the Track structure
        ' Left Track (Player 1's view)
        LeftTrackPictureBoxA.Top = MyTracks.LeftTrack.A.Top
        LeftTrackPictureBoxB.Top = MyTracks.LeftTrack.B.Top


        ' Right Track (Player 2's view)
        RightTrackPictureBoxA.Top = MyTracks.RightTrack.A.Top
        RightTrackPictureBoxB.Top = MyTracks.RightTrack.B.Top


    End Sub

    Private Sub UpdateDisplayedCarPositions()
        ' Adjust the Picture Boxes that hold the car items to the new values.

        ' Primary Car
        ' Player 1
        MyPlayers.P1.PrimaryCarPictureBox.Left = MyPlayers.P1.X

        ' Player 2
        MyPlayers.P2.PrimaryCarPictureBox.Left = MyPlayers.P2.X

        ' Relative Car
        ' Player 1
        MyPlayers.P1.RelativeCarPictureBox.Left = MyPlayers.P1.X
        MyPlayers.P1.RelativeCarPictureBox.Top = MyPlayers.P1.Ry

        ' Player 2
        MyPlayers.P2.RelativeCarPictureBox.Left = MyPlayers.P2.X
        MyPlayers.P2.RelativeCarPictureBox.Top = MyPlayers.P2.Ry

    End Sub

    Private Sub MoveRaceCarPositions()
        ' Move the player cars left or right based on the keys currently pressed

        'Player 1
        With MyPlayers.P1
            If .keyMoveLeft.IsDown Then
                'Moving left is held down, so move left
                .X -= .Dx
            ElseIf .keyMoveRight.IsDown Then
                ' Moving right is held down, so move right
                .X += .Dx
            End If
        End With


        'Player 2
        With MyPlayers.P2
            If .keyMoveLeft.IsDown Then
                'Moving left is held down, so move left
                .X -= .Dx
            ElseIf .keyMoveRight.IsDown Then
                ' Moving right is held down, so move right
                .X += .Dx
            End If
        End With

        ';' Move relative car
        ';' Player 1
        'MyPlayers.P1.Ry = LeftTrackPictureBoxA.Top - MyPlayers.P1.Y

    End Sub

    Private Sub MoveMyTracksRoot()
        ' Move the tracks down every tick, if the car is accelerating.
        ' Also move the relative car forward the same amount
        ' Tracks move directly, car moves indirectly
        ' When the other track moves, move the relative car 

        ' Cars Are Accelerating
        ' Player 1
        If MyPlayers.P1.keyAccel.IsDown Then
            If TickCounter Mod 1 = 0 Then ' Allows modification based on the TickCounter. Not yet used (hence Mod 1)
                MyTracks.LeftTrack.A.Top += MyPlayers.P1.V ' Move the track based on the current player's velocity
                MyTracks.LeftTrack.B.Top += MyPlayers.P1.V ' Move the track based on the current player's velocity
                'Move the relative car of player 2 down with the track on this side
                MyPlayers.P2.Ry += MyPlayers.P1.V ' Move the relative car based on the velocity
                MyPlayers.P1.Ry -= MyPlayers.P1.V ' Move the relative car based on the velocity
            End If
        End If

        ' Player 2
        If MyPlayers.P2.keyAccel.IsDown Then
            If TickCounter Mod 1 = 0 Then ' Allows modification based on the TickCounter. Not yet used (hence Mod 1)
                MyTracks.RightTrack.A.Top += MyPlayers.P2.V ' Move the track based on the current player's velocity
                MyTracks.RightTrack.B.Top += MyPlayers.P2.V ' Move the track based on the current player's velocity
                ' Move the relative cars
                MyPlayers.P2.Ry -= MyPlayers.P2.V ' Move the relative car closer to the top by the same amount.
                MyPlayers.P1.Ry += MyPlayers.P2.V ' Move the relative car based on the velocity
            End If
        End If

        ' Cars Are Braking (Reversing)
        ' Player 1
        If MyPlayers.P1.keyBrake.IsDown Then
            If TickCounter Mod 1 = 0 Then ' Allows modification based on the TickCounter. Not yet used (hence Mod 1)
                MyTracks.LeftTrack.A.Top += -MyPlayers.P1.V ' Move the track based on the current player's velocity
                MyTracks.LeftTrack.B.Top += -MyPlayers.P1.V ' Move the track based on the current player's velocity
                'Move the relative car of player 2 down with the track on this side
                MyPlayers.P2.Ry += -MyPlayers.P1.V ' Move the relative car based on the velocity
                MyPlayers.P1.Ry -= -MyPlayers.P1.V ' Move the relative car based on the velocity
            End If
        End If

        ' Player 2
        If MyPlayers.P2.keyBrake.IsDown Then
            If TickCounter Mod 1 = 0 Then ' Allows modification based on the TickCounter. Not yet used (hence Mod 1)
                MyTracks.RightTrack.A.Top += -MyPlayers.P2.V ' Move the track based on the current player's velocity
                MyTracks.RightTrack.B.Top += -MyPlayers.P2.V ' Move the track based on the current player's velocity
                ' move the relative car of player 1 down with the track on this side
                MyPlayers.P2.Ry -= -MyPlayers.P2.V ' Move the relative car closer to the top by the same amount.
                MyPlayers.P1.Ry += -MyPlayers.P2.V ' Move the relative car based on the velocity
            End If
        End If
    End Sub

    Private Sub RelocateDisplayedTrackSegments()
        ' Relocate Tracks A or B if they move below the panel's border
        ' Indirectly thru the Track structure

        ' Left Track
        If MyTracks.LeftTrack.A.Top > MyTracks.LeftTrack.BorderHeight Then ' if Track Section A moves below the visible panel, relocate it to be above Section B
            MyTracks.LeftTrack.A.Top = MyTracks.LeftTrack.B.Top - MyTracks.LeftTrack.A.Height
        End If
        If MyTracks.LeftTrack.B.Top > MyTracks.LeftTrack.BorderHeight Then ' If Track section  B moves below the visible panel, relocate it above Section A
            MyTracks.LeftTrack.B.Top = MyTracks.LeftTrack.A.Top - MyTracks.LeftTrack.B.Height
        End If

        ' Right Track
        If MyTracks.RightTrack.A.Top > MyTracks.RightTrack.BorderHeight Then ' if Track Section A moves below the visible panel, relocate it to be above Section B
            MyTracks.RightTrack.A.Top = MyTracks.RightTrack.B.Top - MyTracks.RightTrack.A.Height
        End If
        If MyTracks.RightTrack.B.Top > MyTracks.RightTrack.BorderHeight Then ' If Track section  B moves below the visible panel, relocate it above Section A
            MyTracks.RightTrack.B.Top = MyTracks.RightTrack.A.Top - MyTracks.RightTrack.B.Height
        End If


        ' This one works with the direct movement method, not indirect
        '        ' Left Track
        '        If LeftTrackPictureBoxA.Top > LeftRaceBackgroundPanel.Height Then
        '        LeftTrackPictureBoxA.Top = LeftTrackPictureBoxB.Top - LeftTrackPictureBoxA.Height
        '        End If
        '        If LeftTrackPictureBoxB.Top > LeftRaceBackgroundPanel.Height Then
        '        LeftTrackPictureBoxB.Top = LeftTrackPictureBoxA.Top - LeftTrackPictureBoxB.Height
        '        End If
        '
        '        ' Right Track
        '        If RightTrackPictureBoxA.Top > RightRaceBackgroundPanel.Height Then
        '        RightTrackPictureBoxA.Top = RightTrackPictureBoxB.Top - RightTrackPictureBoxA.Height
        '        End If
        '        If RightTrackPictureBoxB.Top > RightRaceBackgroundPanel.Height Then
        '        RightTrackPictureBoxB.Top = RightTrackPictureBoxA.Top - RightTrackPictureBoxB.Height
        '        End If
    End Sub

    Private Sub MoveTrack(Track As PictureBox, VSpeed As Integer)
        ' Move the track based on the car's movement speed
        Track.Location = New Point(Track.Left, Track.Top + VSpeed)
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize everything
        InitializeEverything()
    End Sub

    Private Sub InitializeEverything()

        ' This section needs to be updated to do it more programmatically, probably
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


        ' Initialize the default keyboard control settings
        InitializeKeyboardSettings()

        ' Initialize the player settings
        InitializePlayerSettings()

        ' Initialize Track Settings
        InitializeTrackSettings()

        ' Initialize the Counters
        DbgKeyPressCounter = 0
        DbgKeyDownCounter = 0
        DbgKeyUpCounter = 0
        TickCounter = 0


    End Sub

    Private Sub InitializeKeyboardSettings()
        ' Set the initial values for the player's keyboard controls

        ' Player 1 default controls
        With MyPlayers.P1
            .keyAccel.DefaultValue = Keys.W
            .keyAccel.CurValue = .keyAccel.DefaultValue
            .keyAccel.IsDown = False
            .keyBrake.DefaultValue = Keys.S
            .keyBrake.CurValue = .keyBrake.DefaultValue
            .keyBrake.IsDown = False
            .keyMoveLeft.DefaultValue = Keys.A
            .keyMoveLeft.CurValue = .keyMoveLeft.DefaultValue
            .keyMoveLeft.IsDown = False
            .keyMoveRight.DefaultValue = Keys.D
            .keyMoveRight.CurValue = .keyMoveRight.DefaultValue
            .keyMoveRight.IsDown = False
        End With

        ' Player 2 default controls
        With MyPlayers.P2
            .keyAccel.DefaultValue = Keys.Up
            .keyAccel.CurValue = .keyAccel.DefaultValue
            .keyAccel.IsDown = False
            .keyBrake.DefaultValue = Keys.Down
            .keyBrake.CurValue = .keyBrake.DefaultValue
            .keyBrake.IsDown = False
            .keyMoveLeft.DefaultValue = Keys.Left
            .keyMoveLeft.CurValue = .keyMoveLeft.DefaultValue
            .keyMoveLeft.IsDown = False
            .keyMoveRight.DefaultValue = Keys.Right
            .keyMoveRight.CurValue = .keyMoveRight.DefaultValue
            .keyMoveRight.IsDown = False
        End With

    End Sub

    Private Sub InitializePlayerSettings()
        ' Set the initial values for the player's properties

        ' Player 1 
        With MyPlayers.P1
            ' Set the keys
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

            ' Set the initial location properties
            .Dx = 1
            .X = 156 ' 156 is the x value of the PictureBox on Track 1
            .Y = 172 ' 172 is the y value of the PictureBox on Track 1
            .Ry = .Y

            ' Initialize the car that goes with the player
            .PrimaryCarPictureBox = LeftP1CarPictureBox
            ' Initialize the image that goes with the player
            .PrimaryCarImage = LeftP1CarPictureBox.Image
            .RelativeCarPictureBox = RightP1CarPictureBox 'Set the Relative Picture box to the other picture box
            .RelativeCarPictureBox.Image = .PrimaryCarImage 'Set the relative car image to the primary car image

            ' Initialize the velocity as 1, because that's what it's doing right now
            .V = 1
        End With


        ' Player 2 
        With MyPlayers.P2
            .keyAccel.DefaultValue = Keys.Up
            .keyAccel.CurValue = Keys.Up
            .keyAccel.IsDown = False
            .keyBrake.DefaultValue = Keys.Down
            .keyBrake.CurValue = Keys.Down
            .keyBrake.IsDown = False
            .keyMoveLeft.DefaultValue = Keys.Left
            .keyMoveLeft.CurValue = Keys.Left
            .keyMoveLeft.IsDown = False
            .keyMoveRight.DefaultValue = Keys.Right
            .keyMoveRight.CurValue = Keys.Right
            .keyMoveRight.IsDown = False

            ' Set the initial location properties
            .Dx = 1
            .X = 213 '213 is the x value of the PictureBox on Track 2
            .Y = 172 '172 is the y value of the PictrueBox on Track 2
            .Ry = .Y

            ' Initialize the car that goes with the player
            .PrimaryCarPictureBox = RightP2CarPictureBox
            ' Initialize the image that goes with the player
            .PrimaryCarImage = RightP2CarPictureBox.Image
            .RelativeCarPictureBox = LeftP2CarPictureBox
            .RelativeCarPictureBox.Image = .PrimaryCarImage

            ' Initialize the velocity as 1, because that's what it's doing right now
            .V = 1
        End With
    End Sub

    Private Sub InitializeTrackSettings()
        ' This section sets the defaults for the track elements

        ' Left Track
        With MyTracks.LeftTrack
            .BorderHeight = LeftRaceBackgroundPanel.Height ' The border height defaults to the container panel's height
            With .A
                .Height = LeftTrackPictureBoxA.Height ' the track segment height defaults to the size of the picturebox
                .Top = LeftTrackPictureBoxA.Top ' the track segment top position defaults to the picture box top position
            End With
            With .B
                .Height = LeftTrackPictureBoxB.Height
                .Top = LeftTrackPictureBoxB.Top
            End With
        End With

        ' Right Track
        With MyTracks.RightTrack
            .BorderHeight = RightRaceBackgroundPanel.Height
            With .A
                .Height = RightTrackPictureBoxA.Height
                .Top = RightTrackPictureBoxA.Top
            End With
            With .B
                .Height = RightTrackPictureBoxB.Height
                .Top = RightTrackPictureBoxB.Top
            End With
        End With
    End Sub

    Private Sub MainForm_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        DbgPreviewKeyDownCounter += 1
        'e.IsInputKey = True
        Label1.Text = "PreviewKeyDown: " & DbgPreviewKeyDownCounter & " IsInputKey: " & e.IsInputKey & " KeyCode: " & e.KeyCode & " KeyData: " & e.KeyData & " KeyValue: " & e.KeyValue

    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        DbgKeyDownCounter += 1
        e.Handled = True
        Label2.Text = "KeyDown: " & DbgKeyDownCounter & " Handled: " & e.Handled & " KeyCode: " & e.KeyCode & " KeyData: " & e.KeyData & " KeyValue: " & e.KeyValue
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
        DbgKeyPressCounter += 1
        Label3.Text = "KeyPress: " & DbgKeyPressCounter & " KeyChar: " & e.KeyChar & " " & " Handled: " & e.Handled

    End Sub

    Private Sub MainForm_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        DbgKeyUpCounter += 1
        Label4.Text = "KeyUp: " & DbgKeyUpCounter & " Handled: " & e.Handled & " KeyCode: " & e.KeyCode & " KeyData: " & e.KeyData & " KeyValue: " & e.KeyValue

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


End Class
