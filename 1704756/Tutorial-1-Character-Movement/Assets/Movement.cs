using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
public float horizontalSpeed;
private float mouseX;

void Start () {
		
	}
	
void Update () {
	mouseX = horizontalSpeed * Input.GetAxis("Mouse X");
    Vector3 newPosition = new Vector3(mouseX, 0f, 0f);
    transform.position += newPosition;

		if (transform.position.x >= 5.2f)
    	{
        	transform.position = new Vector3(5.2f, transform.position.y, transform.position.z);
    	}

    	if (transform.position.x <= -5.2f)
		{
    	    transform.position = new Vector3(-5.2f, transform.position.y, transform.position.z);
    	}
	}
}
