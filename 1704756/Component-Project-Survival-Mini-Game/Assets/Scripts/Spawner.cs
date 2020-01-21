using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

public GameObject Objects;
private float spawnTime = 1.5f;

	void Start () 
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn () 
	{	
		float spawnPointX = Random.Range (-10f, 12f);
		Vector3 spawnPosition = new Vector3(spawnPointX, 0.12f, 20f);

		GameObject spawner = Instantiate (Objects, spawnPosition, Quaternion.identity);
        spawner.SetActive(true);
	}
}