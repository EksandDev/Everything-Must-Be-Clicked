using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Data/New ResourceData")]
public class ResourceData : ScriptableObject, IStorageable
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private GameObject _icon;
    [SerializeField] private string _id;

    public string Name => _name;
    public string Description => _description;
    public GameObject Icon => _icon;
    public string ID => _id;
}