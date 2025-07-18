using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public static CardsManager cM;
    [SerializeField] private TMP_Text _cardsCounter;
    public int _cards;

    private void Awake()
    {
        if (!cM) cM = this;
    }

    private void OnGUI() => _cardsCounter.text = _cards.ToString();

    public void AddCards(int amount)
    {
        _cards += amount;
    }
}
