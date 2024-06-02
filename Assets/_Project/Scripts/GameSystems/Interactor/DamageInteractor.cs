using UnityEngine;
using Zenject;

public class DamageInteractor : IInteractorSubsystem
{
    private PlayerStats _player;
    private TargetHealthSlider _healthSlider;

    #region Zenject init
    [Inject]
    private void Initialize(PlayerStats playerStats, TargetHealthSlider healthSlider)
    {
        _player = playerStats;
        _healthSlider = healthSlider;
    }
    #endregion

    public void TryInteract(Collider hitCollider)
    {
        if (hitCollider.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            TrySetActive(true);

            _healthSlider.MaxHealth = damageable.MaxHealth;
            _healthSlider.Health = damageable.Health;

            if (Input.GetMouseButtonDown(0))
                damageable.Health -= _player.Damage;
        }
    }

    public void TrySetActive(bool state)
    {
        if (state && _healthSlider.gameObject.activeInHierarchy)
            return;

        else if (!state && !_healthSlider.gameObject.activeInHierarchy)
            return;

        _healthSlider.gameObject.SetActive(state);
    }
}