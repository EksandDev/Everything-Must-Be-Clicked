using UnityEngine;
using Zenject;

public class CraftingInstaller : MonoInstaller
{
    [SerializeField] private CraftingView _craftingView;

    public override void InstallBindings()
    {
        Container.Bind<CraftingView>().FromInstance(_craftingView).AsSingle();
        Container.Bind<CraftingModel>().AsSingle();
    }
}