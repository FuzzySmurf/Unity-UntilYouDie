using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fuzzy;
using Fuzzy.Entities;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Fuzzy.Inventory
{
    public class PickupCollider : SerializedMonoBehaviour, IPickupCollider
    {
        [OdinSerialize]
        [PropertyTooltip("Set to true if any/all items should be picked up, upon making contact with the IPickupCollider")]
        public bool autoPickUpItems { get; set; }

        public InventoryController inventory;

        public Collider coll
        {
            get { return _coll; }
            private set {
                if (_coll == null)
                {
                    _coll = value;
                    _coll.isTrigger = true; // Enable the Triggers
                }
            }
        }

        private Collider _coll;

        void Awake() {
            coll = gameObject.GetComponent<Collider>();
            //inventory = new InventoryController();
        }

        public void OnTriggerEnter(Collider collider) {
            //Check if the the collider is a pickUp Object, if its not, ignore it.
            ItemObject obj = collider.GetComponent<ItemObject>();
            if (obj == null)
                return;

            //If auto PickUp Items is set to false, do not auto pick up item on Enter.
            if (!autoPickUpItems)
                return;

            inventory.AddItemToInventory(obj);
        }

        public void OnTriggerStay(Collider collider) {
            //Render ItemBase CanvasUI
        }

        public void OnTriggerExit(Collider collider) {
            
        }
    }

}