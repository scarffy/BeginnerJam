using System.Collections;
using System.Collections.Generic;
using BeginnerJam.AI;
using UnityEngine;

namespace BeginnerJam.World
{
    public class EnemySpawnPlace : MonoBehaviour
    {
        [Header("Enemy")] 
        [SerializeField] private GameObject _enemyPrefab;
        
        [Header("Information")]
        [SerializeField] private int _totalEnemiesToSpawn;

        [Header("Settings")] 
        [SerializeField] private float _spawnRate = 1.5f;
        [SerializeField] private float _nextSpawn = 1.5f;
        [SerializeField] private bool bCanStartSpawn = false;
        
        public void AddEnemyCount() => _totalEnemiesToSpawn++;

        public void Initialize()
        {
            EventPipeline.UpdateEvent += StartSpawn;
        }

        public void DeInitialize()
        {
            EventPipeline.UpdateEvent -= StartSpawn;
        }

        public void StartWave()
        {
            bCanStartSpawn = true;
        }

        public void EndWave()
        {
            bCanStartSpawn = false;
        }
        
        private void StartSpawn()
        {
            if(!bCanStartSpawn)
                return;
            
            //! Check ObjectPools if we can reuse
            //! If ObjectPools is more than we can reuse, instantiate a new one
            //! Instantiate/Reuse Enemy object
            //! Add current enemy index

            if (_nextSpawn < _spawnRate)
            {
                _nextSpawn += Time.deltaTime;
            }
            else
            {
                if(_totalEnemiesToSpawn < 0)
                    return;

                if (WorldManager.Instance.CurrentEnemiesInMap >= WorldManager.Instance.TotalEnemyAllowedInMap)
                    return;

                _nextSpawn = 0;
                GameObject go = Instantiate(_enemyPrefab, transform.position, transform.rotation);
                _totalEnemiesToSpawn--;

                EnemyStateMachine enemyState = go.GetComponent<EnemyStateMachine>();
                enemyState.SetEnemyState(EnemyStateMachine.EnemyState.isMoving);

                WorldManager.Instance.AddEnemyCountInMap();
            }
        }
    }
}
