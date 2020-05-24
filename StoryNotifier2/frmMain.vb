Imports System.IO
Imports Newtonsoft.Json.Linq
Imports System.Runtime.InteropServices

Public Class frmMain
    Private IE As New WinHttp.WinHttpRequest

    Private Const SW_SHOWNOACTIVATE As Integer = 4
    Private Const HWND_TOPMOST As Integer = -1
    Private Const SWP_NOACTIVATE As UInteger = &H10
    <DllImport("user32.dll", EntryPoint:="SetWindowPos")>
    Private Shared Function SetWindowPos(ByVal hWnd As Integer, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function
    <DllImport("user32.dll")>
    Private Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
    End Function
    Private Shared Sub ShowInactiveTopmost(ByVal frm As Form)
        Dim taskBarWidth As Integer = Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.WorkingArea.Width
        Dim taskBarHeight As Integer = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height
        Dim NotyLocationX As Integer = Screen.PrimaryScreen.Bounds.Width - 415 - taskBarWidth
        Dim NotyLocationY As Integer = Screen.PrimaryScreen.Bounds.Height - 115 - taskBarHeight

        ShowWindow(frm.Handle, SW_SHOWNOACTIVATE)
        SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST, NotyLocationX, NotyLocationY, frm.Width, frm.Height, SWP_NOACTIVATE)
    End Sub

    Private Sub Quit_Click(sender As Object, e As EventArgs) Handles Quit.Click
        End
    End Sub

    Private Sub viewSNotyForm_Click(sender As Object, e As EventArgs) Handles viewSNotyForm.Click
        Me.Show()
    End Sub

    Private Sub notifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles notifyIcon.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub AppInfo_Click(sender As Object, e As EventArgs) Handles AppInfo.Click
        MsgBox("Developed by Reflection(2016-2020)" & vbCrLf & "커스텀 알림 사운드(Juntos)는 notificationsounds.com에서 가져와서 사용하였습니다." & vbCrLf & "https://notificationsounds.com/message-tones/juntos-607", vbInformation, "Story Notifier 2")
    End Sub

    Private Sub visitDevleopers_Click(sender As Object, e As EventArgs) Handles visitDevleopers.Click
        Process.Start("explorer.exe", "http://chihaya.kr")
    End Sub

    Private Sub Notify()
        Try
            With IE
                .Open("GET", "https://story.kakao.com/a/notifications")
                .SetRequestHeader("Host", "story.kakao.com")
                .SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; rv:35.0) Gecko/20100101 Firefox/35.0")
                .SetRequestHeader("Accept", "application/json")
                .SetRequestHeader("Accept-Language", "ko")
                .SetRequestHeader("Connection", "keep-alive")
                .SetRequestHeader("X-Kakao-ApiLevel", "49")
                .SetRequestHeader("X-Kakao-DeviceInfo", "web:-;-;-")
                .SetRequestHeader("X-Requested-With", "XMLHttpRequest")
                .SetRequestHeader("Cookie", loginCookie)
                .SetRequestHeader("Referer", "https://story.kakao.com/")
                .Send()
            End With
        Catch ex As Exception
            NotifyBalloon("인터넷에 연결되어 있지 않습니다. 인터넷에 연결되면 자동 재시작 됩니다.", "", "", False)
            timerNoty.Enabled = False
            timerConnect.Enabled = True
        End Try

        Dim httpResult As String = System.Text.Encoding.UTF8.GetString(IE.ResponseBody)

        If httpResult = Nothing Then
            NotifyBalloon("카카오스토리에서 로그아웃 되어 알림이 종료됩니다. 재로그인 하세요.", "", "", False)
            timerNoty.Enabled = False
            timerConnect.Enabled = False
            frmLogin.Show()
            Me.Close()
            Exit Sub
        End If

        Dim notyJson As JArray = JArray.Parse(httpResult)
        Dim tmpNotyID As String = notyJson.Item(0).Item("id")

        If tmpNotyID = NotyID Then
            Exit Sub
        End If

        NotyID = tmpNotyID

        Try
            Dim message As String = notyJson.Item(0).Item("message")
            Dim content As String = notyJson.Item(0).Item("content")
            Dim scheme As String = notyJson.Item(0).Item("scheme")
            Dim profURL As String = notyJson.Item(0).Item("actor").Item("profile_thumbnail_url")
            Dim profID As String = notyJson.Item(0).Item("actor").Item("id")

            NotyURL = scheme
            NotyURL = NotyURL.Replace(".", "/")
            NotyURL = NotyURL.Replace("kakaostory://activities/", "")
            NotifyBalloon(message & " " & content, profURL, profID, True)

        Catch ex As exception
        End Try


    End Sub

    Public Sub initializeNotify()
        With IE
            .Open("GET", "https://story.kakao.com/a/notifications")
            .SetRequestHeader("Host", "story.kakao.com")
            .SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; rv:35.0) Gecko/20100101 Firefox/35.0")
            .SetRequestHeader("Accept", "application/json")
            .SetRequestHeader("Accept-Language", "ko")
            .SetRequestHeader("Connection", "keep-alive")
            .SetRequestHeader("X-Kakao-ApiLevel", "49")
            .SetRequestHeader("X-Kakao-DeviceInfo", "web:-;-;-")
            .SetRequestHeader("X-Requested-With", "XMLHttpRequest")
            .SetRequestHeader("Cookie", loginCookie)
            .SetRequestHeader("Referer", "https://story.kakao.com/")
            .Send()
        End With

        Dim httpResult As String = System.Text.Encoding.UTF8.GetString(IE.ResponseBody)

        Dim notyJson As JArray = JArray.Parse(httpResult)
        Dim result As String = notyJson.Item(0).Item("id")
        NotyID = result
    End Sub

    Private Sub NotifyBalloon(str As String, profURL As String, profID As String, isSNoty As Boolean)
        If chkCNoty.Checked = True Then
            With notifyIcon
                .BalloonTipIcon = ToolTipIcon.None
                .BalloonTipTitle = "Story Notifier / " & Now
                .BalloonTipText = str
                .ShowBalloonTip(100)
            End With
        Else
            ShowInactiveTopmost(New frmNoty(str, chkProfile.Checked, profURL, profID, isSNoty, chkSound.Checked))
        End If

        writeLog(str)
    End Sub

    Private Sub notifyIcon_BalloonTipClicked(sender As Object, e As EventArgs) Handles notifyIcon.BalloonTipClicked
        Process.Start("https://story.kakao.com/" & NotyURL)
    End Sub

    Public Sub writeLog(str As String)
        If chkLog.Checked = True Then
            Dim SW As StreamWriter
            SW = My.Computer.FileSystem.OpenTextFileWriter("logs.txt", True)
            SW.WriteLine("[" & Now & "] / " & str)
            SW.Close()
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If File.Exists("config.json") Then
            Dim config As String = File.ReadAllText("config.json")
            Dim configJson As JObject = JObject.Parse(config)
            timerNoty.Interval = Int(configJson.Item("refreshTime")) * 1000
            chkLog.Checked = configJson.Item("writeLogs")
            txtTime.Text = configJson.Item("refreshTime")
            chkCNoty.Checked = configJson.Item("winNoty")
            chkProfile.Checked = configJson.Item("profileLoad")
            chkSound.Checked = configJson.Item("sound")
            colorValue = Color.FromArgb(configJson.Item("colorR"), configJson.Item("colorG"), configJson.Item(("colorB")))
            pnlSetColor.BackColor = colorValue
        End If

        initializeNotify()
        timerNoty.Enabled = True
    End Sub

    Private Sub timerNoty_Tick(sender As Object, e As EventArgs) Handles timerNoty.Tick
        Notify()
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        timerNoty.Interval = Int(txtTime.Text) * 1000


        Dim configJson As New JObject
        configJson.Add("refreshTime", txtTime.Text)
        configJson.Add("writeLogs", chkLog.Checked)
        configJson.Add("winNoty", chkCNoty.Checked)
        configJson.Add("profileLoad", chkProfile.Checked)
        configJson.Add("sound", chkSound.Checked)
        configJson.Add("colorR", colorValue.R.ToString)
        configJson.Add("colorG", colorValue.G.ToString)
        configJson.Add("colorB", colorValue.B.ToString)
        File.WriteAllText("config.json", configJson.ToString)

    End Sub

    Private Sub timerConnect_Tick(sender As Object, e As EventArgs) Handles timerConnect.Tick
        Try
            With IE
                .Open("GET", "https://story.kakao.com/a/notifications")
                .SetRequestHeader("Host", "story.kakao.com")
                .SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; rv:35.0) Gecko/20100101 Firefox/35.0")
                .SetRequestHeader("Accept", "application/json")
                .SetRequestHeader("Accept-Language", "ko")
                .SetRequestHeader("Connection", "keep-alive")
                .SetRequestHeader("X-Kakao-ApiLevel", "31")
                .SetRequestHeader("X-Kakao-DeviceInfo", "web:-;-;-")
                .SetRequestHeader("X-Requested-With", "XMLHttpRequest")
                .SetRequestHeader("Cookie", loginCookie)
                .SetRequestHeader("Referer", "https://story.kakao.com/")
                .Send()
            End With
        Catch ex As Exception
            Exit Sub
        End Try

        timerConnect.Enabled = False
        timerNoty.Enabled = True
    End Sub


    Private Sub pnlSetColor_Click(sender As Object, e As EventArgs) Handles pnlSetColor.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            colorValue = ColorDialog1.Color
            pnlSetColor.BackColor = colorValue
        End If
    End Sub

    Private Sub labelSetColor_Click(sender As Object, e As EventArgs) Handles labelSetColor.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            colorValue = ColorDialog1.Color
            pnlSetColor.BackColor = colorValue
        End If
    End Sub

End Class