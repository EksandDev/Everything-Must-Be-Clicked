using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [SerializeField] private HitEffectObjectPool _hitEffectObjectPool;

    public override void InstallBindings()
    {
        Container.Bind<HitEffectObjectPool>().FromInstance(_hitEffectObjectPool).AsSingle();
    }
}
