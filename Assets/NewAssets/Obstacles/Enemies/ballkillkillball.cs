using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventManager.DamageTaken();
        }
        
        if (other.CompareTag("Bomb") || other.CompareTag("Explosion"))
        {
            // kill ball
            Destroy(gameObject);
        }
    }
}
