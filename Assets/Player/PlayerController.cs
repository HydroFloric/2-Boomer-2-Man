using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput;
    private float _speed = 7;
    private float _verticalSpeed = 7;
    private bool IsGrounded;
    public SpriteRenderer spriteRenderer; 
    
    [SerializeField] private GameObject projectile;
    private Rigidbody2D _projectileRb;
    private GameObject _currentProjectile;
    
    
    [SerializeField] private Transform projectileSocket;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform tf;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Animator animator; 
    
    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        
        animator.SetFloat("GroundSpeed", Mathf.Abs(rb.velocity.x));
        
        if (isGrounded() && animator.GetBool("Falling")) {animator.SetBool("Falling", false);}
        if (rb.velocity.y < -0.5f) animator.SetBool("Falling", true);
        if (rb.velocity.y <= 0 && animator.GetBool("Jump")) animator.SetBool("Jump", false);

        
        Jump();
        ThrowBomb();
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    private void Move()
    {
        rb.velocity = new Vector2(_horizontalInput * _speed, rb.velocity.y);

        checkXDirection();

        //begin walk animation
        animator.SetFloat("speed", MathF.Abs(rb.velocity.x));
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, _verticalSpeed);
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
    
    private void ThrowBomb()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_currentProjectile) return;
            _currentProjectile = Instantiate(projectile, projectileSocket.position, Quaternion.identity);

            _projectileRb = _currentProjectile.GetComponent<Rigidbody2D>();

            if (_projectileRb)
            {
                _projectileRb.velocity = rb.velocity *1.5f;
            }
        
        }
    
    }
}
