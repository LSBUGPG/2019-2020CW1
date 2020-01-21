using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion1 : MonoBehaviour
{

    public float sphereSize = 0.2f;
    public int sphereInRow = 5;

    float spherePivotDistance;
    Vector3 spherePivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    public Material m_Material;

    // Use this for initialization
    void Start()
    {


        //calculate pivot distance
        spherePivotDistance = sphereSize * sphereInRow / 2;
        //use this value to create pivot vector)
        spherePivot = new Vector3(spherePivotDistance, spherePivotDistance, spherePivotDistance);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("Cube"));
        {
            explode();
        }

    }

    public void explode()
    {
        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x <sphereInRow; x++)
        {
            for (int y = 0; y < sphereInRow; y++)
            {
                for (int z = 0; z < sphereInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }
    
    void createPiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //assign material
        piece.GetComponent<Renderer>().material = m_Material;

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(sphereSize * x, sphereSize * y, sphereSize * z) - spherePivot;
        piece.transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = sphereSize;
    }

}