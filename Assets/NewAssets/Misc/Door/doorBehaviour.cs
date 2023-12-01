using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorBehaviour : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
    if (collision.gameObject.tag == "Player")
    {
        Debug.Log("at door");
        EventManager.PlayerDoor();
    }
   }
}
