using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    [SerializeField] private EchoSpawner _spawner;
    
    private Vector3 _pos;
    private PlayerInputs _playerInput;

    [SerializeField] private PlayerInput _PlayerInput;
    private void Awake()
    {
        _playerInput = new PlayerInputs();
        _playerInput.Enable();
        _playerInput.DebugTest.MouseClick.performed+=ctx => OnMouseClick();
        _playerInput.DebugTest.MouseMove.performed+=ctx => OnMouseMove(ctx.ReadValue<Vector3>());


        _playerInput.Player.Move.performed += ctx => OnFOO();
    }


    private void OnFOO()
    {
        print("adfa");
    }
    
    
    private void OnMouseClick()
    {
       var pos =Camera.main.ScreenToWorldPoint(_pos);
        _spawner.Spawn(pos,20);
    }
    
    private void OnMouseMove(Vector3 pos)
    {
        _pos = pos;
    }
}
