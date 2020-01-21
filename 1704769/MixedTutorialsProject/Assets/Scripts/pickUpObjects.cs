using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUpObjects : MonoBehaviour
{
    GameObject[] pickUp;
  
    public Text Score;
    private int index;
    public int Points = 20;

    // Start is called before the first frame update
    void Start()
    {
        pickUp = GameObject.FindGameObjectsWithTag("Object");
        index = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Score.text = index.ToString();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            Destroy(collision.gameObject);

            index += Points;

        }
    }
}
