using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axisX : MonoBehaviour
{

    [SerializeField]
    private float _sensitivity = 60f;

    void Update()
    {

        float _mouseX = Input.GetAxis ("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += _mouseX * _sensitivity * Time.deltaTime;
        transform.localEulerAngles = newRotation; 

    }
}