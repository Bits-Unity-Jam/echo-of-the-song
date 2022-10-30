using System;
using Mechanics.Collectable;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.GameplayCanvas.Hud
{
    public class InventoryView:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Inventory _inventory;


        private void OnEnable()
        {
            _inventory.ChangedAmount += OnAmountChanged;
        }

        private void OnDisable()
        {
            _inventory.ChangedAmount -= OnAmountChanged;
        }

        private void OnAmountChanged(int amount)
        {
            _text.text = amount.ToString()+"/22"; //TODO
        }
    }
}