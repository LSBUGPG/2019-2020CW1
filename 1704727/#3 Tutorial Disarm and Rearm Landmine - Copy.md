# How to disarm and rearm Landmine

Create an empty gameObject like you did in `MineCol`.
Rename this to `BoxCol` since this will also have a Collider.
Add a `Box Collider` on the `BoxCol`.
Go to `Transform` in the `Inspector` tab then change the size of the `Scale`.
Set it to `X = 4`, `Y = 4`, `Z = 4`.
Set the `Box Collider` to `Is Trigger`, it is important to check the `Is Trigger`.
Click and drag the `BoxCol` gameObject to the `Landmine` gameObject to set the `Landmine` as its parent.
Now the `Landmine` should have two `Child` gameObjects underneath its drop box.

# Create an Arming/Disarming script

Rename the script to `ArmDisarm`.

# Writing the script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmDisarm : MonoBehaviour {

	[SerializeField]
	GameObject MineCol1;

	private bool disarm = false;


	void OnTriggerStay(Collider col)
	{
		if(col.tag == "Player")
		{
			if(Input.GetKeyDown("e"))
			{
				disarm = !disarm;
			if(disarm == true)
			{
				MineCol1.GetComponent<SphereCollider>().enabled = false;
				Debug.Log("Disarmed");
			}

			else if(disarm == false)
			{
				MineCol1.GetComponent<SphereCollider>().enabled = true;
				Debug.Log("Bone of my swordo, armed");
			}

			}
		}
	}
}

# Placing the script

Click and drag `ArmDisarm` script to `BoxCol`.
In the `Inspector` tab of `BoxCol`, there should be an empty gameObject saying `None (Game Object)` and next to it says `Mine Col 1`.
Simply left click and hold the `MineCol` gameObject from the `Hierarchy` tab and drag it to the `None (Game Object)` of the `Mine Col `.
That's all.

# How to make it work

Play the scene, slowly walk up to the `Landmine` gameObject without triggering it in the scene, press `E` to disarm it and it should say `Disarmed` in the `Console` tab or just look at the very bottom left of Unity to see if it is disarmed. For rearming the `Landmine`, simply do the same step you did when disarming it, except you don't need to slowly walk up to it since it is disarmed. But, it will trigger the `Landmine` if you rearm it while being too close to it.
