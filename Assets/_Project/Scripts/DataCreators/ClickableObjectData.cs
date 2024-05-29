using UnityEngine;

[CreateAssetMenu(fileName = "ClickableObjectData", menuName = "Data/New ClickableObjectData")]
public class ClickableObjectData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _maxHealth;
    [SerializeField] private ResourceData _drop;
    [SerializeField] private int _dropCount;

    public string Name => _name;

    public int MaxHealth => _maxHealth;
    public ResourceData Drop => _drop;
    public int DropCount => _dropCount;
}
