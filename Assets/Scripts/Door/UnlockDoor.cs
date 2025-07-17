using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [Header("Door Parameters")]
    [SerializeField] private int requiredCoins = 10;
    [SerializeField] private GameObject doorObject;

    void Update()
    {
        void OnTriggerEnter3D(Collider trigger)
        {
            if (trigger.CompareTag("Player") && CoinManager.Instance._totalCoins >= requiredCoins)
            {
                doorObject.SetActive(false); // disattiva la porta (collider e visivo)
                this.enabled = false;
            }
        }
    }
}
