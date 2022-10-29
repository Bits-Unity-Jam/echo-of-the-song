using Game.Mechanics.ObjectsPools.Sources;
using UnityEngine;

namespace Game.Scripts.ObjectsPools.Sources
{
    public class MultipleObjectSource<TObject> : BaseObjectSource<TObject> where TObject : Object
    {
        [ SerializeField ]
        protected TObject[] instances;

        protected int instanceIterator = -1;

        public TObject GetObject(int i)
        {
            return instances[i];
        }

        public override TObject GetObject()
        {
            instanceIterator = (++instanceIterator) % instances.Length;
            return instances[instanceIterator];
        }
    }
}