using UnityEngine;

namespace Game.Mechanics.ObjectsPools.Containers
{
    public abstract class BaseContainer : MonoBehaviour
    {
        public abstract PoolObject PullObject();
        public abstract void PushObject(PoolObject obj);
        public abstract int GetObjectsCount();
    }
}