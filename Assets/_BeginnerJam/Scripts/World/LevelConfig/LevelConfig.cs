using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.Data
{
    [CreateAssetMenu(fileName = "LevelConfig",menuName = "Data/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        public int _totalEnemy = 10;
        public int _totalWaves = 10;

        public float _timeToStartWave;
        public int _maxTowerManaAllowed = 60;
    }
}
