namespace ObjectPool;

class Bullet : IResetable
{
    public Bullet()
    {
        Console.WriteLine("Bullet::Bullet()");
    }

    public int Speed { get; set; }


    public void Reset()
    {
        Speed = DefaultSpeed;

        Console.WriteLine("IResetable::Reset()");
    }

    private const int DefaultSpeed = 100;
}