using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fuzzy.Pooling;
using UnityEngine;

public class ZombieSpawner : SpawnerBase
{

	public override void Start () {
		base.Start();

	    SpawnObject obj = SpawnObjects.First().GetComponent<SpawnObject>();
	    PoolManager.SpawnGO(obj);
	}
	
}
