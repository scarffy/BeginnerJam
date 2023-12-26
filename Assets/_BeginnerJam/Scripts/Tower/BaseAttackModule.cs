using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam
{
    public class BaseAttackModule : MonoBehaviour
    {
        [SerializeField] private int _attackDamage = 30;
        [SerializeField] private float _attackRate = 1.2f;
        [SerializeField] private float _nextAttack = 0f;

        private void Update()
        {
            // if (EEnemyState == EnemyState.isAttacking)
            // {
            //     AttackObject();
            // }
        }

        private void AttackObject()
        {
            // if (_nextAttack <= 0.0f)
            // {
            //     _damageable.DoDamage(_attackDamage);
            //     _nextAttack = _attackRate;
            // }
            // else
            // {
            //     _nextAttack -= Time.deltaTime;
            // }
        }
    }
}
