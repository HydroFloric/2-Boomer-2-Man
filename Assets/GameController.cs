using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int _coinsCollected;
    
    
    private void OnEnable()
    {
        EventManager.OnCoinCollected += UpdateCollectedCoins;

    }
    private void OnDisable()
    {
        EventManager.OnCoinCollected -= UpdateCollectedCoins;

    }
    
    private void UpdateCollectedCoins()
    {
        _coinsCollected += 1;
    }


}
