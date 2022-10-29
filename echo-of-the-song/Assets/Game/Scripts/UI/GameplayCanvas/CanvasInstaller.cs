using UnityEngine;
using Zenject;

namespace Game.Scripts.UI.GameplayCanvas
{
    public class CanvasInstaller : MonoInstaller
    {
        [SerializeField]
        private Canvas canvas;

        public override void InstallBindings()
        {
            BindCanvas();
        }
        private void BindCanvas() =>
            Container.
                Bind<Canvas>().
                FromInstance(canvas).
                AsSingle().
                NonLazy();
    }
}