using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    [SerializeField] private EchoSpawner _spawner;

    private PlayerInputs _inputs;
    private Vector2 _pos;

    private void Awake()
    {
        _inputs = new PlayerInputs();
    }


    private void OnEnable()
    {
        _inputs.Enable();
        _inputs.DebugTest.Enable();
        _inputs.DebugTest.MouseClick.performed += OnMouseClick;
        _inputs.DebugTest.MouseMove.performed += OnMouseMove;
    }


    private void OnMouseClick(InputAction.CallbackContext ctx)
    {
        _spawner.Spawn(_pos,50);
    }
    
    private void OnMouseMove(InputAction.CallbackContext ctx)
    {
        _pos = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
    }
}
