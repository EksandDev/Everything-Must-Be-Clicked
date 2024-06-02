using UnityEngine;
using Zenject;

public class Workbench : MonoBehaviour, IInteractable, INameable
{
    [SerializeField] private CraftData[] _itemsAbleToCraft;

    private CraftingModel _craftingModel;
    private string _name = "Workbench";

    public string Name => _name;

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