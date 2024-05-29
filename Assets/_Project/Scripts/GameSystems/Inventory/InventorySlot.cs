using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : Slot, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemDescriptionText;
    [SerializeField] private TMP_Text _itemsCountText;


    private IStorageable _itemData;
    private int _itemsCount;

    public override IStorageable ItemData 
    { 
        get => _itemData;
        set
        {
            _itemData = value;

            ChangeText();
        } 
    }
    public int ItemsCount 
    {
        get => _itemsCount;
        set
        {
            _itemsCount = value;

            ChangeText();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    private void Start()
    {
        GameObject icon = Instantiate(ItemData.Icon, transform);
        icon.transform.SetSiblingIndex(0);
    }

    private void ChangeText()
    {
        _itemNameText.text = ItemData.Name;
        _itemDescriptionText.text = ItemData.Description;
        _itemsCountText.text = ItemsCount.ToString();
    }

}
