
using System;
using UnityEngine;

namespace Mechanics.Collectable
{
    public class CollectItem : MonoBehaviour, ICollectable
    {
        [SerializeField]
        private string tagCollectableItem;

        public event Action Collect;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == tagCollectableItem)
            {
                Collect?.Invoke();
            }
        }

    }
}