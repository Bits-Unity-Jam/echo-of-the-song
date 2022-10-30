using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private List<Transform> wayPoints;

    public List<Transform> WayPoints { get => wayPoints; set => wayPoints = value; }
}
