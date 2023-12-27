using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.World
{
    public class TowerManager : MonoBehaviour
    {
        //! Supposedly checking if can spawn tower within the map or not
        [SerializeField] private int _currentTowers;

        public bool CanSpawnSpawnTower(int intValue)
        {
            int tempValue = _currentTowers + intValue;
            if(tempValue > WorldManager.Instance.LevelConfig._maxTowerManaAllowed)
                return true;
            return false;
        }
        
        public int GetCurrentTotalTower => _currentTowers;
    }
}
