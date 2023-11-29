using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction OnCoinCollected;
    public static void CoinCollected() => OnCoinCollected?.Invoke();
    
    
    public static event UnityAction OnDamageTaken;
    public static void DamageTaken() => OnDamageTaken?.Invoke();

    
    

}
