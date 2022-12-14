using System;
using UnityEngine;

namespace Game.Scripts.Damage
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private float health = 100;
        [SerializeField]
        private string tagEnemy = "Enemy";

        public event Action OnDied;
        
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
            OnDied?.Invoke();
        }
    }
}
