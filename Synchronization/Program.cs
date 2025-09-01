//// Monitor

// for (int i = 0; i < 2; ++i)
// {
//     ThreadPool.QueueUserWorkItem(_ => { RaceCondition.Increment(); });
// }
//
// Console.Read();
//// RaceCondition
// RaceCondition.ShowCounter();

//// Mutex

// var sample = new MutexSample(4);
//
// sample.Start();
//
// Console.ReadLine();


// 1. addr
// 2. ++
// 3. commit

// = 0x042

// > 0x042
// > 0x042
// > ++

var test = new MultiThreadedListTest(4);


test.Start();

Console.Read();

public static class RaceCondition
{
    private static int _counter;

    public static void Increment()
    {
        Monitor.Enter(_o);

        for (int i = 0; i < 10_000_000; i++)
        {
            _counter++;
        }

        Monitor.Exit(_o);
    }

    private static object _o = new object();

    public static void ShowCounter()
    {
        Console.WriteLine($"Counter:  {_counter}");
    }
}

struct HeavyObject
{
    public decimal _1;
    public decimal _2;
    public decimal _3;
    public decimal _4;
    public decimal _5;
    public decimal _6;
    public decimal _7;
    public decimal _8;
    public decimal _9;
    public decimal _10;
    public decimal _11;
    public decimal _12;
    public decimal _13;
    public decimal _14;
    public decimal _15;
    public decimal _16;
}

public class MultiThreadedListTest
{
    private readonly int _threads;
    private List<HeavyObject> _values = [];

    public MultiThreadedListTest(int threads)
    {
        _threads = threads;
    }

    public void Start()
    {
        for (int i = 0; i < _threads; i++)
        {
            ThreadPool.QueueUserWorkItem(_ => AddElements());
        }
    }

    private void AddElements()
    {
        lock (_o)
        {
            for (int i = 0; i < 10_000; i++)
            {
                _values.Add(new HeavyObject());
            }
        }
    }

    private readonly object _o = new object();
}


public class MutexSample
{
    private readonly int _threads;
    private List<HeavyObject> _values = [];
    private readonly Mutex _mutex;

    public MutexSample(int threads)
    {
        _threads = threads;

        _mutex = new Mutex();
    }

    public void Start()
    {
        for (int i = 0; i < _threads; i++)
        {
            ThreadPool.QueueUserWorkItem(_ => AddElements());
        }
    }

    private void AddElements()
    {
        _mutex.WaitOne();
        
        for (int i = 0; i < 10_000; i++)
        {
            _values.Add(new HeavyObject());
        }

        _mutex.ReleaseMutex();
    }
}