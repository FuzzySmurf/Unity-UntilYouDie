using System;
using System.Collections;
using System.Collections.Generic;
using Fuzzy.Attribute.Model;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Fuzzy.Entities
{
    public abstract partial class ItemObject : SerializedMonoBehaviour
    {
        [OdinSerialize]
        [PropertyTooltip("Unique Identifier for 'this' itemObject")]
        [ReadOnly]
        public int ItemObjectID { get; set; }

        public virtual void Reset() {
            ItemObjectID = 2;
        }

        /// <summary>
        /// Description of an item to display to the player.
        /// </summary>
        [BoxGroup("Item Details")]
        public string Description;

        [BoxGroup("Item Details")]
        [PropertyTooltip("The image that will be rendered to represent the item(Ex. in the Inventory.SlotPanel)")]
        public Texture2D itemImage;

        /// <summary>
        /// IsSpecial is used to Define "Special Items" that can invoke unique Descriptions
        /// for Items that needs a special display message.
        /// </summary>
        [BoxGroup("Item Details")]
        [PropertyTooltip("Used to Identify a one-of-a-kind, unique Item, that requires a UniqueDescription to deliver to the player.")]
        public bool IsUnique = false;

        [BoxGroup("Item Details")]
        [EnableIf("IsUnique")]
        public List<string> UniqueDescription;

        [BoxGroup("Item Details")]
        public int Value = 0;

        [BoxGroup("Item Settings")]
        public bool IsStackable = true;

        /// <summary>
        /// Returns the instance ID of the object.
        /// </summary>
        public int GameObjectInstanceID {
            get { return GetInstanceID(); }
        }
    }
}