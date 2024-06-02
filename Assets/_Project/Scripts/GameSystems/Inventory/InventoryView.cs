using UnityEngine;
using Zenject;

public class InventoryView : View
{
    [SerializeField] private GameObject _inventoryCanvas;
    [SerializeField] private Transform _slotsGrid;
    [SerializeField] private InventorySlot _slotPrefab;

    private Interactor _interactor;
    private FirstPersonController _controller;

    public Transform SlotsGrid => _slotsGrid;
    public InventorySlot SlotPrefab => _slotPrefab;

    #region Zenject init
    [Inject]
    private void Initialize(Interactor interactor, FirstPersonController controller)
    {
        _interactor = interactor;
        _controller = controller;
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            SwitchInterface();
    }

    private void Awake()
    {
        SystemCanvas = _inventoryCanvas;
        SystemSlotsGrid = _slotsGrid;
        SystemSlotPrefab = _slotPrefab;
        Interactor = _interactor;
        Controller = _controller;
    }
}