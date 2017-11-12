using System.Collections;
using System.Collections.Generic;
using Fuzzy.Attribute;
using Fuzzy.Attribute.Model;
using Fuzzy.Attribute.UI;
using Fuzzy.Damage;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Fuzzy.Damage
{

    [RequireComponent(typeof(Collider))]
    public class DamageListener : SerializedMonoBehaviour, IDamageListener<HealthSlider>
    {
        [OdinSerialize]
        public ImplementSliderModel initialHealthSlider { get; set; }

        public HealthSlider adjustableAttribute { get; set; }


        public Collider col
        {
            get { return _col; }
            private set {
                if (_col == null) {
                    _col = value;
                    _col.isTrigger = true; //Enable the triggers.
                }
            }
        }

        private Collider _col;

        public virtual void Reset() {
            initialHealthSlider = new ImplementSliderModel();
        }

        public virtual void Awake() {
            col = this.GetComponent<Collider>();
            adjustableAttribute = new HealthSlider(initialHealthSlider);
        }

        public virtual void OnTriggerEnter(Collider collider) {
            IDamageMessenger messenger;

            messenger = collider.GetComponent<IDamageMessenger>();
            if (messenger != null) {
                if (messenger.damageMessage.sender.name != this.transform.parent.gameObject.name) {
                    DealDamage(messenger.damageMessage);
                }
            }
        }

        public void OnTriggerStay(Collider collider) {}

        public void OnTriggerExit(Collider collider) {}

        public virtual void DealDamage(DamageMessage message) {
            adjustableAttribute.IncreaseCurrent(message.damageAmount);
        }
    }
}