using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    private int coins = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;

            PlayerObserverManager.NotifyCoinCollected(coins);

            Destroy(other.gameObject);
        }
    }
}
