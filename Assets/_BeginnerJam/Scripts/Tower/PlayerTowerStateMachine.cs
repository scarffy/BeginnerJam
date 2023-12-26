using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.AI
{
    public class PlayerTowerStateMachine : MonoBehaviour
    {
        public TowerState ETowerState = TowerState.seeking;

        [SerializeField] private List<GameObject> _targetList = new List<GameObject>();
        [SerializeField] private GameObject _attackTarget;
        [SerializeField] private BaseAttackModule _attackModule;


        public void AddTargetList(Collider collider)
        {
            Debug.Log($"[TowerStateMachine]: Adding target to list {collider.name}");
            if (collider.CompareTag("Enemy"))
            {
                if (!_targetList.Contains(collider.gameObject))
                    _targetList.Add(collider.gameObject);

                _attackTarget = _targetList[0];

                SetTowerState(TowerState.attacking);
            }
        }

        /// <summary>
        /// How to remove target from list when the target is dead?
        /// Remove target when it is out of bound
        /// Subscribe to event?
        /// </summary>
        /// <param name="target"></param>
        public void RemoveTargetList(Collider target)
        {
            if (_targetList.Contains(target.gameObject))
                _targetList.Remove(target.gameObject);

            if (_targetList.Count > 0)
            {
                _attackTarget = _targetList[0];
            }
            else
            {
                SetTowerState(TowerState.seeking);
            }
        }

        public void SetTowerState(TowerState state)
        {
            ETowerState = state;

            switch (state)
            {
                case TowerState.seeking:
                    EventPipeline.UpdateEvent -= _attackModule.AttackObject;
                    _attackModule.SetAttackTarget(null);
                    break;

                case TowerState.attacking:
                    EventPipeline.UpdateEvent += _attackModule.AttackObject;
                    _attackModule.SetAttackTarget(_attackTarget);
                    break;
            }
        }

        public enum TowerState
        {
            seeking,
            attacking
        }
    }
}
