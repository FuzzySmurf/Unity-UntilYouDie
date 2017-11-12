using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using Fuzzy.Pooling;
using Sirenix.Serialization;

namespace Fuzzy.Weapon
{
    [System.Serializable]
    public class BulletBaseSpawner
    {
        public SpawnHandlerDetails handlerDetails;

        public GameObject SpawnLocation;

        public GameObject SpawnHandler;

        private int _spawnHandlerKey;
        // Use this for initialization
        public void Initialize()
        {
            _spawnHandlerKey = PoolManager.CreateNewSpawnHandler(SpawnHandler, handlerDetails);
            AddSpawnLocation();
        }

        public void AddSpawnLocation()
        {
            if (SpawnLocation != null)
            {
                bool bOk = PoolManager.AssignTransformToSpawnHandler(SpawnLocation, _spawnHandlerKey);
                if (!bOk)
                    Debug.Log("Cannot Find SpawnHandler! Cannot Add locations.");
            }
        }

        public SpawnObject AddSpawnObjectToHandler(GameObject spawnObject)
        {
            SpawnObject ret = null;
            if (spawnObject != null)
            {
                ret = PoolManager.AddGOToSpawnPool(spawnObject, _spawnHandlerKey);
            }
            return ret;
        }
    }
}