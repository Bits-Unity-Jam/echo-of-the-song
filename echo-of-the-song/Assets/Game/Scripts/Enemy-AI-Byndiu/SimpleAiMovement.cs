using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAiMovement : MonoBehaviour
{
    public event Action<bool> PlayerDetected;

    private bool _detectionInvoked;


    [SerializeField] private float _speed;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float trigerDistance;
    [SerializeField]
    private float escapeDistance;

    private bool _isTrigeredByPlayer;

    private List<Transform> _wayPoints;
    private int _wayPointIndex = 0;
    private bool _isToEndMove;



    private NavMeshAgent _agent;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        /*_wayPoints = path.WayPoints;*/
        var agent = transform.GetComponent<NavMeshAgent>();
        agent.enabled = false;
        /*transform.position = _wayPoints[0].position;*/
        agent.enabled = true;

        _agent.speed = _speed;
    }

    private void Update()
    {
        //agent.SetDestination(target.position);

        if (target != null)
        {
            FollowPlayerMove();

            /*if (!_isTrigeredByPlayer)
            {
                PathMove();
            }*/
        }

        //var distance = Vector2.Distance(gameObject.transform.position, target.transform.position);
        //if (distance < trigerDistance)
        //{
        //    isTrigered = true;
        //}

        //if (distance > escapeDistance)
        //{
        //    isTrigered = false;
        //}

        //if (isTrigered)
        //{
        //    agent.SetDestination(target.position);
        //}
    }

    private void PathMove()
    {
        _agent.SetDestination(_wayPoints[_wayPointIndex].transform.position);
        if (Vector2.Distance(transform.position, _wayPoints[_wayPointIndex].position) < 0.1f)
        {
            if (_isToEndMove && _wayPointIndex < _wayPoints.Count - 1)
            {
                _wayPointIndex++;
            }
            else
            {
                _isToEndMove = false;
            }

            if (!_isToEndMove && _wayPointIndex > 0)
            {
                _wayPointIndex--;
            }
            else
            {
                _isToEndMove = true;
            }

        }
    }
    private void FollowPlayerMove()
    {
        var distance = Vector2.Distance(gameObject.transform.position, target.transform.position);
        if (distance < trigerDistance)
        {
            _isTrigeredByPlayer = true;
            if (!_detectionInvoked)
            {
                _detectionInvoked = true;
                PlayerDetected?.Invoke(true);
            }
        }

        if (distance > escapeDistance)
        {
            _isTrigeredByPlayer = false;
            
            if (_detectionInvoked)
            {
                _detectionInvoked = false;
                PlayerDetected?.Invoke(false);
            }
        }

        if (_isTrigeredByPlayer)
        {
            _agent.SetDestination(target.position);
        }
    }
}
    

