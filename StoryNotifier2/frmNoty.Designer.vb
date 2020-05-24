<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNoty
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.labelTitle = New System.Windows.Forms.Label()
        Me.labelContent = New System.Windows.Forms.Label()
        Me.pbProfile = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pbProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelTitle
        '
        Me.labelTitle.AutoSize = True
        Me.labelTitle.Font = New System.Drawing.Font("나눔바른고딕", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelTitle.Location = New System.Drawing.Point(112, 9)
        Me.labelTitle.Name = "labelTitle"
        Me.labelTitle.Size = New System.Drawing.Size(138, 24)
        Me.labelTitle.TabIndex = 1
        Me.labelTitle.Text = "Story Notifier"
        '
        'labelContent
        '
        Me.labelContent.Font = New System.Drawing.Font("나눔바른고딕 Light", 11.0!)
        Me.labelContent.Location = New System.Drawing.Point(114, 44)
        Me.labelContent.Name = "labelContent"
        Me.labelContent.Size = New System.Drawing.Size(274, 52)
        Me.labelContent.TabIndex = 2
        Me.labelContent.Text = "Reflection님이 내 스토리에 댓글을 남겼습니다. 이 프로그램은 Windows를 사용하는 PC에서도 카카오스토리 알림을 띄워주는 프로그램 입" &
    "니다."
        '
        'pbProfile
        '
        Me.pbProfile.Image = Global.StoryNotifier2.My.Resources.Resources.default_profile
        Me.pbProfile.Location = New System.Drawing.Point(0, 0)
        Me.pbProfile.Name = "pbProfile"
        Me.pbProfile.Size = New System.Drawing.Size(105, 105)
        Me.pbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbProfile.TabIndex = 0
        Me.pbProfile.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 4000
        '
        'frmNoty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 105)
        Me.Controls.Add(Me.labelContent)
        Me.Controls.Add(Me.labelTitle)
        Me.Controls.Add(Me.pbProfile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmNoty"
        Me.Text = "frmNoty"
        CType(Me.pbProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbProfile As PictureBox
    Friend WithEvents labelTitle As Label
    Friend WithEvents labelContent As Label
    Friend WithEvents Timer1 As Timer
End Class
