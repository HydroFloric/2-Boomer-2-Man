using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public static class EventManager
{
    public static event UnityAction OnCoinCollected;
    public static void CoinCollected() => OnCoinCollected?.Invoke();
    
    
    public static event UnityAction OnDamageTaken;
    public static void DamageTaken() => OnDamageTaken?.Invoke();

    
    public static event UnityAction OnKeyCollected;
    public static void KeyCollected() => OnKeyCollected?.Invoke();

    public static event UnityAction PlayerAtDoor;
    public static void PlayerDoor() => PlayerAtDoor?.Invoke();

}
