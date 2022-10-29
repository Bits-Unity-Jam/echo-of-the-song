using System;
using System.Collections;
using Game.Scripts.Moves;
using Unity.Collections;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Footsteps
{
    public class PlayerFootstepCreator : MonoBehaviour
    {
        [ Range(0, 2) ]
        [ SerializeField ]
        private float maxDistanceBetweenFootsteps = 0.5f; 
        
        [ReadOnly]
        [SerializeField]
        private Vector3 previousFootstepPosition;

        [ ReadOnly ]
        [ SerializeField ]
        public bool isStaying;
        
        private IFactory<Footstep> _footstepFactory;
        private IMoveable<Vector2WorldSpaceData> _moveable;
        private Footstep _lastFootstep;

        public Vector3 LastFootstepCenter => _lastFootstep.SpriteCenter;

        public event Action OnFootstepMade;

        [Inject]
        private void Construct(IFactory<Footstep> footstepFactory, IMoveable<Vector2WorldSpaceData> moveable)
        {
            _footstepFactory = footstepFactory;
            _moveable = moveable;
        }

        private void Update()
        {
            if (_moveable.MovementDirection == default && isStaying == false)
            {
                isStaying = true;
                StartCoroutine(DoubleFootstepRoutine());
                return;
            }

            if (_moveable.MovementDirection != default)
            {
               isStaying = false;
               StopAllCoroutines();
            }

            if (Vector3.Distance(previousFootstepPosition, transform.position) < 
                maxDistanceBetweenFootsteps) return;
            
            MakeFootstep();
        }

        private void MakeFootstep()
        {
            CreateFootStep();
            OnFootstepMade?.Invoke();
        }

        public void CreateFootStep()
        {
            _lastFootstep = _footstepFactory.Create();

            previousFootstepPosition = transform.position;
            Transform footstepTransform = _lastFootstep.transform;
            
            footstepTransform.position = transform.position;
            footstepTransform.up = transform.up;
        }

        private IEnumerator DoubleFootstepRoutine()
        {
            yield return new WaitForSeconds(0.7f);
            CreateFootStep();
            yield return new WaitForSeconds(0.7f);
            CreateFootStep();
        }
    }
}