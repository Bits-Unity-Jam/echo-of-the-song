using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Mechanics.Collectable
{
    public class CollectablesManager : MonoBehaviour, ICollectable
    {
        [SerializeField]
        private TextMeshPro textCount;

        private int _countItem = 0;

        public event Action Collect;

        public void ChangeCountItem()
        {
            Debug.LogError("Enter!");
            _countItem++;
            //textCount.text = _countItem.ToString();
        }

    }
}
