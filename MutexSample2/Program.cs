int count = 0;

var mutex = Mutex.OpenExisting("MutexSample1");

while (true)
{
    mutex.WaitOne();
    Console.WriteLine(count++);
    Thread.Sleep(100);
}

Console.Read();