using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public int _totalCoins = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddCoins(int amount)
    {
        _totalCoins += amount;
    }
}
