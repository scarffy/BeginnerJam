using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.Core
{
    public class BaseHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth = 0;
        [SerializeField] private int _currentHealth = 0;

        public Action<int> OnHealthChanged;

        private bool bCanDoDamange = true;

        public virtual void Start()
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            if (_currentHealth != _maxHealth)
                _currentHealth = _maxHealth;

            OnHealthChanged?.Invoke(_currentHealth);
        }

        public virtual void DoDamage(int damageValue)
        {
            if (_currentHealth > 0 && bCanDoDamange)
                _currentHealth -= damageValue;
            else if(_currentHealth <= 0)
            {
                DoDie();
                bCanDoDamange = false;
            }

            OnHealthChanged?.Invoke(_currentHealth);
        }

        public virtual void DoHeal(int healValue)
        {
            _currentHealth += healValue;
            if (_currentHealth >= _maxHealth)
                _currentHealth = _maxHealth;

            OnHealthChanged?.Invoke(_currentHealth);
        }

        public virtual void DoDie()
        {
        }

        public int MaxHealth => _maxHealth;
    }
}
