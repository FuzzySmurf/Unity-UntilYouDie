using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Fuzzy.Pooling;

public class SpawnerBase : MonoBehaviour
{
    public SpawnHandlerDetails handlerDetails;
    protected int _spawnHandlerKey;

    public List<GameObject> SpawnLocations;
    public List<GameObject> SpawnObjects;


    public virtual void Start()
    {
        _spawnHandlerKey = PoolManager.CreateNewSpawnHandler(this.gameObject, handlerDetails);
        AddSpawnLocations();
        AddSpawnObjectsToHandler();

    }

    protected void AddSpawnLocations()
    {
        if (SpawnLocations.Any())
            foreach (var loc in SpawnLocations)
            {
                bool bOk = PoolManager.AssignTransformToSpawnHandler(loc, _spawnHandlerKey);
                if (!bOk)
                    Debug.Log("Cannot Find SpawnHandler! Cannot Add locations." + this.name);
            }
    }

    protected void AddSpawnObjectsToHandler()
    {
        if (SpawnObjects.Any())
            foreach (var obj in SpawnObjects)
            {
                PoolManager.AddGOToSpawnPool(obj, _spawnHandlerKey);
            }
    }
}
