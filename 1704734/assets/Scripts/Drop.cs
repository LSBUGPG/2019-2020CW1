using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    public LayerMask layer;
    Game controller;

   
    void Start () {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
	}
	
	
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, -Vector2.up, Mathf.Infinity,layer);

            if (hit)
            {
                transform.position = hit.collider.gameObject.transform.position;
                controller.AddIngredient(gameObject);
                Destroy(gameObject.GetComponent<Drop>());                                                    //Delete Drop script so dropped ingredient doesn't respond to mouse
            }

            else 
            {
                Destroy(gameObject);                                                                         //Not over drop zone
            }
        }
    }
}
