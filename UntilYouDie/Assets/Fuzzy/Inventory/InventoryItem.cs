using UnityEngine;
using System.Collections;
using Fuzzy.Entities;
using Sirenix.OdinInspector;

namespace Fuzzy.Inventory
{
    /// <summary>
    /// Used as a UI Canvas representation of the ItemObject being used.
    /// </summary>
    public class InventoryItem : MonoBehaviour
    {
        /// <summary>
        /// Contains an item Reference to the original Inventory Item.
        /// </summary>
        public ItemObject itemObject;

        [PropertyTooltip("The Quantity of 'this' item owned")]
        public int amount;

        private Texture2D _itemImage;

        public Texture2D itemImage {
            get {
                if (itemObject.itemImage != null && _itemImage == null)
                    _itemImage = itemObject.itemImage;
                else {
                    _itemImage = null;
                }
                return _itemImage;
            }
        }
    }
}