using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> _pool;

    public T Prefab { get; private set; }
    public Transform Container { get; set; }

    public ObjectPool(T prefab, int prefabsCount, Transform container = null)
    {
        Prefab = prefab;

        if (container != null)
            Container = container;

        CreatePool(prefabsCount);
    }

    public bool HasFreeObject(out T element)
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetObject(Vector3 spawnPosition)
    {
        if (HasFreeObject(out var element))
        {
            element.transform.position = spawnPosition;
            element.gameObject.SetActive(true);
            return element;
        }

        T currentObject = CreateObject(true);
        currentObject.transform.position = spawnPosition;
        return currentObject;
    }

    private void CreatePool(int prefabsCount)
    {
        _pool = new List<T>();

        for (int i = 0; i < prefabsCount; i++)
            CreateObject();
    }

    private T CreateObject(bool isActive = false)
    {
        T createdObject;

        if (Container == null)
            createdObject = Object.Instantiate(Prefab);
        else
            createdObject = Object.Instantiate(Prefab, Container);

        createdObject.gameObject.SetActive(isActive);
        _pool.Add(createdObject);
        return createdObject;
    }
}
