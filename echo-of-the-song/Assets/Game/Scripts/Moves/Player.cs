using System;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Moves
{
    public class Player : MonoBehaviour, IDiable
    {
        private IMoveable<Vector2WorldSpaceData> _moveable;

        private MovementVectorPresenter _movementVectorPresenter;

        public event Action OnDie;

        [ Inject ]
        private void Construct(IMoveable<Vector2WorldSpaceData> moveable,
            MovementVectorPresenter movementVectorPresenter)
        {
            _moveable = moveable;
            _movementVectorPresenter = movementVectorPresenter;
        }

        private void OnEnable() => _movementVectorPresenter.OnDirectionHandled += HandleNewMovementDirection;

        private void OnDisable() => _movementVectorPresenter.OnDirectionHandled -= HandleNewMovementDirection;

        private void HandleNewMovementDirection(Vector2WorldSpaceData movementVector)
        {
            _moveable.HandleDirection(movementVector);
        }

        public void Die()
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                /*Die();*/
                Debug.Log("Die!!!!!!!!!!!!!!!!!");
            }
        }
    }
}