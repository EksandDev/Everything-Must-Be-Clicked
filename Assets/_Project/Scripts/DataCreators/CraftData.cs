using UnityEngine;

[CreateAssetMenu(fileName = "CraftData", menuName = "Data/New CraftData")]
public class CraftData : ScriptableObject
{
    [SerializeField] private DamageBoostData _resultItemData;
    [SerializeField] private DataAndCount[] _dataAndTheirCount;

    public DamageBoostData ResultItemData { get => _resultItemData; }
    public DataAndCount[] DataAndTheirCount { get => _dataAndTheirCount; }
}
