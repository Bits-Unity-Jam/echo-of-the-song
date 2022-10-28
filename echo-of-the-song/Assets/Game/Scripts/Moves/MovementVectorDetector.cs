using System;
using UnityEngine;

namespace Game.Scripts.Moves
{
    public abstract class BaseMovementVectorDetector : MonoBehaviour
    {
        public event Action<Vector2> OnMovementVectorUpdated;

        protected void SendMovementVectorUpdated(Vector2 movementVector) => OnMovementVectorUpdated?.Invoke(movementVector);
    }
}