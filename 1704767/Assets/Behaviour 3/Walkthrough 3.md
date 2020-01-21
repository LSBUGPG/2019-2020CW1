# Walkthrough 3: Smooth Camera Follow

1. Select the *Camera* GameObject in the *Hierarchy*. In the *Inspector* click *Add Component* at the bottom, type *CameraFollow* and then create a *new script* which you should open.

2. Now declare these properties above the *Start* function.

		public Transform target; //the object we want to look at

	    [Range(0f,1f)] //this lets us use a slider going from 0 - 1
	    public float followSpeed = 0.125f; //The higher the value the faster the camera moves

	    public Vector3 offset; //how far to sit behind target


Assign the *target* property back in the *Unity Editor* in the *Inspector* panel. The other 2 properties are best assigned when in *Play* mode so you can experiment with the best values. Wait until after step 4 to do that.

3. Rename *Update* to *LateUpdate*. LateUpdate is carried out after *Update* (which is where the movement of your target will happen) so that it gets the final position of the target for that frame.

4. Add the following code to the *LateUpdate* function:

		Vector3 nextPosition = target.position + offset; //create a local variable and set it to the target's position but with an offset
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, nextPosition, followSpeed); //create another local variable to store the result of the Lerp function
        transform.position = smoothedPosition;

        transform.LookAt(target.position);

The *Vector3.Lerp* function calculates a position on a direct line in-between the 2 positions you pass it. It moves forward by a fraction (*followSpeed*) of the distance of the line each time *LateUpdate* is called. This creates the effect of the Camera quickly or slowly moving towards its target.
