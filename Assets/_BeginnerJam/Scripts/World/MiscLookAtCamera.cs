using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace BeginnerJam.World
{
    public class MiscLookAtCamera : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToLookAt;
        [SerializeField] private Transform _camera;

        private void Start()
        {
            if (_camera == null)
            {
                _camera = Camera.main.transform;
            }

            if (_objectToLookAt == null)
            {
                Debug.LogError("There is no reference to Object");
            }
        }

        private void Update()
        {
            if(_camera == null)
                return;
            
            //_objectToLookAt.transform.LookAt(_camera);
            _objectToLookAt.transform.rotation =
                Quaternion.LookRotation(_objectToLookAt.transform.position - _camera.transform.position);
        }
    }
}
