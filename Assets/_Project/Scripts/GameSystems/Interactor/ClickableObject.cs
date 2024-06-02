using DG.Tweening;
using UnityEngine;
using Zenject;

public class ClickableObject : MonoBehaviour, IDamageable, INameable
{
    [SerializeField] private ClickableObjectData _data;
    [SerializeField] private Effect _hitEffect;

    private InventoryModel _inventory;
    private HitEffectObjectPool _hitEffectObjectPool;
    private int _health;

    public string Name => _data.Name;
    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            _hitEffectObjectPool.CreateEffect(transform.position);

            AnimateDamage();

            if (_health <= 0)
                Death();
        }
    }

    #region Zenject init
    [Inject]
    private void Inititalize(InventoryModel inventory, HitEffectObjectPool hitEffectObjectPool)
    {
        _inventory = inventory;
        _hitEffectObjectPool = hitEffectObjectPool;
    }
    #endregion

    private void Start()
    {
        _health = _data.MaxHealth;
    }

    private void Death()
    {
        _inventory.ReceiveItem(_data.Drop, _data.DropCount);
        Destroy(gameObject);
    }

    private void AnimateDamage()
    {
        DOTween.Sequence().
            Append(transform.DOScale(0.8f, 0.1f)).
            Append(transform.DOScale(1, 0.1f)).
            SetLink(gameObject);
    }
}