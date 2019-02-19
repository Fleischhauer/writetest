Imports System

Module Program

    Const LOG_PATH As String = "log.txt"
    Public counter As Integer
    Public randomGenerator As Random

    Sub Main()
        Try
            IO.File.Create(LOG_PATH)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadKey()
            Return
        End Try

        randomGenerator = New Random()
        counter = 0

        StartEmulators().GetAwaiter().GetResult()
    End Sub

    Async Function StartEmulators() As Task
        Await Task.Delay(2000)

        Dim t1 = EventEmulator1()
        Dim t2 = EventEmulator2()
        Dim t3 = EventEmulator3()
        Dim t4 = EventEmulator4()

        Console.ReadKey()
        Return
    End Function

    Async Function EventEmulator1() As Task
        Do
            Dim randomDelay As Integer = randomGenerator.Next(100)
            Await Task.Delay(randomDelay)
            Logger($"{DateTime.Now,-19} {counter + 1,5} Test Log message. Emulator1 The delay was {randomDelay} ms.")
        Loop
    End Function
    Async Function EventEmulator2() As Task
        Do
            Dim randomDelay As Integer = randomGenerator.Next(100)
            Await Task.Delay(randomDelay)
            Logger($"{DateTime.Now,-19} {counter + 1,5} Test Log message. Emulator2 The delay was {randomDelay} ms.")
        Loop
    End Function
    Async Function EventEmulator3() As Task
        Do
            Dim randomDelay As Integer = randomGenerator.Next(100)
            Await Task.Delay(randomDelay)
            Logger($"{DateTime.Now,-19} {counter + 1,5} Test Log message. Emulator3 The delay was {randomDelay} ms.")
        Loop
    End Function
    Async Function EventEmulator4() As Task
        Do
            Dim randomDelay As Integer = randomGenerator.Next(100)
            Await Task.Delay(randomDelay)
            Logger($"{DateTime.Now,-19} {counter + 1,5} Test Log message. Emulator4 The delay was {randomDelay} ms.")
        Loop
    End Function

    Sub Logger(text As String)
        Try
            Console.WriteLine(text)
            IO.File.AppendAllText(LOG_PATH, text & vbCrLf)
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(ex.Message)
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
End Module
