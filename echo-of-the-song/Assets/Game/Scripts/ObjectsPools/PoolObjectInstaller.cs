using System;
using UnityEngine;
using Zenject;

namespace Game.Mechanics.ObjectsPools
{
    public class PoolObjectInstaller : MonoInstaller
    {
        [SerializeField]
        private PoolObject poolObject;

        private void OnValidate() => poolObject ??= GetComponent<PoolObject>();
        
        public override void InstallBindings() => BindPoolObject();
        
        private void BindPoolObject() =>
            Container.
                Bind<PoolObject>().
                FromInstance(poolObject).
                AsSingle().
                NonLazy();
    }
}