using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    private float _explosionTimer = 0.5f;
    
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
        Debug.Log("need to implement something to do with the BombExplosion.cs!!!");
        //if (other.CompareTag("BreakableObject")){Destroy(other)}
        
        //if (other.CompareTag("Enemy")){ Destroy(other)}
    }
}
