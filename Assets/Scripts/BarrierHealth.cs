public class BarrierHealth : Health
{
    public void SetHealth(int hits)
    {
        health = hits;
    }

    public override void TakeDamage(int damage)
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}