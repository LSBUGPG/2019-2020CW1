# Hold Object Tutorial

A tutorial showing how to pick up an object and move it around and dropping it in a FPS game.

## Setup

This tutorial is a follow on from the previous one [FPSController](https://github.com/ie2990/IsabelElia_CW1/blob/master/Tutorial2_FPSController.md), please complete this before progressing with this tutorial.

Open the `FPSController` scene.

Select the `Object` cube in the scene and add a `Rigidbody` to it. This will apply gravity to the object meaning it will fall after the player has picked it up.

We now need to set the destination for the object to stay in once the player is holding it. We do this by creating an Empty Game Object which we can name `Destination` and parenting it to the `Player`. Drag the position of the `Destination` out and in front of the `Player` so it can be seen when the game is played.

## Creating the Script

Create a new script called `HoldObject`.

We now need to create a variable that tracks the `Destination` of the object so that the held item actually moved to that position.
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{

            public Transform Destination;
}
```

Now, under the variable we just created, we will now create our own method `OnMouseDown ()`. This is where we will attribute the `Destination` transform and we will also disable gravity so that the object doesn't fall once it has trasnformed to the `Destination`.

```
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<BoxCollider>().enabled = false;

        this.transform.position = Destination.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }
```

Next we will create a method for when the mouse button is released: `OnMouseUp ()`. In this we want to do the opposite of what happens when the mouse is pressed down and actually turn gravity back on for the object so it falls where the player has let go of it.

```
    private void OnMouseUp()
    {
        this.transform.parent = null;

        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
    }
```
Save and Attach the script to Unity.

## Back to Unity

After saving the script, go back into the Unity editor.

Attach the `HoldObject` script to the `Object` cube. 

Now we have to drag the `Destination` object into the empty Destination Slot in the `Hold Object (Script)` component in the `Object` Inspector. Also do this for any objects you want to be able to be picked up and moved around.

Press Play and test it is all working! 
