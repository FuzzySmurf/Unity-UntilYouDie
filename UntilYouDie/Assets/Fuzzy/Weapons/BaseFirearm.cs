using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Fuzzy.Pooling;
using Fuzzy.Entities;
using Sirenix.Serialization;
using Fuzzy.Entities;

namespace Fuzzy.Weapon
{

    public class BaseFirearm : WeaponObject
    {

        public int _currentAmmo;
        public int _maxAmmo;

        //private bool _isWeaponEquipped = false;

        public FirearmSettings firearmSettings;

        //Muzzle Flash

        [OdinSerialize]
        public BulletBaseSpawner bulletBaseSpawner;

        //Firearm Sound Effect.
        AudioSource gunShotAudio;

        //Reload Sound Effect
        AudioSource reloadAudio;

        public int bulletForce = 10;
        public float firearmRateOfFire = 0.5f;
        private float timeSinceLastShot;

        private SpawnObject _spawnObject;

        //public int maxMagazines;
        //public int curMagazines;

        public int currentAmmo
        {
            get
            {
                if (_currentAmmo <= 0)
                    _currentAmmo = 0;
                return _currentAmmo;
            }
        }

        public int maxAmmo { get { return _maxAmmo; } }

        //private SpawnerBase _spawner;

        public void Start()
        {
            bulletBaseSpawner.Initialize();
            _spawnObject = bulletBaseSpawner.AddSpawnObjectToHandler(damageMessenger.gameObject);
            timeSinceLastShot = firearmRateOfFire;
        }

        public void FixedUpdate()
        {
            timeSinceLastShot += Time.deltaTime;
        }

        /// <summary>
        /// Trigger to Fire the Weapon.
        /// </summary>
        public void FireWeapon()
        {
            if (DoWeHaveAmmo() && firearmSettings.IsWeaponEquipped)
            {
                if (timeSinceLastShot >= firearmRateOfFire)
                {
                    //Trigger Muzzle Flash

                    //Spawn Bullet
                    SpawnObject bulletSpawn = PoolManager.SpawnGOAt(_spawnObject, this.transform);

                    //Trigger Bullet Sound Effect
                    if (gunShotAudio != null)
                        gunShotAudio.Play();

                    //Decrement Current Ammo
                    _currentAmmo--;

                    bulletSpawn.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.TransformDirection(Vector3.forward) * bulletForce;
                    bulletSpawn.transform.localEulerAngles = new Vector3(0, bulletSpawn.transform.eulerAngles.y, 0);

                    timeSinceLastShot = 0.0f;
                }
            }
            else
            {
                //Display GUI Image : "Reload Weapon!"
            }
        }

        public bool DoWeHaveAmmo()
        {
            bool bOk = _currentAmmo > 0;
            return bOk;
        }
    }
}