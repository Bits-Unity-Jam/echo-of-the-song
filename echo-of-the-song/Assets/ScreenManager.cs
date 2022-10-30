using Game.Scripts.Moves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _LoaderScreen;
    [SerializeField] private SceneLoader _SceneLoader;

    [SerializeField]private PlayerDeath _player;

    [SerializeField] private float _delayReload;

   

    private void Awake()
    {
        _player.OnDie += _player_OnDie;
    }

    private void _player_OnDie()
    {
        _LoaderScreen.SetActive(true);

        StartCoroutine(DelayedReload());
    }

    private void OnDestroy()
    {
        _player.OnDie -= _player_OnDie;
    }


    private IEnumerator DelayedReload()
    {
        yield return new WaitForSeconds(_delayReload);
        _SceneLoader.ReloadScene();
    }
}
