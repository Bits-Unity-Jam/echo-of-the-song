using Game.Scripts.Footsteps;
using UnityEngine;

public class EchoAlongFootStep : MonoBehaviour
{
    [ SerializeField ]
    private int _rayCount;

    [ SerializeField ]
    private PlayerFootstepCreator _footstepCreator;

    [ SerializeField ]
    private EchoSpawner _echoSpawner;

    private void Start()
    {
        _footstepCreator.OnFootstepMade += OnFootstepMade;
    }

    private void OnDestroy()
    {
        _footstepCreator.OnFootstepMade -= OnFootstepMade;
    }

    private void OnFootstepMade()
    {
        _echoSpawner.Spawn(_footstepCreator.LastFootstepCenter, _rayCount);
    }
}