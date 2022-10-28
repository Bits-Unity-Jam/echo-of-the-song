using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _cr;
    [SerializeField] private TrailRenderer _renderer;
    [SerializeField] private Color _endColor;
    [SerializeField] private float _speedDis;
    [SerializeField]private float _speed;

    private Vector3 _direction;


    public void Start()
    {
        Invoke(new Vector3(1,1));
    }

    private void Update()
    {
        if (_renderer.startColor.a>0)
        {
            _renderer.startColor=Color.LerpUnclamped(_renderer.startColor,_endColor, Time.deltaTime);
            _renderer.endColor=Color.LerpUnclamped( _renderer.endColor,_endColor, Time.deltaTime);
            transform.Translate(_direction*_speed*Time.deltaTime);
        }
        else
        {
            print("End");
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
