ADDING A FLASHLIGHT

1. Setting it up

        Make sure you already have a "Player" in your scene. (You can use my Player FP Controller Tutorial)
        On the "Hierarchy", right click > Light > "Spotlight"
        Child your "Spotlight" under your player. (If you are using First Person View, child it under your main camera)
        Reset the transformation on the "Inspector" to place it in the right position.
        Adjust the placement to your liking.

2. Making the flashlight on and off.

        Add a new script named "flashlight_controller" on your "Spotlight" game object.
        Copy and paste the code below:

            using System.Collections;
            using System.Collections.Generic;
            using UnityEngine;

            public class flashlight_controller : MonoBehaviour
            {

            public bool flashlightOn;

                void Update()
                {
                    if(Input.GetKeyDown("f"))
                    {
                        flashlightOn = !flashlightOn;
                    }

                    if(flashlightOn == true)
                    {
                         GetComponent<Light>().enabled = true;
                    }

                    if(flashlightOn == false)
                    {
                        GetComponent<Light>().enabled = false;
                    }
                }
            }

3. Done!

        Congratulations on making your interactable flashlight!
        You are awesome!   
