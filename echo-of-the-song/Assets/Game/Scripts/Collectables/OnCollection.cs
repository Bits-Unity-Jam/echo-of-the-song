using System;
using System.Collections;
using System.Collections.Generic;
using Mechanics.Collectable;
using UnityEngine;

public class OnCollection : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;
    [SerializeField] private CollectItem _collectItem;
    [SerializeField] private EchoSpawner _echoSpawner;
    [SerializeField] private AudioSource _AudioSource;

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
        _echoSpawner.Spawn(transform.position,10);
        _AudioSource.Play();
        Destroy(gameObject,_destroyDelay);
    }
}
