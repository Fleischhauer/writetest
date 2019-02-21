Module Program

    Const LOG_PATH As String = "log.txt"
    Public randomGenerator As Random
    Public writer As IO.StreamWriter
    Public counter As Integer = 0

    Sub Main()
        If IO.File.Exists(LOG_PATH) Then
            Try
                writer = New IO.StreamWriter(LOG_PATH)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Console.ReadKey()
                Return
            End Try
        Else
            Try
                writer = IO.File.CreateText(LOG_PATH)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Console.ReadKey()
                Return
            End Try

        End If

        randomGenerator = New Random()

        Task.Delay(2000).GetAwaiter().GetResult()

        StartEmulators().GetAwaiter().GetResult()
    End Sub

    Async Function StartEmulators() As Task
        Dim t1 = EventEmulator(1)
        Dim t2 = EventEmulator(2)
        Dim t3 = EventEmulator(3)
        Dim t4 = EventEmulator(4)

        Await Task.Delay(Threading.Timeout.Infinite)
    End Function

    Async Function EventEmulator(number As Integer) As Task
        Do
            Dim randomDelay As Integer = randomGenerator.Next(100)
            Await Task.Delay(randomDelay)
            counter += 1
            Logger($"{DateTime.Now,-19} {counter} Test Log message. Emulator{number} The delay was {randomDelay} ms.")
        Loop
    End Function

    Sub Logger(text As String)
        Try
            Console.WriteLine(text)
            writer.WriteLineAsync(text)
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(ex.Message)
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
End Module
