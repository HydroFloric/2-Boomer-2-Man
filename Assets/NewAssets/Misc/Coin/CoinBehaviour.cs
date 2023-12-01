using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinBehaviour : MonoBehaviour
{
    private float _runningTime;
    private float startHeight;
    public bool isStatic = false; //Whether or not the coins move up and down
    void Start()
    {
        startHeight = transform.localPosition.y;
    }
    void Update()
    {
        if (!isStatic)
        {
            _runningTime += Time.deltaTime;
            var toY = (float)0.75 * Math.Abs(Mathf.Sin(_runningTime * 2)) + startHeight;
            transform.localPosition = new Vector3(transform.localPosition.x, toY, 0);
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
