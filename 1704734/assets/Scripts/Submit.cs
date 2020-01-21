using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submit : MonoBehaviour
{
    Game controller;
   
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
    }

    private void OnMouseDown()
    {
        controller.SubmitIngredients();
    }
}
