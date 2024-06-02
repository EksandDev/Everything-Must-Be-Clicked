using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class CraftingView : View
{
    [SerializeField] private GameObject _craftingCanvas;
    [SerializeField] private Transform _slotsGrid;
    [SerializeField] private CraftingSlot _slotPrefab;

    private Interactor _interactor;
    private FirstPersonController _controller;
    private CraftingModel _craftingModel;

    public Transform SlotsGrid => _slotsGrid;
    public CraftingSlot SlotPrefab => _slotPrefab;

    #region Zenject init
    [Inject]
    private void Initialize(Interactor interactor, FirstPersonController controller,
        CraftingModel craftingModel)
    {
        _interactor = interactor;
        _controller = controller;
        _craftingModel = craftingModel;
    }
    #endregion

    public override void SwitchInterface()
    {
        base.SwitchInterface();

        StartCoroutine(TryCloseInterface());
    }

    private void Awake()
    {
        SystemCanvas = _craftingCanvas;
        SystemSlotsGrid = _slotsGrid;
        SystemSlotPrefab = _slotPrefab;
        Interactor = _interactor;
        Controller = _controller;
    }

    private IEnumerator TryCloseInterface()
    {
        while (SystemCanvas.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
            {
                base.SwitchInterface();

                _craftingModel.DeleteAllSlots();
            }

            yield return null;
        }
    }
}