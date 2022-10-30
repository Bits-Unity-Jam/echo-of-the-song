using Game.Scripts.Footsteps;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Factories
{
    public class PlayerFootstepFactoryInstaller : MonoInstaller
    {
        [ SerializeField ]
        private PlayerFootstepFactory simpleDebrisFactory;

        public override void InstallBindings() => BindObjectFactory();

        private void BindObjectFactory() =>
            Container.Bind<IFactory<PlayerFootstep>>()
                .FromMethod(() => simpleDebrisFactory.GetComponent<IFactory<PlayerFootstep>>()).AsSingle();
    }
}