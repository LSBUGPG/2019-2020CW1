# Walkthrough 4: Tiny Planet with Gravity

### GravityAffector
1. In the *Unity Editor* create a sphere in the *Hierarchy* by right clicking and selecting 3D Object>*Sphere*. Scale this sphere up in the *Inspector* to 32 in all 3 axis.
2. At the bottom of the Inspector, click *Add Component* and type *GravityAffector* then create a new script and open it.
3. Declare a property:

		public float gravityStrength = -9.8f;

This property is the velocity that any given object will be pulled towards the affector with. -9.8m/s is the gravity we experience on Earth but experiment with other values.
4. Remove the *Start* and *Update* functions from your file and replace them with this:

		public void Affect(Transform body)
		{
			Vector3 gravityVector = (body.position - transform.position).normalized;

			body.GetComponent<Rigidbody>().AddForce(gravityVector * gravityStrength);

			Quaternion targetRotation = Quaternion.FromToRotation(body.up, gravityVector) * body.rotation;
			body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
		}

This is our own function that we can call from other scripts. Exciting.
It begins by declaring a local property to hold the result of calculation to get the direction (*gravityVector*) to pull objects in. Then it applies the gravity by multiplying it by the *gravityStrength* using the *AddForce* function on the *Rigidbody* of the target object.
Next *targetRotation* of *body* is calculated. This is done to get a rotation that is in-line with the *gravityVector*.
Finally the rotation of *body* is set to Slerp (smoothly move towards) the *targetRotation*.

### AffectedBody & PlayerLocomotion
1. In the *Unity Editor* create a cube in the *Hierarchy* by right clicking and selecting 3D Object>*Cube*.  At the bottom of the Inspector, click *Add Component* and type *Rigidbody* then cick the result to add it. Repeat this typing in "AffectedBody" this time and creating a new script. And once more create a script called "PlayerLocomotion".
2. Open the *AffectedBody* script and declare a property:

		public GravityAffector gravityAffector;

This will be a reference to the large sphere created earlier and the script on it. Assign it in the *Unity Editor* by dragging and dropping the sphere from the *Hierarchy* into the *Inspector* panel of the cube we made.
3. Back in the script we need to add some code to the *Start* function:

			var rbody = GetComponent<Rigidbody>(); //create a local property with a reference to our the Rigidbody on this object
	        rbody.constraints = RigidbodyConstraints.FreezeRotation; //stop the Rigidbody from changing the rotation of the object
	        rbody.useGravity = false; //stop the Rigidbody using default gravity

This is done to make sure any gravity affecting the object is by the other script we made and not Unity's own gravity. Very important.

4. Inside of the *Update* function add:

		gravityAffector.Affect(transform);

This line calls the *Affect* function we wrote in the *GravityAffector* script and tells it to do it's funky gravity stuff on us(*transform*).

5. Now open up the *PlayerLocomotion* script we made at the start of this section. Declare a new property:

		public float speed;

Assign this back in the Editor, 15 is a good start.

6. Rename *Update* to *FixedUpdate* and input this following:

		var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		var rBody = GetComponent<Rigidbody>();
		rBody.MovePosition(rBody.position + transform.TransformDirection(dir * speed * Time.fixedDeltaTime));

The *direction* property tracks the *Input* (from the arrow keys or WASD) in an easily accessible way (*direction*). It's quite long to keep writing otherwise.
Then it gets the *Rigidbody* of the object and assigns the position to be moved to based on the *direction* and *speed*. The *TransformDirection* function is used to orient the movement to take into account the rotation of the object.
7. Press *Play* in the *Editor* and walk around.
