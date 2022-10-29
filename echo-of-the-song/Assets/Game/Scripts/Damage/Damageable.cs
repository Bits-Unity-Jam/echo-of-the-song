using Mechanics.Damage;
using Mechanics.DetectorCollision;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.HealtPoint
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private float health = 100;
        [SerializeField]
        private string tagEnemy = "Enemy";
        [SerializeField]
        private LayerMask layerMask;

        public float Health
        {
            get => health;
            set => health = value;
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;

            if (health < 0)
            {
                Die();
            }
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }

        public IEnumerable Detect()
        {
            DetectionData[] detectionData = new DetectionData[] { };
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f, layerMask);

            if (hitColliders.Length > 0)
            {
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    detectionData[i].distance = Vector3.Distance(transform.position, hitColliders[i].transform.position);
                    detectionData[i].direction = transform.position - hitColliders[i].transform.position;
                    detectionData[i].transformObject = hitColliders[i].transform;
                }
            }

            return detectionData;
        }
    }
}
