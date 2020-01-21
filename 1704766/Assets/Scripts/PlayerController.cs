using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Sprite[] chars;
    public SpriteRenderer mainchar;
    public Rigidbody2D rb;
    public Transform groundcheck;
    public LayerMask ground;
    public float speed;
    private bool grounded = false;
    public float jumpHeight;
    private Vector2 destination;
    private bool tpchar = false;
    private bool tp;
    public GameObject circle;
    public CircleCollider2D col;
    public float runSpeed;
    private bool sprint = true;
    private bool candoublejump;
    private bool doubleJump = false;
    public PhysicsMaterial2D wallSlide;
    public PhysicsMaterial2D wallStick;
    private bool wallstick = false;



    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Groundcheck raycast
        grounded = Physics2D.Raycast(groundcheck.transform.position, Vector2.down, 0.1f, ground);
        //Move right
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        //Move left
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        //Jump
        if (Input.GetAxis("Vertical") > 0 && grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            candoublejump = true;
        }
        //Second jump
        else if(Input.GetKeyDown(KeyCode.Space) && candoublejump == true && doubleJump == true)
        {    
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            candoublejump = false; 
        }
        //Sprinting
        if (Input.GetKey("left shift") && sprint == true) 
        {
            speed = runSpeed;
        }
        else 
        {
            speed = 8;        
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            tpchar = false;
            circle.SetActive(false);
            mainchar.sprite = chars[0];
            sprint = true;
            doubleJump = false;
            wallstick = false;
        }
        if (Input.GetKeyDown("2"))
        {
            tpchar = false;
            circle.SetActive(false);
            mainchar.sprite = chars[1];
            sprint = false;
            doubleJump = true;
            wallstick = false;
        }
        if (Input.GetKeyDown("3"))
        {
            tpchar = false;
            circle.SetActive(false);
            mainchar.sprite = chars[2];
            sprint = false;
            doubleJump = false;
            wallstick = true;
        }
        if (Input.GetKeyDown("4"))
        {
            tpchar = true;
            circle.SetActive(true);
            mainchar.sprite = chars[3];
            sprint = false;
            doubleJump = false;
            wallstick = false;
        }
        //Teleport
        destination = Input.mouseP osition;
        destination = Camera.main.ScreenToWorldPoint(destination);
        if ((Input.GetKeyDown(KeyCode.Mouse0)) && tp == true && tpchar == true)
        {
            transform.position = new Vector2(destination.x, destination.y);
        }

        circle.transform.localScale = Vector2.one * col.radius * 2;
    }
    void OnMouseOver()
    {
        tp = true;
    }
    void OnMouseExit()
    {
        tp = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" && wallstick == true)
        {
            other.collider.sharedMaterial = wallStick;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" && wallstick == true)
        {
            other.collider.sharedMaterial = wallStick;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            other.collider.sharedMaterial = wallSlide;
        }
    }
}
