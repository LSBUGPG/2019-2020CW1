using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Drag : MonoBehaviour
{
    public GameObject ingredient;
    Text descriptionTextBox;
    public string description;
    GameObject newObject;



    void Start()
    {
        descriptionTextBox = GameObject.FindGameObjectWithTag("Description").GetComponent<Text>();

    }
	
    void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        newObject = Instantiate(ingredient, mousePos, Quaternion.identity);
		
    }

    void OnMouseDrag()
    {
        if (newObject)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            newObject.transform.position = mousePos;
        }
    }

    void OnMouseOver()
    {
        descriptionTextBox.text = description;
    }

}