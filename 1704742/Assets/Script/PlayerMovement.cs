using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
   public GameObject talk;
   

    void Start ()

	{
		rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        ControlPlayer();
        rb.velocity = new Vector3(Input.GetAxis("Horizontal")* speed, rb.velocity.y, Input.GetAxis("Vertical")* speed);
    }


    void ControlPlayer()
    {	
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        if (movement != Vector3.zero)
        {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
         //Slerp makes your rotation smoother based on a value from 0 to 1
        }
            
    }


    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Npc" && SoundTrigger.enemy == 0)
        {
            talk.SetActive(true);
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "Npc")
        {
            talk.SetActive(false);
        }
    }

}
