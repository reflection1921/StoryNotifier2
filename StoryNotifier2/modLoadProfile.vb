Imports System.IO

Module modLoadProfile

    Private IE As New WinHttp.WinHttpRequest

    Public Sub LoadProfile(url As String, profStoryID As String, pBox As PictureBox)

        IE.Open("GET", url)
        IE.SetRequestHeader("Referer", "https://story.kakao.com/" & profStoryID & "/profile/photo")
        IE.Send()

        Dim iBytes As Byte() = IE.ResponseBody

        Dim stream As New MemoryStream(iBytes)
        pBox.Image = Image.FromStream(stream)

    End Sub
End Module
