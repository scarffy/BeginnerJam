using System.Collections;
using System.Collections.Generic;
using BeginnerJam.Manager.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BeginnerJam.UI
{
    public class SettingsPage : BaseUIPage
    {
        [Header("Buttons")]
        [SerializeField] private Button _audioButton;
        [SerializeField] private Button _graphicButton;
        [SerializeField] private Button _closeButton;

        [Header("Tabs")]
        [SerializeField] private GameObject _audioTab;
        [SerializeField] private GameObject _graphicTab;

        public override void Initialized()
        {
            base.Initialized();
            _closeButton.onClick.AddListener(CloseSettingPage);
        }
        
        public override void ClosePage()
        {
            base.ClosePage();
        }

        private void CloseSettingPage()
        {
            UIManager.Instance.SetUIState();
        }
    }
}
