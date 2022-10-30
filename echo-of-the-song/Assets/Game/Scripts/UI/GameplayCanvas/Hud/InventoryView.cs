using System;
using Mechanics.Collectable;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.GameplayCanvas.Hud
{
    public class InventoryView:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _textTake;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private GameObject _image;


        private void OnEnable()
        {
            _inventory.ChangedAmount += OnAmountChanged;
            _inventory.Hold += OnHold;
            _inventory.ChangedAmountTake += OnAmountChangedTake;
        }

        private void OnDisable()
        {
            _inventory.ChangedAmount -= OnAmountChanged;
            _inventory.Hold -= OnHold;
            _inventory.ChangedAmountTake -= OnAmountChangedTake;
        }

        private void OnAmountChanged(int amount)
        {
            _text.text = amount.ToString()+"/22"; 
        }
        
        private void OnAmountChangedTake(int amount)
        {
            _textTake.text = amount.ToString();
        }

        private void OnHold(bool hold)
        {
            _image.SetActive(hold);
        }
    }
}