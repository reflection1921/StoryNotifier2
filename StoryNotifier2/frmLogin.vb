Imports System.Runtime.InteropServices
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class frmLogin
    Dim IE As New WinHttp.WinHttpRequest
    Dim Version As Integer = "21"

    <DllImport("wininet.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function InternetGetCookieEx(ByVal pchURL As String, ByVal pchCookieName As String, ByVal pchCookieData As StringBuilder, ByRef pcchCookieData As UInteger, ByVal dwFlags As Integer, ByVal lpReserved As IntPtr) As Boolean
    End Function

    Const INTERNET_COOKIE_HTTPONLY As Integer = 8192

    Public Function GetGlobalCookies(ByVal uri As String) As String
        Dim datasize As UInteger = 1024
        Dim cookieData As StringBuilder = New StringBuilder(CInt(datasize))
        If InternetGetCookieEx(uri, Nothing, cookieData, datasize, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero) AndAlso cookieData.Length > 0 Then
            Return cookieData.ToString()
        Else
            Return Nothing
        End If
    End Function

    Private Sub webLogin_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles webLogin.DocumentCompleted
        If webLogin.Url.Host = "story.kakao.com" Then
            Dim tmpCookies As String = GetGlobalCookies(webLogin.Document.Url.AbsoluteUri)
            If InStr(tmpCookies, "_kawlt=") Then

                loginCookie = tmpCookies

                frmMain.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '//frmNoty.Show()
        IE.Open("GET", "http://chihaya.kr/snoty/version/version.txt")
        IE.Send()

        If Int(IE.ResponseText) > Version Then
            If MsgBox("새 버전이 존재합니다. 프로그램을 다운로드 하시겠습니까?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Story Notifier 2") = MsgBoxResult.Yes Then
                Process.Start("explorer.exe", "http://chihaya.kr")
            End If
        End If
    End Sub


End Class
