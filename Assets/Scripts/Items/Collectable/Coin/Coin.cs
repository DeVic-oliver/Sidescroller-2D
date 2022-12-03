using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Core.Interfaces;
public class Coin : MonoBehaviour, ICollectable
{
    public static int CoinsCollected = 0;
    [SerializeField] private SOCoin soCoin;

    public void ApplyPoint()
    {
        CoinsCollected += soCoin.CoinValue;
        Destroy(gameObject);
    }
}
