using UnityEngine;

public class HitEffectObjectPool : MonoBehaviour
{
    [SerializeField] private Effect _hitEffectPrefab;
    [SerializeField] private int _effectsCount;

    private ObjectPool<Effect> _pool;

    public Effect CreateEffect(Vector3 spawnPoint)
    {
        return _pool.GetObject(spawnPoint);
    }

    private void Start()
    {
        _pool = new(_hitEffectPrefab, _effectsCount);
    }
}