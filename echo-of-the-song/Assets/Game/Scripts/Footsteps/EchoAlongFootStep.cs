using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Footsteps;
using UnityEngine;

public class EchoAlongFootStep : MonoBehaviour
{
    [SerializeField] private int _rayCount;
    [SerializeField] private PlayerFootstepCreator _footstepCreator;
    [SerializeField] private EchoSpawner _echoSpawner;

    private void OnEnable()
    {
        _footstepCreator.OnFootstepMade += OnFootstepMade;
    }

    private void OnDisable()
    {
        _footstepCreator.OnFootstepMade -= OnFootstepMade;
    }

    private void OnFootstepMade()
    {
        _echoSpawner.Spawn(_footstepCreator.LastFootstepCenter,_rayCount);
    }
    
    
}
