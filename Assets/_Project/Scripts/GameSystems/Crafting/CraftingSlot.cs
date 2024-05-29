using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class CraftingSlot : Slot, IPointerClickHandler
{
    [SerializeField] private TMP_Text _itemNameText;

    private CraftingModel _craftingModel;
    private CraftData _craftData;

    public override IStorageable ItemData { get => _craftData.ResultItemData; }
    public CraftData CraftData { get => _craftData; set => _craftData = value; }

    #region Zenject init
    [Inject]
    private void Initialize(CraftingModel craftingModel)
    {
        _craftingModel = craftingModel;
    }
    #endregion

    public void OnPointerClick(PointerEventData eventData)
    {
        _craftingModel.TryCraftItem(CraftData, 1);
    }

    private void Start()
    {
        GameObject icon = Instantiate(ItemData.Icon, transform);
        icon.transform.SetSiblingIndex(0);
        _itemNameText.text = ItemData.Name;
    }
}
