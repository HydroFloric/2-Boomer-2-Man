using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

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
