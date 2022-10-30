using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Collectable
{
    public class Inventory:MonoBehaviour
    {
        public event Action<int> ChangedAmount;

        private int _collectablesAmount;
        
        public void AddItem()
        {
            _collectablesAmount++;
            ChangedAmount?.Invoke(_collectablesAmount);
        }
        
        public void GiveAllItem()
        {
            _collectablesAmount = 0;
            ChangedAmount?.Invoke(_collectablesAmount);
        }
    }
}