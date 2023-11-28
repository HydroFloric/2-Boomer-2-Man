using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinBehaviour : MonoBehaviour
{
    private float _runningTime;
    void Update()
    {
        _runningTime += Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x ,(float)0.75* Math.Abs(Mathf.Sin(_runningTime * 2))+0.2f,0);
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
