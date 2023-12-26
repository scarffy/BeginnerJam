using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BeginnerJam.World
{
    using Data;
    using AI;
    
    public class WorldManager : MonoBehaviour
    {
        #region Singleton
        public static WorldManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<WorldManager>();
                return _instance;
            }
        }
        private static WorldManager _instance;
        #endregion

        [SerializeField] private EnemySpawner _enemySpawner;
        
        [Header("Settings")] 
        [SerializeField] private LevelConfig _levelConfig;

        [Space(10)] [SerializeField] private int _totalObjectPool = 25;
        [SerializeField] private List<GameObject> _objectPools;

        [SerializeField] private List<GameObject> _currentEnemyList;

        [FormerlySerializedAs("_currentEnemyInMap")]
        [Header("Current Information")] 
        [SerializeField] private int currentEnemiesInMap;
        [SerializeField] private int _totalEnemyAllowedInMap = 25;
        
        [SerializeField] private int _totalWaves
        {
            get => _levelConfig._totalWaves;
        }

        [SerializeField] private int _currentWave = 1;
        [SerializeField] private int _totalEnemy
        {
            get => _levelConfig._totalEnemy;
        }
        
        public void Initialize()
        {
            EventPipeline.OnWaveStart += StartWave;
            Debug.Log($"[World Manager]: Level information: total wave ({_totalWaves}) | total enemy ({_totalEnemy})");
        }

        public void StartWave()
        {
            //! To spawn enemies
            _enemySpawner.Initialize();
            if (!_enemySpawner.IsReadyToStart())
            {
                _enemySpawner.ReadyWave();
                _enemySpawner.StartSpawn();
            }
            else
            {
                _enemySpawner.StartSpawn();
            }
        }
        
        public int TotalEnemies => _totalEnemy;
        public int TotalWaves => _totalWaves;

        public void AddEnemyCountInMap() => currentEnemiesInMap++;
        public int CurrentEnemiesInMap => currentEnemiesInMap;
        public int TotalEnemyAllowedInMap => _totalEnemyAllowedInMap;
    }
}
