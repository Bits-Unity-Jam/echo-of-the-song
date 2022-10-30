using System;
using UnityEngine;

public class Echo : MonoBehaviour
{
    public bool Activated { get; private set; }
    
    [SerializeField] private float _lifeTime;
    [SerializeField] private EchoMove _echoMove; 
    [SerializeField] private EchoTrail _echoTrail;

    private float _currentTime;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Emmit(Vector2 startDirection,Vector2 startPos,IntersectionArea rayType=IntersectionArea.White,bool constant=false)
    {
        gameObject.SetActive(true);
        _currentTime = _lifeTime;
        Activated = true;
        transform.position = startPos;

        _echoMove.SetDirection(startDirection);
        _echoMove.IsMoving = true;
        
        _echoTrail.Activated = true;
        _echoTrail.Initialize(_lifeTime,rayType,constant);
    }


    private void FixedUpdate()
    {
        if (Activated&&_currentTime >= 0)
        {
            _currentTime -= Time.fixedDeltaTime*2;
        }
        else if(Activated)
        {
            Deactivation();
        }
    }


    private void Deactivation()
    {
        if (Activated)
        {
            Activated = false;
            _echoMove.IsMoving = false;
            _echoTrail.StopAllCoroutinesFading();
            StopAllCoroutines();
            gameObject.SetActive(false);
        }
    }
}
