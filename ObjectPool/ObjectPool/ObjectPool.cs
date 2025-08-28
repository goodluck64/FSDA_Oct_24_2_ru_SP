namespace ObjectPool;

class ObjectPool<T>
    where T : IResetable, new()
{
    private readonly Stack<T> _pool = new Stack<T>();

    public T Get()
    {
        if (_pool.Count == 0)
        {
            return new T();
        }

        Console.WriteLine("ObjectPool<T>::Get()");

        return _pool.Pop();
    }

    public void Put(T @object)
    {
        _pool.Push(@object);

        @object.Reset();
    }
}