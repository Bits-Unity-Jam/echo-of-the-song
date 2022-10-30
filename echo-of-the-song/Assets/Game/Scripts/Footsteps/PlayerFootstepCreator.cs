using System;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Footsteps
{
    public class PlayerFootstepCreator : BaseFootstepCreator
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
        private Footstep _lastFootstep;
        private Vector3 _lastPosition;

        public Vector3 LastFootstepCenter => _lastFootstep.SpriteCenter;

        public event Action OnFootstepMade;

        [Inject]
        private void Construct(IFactory<PlayerFootstep> footstepFactory)
        {
            _footstepFactory = footstepFactory;
        }

        private void Update()
        {
            var delta = Vector3.Distance(_lastPosition, transform.position);
            _lastPosition = transform.position;
            
            switch (delta)
            {
                case < 0.0001f when isStaying == false:
                    isStaying = true;
                    StartCoroutine(DoubleFootstepRoutine());
                    return;
                case > 0.01f:
                    isStaying = false;
                    StopAllCoroutines();
                    break;
            }

            if (Vector3.Distance(previousFootstepPosition, transform.position) < 
                maxDistanceBetweenFootsteps) return;
            
            MakeFootstep();
            SendFootstepMade();
            OnFootstepMade?.Invoke();
        }

        private void MakeFootstep()
        {
            CreateFootStep();
            SendFootstepMade();
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