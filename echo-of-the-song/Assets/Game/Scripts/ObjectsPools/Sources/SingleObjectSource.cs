using Game.Mechanics.ObjectsPools.Sources;
using UnityEngine;

namespace Game.Scripts.ObjectsPools.Sources
{
    public class SingleObjectSource<TObject> : BaseObjectSource<TObject> where TObject : Object
    {
        [SerializeField]
        private TObject instance;
        public override TObject GetObject() => instance;
    }
    
}