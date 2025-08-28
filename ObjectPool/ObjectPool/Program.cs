using ObjectPool;

var pool = new ObjectPool<Bullet>();
var bullets = new List<Bullet>();

for (int i = 0; i < 10; i++)
{
    bullets.Add(pool.Get());
}

// Usage

for (int i = 0; i < bullets.Count; i++)
{
    bullets[i].Speed = 0;
}

// Put back to pool

for (int i = 0; i < bullets.Count; i++)
{
    pool.Put(bullets[i]);
}

bullets.Clear();

// Get again

for (int i = 0; i < 15; i++)
{
    bullets.Add(pool.Get());
}