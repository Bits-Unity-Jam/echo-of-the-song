
using System;
using UnityEngine;

namespace Mechanics.Collectable
{
    public class CollectItem : MonoBehaviour, ICollectable
    {
        public event Action Collect;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out CollectPresentor item ))
            {
                Collect?.Invoke();
            }
        }

    }
}