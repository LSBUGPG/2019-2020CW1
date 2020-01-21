PLAYER FIRST PERSON CONTROLLER


1. Create a new scene

        Make a new unity file in 3D.
        The newly create unity file will have the "Sample Scene".(You can change the name if you want)
        On the "Hierarchy", right click and choose "3D Object" > "Capsule".
        Click the "Capsule" and change the name to "Player", choose "Player" tag on the tag drop down under the filename inside the "Inspector".
        Still inside the "Capsule" game object "Inspector", remove the "Capsule Collider" component. (Right click > Remove Component).
        Add "Character Controller" component in the Capsule "Inspector".
        On the "Hierarchy", create an "Empty GameObject" (rename it as "axis_y) and child it under the Capsule. 
        Child the "Main Camera" under "axis_y".

	    Add a "Plane" on the "Hierarchy" just like when you create your Capsule.
	    Change the name of the "Plane" to "Ground".
	

2.  Adding the Keyboard Controller

        Add Component > New Script ("player_movement").
        Copy and paster the code below:

            using System.Collections;
            using System.Collections.Generic;
            using UnityEngine;

            public class player_movement : MonoBehaviour
            {

                [Header("Player Movement")]
                private CharacterController _controller;
                [SerializeField]
                private float _speed = 3.5f;
                private float _gravity = 9.81f;


                void Start()
                {
                    _controller = GetComponent<CharacterController>();

                }

                void Update()
                {
                    BasicMovement();
                
                }

                private void BasicMovement(){
        
                    float horiInput = Input.GetAxis("Horizontal");
                    float vertInput = Input.GetAxis("Vertical");
                    Vector3 direction = new Vector3 (horiInput, 0, vertInput);
                    Vector3 velocity = direction * _speed;
                    velocity.y -= _gravity;

                    velocity = transform.transform.TransformDirection(velocity);
                    _controller.Move(velocity * Time.deltaTime); 
                }
            }


3. Adding the Mouse Controller

        X Axis mouse movement

            Add a new script called "axisX" on your "Capsule"

            Copy and paste the code below:

                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                public class axisX : MonoBehaviour
                {

                [SerializeField]
                private float _sensitivity = 60f;

                    void Update()
                    {

                    float _mouseX = Input.GetAxis ("Mouse X");

                    Vector3 newRotation = transform.localEulerAngles;
                    newRotation.y += _mouseX * _sensitivity * Time.deltaTime;
                    transform.localEulerAngles = newRotation; 

                    }
                }

        Y Axis mouse movement

            Add a new script called "axisY" on your "axis_y"

                Copy and paster the code below:

                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                public class axisY : MonoBehaviour
                {

                [SerializeField]
                private float _sensitivity = 60f;
                private float _mouseY;

                    void Update()
                    {

                        _mouseY -= Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;
                        _mouseY = Mathf.Clamp (_mouseY, -90, 90);

                        transform.localEulerAngles = new Vector3 (_mouseY, transform.localEulerAngles.y, transform.localEulerAngles.z);
                    }
                }


4. Making the mouse pointer invisible during Game Mode

        Inside your "Player_movement" script>

            Inside the void Start, copy and paste:

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

            Inside the void Update, copy and paste:

                if(Input.GetKey(KeyCode.Escape))
                {

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                }
                

5. Done!

        Congratulations on making your playable character in First Person View!
        You are awesome!





    



        



         