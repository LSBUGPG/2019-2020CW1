using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource sound;
    public static int enemy =1;

    void Start ()

	{
		sound = GetComponent<AudioSource>();
	}

    void Update()

    	{
           
    	}
        
        void OnCollisionEnter (Collision coll)
    {
        if ( coll.gameObject.tag  ==  "Enemy")
        {	 
            enemy = 0;
            sound.Play();
            Destroy (coll.gameObject);
        }
    }


}
