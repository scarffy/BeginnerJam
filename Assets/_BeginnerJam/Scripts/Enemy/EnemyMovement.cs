using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BeginnerJam.AI
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private GameObject _destination;
        [SerializeField] private NavMeshAgent _agent;

        [SerializeField] private bool bIsStopMoving = false;

        public void Initialize()
        {
            if(_destination == null)
                _destination = GameObject.Find("MainTower");

            if (_agent == null)
                _agent = GetComponent<NavMeshAgent>();

            if(_destination != null)
                _agent.SetDestination(_destination.transform.position);
            SetAbleToMove(false);
        }
        
        public void SetAbleToMove(bool moveable)
        {
            if (!moveable)
            {
                _agent.isStopped = true;
            }
            else
            {
                _agent.isStopped = false;
            }

            bIsStopMoving = _agent.isStopped;
        }
        
    } 
}
