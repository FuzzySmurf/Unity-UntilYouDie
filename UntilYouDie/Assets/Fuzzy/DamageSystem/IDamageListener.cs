using UnityEngine;
using System.Collections;
using Fuzzy.Attribute;
using Fuzzy.Attribute.Model;
using Fuzzy.Attribute.UI;

namespace Fuzzy.Damage
{
    public interface IDamageListener<T>: ITriggerCollider 
        where T : IAdjustCurrent
    {
        T adjustableAttribute { get; }
        void DealDamage(IDamageMessage message);
    }

    /// <summary>
    /// Simply implemented for the Distributor
    /// </summary>
    public interface IDamageListener: IDamageListener<AdjustableAttribute>
    {
    }
}