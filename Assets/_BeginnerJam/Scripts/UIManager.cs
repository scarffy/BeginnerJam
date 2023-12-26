using System;
using System.Collections;
using System.Collections.Generic;
using BeginnerJam.UI;
using UnityEngine;

namespace BeginnerJam.Manager.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<UIManager>();
                return _instance;
            }
        }

        private static UIManager _instance;

        public UIState uistate = UIState.startUI;

        private BaseUIPage[] uiList = Array.Empty<BaseUIPage>();

        [SerializeField] private BaseUIPage _previousPage;

        [Header("Pages")]
        [SerializeField] private StartPage _startPage;
        [SerializeField] private SettingsPage _settingsPage;
        [SerializeField] private HudPage _hudPage;

        public void Initialize()
        {
            uiList = FindObjectsOfType<BaseUIPage>();

            foreach (var uiItem in uiList)
            {
                uiItem.Initialized();
            }
        }

        public void SetPreviousPage(BaseUIPage prevPage)
        {
            _previousPage = prevPage;
        }

        public void SetUIState(UIState state)
        {
            foreach (var uiItem in uiList)
            {
                uiItem.ClosePage();
            }

            uistate = state;

            switch (state)
            {
                case UIState.startUI:
                    //! how to best do this ui state?
                    _startPage.OpenPage();
                    break;

                case UIState.settingsUI:
                    _settingsPage.OpenPage();
                    break;

                case UIState.hudUI:
                    _hudPage.OpenPage();
                    break;
            }
        }

        public void SetUIState()
        {
            foreach (var uiItem in uiList)
            {
                uiItem.ClosePage();
            }

            _previousPage.OpenPage();
        }


        #region Enums
        public enum UIState
        {
            defaultUI,
            startUI,
            settingsUI,
            hudUI
        }
        #endregion
    }
}
