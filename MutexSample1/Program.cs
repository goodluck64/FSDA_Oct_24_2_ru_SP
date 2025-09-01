var mutex = new Mutex(true, "MutexSample1");

Console.WriteLine("Waiting...");
Console.ReadLine();

mutex.ReleaseMutex();

Console.ReadLine();