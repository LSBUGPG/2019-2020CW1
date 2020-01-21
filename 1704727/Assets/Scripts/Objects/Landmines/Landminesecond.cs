using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landminesecond : MonoBehaviour
{
    [SerializeField] Rigidbody playerRigidbody;
    Rigidbody ObjRigidbody;
    [SerializeField] GameObject Landmine;
    [SerializeField] float knockBack;
    [SerializeField] float knockUp;


    bool isArmed = true;

    private void Start()
    {
        ObjRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody>();
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player" && isArmed)
        {
            // Formerly: playerRigidbody.AddForce((-col.transform.forward * 30f + Vector3.up * 3f), ForceMode.Force);
            // Removed due to adding Force.Impulse makes it impossible to stop movement with Vector3.
            //playerRigidbody.velocity = -col.transform.forward * 50f + Vector3.up * 5f;
            playerRigidbody.AddForce(-col.transform.forward * knockBack + Vector3.up * knockUp, ForceMode.VelocityChange);
            Destroy (Landmine);
            Destroy (GetComponent<BoxCollider>());
            Destroy (GetComponent<SphereCollider>());
        }

        else if(col.gameObject.tag == "PickableObject" && isArmed)
        {
            // Formerly: ObjRigidbody.AddForce((-col.transform.forward * 30f + Vector3.up * 3f), ForceMode.Force);
            ObjRigidbody.AddForce(-col.transform.forward * knockBack + Vector3.up * knockBack, ForceMode.VelocityChange);
            Destroy (Landmine);
            Destroy (GetComponent<BoxCollider>());
            Destroy (GetComponent<SphereCollider>());
        }
    }
}
