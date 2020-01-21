using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 30;
    public float turningSpeed = 60;
    public float damage = 0; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.position += new Vector3(horizontal, 0, vertical);

        //set the player color based on damage
        transform.GetComponent<Renderer>().material.color = new Color(1, 1 - damage, 1 - damage); // go from white to red. 
    }

    

    void OnCollisionEnter(Collision collision)
    {
        GameObject contact = collision.gameObject;

        //Pick up sphere
        if (contact.name == "Sphere")
        {
            Destroy(contact);
        }

        //Damage when hit by cube 
        if (contact.name == "Cube")
        {
            damage += 0.2f;

            if(damage > 1)
            {
                damage = 1;
            }

            
        }

        
        transform.GetComponent<Renderer>().material.color = new Color(1, 1 - damage, 1 - damage);


    }

}
