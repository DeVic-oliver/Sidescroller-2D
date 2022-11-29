using System.Collections;
using UnityEngine;
using TMPro;
public class CountCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsPanel;
    [SerializeField] private SOCounter soCounter;
    private void Update()
    {
        //UpdateCoinsPanel();
        UpdateCoinsViaScriptableObject();
    }
    private void UpdateCoinsPanel()
    {
        coinsPanel.text = Coin.CoinsCollected.ToString();
    }
    private void UpdateCoinsViaScriptableObject()
    {
        coinsPanel.text = soCounter.Counter.ToString();
    }
}
