using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float HorizontalInput;
    private float Speed = 7;
    private float verticalSpeed = 7;
    private bool IsGrounded;
    public Animator animator; 
    public SpriteRenderer spriteRenderer; 
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform tf;
    [SerializeField] private LayerMask groundLayer;
    
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(HorizontalInput * Speed, rb.velocity.y);

        checkXDirection();

        //begin walk animation
        animator.SetFloat("speed", MathF.Abs(rb.velocity.x));
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalSpeed);
            checkXDirection();
            animator.SetBool("isJump", true);
            animator.SetBool("isGrounded", false);
        }
        else if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        else
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isGrounded", true);
        }
        
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(tf.position, 0.2f, groundLayer);
    }
    
    private void checkXDirection()
    {
         //flip direction boomerman is facing based on input
        if(rb.velocity.x > 0) 
        {
            spriteRenderer.flipX = true;
        }
        else if(rb.velocity.x < 0) 
        {
            spriteRenderer.flipX = false;
        }
    }

    //to do: death(), nake sure animator.isDead set to true
}
