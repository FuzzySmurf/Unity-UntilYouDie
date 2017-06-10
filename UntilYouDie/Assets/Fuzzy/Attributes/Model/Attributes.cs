using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Fuzzy.Attribute.Model
{
    public class Attributes
    {
        [OdinSerialize]
        public int Strength { get; set; }

        [OdinSerialize]
        public int Agility { get; set; }

        [OdinSerialize]
        public int Intelligence { get; set; }

        [OdinSerialize]
        public int Dexterity { get; set; }

        [OdinSerialize]
        public int Power { get; set; }

        [OdinSerialize]
        public int Defence { get; set; }

        [OdinSerialize]
        public int Vitality { get; set; }

        [OdinSerialize]
        public int Magic { get; set; }
    }
}