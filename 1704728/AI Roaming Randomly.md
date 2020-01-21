AI ROAMING RANDOMLY

1. Create a new scene

        Make a new unity file in 3D.
        The newly create unity file will have the "Sample Scene".(You can change the name if you want)
        On the "Hierarchy", right click and choose "3D Object" > "Capsule".
        Click the "Capsule" and change the name to "AI" inside the "Inspector".
        Add a "Plane" on the "Hierarchy" just like when you create your Capsule.
	    Change the name of the "Plane" to "Ground".

        Optional: You can add obstacles if you want!

2. Setting a Nav Mesh

        Click your "AI" game object and on the "Inspector", add component > "Nav Mesh Agent".
        Select your "Ground" game object and obstacles (if you have) > Window > AI > Navigation.
        On the "Navigation", click the "Object" Tab and check "Navigation Static".
        Still inside the "Navigation", click "Bake" Tab and click "Bake".

        This process will make a walkable path for your roaming AI and also let the AI know where it can go or not. It works are invisible barrier as well.

3. Setting waypoints

        On the "Hierarchy", create an "Empty GameObject", rename it as "Waypoints".
        Add another "Empty GameObject"(rename it as "Points") and child it under "Waypoints".
        Under the "Inspector" Tab of "Points", click the cube icon and select any icon you want.
        On the "Hierarchy", select Points and "Ctrl + D" to duplicate the game object.
        Place "Points" all over "Ground, you can add as many as you can!

4. Adding the Roam Script

        Add new script named "roam_ai" on your "AI" game object using add component > new script on the "Inspector".
        Copy and paste the code below:

            using System.Collections;
            using System.Collections.Generic;
            using UnityEngine;
            using UnityEngine.AI;

            public class roam_ai : MonoBehaviour
            {
                public Transform[] wayPoints;
                [SerializeField]
                private NavMeshAgent navAgent;

                void Start()
                {
                    navAgent = GetComponent<NavMeshAgent>();
                    AINextDest();
                }

                void Update()
                {
                    if(navAgent.remainingDistance < 0.5f)
                    {

                    AINextDest();

                    }
                }

                void AINextDest(){

                    if(wayPoints.Length == 0)
                    {
                    return;
                    }

                     navAgent.destination = wayPoints[Random.Range(0, Depends on how many Points you have!)].position;
                }
            }


5. Making the AI roam

        Select your "AI" game object and on the "Inspector" > "Roam_ai(Script)" component, drag the "Nav Mesh Agent" component in it.
        Drag all the "Points" you have under the Way Points drop down in the "Roam_ai(Script)" component as well.

        Press Play and check for compilers.

6. Done!

        Congratulations on making your NPC roam randomly!
        You are awesome!        



    







    

    
