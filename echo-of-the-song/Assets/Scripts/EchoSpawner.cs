using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoSpawner : MonoBehaviour
{
    [SerializeField] private Echo _echo;


    private void Start()
    {
        Spawn(transform.position, 20);
    }

    public void Spawn(Vector3 pos,int count)
    {
        float rotation = 0;
        float step = 360 / count;
        for (int i = 0; i < count; i++)
        {
            Echo echo = Instantiate(_echo, pos, Quaternion.identity);
            Vector3 dir = Quaternion.Euler(0, 0, rotation) * Vector3.up;
            echo.Invoke(dir);
            rotation += step ;
        }
    }
}
