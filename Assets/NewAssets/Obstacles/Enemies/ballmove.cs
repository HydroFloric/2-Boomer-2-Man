using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReverseBall : MonoBehaviour
{
    public float speed = 2.0f;
    public float reverseInterval = 3.0f; // The interval for timed turning
    public float stopReverseTime = 1.0f; //  the time to turn after stopping
    public float stopThreshold = 0.05f; // the speed threshold for determining a stop
    public Sprite leftSprite;    // set in the Inspector, 
    public Sprite rightSprite;   // set in the Inspector, 
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private float direction = 1;
    private float reverseTimer = 0;
    private float stopTimer = 0;
    private bool isStopping = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        MoveBall();
    }

    void Update()
    {
        /// logic for timed turning
        reverseTimer += Time.deltaTime;
        if (reverseTimer >= reverseInterval)
        {
            ReverseDirection();
        }

        // logic for turning after stopping
        if (Mathf.Abs(rb.velocity.x) < stopThreshold)
        {
            if (!isStopping)
            {
                isStopping = true;
                stopTimer = 0;
            }
            else
            {
                stopTimer += Time.deltaTime;
                if (stopTimer >= stopReverseTime)
                {
                    ReverseDirection();
                    isStopping = false;
                }
            }
        }
        else
        {
            isStopping = false;
        }
    
        // update the image based on the direction of movement
        if (direction < 0)
        {
            spriteRenderer.sprite = leftSprite;
        }
        else if (direction > 0)
        {
            spriteRenderer.sprite = rightSprite;
        }
    }
    

    private void MoveBall()
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }

    private void ReverseDirection()
    {
        direction *= -1;
        reverseTimer = 0;
        MoveBall();
    }
}