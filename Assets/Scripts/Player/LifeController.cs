using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _currentHP = 10;
    [SerializeField] private int _maxHP = 10;
    [SerializeField] private bool _fullHpOnAwake;

    private void Awake()
    {
        if(_fullHpOnAwake) SetHP(_maxHP);
    }

    public void SetHP(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHP);

        _currentHP = hp;
        if (_currentHP == 0) Die();
    }

    public void AddHP(int amount) => SetHP(_currentHP + amount);

    public void TakeDamage(int damage) => SetHP(_currentHP - damage);    

    private void Die()
    {
        Destroy(gameObject);
    }
}
