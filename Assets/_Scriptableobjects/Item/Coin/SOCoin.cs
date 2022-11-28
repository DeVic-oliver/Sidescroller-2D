using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Coin", menuName = "ScriptableObjects/Items/Coin", order = 1)]
public class SOCoin : ScriptableObject
{
    public int CoinValue;
}