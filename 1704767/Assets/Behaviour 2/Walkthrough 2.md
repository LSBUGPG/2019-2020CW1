# Walkthrough 2: Spotting UI

#### Canvas & UI

1. Create a *Canvas* via right clicking in your *Hierarchy* then selecting UI>*Canvas*
2. Create an *Image* GameObject via the same menu above, selecting UI>*Image*. It should appear as a child of the *Canvas*.
3. Select the *Image* GameObject in the *Hierarchy*. In the *Inspector* panel rename it "Pin" and then click *Add Component* at the bottom, type *PinUI* and then create a *new script* which you should open. (If you have an image prepared then in the *Inspector* assign it to the *Source Image* property of the Image Component on the GameObject.)
4. At the very top of the script, under

        using UnityEngine;

    add

        using UnityEngine.UI;

This gives us the ability to the interact with the UI Components Unity uses.

5. Next we want to declare 2 properties above the *Start* function.

        public Transform target;
        public Vector3 offset;
    The first property will be assigned by code from another script. The second will be assigned back in the *Unity Editor* in the *Inspector* panel.
    It's a good idea to set the *y axis* of the offset to a small positive number so the pin appears above the target.
6. Back to the script we need to rename *Update* to *LateUpdate*. This is a delayed version of the Update function and we will be using it so that our code is carried out after the the movement of everything else is resolved.
7. Inside of *LateUpdate* input the following code:

        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            var worldToScreenPoint = Camera.main.WorldToScreenPoint(target.position + offset);
            transform.position = worldToScreenPoint;
            GetComponent<Image>().enabled = worldToScreenPoint.z > 0;
        }

Let's dissect this.

        if (target == null)
        {
            Destroy(gameObject);
        }
            - If the target property is unassigned then *Destroy* the GameObject this script is on.
            We are doing this so that in the case that the target itself is destroyed (for example if the player kills it) then we will also destroy the pin tracking the target.

        else
        {
            var worldToScreenPoint = Camera.main.WorldToScreenPoint(target.position + offset);
            transform.position = worldToScreenPoint;
            GetComponent<Image>().enabled = worldToScreenPoint.z > 0;
        }
            - If the target still exists, then we want to keep tracking it. So we will move onto the code inside the braces.
            - The first line declares a local property (it can only be used in the function it's declared in) and sets it to equal the result of the *WorldToScreenPoint* function. This function is used to convert the target's position from 3D space into the 2D space the Canvas uses.
            - Next we assign the position of the GameObject the script is attached to to move towards this point in 2D space.
            - Finally, the Camera will show the pin even when it is behind the Camera which is undesirable. To counter this we only enable (display) the pin if the Camera is looking at the target. This is done by only enabling the pin when the z axis of *worldToScreenPoint* is greater than 0 as -1 indicates that the Camera is not looking at the target.
8. Now back in the *Unity Editor* drag and drop *Pin* from the *Hierarchy* into the *Project* panel. This saves it as a *prefab*, allowing us to reference it even when it is not in the scene. We will use the reference to *instantiate* (spawn) our *Pin*.

#### Spotting Script

1. On your *Camera* GameObject create a new script called *SpottingManager*. Inside it declare the following properties:


		public LayerMask layerMask; //the layer(s) of spottable GameObjects

		public GameObject pinPrefab; //a copy of a pin

		public Transform canvas; //used to assign as the parent of all pins

		List<Transform> pins; //A list of all the pins we are using

Back in the *Unity Editor* assign the 3 *public* properties in the *Inspector* panel. If you have not previously assigned your spottable GameObjects a layer then do so now by selecting them in the Hierarchy and then assigning and/or creating a  layer via the *Layer* dropdown list at the top of the *Inspector* panel.

2. Back with the script, inside the *Start* function add:

		pins = new List<Transform>(); //Finalise the setup for the list

3. Inside *Update* enter the code below:

		if (Input.GetMouseButtonDown(0)) //If the left mouse button is clicked...
		{
			if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity, layerMask)) //...and if a ray we shoot in the direction the camera is looking (forward) hits something on a layer marked at spottable...
			{
				if (!pins.Contains(hit.transform)){...then first check that the object we hit doesn't already have a pin. If it doesn't have a pin then...
					var go = Instantiate(pinPrefab, canvas); //...make a new pin! It's parent will be the canvas and for now we will call it go.
					go.GetComponent<PinUI>().target = hit.transform; //Access the PinUI script we wrote and tell the pin what its target is and...
					pins.Add(hit.transform); //...add it to the list of pins we have!
				}
			}
		}

4. You're good to go! Whenever the camera is looking at a spottable GameObject and you click, a pin will appear above it.
