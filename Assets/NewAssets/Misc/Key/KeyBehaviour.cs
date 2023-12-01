using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class KeyBehaviour : MonoBehaviour
{
    public float followDelay = 0.5f; // Adjust the delay as needed
    private bool isHeld = false;
    private Transform playerTransform;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isHeld = true;
            playerTransform = collision.transform;
            EventManager.KeyCollected();
        }
    }

    void Update()
    {
        if (isHeld && playerTransform != null)
        {
                Vector3 targetPosition = new Vector3(
                playerTransform.position.x,
                playerTransform.position.y + 1.0f,
                playerTransform.position.z
                );            
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }
}
