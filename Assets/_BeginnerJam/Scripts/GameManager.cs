using System.Collections;
using System.Collections.Generic;
using BeginnerJam.Core;
using UnityEngine;

namespace BeginnerJam.Manager
{
    using UI;
    using Input;
    using World;
    using AI;

    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<GameManager>();
                return _instance;
            }
        }

        private static GameManager _instance;
        #endregion

        [Header("Managers")]
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private WorldManager _worldManager;
        [SerializeField] private TimeManager _timeManager;
        [SerializeField] private AudioManager _audioManager;

        [Header("Temporary Settings")] 
        [SerializeField] private int _mana = 100;

        private void Start()
        {
            _audioManager.Initialize();
            _uiManager.Initialize();
            _inputManager.Initialize();
            _worldManager.Initialize();
            _timeManager.Initialize();
        }

        private void Update()
        {
            EventPipeline.UpdateEvent?.Invoke();

            
            //! TODO: To Remove this debug mode
            if (UnityEngine.Input.GetKeyUp(KeyCode.E))
            {
                StartGame();
            }
            
            //! TODO: Change this to new input system
            if (UnityEngine.Input.GetKeyUp(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        /// <summary>
        /// Start game before we start wave
        /// </summary>
        public void StartGame()
        {
            EventPipeline.OnGameStart?.Invoke();
            EventPipeline.OnGameEnd += GameEnd;

            _timeManager.OnCountDownEnd += GameStart;
            _timeManager.StartCountDown(_worldManager.LevelConfig._timeToStartWave);

            _uiManager.SetUIState(UIManager.UIState.hudUI);
        }

        private void GameStart()
        {
            EventPipeline.OnWaveStart?.Invoke();
        }

        private void GameEnd()
        {
            _uiManager.SetUIState(UIManager.UIState.startUI);
            _inputManager.SetInputState(InputManager.InputState.UIOnly);

            EnemyStateMachine[] stateMachine = FindObjectsOfType<EnemyStateMachine>();
            foreach (var item in stateMachine)
            {
                item.SetEnemyState(EnemyStateMachine.EnemyState.isDead);
            }
        }

        public TimeManager TimeManager => _timeManager;
    }
}
