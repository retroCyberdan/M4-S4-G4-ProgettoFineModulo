using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _currentHP = 15;
    [SerializeField] private int _maxHP = 15;
    [SerializeField] private bool _fullHpOnAwake = true;

    [SerializeField] private UnityEvent<int, int> _onHpChanged;
    [SerializeField] private UnityEvent _onDeath;

    public int GetHP() => _currentHP;
    public int GetMaxHP() => _maxHP;

    private void Awake()
    {
        if(_fullHpOnAwake)
        {
            SetHP(_maxHP);
        }

        _onHpChanged?.Invoke(_currentHP, _maxHP);
    }

    public void SetHP(int hp)
    {
        int oldHP = _currentHP;
        hp = Mathf.Clamp(hp, 0, _maxHP);
        _currentHP = hp;

        if(oldHP != _currentHP)
        {
            _onHpChanged?.Invoke(_currentHP, _maxHP);
            if(_currentHP == 0)
            {
                _onDeath?.Invoke();
            }
        }
    }

    public void AddHP (int amount) => SetHP(_currentHP + amount);
}
