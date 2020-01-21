using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	Dictionary<string, string> potion;

	// Use this for initialization
	void Start () {
		potion = new Dictionary<string, string> ();
		potion.Add ("fire water", "steam");
		potion.Add ("rat steam", "arcane hair");
		print (potion["rat steam"]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
