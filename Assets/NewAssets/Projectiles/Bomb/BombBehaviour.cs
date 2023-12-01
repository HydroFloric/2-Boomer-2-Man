using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    private float _timerToExplode = 3.0f;
    //[SerializeField] private GameObject Explosion;
    [SerializeField] private ParticleSystem explosionParticles;
    [SerializeField] private GameObject Explosion;
    private bool isExploding = false;
    public Animator animator;

    void Update()
    {
        if (!isExploding)
        {
            _timerToExplode -= Time.deltaTime;

            if (_timerToExplode <= 0)
            {
                StartExplosion();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isExploding)
        {
            if (other.CompareTag("Ground"))
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else if (other.CompareTag("Wall") || other.CompareTag("Enemy") || other.CompareTag("BreakableObject"))
            {
                Explode();
            }
        }
    }

    void StartExplosion()
    {
        isExploding = true;
        animator.SetTrigger("explodeNow"); //control explosion animation

        //explodes after animation elapsed once
        Invoke("Explode", 1.10f);
    }

    void Explode()
    {
        Instantiate(Explosion, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        //Instantiate(Explosion, transform.position, Quaternion.identity);
        Instantiate(explosionParticles, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        explosionParticles.transform.position = transform.position;
        explosionParticles.Play(); // Start the particle system

        Destroy(gameObject);
    }
    
}
