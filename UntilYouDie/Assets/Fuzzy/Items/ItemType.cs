using UnityEngine;
using System.Collections;

namespace Fuzzy.Entities
{
    /// <summary>
    /// The ItemObject is used for any item that will be used as an item.
    /// It is expected, that any item used should be placed on the parent item.
    /// </summary>
    public abstract partial class ItemObject
    {
        public enum ItemType 
        {
            /// <summary>
            /// Item's are any sort of item that can be picked up by an Entity.
            /// </summary>
            Item = 0,

            /// <summary>
            /// Any Weapon that can be picked up by an entity.
            /// </summary>
            Weapon = 1,

            /// <summary>
            /// InstantApply items are instantly applied when they are picked up not
            /// stored in inventory. Items such as statBoosters, enchantments, etc.
            /// </summary>
            InstantApply = 2
        }
    }

}