using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
public class Coin : MonoBehaviour, ICollectable
{
    public static int CoinsCollected = 0;
    [SerializeField] private SOCounter soCounter;

    public void ApplyPoint()
    {
        CoinsCollected += coinData.CoinValue;
        Destroy(gameObject);
    }
}
