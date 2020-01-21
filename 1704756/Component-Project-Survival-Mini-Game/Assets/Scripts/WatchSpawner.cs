using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchSpawner : MonoBehaviour
{
    public GameObject Watches;
    private float spawnTime = 3f;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        float spawnPointX = Random.Range(-10f, 12f);
        Vector3 spawnPosition = new Vector3(spawnPointX, 0.12f, 20f);

        GameObject spawner = Instantiate(Watches, spawnPosition, Quaternion.identity);
        spawner.SetActive(true);
    }
}