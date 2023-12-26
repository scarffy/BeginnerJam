using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BeginnerJam.UI
{
    using Core;
    
    public class HealthHook : MonoBehaviour
    {
        [SerializeField] private BaseHealth _baseHealth;
        [SerializeField] private TextMeshPro _healthText;

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            _baseHealth.OnHealthChanged -= HealthChangeEvent;
        }

        public void Initialize()
        {
            if (_baseHealth == null)
                _baseHealth = GetComponent<BaseHealth>();

            _baseHealth.OnHealthChanged += HealthChangeEvent;
        }

        private void HealthChangeEvent(int healthValue)
        {
            _healthText.SetText($"{healthValue.ToString()} / {_baseHealth.MaxHealth.ToString()}");
        }
    }
}
