using System;
using UnityEngine;

[Serializable]
public struct DataAndCount
{
    [SerializeField] private ResourceData _data;
    [SerializeField] private int _count;

    public ResourceData Data { get => _data; set => _data = value; }
    public int Count { get => _count; set => _count = value; }
}
