using System.Collections;
using System.Collections.Generic;
using BeginnerJam.Manager;
using BeginnerJam.Manager.Input;
using BeginnerJam.Manager.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BeginnerJam.UI
{
    public class StartPage : BaseUIPage
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingButton;

        public override void Initialized()
        {
            base.Initialized();
            
            _startButton.onClick.AddListener(StartGame);
            _settingButton.onClick.AddListener(OpenSettings);
        }

        private void StartGame()
        {
            base.ClosePage();
            InputManager.Instance.SetInputState(InputManager.InputState.GameOnly);
            GameManager.Instance.StartGame();
        }

        private void OpenSettings()
        {
            UIManager.Instance.SetPreviousPage(this);
            UIManager.Instance.SetUIState(UIManager.UIState.settingsUI);
        }
    }
}
