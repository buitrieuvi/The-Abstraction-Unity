using UnityEngine;
using Zenject;

namespace Abstraction
{
    public class InjectInstaller : MonoInstaller
    {
        [SerializeField] private LayerController _layer;

        public override void InstallBindings()
        {
            Container.Bind<InputManager>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<UIManager>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<LayerController>().FromInstance(_layer).AsSingle().NonLazy();

            Container.Bind<PlayerController>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.Bind<CameraManager>().FromComponentInHierarchy().AsSingle().NonLazy();


        }


    }
}