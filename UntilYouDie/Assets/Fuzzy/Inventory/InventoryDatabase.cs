using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Fuzzy.Entities;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Fuzzy.Inventory
{
    public class InventoryDatabase : SerializedMonoBehaviour
    {
        private List<InventoryItem> _listOfItems;

        [OdinSerialize]
        public List<InventoryItem> listOfItems
        {
            //get {return _listOfItems;}
            //private set { _listOfItems = value; }
            get; private set;
        }

        public bool AddItemToInventory(ItemObject item) {
            bool bOk = false;

            InventoryItem invItem = new InventoryItem() {
                itemObject = item,
                amount = 1
            };
            listOfItems.Add(invItem);
            bOk = true;

            return bOk;
        }
    }
}
