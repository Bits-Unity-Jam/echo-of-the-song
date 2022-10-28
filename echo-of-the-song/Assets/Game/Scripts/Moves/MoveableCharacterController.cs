using UnityEngine;

namespace Game.Scripts.Moves
{
    public class MoveableCharacterController : MonoBehaviour, IMoveable<Vector2WorldSpaceData>
    {
        [ SerializeField ]
        private CharacterController characterController;

        [ Range(0, 30) ]
        [ SerializeField ]
        private float movementSpeed;

        private Vector3 _direction;

        public Vector3 MovementDirection => _direction;

        public void HandleDirection(Vector2WorldSpaceData direction) => 
            _direction = new Vector3(direction.Vector.x, direction.Vector.y, 0);

        public void Update()
        {
            if (_direction == default) { return; }
            
            characterController.Move(_direction * movementSpeed * Time.deltaTime);
            
            transform.forward = _direction;
        }
    }
}