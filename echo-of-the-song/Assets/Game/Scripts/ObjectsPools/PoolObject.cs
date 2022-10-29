    using Game.Scripts.ObjectsPools;
    using UnityEngine;

namespace Game.Mechanics.ObjectsPools
{
    public class PoolObject : MonoBehaviour
    {
        private Pool _pool;
        
        public void Initialize(Pool pool) => _pool = pool;

        public virtual void PushToPool()
        {
            gameObject.SetActive(false);
            _pool.PushObject(this);
        }

        public virtual PoolObject Pull()
        {
            gameObject.SetActive(true);
            return this;
        }
        
        public Pool GetPool() => _pool;
    }
}