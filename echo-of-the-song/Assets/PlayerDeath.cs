using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour,IDiable
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("RedZone"))
        {
            Die();
        }
    }
    

    public void Die()
    {
        OnDie?.Invoke();
    }

    public event Action OnDie;
}
