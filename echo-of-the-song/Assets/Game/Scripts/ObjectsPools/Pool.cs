using System;
using Game.Mechanics.ObjectsPools;
using Game.Mechanics.ObjectsPools.Containers;
using Game.Mechanics.ObjectsPools.Sources;
using UnityEngine;
using Zenject;

namespace Game.Scripts.ObjectsPools
{
    public class Pool : MonoBehaviour
    {
        [SerializeField]
        private int startObjectCount;
        
        [Space]
        [SerializeField]
        private bool autoExpand;
        [SerializeField]
        private int countToExpand = 3;
        
        private BaseContainer _container;
        private BaseObjectSource<PoolObject> _baseObjectSourse;
        private DiContainer _diContainer;
        
        [Inject]
        private void Coustruct(DiContainer diContainer) => _diContainer = diContainer;

        private void Awake()
        {
            _container = GetComponent<BaseContainer>();
            _baseObjectSourse = GetComponent<BaseObjectSource<PoolObject>>();
            
            CreateItems(startObjectCount);
        }

        protected virtual void CreateItems(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject created = _diContainer.InstantiatePrefab(_baseObjectSourse.GetObject(), transform);

                if (created.TryGetComponent(out PoolObject newItem) == false)
                    throw new Exception("The object isn`t a PoolObject!");
                
                newItem.Initialize(this);
                newItem.PushToPool();
            }
        }
        
        public virtual void PushObject(PoolObject obj)
        {
            obj.transform.position = transform.position;
            _container.PushObject(obj);
        }

        public virtual PoolObject PullObject()
        {
            if (_container.GetObjectsCount() > 0) return _container.PullObject().Pull();

            if (autoExpand == false) throw new Exception("There is no items in the pool!");
            
            CreateItems(countToExpand);
            
            return _container.PullObject().Pull();
        }
    }
}