using Mechanics.Damage;
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                TakeDamage(5);
                Debug.Log("Entered!");
            }
        }
    }
}
