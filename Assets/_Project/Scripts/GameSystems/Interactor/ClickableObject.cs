using DG.Tweening;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
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

            _audioManager.PlayWithRandomPitch(_audioManager.HitSound, 1, 3, _audioSource);
            AnimateDamage();

            if (_health <= 0)
                Death();
        }
    }

    private InventoryModel _inventory;
    private int _health;

    private AudioSource _audioSource;
    private AudioManager _audioManager;

    #region Zenject init
    [Inject]
    private void Inititalize(InventoryModel inventory, AudioManager audioManager)
    {
        _inventory = inventory;
        _audioManager = audioManager;
    }
    #endregion

    private void Start()
    {
        _health = _data.MaxHealth;
        _audioSource = GetComponent<AudioSource>();
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