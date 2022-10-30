using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoSpawnAlongFollowing : MonoBehaviour
{
    [SerializeField] private TimeEchoSpawn _TimeEchoSpawn;
    [SerializeField] private SimpleAiMovement _SimpleAiMovement;

    private void OnEnable()
    {
        _SimpleAiMovement.PlayerDetected += OnDetect;
    }

    private void OnDisable()
    {
        _SimpleAiMovement.PlayerDetected -= OnDetect;
    }


    private void OnDetect(bool detected)
    {
        _TimeEchoSpawn.Active = detected;
    }
}
