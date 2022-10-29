using System;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Moves
{
    public class Player : MonoBehaviour
    {
        private IMoveable<Vector2WorldSpaceData> _moveable;

        private MovementVectorPresenter _movementVectorPresenter;

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
    }
}