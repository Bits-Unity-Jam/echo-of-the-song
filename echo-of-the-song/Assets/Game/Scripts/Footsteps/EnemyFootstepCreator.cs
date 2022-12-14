using System;
using System.Collections;
using Game.Scripts.ObjectsPools;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Game.Scripts.Footsteps
{
    public class EnemyFootstepCreator : BaseFootstepCreator
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

        private Footstep _lastFootstep;
        private Vector3 _lastPosition;

        public override Vector3 LastFootstepCenter => _lastFootstep.SpriteCenter;
        [SerializeField]
        private NavMeshAgent agent;
        public event Action OnFootstepMade;

        [ SerializeField ]
        private Pool stepPool;


        private void Start()
        {
            stepPool.transform.parent = null;
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
        }

        private void MakeFootstep()
        {
            CreateFootStep();
            SendFootstepMade();
        }

        public void CreateFootStep()
        {
            _lastFootstep = stepPool.PullObject().GetComponent<Footstep>();

            previousFootstepPosition = transform.position;
            Transform footstepTransform = _lastFootstep.transform;
            
            footstepTransform.position = transform.position;
            footstepTransform.up = agent.velocity.normalized;
        }

        private IEnumerator DoubleFootstepRoutine()
        {
            yield return new WaitForSeconds(0.7f);
            CreateFootStep();
            yield return new WaitForSeconds(0.7f);
            CreateFootStep();
        }
    }

    public abstract class BaseFootstepCreator : MonoBehaviour
    {
        public event Action OnFootstepMade;
        public abstract Vector3 LastFootstepCenter { get; }
        protected void SendFootstepMade() => OnFootstepMade?.Invoke();
    }
}