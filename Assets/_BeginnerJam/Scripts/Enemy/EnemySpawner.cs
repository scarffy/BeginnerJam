using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.World
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawnPlace[] _spawnPlaces;
        [SerializeField] private bool bIsReadyToStart = false;

        [Header("Information")] 
        [SerializeField] private int totalEnemies;
        [SerializeField] private int totalSpawnPlace;
        [SerializeField] private int index;
        
        public void Initialize()
        {
            if (_spawnPlaces.Length == 0)
            {
                _spawnPlaces = GetComponentsInChildren<EnemySpawnPlace>();
            }

            foreach (var spawnPlace in _spawnPlaces)
            {
                spawnPlace.Initialize();
            }
        }

        public void ReadyWave()
        {
            StartCoroutine(DistributeEnemiesAcross());
        }

        private IEnumerator DistributeEnemiesAcross()
        {
            totalEnemies = WorldManager.Instance.TotalEnemies;

            totalSpawnPlace = _spawnPlaces.Length - 1;
            index = 0;

            while (totalEnemies > 0)
            {
                _spawnPlaces[index].AddEnemyCount();
                if (index < totalSpawnPlace)
                {
                    index++;
                }
                else
                {
                    index = 0;
                }
                totalEnemies--;
            }

            bIsReadyToStart = true;
            yield return null;
        }

        public void StartSpawn()
        {
            Debug.Log($"[EnemySpawner]: Start Spawn method");
            foreach (var spawnPlace in _spawnPlaces)
            {
                spawnPlace.StartWave();
            }
        }

        public bool IsReadyToStart() => bIsReadyToStart;

    }
}
