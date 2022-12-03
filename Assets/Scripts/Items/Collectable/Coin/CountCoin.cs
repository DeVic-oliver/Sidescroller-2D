using System.Collections;
using UnityEngine;
using TMPro;
public class CountCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsPanel;
    private void Update()
    {
        UpdateCoinsPanel();
    }
    private void UpdateCoinsPanel()
    {
        coinsPanel.text = Coin.CoinsCollected.ToString();
    }
}
