using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Collectable
{
    public class Inventory:MonoBehaviour
    {
        public event Action<int> ChangedAmount;
        public event Action<int> ChangedAmountTake;
        public event Action<bool> Hold;

        private int _collectablesAmount;
        
        public void AddItem()
        {
            _collectablesAmount++;
            ChangedAmountTake?.Invoke(_collectablesAmount);
            Hold?.Invoke(true);
        }
        
        public int GiveItem()
        {
            ChangedAmount?.Invoke(_collectablesAmount);
            ChangedAmountTake?.Invoke(0);
            Hold?.Invoke(false);
            return _collectablesAmount;
        }
    }
}