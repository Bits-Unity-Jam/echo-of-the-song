using System.Collections;
using Game.Mechanics.ObjectsPools;
using UnityEngine;

namespace Game.Scripts.Footsteps
{
    public class Footstep : MonoBehaviour
    {
        [ SerializeField ]
        private PoolObject poolObject;

        [ Range(0, 15) ]
        [ SerializeField ]
        private float lifeTime;

        private void OnEnable() => StartCoroutine(LifetimeRoutine());

        private IEnumerator LifetimeRoutine()
        {
            yield return new WaitForSeconds(lifeTime);
            poolObject.PushToPool();
        }
    }
}