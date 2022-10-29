using System;
using System.Linq;
using UnityEngine;

public class EchoSpawner : MonoBehaviour
{
    [SerializeField] private Echo _echoPrefabs;
    [SerializeField] private int _poolSize;

    private Echo[] _echos;

    private void Start()
    {
        GeneratePool();
    }

    public void Spawn(Vector3 pos,int count)
    {
        float rotation = 0;
        float step = 360 / (float)count;
        for (int i = 0; i < count; i++)
        {
            Echo freeEcho = _echos.First(echo => !echo.IsActive);
            freeEcho.transform.position = pos;
            Vector3 dir = Quaternion.Euler(0, 0, rotation) * Vector3.up;
            freeEcho.Invoke(dir);
            rotation += step ;
        }
    }

    private void GeneratePool()
    {
        _echos = new Echo[_poolSize];
        for (int i = 0; i < _poolSize; i++)
        {
            Echo echo = Instantiate(_echoPrefabs,transform);
            _echos[i] = echo;
        }
    }
}
