using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    List<AudioSource> bouncesounds = new List<AudioSource>();
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;
    public AudioSource sound5;
    public int bouncecount = 0;

    // Start is called before the first frame update
    void Start()
    {
        bouncesounds.Add(sound1);
        bouncesounds.Add(sound2);
        bouncesounds.Add(sound3);
        bouncesounds.Add(sound4);
        bouncesounds.Add(sound5);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            bouncesounds[bouncecount].Play();
            bouncecount += 1;

        }
        if (bouncecount > 4)
        {
            bouncecount = 0;
        }

    }

}
