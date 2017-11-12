using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;

namespace Fuzzy.Damage
{
    [System.Serializable]
    public class DamageMessage
    {
        public GameObject sender;

        public int damageAmount;
    }
}