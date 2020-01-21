using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    
    void OnCollisionEnter (Collision col)
    {

    if (col.gameObject.tag == "MainCamera")
        {
            Destroy (gameObject);
        }

    if (col.gameObject.tag == "Player")
        {
            Destroy (gameObject);
        }
    }

}
