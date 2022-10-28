using Game.Scripts.Moves;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.Scripts.UI.Inputs
{
    /// <summary>
    /// Control from canvas image (on android)
    /// </summary>
    public class SwipeDetector : BaseMovementVectorDetector, IDragHandler
    {
        private Canvas _canvas;

        [Inject]
        private void Construct(Canvas canvas) => _canvas = canvas;

        public void OnDrag(PointerEventData eventData) => base.SendMovementVectorUpdated(eventData.delta / _canvas.scaleFactor);
    }
}