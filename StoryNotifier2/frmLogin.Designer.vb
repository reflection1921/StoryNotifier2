<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.webLogin = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'webLogin
        '
        Me.webLogin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webLogin.Location = New System.Drawing.Point(0, 0)
        Me.webLogin.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webLogin.Name = "webLogin"
        Me.webLogin.Size = New System.Drawing.Size(344, 521)
        Me.webLogin.TabIndex = 0
        Me.webLogin.Url = New System.Uri("https://accounts.kakao.com/login/?continue=https%3A%2F%2Fstory.kakao.com%2F", System.UriKind.Absolute)
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(344, 521)
        Me.Controls.Add(Me.webLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "카카오스토리 로그인"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents webLogin As WebBrowser
End Class
