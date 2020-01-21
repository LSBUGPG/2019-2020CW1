using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 20f;

    Rigidbody2D rb;
    public float jumpSpeed = 10f;

    public bool isGrounded;


    public GameObject Platform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Platform.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
            float Move = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(movementSpeed * Move, rb.velocity.y);
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        { 
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            {
            isGrounded = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;

        }
    }

}