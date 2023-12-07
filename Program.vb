Imports System.IO

Module Program
    Sub Main(args As String())

        Dim FI As FileInfo

        Try

            If args.Length < 1 Then
                Console.WriteLine("FileWait, Simple FileSystemWatcher example")
                Console.WriteLine("Usage:")
                Console.WriteLine("     C:\> FileWait <Folder or Filename to monitor>")
                Console.WriteLine("")
                Console.WriteLine("Examples:")
                Console.WriteLine("     C:\> FileWait C:\Temp\*")
                Console.WriteLine("     Any files Created or Changed in C:\Temp\")
                Console.WriteLine("")
                Console.WriteLine("     C:\> FileWait " & """" & "Replay obsReplay.mp4" & """")
                Console.WriteLine("     A specific files in the current folder")
                End
            End If

            FI = New FileInfo(args(0))

            Console.WriteLine("Monitoring: " & FI.FullName)

            Using FSW As New FileSystemWatcher(FI.DirectoryName, FI.Name)
                FSW.NotifyFilter = IO.NotifyFilters.LastWrite
                FSW.WaitForChanged(WatcherChangeTypes.Changed)
            End Using

            Environment.Exit(0)

        Catch ex As Exception

            Console.WriteLine(ex.Message)
            Environment.Exit(-1)

        End Try

    End Sub

End Module
