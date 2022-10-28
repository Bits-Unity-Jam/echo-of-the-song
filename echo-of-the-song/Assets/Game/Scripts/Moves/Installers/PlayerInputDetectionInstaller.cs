using UnityEngine;
using Zenject;

namespace Game.Scripts.Moves.Installers
{
    public class PlayerInputDetectionInstaller : MonoInstaller
    {
        [SerializeField]
        private BaseMovementVectorDetector movementDetector;

        public override void InstallBindings() => BindSwipeDetector();

        private void BindSwipeDetector() =>
            Container.
                Bind<BaseMovementVectorDetector>().
                FromInstance(movementDetector).
                AsSingle().
                NonLazy();
    }
}