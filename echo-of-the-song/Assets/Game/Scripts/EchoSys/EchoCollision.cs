using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IntersectionArea
{
    Red,
    Yellow,
    White,
    Green,
}
public class EchoCollision : MonoBehaviour
{
    public event Action<Vector3> WallCollision;
    public event Action<IntersectionArea> Intersection;
    
    [SerializeField] private CircleCollider2D _collider;
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            var colliderDistance2D =_collider.Distance(col);
            WallCollision?.Invoke(colliderDistance2D.normal);
        }

        if (col.gameObject.CompareTag("RedZone"))
        {
            Intersection?.Invoke(IntersectionArea.Red);
        }
        
        if (col.gameObject.CompareTag("YellowZone"))
        {
            Intersection?.Invoke(IntersectionArea.Yellow);
        }
        
        if (col.gameObject.CompareTag("GreenZone"))
        {
            Intersection?.Invoke(IntersectionArea.Green);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RedZone"))
        {
            Intersection?.Invoke(IntersectionArea.White);
        }
        
        if (other.gameObject.CompareTag("YellowZone"))
        {
            Intersection?.Invoke(IntersectionArea.White);
        }
        
        if (other.gameObject.CompareTag("GreenZone"))
        {
            Intersection?.Invoke(IntersectionArea.White);
        }
    }
}
