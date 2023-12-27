using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.AI
{
    using Core;

    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;

        public EnemyState EEnemyState = EnemyState.isDead;
        public IDamageable _damageable;

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            SetEnemyState(EnemyState.isDead);
        }

        public void Initialize()
        {
            _enemyMovement.Initialize();
        }

        public void Trigger(Collider collider)
        {
            if (collider.gameObject.CompareTag("MainTower"))
            {
                _enemyMovement.SetAbleToMove(false);

                _damageable = collider.GetComponentInParent<IDamageable>();
                if (_damageable == null)
                    return;

                SetEnemyState(EnemyState.isAttacking);
            }
        }

        public void SetEnemyState(EnemyState state)
        {
            EEnemyState = state;

            switch (state)
            {
                case EnemyState.isMoving:
                    _enemyMovement.SetAbleToMove(true);
                    break;

                case EnemyState.isAttacking:
                    break;

                case EnemyState.isDead:
                    break;
            }
        }

        #region AttackModule
        [Header("Attack Module")]
        //! TODO: Separate this attack module
        [SerializeField] private int _attackDamage = 30;
        [SerializeField] private float _attackRate = 1.2f;
        [SerializeField] private float _nextAttack = 0f;

        private void Update()
        {
            if (EEnemyState == EnemyState.isAttacking)
            {
                AttackObject();
            }
        }

        private void AttackObject()
        {
            if (_nextAttack <= 0.0f)
            {
                _damageable.DoDamage(_attackDamage);
                _nextAttack = _attackRate;
            }
            else
            {
                _nextAttack -= Time.deltaTime;
            }
        }
        #endregion

        public enum EnemyState
        {
            isDead,
            isMoving,
            isAttacking

        }
    }
}
