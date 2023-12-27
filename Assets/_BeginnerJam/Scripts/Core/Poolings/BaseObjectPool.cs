using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BeginnerJam.Core
{
    /// <summary>
    /// This taken from unity learn tutorial (https://learn.unity.com/tutorial/introduction-to-object-pooling#5ff8d015edbc2a002063971d)
    /// I have never do something like this before
    /// </summary>
    public class BaseObjectPool : MonoBehaviour
    {
        public List<GameObject> pooledObjects;
        public GameObject objectToPool;
        public int amountToPool = 25;

        public Transform spawnParent;
        
        void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for(int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
                SetSpawnParent(tmp);
            }
        }

        public virtual void SetSpawnParent(GameObject spawnedObject)
        {
            if (spawnParent != null)
            {
                spawnedObject.transform.SetParent(spawnParent);
            }
        }
        
        public GameObject GetPooledObject()
        {
            for(int i = 0; i < amountToPool; i++)
            {
                if(!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
    }
}
