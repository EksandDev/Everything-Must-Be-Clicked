using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CraftingModel
{
    private InventoryModel _inventory;
    private CraftingView _craftingView;
    private Message _message;
    private DiContainer _diContainer;
    private List<CraftingSlot> _slots = new();

    #region Zenject init
    [Inject]
    private void Initialize(InventoryModel inventory, CraftingView craftingView, Message message,
        DiContainer container)
    {
        _inventory = inventory;
        _craftingView = craftingView;
        _message = message;
        _diContainer = container;
    }
    #endregion

    public void ReceiveDataFromCraftingTable(CraftData[] craftsData)
    {
        foreach (var craftData in craftsData)
        {
            CreateSlot(craftData);
        }

        _craftingView.SwitchInterface();
    }

    public bool TryCraftItem(CraftData craftData, int count)
    {
        if (!_inventory.TryRemoveItems(craftData.DataAndTheirCount))
        {
            _message.Send("You can't craft this item");
            return false;
        }

        else
        {
            _inventory.ReceiveItem(craftData.ResultItemData, count);
            _message.Send($"You just crafted: {craftData.ResultItemData.Name}");
            return true;
        }
    }

    public void DeleteAllSlots()
    {
        foreach (var slot in _slots)
            Object.Destroy(slot.gameObject);

        _slots.Clear();
    }

    private void CreateSlot(CraftData craftData)
    {
        var newSlot = _diContainer.InstantiatePrefabForComponent<CraftingSlot>
            (_craftingView.SlotPrefab, _craftingView.SlotsGrid);
        newSlot.CraftData = craftData;
        _slots.Add(newSlot);
    }
}