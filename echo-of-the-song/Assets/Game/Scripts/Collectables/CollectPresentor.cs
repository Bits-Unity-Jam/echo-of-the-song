using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mechanics.Collectable
{
    public class CollectPresentor : MonoBehaviour
    {
        [SerializeField]
        private CollectablesManager collectablesManager;

        private ICollectable _ICollectable;

        public void Awake()
        {
            _ICollectable = GetComponent<ICollectable>();
            _ICollectable.Collect += ChangeCountItem;
        }

        private void OnDisable()
        {
            _ICollectable.Collect -= ChangeCountItem;
        }

        private void ChangeCountItem()
        {
            collectablesManager.ChangeCountItem();
        }
    }
}
