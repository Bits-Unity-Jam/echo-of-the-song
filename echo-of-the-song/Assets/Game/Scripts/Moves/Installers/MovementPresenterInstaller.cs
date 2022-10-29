using UnityEngine;
using Zenject;

namespace Game.Scripts.Moves.Installers
{
    public class MovementPresenterInstaller : MonoInstaller
    {
        [SerializeField]
        private MovementVectorPresenter movementVectorPresenter;

        public override void InstallBindings() => BindMovementPresenter();

        private void BindMovementPresenter() =>
            Container.
                Bind<MovementVectorPresenter>().
                FromInstance(movementVectorPresenter).
                AsSingle().
                NonLazy();
    }
}