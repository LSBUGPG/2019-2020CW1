using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
    float force = 2.0f;
	float CursorTime = 0.1f;
	float timer;
	bool CursorLockedVar = true;
	bool isPaused = false;

	
	void Start ()
	{

    }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pauseGame();
		}
	}

  	void FixedUpdate ()
	// Used for physics.
	{
		MoveInput();
		// KeyInput is the movement button.

		CursorVar();
		// The unhiding of the cursor.

		timer += Time.deltaTime;
		if(timer > 0)
		{
			CursorVar();
			timer = CursorTime;
		}



		//--Adding Gravity to player--//
		//GetComponent<Rigidbody>().AddForce(Physics.gravity);//
	}

	private void MoveInput()
	{
		float translation = Input.GetAxis("Vertical") * force;
		float strafe = Input.GetAxis("Horizontal") * force;
		//Tme.deltaTime = This will keep the movement smooth and also in-time with the update. The time between this update and the last update that ran.
		//By using the Time.deltaTime as a multiplier, it can ensure that the character is moving smoothly and at the same rate.
		//Update loop does not run at exactly the same time each loop depending on what is happening in the game.

		GetComponent<Rigidbody>().AddForce(transform.TransformDirection(strafe, 1, translation));
		// (x, y, z) axis.
	}


	void CursorVar()
	{
		if(CursorLockedVar == true)
		{
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKey(KeyCode.Escape)) {
                CursorLockedVar = false;
            }
        }  
		else if (CursorLockedVar == false) {
			CursorLockedVar = !CursorLockedVar;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKey(KeyCode.Escape)) {
                CursorLockedVar = true;
            }
		}
	}

	void pauseGame()
	{
		if (isPaused)
		{
			Time.timeScale = 1;
			isPaused = false;
		}
		else
		{
			Time.timeScale = 0;
			isPaused = true;
		}
	}
}