# 22/10/2019
I have added a player and finished the player's scripts along with the landmine.
I made a Collider and Rigidbody for both of these gameObjects.
I had problems with the player script in class early on, the player keeps spinning and won't stop spinning so I had to take a break from coding.
I could not resolve this issue, so I decided doing most of my work at home as this issue does not persist in my own computer.

# 29/10/2019
I have spent most of the time making the Landmine script, I have been able to successfully launch the player away but there is one problem that I encountered.
I had problems with the landmine launching the player in one direction due to using only:

playerRigidbody.AddForce(-transform.forward * 30, ForceMode.Impulse);

on the (Landminefirst) script.

However, launching the player away was my objective in this first script which was successful, so I created a duplicate script called (Landminesecond) which I have used for debugging purposes and implementing new mechanics that the first script did not have. Think of the first script as a Prototype.

I have tried doing:

playerRigidbody.AddForce(-transform.forward * 30 + Vector3.up * 5f, ForceMode.Impulse)

As my first test to fix myself being flung around in one direction which was successful.

# 5/11/2019
Playing around with the landmine caused me to notice some major error, the player keeps moving despite trying to move the player forward and stopping and then continues to move despite trying to counter the movement of the force. I have realized that using force against velocity does not overlap with each other. It is two separate thing that does not go against each other so the force is still being applied despite the player using the velocity. A fixable solution that my lecturer came up with is changing the player's movement to using force instead of velocity so I used the force movement instead.

# 12/11/2019
I began debugging and playing around with my player and landmine scripts, trying to achieve a different outcome that does not use ForceMode.Impulse.
I started using playerRigidbody.velocity which was successful at some point, so I reverted my controls back to using velocity instead of force.

# 19/11/2019
I added a new Box Collider on my landmine and began using OnTriggerStay for my Landmine so that if the player gets too close, they will get launched away.
I've had multiple problems with this idea, considering that using two Colliders in one gameObject would not work since I have to add the ability to arm and disarm the landmine which was turning off the Box Collider.
However, I managed to make the player disarm the landmine but cannot rearm the landmine again due to requiring the BoxCollider so I began debugging my script for quite some time.

# 26/11/2019
Fixed the problem of rearming and disarming. I had to create two new gameObjects that is a child of the landmine and created a Sphere Collider for MineCol and a Box Collider for BoxCol. I placed the script named UnarmedTite on the BoxCol and Landminesecond on the MineCol, removing the Landminesecond script from the parent gameObject.
I created a GameObject and private bool on the BoxCol script. The GameObject is used to reference the MineCol so that it can access the Sphere Collider and disarm or rearm the landmine. I used:

MineCol1.GetComponent<SphereCollider>().enabled = false;

This is to disarm the landmine. And then I created an else if statement where the Sphere Collider will be set to "true" which will rearm the landmine and enable the Sphere Collider again.

# 30/11/2019
I had created a new GameObject, made a new script called "PickupObject".
The idea was to allow the player interact with the gameObject by picking it up and holding it in front of them by holding the mouse button.
First, I added an empty gameObject in front of the player where the item held will be placed when picked up and then made it a child of the Main Camera of the player so that it floats directly in front of the player's viewpoint.

Second, I started writing the script for the PickupObject.

I first removed the gravity of the gameObject so that it doesn't fall down on the ground when picked up due to the gravity.
GetComponent<Rigidbody>().useGravity = false;

I then added the GameObject where the item held is going to transform, meaning where the object will go to if I pick it up.
this.transform.localPosition = theDest.position;

This script transforms the position of the picked up gameObject to the destination of where it should go to when picked up.

I then used the coding:
GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

This code allows me to stop the gameObject from moving when picked up.

Lastly, I set the gameObject that is picked up to be the child of the Pickup location.
this.transform.parent = GameObject.Find("PickingUp").transform;

This allowed me to make the picked up object to maintain its current position prior to the position of the Pickup location.


For my final part of this script, I wrote a script to make sure that when releasing the mouse, the object will be thrown away.
My major issue is the fact that any circular or moving object would cause the gameObject to still roll away when picked up or spin around the player for some odd reason.

# 3/12/2019
I have asked for help to assist me with trying to fix the gameObject from moving when picked up.
I was told about using Hinges on the gameObject to fix it, but the physics of the Unity engine makes it kind of hard for me to use the Hinge component.
So I decided to fix it by writing the script myself to fix it rather than using the Hinge components.

What I did to fix the moving object was to add and set more booleans and more scripts than I expected to do.
First, I added the drag onto the gameObject once picked up so that it drags the gameObject straight to the middle of its parent which is the holding location and prevents it from moving away.
I then made use of the Pickup location's Collider by adding an if statement.

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
