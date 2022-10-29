using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mechanics.Detection
{
    public class DetectionCheck : MonoBehaviour, IDetector
    {
        [SerializeField]
        private LayerMask layerMask;
        [SerializeField]
        private float distanceCheck;

        public IEnumerable<DetectionData> Detect()
        {
            DetectionData[] detectionData = new DetectionData[] { };
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f, layerMask);

            if (hitColliders.Length > 0)
            {
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    detectionData[i].detectionObject = hitColliders[i].gameObject;
                    detectionData[i].transformObject = hitColliders[i].transform;
                    detectionData[i].distance = Vector3.Distance(transform.position, hitColliders[i].transform.position);
                    detectionData[i].direction = transform.position - hitColliders[i].transform.position;

                }
            }

            return detectionData;
        }
    }
}