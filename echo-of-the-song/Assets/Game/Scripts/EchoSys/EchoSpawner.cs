using System;
using System.Collections;
using System.Linq;
using Game.Scripts.Footsteps;
using UnityEngine;

public class EchoSpawner : MonoBehaviour
{
    [ SerializeField ]
    private Echo echoMovePrefabs;

    [ SerializeField ]
    private int _poolSize;

    [SerializeField] private
        IntersectionArea _rayType;

    [SerializeField] private bool _constant;
    
    

    private Echo[] _echos;

    private void Start()
    {
       StartCoroutine( GeneratePool());
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
                freeEchoMove.Emmit(dir, pos,_rayType,_constant);
                rotation += step;
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }
    }

    private IEnumerator GeneratePool()
    {
        _echos = new Echo[_poolSize];
        for (int i = 0; i < _poolSize; i++)
        {
            Echo echoMove = Instantiate(echoMovePrefabs, transform);
            _echos[i] = echoMove;
            
            if (i % 10 == 0)//10  every frame
            {
                yield return null;
            }
        }
    }
}