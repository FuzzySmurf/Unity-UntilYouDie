using UnityEngine;

namespace Fuzzy
{
    /// <summary>
    /// IPickUpCollider is used to "PickUp" Items the collider comes in contact with.
    /// </summary>
    public interface IPickupCollider : ITriggerCollider
    {
        Collider coll { get; }
    }
}
