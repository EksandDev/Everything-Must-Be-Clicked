using UnityEngine;
using Zenject;

public class Workbench : MonoBehaviour, IInteractable
{
    [SerializeField] private CraftData[] _itemsAbleToCraft;

    private CraftingModel _craftingModel;

    #region Zenject init
    [Inject]
    private void Initialize(CraftingModel craftingModel)
    {
        _craftingModel = craftingModel;
    }
    #endregion

    public void SendDataToCraftingModel()
    {
        _craftingModel.ReceiveDataFromCraftingTable(_itemsAbleToCraft);
    }
}