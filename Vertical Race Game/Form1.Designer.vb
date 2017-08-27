<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.LeftRaceBackgroundPanel = New System.Windows.Forms.Panel()
        Me.RightRaceBackgroundPanel = New System.Windows.Forms.Panel()
        Me.MainPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.RightRaceBackgroundPanel)
        Me.MainPanel.Controls.Add(Me.LeftRaceBackgroundPanel)
        Me.MainPanel.Location = New System.Drawing.Point(213, 26)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(508, 288)
        Me.MainPanel.TabIndex = 0
        '
        'LeftRaceBackgroundPanel
        '
        Me.LeftRaceBackgroundPanel.Location = New System.Drawing.Point(15, 23)
        Me.LeftRaceBackgroundPanel.Name = "LeftRaceBackgroundPanel"
        Me.LeftRaceBackgroundPanel.Size = New System.Drawing.Size(239, 226)
        Me.LeftRaceBackgroundPanel.TabIndex = 0
        '
        'RightRaceBackgroundPanel
        '
        Me.RightRaceBackgroundPanel.Location = New System.Drawing.Point(260, 23)
        Me.RightRaceBackgroundPanel.Name = "RightRaceBackgroundPanel"
        Me.RightRaceBackgroundPanel.Size = New System.Drawing.Size(239, 226)
        Me.RightRaceBackgroundPanel.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 344)
        Me.Controls.Add(Me.MainPanel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MainPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainPanel As Panel
    Friend WithEvents RightRaceBackgroundPanel As Panel
    Friend WithEvents LeftRaceBackgroundPanel As Panel
End Class
