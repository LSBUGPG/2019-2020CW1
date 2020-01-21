# Creating a location for holding the object in position

Create an empty gameObject, name this as `PickingUp` and set this gameObject's tag as `PickingUp`.
How to make a `PickingUp` tag, simply select the drop down box of the `Tag` in the `Inspector` tab and then `Add Tag`.
You will now see `Tags & Layers` in the `Inspector Tab`, from there you will see there is a `+` button just at the right corner underneath the `Tags` category (Not the `Sorting Layers` or `Layers`).
Click on that `+` button, name the tag as `PickingUp` then click `Save`.
Now you should have the `PickingUp` tag.

Click on the `PickingUp` gameObject in the `Hierarchy` tab, in the `Inspector` tab, make sure to set it as `PickingUp` tag.
Once that is done, click on the arrow next to the `Player` gameObject in the `Hierarchy` tab, you should see the `Main Camera` gameObject as the child of the `Player`.
Simply make the `PickingUp` gameObject as the child of the `Main Camera`, not the `Player`.
Once that is done, add a `Sphere Collider` on the `PickingUp` gameObject.

# Create a pickable object

Create a new 3D Sphere gameObject in the `Hierarchy`.
Rename this sphere to `Ball`.
Add a Rigidbody to the `Ball` gameObject.

Important step: Set the `Angular Drag` to 1. If you set this lower than 1, the ball may roll forever, especially if its value is lower or is 0.5. Setting an Angular Drag allows it to slow down and stop.

Set the collision detection to `Continuous Dynamic`.

# Create a new script

Rename this script to `PickupObjects`.

# Writing the script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour {

	[SerializeField] Transform theDest;
	[SerializeField] float pushSpeed;
	[SerializeField] float kickHeight;
	private bool isPicked = false;
	private bool canPush = false;


	private bool isThrown = false;
	[SerializeField] private float canBePickedTimer;
	[SerializeField] float Throwspeed;
	private bool canBePicked = true;


	// Picking up object.
	void OnMouseDown()
	{
		if(canBePicked)
		{
		isPicked = true;
		// Turn off the gravity in the Rigidbody to avoid object falling when picked up.
		GetComponent<Rigidbody>().useGravity = false;
		// Freeze the gameObject's rotation to prevent it from moving.
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		// Change the transform position. Move the position of whatever object you are picking up.
		this.transform.localPosition = theDest.position;
		// Use Drag to pull the object, somehow it stops the movement completely.
		GetComponent<Rigidbody>().drag = 8;
		// Parent the object with the player's empty gameObject.
		this.transform.parent = GameObject.Find("PickingUp").transform;
		
		// canPush is set to theDest.transform.forward, spamming this on "true" will result in the object teleporting back and forth.
		canPush = false;
		// If the object is thrown, which is false.
		isThrown = false;
		// If the object can be picked, false. It is already picking it up at this point.
		canBePicked = false;
		}
	}

	// Releasing the object.
	void OnMouseUp()
	{
		isPicked = false;
		// Make the object into its own independent object again.
		this.transform.parent = null;
		// Turn the gravity back on.
		GetComponent<Rigidbody>().useGravity = true;
		// Unfreeze the gameObject to make it move.
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		// Return the drag back to 0 to make movement.
		GetComponent<Rigidbody>().drag = 0;

		// This calculates the distance between theDest and the object's distance(?)
		float distance = (theDest.position - transform.position).magnitude;
		// Can the object be pushed?
		canPush = true;

        // If the distance between the Player and the pickable object is less or equals to 1.3f and can be pushed.
		if(distance <= 1.3f && canPush)
		{
			// Add force to throw the object after letting the mouse go.
			GetComponent<Rigidbody>().velocity = theDest.transform.forward * Throwspeed;
			// Can the object be thrown?
			isThrown = true;
			// Can the object be picked up?
			// I used this to avoid being able to spam the pick up button. It is optional.
			canBePicked = false;
		}

        // If the pickable object is thrown and cannot be picked.
		if(isThrown && !canBePicked)
		{
            // Starts a timer before being able to pick up the object again.
			StartCoroutine(WaitToPickUp());
		}
	}

	private IEnumerator WaitToPickUp()
	{
		while (true)
		{
            // Counts the timer set inside the (), once that timer reaches 0, then the Player is able to pick up the object again.
			yield return new WaitForSeconds(canBePickedTimer);
			canBePicked = true;
		}
	}

	// If the picked up object exits the collider of the player's hold, release the object from the player's hold.
	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "PickingUp" && isPicked)
		{
			isPicked = false;
			this.transform.parent = null;
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			GetComponent<Rigidbody>().drag = 0;

			// canPush is recommended to have as it bugs out with OnMouseUp and pushes the object when the mouse is lifted up despite releasing the object.
			canPush = false;
		}
	}

	// Allows the object to be pushed/kicked around when not picked up.
	private void OnTriggerStay(Collider mov)
	{
		if(mov.tag == "PickingUp" && !isPicked)
		{
			if(Input.GetKey(KeyCode.Mouse1))
			{
				GetComponent<Rigidbody>().AddForce(mov.transform.forward * pushSpeed + Vector3.up * kickHeight, ForceMode.Impulse);
			}
		}
	}
}

# Placing the script

Click and drag the `PickupObjects` script to the `Ball` Inspector tab.
You will see there is a `The Dest` in the `Pickup Objects (Script)` inside the `Inspector` tab, simply click and drag the `PickingUp` gameObject that is child to the `Main Camera` and drag it to `The Dest` in the script.
Also, you will notice that I have a lot of comment in the script, please make use of reading it to get an understanding of my script.
In the script above, you can push and kick the pickable object by pressing the `Right Mouse Button`.
To pick up the object, simply hold the `Left Mouse Button`, releasing the `Left Mouse Button` will throw the object.

You can edit the values in the `Inspector` tab to change its velocity.

Push speed = How fast will the object if pushed.
Kick height = How high will the object fly if kicked.
Can Be Picked Up Timer = This is the timer when the pickable object can be picked up again.
Throwspeed = How fast will the pickable object go when thrown.