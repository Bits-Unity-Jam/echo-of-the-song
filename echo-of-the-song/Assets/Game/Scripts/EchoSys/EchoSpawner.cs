using System;
using System.Linq;
using Game.Scripts.Footsteps;
using UnityEngine;

public class EchoSpawner : MonoBehaviour
{
    [ SerializeField ]
    private Echo echoMovePrefabs;

    [ SerializeField ]
    private int _poolSize;
    
    

    private Echo[] _echos;

    private void Start()
    {
        GeneratePool();
    }
    

    public void Spawn(Vector3 pos, int count)
    {
        try
        {
            float rotation = 0;
            float step = 360 / (float)count;
            for (int i = 0; i < count; i++)
            {
                Echo freeEchoMove = _echos.First(echo => !echo.Activated);
                Vector2 dir = Quaternion.Euler(0, 0, rotation) * Vector2.up;
                freeEchoMove.Emmit(dir, pos);
                rotation += step;
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }
    }

    private void GeneratePool()
    {
        _echos = new Echo[_poolSize];
        for (int i = 0; i < _poolSize; i++)
        {
            Echo echoMove = Instantiate(echoMovePrefabs, transform);
            _echos[i] = echoMove;
        }
    }
}