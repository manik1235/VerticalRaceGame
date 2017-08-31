<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.RightRaceBackgroundPanel = New System.Windows.Forms.Panel()
        Me.LeftRaceBackgroundPanel = New System.Windows.Forms.Panel()
        Me.LeftTrackPictureBoxA = New System.Windows.Forms.PictureBox()
        Me.RightTrackPictureBoxA = New System.Windows.Forms.PictureBox()
        Me.TrackTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LeftTrackPictureBoxB = New System.Windows.Forms.PictureBox()
        Me.RightTrackPictureBoxB = New System.Windows.Forms.PictureBox()
        Me.LeftP1CarPictureBox = New System.Windows.Forms.PictureBox()
        Me.LeftP2CarPictureBox = New System.Windows.Forms.PictureBox()
        Me.RightP2CarPictureBox = New System.Windows.Forms.PictureBox()
        Me.RightP1CarPictureBox = New System.Windows.Forms.PictureBox()
        Me.StatusPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.MainPanel.SuspendLayout()
        Me.RightRaceBackgroundPanel.SuspendLayout()
        Me.LeftRaceBackgroundPanel.SuspendLayout()
        CType(Me.LeftTrackPictureBoxA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightTrackPictureBoxA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftTrackPictureBoxB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightTrackPictureBoxB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftP1CarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftP2CarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightP2CarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightP1CarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.RightRaceBackgroundPanel)
        Me.MainPanel.Controls.Add(Me.LeftRaceBackgroundPanel)
        Me.MainPanel.Location = New System.Drawing.Point(12, 77)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(913, 288)
        Me.MainPanel.TabIndex = 0
        '
        'RightRaceBackgroundPanel
        '
        Me.RightRaceBackgroundPanel.Controls.Add(Me.RightP2CarPictureBox)
        Me.RightRaceBackgroundPanel.Controls.Add(Me.RightP1CarPictureBox)
        Me.RightRaceBackgroundPanel.Controls.Add(Me.RightTrackPictureBoxB)
        Me.RightRaceBackgroundPanel.Controls.Add(Me.RightTrackPictureBoxA)
        Me.RightRaceBackgroundPanel.Location = New System.Drawing.Point(433, 23)
        Me.RightRaceBackgroundPanel.Name = "RightRaceBackgroundPanel"
        Me.RightRaceBackgroundPanel.Size = New System.Drawing.Size(400, 226)
        Me.RightRaceBackgroundPanel.TabIndex = 1
        '
        'LeftRaceBackgroundPanel
        '
        Me.LeftRaceBackgroundPanel.Controls.Add(Me.LeftP2CarPictureBox)
        Me.LeftRaceBackgroundPanel.Controls.Add(Me.LeftP1CarPictureBox)
        Me.LeftRaceBackgroundPanel.Controls.Add(Me.LeftTrackPictureBoxB)
        Me.LeftRaceBackgroundPanel.Controls.Add(Me.LeftTrackPictureBoxA)
        Me.LeftRaceBackgroundPanel.Location = New System.Drawing.Point(15, 23)
        Me.LeftRaceBackgroundPanel.Name = "LeftRaceBackgroundPanel"
        Me.LeftRaceBackgroundPanel.Size = New System.Drawing.Size(400, 226)
        Me.LeftRaceBackgroundPanel.TabIndex = 0
        '
        'LeftTrackPictureBoxA
        '
        Me.LeftTrackPictureBoxA.Image = Global.Vertical_Race_Game.My.Resources.Resources.Basic_Race_Track
        Me.LeftTrackPictureBoxA.Location = New System.Drawing.Point(3, -777)
        Me.LeftTrackPictureBoxA.Margin = New System.Windows.Forms.Padding(0)
        Me.LeftTrackPictureBoxA.Name = "LeftTrackPictureBoxA"
        Me.LeftTrackPictureBoxA.Size = New System.Drawing.Size(388, 1000)
        Me.LeftTrackPictureBoxA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.LeftTrackPictureBoxA.TabIndex = 0
        Me.LeftTrackPictureBoxA.TabStop = False
        '
        'RightTrackPictureBoxA
        '
        Me.RightTrackPictureBoxA.Image = Global.Vertical_Race_Game.My.Resources.Resources.Basic_Race_Track
        Me.RightTrackPictureBoxA.Location = New System.Drawing.Point(3, -777)
        Me.RightTrackPictureBoxA.Margin = New System.Windows.Forms.Padding(0)
        Me.RightTrackPictureBoxA.Name = "RightTrackPictureBoxA"
        Me.RightTrackPictureBoxA.Size = New System.Drawing.Size(388, 1000)
        Me.RightTrackPictureBoxA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.RightTrackPictureBoxA.TabIndex = 1
        Me.RightTrackPictureBoxA.TabStop = False
        '
        'TrackTimer
        '
        Me.TrackTimer.Enabled = True
        Me.TrackTimer.Interval = 1
        '
        'LeftTrackPictureBoxB
        '
        Me.LeftTrackPictureBoxB.Image = Global.Vertical_Race_Game.My.Resources.Resources.Basic_Race_Track
        Me.LeftTrackPictureBoxB.Location = New System.Drawing.Point(6, -387)
        Me.LeftTrackPictureBoxB.Margin = New System.Windows.Forms.Padding(0)
        Me.LeftTrackPictureBoxB.Name = "LeftTrackPictureBoxB"
        Me.LeftTrackPictureBoxB.Size = New System.Drawing.Size(388, 1000)
        Me.LeftTrackPictureBoxB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.LeftTrackPictureBoxB.TabIndex = 1
        Me.LeftTrackPictureBoxB.TabStop = False
        '
        'RightTrackPictureBoxB
        '
        Me.RightTrackPictureBoxB.Image = Global.Vertical_Race_Game.My.Resources.Resources.Basic_Race_Track
        Me.RightTrackPictureBoxB.Location = New System.Drawing.Point(6, -387)
        Me.RightTrackPictureBoxB.Margin = New System.Windows.Forms.Padding(0)
        Me.RightTrackPictureBoxB.Name = "RightTrackPictureBoxB"
        Me.RightTrackPictureBoxB.Size = New System.Drawing.Size(388, 1000)
        Me.RightTrackPictureBoxB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.RightTrackPictureBoxB.TabIndex = 2
        Me.RightTrackPictureBoxB.TabStop = False
        '
        'LeftP1CarPictureBox
        '
        Me.LeftP1CarPictureBox.Location = New System.Drawing.Point(156, 172)
        Me.LeftP1CarPictureBox.Name = "LeftP1CarPictureBox"
        Me.LeftP1CarPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.LeftP1CarPictureBox.TabIndex = 2
        Me.LeftP1CarPictureBox.TabStop = False
        '
        'LeftP2CarPictureBox
        '
        Me.LeftP2CarPictureBox.Location = New System.Drawing.Point(216, 172)
        Me.LeftP2CarPictureBox.Name = "LeftP2CarPictureBox"
        Me.LeftP2CarPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.LeftP2CarPictureBox.TabIndex = 3
        Me.LeftP2CarPictureBox.TabStop = False
        '
        'RightP2CarPictureBox
        '
        Me.RightP2CarPictureBox.Location = New System.Drawing.Point(213, 172)
        Me.RightP2CarPictureBox.Name = "RightP2CarPictureBox"
        Me.RightP2CarPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.RightP2CarPictureBox.TabIndex = 5
        Me.RightP2CarPictureBox.TabStop = False
        '
        'RightP1CarPictureBox
        '
        Me.RightP1CarPictureBox.Location = New System.Drawing.Point(153, 172)
        Me.RightP1CarPictureBox.Name = "RightP1CarPictureBox"
        Me.RightP1CarPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.RightP1CarPictureBox.TabIndex = 4
        Me.RightP1CarPictureBox.TabStop = False
        '
        'StatusPanel
        '
        Me.StatusPanel.Controls.Add(Me.Label4)
        Me.StatusPanel.Controls.Add(Me.Label3)
        Me.StatusPanel.Controls.Add(Me.Label2)
        Me.StatusPanel.Controls.Add(Me.Label1)
        Me.StatusPanel.Location = New System.Drawing.Point(15, 0)
        Me.StatusPanel.Name = "StatusPanel"
        Me.StatusPanel.Size = New System.Drawing.Size(180, 71)
        Me.StatusPanel.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Label3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Label4"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(265, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(230, 71)
        Me.Panel1.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Label7"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Label8"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Location = New System.Drawing.Point(565, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(230, 71)
        Me.Panel2.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Label9"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Label10"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Label11"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Label12"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 344)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusPanel)
        Me.Controls.Add(Me.MainPanel)
        Me.KeyPreview = True
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.MainPanel.ResumeLayout(False)
        Me.RightRaceBackgroundPanel.ResumeLayout(False)
        Me.RightRaceBackgroundPanel.PerformLayout()
        Me.LeftRaceBackgroundPanel.ResumeLayout(False)
        Me.LeftRaceBackgroundPanel.PerformLayout()
        CType(Me.LeftTrackPictureBoxA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightTrackPictureBoxA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftTrackPictureBoxB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightTrackPictureBoxB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftP1CarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftP2CarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightP2CarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightP1CarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusPanel.ResumeLayout(False)
        Me.StatusPanel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainPanel As Panel
    Friend WithEvents RightRaceBackgroundPanel As Panel
    Friend WithEvents LeftRaceBackgroundPanel As Panel
    Friend WithEvents RightTrackPictureBoxA As PictureBox
    Friend WithEvents LeftTrackPictureBoxA As PictureBox
    Friend WithEvents TrackTimer As Timer
    Friend WithEvents RightTrackPictureBoxB As PictureBox
    Friend WithEvents LeftTrackPictureBoxB As PictureBox
    Friend WithEvents LeftP2CarPictureBox As PictureBox
    Friend WithEvents LeftP1CarPictureBox As PictureBox
    Friend WithEvents RightP2CarPictureBox As PictureBox
    Friend WithEvents RightP1CarPictureBox As PictureBox
    Friend WithEvents StatusPanel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
End Class
