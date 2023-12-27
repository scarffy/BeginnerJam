using UnityEngine;

namespace BeginnerJam.World
{
    using Data;
    using Core;
    
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

        [Header("Object Pool Information")] 
        [SerializeField] private BulletPool _bulletPool;

        [SerializeField] private EnemyPool _enemyPool;
        
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

        public BulletPool BulletPool => _bulletPool;
        public EnemyPool EnemyPool => _enemyPool;

        public LevelConfig LevelConfig => _levelConfig;
    }
}
