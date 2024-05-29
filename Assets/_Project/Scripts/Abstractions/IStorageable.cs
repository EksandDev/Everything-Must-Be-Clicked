using UnityEngine;

public interface IStorageable
{
    public string Name { get; }
    public string Description { get; }
    public GameObject Icon { get; }
    public string ID { get; }
}