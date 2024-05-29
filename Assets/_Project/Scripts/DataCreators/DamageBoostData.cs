using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/New ItemData")]
public class DamageBoostData : ScriptableObject, IStorageable
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private GameObject _icon;
    [SerializeField] private int _damageBoost;
    [SerializeField] private string _id;

    public string Name => _name;
    public string Description => _description;
    public GameObject Icon => _icon;
    public int DamageBoost => _damageBoost;
    public string ID => _id;
}
