﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkLog = New System.Windows.Forms.CheckBox()
        Me.notifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notifyMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.viewSNotyForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.moveRecentNoty = New System.Windows.Forms.ToolStripMenuItem()
        Me.myStory = New System.Windows.Forms.ToolStripMenuItem()
        Me.개발자정보ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.visitDevleopers = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Quit = New System.Windows.Forms.ToolStripMenuItem()
        Me.timerNoty = New System.Windows.Forms.Timer(Me.components)
        Me.timerConnect = New System.Windows.Forms.Timer(Me.components)
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.chkCNoty = New System.Windows.Forms.CheckBox()
        Me.pnlSetColor = New System.Windows.Forms.Panel()
        Me.labelSetColor = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.chkProfile = New System.Windows.Forms.CheckBox()
        Me.chkSound = New System.Windows.Forms.CheckBox()
        Me.notifyMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "알리미가 실행중입니다!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'chkLog
        '
        Me.chkLog.Location = New System.Drawing.Point(20, 27)
        Me.chkLog.Name = "chkLog"
        Me.chkLog.Size = New System.Drawing.Size(131, 18)
        Me.chkLog.TabIndex = 1
        Me.chkLog.Text = "로그 작성"
        Me.chkLog.UseVisualStyleBackColor = True
        '
        'notifyIcon
        '
        Me.notifyIcon.ContextMenuStrip = Me.notifyMenu
        Me.notifyIcon.Icon = CType(resources.GetObject("notifyIcon.Icon"), System.Drawing.Icon)
        Me.notifyIcon.Visible = True
        '
        'notifyMenu
        '
        Me.notifyMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.viewSNotyForm, Me.moveRecentNoty, Me.myStory, Me.개발자정보ToolStripMenuItem, Me.Quit})
        Me.notifyMenu.Name = "notifyMenu"
        Me.notifyMenu.Size = New System.Drawing.Size(181, 136)
        '
        'viewSNotyForm
        '
        Me.viewSNotyForm.Name = "viewSNotyForm"
        Me.viewSNotyForm.Size = New System.Drawing.Size(180, 22)
        Me.viewSNotyForm.Text = "SNoty 보이기"
        '
        'moveRecentNoty
        '
        Me.moveRecentNoty.Name = "moveRecentNoty"
        Me.moveRecentNoty.Size = New System.Drawing.Size(180, 22)
        Me.moveRecentNoty.Text = "최근 알림 이동"
        '
        'myStory
        '
        Me.myStory.Name = "myStory"
        Me.myStory.Size = New System.Drawing.Size(180, 22)
        Me.myStory.Text = "내 스토리"
        '
        '개발자정보ToolStripMenuItem
        '
        Me.개발자정보ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.visitDevleopers, Me.AppInfo})
        Me.개발자정보ToolStripMenuItem.Name = "개발자정보ToolStripMenuItem"
        Me.개발자정보ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.개발자정보ToolStripMenuItem.Text = "정보"
        '
        'visitDevleopers
        '
        Me.visitDevleopers.Name = "visitDevleopers"
        Me.visitDevleopers.Size = New System.Drawing.Size(180, 22)
        Me.visitDevleopers.Text = "개발자 웹사이트"
        '
        'AppInfo
        '
        Me.AppInfo.Name = "AppInfo"
        Me.AppInfo.Size = New System.Drawing.Size(180, 22)
        Me.AppInfo.Text = "프로그램 정보"
        '
        'Quit
        '
        Me.Quit.Name = "Quit"
        Me.Quit.Size = New System.Drawing.Size(180, 22)
        Me.Quit.Text = "종료"
        '
        'timerNoty
        '
        Me.timerNoty.Interval = 1000
        '
        'timerConnect
        '
        Me.timerConnect.Interval = 2000
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(113, 138)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(15, 21)
        Me.txtTime.TabIndex = 2
        Me.txtTime.Text = "5"
        Me.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "초"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "알림 체크 주기:"
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(6, 165)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(187, 23)
        Me.btnApply.TabIndex = 5
        Me.btnApply.Text = "저장"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'chkCNoty
        '
        Me.chkCNoty.AutoSize = True
        Me.chkCNoty.Location = New System.Drawing.Point(20, 118)
        Me.chkCNoty.Name = "chkCNoty"
        Me.chkCNoty.Size = New System.Drawing.Size(144, 16)
        Me.chkCNoty.TabIndex = 6
        Me.chkCNoty.Text = "윈도우 기본 알림 사용"
        Me.chkCNoty.UseVisualStyleBackColor = True
        '
        'pnlSetColor
        '
        Me.pnlSetColor.BackColor = System.Drawing.Color.White
        Me.pnlSetColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSetColor.Location = New System.Drawing.Point(20, 97)
        Me.pnlSetColor.Name = "pnlSetColor"
        Me.pnlSetColor.Size = New System.Drawing.Size(13, 13)
        Me.pnlSetColor.TabIndex = 7
        '
        'labelSetColor
        '
        Me.labelSetColor.AutoSize = True
        Me.labelSetColor.Location = New System.Drawing.Point(36, 97)
        Me.labelSetColor.Name = "labelSetColor"
        Me.labelSetColor.Size = New System.Drawing.Size(57, 12)
        Me.labelSetColor.TabIndex = 8
        Me.labelSetColor.Text = "색상 설정"
        '
        'chkProfile
        '
        Me.chkProfile.AutoSize = True
        Me.chkProfile.Location = New System.Drawing.Point(20, 51)
        Me.chkProfile.Name = "chkProfile"
        Me.chkProfile.Size = New System.Drawing.Size(116, 16)
        Me.chkProfile.TabIndex = 9
        Me.chkProfile.Text = "프로필 사진 로드"
        Me.chkProfile.UseVisualStyleBackColor = True
        '
        'chkSound
        '
        Me.chkSound.AutoSize = True
        Me.chkSound.Location = New System.Drawing.Point(20, 74)
        Me.chkSound.Name = "chkSound"
        Me.chkSound.Size = New System.Drawing.Size(88, 16)
        Me.chkSound.TabIndex = 10
        Me.chkSound.Text = "알림 사운드"
        Me.chkSound.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(199, 200)
        Me.Controls.Add(Me.chkSound)
        Me.Controls.Add(Me.labelSetColor)
        Me.Controls.Add(Me.pnlSetColor)
        Me.Controls.Add(Me.chkCNoty)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.chkLog)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkProfile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Story Notifier 2"
        Me.notifyMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents chkLog As CheckBox
    Friend WithEvents notifyIcon As NotifyIcon
    Friend WithEvents notifyMenu As ContextMenuStrip
    Friend WithEvents viewSNotyForm As ToolStripMenuItem
    Friend WithEvents moveRecentNoty As ToolStripMenuItem
    Friend WithEvents myStory As ToolStripMenuItem
    Friend WithEvents 개발자정보ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents visitDevleopers As ToolStripMenuItem
    Friend WithEvents AppInfo As ToolStripMenuItem
    Friend WithEvents Quit As ToolStripMenuItem
    Friend WithEvents timerNoty As Timer
    Friend WithEvents timerConnect As Timer
    Friend WithEvents txtTime As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnApply As Button
    Friend WithEvents chkCNoty As CheckBox
    Friend WithEvents pnlSetColor As Panel
    Friend WithEvents labelSetColor As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents chkProfile As CheckBox
    Friend WithEvents chkSound As CheckBox
End Class
