using UnityEngine;

public abstract class Slot : MonoBehaviour
{
    public virtual IStorageable ItemData { get; set; }
}