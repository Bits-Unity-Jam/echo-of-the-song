using UnityEngine;
using Zenject;

namespace Game.Scripts.Moves
{
    public class MoveableVector2Installer : MonoInstaller 
    {
        [SerializeField] 
        private GameObject moveableModule;

        public override void InstallBindings() => BindMoveable();
        
        private void BindMoveable() =>
            Container.
                Bind<IMoveable<Vector2WorldSpaceData>>().
                FromMethod(() => moveableModule.GetComponent<IMoveable<Vector2WorldSpaceData>>()).
                AsSingle();
    }
}