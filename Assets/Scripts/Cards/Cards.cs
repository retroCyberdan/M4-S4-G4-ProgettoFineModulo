using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField] private int _value;
    private bool _hasTriggered;

    private CardsManager _cardsManager;

    private void Start()
    {
        _cardsManager = CardsManager.cM;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && !_hasTriggered)
        {
            _hasTriggered = true;
            _cardsManager.AddCards(_value);
            Destroy(gameObject);
        }
    }
}
