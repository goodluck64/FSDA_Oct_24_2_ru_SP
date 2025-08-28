// for (int i = 0; i < 10; ++i)
// {
//     ThreadPool.QueueUserWorkItem(ThreadCallback2, null);
// }
//
// Console.Read();
//
//
// for (int i = 0; i < 10; ++i)
// {
//     ThreadPool.QueueUserWorkItem(ThreadCallback2, null);
// }
//
// Console.Read();

//// Timers


// using Timer = System.Timers.Timer;
//
// var timer = new Timer()
// {
//     Interval = 1000,
//     AutoReset = true,
//     Enabled = true
// };
//
// timer.Elapsed += (sender, eventArgs) =>
// {
//     Console.WriteLine($"Timer: {Thread.CurrentThread.ManagedThreadId}");
// };
//
// Console.WriteLine($"Main: {Thread.CurrentThread.ManagedThreadId}");
//
// timer.Start();
//
//
// while (true)
// {
//     string input = Console.ReadLine()!;
//
//     if (input == "s")
//     {
//         timer.Stop();
//         break;
//     }
// }


//// Create and user threads 

// var threads = new List<Thread>();
//
// for (int i = 0; i < 10; ++i)
// {
//     threads.Add(new Thread(ThreadCallback)
//     {
//         IsBackground = true
//     });
// }
//
// foreach (var thread in threads)
// {
//     thread.Start();
// }
//
// foreach (var thread in threads)
// {
//     thread.Join();
// }

static void ThreadCallback()
{
    for (int i = 0; i < 3; i++)
    {
        // if (Random.Shared.Next(0, 10) == i)
        // {
        //     throw new InvalidOperationException("Crush");
        // }

        Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId} [{i}]");
    }
}

static void ThreadCallback2(object? state)
{
    for (int i = 0; i < 3; i++)
    {
        // if (Random.Shared.Next(0, 10) == i)
        // {
        //     throw new InvalidOperationException("Crush");
        // }

        Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId} [{i}]");
    }
}