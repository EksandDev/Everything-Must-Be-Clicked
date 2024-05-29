using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private InventoryView _inventoryView;

    public override void InstallBindings()
    {
        Container.Bind<InventoryView>().FromInstance(_inventoryView).AsSingle();
        Container.Bind<InventoryModel>().AsSingle();
    }
}