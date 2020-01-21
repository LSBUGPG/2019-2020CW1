using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //the object we want to look at

    [Range(0f,1f)]
    public float followSpeed = 0.125f; //The higher the value the faster the camera moves 

    public Vector3 offset; //how far to sit behind target

    void LateUpdate()
    {
        Vector3 nextPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, nextPosition, followSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target.position);
    }
}
