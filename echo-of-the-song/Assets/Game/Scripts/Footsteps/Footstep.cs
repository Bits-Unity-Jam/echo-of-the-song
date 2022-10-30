using Game.Mechanics.ObjectsPools;
using Unity.Collections;
using UnityEngine;

namespace Game.Scripts.Footsteps
{
    public abstract class Footstep : MonoBehaviour
    {
        [ SerializeField ]
        private PoolObject poolObject;

        [SerializeField]
        private SpriteRenderer footSprite;
        
        [ Range(0, 50) ]
        [ SerializeField ]
        private float lifeTime;
        
        [ReadOnly]
        [ SerializeField ]
        private float lastedLifeTime;
        public Vector3 SpriteCenter => footSprite.transform.position;
        
        private void OnEnable()
        {
            lastedLifeTime = lifeTime;
        }

        private void Update()
        {
            lastedLifeTime -= Time.deltaTime;
            
            UpdateFootstepTransparency();
            
            if (lastedLifeTime <= 0)
            {
                poolObject.PushToPool();
            }
        }

        private void UpdateFootstepTransparency()
        {
            var newColor =
                new Color(footSprite.color.r, footSprite.color.g, footSprite.color.b, lastedLifeTime / lifeTime);
            footSprite.color = newColor;
        }
    }
}