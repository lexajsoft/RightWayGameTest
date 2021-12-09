using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private bool _immortal;
    [SerializeField] private int _hp;
    [SerializeField] private int _hpMax;

    public int Hp
    {
        get
        {
            return _hp;
        }
    }
    public int HpMax
    {
        get
        {
            return _hpMax;
        }
    }
    
    public void Init(int hp, int hpMax)
    {
        _hp = hp;
        _hpMax = hpMax;
    }
    public void Init()
    {
        _hp = _hpMax;
        Changed?.Invoke(_hp,_hpMax);
    }

    public bool IsLive()
    {
        if (_immortal)
            return true;
        
        return _hp > 0;
    }

    public void Damage(int damage)
    {
        _hp -= damage;
        if (_hp < 0)
        {
            _hp = 0;
        }
        Changed?.Invoke(_hp,_hpMax);
    }

    public void Heal(int heal)
    {
        _hp += heal;
        if (_hp > _hpMax)
        {
            _hp = _hpMax;
        }
        Changed?.Invoke(_hp,_hpMax);
    }

    public UnityAction<int, int> Changed;
}