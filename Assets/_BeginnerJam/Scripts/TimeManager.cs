using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.Core
{
    /// <summary>
    /// Consolidate counting time for all relevant.
    /// TBH, I'm not sure if this is a good idea or not
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        //! To make this modular enough for other component to use this 
        //! For now, I only use this to start game event
        [SerializeField] private float _countTime = 1.0f;

        public Action OnCountDownStart;
        public Action<float> OnCountingDown;
        public Action OnCountDownEnd;

        public void Initialize()
        {
            
        }

        public void StartCountDown(float countTime)
        {
            OnCountDownStart?.Invoke();

            _countTime = countTime;

            EventPipeline.UpdateEvent += CountDownTime;
        }

        public void EndCountDown()
        {
            OnCountDownEnd?.Invoke();
            
            EventPipeline.UpdateEvent -= CountDownTime;
        }

        private void CountDownTime()
        {
            if (_countTime > 0)
            {
                _countTime -= Time.deltaTime;
                OnCountingDown?.Invoke(_countTime);

                if (_countTime <= 0.0f)
                {
                    EndCountDown();
                }
            }
        }
    }
}
