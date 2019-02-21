Imports System

Module Program

    'Const LOG_PATH1 As String = "log.txt"
    Const LOG_PATH2 As String = "log2.txt"

    Public randomGenerator As Random

    Public writer As IO.StreamWriter

    Sub Main()
        If IO.File.Exists(LOG_PATH2) Then
            Try
                writer = New IO.StreamWriter(LOG_PATH2)
            Catch ex As Exception
                Console.WriteLine("Debug 1: " & ex.Message)
                Console.ReadKey()
                Return
            End Try
        Else
            Try
                IO.File.CreateText(LOG_PATH2)
            Catch ex As Exception
                Console.WriteLine("Debug 2: " & ex.Message)
                Console.ReadKey()
                Return
            End Try

        End If

        randomGenerator = New Random()

        StartEmulators().GetAwaiter().GetResult()
    End Sub

    Async Function StartEmulators() As Task
        Await Task.Delay(2000)

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
            Logger($"{DateTime.Now,-19} Test Log message. Emulator{number} The delay was {randomDelay} ms.")
        Loop
    End Function

    Sub Logger(text As String)
        Try
            Console.WriteLine(text)
            writer.WriteLineAsync(text)
            'IO.File.AppendAllText(LOG_PATH1, text & vbCrLf)
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Debug 3: " & ex.Message)
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
End Module
