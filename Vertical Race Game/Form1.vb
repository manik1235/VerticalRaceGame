Public Class MainForm
    Dim TickCounter As Integer

    Dim PreviewKeyDownCounter As Integer
    Dim KeyDownCounter As Integer
    Dim KeyPressCounter As Integer
    Dim KeyUpCounter As Integer

    Private Structure StructKeyboardControls
        Structure PlayerControls
            Dim MoveLeftKey As Integer
            Dim MoveRightKey As Integer
        End Structure

        Dim P1 As PlayerControls
        Dim P2 As PlayerControls

    End Structure

    Private Sub StructureTest()
        Dim MyPlayer As StructKeyboardControls

        MyPlayer.P1.MoveLeftKey = 3
    End Sub

    Private Sub TrackTimer_Tick(sender As Object, e As EventArgs) Handles TrackTimer.Tick
        StructureTest()

        ' Increase the tick counter, restart if at 1000. This allows things to happen less finely grained
        If TickCounter < 999 Then
            TickCounter += 1
        Else
            TickCounter = 0
        End If

        ' Move the tracks down every tick
        If TickCounter Mod 50 Then
            MoveTrack(LeftTrackPictureBoxA, 1)
            MoveTrack(LeftTrackPictureBoxB, 1)
        End If
        If TickCounter Mod 50 Then
            MoveTrack(RightTrackPictureBoxA, 1)
            MoveTrack(RightTrackPictureBoxB, 1)
        End If

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
    End Sub

    Private Sub MainForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        KeyPressCounter += 1
        Label3.Text = "KeyPress: " & KeyPressCounter & " KeyChar: " & e.KeyChar & " " & " Handled: " & e.Handled

    End Sub

    Private Sub MainForm_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        KeyUpCounter += 1
        Label4.Text = "KeyUp: " & KeyUpCounter & " Handled: " & e.Handled & " KeyCode: " & e.KeyCode & " KeyData: " & e.KeyData & " KeyValue: " & e.KeyValue

    End Sub

    Private Sub KeyBoardTesting()
        'My.Computer.Keyboard.
    End Sub

End Class
