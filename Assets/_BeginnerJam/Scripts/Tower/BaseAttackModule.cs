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
        [SerializeField] private GameObject _projectilPrefab;
        [SerializeField] private Transform _projectileSpawnTransform;

        [SerializeField] private GameObject _attackTarget;
        private IDamageable Damageable;

        [SerializeField] private bool _bIsRotateable = false;

        public void SetAttackTarget(GameObject target)
        {
            _attackTarget = target;

            //! TODO: Test this out
            if (target == null)
                return;

            //! Get damageable so we can see the target as attackable
            if (TryGetComponent(out IDamageable damageable))
            {
                Damageable = damageable;
            }
        }

        public void AttackObject()
        {
            if (Damageable == null)
                return;


            //! Look at the target
            if (_bIsRotateable)
            {
                transform.LookAt(_attackTarget.transform.position);
            }

            if (_nextAttack <= 0)
            {
                // Damageable.DoDamage(_attackDamage);
                //! Spawn projectile
                //! Do object pooling
                GameObject go = Instantiate(_projectilPrefab, _projectileSpawnTransform.position, _projectileSpawnTransform.rotation);

                _nextAttack = _attackRate;
            }

            _nextAttack -= Time.deltaTime;
        }
    }
}
