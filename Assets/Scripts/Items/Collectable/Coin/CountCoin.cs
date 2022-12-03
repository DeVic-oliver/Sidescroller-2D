using System.Collections;
using UnityEngine;
using TMPro;
public class CountCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsPanel;
    [SerializeField] private SOCounter soCounter;
    private void Update()
    {
        UpdateCoinsPanel();
    }
    private void UpdateCoinsPanel()
    {
        coinsPanel.text = Coin.CoinsCollected.ToString();
    }
}
