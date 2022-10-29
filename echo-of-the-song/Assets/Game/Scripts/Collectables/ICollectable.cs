using System;

namespace Mechanics.Collectable
{
    public interface ICollectable
    {
        public event Action Collect;
    }
}