using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Fuzzy.Damage
{
    public interface IDamageDistributor : IDamageMessenger
    {
        List<IDamageListener> listeners { get; set; }

        Collider AreaOfEffect { get; set; }

        void DistributeDamage();
    }
}