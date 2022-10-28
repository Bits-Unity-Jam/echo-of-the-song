using System.Collections;
using Game.Scripts.Moves;
using Unity.Collections;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Footsteps
{
    public class PlayerFootstepCreator : MonoBehaviour
    {
        [ Range(0, 5) ]
        [ SerializeField ]
        private float footStepCooldown;

        [ ReadOnly ]
        [ SerializeField ]
        private bool canMakeFootstep = true;

        [ ReadOnly ]
        [ SerializeField ]
        public bool isStaying;
        
        private IFactory<Footstep> _footstepFactory;
        private IMoveable<Vector2WorldSpaceData> _moveable;

        [Inject]
        private void Construct(IFactory<Footstep> footstepFactory, IMoveable<Vector2WorldSpaceData> moveable)
        {
            _footstepFactory = footstepFactory;
            _moveable = moveable;
        }

        private void MakeDoubleFootstep()
        {
            CreateFootStep();
            CreateFootStep();
        }

        private void Update()
        {
            if (_moveable.MovementDirection == default && isStaying == false)
            {
                isStaying = true;
                MakeDoubleFootstep();
                StopAllCoroutines();
                return;
            }
            
            if (canMakeFootstep == false) return;
            canMakeFootstep = false;
            CreateFootStep();
            StartCoroutine(FootstepCooldownRoutine());
        }

        public void CreateFootStep()
        {
            Footstep footstep = _footstepFactory.Create();
            
            Transform footstepTransform = footstep.transform;
            
            footstepTransform.position = transform.position;
            footstepTransform.up = _moveable.MovementDirection;
        }

        private IEnumerator FootstepCooldownRoutine()
        {
            yield return new WaitForSeconds(footStepCooldown);
            canMakeFootstep = true;
        }
    }
}