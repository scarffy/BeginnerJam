using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BeginnerJam.Core
{
    public class BaseTrigger : MonoBehaviour
    {
        public UnityEvent<Collider> OnTrigger;
        public UnityEvent<Collider> OnTriggeredStay;
        public UnityEvent<Collider> OnTriggerExited;

        private void OnTriggerEnter(Collider collider)
        {
            OnTrigger?.Invoke(collider);
        }

        private void OnTriggerStay(Collider collider)
        {
            OnTriggeredStay?.Invoke(collider);
        }

        private void OnTriggerExit(Collider collider)
        {
            OnTriggerExited?.Invoke(collider);
        }
    }
}
