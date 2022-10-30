using Game.Scripts.Footsteps;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Factories
{
    public class EnemyFootstepFactoryInstaller : MonoInstaller
    {
        [ SerializeField ]
        private EnemyFootstepFactory simpleDebrisFactory;

        public override void InstallBindings() => BindObjectFactory();

        private void BindObjectFactory() =>
            Container.Bind<IFactory<EnemyFootstep>>()
                .FromMethod(() => simpleDebrisFactory.GetComponent<IFactory<EnemyFootstep>>()).AsSingle();
    }
}