using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryModel
{
    private InventoryView _inventoryView;
    private List<InventorySlot> _slots = new();

    #region Zenject init
    [Inject]
    private void Initialize(InventoryView inventoryView)
    {
        _inventoryView = inventoryView;
    }
    #endregion

    public void ReceiveItem(IStorageable data, int itemsCount)
    {
        if (!GetFullness())
            CreateSlot(data, itemsCount);

        else
        {
            foreach (var slot in _slots)
            {
                if (slot.ItemData.ID != data.ID)
                    continue;

                slot.ItemsCount += itemsCount;
                return;
            }

            CreateSlot(data, itemsCount);
        }
    }

    public bool TryRemoveItems(DataAndCount[] dataAndTheirCountToRemove)
    {
        if (!GetFullness())
            return false;

        else
        {
            List<InventorySlot> slotsWithItemsToRemove = new();

            foreach (var slot in _slots)
            {
                foreach (var item in dataAndTheirCountToRemove)
                {
                    if (slot.ItemData.ID != item.Data.ID || slot.ItemsCount < item.Count)
                        continue;

                    slotsWithItemsToRemove.Add(slot);
                    break;
                }
            }

            if (slotsWithItemsToRemove.Count == dataAndTheirCountToRemove.Length)
            {
                List<InventorySlot> slotsToDestroy = new();

                foreach (var slot in slotsWithItemsToRemove)
                {
                    foreach (var item in dataAndTheirCountToRemove)
                    {
                        if (slot.ItemData.ID != item.Data.ID)
                            continue;

                        slot.ItemsCount -= item.Count;

                        if (slot.ItemsCount <= 0)
                            slotsToDestroy.Add(slot);

                        break;
                    }
                }

                if (slotsToDestroy.Count > 0)
                {
                    foreach (var slot in slotsToDestroy)
                    {
                        _slots.Remove(slot);
                        Object.Destroy(slot.gameObject);
                    }
                }

                return true;
            }
        }

        return false;
    }

    public bool GetFullness()
    {
        if (_slots.Count == 0)
            return false;

        return true;
    }

    private void CreateSlot(IStorageable data, int ItemsCount)
    {
        InventorySlot newSlot = Object.Instantiate(_inventoryView.SlotPrefab, _inventoryView.SlotsGrid);
        newSlot.ItemData = data;
        newSlot.ItemsCount = ItemsCount;
        _slots.Add(newSlot);
    }
}