using System;
using UnityEngine;

public class Echo : MonoBehaviour
{
    public bool Activated { get; private set; }
    
    [SerializeField] private float _lifeTime;
    [SerializeField] private EchoMove _echoMove; 
    [SerializeField] private EchoTrail _echoTrail;

    private float _currentTime;
    
    public void Emmit(Vector2 startDirection,Vector2 startPos)
    {
        _currentTime = _lifeTime;
        Activated = true;
        transform.position = startPos;

        _echoMove.SetDirection(startDirection);
        _echoMove.IsMoving = true;
        
        _echoTrail.Activated = true;
        _echoTrail.SetLifeTime(_lifeTime);
    }


    private void Update()
    {
        if (Activated&&_currentTime >= 0)
        {
            _currentTime -= Time.fixedDeltaTime;
        }
        else if(Activated)
        {
            Deactivation();
        }
    }


    private void Deactivation()
    {
        Activated = false;
        _echoMove.IsMoving = false;
    }
}
