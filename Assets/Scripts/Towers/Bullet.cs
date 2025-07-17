using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, _lifeTime); // <- distrugge il bullet dopo un certo tempo 
    }

    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            //other.GetComponent<LifeController>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
