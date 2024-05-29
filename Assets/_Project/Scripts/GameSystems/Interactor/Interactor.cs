using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Interactor : MonoBehaviour
{
    private DamageInteractor _damageInteractor;
    private ShowTextInteractor _viewTextInteractor;
    private CraftingInteractor _craftingInteractor;
    private List<IInteractorSubsystem> _interactorSubsystems = new();
    private int _rayDistance = 3;
    private bool _isActive = true;

    public bool IsActive {  get => _isActive; set => _isActive = value; }

    #region Zenject init
    [Inject]
    private void Initialize(DamageInteractor damageInteractor, ShowTextInteractor viewTextInteractor,
        CraftingInteractor craftingInteractor)
    {
        _damageInteractor = damageInteractor;
        _viewTextInteractor = viewTextInteractor;
        _craftingInteractor = craftingInteractor;
    }
    #endregion

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayDistance) && IsActive &&
            hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            if (_interactorSubsystems.Count == 0)
                return;

            foreach (var subsystem in _interactorSubsystems)
                subsystem.TryInteract(hit.collider);
        }

        else
            _viewTextInteractor.TryVanishText();
    }

    private void Awake()
    {
        InitializeSubsystems();
    }

    private void InitializeSubsystems()
    {
        _interactorSubsystems.Add(_damageInteractor);
        _interactorSubsystems.Add(_viewTextInteractor);
        _interactorSubsystems.Add(_craftingInteractor);
    }
}