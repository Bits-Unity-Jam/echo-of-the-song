using UnityEngine;

namespace Game.Mechanics.ObjectsPools.Sources
{
    public abstract class BaseObjectSource<TObject> : MonoBehaviour
    {
        public abstract TObject GetObject();
    }
}