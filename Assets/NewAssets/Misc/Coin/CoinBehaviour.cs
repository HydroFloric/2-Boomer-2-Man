using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinBehaviour : MonoBehaviour
{
    private float _runningTime;
    public bool isStatic = false; //Whether or not the coins move up and down
    void Update()
    {
        if (!isStatic)
        {
            _runningTime += Time.deltaTime;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y * (float)0.75 * Math.Abs(Mathf.Sin(_runningTime)) + 0.25f, 0);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            EventManager.CoinCollected();
        }
    }
}
