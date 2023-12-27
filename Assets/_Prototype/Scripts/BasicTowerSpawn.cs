using System;
using BeginnerJam.Manager.Input;
using UnityEngine;

namespace BeginnerJam.Core
{
    public class BasicTowerSpawn : MonoBehaviour
    {
        [Header("Ray cast")]
        private Ray ray;
        private RaycastHit hit;
        float maxDistance = 100;
        public LayerMask layersToHit;
        
        [Header("Tower")] 
        [SerializeField] private GameObject _towerPrefab;
        [SerializeField] private GameObject _temporaryTower;

        [Header("Current Information")]
        [SerializeField] private bool _bIsFirstClick = false;
        [SerializeField] private bool _bIsDoneSpawn = true;

        /// <summary>
        /// This to change to fit new input system
        /// Prototyping tower spawn
        /// </summary>
        void Update()
        {
            //! Return if the state is ui only
            //! We would want the game to run logic in game or game and ui mode
            if (InputManager.Instance.inputState == InputManager.InputState.UIOnly)
            {
                Debug.Log($"[BasicTowerSpawn]: Stop method for UI Only mode");
                return;
            }

            //! Visualize tower rotation
            if (_bIsFirstClick && _temporaryTower != null)
            {
                float mousePosition = Input.mousePosition.x;
                _temporaryTower.transform.localRotation = Quaternion.AngleAxis(mousePosition, Vector3.up);
            }
            
            //! Check if we done spawning
            //! Second click
            if (Input.GetMouseButtonUp(0) && _bIsFirstClick && _temporaryTower != null)
            {
                _bIsFirstClick = false;
                _bIsDoneSpawn = true;
                _temporaryTower = null;
                return;
            }
            
            //! Spawn tower logic
            if (Input.GetMouseButtonUp(0) && !_bIsFirstClick && _bIsDoneSpawn)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out hit, maxDistance, layersToHit))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    GameObject tower = Instantiate(
                            _towerPrefab, 
                            hit.point, 
                        Quaternion.identity);
                    _temporaryTower = tower;
                }

                _bIsFirstClick = true;
                _bIsDoneSpawn = false;
                return;
            }

            //! Cancel spawn tower if user click on right mouse button
            if (Input.GetMouseButtonUp(1))
            {
                if (_temporaryTower != null)
                {
                    _bIsFirstClick = false;
                    _bIsDoneSpawn = true;
                    Destroy(_temporaryTower);
                    _temporaryTower = null;
                }
            }
        }
    }
}
