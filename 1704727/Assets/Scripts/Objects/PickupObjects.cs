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

		if(isThrown && !canBePicked)
		{
			StartCoroutine(WaitToPickUp());
		}
	}

	private IEnumerator WaitToPickUp()
	{
		while (true)
		{
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

		if(other.tag == "Landmine" && isPicked)
		{
			isPicked = false;
			this.transform.parent = null;
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			GetComponent<Rigidbody>().drag = 0;
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
