using UnityEngine;
using System.Collections;
using Fuzzy.Pooling;
using System.Linq;

public class FirearmSpawner : SpawnerBase
{
    public GameObject spawnHandler;
    // Use this for initialization
    public override void Start()
    {
        _spawnHandlerKey = PoolManager.CreateNewSpawnHandler(spawnHandler, handlerDetails);
        AddSpawnLocations();
        AddSpawnObjectsToHandler();
    }
}
