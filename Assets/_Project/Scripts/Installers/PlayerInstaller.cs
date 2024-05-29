using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private GameObject _player;
    [SerializeField] private FirstPersonController _controller;
    [SerializeField] private Message _message;

    public override void InstallBindings()
    {
        Container.Bind<PlayerStats>().AsSingle();
        Container.Bind<FirstPersonController>().FromInstance(_controller).AsSingle();
        Container.Bind<Message>().FromInstance(_message).AsSingle();
    }
}
