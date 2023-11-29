using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    private float _timerToExplode = 3.0f;
    [SerializeField] private GameObject Explosion;
    void Update()
    {
        _timerToExplode -= Time.deltaTime;
        if (_timerToExplode <= 0)
        {
            Destroy(gameObject);
            Instantiate(Explosion, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        
        if (other.CompareTag("Wall"))
        {
            Instantiate(Explosion, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
