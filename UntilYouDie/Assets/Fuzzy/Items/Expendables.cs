using UnityEngine;
using System.Collections;
using Fuzzy.Attribute;
using Fuzzy.Attribute.Model;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Fuzzy.Entities
{
    public class Expendables : ItemObject
    {
        [OdinSerialize]
        [PropertyTooltip("This is for attribute boosts, if any.")]
        public bool hasAttributes = false;

        [OdinSerialize]
        [EnableIf("hasAttributes")]
        public Attributes attributes { get; set; }

        public int Health = 0;

        public int Mana = 0;

        public override void Reset() {
            attributes = new Attributes();
        }
    }
}