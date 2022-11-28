using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Interfaces.Item;
public class Coin : MonoBehaviour, ICollectable
{
    public static int CoinsCollected = 0;
    [SerializeField] private SOCoin coinData;

    public void ApplyPoint()
    {
        CoinsCollected += coinData.CoinValue;
        Destroy(gameObject);
    }
}
