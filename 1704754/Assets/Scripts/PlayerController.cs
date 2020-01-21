using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Jump;
    private float Move;

    private Rigidbody2D rb;

    private bool Ground;
    public Transform CheckGround;
    public float CheckRadius;
    public LayerMask WhatIsGround;

    private int JumpExtra;
    public int ExtraJumpValue;

    private void Start()
    {
        JumpExtra = ExtraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Ground = Physics2D.OverlapCircle(CheckGround.position, CheckRadius, WhatIsGround);
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Move * Speed, rb.velocity.y);
    }
    private void Update()
    {
                if (Ground == true)
                {
                    JumpExtra = ExtraJumpValue;
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) && JumpExtra > 0)
                {
                    rb.velocity = Vector2.up * Jump;
                    JumpExtra--;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && JumpExtra == 0 && Ground == true)
                {
                    rb.velocity = Vector2.up * Jump;
                }
            }
        }
 