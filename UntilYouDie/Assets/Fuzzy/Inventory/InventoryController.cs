using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fuzzy.Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using Sirenix.Serialization;

namespace Fuzzy.Inventory
{
    [RequireComponent(typeof(InventoryDatabase))]
    public class InventoryController : MonoBehaviour
    {
        [BoxGroup("InventoryConfig")]
        public string SlotsPanel = "Slots_Panel_BG";

        [BoxGroup("InventoryConfig")]
        [PropertyTooltip("Used to render the amount of slots the inventory will hold")]
        public int amountOfSlots = 16;

        private GameObject inventoryPanel;
        private GameObject slotPanel;

        [PropertyTooltip("the UI Slot that will be used as the background to hold items.")]
        public GameObject inventorySlot;

        public List<GameObject> slots = new List<GameObject>();
        private InventoryDatabase _inventoryDatabase;

        void Awake() {
            inventoryPanel = this.gameObject;
            slotPanel = inventoryPanel.transform.FindChild(SlotsPanel).gameObject;
            _inventoryDatabase = this.gameObject.GetComponent<InventoryDatabase>();
        }

        void Start() {
            RenderSlots();
        }

        private void RenderSlots() {
            for (int i = 0; i < amountOfSlots; i++) {
                slots.Add(Instantiate(inventorySlot));
                slots[i].transform.SetParent(slotPanel.transform);
            }
        }

        public bool AddItemToInventory(ItemObject item) {
            bool bOk = false;

            //check if item exists in db.
            InventoryItem obj = GetItemFromInventory(item);
            //if it does exist, check if it is stackable.
            if (obj != null) {
                if (item.IsStackable) {
                    obj.amount++;
                }
            }
            else {
                //if it doesn't exist, add it to the inventoryDB.
                _inventoryDatabase.AddItemToInventory(item);
            }

            return bOk;
        }

        private InventoryItem GetItemFromInventory(ItemObject item) {
            return _inventoryDatabase.listOfItems.FirstOrDefault(x => x.itemObject == item);
        }

        private InventoryItem GetItemFromInventory(int itemObjectID) {
            return _inventoryDatabase.listOfItems.FirstOrDefault(x => x.itemObject.ItemObjectID == itemObjectID);
        }
    }
}