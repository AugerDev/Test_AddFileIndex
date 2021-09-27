Imports System
Imports System.IO
Imports System.Net.Http
Imports System.Net.Http.Headers

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
        AddFileIndex.Wait()
    End Sub

    Public Async Function AddFileIndex() As Task
        Dim AP = New AugerModel.Model.FileManager.AccessPermission()
        Dim FI As New AugerModel.Model.FileManager.FileManagerDirectoryContent()
        Dim appUrl = "http://localhost:1080/api"
        Dim Finfo As New FileInfo("Document/- AL216_NS - Drainage Investigation Report.pdf")
        FI.Name = Finfo.Name
        FI.DateModified = Finfo.LastWriteTime
        FI.DateCreated = Finfo.CreationTime
        FI.HasChild = False
        FI.Type = Finfo.Extension
        FI.IsFile = True
        FI.FilterPath = Finfo.FullName
        FI.Path = Finfo.FullName
        FI.Permission = AP
        Dim d = New With {Key .jn = "102096", .path = "\\augerjobstorage.file.core.windows.net\\activejobfolders\\102096", .trimUNCPath = True, .fileData = FI}
        Dim d2 As String = System.Text.Json.JsonSerializer.Serialize(d)

        Dim Buffer = System.Text.Encoding.UTF8.GetBytes(d2)
        Dim byteContent = New ByteArrayContent(Buffer)
        byteContent.Headers.ContentType = New MediaTypeHeaderValue("application/json")
        'System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(se As Object, cert As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslerror As System.Net.Security.SslPolicyErrors) True

        Dim Token As String = ""
        Dim http As New HttpClient
        http.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token)
        Try
            Dim resp = Await http.PostAsync(appUrl + "/FileIndex/AddFileIndex", byteContent)
            If resp.StatusCode Then

            End If

        Catch ex As Exception

        End Try
    End Function


End Module
