using Game.Scripts.Moves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private LoseScreen loseScreen;

    private Player _player;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _player.OnDie += _player_OnDie;
    }

    private void _player_OnDie()
    {
        loseScreen.Open();
    }

    private void OnDestroy()
    {
        _player.OnDie -= _player_OnDie;
    }
}
