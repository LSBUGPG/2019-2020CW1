using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landminefirst : MonoBehaviour
{
    [SerializeField]
    Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            playerRigidbody.AddForce(-transform.forward * 30, ForceMode.Impulse);
        }
    }
}