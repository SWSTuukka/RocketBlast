using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltObject : MonoBehaviour
{
    public float tiltAngle = 10f; 

    private Vector3 previousPosition;

    private void Start()
    {
        previousPosition = transform.position;
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 movementDirection = (currentPosition - previousPosition).normalized;
        float tiltAmount = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0f, tiltAmount, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, tiltAngle * Time.deltaTime);

        previousPosition = currentPosition;
    }
}

