using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Interfaces.Item;
public class Coin : MonoBehaviour, ICollectable
{
    public static int CoinsCollected = 0;
    [SerializeField] private SOCoin coinData;
    [SerializeField] private SOCounter soCounter;

    public void ApplyPoint()
    {
        //CoinsCollected += coinData.CoinValue;
        soCounter.Counter += coinData.CoinValue;
        Destroy(gameObject);
    }
}
