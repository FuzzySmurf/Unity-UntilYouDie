using UnityEngine;
using System.Collections;
using Fuzzy.Damage;
using Sirenix.OdinInspector;

namespace Fuzzy.Damage
{
    /// <summary>
    /// This should be implemented on the Objects that will distribute damage
    /// For Example, Bullets, Arrows, Projectiles, Physical Weapons, etc.
    /// </summary>
    public abstract class DamageMessenger : SerializedMonoBehaviour, IDamageMessenger
    {
        public IDamageMessage damageMessage { get; set; }
    }
}