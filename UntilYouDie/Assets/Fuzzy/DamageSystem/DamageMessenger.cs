using UnityEngine;
using System.Collections;
using Fuzzy.Damage;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;

namespace Fuzzy.Damage
{
    /// <summary>
    /// This should be implemented on the Objects that will distribute damage
    /// For Example, Bullets, Arrows, Projectiles, Physical Weapons, etc.
    /// </summary>
    [ShowOdinSerializedPropertiesInInspector]
    public abstract class DamageMessenger : SerializedMonoBehaviour, IDamageMessenger 
    {
        [OdinSerialize]
        public DamageMessage damageMessage { get; set; }

        public virtual void Reset()
        {
            damageMessage = new DamageMessage();
        }

        public virtual void Awake()
        {
            if (damageMessage == null)
                damageMessage = new DamageMessage();
        }
    }
}