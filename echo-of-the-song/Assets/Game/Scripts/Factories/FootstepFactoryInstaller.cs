using Game.Scripts.Footsteps;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Factories
{
    public class FootstepFactoryInstaller : MonoInstaller
    {
        [ SerializeField ]
        private FootstepFactory simpleDebrisFactory;

        public override void InstallBindings() => BindObjectFactory();

        private void BindObjectFactory() =>
            Container.Bind<IFactory<Footstep>>()
                .FromMethod(() => simpleDebrisFactory.GetComponent<IFactory<Footstep>>()).AsSingle();
    }
}