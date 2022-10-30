using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celebration : MonoBehaviour
{
    [SerializeField] private TaskCollection _TaskCollection;
    [SerializeField] private EchoSpawner _EchoSpawner;


    private void OnEnable()
    {
        _TaskCollection.AllCompleted += OnCompleted;
    }

    private void OnDisable()
    {
        _TaskCollection.AllCompleted -= OnCompleted;
    }

    private void OnCompleted()
    {
        _EchoSpawner.Spawn(transform.position,100);
    }
}
