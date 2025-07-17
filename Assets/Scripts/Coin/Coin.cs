using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.ScrollRect;

public class Coin : MonoBehaviour
{
    private enum COIN_TYPE { BLUE, RED, YELLOW }

    [SerializeField] private COIN_TYPE _coinType = COIN_TYPE.BLUE;
    [SerializeField] private int value = 1;

    private void OnCoinType() // <- per scegliere quale tipo di moneta
    {
        switch (_coinType)
        {
            case COIN_TYPE.BLUE:
                value = 1;
                break;

            case COIN_TYPE.RED:
                value = 3;
                break;

            case COIN_TYPE.YELLOW:
                value = 5;
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoins(value);
            Destroy(gameObject);
        }
    }
}
