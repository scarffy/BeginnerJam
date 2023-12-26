using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Reference")] [SerializeField] private Transform _orientation;
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _playerObject;
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _rotationSpeed;

        [SerializeField] private Transform _combatLookAt;

        public CameraStyle ECameraStyle = CameraStyle.Basic;
        
        public enum  CameraStyle
        {
            Basic,
            Combat,
            Topdown
        }

        private void Update()
        {
            //! Rotate Orientation
            Vector3 viewDir = _player.position -
                              new Vector3(transform.position.x, _player.position.y, transform.position.z);
            _orientation.forward = viewDir.normalized;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            //! Rotate player object
            if (ECameraStyle == CameraStyle.Basic)
            {
                Vector3 inputDirection = _orientation.forward * verticalInput + _orientation.right * horizontalInput;

                if (inputDirection != Vector3.zero)
                {
                    _playerObject.forward = Vector3.Slerp(_playerObject.forward, inputDirection.normalized,
                        Time.deltaTime * _rotationSpeed);
                }
            }
            
           
        }
    }
}
