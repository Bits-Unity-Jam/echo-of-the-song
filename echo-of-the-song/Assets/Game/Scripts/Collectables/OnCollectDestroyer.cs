using System;
using System.Collections;
using System.Collections.Generic;
using Mechanics.Collectable;
using UnityEngine;

public class OnCollectDestroyer : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private CollectItem _collectItem;

    private void OnEnable()
    {
        _collectItem.Collect += OnCollect;
    }

    private void OnDisable()
    {
        _collectItem.Collect -= OnCollect;
    }

    private void OnCollect()
    {
        Destroy(gameObject,_delay);
    }
}
