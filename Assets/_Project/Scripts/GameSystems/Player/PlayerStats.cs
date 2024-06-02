public class PlayerStats
{
    public int Damage 
    { 
        get => _damage;
        set
        {
            if (value <= 0)
                return;

            _damage = value;
        }
    }

    private int _damage = 2;
}