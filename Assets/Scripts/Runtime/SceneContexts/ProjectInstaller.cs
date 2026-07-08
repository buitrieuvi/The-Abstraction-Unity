using Abstraction.SharedModel;
using UnityEngine;
using Zenject;

namespace Abstraction
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<DTO_Player>()
                .AsSingle()
                .NonLazy();

            Container.Bind<GameDataManager>()
                .AsSingle()
                .NonLazy();
        }

    }
}