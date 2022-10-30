using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEchoSpawn : MonoBehaviour
{
    [SerializeField] private EchoSpawner _EchoSpawner;
    [SerializeField] private float _time;
    [SerializeField] private int _rayCount;


    private float _currentTime;

    private void Start()
    {
        _currentTime = _time;
    }

    private void Update()
    {
        if(_currentTime<=0)
        {
            _EchoSpawner.Spawn(transform.position,_rayCount);
            _currentTime = _time;
        }
        else
        {
            _currentTime -= Time.deltaTime;
        }
    }
}
