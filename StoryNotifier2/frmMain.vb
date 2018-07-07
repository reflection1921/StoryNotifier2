Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class frmMain
    Private IE As New WinHttp.WinHttpRequest

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
        MsgBox("Developed by Reflection(2016-2018)", vbInformation, "Story Notifier")
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
                .SetRequestHeader("X-Kakao-ApiLevel", "43")
                .SetRequestHeader("X-Kakao-DeviceInfo", "web:-;-;-")
                .SetRequestHeader("X-Requested-With", "XMLHttpRequest")
                .SetRequestHeader("Cookie", loginCookie)
                .SetRequestHeader("Referer", "https://story.kakao.com/")
                .Send()
            End With
        Catch ex As Exception
            NotifyBalloon("인터넷에 연결되어 있지 않습니다. 인터넷에 연결되면 자동 재시작 됩니다.")
            timerNoty.Enabled = False
            timerConnect.Enabled = True
        End Try

        Dim httpResult As String = IE.ResponseText

        If httpResult = Nothing Then
            NotifyBalloon("카카오스토리에서 로그아웃 되어 알림이 종료됩니다. 재로그인 하세요.")
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

        Dim message As String = notyJson.Item(0).Item("message")
        Dim content As String = notyJson.Item(0).Item("content")
        Dim scheme As String = notyJson.Item(0).Item("scheme")
        NotyURL = Split(Split(scheme, "kakaostory://activities/")(1), "?")(0)
        NotyURL = NotyURL.Replace(".", "/")

        NotifyBalloon(message & " " & content)
    End Sub

    Public Sub initializeNotify()
        With IE
            .Open("GET", "https://story.kakao.com/a/notifications")
            .SetRequestHeader("Host", "story.kakao.com")
            .SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; rv:35.0) Gecko/20100101 Firefox/35.0")
            .SetRequestHeader("Accept", "application/json")
            .SetRequestHeader("Accept-Language", "ko")
            .SetRequestHeader("Connection", "keep-alive")
            .SetRequestHeader("X-Kakao-ApiLevel", "43")
            .SetRequestHeader("X-Kakao-DeviceInfo", "web:-;-;-")
            .SetRequestHeader("X-Requested-With", "XMLHttpRequest")
            .SetRequestHeader("Cookie", loginCookie)
            .SetRequestHeader("Referer", "https://story.kakao.com/")
            .Send()
        End With

        Dim httpResult As String = IE.ResponseText

        Dim notyJson As JArray = JArray.Parse(httpResult)
        Dim result As String = notyJson.Item(0).Item("id")
        NotyID = result
    End Sub

    Private Sub NotifyBalloon(str As String)
        With notifyIcon
            .BalloonTipIcon = ToolTipIcon.None
            .BalloonTipTitle = "Story Notifier / " & Now
            .BalloonTipText = str
            .ShowBalloonTip(100)
        End With

        writeLog(str)
    End Sub

    Private Sub notifyIcon_BalloonTipClicked(sender As Object, e As EventArgs) Handles notifyIcon.BalloonTipClicked
        Process.Start("explorer.exe", "https://story.kakao.com/" & NotyURL)
    End Sub

    Private Sub chkLog_CheckedChanged(sender As Object, e As EventArgs) Handles chkLog.CheckedChanged
        Dim configJson As New JObject
        configJson.Add("refreshTime", txtTime.Text)
        configJson.Add("writeLogs", chkLog.Checked)
        File.WriteAllText("config.json", configJson.ToString)
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
        File.WriteAllText("config.json", configJson.ToString)
    End Sub
End Class