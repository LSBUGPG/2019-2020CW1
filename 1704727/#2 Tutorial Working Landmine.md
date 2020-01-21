# Creating a working Landmine

For tutorial purposes, I highly recommend creating a 3D Sphere gameObject in the `Hierarchy` tab and rename this to `Landmine` or anything you want to know this is a landmine.
Add a Rigidbody to the `Landmine` and make sure it has its own Sphere collider.
Set the collision detection to `Continuous Dynamic`.
Check the `Use Gravity` and leave the `Is Kinematic` unchecked.
Create an empty gameObject and name this to `MineCol`.
This `MineCol` is a Mine Collider which I will use as the trigger. If the player enters the `MineCol` collider, the landmine will explode.
Create a Sphere Collider for the `MineCol`.
Go to the MineCol's `Inspector` tab, look for the `Transform` which is at the very top of the `Inspector` tab.
Change the `Scale` to `X = 2`, `Y = 2`, `Z = 2`.
This will change the Sphere collider's size in the `MineCol`.
It is also important to set the Sphere Collider to `Is Trigger`, simply check the `Is Trigger` on the MineCol `Inspector` tab.

Important Step: Click on the `Player` in the `Hierarchy` tab, in the `Inspector` tab, you must tag the `Player` as `Player` in the drop box otherwise this script will not work.

# Create a Landmine script

Rename the new script to `Landmine`.

# Writing the Landmine script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] GameObject Landmine;
    [SerializeField] float knockBack;
    [SerializeField] float knockUp;


    bool isArmed = true;

    private void Start()
    {
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player" && isArmed)
        {
            playerRigidbody.AddForce(-col.transform.forward * knockBack + Vector3.up * knockUp, ForceMode.VelocityChange);
            Destroy (Landmine);
            Destroy (GetComponent<BoxCollider>());
            Destroy (GetComponent<SphereCollider>());
        }
    }
}


# Placing the Landmine script

Click and drag this Landmine script to MineCol.
In the `Hierarchy`, select `MineCol` and in the `Inspector` tab where the `Landmine` script is, there would be something called `Landmine` with `None (Game Object)` meaning the `Landmine` gameObject is not yet set into the script.
You must left click and hold the `Landmine` gameObject from the `Hierarchy` and drag it to the `None (Game Object)`.
It should set the `Landmine` gameObject into the script.
Ignore the Player Rigidbody that says `None (Rigidbody)` since the script is already calling the Rigidbody of the Player at the `private void Start()` function.
Just in case if there is any error, simply click and drag the `Player` gameObject to the `Player Rigidbody` on the `Landmine` script.

Now the landmine should knock the player back if the player gets within the `MineCol` collider.

On the `Landmine` script, you can see `Knock Back` and `Knock Up` with a number on it.
Knock back = How far will the Landmine knock the player back.
Knock up = How high will the Landmine knock the player up.

You can edit these values as you wish.