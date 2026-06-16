using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinsChanged += UpdateCoins;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinsChanged -= UpdateCoins;
    }

    private void UpdateCoins(int amount)
    {
        coinText.text = "Moedas: " + amount;
    }
}