using BeginnerJam.World;
using UnityEngine;

namespace BeginnerJam.AI
{
    using Core;
    
    public class BaseAttackModule : MonoBehaviour
    {
        [SerializeField] private int _attackDamage = 30;
        [SerializeField] private float _attackRate = 3f;
        [SerializeField] private float _nextAttack = 0f;
        
        [Header("Bullet Settings")]
        // [SerializeField] private GameObject _projectilPrefab;
        [SerializeField] private Transform _projectileSpawnTransform;

        [SerializeField] private GameObject _attackTarget;
        private IDamageable Damageable;
        
        [Header("Settings")]
        [SerializeField] private bool _bIsRotatable = false;

        [SerializeField] private Transform _rotatableObject;

        public void SetAttackTarget(GameObject target)
        {
            _attackTarget = target;
            
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
            if (_bIsRotatable)
            {
                if(_attackTarget != null)
                    _rotatableObject.LookAt(_attackTarget.transform.position);
            }

            if (_nextAttack <= 0)
            {
                // GameObject bullet = Instantiate(_projectilPrefab, _projectileSpawnTransform.position, _projectileSpawnTransform.rotation);
                GameObject bullet = WorldManager.Instance.BulletPool.GetPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = _projectileSpawnTransform.position;
                    bullet.transform.rotation = _projectileSpawnTransform.rotation;
                    bullet.SetActive(true);
                }

                _nextAttack = _attackRate;
            }

            _nextAttack -= Time.deltaTime;
        }
    }
}
