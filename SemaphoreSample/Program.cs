var semaphore = new Semaphore(3, 3); // SemaphoreSlim


for (int i = 0; i < 9; i++)
{
    ThreadPool.QueueUserWorkItem(_ => { PrintCounter(); });
}

Console.Read();

void PrintCounter()
{
    Console.WriteLine("void PrintCounter::PrintCounter();");

    semaphore.WaitOne();

    Console.WriteLine("Entering...");

    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine($"[Id:{Thread.CurrentThread.ManagedThreadId}]: {i}");
        Thread.Sleep(500 + Random.Shared.Next(100, 500));
    }

    Console.WriteLine("Exiting...");
    semaphore.Release();
}