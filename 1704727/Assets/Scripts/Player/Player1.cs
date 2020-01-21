using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{

	[SerializeField]
    float speed = 2.0f;
	bool CursorLockedVar = true;
	float CursorTime = 0.1f;
	float timer;
    bool gamePaused = false;
	

  	void FixedUpdate ()
	{
		MoveInput();
		// KeyInput is the movement button.

		CursorVar();
		// The unhiding of the cursor.

		timer -= Time.deltaTime;
		if(timer < 0)
		{
			CursorVar();
			timer = CursorTime;
		}

		//--Adding Gravity to player--//
		//GetComponent<Rigidbody>().AddForce(Physics.gravity);//
	}

	private void MoveInput()
	{
		float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		//Tme.deltaTime = This will keep the movement smooth and also in-time with the update. The time between this update and the last update that ran.
		//By using the Time.deltaTime as a multiplier, it can ensure that the character is moving smoothly and at the same rate.
		//Update loop does not run at exactly the same time each loop depending on what is happening in the game.

		transform.Translate(strafe, 0, translation);
		// (x, y, z) axis.
	}


	void CursorVar()
	{
		if(CursorLockedVar == true)
		{
            // Time.timeScale = 1;
            // gamePaused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKey(KeyCode.Escape)) {
            CursorLockedVar = false;
            }
        }  
		else if (CursorLockedVar == false) {
            gamePaused = !gamePaused;
            CursorLockedVar = !CursorLockedVar;
            // Time.timeScale = 0;
            // gamePaused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKey(KeyCode.Escape)) {
                CursorLockedVar = true;
            }
		}
	}
}