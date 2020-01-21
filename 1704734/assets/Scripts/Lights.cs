using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{

    public GameObject light;


    // Use this for initialization
    void Start()
    {
        light.SetActive(false);
    }

    void OnMouseOver()
    {
        light.SetActive(true);
    }

    void OnMouseExit()
    {
        light.SetActive(false);
    }

	
    // Update is called once per frame
    void Update()
    {
		
    }
}
