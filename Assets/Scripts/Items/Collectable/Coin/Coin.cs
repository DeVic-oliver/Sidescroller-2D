using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Interfaces.Item;
public class Coin : MonoBehaviour, ICollectable
{
    public static int CoinsCollected = 0;
    public void ApplyPoint()
    {
        CoinsCollected++;
        Destroy(gameObject);
    }
}
