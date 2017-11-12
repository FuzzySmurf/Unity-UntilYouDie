using UnityEngine;
using System.Collections;
using Sirenix.Serialization;

namespace Fuzzy.Damage
{
    public interface IDamageMessenger
    {
        DamageMessage damageMessage { get; set; }
    }
}