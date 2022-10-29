using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAiMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float followingSpeed;
    [SerializeField]
    private float trigerDistance;
    [SerializeField]
    private float escapeDistance;

    private bool isTrigered;

    private NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
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
}
