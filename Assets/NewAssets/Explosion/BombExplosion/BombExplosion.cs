using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    private float _explosionTimer = 0.5f;
    private float power = 10.0F;

    private void Update()
    {
        _explosionTimer -= Time.deltaTime;
        if (_explosionTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("need to implement something to do with the BombExplosion.cs!!!");
        if (other.CompareTag("Player"))
        {

            Vector3 explosionPos = transform.position;
            Vector3 dir = other.transform.position - explosionPos;
            Vector2 forceDir = dir;

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(dir.normalized * power, ForceMode2D.Impulse);
            }
        }

        if (other.CompareTag("BreakableObject")){ Destroy(other.gameObject);}

        if (other.CompareTag("Enemy")){ Destroy(other.gameObject);}
    }
}
