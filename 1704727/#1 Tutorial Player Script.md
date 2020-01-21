# Player Tutorial (FPS)

## Make a new scene

First, open Unity and make a new scene, rename this scene to `PlayerTutorial`.
Right click on the `Hierarchy` tab then move the mouse to the `3D Object`, create a `Plane` gameObject and expand it to whatever size you want but it has to be big enough for the player and other objects to move around on.
Right click on the `Plane` in the `Hierarchy` panel, select `Rename`, and then rename the 3D plane as `Platform` or anything that will make you know it is a platform.
Go to the `Inspector` tab, click on `Add Component` and then add a Rigidbody to the `Platform`, click on the collision detection drop down box and set it to `Continuous`.
It is also important to set the Rigidbody to kinematic, so check the `Is Kinematic` and uncheck the `Use Gravity`.
Another important thing is to add a collider to the plane if there is none.
Go to `Add Component` on the `Inspector` tab, look for `Box Collider` and set that as the collider for the `Plane`.

Now you know how to create a 3D gameObject into Unity and add a Rigidbody to it as well as adding colliders.
This time, create a 3D capsule gameObject, name this 3D capsule as `Player`.
Add a Rigidbody to the `Player`, set the collision detection to `Continuous`.
The `Player` must have a capsule collider.
In the Rigidbody tab, click on `Constraints`.
Make sure you check `Freeze Rotation` on `Y` and `Z` to prevent the player from moving when collided with a wall or object while not pressing the move button.

## Configuring the Player

Hold left click and drag the `Main Camera` to the `Player` to set the main camera as the child of the player.
Go to `Project` > `Scripts`, right-click on the huge box of the `Project` tab, create a new script by going to `Create` > `C# Script`.
Name this script to `PlayerMovement`.
Leave it empty for now.

## Configuring the Main Camera

Create a new script, name this script `CamMouseLook` or anything you want to know that this script is for camera movement that uses the mouse.
Open the `CamMouseLook` script using either `Visual Studio Code` or `Visual Studio`.
Write the script for the `CamMouseLook`.

## Writing the CamMouseLook Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour
{

    [SerializeField]
    Vector2 mouseLook;
    // Keeps track of how much movement the camera has made.

    Vector2 smoothV;
    // Required to make the mouseLook more smoothly. Not really necessary but it has been stated that without it is not smooth.

    public float sensitivity = 5f;
    // This is the sensitivity of the mouseLook.

    public float smoothing = 2f;
    // Smoothing the mouseLook.

    GameObject character;
    

    void Start()
    {
        character = this.transform.parent.gameObject;
        // Character is set to the parent that the object has this code, which is the Camera.
        // The character is the camera's parent.
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        // md = Mouse Delta.

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // (x, y) axis due to 2 Vectors and not 3. The md is multiplied by the sensitivity and smoothing values.

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
		// Lerp is a linear interpretation of a movement. Which won't instantly move a camera, it would move smoothly between two points which is the purpose of Lerp.
		// Lerp is used a lot on Character and NPC movement script.

		mouseLook += smoothV * Time.deltaTime;
		// mouseLook is adding the smoothV and applying it to the character.

		mouseLook.y = Mathf.Clamp(mouseLook.y, -80f, 80f);
		// The clamp is used to have limit to a certain rotation in this script.

		character.transform.rotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);

		transform.localRotation = Quaternion.AngleAxis(mouseLook.y, Vector3.left);
		//The "-mouseLook.y" is the inverted system to look up or look down script.

    }
}

This is the full script for the CamMouseLook, each `//` is called a comment.
The comment is not read as a script and I generally use this for each code so that I know which code does what on my script.

## Implementing the CamMouseLook Script

Go to the `Hierarchy` tab, left click on the `Main Camera`, make sure the `Inspector` tab is inspecting the `Main Camera`.
Go to the `CamMouseLook` script, hold left click and drag the script to the `Inspector` of the `Main Camera` to implement the `CamMouseLook` script.
You will have the `Sensitivity` and `Smoothing` option visible on the `Inspector` tab.
You can play with the `Sensitivity` to determine how fast you want your camera to look, though I suggest leaving the `Smoothing` value to 2 unless you want to play with it too.

## Writing the PlayerMovement script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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

## Implement the PlayerMovement script to the player

The same way you implement the `CamMouseLook` script onto the `Main Camera`, except do this for the `Player`.
The speed is set to 2 as default, you can edit the speed in the `Inspector` tab.
Important Notice: Use the `Esc` key on your keyboard to bring your mouse cursor back to your monitor. If you want to mouse cursor to disappear again, simply click back inside the `Game` tab.

Now you can run the game and see how it plays out.