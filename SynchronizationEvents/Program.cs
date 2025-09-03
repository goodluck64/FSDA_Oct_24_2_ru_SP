using var autoResetEvent = new AutoResetEvent(true);

//// autoResetEvent.Set(); -> true
//// autoResetEvent.Reset(); -> false

// Console.WriteLine("1");
// autoResetEvent.WaitOne(); // true -> false
// Console.WriteLine("2");
// autoResetEvent.Set(); // false -> true
// autoResetEvent.WaitOne();
// Console.WriteLine("3");


// using var manualResetEvent = new ManualResetEvent(true);
//
// Console.WriteLine("1");
// manualResetEvent.WaitOne(); // true
//
// manualResetEvent.Reset(); // true -> false
//
// Console.WriteLine("2");
// manualResetEvent.WaitOne();
// Console.WriteLine("3");
// manualResetEvent.WaitOne();
// Console.WriteLine("4");

var globalResetEvent = new ManualResetEvent(false);
var counterResetEvent = new ManualResetEvent(true);

ThreadPool.QueueUserWorkItem(_ =>
{
    int i = 0;

    while (true)
    {
        counterResetEvent.WaitOne();
        Console.WriteLine(i++);

        Thread.Sleep(100);
    }
});

ThreadPool.QueueUserWorkItem(_ =>
{
    bool flag = true;
    bool loopFlag = true;
    
    while (loopFlag)
    {
        var action = Console.ReadKey(true);

        switch (action.Key)
        {
            case ConsoleKey.Q:
                globalResetEvent.Set();
                loopFlag = false;
                break;
            case ConsoleKey.C:
                if (flag)
                {
                    counterResetEvent.Reset();
                }
                else
                {
                    counterResetEvent.Set();
                }

                flag = !flag;

                break;
        }
    }
});

Console.WriteLine($"ContextIsNull: {SynchronizationContext.Current is null}");

globalResetEvent.WaitOne();