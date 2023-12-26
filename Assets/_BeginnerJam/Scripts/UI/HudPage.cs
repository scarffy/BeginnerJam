using System;
using System.Collections;
using System.Collections.Generic;
using BeginnerJam.Manager;
using BeginnerJam.World;
using UnityEngine;
using TMPro;

namespace BeginnerJam.UI
{
    public class HudPage : BaseUIPage
    {
        [SerializeField] private TextMeshProUGUI _gameCountDownText;
        [SerializeField] private TextMeshProUGUI _gameWaveText;
        [SerializeField] private TextMeshProUGUI _gameTotalEnemiesText;

        private void OnEnable()
        {
            Initialized();
        }

        public override void Initialized()
        {
            base.Initialized();

            EventPipeline.OnGameStart += StartWave;
        }

        public override void OpenPage()
        {
            base.OpenPage();
        }

        public override void ClosePage()
        {
            base.ClosePage();
        }

        private void StartWave()
        {
            GameManager.Instance.TimeManager.OnCountingDown += WaveCountDown;
        }

        private void WaveCountDown(float fValue)
        {
            _gameCountDownText.SetText($"Wave counting down: {(int)fValue}");
        }
    }
}
