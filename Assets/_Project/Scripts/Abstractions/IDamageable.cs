using System.Security.Cryptography;

public interface IDamageable : IInteractable
{
    public int MaxHealth { get; }
    public int Health { get; set; }
}
