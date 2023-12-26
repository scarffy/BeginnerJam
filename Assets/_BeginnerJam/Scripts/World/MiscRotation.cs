using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.World
{
    public class MiscRotation : MonoBehaviour
    {
        [SerializeField] private Transform _objectToRotate;
        [SerializeField] private float _rotationSpeed = 45f;

        //! TODO: To consolidate world update method in one place
        private void Update()
        {
            _objectToRotate.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        }
    }
}
