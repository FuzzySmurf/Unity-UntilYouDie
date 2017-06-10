using UnityEngine;
using System.Collections;

namespace Fuzzy.Damage
{
    public interface IDamageMessenger
    {
        IDamageMessage damageMessage { get; set; }
    }
}