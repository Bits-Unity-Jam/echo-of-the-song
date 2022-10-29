using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _cr;
    [SerializeField] private TrailRenderer _renderer;
    
    [SerializeField] private Color _currentColor;
    
    [SerializeField] private float _lifeTime;
    [SerializeField]private float _speed;
    
    public bool IsActive => _currentColor.a > 0;

    private Vector3 _direction;
    private float _colorStep;


    public void Start()
    {
        /*Invoke(new Vector3(1,1));*/
        
        _colorStep = (_currentColor.a / _lifeTime) *Time.deltaTime;
    }

    private void Update()
    {
        if (_currentColor.a > 0)
        {
            _currentColor.a -= _colorStep;
            _renderer.startColor=_currentColor;
            _renderer.endColor=_currentColor;
            
            transform.Translate(_direction*_speed*Time.deltaTime);
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            var colliderDistance2D =_cr.Distance(col);
            _direction=Vector3.Reflect(_direction,colliderDistance2D.normal);
        }

        /*if (col.gameObject.CompareTag("RedZone"))
        {
            var colliderDistance2D =_cr.Distance(col);
            colliderDistance2D.pointA;
        }*/
    }
    
    public void Invoke(Vector3 dir)
    {
        _currentColor.a = 1;
        _renderer.startColor = _currentColor;
        _renderer.endColor = _currentColor;
        
        _direction = dir;
    }
    
}
