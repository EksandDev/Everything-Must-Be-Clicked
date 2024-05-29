using UnityEngine;
using Zenject;

public class InteractorInstaller : MonoInstaller
{
    [SerializeField] private Interactor _interactor;
    [SerializeField] private TargetNameText _targetNameText;

    public override void InstallBindings()
    {
        Container.Bind<Interactor>().FromInstance(_interactor).AsSingle();
        Container.Bind<DamageInteractor>().AsSingle();
        Container.Bind<ShowTextInteractor>().AsSingle();
        Container.Bind<CraftingInteractor>().AsSingle();
        Container.Bind<TargetNameText>().FromInstance(_targetNameText).AsSingle();
    }
}