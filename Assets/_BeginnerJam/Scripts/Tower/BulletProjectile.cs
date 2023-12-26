using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam
{
    public class BulletProjectile : MonoBehaviour
    {
        [SerializeField] private bool _bIsDebugging = false;

        [Header("Settings")]
        //! TODO: to get damage number from scriptable object (Stat system)
        [SerializeField] private int _damageAmount;
        [SerializeField] private Rigidbody _rigidbody;


        private void OnEnable()
        {
            if (!_bIsDebugging)
                Destroy(gameObject, 10f);

            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody>();

            EventPipeline.UpdateEvent += MoveBullet;
        }

        public void BulletTrigger(Collider collider)
        {

            if (collider.CompareTag("Enemy"))
            {
                Debug.Log("[BulletProjectile]: Found enemy");
                if (collider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.DoDamage(_damageAmount);
                    Debug.Log("[BulletProjectile]: Do damage to enemy");

                    gameObject.SetActive(false);
                }
            }
        }

        private void MoveBullet()
        {
            _rigidbody.AddForce(10 * transform.forward);
        }

        private void OnDisable()
        {
            EventPipeline.UpdateEvent -= MoveBullet;
        }
    }
}
