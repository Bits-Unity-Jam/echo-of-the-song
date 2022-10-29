using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    private Vector3 _pos;
    private PlayerInputs _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInputs();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Fire.started += OnMouseClick;
    }
    
    private void OnDisable()
    {
        _playerInput.Player.Fire.performed -= OnMouseClick;
        _playerInput.Enable();
    }

    private void OnMouseClick(InputAction.CallbackContext obj)
    {
        Debug.Log("FirePressed!!!!!!");
    }
}