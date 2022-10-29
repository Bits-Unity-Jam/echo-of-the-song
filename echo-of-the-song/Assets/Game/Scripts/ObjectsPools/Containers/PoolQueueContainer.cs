using System.Collections.Generic;

namespace Game.Mechanics.ObjectsPools.Containers
{
    public class PoolQueueContainer : BaseContainer
    {
        private Queue<PoolObject> _objectQueue = new();

        public override PoolObject PullObject() => _objectQueue.Dequeue();
        public override void PushObject(PoolObject obj) => _objectQueue.Enqueue(obj);
        public override int GetObjectsCount() => _objectQueue.Count;
    }
}