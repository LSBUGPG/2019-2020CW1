using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Generate 5 cubes
        for (int i = 0; i < 5; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            int x = Random.Range(-70, 70);
            int z = Random.Range(-70, 70);

            cube.transform.position = new Vector3(x, 0, z);
            cube.transform.parent = transform;

            cube.transform.localScale = new Vector3(5, 5, 5);

            Rigidbody rb = cube.AddComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }

        //Generate 5 spheres
        for (int j = 0; j < 5; j++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
           
            int x = Random.Range(-70, 70);
            int z = Random.Range(-70, 70);

            sphere.transform.position = new Vector3(x, 0, z);
            sphere.transform.parent = transform;

            sphere.transform.localScale = new Vector3(3, 3, 3);

            Rigidbody rb = sphere.AddComponent<Rigidbody>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(Transform child in transform)
        {
            if (child.name == "Cube")
            {
                //move forward
                child.transform.Translate( Random.Range(0, 0.5f) * transform.forward );

                //turn every now and then
                if( Random.Range(0,100) == 50)
                {
                    int y = Random.Range(0, 360);
                    child.transform.eulerAngles = new Vector3(0, y, 0);
                }


            }
        }

    }
}
