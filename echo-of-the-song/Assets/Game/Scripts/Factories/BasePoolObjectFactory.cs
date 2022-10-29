using Game.Scripts.ObjectsPools;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Factories
{
    public abstract class BasePoolObjectFactory<T> : MonoBehaviour, IFactory<T>
    {
        [ SerializeField ]
        private Pool objectPool;

        private void OnValidate() => objectPool ??= GetComponent<Pool>();

        public T Create() => objectPool.PullObject().gameObject.GetComponent<T>();
    }
}