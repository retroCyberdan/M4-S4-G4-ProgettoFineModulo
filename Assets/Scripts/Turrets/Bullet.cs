using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, _lifeTime); // <- distrugge il bullet dopo un certo tempo 
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            LifeController target = collider.GetComponent<LifeController>();
            target.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
