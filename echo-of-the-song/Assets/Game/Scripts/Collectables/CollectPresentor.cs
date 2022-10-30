using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mechanics.Collectable
{
    public class CollectPresentor : MonoBehaviour
    {
        [SerializeField]
        private Inventory _inventory;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out ICollectable item ))
            {
                _inventory.AddItem();
            }
        }
        
    }
}
