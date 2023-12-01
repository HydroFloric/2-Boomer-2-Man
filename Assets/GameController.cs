using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private int _coinsCollected;
    private int _life;

    private void Start()
    {
        _life = 1;
        _coinsCollected = 0;
        Player.GetComponent<Animator>().SetBool("IsDead", false);
    }

    private void OnEnable()
    {
        EventManager.OnCoinCollected += UpdateCollectedCoins;
        EventManager.OnDamageTaken += UpdateLife;
    }
    private void OnDisable()
    {
        EventManager.OnCoinCollected -= UpdateCollectedCoins;
        EventManager.OnDamageTaken -= UpdateLife;
    }
    
    private void UpdateCollectedCoins()
    {
        _coinsCollected += 1;
    }

    private void UpdateLife()
    {
        _life -= 1;
        if (_life <= 0)
        {
            Player.GetComponent<Animator>().SetBool("isDead", true);
        }
        
    }


}
