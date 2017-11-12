using Fuzzy.Damage;
using Fuzzy.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Fuzzy.Weapon
{
    public class Projectile : DamageMessenger
    {

        public float expireTime = 3.0f;
        private SpawnObject _spawnObject;
        private bool isFirstAttempt = true;
        public GameObject player;
        public int damage;

        public SpawnObject spawnObject
        {
            get
            {
                if (_spawnObject == null)
                    _spawnObject = this.GetComponent<SpawnObject>();
                return _spawnObject;
            }
        }

        private new Rigidbody rigidbody;

        public override void Awake()
        {
            base.Awake();

            rigidbody = GetComponent<Rigidbody>();
            damageMessage.sender = player;
            damageMessage.damageAmount = damage;
        }

        private void OnEnable()
        {
            if (isFirstAttempt == false)
                StartCoroutine(LifeSpan());
            else
                isFirstAttempt = false;
        }

        public void FixedUpdate()
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        }

        public IEnumerator LifeSpan()
        {
            Debug.Log("The Bullets Velocity: " + rigidbody.velocity);
            yield return new WaitForSeconds(expireTime);
            PoolManager.DeactivateObjects(spawnObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}