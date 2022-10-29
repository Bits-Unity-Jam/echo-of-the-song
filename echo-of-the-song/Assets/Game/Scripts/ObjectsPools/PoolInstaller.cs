using Game.Scripts.ObjectsPools;
using UnityEngine;
using Zenject;

namespace Game.Mechanics.ObjectsPools
{
    public class PoolInstaller : MonoInstaller
    {
        [SerializeField] 
        private Pool pool;
        
        public override void InstallBindings() => BindPool();

        private void BindPool() =>
            Container.
                Bind<Pool>().
                FromInstance(pool).
                AsSingle().
                NonLazy();
    }
}
