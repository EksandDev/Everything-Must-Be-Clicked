using DG.Tweening;
using UnityEngine;
using Zenject;

public class ClickableObject : MonoBehaviour, IDamageable, INameable
{
    [SerializeField] private ClickableObjectData _data;

    public string Name => _data.Name;
    public int Health
    {
        get => _health;
        set
        {
            _health = value;

            AnimateDamage();

            if (_health <= 0)
                Death();
        }
    }

    private InventoryModel _inventoryService;
    private int _health;

    #region Zenject init
    [Inject]
    private void Inititalize(InventoryModel inventoryService)
    {
        _inventoryService = inventoryService;
    }
    #endregion

    private void Start()
    {
        _health = _data.MaxHealth;
    }

    private void Death()
    {
        _inventoryService.ReceiveItem(_data.Drop, _data.DropCount);
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