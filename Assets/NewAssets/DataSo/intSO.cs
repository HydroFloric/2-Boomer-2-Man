using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class intSO : ScriptableObject
{
    [SerializeField]
    private int _coin;
    public int coin
    {
        get { return _coin; }
        set { _coin = value; }
    }
}
