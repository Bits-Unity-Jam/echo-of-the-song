using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Moves
{
    public class InputSystemCallbackDetector : BaseMovementVectorDetector
    {
        private PlayerInputs _playerInputs;
        
        private void Awake()
        {
            _playerInputs = new PlayerInputs();
        }

        private void OnEnable()
        {
            _playerInputs.Player.Enable();
            
            _playerInputs.Player.Move.performed += HandleMove;
            _playerInputs.Player.Move.canceled += HandleMove;
        }

        private void OnDisable()
        {
            _playerInputs.Player.Move.performed -= HandleMove;
            _playerInputs.Player.Move.canceled -= HandleMove;
            
            _playerInputs.Player.Disable();
        }

        private void HandleMove(InputAction.CallbackContext ctx)
        {
            Vector2 moveInput = ctx.ReadValue<Vector2>();
            
            base.SendMovementVectorUpdated(moveInput);
        }
    }
}
