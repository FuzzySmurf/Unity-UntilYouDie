using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

namespace Fuzzy.Damage
{
    public interface IDamageMessage 
    {
        GameObject sender { get; set; }

        int damage { get; set; }
    }
}