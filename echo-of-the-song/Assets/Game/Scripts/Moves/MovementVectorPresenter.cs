using System;
using Unity.Collections;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Moves
{
    public class MovementVectorPresenter : MonoBehaviour
    {
        [ReadOnly]
        [SerializeField]
        private float maxSwipeLength = 100f;
        
        //[SerializeField]
        private BaseMovementVectorDetector _baseMovementVectorDetector;

        public event Action<Vector2WorldSpaceData> OnDirectionHandled;

        [Inject]
        private void Construct(BaseMovementVectorDetector swipeDetector)
        {
            _baseMovementVectorDetector = swipeDetector;
        }

        private void Start() => _baseMovementVectorDetector.OnMovementVectorUpdated += HandleDelta;

        private void OnDestroy() => _baseMovementVectorDetector.OnMovementVectorUpdated -= HandleDelta;

        private void HandleDelta(Vector2 delta)
        {
            Vector2 deltaPosition = CountDeltaPosition(delta);
            
            OnDirectionHandled?.Invoke(new Vector2WorldSpaceData{ Vector = deltaPosition});
        }

        private Vector2 CountDeltaPosition(Vector2 delta)
        {
            
#if UNITY_ANDROID

            Vector2 deltaPosition = new Vector2(delta.x, delta.y);

            float maxAxisValue = Mathf.Max(Mathf.Abs(deltaPosition.x), Mathf.Abs(deltaPosition.y));

            deltaPosition =
                maxAxisValue > 0 ? deltaPosition / maxSwipeLength : Vector2.zero;

            deltaPosition = Vector2.ClampMagnitude(deltaPosition, 1);

            return deltaPosition;
            
#elif UNITY_STANDALONE_WIN
            
            return delta;
            
#endif
        }
    }
}