using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoMove : MonoBehaviour
{
    public bool IsMoving { get; set; }
    
    [SerializeField]private float _speed;
    [SerializeField] private EchoCollision _echoCollision;
    private Vector2 _direction;


    private void OnEnable()
    {
        _echoCollision.WallCollision += HandleWallCollision;
    }

    private void OnDisable()
    {
        _echoCollision.WallCollision -= HandleWallCollision;
    }

    private void HandleWallCollision(Vector3 normal)
    {
        _direction=Vector3.Reflect(_direction,normal);
    }
    
    private void Update()
    {
        if (IsMoving)
        {
            transform.Translate(_direction*_speed*Time.deltaTime);
        }
    }

    public void SetDirection(Vector2 startDirection)
    {
        _direction = startDirection;
    }
}
