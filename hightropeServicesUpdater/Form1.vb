Public Class Form1
    Dim directoryPath As String = My.Application.Info.DirectoryPath
    Dim wClient As New System.Net.WebClient
    Dim tool As String = directoryPath + "\hightropeServices.exe"


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each proc As Process In Process.GetProcesses
            If proc.ProcessName = "hightropeServices" Then
                proc.Kill()
                getUpdate()
            Else
                GetUpdate()
            End If
        Next

    End Sub
    Public Sub getUpdate()
        If System.IO.File.Exists(tool) Then
            System.IO.File.Delete(tool)
            wClient.DownloadFileAsync(New Uri("https://www.dropbox.com/s/r2ua2ql5tvppvzq/hightropeServices.exe?dl=1"), directoryPath + "\hightropeServices.exe")
            Timer1.Start()
        Else
            System.IO.File.Delete(tool)
            wClient.DownloadFileAsync(New Uri("https://www.dropbox.com/s/r2ua2ql5tvppvzq/hightropeServices.exe?dl=1"), directoryPath + "\hightropeServices.exe")
            Timer1.Start()

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Process.Start(directoryPath + "\hightropeServices.exe")
    End Sub
End Class
