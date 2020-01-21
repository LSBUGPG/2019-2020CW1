using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    //https://www.youtube.com/watch?v=JUTFiyBjlnc used for sprint command.
    float moveSpeed;
    float sprintSpeed = 8f;
    float walkSpeed = 4f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (moveSpeed*Input.GetAxis ("Horizontal") * Time.deltaTime, 0f,moveSpeed*Input.GetAxis ("Vertical")*Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
       
	}
}
