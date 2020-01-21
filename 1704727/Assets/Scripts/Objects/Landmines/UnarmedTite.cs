using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnarmedTite : MonoBehaviour {

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
