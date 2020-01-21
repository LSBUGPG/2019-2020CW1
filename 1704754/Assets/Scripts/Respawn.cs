using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform Player;
    public Transform respawnPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = respawnPoint.transform.position;
    }


}

