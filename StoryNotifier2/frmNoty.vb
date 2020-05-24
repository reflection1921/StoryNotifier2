Public Class frmNoty

    Sub New(nMessage As String, isLoadProfile As Boolean, profURL As String, profID As String, isSNoty As Boolean, isSound As Boolean)

        InitializeComponent()

        labelContent.Text = nMessage
        Me.BackColor = colorValue

        If colorValue.GetBrightness < 0.3 Then
            labelTitle.ForeColor = Color.White
            labelContent.ForeColor = Color.White
        Else
            labelTitle.ForeColor = Color.Black
            labelContent.ForeColor = Color.Black
        End If

        If isSound = True Then
            My.Computer.Audio.Play(My.Resources.juntos, AudioPlayMode.Background)
        End If

        If isSNoty = False Then
            pbProfile.Image = My.Resources.notyicon
            Exit Sub
        End If

        If isLoadProfile = True Then
            LoadProfile(profURL, profID, pbProfile)
        End If

    End Sub

    Private Sub frmNoty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '//loadProfile("URI", "", pbProfile)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

    Private Sub viewNotyContent(sender As Object, e As EventArgs) Handles pbProfile.Click, labelTitle.Click, labelContent.Click, Me.Click
        Process.Start("https://story.kakao.com/" & NotyURL)
    End Sub
End Class