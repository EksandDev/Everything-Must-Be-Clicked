using UnityEngine;
using Zenject;

public class DamageInteractor : IInteractorSubsystem
{
    private PlayerStats _player;

    #region Zenject init
    [Inject]
    private void Initialize(PlayerStats playerStats)
    {
        _player = playerStats;
    }
    #endregion

    public void TryInteract(Collider hitCollider)
    {
        if (Input.GetMouseButtonDown(0) &&
            hitCollider.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.Health -= _player.Damage;
        }
    }
}