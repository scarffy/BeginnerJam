using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.Manager.Input
{
    using UnityEngine.InputSystem;
    
    public class InputManager : MonoBehaviour
    {
        #region Singleton
        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<InputManager>();
                return _instance;
            }
        }
        private static InputManager _instance;
        #endregion
        
        public InputState inputState = InputState.UIOnly;

        [SerializeField] private PlayerInput _playerInput;

        public void Initialize()
        {
            SetInputState(InputState.UIOnly);
        }
        
        public void SetInputState(InputState state)
        {
            inputState = state;

            switch (state)
            {
                case InputState.GameOnly:
                    _playerInput.actions.FindActionMap("Player").Enable();
                    _playerInput.actions.FindActionMap("UI").Disable();
                    break;
                
                case InputState.UIOnly:
                    _playerInput.actions.FindActionMap("UI").Enable();
                    _playerInput.actions.FindActionMap("Player").Disable();
                    break;
            }
        }

        public enum InputState
        {
            GameOnly,
            UIOnly,
            GameAndUI
        }
    }
}
