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

    private Vector3 _direction;
    private float _colorStep;


    public void Start()
    {
        _colorStep = (_currentColor.a / _lifeTime) *Time.deltaTime;
    }

    private void Update()
    {
        if (_currentColor.a>0)
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
            var a =_cr.Distance(col);
            _direction=Vector3.Reflect(_direction,a.normal);
        }
    }
    
    public void Invoke(Vector3 dir)
    {
        Color color= _renderer.startColor;
        color.a = 1;
        _renderer.startColor = color;
        _renderer.endColor = color;
        _direction = dir;
    }
    
}
